using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Battleship.API.Features.Ships
{
    [ApiController]
    [Route("[controller]")]
    public class ShipsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShipsController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        [Produces(typeof(int))]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Create(CreateShip create)
        {
            var res = await _mediator.Send(create);

            return Ok(res);
        }
    }
}

