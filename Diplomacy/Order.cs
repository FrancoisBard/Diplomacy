using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomacy
{
    class Order
    {
        private OrderType OrderType { get; set; }

        public static void Parse(string order)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }

    enum OrderType
    {
        Hold,
        Attack,
        Support,
        Convoy
    }
}
