using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMonitoringShared
{
    public record class Trade : IEquatable<Trade>
    {
        public int TradeId { get; set; }
        public int PartyId { get; set; }
        public int CounterPartyId { get; set; }
        public int TraderId { get; set; }
        public string Ticker { get; set; }
        public string BuySell { get; set; }
        public double SpotPrice { get; set; }
        public int Quantity { get; set; }
        public double NotionalUSD { get; set; }
        public double FXRate { get; set; }
        public string RiskBook { get; set; }
        public string TradeCcy { get; set; }
        public string SettlementCcy { get; set; }
        public DateTime TradeDate { get; set; }
        public DateTime SettlementDate { get; set; }
        public string MarketingDesk { get; set; }
        public DateTime LastUpdated { get; set; }
        public int LastUpdatedById { get; set; }

        public void CopyTo(Trade inputTrade)
        {
            inputTrade.TradeId = this.TradeId;
            inputTrade.PartyId = this.PartyId;
            inputTrade.CounterPartyId = this.CounterPartyId;
            inputTrade.TraderId= this.TraderId;
            inputTrade.Ticker = this.Ticker;
            inputTrade.BuySell = this.BuySell;
            inputTrade.SpotPrice = this.SpotPrice;
            inputTrade.Quantity = this.Quantity;
            inputTrade.NotionalUSD = this.NotionalUSD;
            inputTrade.FXRate = this.FXRate;
            inputTrade.RiskBook = this.RiskBook;
            inputTrade.TradeCcy = this.TradeCcy;
            inputTrade.SettlementCcy = this.SettlementCcy;
            inputTrade.TradeDate = this.TradeDate;
            inputTrade.SettlementDate = this.SettlementDate;
            inputTrade.MarketingDesk = this.MarketingDesk;
            inputTrade.LastUpdated = this.LastUpdated;
            inputTrade.LastUpdatedById = this.LastUpdatedById;
        }

        public override int GetHashCode()
        {
            return TradeId.GetHashCode();
        }

        public virtual bool Equals(Trade? other)
        {
            if (other == null) return false;

            if (this.TradeId != other.TradeId) return false;

            return true;
        }
    }
}
