using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Diplomacy
{
    class Program
    {
        static void Main(string[] args)
        {
            //build test board

            //todo use constuctors
            var nodeA = new BoardNode()
            {
               Name = "A",
               SpaceType = SpaceType.Land
            };

            var nodeB = new BoardNode()
            {
                Name = "B",
                SpaceType = SpaceType.Sea
            };

            var nodeC = new BoardNode()
            {
                Name = "C",
                SpaceType = SpaceType.Sea
            };

            var nodeD = new BoardNode()
            {
                Name = "D",
                SpaceType = SpaceType.Sea
            };

            //nodeA.NeighborLands.Add(nodeB);
            //nodeB.NeighborLands.Add(nodeC);
            //nodeC.NeighborLands.Add(nodeD);
            //nodeD.NeighborLands.Add(nodeA);
        }
    }
}
