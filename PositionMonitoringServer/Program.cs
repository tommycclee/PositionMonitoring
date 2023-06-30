// See https://aka.ms/new-console-template for more information
using System;
using Grpc.Core;
using TommyLee.Example.Grpc.PositionMonitoring;

namespace PositionMonitoringServer
{
    class Program
    {
        const string Host = "localhost";
        const int Port = 8888;

        public static void Main(string[] args)
        {
            var positionCache = new PositionCache();
            var realTimeMarketDataServiceSimulator = new RealTimeMarketDataServiceSimulator(positionCache);
            realTimeMarketDataServiceSimulator.Start();

            // Build server
            var server = new Server
            {
                Services = { PositionMonitoringService.BindService(new PositionMonitoringServiceImpl(positionCache)) },
                Ports = { new ServerPort(Host, Port, ServerCredentials.Insecure) }
            };

            // Start server
            server.Start();

            Console.WriteLine("*************************************************************************");
            Console.WriteLine("*                    POSITION MONITORING SIMULATOR                      *");
            Console.WriteLine("*                                                                       *");
            Console.WriteLine("*  Author      : Tommy Lee                                              *");
            Console.WriteLine("*  Date        : 29-Jun-2023                                            *");
            Console.WriteLine("*  Description : This service will simulate a position monitoring       *");
            Console.WriteLine("*                system publshing real-time prices and quantity on a    *");
            Console.WriteLine("*                set of instruments.                                    *");
            Console.WriteLine("*                                                                       *");
            Console.WriteLine("*                This service will publish a set of positions and       *");
            Console.WriteLine("*                trades with randomized values every second to          *");
            Console.WriteLine("*                clients connected via gRPC.                            *");
            Console.WriteLine("*                                                                       *");
            Console.WriteLine("*                To simulate the scenario allowing clients to           *");
            Console.WriteLine("*                gracefully recover from a service restart, simply      *");
            Console.WriteLine("*                kill this service, and restart it. The clients         *");
            Console.WriteLine("*                should automatically reconnect to the service and      *");
            Console.WriteLine("*                continue to refresh real-time data.                    *");
            Console.WriteLine("*                                                                       *");
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("Position Monitoring Simulation Server listening on port " + Port);
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}