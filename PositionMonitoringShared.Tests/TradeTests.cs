using NuGet.Frameworks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMonitoringShared.Tests
{
    [TestFixture]
    internal class TradeTests
    {
        [Test]
        public void Trade_CopyTo_ExpectEqual()
        {
            var originalTrade = TradeTestsUtility.CreateDummyTrade();

            var newTrade = new Trade();
            originalTrade.CopyTo(newTrade);

            Assert.True(originalTrade.TradeId == newTrade.TradeId);
            Assert.True(originalTrade.PartyId == newTrade.PartyId);
            Assert.True(originalTrade.CounterPartyId == newTrade.CounterPartyId);
            Assert.True(originalTrade.TraderId == newTrade.TraderId);
            Assert.True(originalTrade.Ticker == newTrade.Ticker);
            Assert.True(originalTrade.BuySell == newTrade.BuySell);
            Assert.True(originalTrade.SpotPrice == newTrade.SpotPrice);
            Assert.True(originalTrade.Quantity == newTrade.Quantity);
            Assert.True(originalTrade.NotionalUSD == newTrade.NotionalUSD);
            Assert.True(originalTrade.FXRate == newTrade.FXRate);
            Assert.True(originalTrade.RiskBook == newTrade.RiskBook);
            Assert.True(originalTrade.TradeCcy == newTrade.TradeCcy);
            Assert.True(originalTrade.SettlementCcy == newTrade.SettlementCcy);
            Assert.True(originalTrade.TradeDate == newTrade.TradeDate);
            Assert.True(originalTrade.SettlementDate == newTrade.SettlementDate);
            Assert.True(originalTrade.MarketingDesk == newTrade.MarketingDesk);
            Assert.True(originalTrade.LastUpdated == newTrade.LastUpdated);
            Assert.True(originalTrade.LastUpdatedById == newTrade.LastUpdatedById);
        }
    }

    internal class TradeTestsUtility
    {
        public static Trade CreateDummyTrade()
        {
            var trade = new Trade();
            trade.TradeId = 1;
            trade.PartyId = 2;
            trade.CounterPartyId = 3;
            trade.TraderId = 4;
            trade.Ticker = "XXX";
            trade.BuySell = "Buy";
            trade.SpotPrice = 99;
            trade.Quantity = 1000;
            trade.NotionalUSD = 1000000;
            trade.FXRate = 7.78;
            trade.RiskBook = "TEST RISKBOOK";
            trade.TradeCcy = "YYY";
            trade.SettlementCcy = "ZZZ";
            trade.TradeDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            trade.SettlementDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day).AddDays(2);
            trade.MarketingDesk = "TEST MARKETING DESKS";
            trade.LastUpdated = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day); ;
            trade.LastUpdatedById = 5;
            return trade;
        }
    }
}
