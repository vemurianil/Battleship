using System;
namespace Battleship.API.Entities
{
    public class Ship : IEntity
    {
        public Ship()
        {
        }

        public int Id { get; set; }
        public Board Board { get; set; }
        public ICollection<Coordinate> Coordinates { get; set; }
    }
}

