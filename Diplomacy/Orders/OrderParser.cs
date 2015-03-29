using System;
using System.Text.RegularExpressions;
using Diplomacy.Board;

namespace Diplomacy.Orders
{
    public class OrderParser
    {
        private readonly Board.Board Board;

        public OrderParser(Board.Board board)
        {
            this.Board = board;
        }

        //todo i could have only one regex... ?
        public IOrder Parse(string order)
        {

            var iOrder = TryParseMoveOrHoldOrder(order);
            if (iOrder != null)
            {
                return iOrder;
            }

            iOrder = TryParseConvoyOrSupportOrder(order);
            if (iOrder != null)
            {
                return iOrder;
            }

            throw new Exception(); //todo return hold ?
        }

        private IOrder TryParseMoveOrHoldOrder(string order)
        {
            return TryParseHoldOrder(order) ?? TryParseMoveOrder(order);
        }

        private IOrder TryParseConvoyOrSupportOrder(string order)
        {
            var convoyOrSupportRegex = new Regex(
                @"^(?<unitType>[AF]) (?<location>\w{3}( \w{2})?) (?<orderType>[SC]) (?<supportedOrConvoyedOrder>.*)$",
                RegexOptions.IgnoreCase);

            var match = convoyOrSupportRegex.Match(order);

            if (!match.Success)
            {
                return null;
            }

            var unitType = match.Groups["unitType"].Value.ToUpperInvariant();
            var location = match.Groups["location"].Value.ToUpperInvariant();
            var orderType = match.Groups["orderType"].Value.ToUpperInvariant();
            var supportedOrConvoyedOrder = match.Groups["supportedOrConvoyedOrder"].Value.ToUpperInvariant();

            var supportedOrder = TryParseMoveOrHoldOrder(supportedOrConvoyedOrder);
            if (supportedOrder == null)
            {
                return null;
            }

            switch (orderType)
            {
                case "S":
                    return new SupportOrder(Board, unitType, location, supportedOrder);
                case "C":
                    return new ConvoyOrder(Board, unitType, location, supportedOrder);
                default:
                    throw new NotImplementedException("Unknown order type");
            }
        }

        private IOrder TryParseMoveOrder(string order)
        {
            var moveRegex = new Regex(
                @"^(?<unitType>[AF]) (?<origin>\w{3}( \w{2})?)-(?<destination>\w{3}( \w{2})?)$",
                RegexOptions.IgnoreCase);

            var match = moveRegex.Match(order);

            if (!match.Success)
            {
                return null;
            }

            var unitType = match.Groups["unitType"].Value.ToUpperInvariant();
            var origin = match.Groups["origin"].Value.ToUpperInvariant();
            var destination = match.Groups["destination"].Value.ToUpperInvariant();

            return new MoveOrder(Board, unitType, origin, destination);
        }

        private IOrder TryParseHoldOrder(string order)
        {
            var holdRegex = new Regex(
                @"^(?<unitType>[AF]) (?<location>\w{3}( \w{2})?) (?<hold>H)$",
                RegexOptions.IgnoreCase);

            var match = holdRegex.Match(order);

            if (!match.Success)
            {
                return null;
            }

            var unitType = match.Groups["unitType"].Value.ToUpperInvariant();
            var location = match.Groups["location"].Value.ToUpperInvariant();
            var hold = match.Groups["hold"].Value.ToUpperInvariant();

            if (hold == "H")
            {
                return new HoldOrder(Board, unitType, location);
            }
            else
            {
                return new BuildOrDisbandOrder(Board, unitType, location);
            }
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
                    throw new NotImplementedException("Unknown unit type");
            }
        }

        public static string GetUnitTypeAbbreviation(UnitType unitType)
        {
            switch (unitType)
            {
                case UnitType.Army:
                    return "A";
                case UnitType.Fleet:
                    return "F";
                default:
                    throw new NotImplementedException("Unknown unit type");
            }
        }
    }
}
