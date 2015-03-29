using System;
using System.Linq;
using Diplomacy.Board;

namespace Diplomacy.Orders
{
    /// <summary>
    /// Move or Retreat order
    /// </summary>
    public class MoveOrder : IOrder
    {
        public Force Force { get; set; }

        public UnitType UnitType { get; set; }

        public ILocation Origin { get; set; }

        public ILocation Destination { get; set; }

        public MoveOrder(Board.Board board, string unitType, string origin, string destination)
            : this(
                OrderParser.ParseUnitType(unitType),
                board.Locations.Single(l => l.Abbreviation == origin),
                board.Locations.Single(l => l.Abbreviation == destination))
        {
        }

        public MoveOrder(UnitType unitType, ILocation origin, ILocation destination)
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
            return String.Format("{0} {1}-{2}", 
                OrderParser.GetUnitTypeAbbreviation(UnitType), 
                Origin.Abbreviation, 
                Destination.Abbreviation);
        }
    }
}