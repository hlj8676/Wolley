using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DataWrapper;

public class UserTeamGroupHandle:SuperBOBO.NetInterface
{
    private void Delegate_SUB_ID_TANK_SETTING_RSP(int errorCode, byte curSelectTankSetIdx, TankSetting[] list)
    {
        Player.instance.teamGroup.clearTeamGroupData();

        Player.instance.teamGroup.curSelectTeamGroupId = 0;//curSelectTankSetIdx;

        foreach (var k in list)
        {
            PlayerTeamGroup.TeamGroupData teamGroupData = new PlayerTeamGroup.TeamGroupData();

            teamGroupData.settingIdx = k.settingIdx;
            teamGroupData.tankId = k.tankId;
            teamGroupData.pilotAId = k.pilotAId;
            teamGroupData.pilotBId = k.pilotBId;
            teamGroupData.pilotCId = k.pilotCId;
            teamGroupData.pilotDId = k.pilotDId;
            teamGroupData.pilotEId = k.pilotEId;
            teamGroupData.professorId = k.professorId;

            Player.instance.teamGroup.addTeamGroupData(teamGroupData);
        }

        PlayerTeamGroup.TeamGroupData m_teamGroupData = DataWrapper.Player.instance.getCurBattleTeamGroupData();

        if (m_teamGroupData != null && m_teamGroupData.tankId != 0)
        {
            PlayerTank tankData = DataWrapper.Player.instance.teamGroup.getTankData(m_teamGroupData.tankId);

            if (tankData != null)
            {
                DataWrapper.Player.instance.currentSelectedTank = tankData;
            }
        }
    }

    public void OnRegister()
    {
        AutoGenProto.delegate_SUB_ID_TANK_SETTING_RSP += Delegate_SUB_ID_TANK_SETTING_RSP;
    }

    public void OnUnRegister()
    {
        AutoGenProto.delegate_SUB_ID_TANK_SETTING_RSP -= Delegate_SUB_ID_TANK_SETTING_RSP;
    }

    //断线重连后，数据同步调用方法 by shilongquan
    public void OnDataUpdate()
    {

    }
}
