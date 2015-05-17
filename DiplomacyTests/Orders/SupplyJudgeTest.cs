using Xunit;
using Diplomacy.Orders;
using Diplomacy.Board;
using System.Collections.Generic;

namespace DiplomacyTests.Orders
{
    class SupplyJudgeTest
    {
        [Fact]
        public void rata()
        {
            Diplomacy.Board.Board board = new Board();
            ILocation locationA = new Province("A", "A", "A", SpaceType.Land);
            ILocation locationB = new Province("B", "B", "B", SpaceType.Land); //todo allow parameterless constructor ?
            board.Locations.Add(locationA);
            board.Locations.Add(locationB);

            var unit = new Unit(UnitType.Army, Force.France, locationA);
            
            var orders = new List<SupplyOrder>()
            {
                new SupplyOrder(UnitType.Army, locationA),
                new SupplyOrder(UnitType.Army, locationB),
            };

            var supplyJudge = new SupplyJudge(board);
            var executedOrders = supplyJudge.Judge(orders);

            //Assert.Contains()

        }
    }
}
