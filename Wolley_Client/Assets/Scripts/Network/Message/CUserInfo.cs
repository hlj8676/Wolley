//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: CUserInfo.proto
namespace network.message
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"UserInfo")]
  public partial class UserInfo : global::ProtoBuf.IExtensible
  {
    public UserInfo() {}
    
    private long _uid;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"uid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public long uid
    {
      get { return _uid; }
      set { _uid = value; }
    }
    private int _locationServerId;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"locationServerId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int locationServerId
    {
      get { return _locationServerId; }
      set { _locationServerId = value; }
    }
    private int _homeServerId;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"homeServerId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int homeServerId
    {
      get { return _homeServerId; }
      set { _homeServerId = value; }
    }
    private string _name;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }
    private int _level;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"level", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int level
    {
      get { return _level; }
      set { _level = value; }
    }
    private int _icon;
    [global::ProtoBuf.ProtoMember(6, IsRequired = true, Name=@"icon", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int icon
    {
      get { return _icon; }
      set { _icon = value; }
    }
    private long _power;
    [global::ProtoBuf.ProtoMember(7, IsRequired = true, Name=@"power", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public long power
    {
      get { return _power; }
      set { _power = value; }
    }
    private long _killCount;
    [global::ProtoBuf.ProtoMember(8, IsRequired = true, Name=@"killCount", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public long killCount
    {
      get { return _killCount; }
      set { _killCount = value; }
    }
    private int _powerRank;
    [global::ProtoBuf.ProtoMember(10, IsRequired = true, Name=@"powerRank", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int powerRank
    {
      get { return _powerRank; }
      set { _powerRank = value; }
    }
    private int _vip;
    [global::ProtoBuf.ProtoMember(11, IsRequired = true, Name=@"vip", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int vip
    {
      get { return _vip; }
      set { _vip = value; }
    }
    private string _jid;
    [global::ProtoBuf.ProtoMember(13, IsRequired = true, Name=@"jid", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string jid
    {
      get { return _jid; }
      set { _jid = value; }
    }
    private string _sign;
    [global::ProtoBuf.ProtoMember(16, IsRequired = true, Name=@"sign", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string sign
    {
      get { return _sign; }
      set { _sign = value; }
    }
    private string _avatar;
    [global::ProtoBuf.ProtoMember(17, IsRequired = true, Name=@"avatar", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string avatar
    {
      get { return _avatar; }
      set { _avatar = value; }
    }
    private int _lang;
    [global::ProtoBuf.ProtoMember(18, IsRequired = true, Name=@"lang", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int lang
    {
      get { return _lang; }
      set { _lang = value; }
    }
    private int _nationalFlag;
    [global::ProtoBuf.ProtoMember(19, IsRequired = true, Name=@"nationalFlag", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int nationalFlag
    {
      get { return _nationalFlag; }
      set { _nationalFlag = value; }
    }
    private bool _newRole;
    [global::ProtoBuf.ProtoMember(21, IsRequired = true, Name=@"newRole", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool newRole
    {
      get { return _newRole; }
      set { _newRole = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}