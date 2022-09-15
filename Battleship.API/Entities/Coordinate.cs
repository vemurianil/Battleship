using System;
namespace Battleship.API.Entities
{
    public class Coordinate : IEntity
    {
        public Coordinate()
        {
        }

        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Ship Ship { get; set; }
    }
}

