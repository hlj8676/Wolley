using UnityEngine;
using System.Collections;

public class UserBasicPropChangeHandle : SuperBOBO.NetInterface
{
    public delegate void SuccessFunction();
    public static SuccessFunction tager = null;

    public void Delegate_ID_PLAYER_INFO_CHANGE_RSP(int errorCode, byte changeid, uint curValue, uint value1, uint value2)
    {
        NetLog.GetInstance().PostLog(string.Format("Delegate_ID_PLAYER_INFO_CHANGE_RSP:changeid={0},curValue={1}",changeid.ToString(),curValue));
        // UIWait.Wait(false);
        ChangeAttr change = (ChangeAttr)changeid;
        switch (change)
        {
            case ChangeAttr.ATTR_ENERGY:
                DataWrapper.Player.instance.energy = curValue;
                DataWrapper.Player.instance.serverDateTime = value1;
                DataWrapper.Player.instance.nextEnergyTime = value2 > 0 ? value2 - value1 : 0;
                SystemLoader.Instance.gameObject.AddMissingComponent<PlayerEnergyManager>();
                if(UIPlayerBasicPropItem.instance != null)
                {
                    UIPlayerBasicPropItem.instance.nextTime = DataWrapper.Player.instance.nextEnergyTime;
                }
         
                break;
            case ChangeAttr.ATTR_GOLD:
                DataWrapper.Player.instance.gold = curValue;
                break;
            case ChangeAttr.ATTR_DIAMOND:
                DataWrapper.Player.instance.diamond = curValue;
                break;
            case ChangeAttr.ATTR_COIN:
                DataWrapper.Player.instance.coin = curValue;
                break;
            case ChangeAttr.ATTR_ACTIVE:
                DataWrapper.Player.instance.activePoint = curValue;
                if (GuideManager.instance != null)
                    GuideManager.instance.CheckGuideToTrigger(7, curValue);//活跃度检测引导开放
                break;
            case ChangeAttr.ATTR_EXP:
                DataWrapper.Player.instance.exp = curValue;
                break;
            case ChangeAttr.ATTR_LEVEL:
                UILevelUpHandle.GetInstance().OnLevelUp(DataWrapper.Player.instance.level, curValue);
                DataWrapper.Player.instance.level = curValue;

                #if UNITY_EDITOR || UNITY_STANDALONE_WIN

                #elif UNITY_ANDROID
                    #if SDK_Quick
                        AndroidSDKManager.updateRoleInfo(false);
                    #endif
                #elif UNITY_IOS
                    #if SDK_Quick
                        IOSSDKManager.updateRoleInfo(false);
                    #endif
                #endif

                if (GuideManager.instance != null)
                    GuideManager.instance.CheckGuideToTrigger(1, curValue);//升级检测引导开放
                break;
            case ChangeAttr.ATTR_HONOR:
                DataWrapper.Player.instance.honor = curValue;
                break;
            case ChangeAttr.ATTR_BUYGOLDTIMES:
                DataWrapper.Player.instance.goldConvertCount = curValue;
                break;
            case ChangeAttr.ATTR_BUYENERGYTIMES:
                DataWrapper.Player.instance.energyConvertCount = curValue;
                break;
            case ChangeAttr.ATTR_STRATEGYPOTIN:
                DataWrapper.Player.instance.strategypoint = curValue;
                break;
            case ChangeAttr.ATTR_DEXP:
                DataWrapper.Player.instance.dexp = curValue;
                if (DataWrapper.Player.instance.country == 1 && GuideManager.instance != null)
                    GuideManager.instance.CheckGuideToTrigger(9, curValue);//国别经验检测引导开放
                break;
            case ChangeAttr.ATTR_REXP:
                DataWrapper.Player.instance.rexp = curValue;
                if (DataWrapper.Player.instance.country == 2 && GuideManager.instance != null)
                    GuideManager.instance.CheckGuideToTrigger(9, curValue);//国别经验检测引导开放
                break;
            case ChangeAttr.ATTR_YEXP:
                DataWrapper.Player.instance.yexp = curValue;
                if (DataWrapper.Player.instance.country == 3 && GuideManager.instance != null)
                    GuideManager.instance.CheckGuideToTrigger(9, curValue);//国别经验检测引导开放
                break;
            case ChangeAttr.ATTR_SEXP:
                DataWrapper.Player.instance.sexp = curValue;
                if (DataWrapper.Player.instance.country == 4 && GuideManager.instance != null)
                    GuideManager.instance.CheckGuideToTrigger(9, curValue);//国别经验检测引导开放
                break;
            case ChangeAttr.ATTR_MEXP:
                DataWrapper.Player.instance.mexp = curValue;
                if (DataWrapper.Player.instance.country == 5 && GuideManager.instance != null)
                    GuideManager.instance.CheckGuideToTrigger(9, curValue);//国别经验检测引导开放
                break;
            case ChangeAttr.ATTR_GLOBAL_EXP:
                DataWrapper.Player.instance.drysmexp = curValue;
                break;
            case ChangeAttr.ATTR_RECHARGE:
                DataWrapper.Player.instance.recharge = curValue;
                DataWrapper.PlayerVIP.CheckAndDoChange();
                break;
            case ChangeAttr.ATTR_ARMORPOINT:
                DataWrapper.Player.instance.armorpoint = curValue;
                break;
            case ChangeAttr.ATTR_RECHARGE6:
                DataWrapper.Player.instance.recharge6 = curValue;
                break;
            case ChangeAttr.ATTR_RECHARGE30:
                DataWrapper.Player.instance.recharge30 = curValue;
                break;
            case ChangeAttr.ATTR_RECHARGE68:
                DataWrapper.Player.instance.recharge68 = curValue;
                break;
            case ChangeAttr.ATTR_RECHARGE128:
                DataWrapper.Player.instance.recharge128 = curValue;
                break;
            case ChangeAttr.ATTR_RECHARGE328:
                DataWrapper.Player.instance.recharge328 = curValue;
                break;
            case ChangeAttr.ATTR_RECHARGE648:
                DataWrapper.Player.instance.recharge648 = curValue;
                break;
            case ChangeAttr.ATTR_MONTHCARD25:
                uint tempmonthCard25 = DataWrapper.Player.instance.monthCard25;
                DataWrapper.Player.instance.monthCard25 = curValue;
                System.DateTime sinceDt = System.DateTime.Now;
                DataWrapper.Player.instance.monthCardEndTime = sinceDt.AddSeconds(curValue);

                if (tempmonthCard25 < curValue)
                {
                    GameObject go = UIManager.Instance.CreateUI("UI/Tips/UIMonth") as GameObject;
                    go.transform.parent = GameObject.FindObjectOfType<UIRoot>().transform;
                    go.transform.localScale = Vector3.one;
                    go.transform.localPosition = Vector3.zero;
                }
                break;
        }

        DataWrapper.ModelDispatcher.Instance.Dispatch(DataWrapper.Player.instance);

        if (tager != null)
        {
            tager();
        }
    }

    public void OnRegister()
    {
        AutoGenProto.delegate_ID_PLAYER_INFO_CHANGE_RSP += Delegate_ID_PLAYER_INFO_CHANGE_RSP;

    }
    public void OnUnRegister()
    {
        AutoGenProto.delegate_ID_PLAYER_INFO_CHANGE_RSP -= Delegate_ID_PLAYER_INFO_CHANGE_RSP;

    }

    //断线重连后，数据同步调用方法 by shilongquan
    public void OnDataUpdate()
    {

    }
}
