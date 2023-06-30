using PositionMonitoringShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMonitoringServer
{
    public enum PositionUpdateEventType
    {
        Add = 0, 
        Update = 1, 
        Delete = 2
    }

    internal class PositionUpdateEventArgs : EventArgs
    {
        public PositionUpdateEventType EventType { get; set; }
        public Position PositionUpdated { get; set; }
    }
}
