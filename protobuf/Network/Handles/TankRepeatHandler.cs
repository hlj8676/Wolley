using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SuperBOBO;
using System.IO;
using DataWrapper;
public class TankRepeatHandler :   PBHandler {

    public const string Rsp = "TankRepeatObtainItemRsp";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public string GetRspName()
    {
        return Rsp;
    }

    public void OnRecv(byte[] datas)
    {
        MemoryStream m = new MemoryStream(datas);
        TankProtocol.TankRepeatObtainItemRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.TankRepeatObtainItemRsp>(m);

        if (rsp == null)
            return;
        Item i = new Item(rsp.itemId, rsp.itemNum);
        List<Item> items = new List<Item>();
        items.Add(i);

        Table.Tank data = Table.Tank.Get(rsp.tankdId + "-1");

        UITip.ShowItemGet(items, false, data.Name);
    }

    public void OnUnRegister()
    {
    }
}
