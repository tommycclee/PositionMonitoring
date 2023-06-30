using Grpc.Core;
using PositionMonitoringShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMonitoringServer
{
    /// <summary>
    /// This class is the cache of all the positions in the service, and publishes an event when the positions has updated
    /// </summary>
    public class PositionCache
    {
        private Dictionary<int, Position> _positions;
        private ReaderWriterLock _lock = new ReaderWriterLock();
        private int _readerTimeouts = 0;
        private int _writerTimeouts = 0;
        private int _reads = 0;
        private int _writes = 0;
        private const int _timeout = 1000;

        public event EventHandler<List<Position>>? PositionsChanged;

        public PositionCache()
        {
            _positions = new Dictionary<int, Position>();
        }

        public void OnPositionsChanged(List<Position> positions)
        {
            try
            {
                if (PositionsChanged != null) PositionsChanged(this, positions);
            }
            catch (Exception ex)
            {

            }
        }

        public void Add(int positionId, string ticker, int qtyT_1)
        {
            var position = new Position() { Id = positionId, Ticker = ticker, QtyT_1 = qtyT_1 };
            WriteToCache(position);
        }

        public Position Get(int positionId)
        {
            return ReadFromCache(positionId);
        }

        public IEnumerable<int> ReadFromCacheAllPositionId()
        {
            List<int> positionIdList = new List<int>();
            try
            {
                _lock.AcquireReaderLock(_timeout);
                try
                {
                    // It is safe for this thread to read from the shared resource.
                    var keys = _positions.Keys;
                    foreach (var key in keys)
                    {
                        positionIdList.Add(key);
                    }

                    Interlocked.Increment(ref _reads);
                }
                finally
                {
                    // Ensure that the lock is released.
                    _lock.ReleaseReaderLock();
                }
            }
            catch (ApplicationException)
            {
                // The reader lock request timed out.
                Interlocked.Increment(ref _readerTimeouts);
            }
            return positionIdList;
        }

        public Position ReadFromCache(int positionId)
        {
            Position positionInCache = null;
            try
            {
                _lock.AcquireReaderLock(_timeout);
                try
                {
                    // It is safe for this thread to read from the shared resource.
                    _positions.TryGetValue(positionId, out positionInCache);
                    Interlocked.Increment(ref _reads);
                }
                finally
                {
                    // Ensure that the lock is released.
                    _lock.ReleaseReaderLock();
                }
            }
            catch (ApplicationException)
            {
                // The reader lock request timed out.
                Interlocked.Increment(ref _readerTimeouts);
            }
            return positionInCache;
        }

        // Request and release the writer lock, and handle time-outs.
        private void WriteToCache(Position position)
        {
            try
            {
                _lock.AcquireWriterLock(_timeout);
                try
                {
                    Position positionInCache;
                    if (_positions.TryGetValue(position.Id, out positionInCache))
                    {
                        position.CopyTo(positionInCache);
                    }
                    else
                    {
                        _positions.Add(position.Id, position);
                    }

                    // It's safe for this thread to access from the shared resource.
                    Interlocked.Increment(ref _writes);
                }
                finally
                {
                    // Ensure that the lock is released.
                    _lock.ReleaseWriterLock();
                }
            }
            catch (ApplicationException)
            {
                // The writer lock request timed out.
                Interlocked.Increment(ref _writerTimeouts);
            }
        }
    }
}
