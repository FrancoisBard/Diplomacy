using System;
using System.Linq;
using Diplomacy.Board;

namespace Diplomacy.Orders
{
    /// <summary>
    /// Supply order (Build or Disband) 
    /// </summary>
    public class SupplyOrder : IOrder
    {
        public Force Force { get; set; }

        public UnitType UnitType { get; private set; }

        public ILocation Location { get; private set; }

        public SupplyOrder(Board.Board board, string unitType, string location)
            : this(
                OrderParser.ParseUnitType(unitType),
                board.Locations.Single(l => l.Abbreviation == location))
        {
        }

        public SupplyOrder(UnitType unitType, ILocation location)
        {
            UnitType = unitType;
            Location = location;
        }

        public void Execute()
        {
            //do nothing
        }

        public bool Validate()
        {
            //do nothing
            return false;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}",
                OrderParser.GetUnitTypeAbbreviation(UnitType),
                Location.Abbreviation);
        }
    }
}