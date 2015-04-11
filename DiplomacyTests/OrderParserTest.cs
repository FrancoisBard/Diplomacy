using System;
using Xunit;
using Diplomacy.Orders;
using Diplomacy.Board;
using System.Collections.Generic;
using Xunit.Extensions;
using System.Linq;

namespace DiplomacyTests
{
    public class OrderParserTest
    {
        [Theory, MemberData("Orders")]
        public void Parse(Board Board, string orderString, IOrder expectedOrder)
        {
            var orderParser = new OrderParser(Board);

            var actualOrder = orderParser.Parse(orderString);

            CompareOrders(expectedOrder, actualOrder);
        }

        private static void CompareOrders(IOrder expectedOrder, IOrder actualOrder)
        {
            Assert.True(expectedOrder.GetType() == actualOrder.GetType());

            //tests common fields.
            Assert.Equal(expectedOrder.UnitType, actualOrder.UnitType);

            //tests special fields.
            var type = expectedOrder.GetType();
            if (type == typeof(MoveOrder))
            {
                var expectedTypedOrder = (MoveOrder)expectedOrder;
                var actualTypedOrder = (MoveOrder)actualOrder;

                Assert.Equal(expectedTypedOrder.Destination, actualTypedOrder.Destination);
                Assert.Equal(expectedTypedOrder.Origin, actualTypedOrder.Origin);
            }
            else if (type == typeof(HoldOrder))
            {
                var expectedTypedOrder = (HoldOrder)expectedOrder;
                var actualTypedOrder = (HoldOrder)actualOrder;

                Assert.Equal(expectedTypedOrder.Location, actualTypedOrder.Location);
            }
            else if (type == typeof(ConvoyOrder))
            {
                var expectedTypedOrder = (ConvoyOrder)expectedOrder;
                var actualTypedOrder = (ConvoyOrder)actualOrder;

                Assert.Equal(expectedTypedOrder.Location, actualTypedOrder.Location);

                CompareOrders(expectedTypedOrder.ConvoyedMoveOrder, actualTypedOrder.ConvoyedMoveOrder);
            }
            else if (type == typeof(SupportOrder))
            {
                var expectedTypedOrder = (SupportOrder)expectedOrder;
                var actualTypedOrder = (SupportOrder)actualOrder;

                Assert.Equal(expectedTypedOrder.Location, actualTypedOrder.Location);

                CompareOrders(expectedTypedOrder.SupportedMoveOrHoldOrder, actualTypedOrder.SupportedMoveOrHoldOrder);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Some of these test are impossible from a game mechanics pov, but that's beyond the point. We are testing the syntax here.
        /// </remarks>
        public static IEnumerable<object[]> Orders
        {
            get
            {
                //initialize test board
                var Board = new Board();

                var abc = new Province(null, "ABC", null, 0);
                var def = new Province(null, "DEF", null, 0);
                var ghi = new Province(null, "GHI", null, 0);
                var jkl = new Province(null, "JKL", null, 0);
                var abcNc = new CoastLine(null, "ABC NC", null);
                var abcSc = new CoastLine(null, "ABC SC", null);

                Board.Locations = new HashSet<ILocation>() { abc, def, ghi, jkl, abcNc, abcSc };

                var moveOrdersTestData = new[]
                {
                    new object[] { Board, "A ABC-DEF", new MoveOrder(UnitType.Army, abc, def) },
                    new object[] { Board, "F GHI-JKL", new MoveOrder(UnitType.Fleet, ghi, jkl) },
                    new object[] { Board, "F ABC NC-ABC SC", new MoveOrder(UnitType.Fleet, abcNc, abcSc) },
                    new object[] { Board, "F GHI-ABC SC", new MoveOrder(UnitType.Fleet, ghi, abcSc) },
                    new object[] { Board, "F ABC NC-JKL", new MoveOrder(UnitType.Fleet, abcNc, jkl) }
                };

                var holdOrdersTestData = new[]
                {
                    new object[] { Board, "A ABC H", new HoldOrder(UnitType.Army, abc) },
                    new object[] { Board, "F GHI H", new HoldOrder(UnitType.Fleet, ghi) },
                    new object[] { Board, "F ABC NC H", new HoldOrder(UnitType.Fleet, abcNc) },
                };

                var convoyOrdersTestData = new[]
                {
                    new object[] { Board, "F GHI C A ABC-DEF", new ConvoyOrder(UnitType.Fleet, ghi, new MoveOrder(UnitType.Army, abc, def)) }
                };

                var supportOrdersTestData = new[]
                {
                    new object[] { Board, "A GHI S A ABC-DEF", new SupportOrder(UnitType.Army, ghi, new MoveOrder(UnitType.Army, abc, def)) },
                    new object[] { Board, "F GHI S F ABC NC-ABC SC", new SupportOrder(UnitType.Fleet, ghi, new MoveOrder(UnitType.Fleet, abcNc, abcSc)) },
                    new object[] { Board, "F ABC NC S F GHI-ABC SC", new SupportOrder(UnitType.Fleet, abcNc, new MoveOrder(UnitType.Fleet, ghi, abcSc)) },

                    new object[] { Board, "A GHI S A ABC H", new SupportOrder(UnitType.Army, ghi, new HoldOrder(UnitType.Army, abc)) },
                    new object[] { Board, "F ABC NC S F ABC SC H", new SupportOrder(UnitType.Fleet, abcNc, new HoldOrder(UnitType.Fleet, abcSc)) },
                };

                return moveOrdersTestData.Concat(holdOrdersTestData).Concat(convoyOrdersTestData).Concat(supportOrdersTestData);
            }
        }
    }
}
