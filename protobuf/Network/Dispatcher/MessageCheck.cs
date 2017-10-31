using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// 专门用来检测收发协议，甚至可以验证一些逻辑
/// </summary>
public class MessageCheck:Singleton<MessageCheck>  
{
    private Dictionary<string, List<string>> msgMaps = new Dictionary<string, List<string>>();

    private List<string> sendList = new List<string>();

    private List<string> recvList = new List<string>();
    
    //注册监视消息
    public void Init()
    {
        //注册1对1的监视关系
        Reg("ShopReq", "ShopRsp");
    }

    public void Reg(string keySend,params string[] keyRecvs)
    {
        if (msgMaps.ContainsKey(keySend))
        {
            
            msgMaps[keySend].Clear();
            msgMaps[keySend].AddRange(keyRecvs);
        }
        else
        {
            List<string> r = new List<string>();
            r.AddRange(keyRecvs);
            msgMaps.Add(keySend, r);
        }
    }

    public void SendMessage(string key)
    {

        if (msgMaps.ContainsKey(key))
        {
            Common.ShowLoading(5);
            sendList.Add(key);
            Util.LogColor(EModule.message_check_send, string.Format("监视消息{0}", key));

        }
        else
        {
           // Util.LogColor(EModule.message_check_send, string.Format("发送消息{0}，不在监视列表中", key));
        }
    }

    public void RecvMessage(string key)
    {
       
        if (sendList.Count > 0)
        {
            recvList.Add(key);
            string send = sendList[0];

            if (msgMaps.ContainsKey(send))
            {
                List<string> checkList = msgMaps[send];

                if (checkList != null && checkList.Count > 0)
                {
                    if (recvList.Count >= checkList.Count)
                    {
                        List<int> pos = new List<int>();
                        for (int i = 0; i < recvList.Count; i++)
                        {
                            foreach (var k in checkList)
                            {
                                if (recvList[i] == k)
                                {
                                    pos.Add(i);
                                }
                            }
                        }
                        if (pos.Count == checkList.Count)
                        {
                            foreach (var k in pos)
                            {
                                recvList.RemoveAt(k);
                            }
                            sendList.RemoveAt(0);
                            Util.LogColor(EModule.message_check_recv, string.Format("监视消息{0}，成功收到回复{1}", send, key));
                            Common.HideLoading();
                        }
                    }
                }

                
            }
            else
            {
                sendList.Clear();
                recvList.Clear();
                Util.LogColor(EModule.message_check_recv, string.Format("收到错误消息{0}", key));
                
            }
        }
        else
        {
            //Util.LogColor(EModule.message_check_recv, string.Format("收到消息{0}，不在监视列表中", key));
        }

    }


}



