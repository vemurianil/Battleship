using System;
namespace Battleship.API.Entities
{
    public class Board : IEntity
    {
        public Board()
        {
        }

        public int Id { get; set; }
        public int GridSize { get; set; }
        public IList<Ship> Ships { get; set; }
    }
}

