using System;
using System.Linq;
using Diplomacy.Board;

namespace Diplomacy.Orders
{
    public class BuildOrDisbandOrder : IOrder
    {
        private UnitType UnitType { get; set; }

        private ILocation Location { get; set; }

        public BuildOrDisbandOrder(Board.Board board, string unitType, string location)
            : this(
                OrderParser.ParseUnitType(unitType),
                board.Locations.Single(l => l.Abbreviation == location))
        {
        }

        public BuildOrDisbandOrder(UnitType unitType, ILocation location)
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
            return String.Format("{0} {1}",
                OrderParser.GetUnitTypeAbbreviation(UnitType),
                Location.Abbreviation);
        }
    }
}