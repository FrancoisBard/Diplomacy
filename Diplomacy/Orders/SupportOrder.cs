using System;
using System.Linq;
using Diplomacy.Board;

namespace Diplomacy.Orders
{
    class SupportOrder : IOrder
    {
        private UnitType UnitType { get; set; }

        private ILocation Location { get; set; }

        private MoveOrder SupportedMove { get; set; }

        public SupportOrder(string unitType, string location, string supportedMoveUnitType, string supportedMoveOrigin, string supportedMoveDestination)
            : this(
                OrderParser.ParseUnitType(unitType),
                Program.Board.Locations.Single(l => l.Abbreviation == location),
                new MoveOrder(supportedMoveUnitType, supportedMoveOrigin, supportedMoveDestination))
        {
        }

        private SupportOrder(UnitType unitType, ILocation location, MoveOrder supportedMove)
        {
            UnitType = unitType;
            Location = location;
            SupportedMove = supportedMove;
        }

        //shouldn't be here ?
        public Boolean Validate()
        {
            var unit = Location.Unit;
            return unit != null && UnitType == unit.UnitType && SupportedMove.Validate();

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