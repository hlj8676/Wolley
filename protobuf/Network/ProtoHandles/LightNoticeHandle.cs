using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class LightNoticeHandle : SuperBOBO.PBHandler
{

    public static string handleName = "LightNoticeRsp";

    public void OnRecv(byte[] datas)
    {
        using (MemoryStream m = new MemoryStream(datas))
        {
            TankProtocol.LightNoticeRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.LightNoticeRsp>(m);

            if (SystemLoader.Instance)
            {
                SystemLoader.Instance.StartCoroutine(LightNoticeBrocastMessage.ShowGongGao(rsp.starttime, rsp.endtime, rsp.delay, rsp.context));
            }
        }

    }

    public class LightNoticeBrocastMessage
    {

        public static IEnumerator ShowGongGao(uint start, uint end, float delay, string msg)
        {
            DateTime ct = System.DateTime.Now;
            DateTime st = Common.StampToDateTime(start.ToString());
            DateTime et = Common.StampToDateTime(end.ToString());

            if (ct.Ticks < et.Ticks)
            {
                float duration = (float)TimeSpan.FromTicks(et.Ticks - st.Ticks).TotalSeconds;
                float startTime = Time.realtimeSinceStartup + (float)TimeSpan.FromTicks(st.Ticks - ct.Ticks).TotalSeconds;
                float endTime = startTime + duration;

                int count = System.Text.Encoding.Default.GetByteCount(msg);

                int d = (count / 40 + 1) * 17;
                if (delay < d)
                    delay = d;

                while (Time.time < endTime)
                {
                    if (Time.time > delay + startTime)
                    {
                        startTime = Time.time;
                        if (SocketFactory.battleSocket == null)
                            UIMessageBox.ShowRoll(msg);
                        Chat.InsertSystemMsg(msg);
                        yield return new WaitForSeconds(delay);
                    }

                    yield return new WaitForSeconds(1);
                }
            }
        }
    }

    public void OnUnRegister()
    {
        Debug.Log("just an unreg");
        SystemLoader.Instance.StopAllCoroutines();
    }

    public string GetRspName()
    {
        return handleName;
    }
}
