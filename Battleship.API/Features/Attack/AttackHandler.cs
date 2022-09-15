using System;
using Battleship.API.Data;
using MediatR;

namespace Battleship.API.Features.Attack
{
    public class AttackHandler : IRequestHandler<Attack, bool>
    {
        private readonly IBattleshipDbContext _db;

        public AttackHandler(IBattleshipDbContext db) => _db = db;

        public async Task<bool> Handle(Attack request, CancellationToken cancellationToken)
        {
            var board = await _db.Boards.FindAsync(request.BoardId);
            if (board == null)
            {
                throw new Exception("Board does not exist");
            }
            if (request.X > board.GridSize || request.Y > board.GridSize)
            {
                throw new Exception("Not valid coordinates");
            }
            return _db.Coordinates
                .Where(c => c.Ship.Board == board && request.X == c.X && request.Y == c.Y)
                .Any();
        }
    }
}

