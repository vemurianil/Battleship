using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Battleship.API.Features.Attack
{
    [ApiController]
    [Route("[controller]")]
    public class AttackController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AttackController(IMediator mediator) => _mediator = mediator;

        [HttpPut]
        [Produces(typeof(bool))]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Attack(Attack request)
        {
            var res = await _mediator.Send(request);

            return Ok(res);
        }
    }
}

