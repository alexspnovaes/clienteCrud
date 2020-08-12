using Cliente.Domain.Commands.Cliente;
using MediatR;
using System;

namespace Cliente.Domain.Commands
{
    public class UpdateClienteCommand : ClienteCommand, IRequest<GenericCommandResult>
    {
        public UpdateClienteCommand(Guid id, string nome, int idade)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
        }

        public Guid Id { get; set; }
    }
}
