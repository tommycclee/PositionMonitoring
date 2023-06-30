using PositionMonitoringShared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMonitoringClient
{
    public class TradeViewModel : INotifyPropertyChanged, IEquatable<TradeViewModel>
    {
        private int _tradeId;
        public int TradeId { get { return _tradeId; } set { _tradeId = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TradeId))); } }
        private int _partyId;
        public int PartyId { get { return _partyId; } set { _partyId = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PartyId))); } }
        private int _CounterPartyId;
        public int CounterPartyId { get { return _CounterPartyId; } set { _CounterPartyId = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CounterPartyId))); } }
        private int _TraderId;
        public int TraderId { get { return _TraderId; } set { _TraderId = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TraderId))); } }
        private string _Ticker;
        public string Ticker { get { return _Ticker; } set { _Ticker = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Ticker))); } }
        private string _BuySell;
        public string BuySell { get { return _BuySell; } set { _BuySell = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BuySell))); } }
        private double _SpotPrice;
        public double SpotPrice { get { return _SpotPrice; } set { _SpotPrice = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SpotPrice))); } }
        private int _Quantity;
        public int Quantity { get { return _Quantity; } set { _Quantity = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Quantity))); } }
        private double _NotionalUSD;
        public double NotionalUSD { get { return _NotionalUSD; } set { _NotionalUSD = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NotionalUSD))); } }
        private double _FXRate;
        public double FXRate { get { return _FXRate; } set { _FXRate = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FXRate))); } }
        private string _RiskBook;
        public string RiskBook { get { return _RiskBook; } set { _RiskBook = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RiskBook))); } }
        private string _TradeCcy;
        public string TradeCcy { get { return _TradeCcy; } set { _TradeCcy = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TradeCcy))); } }
        private string _SettlementCcy;
        public string SettlementCcy { get { return _SettlementCcy; } set { _SettlementCcy = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SettlementCcy))); } }
        private DateTime _TradeDate;
        public DateTime TradeDate { get { return _TradeDate; } set { _TradeDate = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TradeDate))); } }
        private DateTime _SettlementDate;
        public DateTime SettlementDate { get { return _SettlementDate; } set { _SettlementDate = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SettlementDate))); } }
        private string _MarketingDesk;
        public string MarketingDesk { get { return _MarketingDesk; } set { _MarketingDesk = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MarketingDesk))); } }
        private DateTime _LastUpdated;
        public DateTime LastUpdated { get { return _LastUpdated; } set { _LastUpdated = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastUpdated))); } }
        private int _LastUpdatedById;
        public int LastUpdatedById { get { return _LastUpdatedById; } set { _LastUpdatedById = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastUpdatedById))); } }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void CopyFrom(Trade inputTrade)
        {
            this.TradeId = inputTrade.TradeId;
            this.PartyId = inputTrade.PartyId;
            this.CounterPartyId = inputTrade.CounterPartyId;
            this.TraderId = inputTrade.TraderId;
            this.Ticker = inputTrade.Ticker;
            this.BuySell = inputTrade.BuySell;
            this.SpotPrice = inputTrade.SpotPrice;
            this.Quantity = inputTrade.Quantity;
            this.NotionalUSD = inputTrade.NotionalUSD;
            this.FXRate = inputTrade.FXRate;
            this.RiskBook = inputTrade.RiskBook;
            this.TradeCcy = inputTrade.TradeCcy;
            this.SettlementCcy = inputTrade.SettlementCcy;
            this.TradeDate = inputTrade.TradeDate;
            this.SettlementDate = inputTrade.SettlementDate;
            this.MarketingDesk = inputTrade.MarketingDesk;
            this.LastUpdated = inputTrade.LastUpdated;
            this.LastUpdatedById = inputTrade.LastUpdatedById;
        }

        public bool Equals(TradeViewModel? other)
        {
            if (other == null) return false;

            if (this.TradeId != other.TradeId) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return TradeId.GetHashCode();
        }
    }
}
