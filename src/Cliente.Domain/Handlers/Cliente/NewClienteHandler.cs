using Cliente.Domain.Commands;
using Cliente.Domain.Repositories;
using Cliente.Domain.Validators.Cliente;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cliente.Domain.Handlers.Cliente
{
    public class NewClienteHandler : IRequestHandler<NewClienteCommand,GenericCommandResult>
    {
        private readonly IClientRepository _clientRepository;

        public NewClienteHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }


        public async Task<GenericCommandResult> Handle(NewClienteCommand request, CancellationToken cancellationToken)
        {
            var validator = new NewClienteValidator();
            var results = validator.Validate(request);
            if (!results.IsValid)
                return GenericCommandResult.Failure(results.Errors);
            var cliente = new Entities.Cliente(request.Nome, request.Idade);
            await _clientRepository.Create(cliente);
            return  GenericCommandResult.Success(cliente);
        }
    }
}
