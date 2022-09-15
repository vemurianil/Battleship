using System;
using MediatR;

namespace Battleship.API.Features.Boards
{
    public class CreateBoard : IRequest<int>
    {
        public int GridSize { get; set; }
    }
}

