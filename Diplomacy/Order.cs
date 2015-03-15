using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Diplomacy
{
    class Order
    {
        private OrderType OrderType { get; set; }

        public static MoveOrder Parse(string order)
        {
            var moveRegex = new Regex(@"(?<unitType>\w) (?<origin>\w*)-(?<destination>\w*)", RegexOptions.IgnoreCase);

            var match = moveRegex.Match(order);

            if (!match.Success)
            {
                throw new ArgumentException("invalid order");
            }

            var unitType = match.Groups["unitType"].Value.ToUpperInvariant();
            var origin = match.Groups["origin"].Value.ToUpperInvariant();
            var destination = match.Groups["destination"].Value.ToUpperInvariant();

            return new MoveOrder(unitType, origin, destination);
        }

        protected static UnitType ParseUnitType(string unitType)
        {
            switch (unitType)
            {
                case "A":
                    return UnitType.Army;
                case "F":
                    return UnitType.Fleet;
                default:
                    throw new Exception("Unknown unit type");
            }
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }

    class MoveOrder : Order
    {
        public UnitType UnitType { get; set; }

        public ILocation Origin { get; set; }

        public ILocation Destination { get; set; }

        public MoveOrder(string unitType, string origin, string destination)
            : this(
            ParseUnitType(unitType),
            Program.Board.Locations.Single(l => l.Abbreviation == origin),
            Program.Board.Locations.Single(l => l.Abbreviation == destination))
        {
        }

        public MoveOrder(UnitType unitType, ILocation origin, ILocation destination)
        {
            UnitType = unitType;
            Origin = origin;
            Destination = destination;
        }

        public Boolean Validate()
        {
            var unit = Origin.Unit;
            return unit != null && UnitType == unit.UnitType && unit.CanMoveTo(Destination);
        }

        public void Move()
        {
            Origin.Unit.MoveTo(Destination);
        }
    }

    enum OrderType
    {
        Hold,
        Attack,
        Support,
        Convoy
    }
}
