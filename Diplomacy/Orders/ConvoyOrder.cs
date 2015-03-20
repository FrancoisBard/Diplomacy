using System;
using System.Linq;
using Diplomacy.Board;

namespace Diplomacy.Orders
{
    class ConvoyOrder : IOrder
    {
        private UnitType UnitType { get; set; }

        private ILocation Location { get; set; }

        private IOrder ConvoyedMove { get; set; }

        public ConvoyOrder(string unitType, string location, IOrder convoyedMove)
            : this(
                OrderParser.ParseUnitType(unitType),
                Program.Board.Locations.Single(l => l.Abbreviation == location),
                convoyedMove)
        {
        }

        private ConvoyOrder(UnitType unitType, ILocation location, IOrder convoyedMove)
        {
            UnitType = unitType;
            Location = location;
            ConvoyedMove = convoyedMove;
        }

        //shouldn't be here ?
        public Boolean Validate()
        {
            var unit = Location.Unit;
            return unit != null && UnitType == unit.UnitType && ConvoyedMove.Validate();

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