using NUnit.Framework;
using PositionMonitoringShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMonitoringServer.Tests
{
    [TestFixture]
    internal class PositionCacheTests
    {
        [Test]
        public void OnPositionsChanged_WhenTriggered_FiresEvent()
        {
            var testPositions = new List<Position>();
            var dummyPosition = new Position() { Id = 1 };
            testPositions.Add(dummyPosition);

            var positionCache = new PositionCache();
            var eventTriggered = false;
            positionCache.PositionsChanged += (o, e) => eventTriggered = true;
            positionCache.OnPositionsChanged(testPositions);

            Assert.That(eventTriggered, Is.True);
        }

        [Test]
        public void Add_WhenAddPosition_ExpectsCanGetFromCache()
        {
            var testPositionId = 999;
            var testTicker = "XXX";
            var testQtyT_1 = 1000;
            var positionCache = new PositionCache();
            positionCache.Add(testPositionId, testTicker, testQtyT_1);
            var positionInCache = positionCache.Get(testPositionId);
            Assert.IsNotNull(positionInCache);
            Assert.True(positionInCache.Id == testPositionId);
            Assert.True(positionInCache.Ticker == testTicker);
            Assert.True(positionInCache.QtyT_1 == testQtyT_1);
        }

        [Test]
        public void ReadFromCacheAllPositionId_WhenAddPosition_ExpectsReturnAllPositionId()
        {
            var testPosition1 = new Position() { Id = 1001 };
            var testPosition2 = new Position() { Id = 1002 };
            var testTicker = "XXX";
            var testQtyT_1 = 1000;
            var positionCache = new PositionCache();
            positionCache.Add(testPosition1.Id, testTicker, testQtyT_1);
            positionCache.Add(testPosition2.Id, testTicker, testQtyT_1);
            var positionIdList = positionCache.ReadFromCacheAllPositionId();
            Assert.True(positionIdList.Count() == 2);
            Assert.True(positionIdList.Any(item => item == testPosition1.Id));
            Assert.True(positionIdList.Any(item => item == testPosition2.Id));
        }

        [Test]
        public void ReadFromCache_WhenAddPosition_ExpectsReturnPosition()
        {
            var testPosition = new Position() { Id = 1001, Ticker = "XXX", QtyT_1 = 1000 };
            var positionCache = new PositionCache();
            positionCache.Add(testPosition.Id, testPosition.Ticker, testPosition.QtyT_1);
            var readPosition = positionCache.ReadFromCache(testPosition.Id);
            Assert.NotNull(readPosition);
            Assert.True(readPosition.Equals(testPosition));
        }
    }
}
