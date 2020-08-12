using Cliente.Domain.Commands.Cliente;
using MediatR;
using System;

namespace Cliente.Domain.Commands
{
    public class NewClienteCommand : ClienteCommand, IRequest<GenericCommandResult>
    {
        public NewClienteCommand(string nome, int idade) 
        {
            Nome = nome;
            Idade = idade;
        }
    }
}
