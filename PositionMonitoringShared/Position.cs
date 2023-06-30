using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMonitoringShared
{
    public record class Position : IEquatable<Position>
    {
        public object SyncLock { get; private set; }
        public int Id { get; set; }
        public string Ticker { get; set; }
        public double Spot { get; set; }
        public int QtyT_1 { get; set; }
        public int QtyT_0 { get; set; }
        public int QtyChange { get; set; }
        public int CumulativeQtyChange { get; set; }
        public int TotalCumulativeQtyTraded { get; set; }
        public DateTime LastUpdated { get; set; }
        public Trade LatestTrade { get; set; }

        public Position()
        {
            SyncLock = new object();
        }

        public void CopyTo(Position inputPosition)
        {
            inputPosition.Id = this.Id;
            inputPosition.Ticker = this.Ticker;
            inputPosition.Spot= this.Spot;
            inputPosition.QtyT_1 = this.QtyT_1;
            inputPosition.QtyT_0 = this.QtyT_0;
            inputPosition.QtyChange= this.QtyChange;
            inputPosition.CumulativeQtyChange = this.CumulativeQtyChange;
            inputPosition.TotalCumulativeQtyTraded = this.TotalCumulativeQtyTraded;
            inputPosition.LastUpdated = this.LastUpdated;
            if (inputPosition.LatestTrade == null)
            {
                inputPosition.LatestTrade = new Trade();
            }
            this.LatestTrade.CopyTo(inputPosition.LatestTrade);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public virtual bool Equals(Position? other)
        {
            if (other == null) return false;

            if (this.Id != other.Id) return false;

            return true;
        }
    }
}
