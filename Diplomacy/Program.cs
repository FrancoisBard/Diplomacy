using System;
using System.Collections.Generic;
using Diplomacy.Board;
using Diplomacy.Orders;

namespace Diplomacy
{
    /// <summary>
    /// https://www.wizards.com/avalonhill/rules/diplomacy.pdf
    /// </summary>
    class Program
    {
        public static Board.Board Board;

        static void Main(string[] args)
        {
            Board = EuropeanBoardFactory.CreateEuropeBoard();

            while (true)
            {
                try
                {
                    ListUnitLocations(Board);

                    Console.WriteLine();

                    var orderString = Console.ReadLine();

                    var orderParser = new OrderParser(Board);
                    var order = orderParser.Parse(orderString);
                    if (!order.Validate())
                    {
                        Console.WriteLine("invalid move");
                        continue;
                    }

                    order.Execute();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine();
                }
            }
        }

        static void ListUnitLocations(Board.Board board)
        {
            foreach (var unit in board.Units)
            {
                Console.WriteLine("{0} in {1}", unit.UnitType, unit.Location.Name);
            }
        }
    }
}
