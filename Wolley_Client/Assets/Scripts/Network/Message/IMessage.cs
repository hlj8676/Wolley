//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: IMessage.proto
namespace network.message
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"FSMessage")]
  public partial class FSMessage : global::ProtoBuf.IExtensible
  {
    public FSMessage() {}
    
    private string _head;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"head", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string head
    {
      get { return _head; }
      set { _head = value; }
    }
    private byte[] _body;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"body", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public byte[] body
    {
      get { return _body; }
      set { _body = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}