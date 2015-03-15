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

        public static Order Parse(string order)
        {
            var moveRegex = new Regex(@"(?<unitType>\w) (?<origin>\w*)-(?<destination>\w*)", RegexOptions.IgnoreCase);

            var match = moveRegex.Match(order);

            if (!match.Success)
            {
                throw new ArgumentException();
            }

            var unitType = match.Groups["unitType"].Value.ToUpperInvariant();
            var origin = match.Groups["origin"].Value.ToUpperInvariant();
            var destination = match.Groups["destination"].Value.ToUpperInvariant();

            var originLocation = Program.Board.Locations.Single(l => l.Abbreviation == origin);
            var destinationLocation = Program.Board.Locations.Single(l => l.Abbreviation == destination);

            UnitType unitTypeEnum;
            switch (unitType)
            {
                case "A":
                    unitTypeEnum = UnitType.Army;
                    break;
                case "F":
                    unitTypeEnum = UnitType.Fleet;
                    break;
                default:
                    throw new Exception();
            }

            return new MoveOrder(unitTypeEnum, originLocation, destinationLocation);
        }

        class MoveOrder : Order
        {
            public UnitType UnitType { get; set; }

            public ILocation Origin { get; set; }

            public ILocation Destination { get; set; }

            public MoveOrder(UnitType unitType, ILocation origin, ILocation destination)
            {
                UnitType = unitType;
                Origin = origin;
                Destination = destination;
            }

            public Boolean Validate() // todo move it back up in Order.Parse ?
            {
                return UnitType == Origin.Unit.UnitType && Origin.Unit.CanMoveTo(Destination); //todo should call canmoveto
            }

            public void Move()
            {
                Origin.Unit.MoveTo(Destination);
            }
        }

        public override string ToString()
        {
            throw new NotImplementedException();
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
