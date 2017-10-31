using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class UserTankListHandle : SuperBOBO.NetInterface
{
    public void Delegate_ID_WAREHOUSE_TANK_LIST_RSP(int errorCode, byte type, byte tankFrom, WarehouseTankDetailInfo[] list)
    {
        List<WarehouseTankDetailInfo> lst = new List<WarehouseTankDetailInfo>(list);
        switch (type)
        {
            case 0://list
                DataWrapper.Player.instance.SetTank(lst);
                DataWrapper.Player.instance.currentSelectedTank = new DataWrapper.PlayerTank(list[0]);

                foreach (WarehouseTankDetailInfo temp in list)
                {
                    NetLog.GetInstance().PostLog("initTank:" + temp.tankId);
                }

                break;
            case 1://add 
                //Debug.Log("GetTank -> From = " + tankFrom);// 0
                TankFrom from = (TankFrom)tankFrom;
                switch (from)
                {
                    case TankFrom.TANK_FROM_LUA:
                        break;
                    case TankFrom.TANK_FROM_DB:
                    case TankFrom.TANK_FROM_AI_TEMPLATE:
                    case TankFrom.TANK_FROM_GM:
                    case TankFrom.TANK_FROM_NONE:
                    default:
                        if (UITenLottery.instane && UITenLottery.instane.gameObject.activeInHierarchy)
                        {
                            UITenLottery.instane.AddToGetTankCallBackList(UITip.ShowTankGet, new DataWrapper.PlayerTank(lst[0]));
                        }
                        else
                        {
                            UITip.ShowTankGet(new DataWrapper.PlayerTank(lst[0]));
                        }
                        break;
                }
                DataWrapper.Player.instance.AddTank(lst);
                if (UIWareHouseNew.instance != null && UIWareHouseNew.instance.gameObject.activeInHierarchy)
                {
                    if (UIWareHouseNew.instance.tankUpLevel != null && UIWareHouseNew.instance.tankUpLevel.gameObject.activeInHierarchy)
                    {   
                        UIWareHouseNew.instance.tankUpLevel.buyedHandler();
                    }
                }
                break;
            case 2://delete
                DataWrapper.Player.instance.DeleteTank(lst);
                DataWrapper.ModelDispatcher.Instance.Dispatch(DataWrapper.Player.instance);
                break;
        }

    }

    public void OnRegister()
    {
        AutoGenProto.delegate_ID_WAREHOUSE_TANK_LIST_RSP += Delegate_ID_WAREHOUSE_TANK_LIST_RSP;
    }

    public void OnUnRegister()
    {
        AutoGenProto.delegate_ID_WAREHOUSE_TANK_LIST_RSP -= Delegate_ID_WAREHOUSE_TANK_LIST_RSP;
    }

    //断线重连后，数据同步调用方法 by shilongquan
    public void OnDataUpdate()
    {

    }
}
