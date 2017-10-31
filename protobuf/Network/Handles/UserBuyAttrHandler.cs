using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DataWrapper;

public class UserBuyAttrHandler : SuperBOBO.NetInterface
{
    //购买成功后处理
    public delegate void SuccessFunction();
    public static SuccessFunction tager = null;

    private void Delegate_SUB_ID_CONSUME_RSP(int errorCode, byte type, uint value, uint rate)
    {
        string str = "";

        switch((ChangeAttr)type)
        {
            case ChangeAttr.ATTR_GOLD:
                str = Table.Message.Get(20101).Tip;
                break;
            case ChangeAttr.ATTR_ENERGY:
                str = Table.Message.Get(20102).Tip;
                break;
        }

        if (tager != null)
        {
            tager();
            tager = null;
        }

        string body = string.Format(str, value);
        int critValue = (int)Mathf.Floor(rate * 0.01f);

        //翻倍
        if (critValue > 1)
        {
            GameObject go = UIManager.Instance.CreateUI("UI/Common/BoxBuyFruitLittleWindow") as GameObject;
            go.transform.parent = GameObject.FindObjectOfType<UIRoot>().transform;
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = Vector3.one;

            BoxBuyFruitLittleWindow window = go.GetComponent<BoxBuyFruitLittleWindow>();

            if (window != null)
            {
                window.setBody(body, critValue);
            }
        }
        else
        {
            UIMessageBox.ShowLittleWindow(body);
        }
    }

    public void OnRegister()
    {
        AutoGenProto.delegate_SUB_ID_CONSUME_RSP += Delegate_SUB_ID_CONSUME_RSP;
    }

    public void OnUnRegister()
    {
        AutoGenProto.delegate_SUB_ID_CONSUME_RSP -= Delegate_SUB_ID_CONSUME_RSP;
    }

    //断线重连后，数据同步调用方法 by shilongquan
    public void OnDataUpdate()
    {
        if (tager != null)
        {
            UIMessageBox.Show(151);
            tager = null;
        }
    }
}
