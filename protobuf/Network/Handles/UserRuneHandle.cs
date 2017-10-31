using UnityEngine;
using System.Collections;

using DataWrapper;

public class UserRuneHandle : SuperBOBO.NetInterface
{
    public void OnRegister()
    {
        AutoGenProto.delegate_SUB_ID_WAREHOUSE_TACTIC_PAGE_RSP += delegate_SUB_ID_WAREHOUSE_TACTIC_PAGE_RSP;

        AutoGenProto.delegate_SUB_ID_WAREHOUSE_TACTIC_PAGE_LSIT_RSP += delegate_SUB_ID_WAREHOUSE_TACTIC_PAGE_LSIT_RSP;
        AutoGenProto.delegate_SUB_ID_WAREHOUSE_TACTIC_UNLOCK_SOCKET_RSP += delegate_SUB_ID_WAREHOUSE_TACTIC_UNLOCK_SOCKET_RSP;
        AutoGenProto.delegate_SUB_ID_WAREHOUSE_TACTIC_UP_RUNE_RSP += delegate_SUB_ID_WAREHOUSE_TACTIC_UP_RUNE_RSP;
        AutoGenProto.delegate_SUB_ID_WAREHOUSE_TACTIC_DOWN_RUNE_RSP += delegate_SUB_ID_WAREHOUSE_TACTIC_DOWN_RUNE_RSP;
        AutoGenProto.delegate_SUB_ID_WAREHOUSE_TACTIC_SET_NAME_RSP += delegate_SUB_ID_WAREHOUSE_TACTIC_SET_NAME_RSP;
        AutoGenProto.delegate_SUB_ID_WAREHOUSE_TACTIC_DOWN_ALL_RUNE_RSP += delegate_SUB_ID_WAREHOUSE_TACTIC_DOWN_ALL_RUNE_RSP;

        AutoGenProto.delegate_SUB_ID_WAREHOUSE_TACTIC_DECOMPOSE_RSP += delegate_SUB_ID_WAREHOUSE_TACTIC_DECOMPOSE_RSP;
        AutoGenProto.delegate_SUB_ID_WAREHOUSE_TACTIC_COMPOSE_RSP += delegate_SUB_ID_WAREHOUSE_TACTIC_COMPOSE_RSP;
    }

    public void OnUnRegister()
    {
        AutoGenProto.delegate_SUB_ID_WAREHOUSE_TACTIC_PAGE_RSP -= delegate_SUB_ID_WAREHOUSE_TACTIC_PAGE_RSP;

        AutoGenProto.delegate_SUB_ID_WAREHOUSE_TACTIC_PAGE_LSIT_RSP -= delegate_SUB_ID_WAREHOUSE_TACTIC_PAGE_LSIT_RSP;
        AutoGenProto.delegate_SUB_ID_WAREHOUSE_TACTIC_UNLOCK_SOCKET_RSP -= delegate_SUB_ID_WAREHOUSE_TACTIC_UNLOCK_SOCKET_RSP;
        AutoGenProto.delegate_SUB_ID_WAREHOUSE_TACTIC_UP_RUNE_RSP -= delegate_SUB_ID_WAREHOUSE_TACTIC_UP_RUNE_RSP;
        AutoGenProto.delegate_SUB_ID_WAREHOUSE_TACTIC_SET_NAME_RSP -= delegate_SUB_ID_WAREHOUSE_TACTIC_SET_NAME_RSP;
        AutoGenProto.delegate_SUB_ID_WAREHOUSE_TACTIC_DOWN_ALL_RUNE_RSP -= delegate_SUB_ID_WAREHOUSE_TACTIC_DOWN_ALL_RUNE_RSP;

        AutoGenProto.delegate_SUB_ID_WAREHOUSE_TACTIC_DECOMPOSE_RSP -= delegate_SUB_ID_WAREHOUSE_TACTIC_DECOMPOSE_RSP;
        AutoGenProto.delegate_SUB_ID_WAREHOUSE_TACTIC_COMPOSE_RSP -= delegate_SUB_ID_WAREHOUSE_TACTIC_COMPOSE_RSP;
    }

    public static void Send_Page_List()
    {
        AutoGenProto.Send_SUB_ID_WAREHOUSE_TACTIC_PAGE_LSIT(0);
        AutoGenProto.Send_SUB_ID_WAREHOUSE_TACTIC_PAGE_LSIT(1);
        AutoGenProto.Send_SUB_ID_WAREHOUSE_TACTIC_PAGE_LSIT(2);
    }

    static void delegate_SUB_ID_WAREHOUSE_TACTIC_PAGE_RSP(int errorCode, byte pageIdx, byte opration, byte res)
    {
        if (res == 0)
        {
            if (opration == 1)
            {
                if (UIRune.m_instance)
                {
                    AutoGenProto.Send_SUB_ID_WAREHOUSE_TACTIC_PAGE_LSIT(pageIdx);
                }
            }
            else if (opration == 2)
            {
                Player.instance.rune.SetCurrentPage(pageIdx);
            }
        }
    }

    static void delegate_SUB_ID_WAREHOUSE_TACTIC_PAGE_LSIT_RSP(int errorCode, byte pageIdx, byte pagestate, RakNet.RakString pagename, TacticSocket[] list)
    {
        PlayerRunePage page = new PlayerRunePage();
        page.m_pageIndex = pageIdx;
        page.m_pageState = pagestate;
        page.m_pageName = pagename.ToString();
        page.m_arraySocket = list;

        Util.Log("Page: " + pageIdx + " state:  " + page.m_pageState + " " + page.m_arraySocket[0].socketitem + " " + page.m_arraySocket[1].socketitem);
        Player.instance.rune.SetPage(pageIdx, page);

        DataWrapper.ModelDispatcher.Instance.Dispatch(DataWrapper.Player.instance.rune);

        Util.Log("delegate_SUB_ID_WAREHOUSE_TACTIC_PAGE_LSIT_RSP");
    }

    static void delegate_SUB_ID_WAREHOUSE_TACTIC_UNLOCK_SOCKET_RSP(int errorCode, byte pageIdx, byte idx, byte res)
    {
        Util.Log("delegate_SUB_ID_WAREHOUSE_TACTIC_UNLOCK_SOCKET_RSP : " + idx + "  " + res);
        if (res == 0)
        {
            PlayerRunePage page = Player.instance.rune.GetPage(pageIdx);
            page.SetGrid(idx, 0);

            if (UIRune.m_instance)
            {
                UIRune.m_instance.SetGrid(pageIdx, idx, 0);
            }
        }
    }

    static void delegate_SUB_ID_WAREHOUSE_TACTIC_UP_RUNE_RSP(int errorCode, byte pageIdx, byte idx, int itemId)
    {
        Common.HideLoading();

        Util.Log("delegate_SUB_ID_WAREHOUSE_TACTIC_UP_RUNE_RSP : " + idx + "  " + itemId);
        if (itemId > 0)
        {
            PlayerRunePage page = Player.instance.rune.GetPage(pageIdx);
            page.SetGrid(idx, itemId);

            if (UIRune.m_instance)
            {
                UIRune.m_instance.m_stage.m_panelStagePage.m_dataPage = page;
                UIRune.m_instance.SetGrid(pageIdx, idx, itemId);
            }
        }
    }

    static void delegate_SUB_ID_WAREHOUSE_TACTIC_DOWN_RUNE_RSP(int errorCode, byte pageIdx, byte idx, int itemId)
    {
        Common.HideLoading();

        Util.Log("delegate_SUB_ID_WAREHOUSE_TACTIC_DOWN_RUNE_RSP : " + idx + "  " + itemId);
        //if (itemId > 0)
        {
            PlayerRunePage page = Player.instance.rune.GetPage(pageIdx);
            page.SetGrid(idx, 0);

            if (UIRune.m_instance)
            {
                UIRune.m_instance.SetGrid(pageIdx, idx, 0);
            }
        }
    }

    static void delegate_SUB_ID_WAREHOUSE_TACTIC_SET_NAME_RSP(int errorCode, byte pageIdx, byte res)
    {
        //PlayerRunePage page = Player.instance.rune.GetPage(pageIdx);
        //page.m_pageName = 
    }

    static void delegate_SUB_ID_WAREHOUSE_TACTIC_DOWN_ALL_RUNE_RSP(int errorCode, byte pageIdx, byte res)
    {
        PlayerRunePage page = Player.instance.rune.GetPage(pageIdx);
        page.UnequipAll();

        if (UIRune.m_instance)
        {
            UIRuneStagePage uiPage = UIRune.m_instance.m_stage.m_panelStagePage;
            if (uiPage.m_dataPage.m_pageIndex == pageIdx)
            {
                uiPage.SetData(page);
            }
        }
    }

    static void delegate_SUB_ID_WAREHOUSE_TACTIC_DECOMPOSE_RSP(int _errcode, byte res, uint stragypoint)
    {
        if (UIRune.m_instance)
        {
            UIRuneIllustrations illustrations = UIRune.m_instance.m_illustrations;
            if (illustrations.gameObject.activeSelf)
            {
                illustrations.UpdatePlayerData();

                UIRuneIllustrationsItemPanel illustrationsItem = illustrations.m_objItemPanel;

                if (illustrationsItem.gameObject.activeSelf)
                {
                    RuneBagItem item = illustrations.GetRuneBagItemInfo(illustrationsItem.m_runeID);
                    //if (item.GetAvailable() < 1)
                    {
                       // illustrationsItem.gameObject.SetActive(false);
                    }
                    //else
                    {
                        illustrationsItem.playEffect(true);
                        illustrationsItem.SetItemInfo(illustrations.GetRuneBagItemInfo(illustrationsItem.m_runeID));
                    }
                }
            }

            UIRuneRecommend recommend = UIRune.m_instance.m_recommend;
            if (recommend != null && recommend.gameObject.activeSelf)
            {
                UIRuneIllustrationsItemPanel illustrationsItem = illustrations.m_objItemPanel;

                if (illustrationsItem.gameObject.activeSelf)
                {
                    RuneBagItem item = UIRune.m_instance.m_recommend.m_curClickRuneBagItem.getItemInfo();

                    illustrationsItem.playEffect(true);
                    illustrationsItem.SetItemInfo(item);
                }
            }

            UIRuneIllustrationsBatchSplit batchSplit = UIRune.m_instance.m_batchSplit;
            if (batchSplit.gameObject.activeSelf)
            {
                batchSplit.UpdatePlayerData();
                batchSplit.Show();
                batchSplit.UpdatePointObtain();
            }

            string msg = string.Format(Table.Message.GetTip(4003), stragypoint);
            UIMessageBox.ShowLittleWindow(msg);
        }
    }

    static void delegate_SUB_ID_WAREHOUSE_TACTIC_COMPOSE_RSP(int _errcode, byte res)
    {
        if (UIRune.m_instance)
        {
            UIRuneIllustrations illustrations = UIRune.m_instance.m_illustrations;
            if (illustrations.gameObject.activeSelf)
            {
                illustrations.UpdatePlayerData();

                UIRuneIllustrationsItemPanel illustrationsItem = illustrations.m_objItemPanel;

                if (illustrationsItem.gameObject.activeSelf)
                    illustrationsItem.SetItemInfo(illustrations.GetRuneBagItemInfo(illustrationsItem.m_runeID));

                illustrationsItem.playEffect(false);

                string msg = string.Format(Table.Message.GetTip(4006), Table.Item.GetName(Table.Strategy.GetITEMID(illustrationsItem.m_runeID)));
                UIMessageBox.ShowLittleWindow(msg);
            }

            UIRuneRecommend recommend = UIRune.m_instance.m_recommend;
            if (recommend != null && recommend.gameObject.activeSelf)
            {
                UIRuneIllustrationsItemPanel illustrationsItem = illustrations.m_objItemPanel;

                if (illustrationsItem.gameObject.activeSelf)
                {
                    RuneBagItem item = UIRune.m_instance.m_recommend.m_curClickRuneBagItem.getItemInfo();
                    illustrationsItem.SetItemInfo(item);
                    illustrationsItem.playEffect(false);
                }

                string msg = string.Format(Table.Message.GetTip(4006), Table.Item.GetName(Table.Strategy.GetITEMID(illustrationsItem.m_runeID)));
                UIMessageBox.ShowLittleWindow(msg);
            }
        }
    }

    //断线重连后，数据同步调用方法 by shilongquan
    public void OnDataUpdate()
    {

    }
}
