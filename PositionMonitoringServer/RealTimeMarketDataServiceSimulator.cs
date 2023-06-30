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
    /// This class creates a simulation of a set of positions updating with real-time market data
    /// </summary>
    internal class RealTimeMarketDataServiceSimulator : IDisposable
    {
        private PositionCache _positionCache;
        private Random _random = new Random();
        private int _tradeIdCounter = 1000000;
        private int _partyId = 2000000;
        private int _counterPartyIdCounter = 3000000;
        private int _traderIdCounter = 4000000;
        private int _lastUpdatedByIdCounter = 5000000;

        public RealTimeMarketDataServiceSimulator(PositionCache positionCache) 
        { 
            _positionCache = positionCache;
        }  

        /// <summary>
        /// This method starts the simulation by creating a set of positions, and starting a task to simulate position and trade data updates
        /// </summary>
        public void Start()
        {
            _positionCache.Add(1, "700.HK", 1000);
            _positionCache.Add(2, "939.HK", 10000);
            _positionCache.Add(3, "1288.HK", 50000);
            _positionCache.Add(4, "0005.HK", 75000);
            _positionCache.Add(5, "0008.HK", 100000);

            Task.Factory.StartNew(() => StartSimulation(), CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default);
        }

        /// <summary>
        /// This method runs the simulation by going through each position in the PositionCache, and update each position and trade with randomized values
        /// </summary>
        private void StartSimulation()
        {
            while (true)
            {
                try
                {
                    var positionIdList = _positionCache.ReadFromCacheAllPositionId();
                    var simulatedPositions = new List<Position>();

                    foreach (var positionId in positionIdList)
                    {
                        var position = _positionCache.ReadFromCache(positionId);
                        SimulatePosition(position);
                        var simulatedPosition = new Position();
                        position.CopyTo(simulatedPosition);
                        simulatedPositions.Add(simulatedPosition);
                        if (_positionCache.OnPositionsChanged != null) _positionCache.OnPositionsChanged(simulatedPositions);
                    }
                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in \"StartSimulation\" : {ex.ToString()}");
                }
            }
        }

        private void SimulatePosition(Position position)
        {
            lock (position.SyncLock)
            {
                var realTimeSpot = _random.NextDouble() * 100;
                realTimeSpot = realTimeSpot == 0 ? 1 : realTimeSpot;
                position.Spot = realTimeSpot;
                position.QtyT_0 = _random.Next(1, position.QtyT_1 * 2);
                position.QtyChange = position.QtyT_0 - position.QtyT_1;
                position.CumulativeQtyChange = position.CumulativeQtyChange + Math.Abs(position.QtyChange);
                position.TotalCumulativeQtyTraded = position.QtyT_1 + position.CumulativeQtyChange;
                position.LastUpdated = DateTime.Now;
                position.LatestTrade = new Trade();
                SimulateTrade(position);
            }
        }

        private void SimulateTrade(Position position)
        {
            position.LatestTrade.TradeId = ++_tradeIdCounter;
            position.LatestTrade.PartyId = _partyId;
            position.LatestTrade.CounterPartyId = ++_counterPartyIdCounter;
            position.LatestTrade.TraderId = ++_traderIdCounter;
            position.LatestTrade.TradeDate = DateTime.Now;
            position.LatestTrade.Ticker = position.Ticker;
            position.LatestTrade.Quantity = Math.Abs(position.QtyChange);
            position.LatestTrade.BuySell = position.QtyChange > 0 ? "Buy" : "Sell";
            position.LatestTrade.SpotPrice = position.Spot;
            position.LatestTrade.LastUpdated = DateTime.Now;
            position.LatestTrade.FXRate = 7.75 + (_random.NextDouble() * (7.85 - 7.75));
            position.LatestTrade.LastUpdatedById = ++_lastUpdatedByIdCounter;
            position.LatestTrade.MarketingDesk = "HK_STOCK_MARKETING";
            position.LatestTrade.NotionalUSD = position.Spot * Math.Abs(position.QtyChange) / position.LatestTrade.FXRate;
            position.LatestTrade.RiskBook = "HK_STOCK_RISK";
            position.LatestTrade.SettlementCcy = "HKD";
            position.LatestTrade.TradeDate = DateTime.Now;
            position.LatestTrade.SettlementDate = position.LatestTrade.TradeDate.AddDays(2); //exclude holiday schedule for now
            position.LatestTrade.TradeCcy = "HKD";
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
                    _positionCache = null;
                }
                catch (RpcException ex)
                {
                }
            }
            // free native resources if there are any.
        }
    }
}
