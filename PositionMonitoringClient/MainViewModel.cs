using TommyLee.Example.Grpc.PositionMonitoring;
using PositionMonitoringShared;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace PositionMonitoringClient
{
    public class MainViewModel : ILoad, INotifyPropertyChanged, IDisposable
    {
        private const string Host = "localhost";
        private const int Port = 8888;

        private PositionMonitoringService.PositionMonitoringServiceClient _positionMonitoringService;
        private AsyncDuplexStreamingCall<PositionMonitoringMessage, PositionMonitoringMessageFromServer> _call;

        private ObservableCollection<PositionViewModel> _positions;
        private Dictionary<int, PositionViewModel> _positionsMap;
        private object _positionsLock = new object();

        public event PropertyChangedEventHandler? PropertyChanged;
        private DispatcherTimer _serverConnectionVerificationTimer;

        public MainViewModel()
        {
            _positionsMap = new Dictionary<int, PositionViewModel>();
            InitializeGrpc();
        }

        private bool _isServerConnected;
        public bool IsServerConnected
        {
            get { return _isServerConnected; }
            set
            {
                _isServerConnected = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsServerConnected)));
            }
        }

        private DateTime _lastUpdateTimeStamp;
        public DateTime LastUpdatedTimeStamp
        {
            get { return _lastUpdateTimeStamp; }
            set { _lastUpdateTimeStamp = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastUpdatedTimeStamp))); }
        }

        public ObservableCollection<PositionViewModel> Positions
        {
            get { return _positions; }
            set
            {
                _positions = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Positions)));
            }
        }

        public string ServerAddress
        {
            get { return $"{Host}:{Port}"; }
        }

        public string UserId
        {
            get { return System.Security.Principal.WindowsIdentity.GetCurrent().Name; }
        }

        private void InitializeServerConnectionVerificationTimer()
        {
            _serverConnectionVerificationTimer = new DispatcherTimer();
            _serverConnectionVerificationTimer.Tick += ServerConnectionVerificationTimerHandler;
            _serverConnectionVerificationTimer.Interval = new TimeSpan(0, 0, 1);
            _serverConnectionVerificationTimer.Start();
        }

        /// <summary>
        /// This method runs every second, and verifies if a valid connection with the server is established
        /// If the server connection is no longer valid, it will attempt to re-establish connection to the server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServerConnectionVerificationTimerHandler(object sender, EventArgs e)
        {
            
            try
            {
                if (_call == null)
                {
                    InitializeConnection();
                }
            }
            catch (Exception ex)
            {
                IsServerConnected = false;
                Console.WriteLine($"Error in method \"ServerConnectionVerificationTimerHandler\" : {ex.ToString()}");
            }
        }

        public void Loaded()
        {
            Positions = new ObservableCollection<PositionViewModel>();
            InitializeConnection();
            InitializeServerConnectionVerificationTimer();
        }

        private void InitializeGrpc()
        {
            // Create a channel
            var channel = new Channel(Host + ":" + Port, ChannelCredentials.Insecure);

            // Create a client with the channel
            _positionMonitoringService = new PositionMonitoringService.PositionMonitoringServiceClient(channel);
        }

        private async void InitializeConnection()
        {
            // Open a connection to the server
            try
            {
                using (_call = _positionMonitoringService.Connect())
                {
                    // Read messages from the response stream
                    while (await _call.ResponseStream.MoveNext(CancellationToken.None))
                    {
                        try
                        {
                            var serverMessage = _call.ResponseStream.Current;
                            Position positionOnServer = JsonSerializer.Deserialize<Position>(serverMessage.Message.Message);

                            if (positionOnServer != null)
                            {
                                bool positionExist = false;
                                PositionViewModel positionOnClient;

                                lock (_positionsLock)
                                {
                                    positionExist = _positionsMap.TryGetValue(positionOnServer.Id, out positionOnClient);

                                    if (positionExist && positionOnClient != null)
                                    {
                                        positionOnClient.CopyFrom(positionOnServer);
                                    }
                                    else
                                    {
                                        positionOnClient = new PositionViewModel();
                                        positionOnClient.CopyFrom(positionOnServer);

                                        _positions.Add(positionOnClient);
                                        _positionsMap.Add(positionOnClient.Id, positionOnClient);
                                    }
                                }
                                LastUpdatedTimeStamp = DateTime.Now;
                            }
                        }
                        catch (Exception ex) 
                        {
                            Console.WriteLine($"Error in method \"InitializeConnection\" reading ResponseStream : {ex.ToString()}");
                        }
                        IsServerConnected = true;
                    }
                }
            }
            catch (RpcException ex)
            {
                _call = null;
                IsServerConnected = false;
                Console.WriteLine($"Error in method \"InitializeConnection\" : {ex.ToString()}");
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
                    _positionMonitoringService = null;
                    if (_serverConnectionVerificationTimer != null)
                    {
                        _serverConnectionVerificationTimer.Tick -= ServerConnectionVerificationTimerHandler;
                    }
                    _serverConnectionVerificationTimer = null;
                }
                catch (RpcException ex) 
                { 
                }
            }
            // free native resources if there are any.
        }
    }
}
