#region Designer generated code

using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;

namespace TommyLee.Example.Grpc.PositionMonitoring {
  public static class PositionMonitoringService
  {
    static readonly string __ServiceName = "TommyLee.example.grpc.PositionMonitoring.PositionMonitoringService";

    static readonly Marshaller<global::TommyLee.Example.Grpc.PositionMonitoring.PositionMonitoringMessage> __Marshaller_PositionMonitoringMessage = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::TommyLee.Example.Grpc.PositionMonitoring.PositionMonitoringMessage.Parser.ParseFrom);
    static readonly Marshaller<global::TommyLee.Example.Grpc.PositionMonitoring.PositionMonitoringMessageFromServer> __Marshaller_PositionMonitoringMessageFromServer = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::TommyLee.Example.Grpc.PositionMonitoring.PositionMonitoringMessageFromServer.Parser.ParseFrom);

    static readonly Method<global::TommyLee.Example.Grpc.PositionMonitoring.PositionMonitoringMessage, global::TommyLee.Example.Grpc.PositionMonitoring.PositionMonitoringMessageFromServer> __Method_Connect = new Method<global::TommyLee.Example.Grpc.PositionMonitoring.PositionMonitoringMessage, global::TommyLee.Example.Grpc.PositionMonitoring.PositionMonitoringMessageFromServer>(
        MethodType.DuplexStreaming,
        __ServiceName,
        "Connect",
        __Marshaller_PositionMonitoringMessage,
        __Marshaller_PositionMonitoringMessageFromServer);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::TommyLee.Example.Grpc.PositionMonitoring.PositionMonitoringReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of PositionMonitoringService</summary>
    public abstract class PositionMonitoringServiceBase
    {
      public virtual global::System.Threading.Tasks.Task Connect(IAsyncStreamReader<global::TommyLee.Example.Grpc.PositionMonitoring.PositionMonitoringMessage> requestStream, IServerStreamWriter<global::TommyLee.Example.Grpc.PositionMonitoring.PositionMonitoringMessageFromServer> responseStream, ServerCallContext context)
      {
        throw new RpcException(new Status(StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for PositionMonitoringService</summary>
    public class PositionMonitoringServiceClient : ClientBase<PositionMonitoringServiceClient>
    {
      /// <summary>Creates a new client for PositionMonitoringService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public PositionMonitoringServiceClient(Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for PositionMonitoringService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public PositionMonitoringServiceClient(CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected PositionMonitoringServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected PositionMonitoringServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual AsyncDuplexStreamingCall<global::TommyLee.Example.Grpc.PositionMonitoring.PositionMonitoringMessage, global::TommyLee.Example.Grpc.PositionMonitoring.PositionMonitoringMessageFromServer> Connect(Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return Connect(new CallOptions(headers, deadline, cancellationToken));
      }
      public virtual AsyncDuplexStreamingCall<global::TommyLee.Example.Grpc.PositionMonitoring.PositionMonitoringMessage, global::TommyLee.Example.Grpc.PositionMonitoring.PositionMonitoringMessageFromServer> Connect(CallOptions options)
      {
        return CallInvoker.AsyncDuplexStreamingCall(__Method_Connect, null, options);
      }
      protected override PositionMonitoringServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new PositionMonitoringServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    public static ServerServiceDefinition BindService(PositionMonitoringServiceBase serviceImpl)
    {
      return ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Connect, serviceImpl.Connect).Build();
    }

  }
}
#endregion
