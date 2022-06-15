using BattleShip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Parser
{
    public class InputParser
    {
        public int ParseNumber(string input)
        {
            try
            {
                if(input == null)
                {
                    throw new ArgumentNullException("Input is Null");
                }
                return int.Parse(input);
            }
            catch
            {
                throw new InvalidDataException("Input is not a valid Number!!");
            }
        }

        public List<Coordinate> ParseCordinates(string input, int length)
        {
            try
            {
                if (input == null)
                {
                    throw new ArgumentNullException("Input is Null");
                }
                var cordinatesList = input.Split(":");
                if(cordinatesList.Length != length)
                {
                    throw new ArgumentNullException("Input doesn't match length");
                }
                var cordinatesArray = new List<Coordinate> { };
                for(var i=0; i< cordinatesList.Length; i++)
                {
                    var cordinateString = cordinatesList[i];
                    var cordinates = cordinateString.Split(',');
                    cordinatesArray.Add(new Coordinate()
                    {
                        X = Convert.ToInt32(cordinates[0]),
                        Y = Convert.ToInt32(cordinates[1])
                    });
                };
                return cordinatesArray;
            }
            catch
            {
                throw new InvalidDataException("Input is not a valid!!");
            }
        }
    }
}
