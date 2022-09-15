using System;
using MediatR;

namespace Battleship.API.Features.Ships
{
    public class CreateShip : IRequest<int>
    {
        public int BoardId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; set; }
        public bool IsHorizantal { get; set; }
    }
}

