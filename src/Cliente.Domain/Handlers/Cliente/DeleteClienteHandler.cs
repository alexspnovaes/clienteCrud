using Cliente.Domain.Commands;
using Cliente.Domain.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cliente.Domain.Handlers.Cliente
{
    public class DeleteClienteHandler : IRequestHandler<DeleteClienteCommand,GenericCommandResult>
    {
        private readonly IClientRepository _clientRepository;

        public DeleteClienteHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }


        public async Task<GenericCommandResult> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clientRepository.Get(request.Id);
            if (cliente is null)
                return GenericCommandResult.Failure(new List<string> { "Cliente não encontrado" });
            await _clientRepository.Delete(cliente);
            return  GenericCommandResult.Success(cliente);
        }
    }
}
