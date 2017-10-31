using UnityEngine;
using System.Collections;

namespace Module
{
    public struct StructTest
    {
        public int m_instanceID;
        public Vector3 m_position;
        public Vector3 m_direction;
    }

    public static class BS_Extends_StructTest
    {
        public static void Write(this RakNet.BitStream bs, StructTest data)
        {
            bs.Write(data.m_instanceID);

            Vector3 v = data.m_position;
            bs.Write(v.x);
            bs.Write(v.y);
            bs.Write(v.z);

            Vector3 f = data.m_direction;
            bs.Write(f.x);
            bs.Write(f.y);
            bs.Write(f.z);
        }
    }
}
