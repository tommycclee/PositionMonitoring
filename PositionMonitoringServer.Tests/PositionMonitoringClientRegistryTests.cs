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
    internal class PositionMonitoringClientRegistryTests
    {
        [Test]
        public void AddPositions_WhenAddPosition_ExpectsToGetSuccessfully()
        {
            var positionMonitoringClientRegistry = new PositionMonitoringClientRegistry();
            var inputPosition1 = new Position() { Id = 1000 };
            var inputPosition2 = new Position() { Id = 1001 };
            var inputPositions = new List<Position>() { inputPosition1, inputPosition2 };
            positionMonitoringClientRegistry.AddPositions(inputPositions);
            var outputPositions = positionMonitoringClientRegistry.GetPositions();
            Assert.IsNotNull(outputPositions);
            Assert.True(outputPositions.Count == inputPositions.Count);
            Assert.True(outputPositions.Any(item => item.Equals(inputPosition1)));
            Assert.True(outputPositions.Any(item => item.Equals(inputPosition2)));
        }
    }
}
