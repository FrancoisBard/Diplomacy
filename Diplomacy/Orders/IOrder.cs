using System;
using Diplomacy.Board;

namespace Diplomacy.Orders
{
    public interface IOrder
    {
        Force Force { get; set; }

        UnitType UnitType { get; }

        Boolean Validate();

        void Execute();
    }
}