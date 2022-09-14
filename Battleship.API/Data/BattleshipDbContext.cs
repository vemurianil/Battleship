using System;
using Battleship.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Battleship.API.Data
{
    public class BattleshipDbContext : DbContext, IBattleshipDbContext
    {
        public BattleshipDbContext(DbContextOptions<BattleshipDbContext> options)
            : base(options)
        {
        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<Coordinate> Coordinates { get; set; }
    }
}

