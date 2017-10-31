using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserTankDetailHandle:SuperBOBO.NetInterface
{

    public void Delegate_ID_WAREHOUSE_TANK_DETAIL_INFO_RSP(int errorCode, byte type, WarehouseTankDetailInfo[] list)
    {
        WarehouseTankDetailInfo detailInfo = list[0];
        DataWrapper.PlayerTank playerTank = DataWrapper.Player.instance.FindTank(detailInfo.tankId);

        if(playerTank.detail.useTimes > 0)
        {
            uint count = detailInfo.useTimes - playerTank.detail.useTimes;
            string str = Table.Message.Get(1516).Tip;
            string body = string.Format(str, count, playerTank.name);
            UIMessageBox.ShowLittleWindow(body);
        }

        playerTank.SetInfo(detailInfo);
        if (DataWrapper.Player.instance.currentSelectedTank.tankId == list[0].tankId)
            DataWrapper.Player.instance.currentSelectedTank.detail = list[0];
        DataWrapper.ModelDispatcher.Instance.Dispatch(DataWrapper.Player.instance.FindTank(list[0].tankId));
    }

    public void OnRegister()
    {
        AutoGenProto.delegate_ID_WAREHOUSE_TANK_DETAIL_INFO_RSP += Delegate_ID_WAREHOUSE_TANK_DETAIL_INFO_RSP;   
    }

    public void OnUnRegister()
    {
        AutoGenProto.delegate_ID_WAREHOUSE_TANK_DETAIL_INFO_RSP -= Delegate_ID_WAREHOUSE_TANK_DETAIL_INFO_RSP;   
    }

    //断线重连后，数据同步调用方法 by shilongquan
    public void OnDataUpdate()
    {

    }
}
