using BattleShip.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Models
{
    public class BattleShipGrid
    {
        private int[,] Grid;
        private int GridSize;
        private List<BattleShipModel> BattleShips;
        private List<Coordinate> MissedCordinateList;

        public BattleShipGrid(int gridSize)
        {
            Grid = new int[gridSize, gridSize];
            GridSize = gridSize;
            BattleShips = new List<BattleShipModel>();
            MissedCordinateList = new List<Coordinate>();
        }

        public void SetGridValues(List<Coordinate> cordinates)
        {
            for(int i = 0; i < cordinates.Count; i++)
            {
                BattleShips.Add(new BattleShipModel()
                {
                    Coordinate = new Coordinate()
                    {
                        X = cordinates[i].X,
                        Y = cordinates[i].Y
                    },
                    Status = Enum.Status.Alive
                });
            }
        }

        public void SetHits(List<Coordinate> cordinates)
        {

            for (int i = 0; i < cordinates.Count; i++)
            {
                var isHit = false;
                for (int j = 0; j < BattleShips.Count; j++)
                {
                    if (BattleShips[j].Coordinate.X == cordinates[i].X && BattleShips[j].Coordinate.Y == cordinates[i].Y)
                    {
                        BattleShips[i].Status = Enum.Status.Dead;
                        isHit = true;
                        break;
                    }                
                }
                if (isHit)
                {
                    MissedCordinateList.Add(cordinates[i]);
                }
            }
        }

        public int ShowStatus()
        {
            int noOfHits = 0;
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    var battleShip = BattleShips.Where(b => (b.Coordinate.X == i) && (b.Coordinate.Y == j)).FirstOrDefault();
                    var missedMissile = MissedCordinateList.Where( m => m.X == i && m.Y == j).FirstOrDefault();

                    if (battleShip != null && battleShip.Status == Enum.Status.Dead)
                    {
                        Console.Write("X");
                        noOfHits++;
                    }
                    else if (battleShip != null && battleShip.Status == Enum.Status.Alive)
                    {
                        Console.Write("B");
                    }
                    else if (missedMissile != null)
                    {
                        Console.Write("O");
                    }
                    if (battleShip == null)
                    {
                        Console.Write("_");
                    }

                }
                Console.WriteLine();
            }
            return noOfHits;
        }
    }
}
    