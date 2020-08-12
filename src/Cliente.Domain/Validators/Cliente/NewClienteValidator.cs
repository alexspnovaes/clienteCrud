using Cliente.Domain.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cliente.Domain.Validators.Cliente
{
    public class NewClienteValidator : ClienteCommandValidator<NewClienteCommand>
    {
    }
}
