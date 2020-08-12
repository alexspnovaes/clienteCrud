using Cliente.Domain.Commands;
using Cliente.Domain.Repositories;
using Cliente.Domain.Validators.Cliente;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cliente.Domain.Handlers.Cliente
{
    public class UpdateClienteHandler : IRequestHandler<UpdateClienteCommand,GenericCommandResult>
    {
        private readonly IClientRepository _clientRepository;

        public UpdateClienteHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }


        public async Task<GenericCommandResult> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateClienteValidator();
            var results = validator.Validate(request);
            if (!results.IsValid)
                return GenericCommandResult.Failure(results.Errors);

            var cliente = await _clientRepository.Get(request.Id);
            if (cliente is null)
                return GenericCommandResult.Failure(new List<string> { ErrorMessages.ClientNofFound  });
            cliente.Nome = request.Nome;
            cliente.Idade = request.Idade;
            await _clientRepository.Update(cliente);
            return  GenericCommandResult.Success(cliente);
        }
    }
}
