using Cliente.Domain.Commands;
using FluentValidation;
using System;

namespace Cliente.Domain.Validators.Cliente
{
    public class UpdateClienteValidator : ClienteCommandValidator<UpdateClienteCommand>
    {
        public UpdateClienteValidator()
        {
            RuleFor(x => x.Id)
               .NotEqual(Guid.Empty)
               .WithMessage(ErrorMessages.IdEmpty);
        }
    }
}
