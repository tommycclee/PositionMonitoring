using PositionMonitoringShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMonitoringServer
{
    internal class PositionMonitoringClientRegistry
    {
        private object _positionLock = new object();
        public AutoResetEvent Signal { get; set; }
        private List<Position> Positions { get; set; }

        public PositionMonitoringClientRegistry()
        {
            Positions = new List<Position>();
        }

        public void AddPositions(List<Position> positions)
        {
            lock (_positionLock)
            {
                Positions.AddRange(positions);
            }
        }

        public List<Position> GetPositions()
        {
            var positions = new List<Position>();
            lock (_positionLock)
            {
                positions.AddRange(Positions);
                Positions.Clear();
            }
            return positions;
        }
    }
}
