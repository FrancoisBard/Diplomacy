using System;
using System.Linq;
using Diplomacy.Board;

namespace Diplomacy.Orders
{
    class MoveOrder : IOrder
    {
        private UnitType UnitType { get; set; }

        private ILocation Origin { get; set; }

        private ILocation Destination { get; set; }

        public MoveOrder(string unitType, string origin, string destination)
            : this(
                OrderParser.ParseUnitType(unitType),
                Program.Board.Locations.Single(l => l.Abbreviation == origin),
                Program.Board.Locations.Single(l => l.Abbreviation == destination))
        {
        }

        private MoveOrder(UnitType unitType, ILocation origin, ILocation destination)
        {
            UnitType = unitType;
            Origin = origin;
            Destination = destination;
        }

        //shouldn't be here ?
        public Boolean Validate()
        {
            var unit = Origin.Unit;
            return unit != null && UnitType == unit.UnitType && unit.CanMoveTo(Destination);
        }

        public void Execute()
        {
            Origin.Unit.MoveTo(Destination);
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}