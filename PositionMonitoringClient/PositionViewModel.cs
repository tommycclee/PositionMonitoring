using PositionMonitoringShared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMonitoringClient
{
    public class PositionViewModel : INotifyPropertyChanged, IEquatable<PositionViewModel>
    {
        public int Id { get; set; }
        public string Ticker { get; set; }
        private double _spot;
        public double Spot { get { return _spot; } set { _spot = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Spot))); } }
        private int _QtyT_1;
        public int QtyT_1 { get { return _QtyT_1; } set { _QtyT_1 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QtyT_1))); } }
        private int _QtyT_0;
        public int QtyT_0 { get { return _QtyT_0; } set { _QtyT_0 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QtyT_0))); } }
        private int _QtyChange;
        public int QtyChange { get { return _QtyChange; } set { _QtyChange = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QtyChange))); } }
        private int _CumulativeQtyChange;
        public int CumulativeQtyChange { get { return _CumulativeQtyChange; } set { _CumulativeQtyChange = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CumulativeQtyChange))); } }
        private int _TotalCumulativeQtyTraded;
        public int TotalCumulativeQtyTraded { get { return _TotalCumulativeQtyTraded; } set { _TotalCumulativeQtyTraded = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TotalCumulativeQtyTraded))); } }
        public DateTime LastUpdated { get; set; }
        private TradeViewModel _LatestTrade;
        public TradeViewModel LatestTrade { get { return _LatestTrade; } set { _LatestTrade = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LatestTrade))); } }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void CopyFrom(Position inputPosition)
        {
            this.Id = inputPosition.Id;
            this.Ticker = inputPosition.Ticker;
            this.Spot = inputPosition.Spot;
            this.QtyT_1 = inputPosition.QtyT_1;
            this.QtyT_0 = inputPosition.QtyT_0;
            this.QtyChange = inputPosition.QtyChange;
            this.CumulativeQtyChange = inputPosition.CumulativeQtyChange;
            this.TotalCumulativeQtyTraded = inputPosition.TotalCumulativeQtyTraded;
            this.LastUpdated = inputPosition.LastUpdated;
            if (this.LatestTrade == null)
            {
                this.LatestTrade = new TradeViewModel();
            }
            this.LatestTrade.CopyFrom(inputPosition.LatestTrade);
        }

        public bool Equals(PositionViewModel? other)
        {
            if (other == null) return false;

            if (this.Id != other.Id) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
