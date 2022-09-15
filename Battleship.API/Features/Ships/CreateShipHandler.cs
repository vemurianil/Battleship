using System;
using Battleship.API.Data;
using Battleship.API.Entities;
using MediatR;
using static System.Net.Mime.MediaTypeNames;

namespace Battleship.API.Features.Ships
{
    public class CreateShipHandler : IRequestHandler<CreateShip, int>
    {
        private readonly IBattleshipDbContext _db;

        public CreateShipHandler(IBattleshipDbContext db) => _db = db;

        public async Task<int> Handle(CreateShip request, CancellationToken cancellationToken)
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
            if ((request.IsHorizantal && request.X + request.Size > board.GridSize) ||
                (!request.IsHorizantal && request.Y + request.Size > board.GridSize))
            {
                throw new Exception("Ship does not fit on board");
            }
            var coordinates = new HashSet<string>();
            if (request.IsHorizantal)
            {
                for (var i = request.X; i < request.X + request.Size; i++)
                {
                    coordinates.Add($"{i}{request.Y}");
                }
            }
            else
            {
                for (var i = request.Y; i < request.Y + request.Size; i++)
                {
                    coordinates.Add($"{request.X}{i}");
                }
            }
            var overlaps = _db.Coordinates.Where(c => c.Ship.Board == board)
                .Select(c => $"{c.X}{c.Y}")
                .Where(s => coordinates.Contains(s))
                .Any();

            if (overlaps)
            {
                throw new Exception("Ship overlap");
            }

            var ship = new Ship
            {
                Board = board,
            };
            _db.Ships.Add(ship);

            var xCoordinate = request.X;
            var yCoordinate = request.Y;
            if (request.IsHorizantal)
            {
                _db.Coordinates
                    .AddRange(coordinates.Select(c => new Coordinate
                    {
                        Ship = ship,
                        X = xCoordinate++,
                        Y = yCoordinate
                    }));
            }
            else
            {
                _db.Coordinates
                    .AddRange(coordinates.Select(c => new Coordinate
                    {
                        Ship = ship,
                        X = xCoordinate,
                        Y = yCoordinate++
                    }));
            }

            await _db.SaveChangesAsync(cancellationToken);
            return ship.Id;
        }
    }
}

