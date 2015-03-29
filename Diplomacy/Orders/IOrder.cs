using System;

namespace Diplomacy.Orders
{
    public interface IOrder
    {
        Board.Force Force { get; set; }

        Boolean Validate();

        void Execute();
    }
}