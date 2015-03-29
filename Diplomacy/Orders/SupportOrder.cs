using System;
using System.Linq;
using Diplomacy.Board;

namespace Diplomacy.Orders
{
    public class SupportOrder : IOrder
    {
        public Force Force { get; set; }

        public UnitType UnitType { get; set; }

        public ILocation Location { get; set; }

        public IOrder SupportedMoveOrHoldOrder { get; set; }

        public SupportOrder(Board.Board board, string unitType, string location, IOrder supportedMoveOrHoldOrder)
            : this(
                OrderParser.ParseUnitType(unitType),
                board.Locations.Single(l => l.Abbreviation == location),
                supportedMoveOrHoldOrder)
        {
        }

        public SupportOrder(UnitType unitType, ILocation location, IOrder supportedMoveOrHoldOrder)
        {
            UnitType = unitType;
            Location = location;
            SupportedMoveOrHoldOrder = supportedMoveOrHoldOrder;
        }

        //shouldn't be here ?
        public Boolean Validate()
        {
            var unit = Location.Unit;
            return unit != null && UnitType == unit.UnitType && SupportedMoveOrHoldOrder.Validate();

            //todo check we are neighbor
        }

        public void Execute()
        {
            //nothing
        }

        public override string ToString()
        {
            return String.Format("{0} {1} S {2}",
                OrderParser.GetUnitTypeAbbreviation(UnitType),
                Location.Abbreviation,
                SupportedMoveOrHoldOrder.ToString());
        }
    }
}