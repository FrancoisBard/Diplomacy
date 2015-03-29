using System;
using System.Linq;
using Diplomacy.Board;

namespace Diplomacy.Orders
{
    public class ConvoyOrder : IOrder
    {
        public Force Force { get; set; }

        public UnitType UnitType { get; set; }

        public ILocation Location { get; set; }

        public IOrder ConvoyedMoveOrder { get; set; }

        public ConvoyOrder(Board.Board board, string unitType, string location, IOrder convoyedMoveOrder)
            : this(
                OrderParser.ParseUnitType(unitType),
                board.Locations.Single(l => l.Abbreviation == location),
                convoyedMoveOrder)
        {
        }

        public ConvoyOrder(UnitType unitType, ILocation location, IOrder convoyedMoveOrder)
        {
            UnitType = unitType;
            Location = location;
            ConvoyedMoveOrder = convoyedMoveOrder;
        }

        //shouldn't be here ?
        public Boolean Validate()
        {
            var unit = Location.Unit;
            return unit != null && UnitType == unit.UnitType && ConvoyedMoveOrder.Validate();

            //todo check we are neighbor
        }

        public void Execute()
        {
            //nothing
        }

        public override string ToString()
        {
            return String.Format("{0} {1} C {2}",
                OrderParser.GetUnitTypeAbbreviation(UnitType),
                Location.Abbreviation,
                ConvoyedMoveOrder.ToString());
        }
    }
}