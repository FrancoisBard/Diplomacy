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

        public SupplyJudge(Board.Board board)
        {
            Board = board;
        }

        public IDictionary<Force, int> DetermineAdjustments()
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
            var adjustments = DetermineAdjustments();
            var executedOrders = new List<SupplyOrder>();

            foreach (var order in orders)
            {
                var adjustmentsCount = adjustments[order.Force];

                if (adjustmentsCount == 0)
                {
                    //no more orders allowed
                    continue;
                }

                //determine if it's a disband or build order
                var disband = adjustmentsCount < 0;

                //if we disband, we need a unit. If we build, we need the location to be empty.
                if (disband ^ order.Location.Unit == null)
                {
                    continue;
                }

                //check that the location is a supply centre and it's owned by the right Force
                var province = (Province)order.Location; //todo could throw
                if (province.SupplyCentre == null || province.SupplyCentre.Owner != order.Force)
                {
                    continue;
                }

                //check unit type
                if (order.Location.SpaceType == SpaceType.Land && order.UnitType == UnitType.Fleet)
                {
                    continue;
                }

                //todo more ?

                executedOrders.Add(order);
                order.Execute();
            }

            return executedOrders;
        }
    }
}
