using MediatR;
using System;

namespace Cliente.Domain.Commands
{
    public class DeleteClienteCommand : IRequest<GenericCommandResult>
    {
        public DeleteClienteCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
