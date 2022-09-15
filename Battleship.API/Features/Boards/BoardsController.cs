using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Battleship.API.Features.Boards
{
    [ApiController]
    [Route("[controller]")]
    public class BoardsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BoardsController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        [Produces(typeof(int))]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Create(CreateBoard request)
        {
            var res = await _mediator.Send(request);

            return Ok(res);
        }
    }
}

