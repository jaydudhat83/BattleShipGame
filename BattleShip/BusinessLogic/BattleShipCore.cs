using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.Models;

namespace BattleShip.BusinessLogic
{
    public class BattleShipCore
    {
        public List<BattleShipModel> P1BattleShips;

        public List<BattleShipModel> P2BattleShips;

        public int GridSize;

        public void CreateBattleShipGrid(int gridSize)
        {
            GridSize = gridSize;
        }

        public void SetBattleShips()
        {
            P1BattleShips = new List<BattleShipModel>();
        }
    }
}
