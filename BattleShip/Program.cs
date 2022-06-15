using BattleShip.Constants;
using BattleShip.Models;
using BattleShip.Parser;

class BattleShipMain
{
    static public void Main(string[] args)
    {
        var inputParser = new InputParser();
        Console.WriteLine("Please Enter Size of the grid");
        var gridSize = inputParser.ParseNumber(Console.ReadLine());

        Console.WriteLine("Please Enter Total Ships");
        var totalShips = inputParser.ParseNumber(Console.ReadLine());
        Console.WriteLine("Please Enter P1 Ship Positions");
        var p1ShipLocations = inputParser.ParseCordinates(Console.ReadLine(), totalShips);
        Console.WriteLine("Please Enter P2 Ship Positions");
        var p2ShipLocations = inputParser.ParseCordinates(Console.ReadLine(), totalShips);

        Console.WriteLine("Please Enter Total Missiles");
        var totalMissiles = inputParser.ParseNumber(Console.ReadLine());
        Console.WriteLine("Please Enter P1 Missiles Positions");
        var p1MissilesPositions = inputParser.ParseCordinates(Console.ReadLine(), totalMissiles);
        Console.WriteLine("Please Enter P2 Missiles Positions");
        var p2MissilesPositions = inputParser.ParseCordinates(Console.ReadLine(), totalMissiles);

        BattleShipGrid player1 = new BattleShipGrid(totalShips);
        BattleShipGrid player2 = new BattleShipGrid(totalShips);
        player1.SetGridValues(p1ShipLocations);
        player1.SetHits(p2MissilesPositions);

        player2.SetGridValues(p2ShipLocations);
        player2.SetHits(p1MissilesPositions);

        Console.WriteLine("Player1");
        var p1Hits = player1.ShowStatus();
        Console.WriteLine("Player2");
        var p2Hits = player2.ShowStatus();
        Console.WriteLine("P1:" + p1Hits);
        Console.WriteLine("P2:" + p2Hits);
        if (p1Hits < p2Hits)
        {
            Console.WriteLine(Messages.Player1Wins);
        }
        else if(p1Hits > p2Hits)
        {
            Console.WriteLine(Messages.Player2Wins);
        }
        else
        {
            Console.WriteLine(Messages.Draw);
        }

        Console.ReadKey();
    }
}