using Cliente.Domain.Commands;
using Cliente.Domain.Handlers.Cliente;
using Cliente.Domain.Repositories;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Cliente.Domain.Test.handlers.cliente
{
    public class UpdateClienteHandlerTest
    {
        private readonly IClientRepository _repository;

        public UpdateClienteHandlerTest()
        {
            _repository = Substitute.For<IClientRepository>();
        }

        private async Task<GenericCommandResult> CreateRequest(Guid id, string nome, int idade)
        {
            var handler = new UpdateClienteHandler(_repository);
            var request = new UpdateClienteCommand(id, nome, idade);
            var result = await handler.Handle(request, CancellationToken.None);
            return result;
        }

        [Fact(DisplayName = "Handler - OK")]
        public async Task Handler_ok()
        {
            var id = Guid.NewGuid();
            _repository.Get(id).ReturnsForAnyArgs(new Entities.Cliente("Teste", 20));
            var result = await CreateRequest(Guid.NewGuid(),"Teste", 20);
            Assert.True(result.Ok);

        }

        [Fact(DisplayName = "Handler client not exists - NOK")]
        public async Task Handler_zeroage_nok()
        {
            _repository.Get(Arg.Any<Guid>()).ReturnsNull();
            var result = await CreateRequest(Guid.NewGuid(),"Teste", 20);
            Assert.Equal(ErrorMessages.ClientNofFound,result.Errors.FirstOrDefault());

        }

        [Fact(DisplayName = "Handler empty guid - NOK")]
        public async Task Handler_age_greater_150_nok()
        {
            var result = await CreateRequest(Guid.Empty,"Teste", 20);
            Assert.Equal(ErrorMessages.IdEmpty, result.Errors.FirstOrDefault());

        }
    }
}
