using TommyLee.Example.Grpc.PositionMonitoring;
using PositionMonitoringShared;
using Grpc.Core;
using System.Text.Json;

namespace PositionMonitoringServer
{
    /// <summary>
    /// This class establish a connection with each client.
    /// When positions in the PositionCache is updated, it will send the updated positions to each client
    /// </summary>
    public class PositionMonitoringServiceImpl : PositionMonitoringService.PositionMonitoringServiceBase, IDisposable
    {
        private PositionCache _positionCache;
        private List<PositionMonitoringClientRegistry> _clientRegistry = new List<PositionMonitoringClientRegistry>();

        public PositionMonitoringServiceImpl(PositionCache positionCache)
        {
            _positionCache = positionCache;
            _positionCache.PositionsChanged += _positionCache_PositionChanged;
        }

        private void _positionCache_PositionChanged(object? sender, List<Position> positions)
        {
            try
            {
                foreach (var clientRegistry in _clientRegistry)
                {
                    clientRegistry.AddPositions(positions);
                }
                foreach (var clientRegistry in _clientRegistry)
                {
                    clientRegistry.Signal.Set();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in \"_positionCache_PositionChanged\" : {ex.ToString()}");
            }
        }

        public override async Task Connect(IAsyncStreamReader<PositionMonitoringMessage> requestStream,
            IServerStreamWriter<PositionMonitoringMessageFromServer> responseStream,
            ServerCallContext context)
        {
            // Keep track of connected clients
            var clientRegistry = new PositionMonitoringClientRegistry() { Signal = new AutoResetEvent(false) };
            _clientRegistry.Add(clientRegistry);

            while (true)
            {
                try
                {
                    clientRegistry.Signal.WaitOne();
                    List<Position> positionsFromQueue = clientRegistry.GetPositions();
                    foreach (var position in positionsFromQueue)
                    {
                        string jsonString = JsonSerializer.Serialize(position);

                        var messageFromClient = new PositionMonitoringMessage() { From = "other", Message = jsonString };

                        // Create a server message that wraps the client message
                        var message = new PositionMonitoringMessageFromServer
                        {
                            Message = messageFromClient
                        };

                        try { await responseStream.WriteAsync(message); } catch (Exception ex) { }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error in \"Connect\" : {ex.ToString()}");
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                try
                {
                    if (_positionCache != null)
                    {
                        _positionCache.PositionsChanged -= _positionCache_PositionChanged;
                        _positionCache = null;
                    }
                }
                catch (RpcException ex)
                {
                }
            }
            // free native resources if there are any.
        }
    }
}
