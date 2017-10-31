using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserItemListHandle : SuperBOBO.NetInterface
{
    [System.Obsolete("历史原因代码，废弃")]
    public static List<ItemInfo> notPropList = new List<ItemInfo>();


    public void Delegate_ID_ITEM_LIST_RSP(int errorCode, byte updateType, byte itemFrom, ItemInfo[] list)
    {

        //服务端下发的是全量
        List<ItemInfo> lst = new List<ItemInfo>(list);

        switch (updateType)
        {
            case 0://fullList
                foreach (ItemInfo info in list)
                {
                    //id从[1,9][200,300)只是显示用途，不能在背包里使用
                    if ((info.itemId >= 1 && info.itemId <= 9) || (info.itemId >= 200 && info.itemId < 300))
                    {
                        continue;
                    }

                    if (DataWrapper.Player.instance.bag.itemInfos.ContainsKey(info.itemId))
                        DataWrapper.Player.instance.bag.itemInfos[info.itemId] = info;
                    else
                    {
                        DataWrapper.Player.instance.bag.itemInfos.Add(info.itemId, info);
                    }

                }
                DataWrapper.Player.instance.bag.RefreshItem(lst);
                DataWrapper.Player.instance.bag.SortItem();
                break;
            case 1://add 

               
                    switch ((ItemFrom)itemFrom)
                    {
                        case ItemFrom.LUA:
                        case ItemFrom.NONE:
                        case ItemFrom.PVE:
                        case ItemFrom.TASK_AWARD_COMPLETE:
                        case ItemFrom.PVP:
                        case ItemFrom.DAILY_TASK_AWARD_COMPLETE:
                        case ItemFrom.MAIN_TASK_AWARD_COMPLETE:
                        case ItemFrom.TANK_REPEAT://坦克重复
                        case ItemFrom.COATING://涂装转换不提示  
                        case ItemFrom.CORPS:
                            break;
                        default:
                        case ItemFrom.GM:
                        case ItemFrom.MAIL:
                        case ItemFrom.TASK_AWARD_ACTIVITY:
                        case ItemFrom.ACTIVITY_COMPLETE:
                        case ItemFrom.USE:
                        case ItemFrom.FINISH_ASSIGN:

                            if (isOneGiftAndAutoUse(lst))
                            {
                                DataWrapper.Item item = DataWrapper.Item.GetAddedItem(lst[0].itemId, lst[0].itemNum); //只使用当前增加的礼包个数，不是所有的礼包
                                Common.UsePropGetItem(item.id,item.num);
                            }
                            else
                            {
                                OnShowItemList(lst,true);                            
                            }
                            break;
                        case ItemFrom.TANKCHEST:
                        case ItemFrom.TANKCHEST_TEN:
                        case ItemFrom.SUPER_TANKCHEST:
                        case ItemFrom.SUPER_TANKCHEST_TEN:
                        case ItemFrom.SUPER_BULLET:

                            //据勇哥说，这个逻辑用不到 by zj
                            //if (isGiftItems(lst))
                            //{
                            //    OnLottery(lst);
                            //}
                            //end by zj
                            
                            if (isOneGiftAndAutoUse(lst))
                            {
                                DataWrapper.Item item = DataWrapper.Item.GetAddedItem(lst[0].itemId, lst[0].itemNum); //只使用当前增加的礼包个数，不是所有的礼包
                                Common.UsePropGetItem(item.id,item.num);
                            }
                            else
                            {
                                OnShowItemList(lst,false);

                                if (UICopyChestBattle.instance != null)
                                {
                                    UICopyChestBattle.instance.resetNoClick();
                                }
                            }

                            break;

                        case ItemFrom.TURNTABLE_GOLD_FREE:
                        case ItemFrom.TURNTABLE_GOLD_ONCE:
                        case ItemFrom.TURNTABLE_DIAMOND_FREE:
                        case ItemFrom.TURNTABLE_DIAMOND_ONCE:
                            //if (isGiftItems(lst))
                            //{
                            OnTenLotteryOpenOne(lst);
                            //}

                            break;

                        case ItemFrom.TURNTABLE_GOLD_TEN:
                        case ItemFrom.TURNTABLE_DIAMOND_TEN:

                            //if (isGiftItems(lst))
                            //{
                            OnTenLotteryOpenTen(lst);
                            //}

                            break;
                    }

                // 入背包
                DataWrapper.Player.instance.bag.SetItem(lst);
                DataWrapper.Player.instance.bag.SortItem();
                break;
            case 2://del
                //入背包
                DataWrapper.Player.instance.bag.SetItem(lst);
                DataWrapper.Player.instance.bag.SortItem();
                break;
        }

        DataWrapper.ModelDispatcher.Instance.Dispatch(DataWrapper.Player.instance);
        SuperBOBO.EventManager.Instance.FireEvent(GameEventType.ITEM_LIST);

        Common.HideLoading();
    }


    /// <summary>
    /// 检测10连抽是否开启
    /// </summary>
    /// <param name="lst"></param>
    private void OnLottery(List<ItemInfo> lst)
    {
        if (UITenLottery.CheakIsOnLotteryUI())
        {
            if (UITenLottery.instane.isTen)
            {
                UITenLottery.instane.TenCallBack = OnItemListExtend_TenLottery;

            }
            else
            {
                UITenLottery.instane.LingCallBack = OnItemListExtend_OneLottery;

            }
        }
        else
        {
            OnShowItemList(lst, true);
        }
    }

    /// <summary>
    /// 是否十连抽开启的状态10个
    /// </summary>
    /// <param name="lst"></param>
    private void OnTenLotteryOpenTen(List<ItemInfo> lst)
    {
        if (UITenLottery.instane)
        {
            UITenLottery.instane.TenCallBack = OnItemListExtend_TenLottery;

        }
        else
        {
            OnShowItemList(lst, true);

        }
    }

    /// <summary>
    /// 十连抽只开启一个
    /// </summary>
    /// <param name="lst"></param>
    public void OnTenLotteryOpenOne(List<ItemInfo> lst)
    {
        ///需要等待旋转狂动画
        if (UITenLottery.instane)
        {
            UITenLottery.instane.LingCallBack = OnItemListExtend_OneLottery;

        }
        else
        {
            OnShowItemList(lst, true);

        }
    }


    /// <summary>
    /// 检测是不是开礼包之后的服务器返回的道具列表
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    [System.Obsolete("这段逻辑不要了(⊙﹏⊙)b")]

    private bool isGiftItems(List<ItemInfo> list)
    {

        bool value = true;
        if (DataWrapper.Player.instance == null)
            return value;
        if (DataWrapper.Player.instance.m_UseDLiBaoIDList == null)
            return value;
        if (DataWrapper.Player.instance.m_UseDLiBaoIDList.Count == 0)
            return value;
        Dictionary<uint, uint> tempDic = new Dictionary<uint, uint>();
        foreach (ItemInfo va in list)
        {
            uint tempItemNum = 0;
            if (DataWrapper.Player.instance.bag.itemInfos.ContainsKey(va.itemId))
            {
                tempItemNum = va.itemNum - DataWrapper.Player.instance.bag.itemInfos[va.itemId].itemNum;
            }
            else
            {
                tempItemNum = va.itemNum;
            }
            tempDic.Add(va.itemId, tempItemNum);
        }
        for (int i = 0; i < DataWrapper.Player.instance.m_UseDLiBaoIDList.Count; i++)
        {
            ItemInfo tempItemInfo = DataWrapper.Player.instance.m_UseDLiBaoIDList[i];
            string itemstr = Table.Item.GetP1(tempItemInfo.itemId);
            string[] itemListstr = itemstr.Split('|');
            if (itemListstr.Length != list.Count)
            {
                continue;
            }
            value = false;
            for (int k = 0; k < itemListstr.Length; k++)
            {
                uint tempid = uint.Parse(itemListstr[k].Split(';')[0]);
                short tempnum = (short)(short.Parse(itemListstr[k].Split(';')[1]) * tempItemInfo.itemNum);
                if (!tempDic.ContainsKey(tempid))
                {
                    value = true;
                    break;
                }
                if (tempDic[tempid] != tempnum)
                {
                    value = true;
                    break;
                }

            }
            if (value == false)
            {
                DataWrapper.Player.instance.m_UseDLiBaoIDList.RemoveAt(i);
                return value;
            }


        }

        return value;
    }

    /// <summary>
    /// 朴实无华の显示道具
    /// </summary>
    /// <param name="list"></param>
    public static void OnShowItemList(List<ItemInfo> list, bool hebing)
    {
        List<ItemInfo> l = new List<ItemInfo>();
        l.AddRange(list);
        UITip.ShowItemGet(DataWrapper.PlayerBag.ChangeType(l),hebing);
    }


    public static void OnItemListExtend_OneLottery(List<ItemInfo> list)
    {
        List<ItemInfo> l = new List<ItemInfo>();
        l.AddRange(list);
        UITip.ShowLotteryGet(ChangeTypeForTenLottery(l));

    }

    public static void OnItemListExtend_TenLottery(List<ItemInfo> list)
    {
        List<ItemInfo> l = new List<ItemInfo>();
        l.AddRange(list);
        UITip.ShowLotteryGet(ChangeTypeForTenLottery(l));
    }


    private static List<DataWrapper.Item> ChangeTypeForTenLottery(List<ItemInfo> info)
    {
        List<DataWrapper.Item> items = new List<DataWrapper.Item>();

        foreach (var k in info)
        {
            DataWrapper.Item i = new DataWrapper.Item(k.itemId, k.itemNum);
            items.Add(i);
        }

        return items;
    }

    /// <summary>
    /// 收到服务端下发的一个礼包，则自动使用,并且不显示
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    private bool isOneGiftAndAutoUse(List<ItemInfo> list)
    {
        bool value = false;

        if (list.Count == 1)
        {
            value = DataWrapper.Item.CanAutoUse(list[0].itemId);
        }

        return value;
    }


    public void OnRegister()
    {
        AutoGenProto.delegate_ID_ITEM_LIST_RSP += Delegate_ID_ITEM_LIST_RSP;
    }

    public void OnUnRegister()
    {
        AutoGenProto.delegate_ID_ITEM_LIST_RSP -= Delegate_ID_ITEM_LIST_RSP;
    }

    //断线重连后，数据同步调用方法 by shilongquan
    public void OnDataUpdate()
    {

    }
}
