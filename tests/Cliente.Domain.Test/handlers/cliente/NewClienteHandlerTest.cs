using Cliente.Domain.Commands;
using Cliente.Domain.Handlers.Cliente;
using Cliente.Domain.Repositories;
using NSubstitute;
using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Cliente.Domain.Test.handlers.cliente
{
    public class NewClienteHandlerTest
    {
        private readonly IClientRepository _repository;

        public NewClienteHandlerTest()
        {
            _repository = Substitute.For<IClientRepository>();
        }

        private async Task<GenericCommandResult> CreateRequest(string nome, int idade)
        {
            var handler = new NewClienteHandler(_repository);
            await _repository.Create(Arg.Any<Entities.Cliente>());
            var request = new NewClienteCommand(nome, idade);
            var result = await handler.Handle(request, CancellationToken.None);
            return result;
        }

        [Fact(DisplayName = "Handler - OK")]
        public async Task Handler_ok()
        {
            var result = await CreateRequest("Teste", 20);
            Assert.True(result.Ok);

        }

        [Fact(DisplayName = "Handler zero age - NOK")]
        public async Task Handler_zeroage_nok()
        {
            var result = await CreateRequest("Teste", 0);
            Assert.Equal(ErrorMessages.AgeEmpty,result.Errors.FirstOrDefault());

        }

        [Fact(DisplayName = "Handler age greater than 150 - NOK")]
        public async Task Handler_age_greater_150_nok()
        {
            var result = await CreateRequest("Teste", 151);
            Assert.Equal(ErrorMessages.AgeLessThan150, result.Errors.FirstOrDefault());

        }

        [Fact(DisplayName = "Handler age equal 150 - OK")]
        public async Task Handler_age_equal_150_ok()
        {
            var result = await CreateRequest("Teste", 150);
            Assert.True(result.Ok);

        }

        [Fact(DisplayName = "Handler empty name - NOK")]
        public async Task Handler_empty_name_3_nok()
        {
            var result = await CreateRequest(null,50);
            Assert.Equal(ErrorMessages.NameEmpty, result.Errors.FirstOrDefault());
        }
    

        [Fact(DisplayName = "Handler name less 3 - NOK")]
        public async Task Handler_name_less_3_nok()
        {
            var result = await CreateRequest("a", 50);
            Assert.Equal(ErrorMessages.NameLessThan3, result.Errors.FirstOrDefault());
        }

        [Fact(DisplayName = "Handler name more 100 - NOK")]
        public async Task Handler_name_more_than_100_nok()
        {
            var result = await CreateRequest("Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                "Maecenas dui arcu, cursus vitae varius luctus, sodales quis elit. Donec commodo, velit eget ultricies vehicula, quam lorem aliquet dui, at consequat magna risus at leo. " +
                "Integer sit amet diam ultrices, tempor purus nec, congue quam. Vestibulum sit amet lacinia lorem, eu faucibus dui. Donec commodo malesuada commodo. " +
                "In eu commodo ligula. Morbi dui elit, suscipit sed feugiat non, eleifend sit amet magna. Nam mattis maximus sapien, nec rhoncus lectus feugiat bibendum.", 50);
            Assert.Equal(ErrorMessages.NameMoreThan100, result.Errors.FirstOrDefault());
        }

        [Fact(DisplayName = "Handler name equal 100 - OK")]
        public async Task Handler_name_equal_100_ok()
        {
            var result = await CreateRequest("Lorem ipsum dolor sit amet, consectetur adipiscingLorem ipsum dolor sit amet, consectetur adipiscing", 50);
            Assert.True(result.Ok);
        }

    }
}
