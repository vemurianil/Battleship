using System;
using Battleship.API.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Battleship.API.Data
{
    public interface IBattleshipDbContext
    {
        DbSet<Board> Boards { get; set; }
        DbSet<Ship> Ships { get; set; }
        DbSet<Coordinate> Coordinates { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

