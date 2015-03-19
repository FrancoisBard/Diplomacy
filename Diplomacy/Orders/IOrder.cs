using System;

namespace Diplomacy.Orders
{
    interface IOrder
    {
        Boolean Validate();
        void Execute();
    }
}