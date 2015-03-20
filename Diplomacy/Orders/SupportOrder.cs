using System;
using System.Linq;
using Diplomacy.Board;

namespace Diplomacy.Orders
{
    class SupportOrder : IOrder
    {
        private UnitType UnitType { get; set; }

        private ILocation Location { get; set; }

        private IOrder SupportedMoveOrHold { get; set; }

        public SupportOrder(string unitType, string location, IOrder supportedMoveOrHold)
            : this(
                OrderParser.ParseUnitType(unitType),
                Program.Board.Locations.Single(l => l.Abbreviation == location),
                supportedMoveOrHold)
        {
        }

        private SupportOrder(UnitType unitType, ILocation location, IOrder supportedMoveOrHold)
        {
            UnitType = unitType;
            Location = location;
            SupportedMoveOrHold = supportedMoveOrHold;
        }

        //shouldn't be here ?
        public Boolean Validate()
        {
            var unit = Location.Unit;
            return unit != null && UnitType == unit.UnitType && SupportedMoveOrHold.Validate();

            //todo check we are neighbor
        }

        public void Execute()
        {
            //nothing
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}