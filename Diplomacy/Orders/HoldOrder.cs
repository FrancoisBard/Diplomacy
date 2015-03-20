using System;
using System.Linq;
using Diplomacy.Board;

namespace Diplomacy.Orders
{
    class HoldOrder : IOrder
    {
        private UnitType UnitType { get; set; }

        private ILocation Location { get; set; }

        public HoldOrder(string unitType, string location)
            : this(
                OrderParser.ParseUnitType(unitType),
                Program.Board.Locations.Single(l => l.Abbreviation == location))
        {
        }

        private HoldOrder(UnitType unitType, ILocation location)
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
            throw new NotImplementedException();
        }
    }
}