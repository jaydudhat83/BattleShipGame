using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Models
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool IsHit(Coordinate c)
        {
            if (this.X == c.X && this.Y == c.Y)
                return false;
            return true;
        }
    }
}
