using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMonitoringShared.Tests
{
    [TestFixture]
    internal class PositionTests
    {
        [Test]
        public void Position_CopyTo_ExpectsEqual()
        {
            var originalPosition = PositionTestsUtility.CreateDummyPosition();
            var newPosition = new Position();
            originalPosition.CopyTo(newPosition);

            Assert.True(originalPosition.Id == newPosition.Id);
            Assert.True(originalPosition.Ticker == newPosition.Ticker);
            Assert.True(originalPosition.Spot == newPosition.Spot);
            Assert.True(originalPosition.QtyT_1 == newPosition.QtyT_1);
            Assert.True(originalPosition.QtyT_0 == newPosition.QtyT_0);
            Assert.True(originalPosition.QtyChange == newPosition.QtyChange);
            Assert.True(originalPosition.CumulativeQtyChange == newPosition.CumulativeQtyChange);
            Assert.True(originalPosition.TotalCumulativeQtyTraded == newPosition.TotalCumulativeQtyTraded);
            Assert.True(originalPosition.LastUpdated == newPosition.LastUpdated);
        }
    }

    internal class PositionTestsUtility
    {
        public static Position CreateDummyPosition()
        {
            var position = new Position();
            position.Id = 1;
            position.Ticker = "XXX";
            position.Spot = 99;
            position.QtyT_1 = 1000;
            position.QtyT_0 = 1500;
            position.QtyChange = 500;
            position.CumulativeQtyChange = 3000;
            position.TotalCumulativeQtyTraded = 4000;
            position.LastUpdated = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            position.LatestTrade = TradeTestsUtility.CreateDummyTrade();
            return position;
        }
    }
}
