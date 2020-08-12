using Cliente.Domain.Commands.Cliente;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cliente.Domain.Validators.Cliente
{
    public class ClienteCommandValidator<T> : AbstractValidator<T> where T : ClienteCommand
    {
        public ClienteCommandValidator()
        {
            RuleFor(x => x.Nome)
              .NotEmpty()
              .WithMessage(ErrorMessages.NameEmpty)
              .MinimumLength(3)
              .WithMessage(ErrorMessages.NameLessThan3)
              .MaximumLength(100)
              .WithMessage(ErrorMessages.NameMoreThan100);

            RuleFor(x => x.Idade)
                   .GreaterThan(0)
                   .WithMessage(ErrorMessages.AgeEmpty)
                   .LessThanOrEqualTo(150)
                   .WithMessage(ErrorMessages.AgeLessThan150);
        }
    }
}
