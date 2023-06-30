#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace TommyLee.Example.Grpc.PositionMonitoring {

  public static partial class PositionMonitoringReflection {

    #region Descriptor
    
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static PositionMonitoringReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChZDaGF0L3Byb3Rvcy9jaGF0LnByb3RvEhVjb20uZXhhbXBsZS5ncnBjLmNo",
            "YXQiLAoLQ2hhdE1lc3NhZ2USDAoEZnJvbRgBIAEoCRIPCgdtZXNzYWdlGAIg",
            "ASgJIkwKFUNoYXRNZXNzYWdlRnJvbVNlcnZlchIzCgdtZXNzYWdlGAIgASgL",
            "MiIuY29tLmV4YW1wbGUuZ3JwYy5jaGF0LkNoYXRNZXNzYWdlMmsKC0NoYXRT",
            "ZXJ2aWNlElwKBGNoYXQSIi5jb20uZXhhbXBsZS5ncnBjLmNoYXQuQ2hhdE1l",
            "c3NhZ2UaLC5jb20uZXhhbXBsZS5ncnBjLmNoYXQuQ2hhdE1lc3NhZ2VGcm9t",
            "U2VydmVyKAEwAWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::TommyLee.Example.Grpc.PositionMonitoring.PositionMonitoringMessage), global::TommyLee.Example.Grpc.PositionMonitoring.PositionMonitoringMessage.Parser, new[]{ "From", "Message" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::TommyLee.Example.Grpc.PositionMonitoring.PositionMonitoringMessageFromServer), global::TommyLee.Example.Grpc.PositionMonitoring.PositionMonitoringMessageFromServer.Parser, new[]{ "Message" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class PositionMonitoringMessage : pb::IMessage<PositionMonitoringMessage> {
    private static readonly pb::MessageParser<PositionMonitoringMessage> _parser = new pb::MessageParser<PositionMonitoringMessage>(() => new PositionMonitoringMessage());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<PositionMonitoringMessage> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::TommyLee.Example.Grpc.PositionMonitoring.PositionMonitoringReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PositionMonitoringMessage() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PositionMonitoringMessage(PositionMonitoringMessage other) : this() {
      from_ = other.from_;
      message_ = other.message_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PositionMonitoringMessage Clone() {
      return new PositionMonitoringMessage(this);
    }

    /// <summary>Field number for the "from" field.</summary>
    public const int FromFieldNumber = 1;
    private string from_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string From {
      get { return from_; }
      set {
        from_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "message" field.</summary>
    public const int MessageFieldNumber = 2;
    private string message_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Message {
      get { return message_; }
      set {
        message_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as PositionMonitoringMessage);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(PositionMonitoringMessage other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (From != other.From) return false;
      if (Message != other.Message) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (From.Length != 0) hash ^= From.GetHashCode();
      if (Message.Length != 0) hash ^= Message.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (From.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(From);
      }
      if (Message.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Message);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (From.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(From);
      }
      if (Message.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Message);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(PositionMonitoringMessage other) {
      if (other == null) {
        return;
      }
      if (other.From.Length != 0) {
        From = other.From;
      }
      if (other.Message.Length != 0) {
        Message = other.Message;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            From = input.ReadString();
            break;
          }
          case 18: {
            Message = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class PositionMonitoringMessageFromServer : pb::IMessage<PositionMonitoringMessageFromServer> {
    private static readonly pb::MessageParser<PositionMonitoringMessageFromServer> _parser = new pb::MessageParser<PositionMonitoringMessageFromServer>(() => new PositionMonitoringMessageFromServer());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<PositionMonitoringMessageFromServer> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::TommyLee.Example.Grpc.PositionMonitoring.PositionMonitoringReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PositionMonitoringMessageFromServer() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PositionMonitoringMessageFromServer(PositionMonitoringMessageFromServer other) : this() {
      Message = other.message_ != null ? other.Message.Clone() : null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PositionMonitoringMessageFromServer Clone() {
      return new PositionMonitoringMessageFromServer(this);
    }

    /// <summary>Field number for the "message" field.</summary>
    public const int MessageFieldNumber = 2;
    private global::TommyLee.Example.Grpc.PositionMonitoring.PositionMonitoringMessage message_;
    /// <summary>
    /// google.protobuf.Timestamp timestamp = 1;
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::TommyLee.Example.Grpc.PositionMonitoring.PositionMonitoringMessage Message {
      get { return message_; }
      set {
        message_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as PositionMonitoringMessageFromServer);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(PositionMonitoringMessageFromServer other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Message, other.Message)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (message_ != null) hash ^= Message.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (message_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Message);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (message_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Message);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(PositionMonitoringMessageFromServer other) {
      if (other == null) {
        return;
      }
      if (other.message_ != null) {
        if (message_ == null) {
          message_ = new global::TommyLee.Example.Grpc.PositionMonitoring.PositionMonitoringMessage();
        }
        Message.MergeFrom(other.Message);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 18: {
            if (message_ == null) {
              message_ = new global::TommyLee.Example.Grpc.PositionMonitoring.PositionMonitoringMessage();
            }
            input.ReadMessage(message_);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
