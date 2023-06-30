using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMonitoringClient.Tests
{
    [TestFixture]
    internal class ValueToStateConverterTests
    {
        [Test]
        public void Convert_WhenZero_ExpectsZero()
        {
            var valueToStateConverter = new ValueToStateConverter();
            var result = valueToStateConverter.Convert(0, typeof(int), null, null);
            Assert.IsNotNull(result);
            var resultInInt = Convert.ToInt32(result);
            Assert.True(resultInInt == 0);
        }

        [Test]
        public void Convert_WhenGreaterThanZero_ExpectsOne()
        {
            var valueToStateConverter = new ValueToStateConverter();
            var result = valueToStateConverter.Convert(99, typeof(int), null, null);
            Assert.IsNotNull(result);
            var resultInInt = Convert.ToInt32(result);
            Assert.True(resultInInt == 1);
        }

        [Test]
        public void Convert_WhenLessThanZero_ExpectsNegativeOne()
        {
            var valueToStateConverter = new ValueToStateConverter();
            var result = valueToStateConverter.Convert(-99, typeof(int), null, null);
            Assert.IsNotNull(result);
            var resultInInt = Convert.ToInt32(result);
            Assert.True(resultInInt == -1);
        }
    }
}
