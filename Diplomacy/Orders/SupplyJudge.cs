using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplomacy.Board;

namespace Diplomacy.Orders
{
    class SupplyJudge
    {
        private Board.Board Board;
        public IDictionary<Force, int> AdditionalUnitsNeededForEachForce; //todo make it immutable ?

        public SupplyJudge(Board.Board board)
        {
            Board = board;
            AdditionalUnitsNeededForEachForce = DetermineAdditionalUnitsNeededForEachForce();
        }

        private IDictionary<Force, int> DetermineAdditionalUnitsNeededForEachForce()
        {
            var ownedUnits = Board.Units.
                GroupBy(u => u.Owner);

            var ownedCenters = Board.SupplyCentres.
                Where(sc => sc.Owner.HasValue).
                GroupBy(sc => sc.Owner.Value);

            return ownedCenters.Join(
                ownedUnits,
                g => g.Key,
                g => g.Key,
                (g1, g2) => new KeyValuePair<Force, int>(g1.Key, g1.Count() - g2.Count())).
                ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        public IEnumerable<SupplyOrder> Judge(IEnumerable<SupplyOrder> orders)
        {
            //note that we don't validate the number of orders received.

            var executedOrders = new List<SupplyOrder>();

            foreach (var order in orders)
            {
                if (Judge(order))
                {
                    executedOrders.Add(order);
                    order.Execute();
                }
            }

            return executedOrders;
        }

        private bool Judge(SupplyOrder order)
        {
            var AdditionalUnitsNeeded = AdditionalUnitsNeededForEachForce[order.Force];

            //no orders to give
            if (AdditionalUnitsNeeded == 0)
            {
                return false;
            }

            //determine if it's a disband or build order
            var disband = AdditionalUnitsNeeded < 0;

            //if we disband, we need a unit. If we build, we need the location to be empty.
            if (disband ^ order.Location.Unit == null)
            {
                return false;
            }

            //check that the location is a supply centre and it's owned by the right Force
            var province = (Province)order.Location; //todo could throw
            if (province.SupplyCentre == null || province.SupplyCentre.Owner != order.Force)
            {
                return false;
            }

            //check unit type
            if (order.Location.SpaceType == SpaceType.Land && order.UnitType == UnitType.Fleet)
            {
                return false;
            }

            //todo more ????
            return true;
        }
    }
}
