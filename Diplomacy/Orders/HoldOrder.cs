using System;
using System.Linq;
using Diplomacy.Board;

namespace Diplomacy.Orders
{
    public class HoldOrder : IOrder
    {
        public Force Force { get; set; }

        public UnitType UnitType { get; set; }

        public ILocation Location { get; set; }

        public HoldOrder(Board.Board board, string unitType, string location)
            : this(
                OrderParser.ParseUnitType(unitType),
                board.Locations.Single(l => l.Abbreviation == location))
        {
        }

        public HoldOrder(UnitType unitType, ILocation location)
        {
            UnitType = unitType;
            Location = location;
        }

        //shouldn't be here ?
        public Boolean Validate()
        {
            var unit = Location.Unit;
            return unit != null && UnitType == unit.UnitType;
        }

        public void Execute()
        {
            //do nothing
        }

        public override string ToString()
        {
            return String.Format("{0} {1} H",
                OrderParser.GetUnitTypeAbbreviation(UnitType),
                Location.Abbreviation);
        }
    }
}