using System;
using MediatR;

namespace Battleship.API.Features.Attack
{
    public class Attack : IRequest<bool>
    {
        public Attack()
        {
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int BoardId { get; set; }
    }
}

