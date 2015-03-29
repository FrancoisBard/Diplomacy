using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomacy.Orders
{
    class SupplyJudge
    {
        public void Judge(Board.Board board, IDictionary<SupplyOrder, bool> orders)
        {
            foreach (var order in orders.Keys)
            {
                //determine if it's a disband or build order

                if (order.Location.Unit != null)
                {
                    orders[order] = false;
                    continue;
                }

                //if (order.Location.SpaceType == Board.SpaceType.
            }
        }
    }
}
