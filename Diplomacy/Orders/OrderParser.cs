using System;
using System.Text.RegularExpressions;
using Diplomacy.Board;

namespace Diplomacy.Orders
{
    static class OrderParser
    {
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
}
