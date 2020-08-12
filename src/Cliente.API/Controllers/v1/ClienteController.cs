using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cliente.Domain.Commands;
using Cliente.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IClientRepository _repository;
        private readonly IMediator _mediator;
        public ClienteController(
            IClientRepository repository,
            IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        [ProducesResponseType(typeof(List<Domain.Entities.Cliente>), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.Get());
        }

        [ProducesResponseType(typeof(GenericCommandResult), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NewClienteCommand command)
        {
            var result = await _mediator.Send(new NewClienteCommand(command.Nome, command.Idade));
            if (result.Ok)
                return Ok(result.Data);
            return BadRequest(result.Errors);
        }

        [ProducesResponseType(typeof(GenericCommandResult), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteClienteCommand(id));
            if (result.Ok)
                return Ok(result.Data);
            return BadRequest(result.Errors);
        }

        [ProducesResponseType(typeof(GenericCommandResult), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateClienteCommand command)
        {
            var result = await _mediator.Send(new UpdateClienteCommand(command.Id,command.Nome,command.Idade));
            if (result.Ok)
                return Ok(result.Data);
            return BadRequest(result.Errors);
        }
    }
}
