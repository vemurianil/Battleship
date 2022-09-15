using System;
using Battleship.API.Data;
using Battleship.API.Entities;
using MediatR;
using static System.Net.Mime.MediaTypeNames;

namespace Battleship.API.Features.Boards
{
    public class CreateBoardHanlder : IRequestHandler<CreateBoard, int>
    {
        private readonly IBattleshipDbContext _db;

        public CreateBoardHanlder(IBattleshipDbContext db) => _db = db;

        public async Task<int> Handle(CreateBoard request, CancellationToken cancellationToken)
        {
            var entity = new Board
            {
                GridSize = request.GridSize
            };
            _db.Boards.Add(entity);
            await _db.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}

