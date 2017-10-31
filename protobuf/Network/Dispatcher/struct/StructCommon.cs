using UnityEngine;
using System.Collections;

using RakNet;

public static class BS_Extends_StructCommon
{
    public static void Write(this RakNet.BitStream bs, Vector3 data)
    {
        bs.Write(data.x);
        bs.Write(data.y);
        bs.Write(data.z);
    }

    public static void Read(this RakNet.BitStream bs, out Vector3 data)
    {
        bs.Read(out data.x);
        bs.Read(out data.y);
        bs.Read(out data.z);
    }

    public static void WriteCompressedPos(this RakNet.BitStream bs, Vector3 data)
    {
        int temp;
        temp = Mathf.CeilToInt(data.x * 100);
        bs.WriteCompressed(temp);
        temp = Mathf.CeilToInt(data.z * 100);
        bs.WriteCompressed(temp);
    }

    public static void WriteCompressedRot(this RakNet.BitStream bs, Vector3 data)
    {
        int temp;
       
        temp = Mathf.CeilToInt(data.y * 100);
        bs.WriteCompressed(temp);
    }

    public static void ReadCompressedPos(this RakNet.BitStream bs, out Vector3 data)
    {
        int temp = 0;
        bs.ReadCompressed(out temp);
        data.x = temp * 0.01f;
        bs.ReadCompressed(out temp);
        data.z = temp * 0.01f;
        //liypeng
        data.y = 31;
    }

    public static void ReadCompressedRot(this RakNet.BitStream bs, out Vector3 data)
    {
        int temp = 0;
        data = Vector3.zero;
        bs.ReadCompressed(out temp);
        data.y = temp * 0.01f;
      
    }
}
