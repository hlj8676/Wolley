using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BattlePaintHandle : SuperBOBO.NetInterface
{

    List<Pail> pailInfos = new List<Pail>();

    public BattlePaintHandle()
    {
        pailInfos.Clear();
    }

    public void OnRegister()
    {
        AutoGenProto.delegate_SUB_ID_PAIL_LIST_RSP += Delegate_SUB_ID_PAIL_LIST_RSP;
        AutoGenProto.delegate_SUB_ID_PAIL_LIST_RSP_completed += Delegate_SUB_ID_PAIL_LIST_RSP_completed;
        AutoGenProto.delegate_SUB_ID_PAIL_HIT_RSP += Delegate_SUB_ID_PAIL_HIT_RSP;
        AutoGenProto.delegate_SUB_ID_PAIL_HIT_RSP_completed += Delegate_SUB_ID_PAIL_HIT_RSP_completed;


    }

    public void OnUnRegister()
    {
        AutoGenProto.delegate_SUB_ID_PAIL_LIST_RSP -= Delegate_SUB_ID_PAIL_LIST_RSP;
        AutoGenProto.delegate_SUB_ID_PAIL_LIST_RSP_completed -= Delegate_SUB_ID_PAIL_LIST_RSP_completed;
        AutoGenProto.delegate_SUB_ID_PAIL_HIT_RSP -= Delegate_SUB_ID_PAIL_HIT_RSP;
        AutoGenProto.delegate_SUB_ID_PAIL_HIT_RSP_completed -= Delegate_SUB_ID_PAIL_HIT_RSP_completed;

    }

    public void Delegate_SUB_ID_PAIL_LIST_RSP(int _errcode, uint idx, uint tid, uint blood, short x, short y, short z)
    {
        pailInfos.Add(new Pail(idx,tid,blood,x,y,z));
    }

    public void Delegate_SUB_ID_PAIL_LIST_RSP_completed()
    {
        foreach (var k in pailInfos)
        { 
            ASceneObject ao = SceneObjectFactory.CreateSceneObject(k.idx,k.tid,new Vector3(Common.PVP_ConvertFloat(k.x),Common.PVP_ConvertFloat(k.y),Common.PVP_ConvertFloat(k.z)));

            ConsoleShow.LogWarning("生成场景物件 " + k.idx + "  " + k.tid);
            //Util.LogWarning("生成场景物件 " + k.idx + "  " + k.tid);

            (ao as PaintBucket).pailInfo = k;

            SceneObjectList.AddObject(ao);
        }
    }

    public void Delegate_SUB_ID_PAIL_HIT_RSP(int _errcode, uint idx, uint tid, uint blood, short x, short y, short z)
    {
        Pail p = pailInfos.Find(
         (go)=> 
            {
            if (go.idx == idx)
            {
                return true;
            }
            return false;
        });

        p.tid = tid;
        p.blood = blood;
        p.x = x;
        p.y = y;
        p.z = z;

        ConsoleShow.Log("hp" + p.blood);

        if (p.blood <= 0)
        {
            IObject io = SceneObjectList.GetObject(p.idx);
            if (io is ASceneObject)
            {
                ASceneObject aso = io as ASceneObject;
                aso.OnDead();
                SceneObjectList.RemoveObject(p.idx);
            }
            else
            {
                Util.LogError("error");
            }
        }
    }
    public void Delegate_SUB_ID_PAIL_HIT_RSP_completed()
    { 
        //no use       
    }

    //断线重连后，数据同步调用方法 by shilongquan
    public void OnDataUpdate()
    {

    }
}
