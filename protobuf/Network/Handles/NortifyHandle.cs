using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NortifyHandle : SuperBOBO.NetInterface
{

    public void Delegate_SUB_ID_NOTIFY_MESSAGE_RSP(int errorCode, uint id, NotifyMsg[] list)
    {

        bool speical = false;
        bool quickChat = false;
        NotifyMsgID msg = (NotifyMsgID)id;
      //  Debug.LogError("----------------------------------->msg--->" + id.ToString());
        switch (msg)// todo ui
        {

            case NotifyMsgID.NotifyMsgID_Battle_Drop_Item:
                ItemDropFactory.CreateItemDrop(1);
                break;

            case NotifyMsgID.NotifyMsgID_Battle_First_Kill_People:

                NotifyMsg msg1 = list[0];
                NotifyMsg msg2 = list[1];
                

                RoomPlayerInfo info = ARoom.GetPlayers().GetPlayer(msg1.paramInt);
                if (info != null)
                    msg1.paramStr = info.userName;
                else
                    return;
                info = ARoom.GetPlayers().GetPlayer(msg2.paramInt);
                if (info != null)
                    msg2.paramStr = info.userName;
                else
                    return;
                //   msg2.paramInt = 0;

                LevelManagerBase.instance.OnBattleEvent(GameEventType.FirstBlood, new object[] { msg1.paramInt, msg2.paramInt });
  
                return;
            case NotifyMsgID.NotifyMsgID_Battle_Kill_People:
                speical = true;
                msg1 = list[0];
                msg2 = list[1];
                //msg1.paramStr = ARoom.GetPlayers().GetPlayer(msg1.paramInt).userName;
                //msg1.paramInt = 0;

                //msg2.paramStr = ARoom.GetPlayers().GetPlayer(msg2.paramInt).userName;
                //msg2.paramInt = 0;

                break;

            //QuickChat-----------------------------------------------------------------------------------------------------------------------------
            case NotifyMsgID.NotifyMsgID_Battle_Quick_Talk:
                quickChat = true;
                break;

        }
        if(id>=50101 && id<=50109)
        {
            NotifyMsg msg1 = list[0];

            RoomPlayerInfo info = ARoom.GetPlayers().GetPlayer(msg1.paramInt);
            if (info != null)
            {
                msg1.paramInt = 0;
                msg1.paramStr = info.userName;
            }
              
        }
        List<NotifyMsg> lst = new List<NotifyMsg>(list);
        if (speical)
        {

            BattlePlayer kill = LevelManagerBase.GetPlayer(lst[0].paramInt);
            BattlePlayer dead = LevelManagerBase.GetPlayer(lst[1].paramInt);
            if (kill != null && dead != null && kill.playername != null && dead.playername != null)
            {
                NetLog.GetInstance().PostLog("收到一次 " + kill.playername.ToString() + "杀" + dead.playername.ToString());
                UIMessageBox.ShowKill(lst);
            }
        }
        else if (quickChat)
        {
            if (lst.Count > 1)
                if (UIQuickChat_Expression.instance)
                    UIQuickChat_Expression.instance.PlayExpGIF(lst[0].paramInt, lst[1].paramInt);
            //UIMessageBox.ShowRoll("" + lst[0].paramInt + lst[1].paramInt);
        }
        else
        {
            UIMessageBox.Show(id, lst);
        }

    }

    public void OnRegister()
    {

        AutoGenProto.delegate_SUB_ID_NOTIFY_MESSAGE_RSP += Delegate_SUB_ID_NOTIFY_MESSAGE_RSP;
    }

    public void OnUnRegister()
    {
        AutoGenProto.delegate_SUB_ID_NOTIFY_MESSAGE_RSP -= Delegate_SUB_ID_NOTIFY_MESSAGE_RSP;
    }

    //断线重连后，数据同步调用方法 by shilongquan
    public void OnDataUpdate()
    {

    }
}
