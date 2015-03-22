using System;

namespace Diplomacy.Orders
{
    public interface IOrder
    {
        Boolean Validate();
        void Execute();
    }
}