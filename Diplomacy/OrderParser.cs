using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace Diplomacy
{
    class OrderParser
    {
        private OrderType OrderType { get; set; }

        public static IOrder Parse(string order)
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

        public static UnitType ParseUnitType(string unitType)
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
    }

    interface IOrder
    {
        Boolean Validate();
        void Execute();
    }

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


    class OrderSolver
    {
        private IEnumerable<OrderParser> Orders { get; set; }

        public void Solve()
        {

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
