using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMonitoringClient.Tests
{
    [TestFixture]
    internal class ServerStateToValueConverterTests
    {
        [Test]
        public void Convert_WhenTrue_ExpectsConnected()
        {
            var serverStateToValueConverter = new ServerStateToValueConverter();
            var result = serverStateToValueConverter.Convert(true, typeof(string), null, null);
            Assert.IsNotNull(result);
            var resultInString = result.ToString();
            Assert.IsNotEmpty(resultInString);
            Assert.True(resultInString == "Connected");
        }

        [Test]
        public void Convert_WhenFalse_ExpectsDisconnected()
        {
            var serverStateToValueConverter = new ServerStateToValueConverter();
            var result = serverStateToValueConverter.Convert(false, typeof(string), null, null);
            Assert.IsNotNull(result);
            var resultInString = result.ToString();
            Assert.IsNotEmpty(resultInString);
            Assert.True(resultInString == "Disconnected");
        }
    }
}
