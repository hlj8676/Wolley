//using network.message;
using UnityEngine;
using XLua;



// lua访问的类都加上 LuaCallCSharp,生成代理代码,避免使用反射
public class LuaMain : LuaMainBase
{

	//private ILuaUiManager uiManager;
	//private ILuaWorldGuiManager worldGui;
	private LuaMainValue luaMainValue;


	/// <summary>
	/// 初始化lua运行环境
	/// </summary>
	public LuaMainValue InitLuaEnv()
	{
		InitCodePath();
		//luaenv.Global.Set("game", new GameMethod());
		//luaenv.Global.Set("dataManager", MainValue.mxDataManager);
		//luaenv.Global.Set("dbManager", MainValue.mxCSVManager);
		//luaenv.Global.Set("analysis", Analysis.Intance);
		//luaenv.Global.Set("sixwaves", SixWaves.Intance);

		luaenv.DoString("require 'LuaMain'");

		luaMainValue = luaenv.Global.Get<LuaMainValue>("MainValue");
		//uiManager = luaMainValue.GetUIManager();
		//ShowMemory();
		return luaMainValue;
	}




	#region event

	public void InitLuaEvent()
	{
		//MainValue.mxDataManager.HostUserInfoData.OnLoginResult += luaMainValue.OnLoginResult;
		//MainValue.mxDataManager.HostUserInfoData.OnPowerUpdateNtf += luaMainValue.OnPowerUpdate;
		//MainValue.mxDataManager.HostUserInfoData.OnSearchUser += luaMainValue.OnSearchUser;
		//MainValue.mxDataManager.HostUserInfoData.OnSetUserNationalFlagResponse += luaMainValue.OnSetUserNationalFlagResponse;





		//MainValue.mxDataManager.BuildingData.OnBuildingBegin += luaMainValue.OnBuildingBegin;
		//MainValue.mxDataManager.BuildingData.OnBuildingLevelUp += luaMainValue.OnBuildingLevelUp;
		//MainValue.mxDataManager.BuildingData.OnBuildingComplete += luaMainValue.OnBuildingComplete;
		//MainValue.mxDataManager.BuildingData.OnBuildingInfoList += luaMainValue.OnBuildingInfoList;
		//MainValue.mxDataManager.BuildingData.OnBuildingProgInfoList += luaMainValue.OnBuildingProgInfoList;
		//MainValue.mxDataManager.BuildingData.OnWaitInfoList += luaMainValue.OnWaitInfoList;
		//MainValue.mxDataManager.BuildingData.OnBuildUpdateNtf += luaMainValue.OnBuildUpdateNtf;
		//MainValue.mxDataManager.BuildingData.OnBuildingRemove += luaMainValue.OnBuildingRemove;
		//MainValue.mxDataManager.BuildingData.OnBuildingCancel += luaMainValue.OnBuildingCancel;
		//MainValue.mxDataManager.BuildingData.OnBuildingHarvest += luaMainValue.OnBuildingHarvest;
		//MainValue.mxDataManager.BuildingData.OnHarvestChest += luaMainValue.OnHarvestChest;
		//MainValue.mxDataManager.BuildingData.OnBuildingFreeResponse += luaMainValue.OnBuildingFreeResponse;
		//MainValue.mxDataManager.BuildingData.OnBuildingFreeInfoNtf += luaMainValue.OnBuildingFreeInfoNtf;
		//MainValue.mxDataManager.BuildingData.OnBuildingUnlockResponse += luaMainValue.OnBuildingUnlockResponse;


		//MainValue.mxDataManager.MapDataGrid.CityDictAction += luaMainValue.OnCityList;

		//MainValue.mxDataManager.TaskData.TaskComplete += luaMainValue.OnTaskComplete;
		//MainValue.mxDataManager.TaskData.OnGetReward += luaMainValue.OnGetReward;
		//MainValue.mxDataManager.TaskData.OnTaskGetDailyList += luaMainValue.OnTaskGetDailyList;
		//MainValue.mxDataManager.TaskData.OnTaskBeginDaily += luaMainValue.OnTaskBeginDaily;
		//MainValue.mxDataManager.TaskData.OnTaskGetDailyReward += luaMainValue.OnTaskGetDailyReward;
		//MainValue.mxDataManager.TaskData.OnTaskUpdateNtf += luaMainValue.OnTaskUpdateNtf;
		//MainValue.mxDataManager.TaskData.OnDailyEventNtf += luaMainValue.OnDailyEventNtf;
		//MainValue.mxDataManager.TaskData.OnDailyEventGetRewardNtf += luaMainValue.OnDailyEventGetRewardNtf;


		//MainValue.mxDataManager.ResourceData.OnResource += luaMainValue.OnResourceData;

		//MainValue.mxDataManager.ItemData.OnUseItem += luaMainValue.OnUseItem;
		//MainValue.mxDataManager.ItemData.OnItemSpeedup += luaMainValue.OnItemSpeedup;
		//MainValue.mxDataManager.ItemData.OnItemUserNtf += luaMainValue.OnItemUserNtf;
		//MainValue.mxDataManager.ItemData.OnItemUpdateNtf += luaMainValue.OnItemUpdateNtf;
		//MainValue.mxDataManager.ItemData.OnItemBuy += luaMainValue.OnItemBuy;

		//MainValue.mxDataManager.DefenseData.OnGarrisonTotalTroops += luaMainValue.OnGarrisonTotalTroops;
		//MainValue.mxDataManager.DefenseData.OnGarrisonProgInfo += luaMainValue.OnGarrisonProgInfo;
		//MainValue.mxDataManager.DefenseData.OnGarrisonTrainCancelResponse += luaMainValue.OnGarrisonTrainCancelResponse;

		//MainValue.mxDataManager.TroopData.OnTroopTrain += luaMainValue.OnTroopTrain;

		//MainValue.mxDataManager.TroopData.OnTotalTroops += luaMainValue.OnTroopsTotal;
		//MainValue.mxDataManager.TroopData.OnCityTroopss += luaMainValue.OnTroopsCity;
		//MainValue.mxDataManager.TroopData.OnTroopProgs += luaMainValue.OnTroopProgs;
		//MainValue.mxDataManager.TroopData.OnTroopWaitings += luaMainValue.OnTroopWaitings;
		//MainValue.mxDataManager.TroopData.OnTroopDissmiss += luaMainValue.OnTroopDissmiss;
		//MainValue.mxDataManager.TroopData.OnTroopTrainCancel += luaMainValue.OnTroopTrainCancel;


		//MainValue.mxDataManager.ResearchData.ResearchBaseInfoListAction += luaMainValue.OnResearchBaseInfoList;
		//MainValue.mxDataManager.ResearchData.ResearchUpgradeNtfAction += luaMainValue.OnResearchUpgradeNtf;
		//MainValue.mxDataManager.ResearchData.ResearchDetailInfoAction += luaMainValue.OnResearchDetailInfo;
		//MainValue.mxDataManager.ResearchData.ResearchBaseInfoAction += luaMainValue.OnResearchBaseInfo;
		//MainValue.mxDataManager.ResearchData.OnResearchUpgrade += luaMainValue.OnResearchUpgrade;
		//MainValue.mxDataManager.ResearchData.OnResearchCancel += luaMainValue.OnResearchCancel;
		//MainValue.mxDataManager.ResearchData.OnResearchCompleteNtf += luaMainValue.OnResearchCompleteNtf;


		//MainValue.mxDataManager.PlayerUserInfoData.UserInfoAction += luaMainValue.OnUserInfo;
		//MainValue.mxDataManager.PlayerUserInfoData.OnRankInfosAction += luaMainValue.OnRankInfos;


		//MainValue.mxDataManager.Hero.OnHeroLevel += luaMainValue.OnHeroLevel;
		//MainValue.mxDataManager.Hero.OnHeroInfo += luaMainValue.OnHeroInfo;
		//MainValue.mxDataManager.Hero.OnHeroMode += luaMainValue.OnHeroMode;
		//MainValue.mxDataManager.Hero.OnHeroView += luaMainValue.OnHeroView;
		//MainValue.mxDataManager.Hero.OnHeroEmploy += luaMainValue.OnHeroEmploy;
		//MainValue.mxDataManager.Hero.OnHeroTalentPageSelect += luaMainValue.OnHeroTalentPageSelect;
		//MainValue.mxDataManager.Hero.OnHeroTalentGetList += luaMainValue.OnHeroTalentGetList;
		//MainValue.mxDataManager.Hero.OnHeroTalent += luaMainValue.OnHeroTalent;
		//MainValue.mxDataManager.Hero.OnHeroTalentPointsInfo += luaMainValue.OnHeroTalentPointsInfo;
		//MainValue.mxDataManager.Hero.OnHeroTalentUpgrade += luaMainValue.OnHeroTalentUpgrade;
		//MainValue.mxDataManager.Hero.OnHeroTalentReset += luaMainValue.OnHeroTalentReset;
		//MainValue.mxDataManager.Hero.OnHeroEquipInfo += luaMainValue.OnHeroEquipInfo;
		//MainValue.mxDataManager.Hero.OnHeroSkillUnlockResponse += luaMainValue.OnHeroSkillUnlockResponse;
		//MainValue.mxDataManager.Hero.OnHeroSkillUpgradeResponse += luaMainValue.OnHeroSkillUpgradeResponse;
		//MainValue.mxDataManager.Hero.OnHeroModelCombineResponse += luaMainValue.OnHeroModelCombineResponse;







		//MainValue.mxDataManager.RecruitHallData.OnRecruitHallInfo += luaMainValue.OnRecruitHallInfo;
		//MainValue.mxDataManager.RecruitHallData.OnOfficerRecruit += luaMainValue.OnOfficerRecruit;
		//MainValue.mxDataManager.RecruitHallData.OnOfficerUpgradeStar += luaMainValue.OnOfficerUpgradeStar;
		//MainValue.mxDataManager.RecruitHallData.OnOfficerShow += luaMainValue.OnOfficerShow;
		//MainValue.mxDataManager.RecruitHallData.OnOfficeShowInfo += luaMainValue.OnOfficeShowInfo;
		//MainValue.mxDataManager.RecruitHallData.OnOfficerEquip += luaMainValue.OnOfficerEquip;
		//MainValue.mxDataManager.RecruitHallData.OnOfficerRemove += luaMainValue.OnOfficerRemove;
		//MainValue.mxDataManager.RecruitHallData.OnOfficerUpdate += luaMainValue.OnOfficerUpdate;
		//MainValue.mxDataManager.RecruitHallData.OnOfficerNew += luaMainValue.OnOfficerNew;
		//MainValue.mxDataManager.RecruitHallData.OnOfficerResolve += luaMainValue.OnOfficerResolve;
		//MainValue.mxDataManager.RecruitHallData.OnMedalCombine += luaMainValue.OnMedalCombine;
		//MainValue.mxDataManager.RecruitHallData.OnMedalUse += luaMainValue.OnMedalUse;
		//MainValue.mxDataManager.RecruitHallData.OnMedalRemove += luaMainValue.OnMedalRemove;
		//MainValue.mxDataManager.RecruitHallData.OnOfficerDecompositionResponse += luaMainValue.OnOfficerDecompositionResponse;

		//MainValue.mxDataManager.BuffData.OnBuffList += luaMainValue.OnBuffList;
		//MainValue.mxDataManager.BuffData.OnBuffUpdate += luaMainValue.OnBuffUpdate;
		//MainValue.mxDataManager.BuffData.OnHeroBuffList += luaMainValue.OnHeroBuffList;
		//MainValue.mxDataManager.BuffData.OnHeroBuff += luaMainValue.OnHeroBuff;

		//MainValue.mxDataManager.MailData.OnGetMailList += luaMainValue.OnGetMailList;
		//MainValue.mxDataManager.MailData.OnNewMailNtf += luaMainValue.OnNewMailNtf;
		//MainValue.mxDataManager.MailData.OnUnreadMailCountNtf += luaMainValue.OnUnreadMailCountNtf;
		//MainValue.mxDataManager.MailData.OnCreateMail += luaMainValue.OnCreateMail;
		//MainValue.mxDataManager.MailData.OnCreateMailByName += luaMainValue.OnCreateMailByName;
		//MainValue.mxDataManager.MailData.OnDeleteMail += luaMainValue.OnDeleteMail;
		//MainValue.mxDataManager.MailData.OnMarkMailReaded += luaMainValue.OnMarkMailReaded;
		//MainValue.mxDataManager.MailData.OnSaveMail += luaMainValue.OnSaveMail;
		//MainValue.mxDataManager.MailData.OnReadMail += luaMainValue.OnReadMail;
		//MainValue.mxDataManager.MailData.OnGetRewardList += luaMainValue.OnReadOnGetRewardListMail;
		//MainValue.mxDataManager.MailData.OnGetPrizeCurr += luaMainValue.OnGetPrizeCurr;
		
		//MainValue.mxDataManager.MailData.OnGetPrize += luaMainValue.OnGetPrize;
		//MainValue.mxDataManager.MailData.OnPrizeInfo += luaMainValue.OnPrizeInfo;

		//MainValue.mxDataManager.MailData.OnGetManoeuvreReportListResponse += luaMainValue.OnGetManoeuvreReportListResponse;


		//MainValue.mxDataManager.HostUserInfoData.OnRename += luaMainValue.OnRename;

		//// 雷达数据
		//MainValue.mxDataManager.MapAlertData.OnBeScoutInfoList += luaMainValue.OnBeScoutInfoList;
		//MainValue.mxDataManager.MapAlertData.OnBeAtkInfoList += luaMainValue.OnBeAtkInfoList;
		//MainValue.mxDataManager.MapAlertData.OnBeCollisionInfoList += luaMainValue.OnBeCollisionInfoList;

		////集结攻击NTF
		//MainValue.mxDataManager.MapAlertData.OnRallyAlertNtf += luaMainValue.OnRallyAlertNtf;
		//MainValue.mxDataManager.MapAlertData.OnRallyDefenceAlertNtf += luaMainValue.OnRallyDefenceAlertNtf;
		////雷达集合的消息
		//MainValue.mxDataManager.MapAlertData.OnRadarNtf += luaMainValue.OnRadarNtf;


		//// 行军队列数量
		//MainValue.mxDataManager.DataMapUserNtf.OnCurrentMarchCount += luaMainValue.OnCurrentMarchCountFunction;

		//MainValue.mxDataManager.ChestData.OnChestGetReward += luaMainValue.OnChestGetReward;
		//MainValue.mxDataManager.ChestData.OnChestNtf += luaMainValue.OnChestNtf;

		//MainValue.mxDataManager.RepairData.OnRepair += luaMainValue.OnRepair;
		//MainValue.mxDataManager.RepairData.OnRepairNtf += luaMainValue.OnRepairNtf;
		//MainValue.mxDataManager.RepairData.OnRepairTroopNtf += luaMainValue.OnRepairTroopNtf;

		//MainValue.mxDataManager.PayData.OnGetIapList += luaMainValue.OnGetIapList;
		//MainValue.mxDataManager.PayData.OnIapFinish += luaMainValue.OnIapFinish;

		//MainValue.mxDataManager.VipData.OnVipNtf += luaMainValue.OnVipNtf;
		//MainValue.mxDataManager.VipData.OnVipLevelUpNtf += luaMainValue.OnVipLevelUpNtf;

		//MainValue.mxDataManager.EventData.OnEventListNtf += luaMainValue.OnEventListNtf;
		//MainValue.mxDataManager.EventData.OnEventNtf += luaMainValue.OnEventNtf;
		//MainValue.mxDataManager.EventData.OnEventDetail += luaMainValue.OnEventDetail;

		//MainValue.mxDataManager.EventData.OnEventRankListResponse += luaMainValue.OnEventRankListResponse;
		//MainValue.mxDataManager.EventData.OnEventLastListResponse += luaMainValue.OnEventLastListResponse;





		///**  联盟   */
		//// 创建联盟
		//MainValue.mxDataManager.AllianceData.OnCreateAlliance += luaMainValue.OnCreateAlliance;
		//// 联盟推荐列表响应
		//MainValue.mxDataManager.AllianceData.OnAllianceListResponse += luaMainValue.OnAllianceListResponse;
		//// 玩家加入联盟请求
		//MainValue.mxDataManager.AllianceData.OnJoinAllianceResponse += luaMainValue.OnJoinAllianceResponse;
		//// 入会申请通知
		//MainValue.mxDataManager.AllianceData.OnAllianceJoinApplyNtf += luaMainValue.OnAllianceJoinApplyNtf;
		//// 加入公会广播通知
		//MainValue.mxDataManager.AllianceData.OnJoinAllianceNtf += luaMainValue.OnJoinAllianceNtf;
		//// 退出公会广播通知 
		//MainValue.mxDataManager.AllianceData.OnQuitAllianceNtf += luaMainValue.OnQuitAllianceNtf;
		//// 搜索联盟
		//MainValue.mxDataManager.AllianceData.OnSearchAllianceResponse += luaMainValue.OnSearchAllianceResponse;
		//// 个人退出联盟
		//MainValue.mxDataManager.AllianceData.OnQuitAllianceResponseNtf += luaMainValue.OnQuitAllianceResponseNtf;
		////修改联盟头衔
		//MainValue.mxDataManager.AllianceData.OnAllianceMemberTitleNtf += luaMainValue.OnAllianceMemberTitleNtf;
		////修改联盟头衔通知
		//MainValue.mxDataManager.AllianceData.OnUpdateAllianceMemberTitleNtf += luaMainValue.OnUpdateAllianceMemberTitleNtf;
		////解散联盟回调
		//MainValue.mxDataManager.AllianceData.OnDismissAllianceResponse += luaMainValue.OnDismissAllianceResponse;
		////解散联盟通知
		//MainValue.mxDataManager.AllianceData.OnDismissAllianceNtf += luaMainValue.OnDismissAllianceNtf;
		////联盟打开宝箱响应
		//MainValue.mxDataManager.AllianceData.OnOpenAllianceGiftResponse += luaMainValue.OnOpenAllianceGiftResponse;
		////获取宝箱list
		//MainValue.mxDataManager.AllianceData.OnListAllianceGiftResponse += luaMainValue.OnListAllianceGiftResponse;

		////收到联盟宝箱通知，center直接发给client的*
		//MainValue.mxDataManager.AllianceData.OnReceiveAllianceGiftNtf += luaMainValue.OnReceiveAllianceGiftNtf;
		////宝箱等级公会广播通知*
		//MainValue.mxDataManager.AllianceData.OnAllianceGiftLevelNtf += luaMainValue.OnAllianceGiftLevelNtf;


		//MainValue.mxDataManager.AllianceData.OnAllianceOfferHelpResponse += luaMainValue.OnAllianceOfferHelpResponse;
		//MainValue.mxDataManager.AllianceData.OnAllianceHelpResponse += luaMainValue.OnAllianceHelpResponse;
		//MainValue.mxDataManager.AllianceData.OnAllianceHelpNtf += luaMainValue.OnAllianceHelpNtf;
		//MainValue.mxDataManager.AllianceData.OnAllianceOfferHelpNtf += luaMainValue.OnAllianceOfferHelpNtf;
		//MainValue.mxDataManager.AllianceData.OnAllianceDeleteHelpNtf += luaMainValue.OnAllianceDeleteHelpNtf;
		//MainValue.mxDataManager.AllianceData.OnAllianceUpdateHelpNtf += luaMainValue.OnAllianceUpdateHelpNtf;
		//MainValue.mxDataManager.AllianceData.OnAllianceListHelpResponse += luaMainValue.OnAllianceListHelpResponse;
		//MainValue.mxDataManager.AllianceData.OnAllianceOfferHelpAllResponse += luaMainValue.OnAllianceOfferHelpAllResponse;
		//MainValue.mxDataManager.AllianceData.OnAllianceModRankResponse += luaMainValue.OnAllianceModRankResponse;
		//MainValue.mxDataManager.AllianceData.OnAllianceModRankNtf += luaMainValue.OnAllianceModRankNtf;
		//// 修改联盟权限响应 */
		//MainValue.mxDataManager.AllianceData.OnUpdateAllianceAuthorityResponse += luaMainValue.OnUpdateAllianceAuthorityResponse;
		//// ct联盟权限改变通知client */
		//MainValue.mxDataManager.AllianceData.OnUpdateAllianceAuthorityNtf += luaMainValue.OnUpdateAllianceAuthorityNtf;
		//// 联盟成员
		//MainValue.mxDataManager.AllianceData.OnAllianceMemberResponse += luaMainValue.OnAllianceMemberResponse;
		//MainValue.mxDataManager.AllianceData.OnChangeAllianceNameResponse += luaMainValue.OnChangeAllianceNameResponse;

		//MainValue.mxDataManager.AllianceData.OnAllianceLevelInfoResponse += luaMainValue.OnAllianceLevelInfoResponse;
		//MainValue.mxDataManager.AllianceData.OnAllianceDonateResponse += luaMainValue.OnAllianceDonateResponse;

		//MainValue.mxDataManager.AllianceData.OnAllianceDonateHistoryResponse += luaMainValue.OnAllianceDonateHistoryResponse;
		//MainValue.mxDataManager.AllianceData.OnAllianceResApplyNtf += luaMainValue.OnAllianceResApplyNtf;
		//MainValue.mxDataManager.AllianceData.OnManageAllianceResApplyResponse += luaMainValue.OnManageAllianceResApplyResponse;


		////联盟领土列表响应
		//MainValue.mxDataManager.AllianceData.OnListAllianceDominionResponse += luaMainValue.OnListAllianceDominionResponse;
		//MainValue.mxDataManager.AllianceData.OnChangeAllianceAbbrResponse += luaMainValue.OnChangeAllianceAbbrResponse;
		//MainValue.mxDataManager.AllianceData.OnChangeAllianceLogoResponse += luaMainValue.OnChangeAllianceLogoResponse;
		//MainValue.mxDataManager.AllianceData.OnChangeAllianceLangResponse += luaMainValue.OnChangeAllianceLangResponse;
		//MainValue.mxDataManager.AllianceData.OnChangeAllianceDescResponse += luaMainValue.OnChangeAllianceDescResponse;
		//MainValue.mxDataManager.AllianceData.OnUpdateAllianceBriefNtf += luaMainValue.OnUpdateAllianceBriefNtf;
		//MainValue.mxDataManager.AllianceData.OnAllianceResHistoryNtf += luaMainValue.OnAllianceResHistoryNtf;
		//MainValue.mxDataManager.AllianceData.OnAllianceResUpdateNtf += luaMainValue.OnAllianceResUpdateNtf;
		//MainValue.mxDataManager.AllianceData.OnAllianceResListNtf += luaMainValue.OnAllianceResListNtf;
		//MainValue.mxDataManager.AllianceData.OnListAllianceResApplyNtf += luaMainValue.OnListAllianceResApplyNtf;


		//MainValue.mxDataManager.MapDataGrid.CapitalDetailInfoAction += luaMainValue.OnCapitalDetailInfo;


		//MainValue.mxDataManager.AllianceData.OnAllianceResApplyResultNtf += luaMainValue.OnAllianceResApplyResultNtf;
		//MainValue.mxDataManager.AllianceData.OnAllianceResApplyResponse += luaMainValue.OnAllianceResApplyResponse;
		//MainValue.mxDataManager.AllianceData.OnAllianceResApplyCancelResponse += luaMainValue.OnAllianceResApplyCancelResponse;
		//MainValue.mxDataManager.AllianceData.OnDelAllianceResApplyNtf += luaMainValue.OnDelAllianceResApplyNtf;





		//MainValue.mxDataManager.DataMapUserNtf.OnFormationStyleInfo += luaMainValue.OnFormationStyleInfo;
		//MainValue.mxDataManager.DataMapUserNtf.OnSetFormationStyleResult += luaMainValue.OnSetFormationStyleResult;


		////黑市
		//MainValue.mxDataManager.BlackmarketData.OnBlackmarket += luaMainValue.OnBlackmarket;
		//MainValue.mxDataManager.BlackmarketData.OnBlackmarketRefresh += luaMainValue.OnBlackmarketRefresh;
		//MainValue.mxDataManager.BlackmarketData.OnBlackmarketBuyItem += luaMainValue.OnBlackmarketBuyItem;

		//// 集结防御
		//MainValue.mxDataManager.RallyDataNtf.OnResponse_RallyAtkListNtf += luaMainValue.OnResponse_RallyAtkListNtf;
		//MainValue.mxDataManager.RallyDataNtf.OnResponse_RallyDefListNtf += luaMainValue.OnResponse_RallyDefListNtf;
		////集结
		//MainValue.mxDataManager.RallyDataNtf.OnResponse_RallyListNtf += luaMainValue.OnResponse_RallyListNtf;
		//MainValue.mxDataManager.RallyDataNtf.OnResponse_RallyList += luaMainValue.OnResponse_RallyList;

		////活动
		//MainValue.mxDataManager.ActivityData.OnActivityFistPayNtf += luaMainValue.OnActivityFistPayNtf;
		//MainValue.mxDataManager.ActivityData.OnActivityUnlimitedNtf += luaMainValue.OnActivityUnlimitedNtf;
		//MainValue.mxDataManager.ActivityData.OnCollectActFistPayResponse += luaMainValue.OnCollectActFistPayResponse;
		//MainValue.mxDataManager.ActivityData.OnCollectActHeroLevelResponse += luaMainValue.OnCollectActHeroLevelResponse;
		//MainValue.mxDataManager.ActivityData.OnCollectActPowerResponse += luaMainValue.OnCollectActPowerResponse;

		//MainValue.mxDataManager.ActivityData.OnCollectActSevenDaysResponse += luaMainValue.OnCollectActSevenDaysResponse;
		//MainValue.mxDataManager.ActivityData.OnMonthSinginResponse += luaMainValue.OnMonthSinginResponse;
		//MainValue.mxDataManager.ActivityData.OnCollectCumulativeResponse += luaMainValue.OnCollectCumulativeResponse;

		//MainValue.mxDataManager.ActivityData.OnGachaResponse += luaMainValue.OnGachaResponse;
		//MainValue.mxDataManager.ActivityData.OnGachaNtf += luaMainValue.OnGachaNtf;
		//MainValue.mxDataManager.ActivityData.OnGachaGetiamondBoxResponse += luaMainValue.OnGachaGetiamondBoxResponse;
		//MainValue.mxDataManager.ActivityData.OnGachaGetCashBoxResponse += luaMainValue.OnGachaGetCashBoxResponse;
		//MainValue.mxDataManager.ActivityData.OnGachaDiamondResponse += luaMainValue.OnGachaDiamondResponse;
		//MainValue.mxDataManager.ActivityData.OnGachaCashResponse += luaMainValue.OnGachaCashResponse;

		//MainValue.mxDataManager.ActivityData.OnFundBuyResponse += luaMainValue.OnFundBuyResponse;
		//MainValue.mxDataManager.ActivityData.OnFundCollectResponse += luaMainValue.OnFundCollectResponse;
		//MainValue.mxDataManager.ActivityData.OnDailyTargetGetRewardResponse += luaMainValue.OnDailyTargetGetRewardResponse;
		//MainValue.mxDataManager.ActivityData.OnDailyTargetShopResponse += luaMainValue.OnDailyTargetShopResponse;
		//MainValue.mxDataManager.ActivityData.OnCardCollectResponse += luaMainValue.OnCardCollectResponse;
		

		//MainValue.mxDataManager.ChatManager.OnChatDataNtf += luaMainValue.OnChatDataNtf;
		//MainValue.mxDataManager.ChatManager.OnChatTokenNtf += luaMainValue.OnChatTokenNtf;

		//MainValue.mxDataManager.ChatManager.OnLoginChatServerResponse += luaMainValue.OnLoginChatServerResponse;
		//MainValue.mxDataManager.ChatManager.OnChatMessageNtf += luaMainValue.OnChatMessageNtf;
		//MainValue.mxDataManager.ChatManager.OnChatMessageResponse += luaMainValue.OnChatMessageResponse;
		//MainValue.mxDataManager.ChatManager.OnChatAnnounceNtf += luaMainValue.OnChatAnnounceNtf;
		//MainValue.mxDataManager.ChatManager.OnChatMoreMessageResponse += luaMainValue.OnChatMoreMessageResponse;



		////屏幕位置委托
		//MainValue.mxDataManager.ObserverData.ScreenCenterPstAction += luaMainValue.OnSetPstValue;

		//MainValue.mxDataManager.DataUserstatis.OnUserStatisticsResponse += luaMainValue.OnUserStatisticsResponse;
		//MainValue.mxDataManager.MapPveData.OnFindNearestElement += luaMainValue.OnFindNearestElement;
		//MainValue.mxDataManager.MapPveData.OnRefreshNearestElement += luaMainValue.OnRefreshNearestElement;

		//MainValue.mxDataManager.MarchData.OnMarchNtf += luaMainValue.OnNewMarchNtf;
		//MainValue.mxDataManager.MarchData.OnMarchCompleteNtf += luaMainValue.OnMarchCompleteNtf;

		//MainValue.mxDataManager.ManoeuverData.OnGetManoeuvreInfo += luaMainValue.OnGetManoeuvreInfo;

		//MainValue.mxDataManager.ManoeuverData.OnManoeuvreSwitchNtf += luaMainValue.OnManoeuvreSwitchNtf;

		//MainValue.mxDataManager.ManoeuverData.OnGetManoeuvreMatch += luaMainValue.OnGetManoeuvreMatch;
		//MainValue.mxDataManager.ManoeuverData.OnGetGlobalManoeuvre += luaMainValue.OnGetGlobalManoeuvre;
		//MainValue.mxDataManager.ManoeuverData.OnGetManoeuvreRank += luaMainValue.OnGetManoeuvreRank;
		//MainValue.mxDataManager.ManoeuverData.OnGetManoeuvreInfoUpdateNtf += luaMainValue.OnGetManoeuvreInfoUpdateNtf;
		//MainValue.mxDataManager.ManoeuverData.OnGetManoeuvreSetStyleRespons += luaMainValue.OnGetManoeuvreSetStyleRespons;

		//MainValue.mxDataManager.ManoeuverShopData.OnManoeuvreShopNtf += luaMainValue.OnManoeuvreShopNtf;

		//MainValue.mxDataManager.ManoeuverShopData.OnGetManoeuvreShopInfoResponse += luaMainValue.OnGetManoeuvreShopInfoResponse;
		//MainValue.mxDataManager.ManoeuverShopData.OnRefreshManoeuvreShopResponse += luaMainValue.OnRefreshManoeuvreShopResponse;
		//MainValue.mxDataManager.ManoeuverShopData.OnManoeuvreShopBuyItemResponse += luaMainValue.OnManoeuvreShopBuyItemResponse;








		//MainValue.mxDataManager.PveData.OnPveStartLevelResponse += luaMainValue.OnPveStartLevelResponse;
		//MainValue.mxDataManager.PveData.OnPveOpenChapterBoxResponse += luaMainValue.OnPveOpenChapterBoxResponse;
		//MainValue.mxDataManager.PveData.OnPveSetStyleResponse += luaMainValue.OnPveSetStyleResponse;
		////		MainValue.mxDataManager.PveData.OnPveGetStyleResponse += luaMainValue.OnPveGetStyleResponse;

		//MainValue.mxDataManager.PveData.OnPveWipeOutResponse += luaMainValue.OnPveWipeOutResponse;

		//MainValue.mxDataManager.ManoeuverData.OnManoeuvreBuyChallengeTimesResponse += luaMainValue.OnManoeuvreBuyChallengeTimesResponse;

		//MainValue.mxDataManager.FtueData.OnNewbieGuideNtf += luaMainValue.OnNewbieGuideNtf;
		//MainValue.mxDataManager.FtueData.OnNewbieGuideProgResponse += luaMainValue.OnNewbieGuideProgResponse;
		//MainValue.mxDataManager.FtueData.OnNewbieGuideEventResponse += luaMainValue.OnNewbieGuideEventResponse;
		//MainValue.mxDataManager.FtueData.OnNewbieGuideSkipResponse += luaMainValue.OnNewbieGuideSkipResponse;




		//MainValue.mxDataManager.CapitalData.OnCapitalTroopInfo += luaMainValue.OnCapitalTroopInfo;
		//MainValue.mxDataManager.CapitalData.OnCapitalsOccupyInfo += luaMainValue.OnCapitalsOccupyInfo;

		//MainValue.mxDataManager.ScrollData.OnScrollTextNtf += luaMainValue.OnScrollTextNtf;

		//MainValue.mxDataManager.HuoDongData.OnHuodongGetBriefListResponse += luaMainValue.OnHuodongGetBriefListResponse;
		//MainValue.mxDataManager.HuoDongData.OnHuodongGetDetailResponse += luaMainValue.OnHuodongGetDetailResponse;
		//MainValue.mxDataManager.HuoDongData.OnHuodongBriefListNtf += luaMainValue.OnHuodongBriefListNtf;
		//MainValue.mxDataManager.HuoDongData.OnHuodongGetPrizeResponse += luaMainValue.OnHuodongGetPrizeResponse;




		//MainValue.mxDataManager.CapitalData.OnCapitalBattleRecordResponse += luaMainValue.OnCapitalBattleRecordResponse;
		//MainValue.mxDataManager.CapitalData.OnCapitalSetTaxResponse += luaMainValue.OnCapitalSetTaxResponse;


		//MainValue.mxDataManager.RankingData.OnUserRankListResponse += luaMainValue.OnUserRankListResponse;
		//MainValue.mxDataManager.RankingData.OnDetailRankListResponse += luaMainValue.OnDetailRankListResponse;
		//MainValue.mxDataManager.RankingData.OnAllianceRankListResponse += luaMainValue.OnAllianceRankListResponse;
		//MainValue.mxDataManager.RankingData.OnUserRankInfoNtf += luaMainValue.OnUserRankInfoNtf;




	}


	public void UnInitLuaEvent()
	{
		//MainValue.mxDataManager.HostUserInfoData.OnLoginResult -= luaMainValue.OnLoginResult;
		//MainValue.mxDataManager.HostUserInfoData.OnPowerUpdateNtf -= luaMainValue.OnPowerUpdate;
		//MainValue.mxDataManager.HostUserInfoData.OnSearchUser -= luaMainValue.OnSearchUser;
		//MainValue.mxDataManager.HostUserInfoData.OnSetUserNationalFlagResponse -= luaMainValue.OnSetUserNationalFlagResponse;

		//MainValue.mxDataManager.BuildingData.OnBuildingBegin -= luaMainValue.OnBuildingBegin;
		//MainValue.mxDataManager.BuildingData.OnBuildingLevelUp -= luaMainValue.OnBuildingLevelUp;
		//MainValue.mxDataManager.BuildingData.OnBuildingComplete -= luaMainValue.OnBuildingComplete;
		//MainValue.mxDataManager.BuildingData.OnBuildingInfoList -= luaMainValue.OnBuildingInfoList;
		//MainValue.mxDataManager.BuildingData.OnBuildingProgInfoList -= luaMainValue.OnBuildingProgInfoList;
		//MainValue.mxDataManager.BuildingData.OnWaitInfoList -= luaMainValue.OnWaitInfoList;
		//MainValue.mxDataManager.BuildingData.OnBuildUpdateNtf -= luaMainValue.OnBuildUpdateNtf;
		//MainValue.mxDataManager.BuildingData.OnBuildingRemove -= luaMainValue.OnBuildingRemove;
		//MainValue.mxDataManager.BuildingData.OnBuildingCancel -= luaMainValue.OnBuildingCancel;
		//MainValue.mxDataManager.BuildingData.OnBuildingHarvest -= luaMainValue.OnBuildingHarvest;
		//MainValue.mxDataManager.BuildingData.OnHarvestChest -= luaMainValue.OnHarvestChest;
		//MainValue.mxDataManager.BuildingData.OnBuildingFreeResponse -= luaMainValue.OnBuildingFreeResponse;
		//MainValue.mxDataManager.BuildingData.OnBuildingFreeInfoNtf -= luaMainValue.OnBuildingFreeInfoNtf;
		//MainValue.mxDataManager.BuildingData.OnBuildingUnlockResponse -= luaMainValue.OnBuildingUnlockResponse;

		//MainValue.mxDataManager.MapDataGrid.CityDictAction -= luaMainValue.OnCityList;

		//MainValue.mxDataManager.TaskData.TaskComplete -= luaMainValue.OnTaskComplete;
		//MainValue.mxDataManager.TaskData.OnGetReward -= luaMainValue.OnGetReward;
		//MainValue.mxDataManager.TaskData.OnTaskGetDailyList -= luaMainValue.OnTaskGetDailyList;
		//MainValue.mxDataManager.TaskData.OnTaskBeginDaily -= luaMainValue.OnTaskBeginDaily;
		//MainValue.mxDataManager.TaskData.OnTaskGetDailyReward -= luaMainValue.OnTaskGetDailyReward;
		//MainValue.mxDataManager.TaskData.OnTaskUpdateNtf -= luaMainValue.OnTaskUpdateNtf;
		//MainValue.mxDataManager.TaskData.OnDailyEventNtf -= luaMainValue.OnDailyEventNtf;
		//MainValue.mxDataManager.TaskData.OnDailyEventGetRewardNtf -= luaMainValue.OnDailyEventGetRewardNtf;

		//MainValue.mxDataManager.Hero.OnHeroSkillUnlockResponse -= luaMainValue.OnHeroSkillUnlockResponse;

		//MainValue.mxDataManager.Hero.OnHeroSkillUpgradeResponse -= luaMainValue.OnHeroSkillUpgradeResponse;

		//MainValue.mxDataManager.Hero.OnHeroModelCombineResponse -= luaMainValue.OnHeroModelCombineResponse;

		//MainValue.mxDataManager.ResourceData.OnResource -= luaMainValue.OnResourceData;

		//MainValue.mxDataManager.ItemData.OnUseItem -= luaMainValue.OnUseItem;
		//MainValue.mxDataManager.ItemData.OnItemSpeedup -= luaMainValue.OnItemSpeedup;
		//MainValue.mxDataManager.ItemData.OnItemUserNtf -= luaMainValue.OnItemUserNtf;
		//MainValue.mxDataManager.ItemData.OnItemUpdateNtf -= luaMainValue.OnItemUpdateNtf;
		//MainValue.mxDataManager.ItemData.OnItemBuy -= luaMainValue.OnItemBuy;

		//MainValue.mxDataManager.DefenseData.OnGarrisonTotalTroops -= luaMainValue.OnGarrisonTotalTroops;
		//MainValue.mxDataManager.DefenseData.OnGarrisonProgInfo -= luaMainValue.OnGarrisonProgInfo;
		//MainValue.mxDataManager.DefenseData.OnGarrisonTrainCancelResponse -= luaMainValue.OnGarrisonTrainCancelResponse;
		//MainValue.mxDataManager.TroopData.OnTroopTrain -= luaMainValue.OnTroopTrain;

		//MainValue.mxDataManager.TroopData.OnTotalTroops -= luaMainValue.OnTroopsTotal;
		//MainValue.mxDataManager.TroopData.OnCityTroopss -= luaMainValue.OnTroopsCity;
		//MainValue.mxDataManager.TroopData.OnTroopProgs -= luaMainValue.OnTroopProgs;
		//MainValue.mxDataManager.TroopData.OnTroopWaitings -= luaMainValue.OnTroopWaitings;
		//MainValue.mxDataManager.TroopData.OnTroopDissmiss -= luaMainValue.OnTroopDissmiss;
		//MainValue.mxDataManager.TroopData.OnTroopTrainCancel -= luaMainValue.OnTroopTrainCancel;

		//MainValue.mxDataManager.ResearchData.ResearchBaseInfoListAction -= luaMainValue.OnResearchBaseInfoList;
		//MainValue.mxDataManager.ResearchData.ResearchUpgradeNtfAction -= luaMainValue.OnResearchUpgradeNtf;
		//MainValue.mxDataManager.ResearchData.ResearchDetailInfoAction -= luaMainValue.OnResearchDetailInfo;
		//MainValue.mxDataManager.ResearchData.ResearchBaseInfoAction -= luaMainValue.OnResearchBaseInfo;
		//MainValue.mxDataManager.ResearchData.OnResearchUpgrade -= luaMainValue.OnResearchUpgrade;
		//MainValue.mxDataManager.ResearchData.OnResearchCancel -= luaMainValue.OnResearchCancel;
		//MainValue.mxDataManager.ResearchData.OnResearchCompleteNtf -= luaMainValue.OnResearchCompleteNtf;


		//MainValue.mxDataManager.PlayerUserInfoData.UserInfoAction -= luaMainValue.OnUserInfo;
		//MainValue.mxDataManager.PlayerUserInfoData.OnRankInfosAction -= luaMainValue.OnRankInfos;

		//MainValue.mxDataManager.ManoeuverData.OnManoeuvreSwitchNtf -= luaMainValue.OnManoeuvreSwitchNtf;

		//MainValue.mxDataManager.Hero.OnHeroLevel -= luaMainValue.OnHeroLevel;
		//MainValue.mxDataManager.Hero.OnHeroInfo -= luaMainValue.OnHeroInfo;
		//MainValue.mxDataManager.Hero.OnHeroMode -= luaMainValue.OnHeroMode;
		//MainValue.mxDataManager.Hero.OnHeroView -= luaMainValue.OnHeroView;
		//MainValue.mxDataManager.Hero.OnHeroEmploy -= luaMainValue.OnHeroEmploy;
		//MainValue.mxDataManager.Hero.OnHeroTalentPageSelect -= luaMainValue.OnHeroTalentPageSelect;
		//MainValue.mxDataManager.Hero.OnHeroTalentGetList -= luaMainValue.OnHeroTalentGetList;
		//MainValue.mxDataManager.Hero.OnHeroTalent -= luaMainValue.OnHeroTalent;
		//MainValue.mxDataManager.Hero.OnHeroTalentPointsInfo -= luaMainValue.OnHeroTalentPointsInfo;
		//MainValue.mxDataManager.Hero.OnHeroTalentUpgrade -= luaMainValue.OnHeroTalentUpgrade;
		//MainValue.mxDataManager.Hero.OnHeroTalentReset -= luaMainValue.OnHeroTalentReset;
		//MainValue.mxDataManager.Hero.OnHeroEquipInfo -= luaMainValue.OnHeroEquipInfo;


		//MainValue.mxDataManager.RecruitHallData.OnRecruitHallInfo -= luaMainValue.OnRecruitHallInfo;
		//MainValue.mxDataManager.RecruitHallData.OnOfficerRecruit -= luaMainValue.OnOfficerRecruit;
		//MainValue.mxDataManager.RecruitHallData.OnOfficerUpgradeStar -= luaMainValue.OnOfficerUpgradeStar;
		//MainValue.mxDataManager.RecruitHallData.OnOfficerShow -= luaMainValue.OnOfficerShow;
		//MainValue.mxDataManager.RecruitHallData.OnOfficeShowInfo -= luaMainValue.OnOfficeShowInfo;
		//MainValue.mxDataManager.RecruitHallData.OnOfficerEquip -= luaMainValue.OnOfficerEquip;
		//MainValue.mxDataManager.RecruitHallData.OnOfficerRemove -= luaMainValue.OnOfficerRemove;
		//MainValue.mxDataManager.RecruitHallData.OnOfficerUpdate -= luaMainValue.OnOfficerUpdate;
		//MainValue.mxDataManager.RecruitHallData.OnOfficerNew -= luaMainValue.OnOfficerNew;
		//MainValue.mxDataManager.RecruitHallData.OnOfficerResolve -= luaMainValue.OnOfficerResolve;
		//MainValue.mxDataManager.RecruitHallData.OnMedalCombine -= luaMainValue.OnMedalCombine;
		//MainValue.mxDataManager.RecruitHallData.OnMedalUse -= luaMainValue.OnMedalUse;
		//MainValue.mxDataManager.RecruitHallData.OnMedalRemove -= luaMainValue.OnMedalRemove;
		//MainValue.mxDataManager.RecruitHallData.OnOfficerDecompositionResponse -= luaMainValue.OnOfficerDecompositionResponse;

		//MainValue.mxDataManager.BuffData.OnBuffList -= luaMainValue.OnBuffList;
		//MainValue.mxDataManager.BuffData.OnBuffUpdate -= luaMainValue.OnBuffUpdate;
		//MainValue.mxDataManager.BuffData.OnHeroBuffList -= luaMainValue.OnHeroBuffList;
		//MainValue.mxDataManager.BuffData.OnHeroBuff -= luaMainValue.OnHeroBuff;

		//MainValue.mxDataManager.MailData.OnGetMailList -= luaMainValue.OnGetMailList;
		//MainValue.mxDataManager.MailData.OnNewMailNtf -= luaMainValue.OnNewMailNtf;
		//MainValue.mxDataManager.MailData.OnUnreadMailCountNtf -= luaMainValue.OnUnreadMailCountNtf;
		//MainValue.mxDataManager.MailData.OnCreateMail -= luaMainValue.OnCreateMail;
		//MainValue.mxDataManager.MailData.OnCreateMailByName -= luaMainValue.OnCreateMailByName;
		//MainValue.mxDataManager.MailData.OnDeleteMail -= luaMainValue.OnDeleteMail;
		//MainValue.mxDataManager.MailData.OnMarkMailReaded -= luaMainValue.OnMarkMailReaded;
		//MainValue.mxDataManager.MailData.OnSaveMail -= luaMainValue.OnSaveMail;
		//MainValue.mxDataManager.MailData.OnReadMail -= luaMainValue.OnReadMail;

		//MainValue.mxDataManager.MailData.OnGetPrizeCurr -= luaMainValue.OnGetPrizeCurr;
		//MainValue.mxDataManager.MailData.OnGetPrize -= luaMainValue.OnGetPrize;


		//MainValue.mxDataManager.MailData.OnGetRewardList -= luaMainValue.OnReadOnGetRewardListMail;
		//MainValue.mxDataManager.MailData.OnPrizeInfo -= luaMainValue.OnPrizeInfo;

		//MainValue.mxDataManager.MailData.OnGetManoeuvreReportListResponse -= luaMainValue.OnGetManoeuvreReportListResponse;
		//MainValue.mxDataManager.HostUserInfoData.OnRename -= luaMainValue.OnRename;

		//// 雷达
		//MainValue.mxDataManager.MapAlertData.OnBeScoutInfoList -= luaMainValue.OnBeScoutInfoList;
		//MainValue.mxDataManager.MapAlertData.OnBeAtkInfoList -= luaMainValue.OnBeAtkInfoList;
		//MainValue.mxDataManager.MapAlertData.OnBeCollisionInfoList -= luaMainValue.OnBeCollisionInfoList;


		//MainValue.mxDataManager.MapAlertData.OnRallyAlertNtf -= luaMainValue.OnRallyAlertNtf;
		//MainValue.mxDataManager.MapAlertData.OnRallyDefenceAlertNtf -= luaMainValue.OnRallyDefenceAlertNtf;
		////雷达集合的消息
		//MainValue.mxDataManager.MapAlertData.OnRadarNtf -= luaMainValue.OnRadarNtf;

		//// 当前行军数量
		//MainValue.mxDataManager.DataMapUserNtf.OnCurrentMarchCount -= luaMainValue.OnCurrentMarchCountFunction;

		//MainValue.mxDataManager.ChestData.OnChestGetReward -= luaMainValue.OnChestGetReward;
		//MainValue.mxDataManager.ChestData.OnChestNtf -= luaMainValue.OnChestNtf;
		//MainValue.mxDataManager.RepairData.OnRepair -= luaMainValue.OnRepair;
		//MainValue.mxDataManager.RepairData.OnRepairNtf -= luaMainValue.OnRepairNtf;
		//MainValue.mxDataManager.RepairData.OnRepairTroopNtf -= luaMainValue.OnRepairTroopNtf;

		//MainValue.mxDataManager.PayData.OnGetIapList -= luaMainValue.OnGetIapList;
		//MainValue.mxDataManager.PayData.OnIapFinish -= luaMainValue.OnIapFinish;

		//MainValue.mxDataManager.VipData.OnVipNtf -= luaMainValue.OnVipNtf;
		//MainValue.mxDataManager.VipData.OnVipLevelUpNtf -= luaMainValue.OnVipLevelUpNtf;

		//MainValue.mxDataManager.EventData.OnEventListNtf -= luaMainValue.OnEventListNtf;
		//MainValue.mxDataManager.EventData.OnEventNtf -= luaMainValue.OnEventNtf;
		//MainValue.mxDataManager.EventData.OnEventDetail -= luaMainValue.OnEventDetail;
		//MainValue.mxDataManager.EventData.OnEventRankListResponse -= luaMainValue.OnEventRankListResponse;
		//MainValue.mxDataManager.EventData.OnEventLastListResponse -= luaMainValue.OnEventLastListResponse;

		//MainValue.mxDataManager.MapDataGrid.CapitalDetailInfoAction -= luaMainValue.OnCapitalDetailInfo;

		///**  联盟  */
		//// 创建联盟
		//MainValue.mxDataManager.AllianceData.OnCreateAlliance -= luaMainValue.OnCreateAlliance;
		//// 联盟推荐列表响应
		//MainValue.mxDataManager.AllianceData.OnAllianceListResponse -= luaMainValue.OnAllianceListResponse;
		//// 玩家加入联盟请求
		//MainValue.mxDataManager.AllianceData.OnJoinAllianceResponse -= luaMainValue.OnJoinAllianceResponse;
		//// 入会申请通知
		//MainValue.mxDataManager.AllianceData.OnAllianceJoinApplyNtf -= luaMainValue.OnAllianceJoinApplyNtf;
		//// 加入公会广播通知
		//MainValue.mxDataManager.AllianceData.OnJoinAllianceNtf -= luaMainValue.OnJoinAllianceNtf;
		//// 退出公会广播通知
		//MainValue.mxDataManager.AllianceData.OnQuitAllianceNtf -= luaMainValue.OnQuitAllianceNtf;
		//// 搜索联盟
		//MainValue.mxDataManager.AllianceData.OnSearchAllianceResponse -= luaMainValue.OnSearchAllianceResponse;
		//MainValue.mxDataManager.AllianceData.OnAllianceModRankResponse -= luaMainValue.OnAllianceModRankResponse;
		//MainValue.mxDataManager.AllianceData.OnAllianceModRankNtf -= luaMainValue.OnAllianceModRankNtf;
		//// 个人退出联盟
		//MainValue.mxDataManager.AllianceData.OnQuitAllianceResponseNtf -= luaMainValue.OnQuitAllianceResponseNtf;
		////修改联盟头衔
		//MainValue.mxDataManager.AllianceData.OnAllianceMemberTitleNtf -= luaMainValue.OnAllianceMemberTitleNtf;
		////修改联盟头衔通知
		//MainValue.mxDataManager.AllianceData.OnUpdateAllianceMemberTitleNtf -= luaMainValue.OnUpdateAllianceMemberTitleNtf;
		//// 修改联盟权限响应 */
		//MainValue.mxDataManager.AllianceData.OnUpdateAllianceAuthorityResponse -= luaMainValue.OnUpdateAllianceAuthorityResponse;
		//// ct联盟权限改变通知client */
		//MainValue.mxDataManager.AllianceData.OnUpdateAllianceAuthorityNtf -= luaMainValue.OnUpdateAllianceAuthorityNtf;

		//// 联盟成员
		//MainValue.mxDataManager.AllianceData.OnAllianceMemberResponse -= luaMainValue.OnAllianceMemberResponse;
		//MainValue.mxDataManager.AllianceData.OnChangeAllianceNameResponse -= luaMainValue.OnChangeAllianceNameResponse;
		//MainValue.mxDataManager.AllianceData.OnAllianceLevelInfoResponse -= luaMainValue.OnAllianceLevelInfoResponse;

		//MainValue.mxDataManager.AllianceData.OnAllianceDonateResponse -= luaMainValue.OnAllianceDonateResponse;
		////联盟捐赠历史列表
		//MainValue.mxDataManager.AllianceData.OnAllianceDonateHistoryResponse -= luaMainValue.OnAllianceDonateHistoryResponse;
		////解散联盟回调
		//MainValue.mxDataManager.AllianceData.OnDismissAllianceResponse -= luaMainValue.OnDismissAllianceResponse;
		////解散联盟通知
		//MainValue.mxDataManager.AllianceData.OnDismissAllianceNtf -= luaMainValue.OnDismissAllianceNtf;

		////联盟宝箱List响应
		//MainValue.mxDataManager.AllianceData.OnOpenAllianceGiftResponse -= luaMainValue.OnOpenAllianceGiftResponse;
		////获取宝箱list
		//MainValue.mxDataManager.AllianceData.OnListAllianceGiftResponse -= luaMainValue.OnListAllianceGiftResponse;

		//MainValue.mxDataManager.AllianceData.OnReceiveAllianceGiftNtf -= luaMainValue.OnReceiveAllianceGiftNtf;
		////宝箱等级公会广播通知*
		//MainValue.mxDataManager.AllianceData.OnAllianceGiftLevelNtf -= luaMainValue.OnAllianceGiftLevelNtf;

		//MainValue.mxDataManager.AllianceData.OnQuitAllianceResponseNtf -= luaMainValue.OnQuitAllianceResponseNtf;
		//MainValue.mxDataManager.AllianceData.OnAllianceOfferHelpResponse -= luaMainValue.OnAllianceOfferHelpResponse;
		//MainValue.mxDataManager.AllianceData.OnAllianceHelpResponse -= luaMainValue.OnAllianceHelpResponse;
		//MainValue.mxDataManager.AllianceData.OnAllianceHelpNtf -= luaMainValue.OnAllianceHelpNtf;
		//MainValue.mxDataManager.AllianceData.OnAllianceOfferHelpNtf -= luaMainValue.OnAllianceOfferHelpNtf;
		//MainValue.mxDataManager.AllianceData.OnAllianceDeleteHelpNtf -= luaMainValue.OnAllianceDeleteHelpNtf;
		//MainValue.mxDataManager.AllianceData.OnAllianceUpdateHelpNtf -= luaMainValue.OnAllianceUpdateHelpNtf;
		//MainValue.mxDataManager.AllianceData.OnAllianceListHelpResponse -= luaMainValue.OnAllianceListHelpResponse;
		//MainValue.mxDataManager.AllianceData.OnCreditUpdateNtf -= luaMainValue.OnCreditUpdateNtf;
		//MainValue.mxDataManager.AllianceData.OnAllianceOfferHelpAllResponse -= luaMainValue.OnAllianceOfferHelpAllResponse;
		//MainValue.mxDataManager.AllianceData.OnUpdateAllianceBriefNtf -= luaMainValue.OnUpdateAllianceBriefNtf;
		//MainValue.mxDataManager.AllianceData.OnAllianceResHistoryNtf -= luaMainValue.OnAllianceResHistoryNtf;
		//MainValue.mxDataManager.AllianceData.OnAllianceResUpdateNtf -= luaMainValue.OnAllianceResUpdateNtf;
		//MainValue.mxDataManager.AllianceData.OnAllianceResListNtf -= luaMainValue.OnAllianceResListNtf;
		//MainValue.mxDataManager.AllianceData.OnListAllianceResApplyNtf -= luaMainValue.OnListAllianceResApplyNtf;
		//MainValue.mxDataManager.AllianceData.OnAllianceResApplyResultNtf -= luaMainValue.OnAllianceResApplyResultNtf;
		//MainValue.mxDataManager.AllianceData.OnAllianceResApplyResponse -= luaMainValue.OnAllianceResApplyResponse;
		//MainValue.mxDataManager.AllianceData.OnAllianceResApplyCancelResponse -= luaMainValue.OnAllianceResApplyCancelResponse;
		//MainValue.mxDataManager.AllianceData.OnDelAllianceResApplyNtf -= luaMainValue.OnDelAllianceResApplyNtf;
		////联盟领土列表响应
		//MainValue.mxDataManager.AllianceData.OnListAllianceDominionResponse -= luaMainValue.OnListAllianceDominionResponse;
		//MainValue.mxDataManager.AllianceData.OnChangeAllianceAbbrResponse -= luaMainValue.OnChangeAllianceAbbrResponse;
		//MainValue.mxDataManager.AllianceData.OnChangeAllianceLogoResponse -= luaMainValue.OnChangeAllianceLogoResponse;
		//MainValue.mxDataManager.AllianceData.OnChangeAllianceLangResponse -= luaMainValue.OnChangeAllianceLangResponse;
		//MainValue.mxDataManager.AllianceData.OnChangeAllianceDescResponse -= luaMainValue.OnChangeAllianceDescResponse;
		//MainValue.mxDataManager.AllianceData.OnAllianceResApplyNtf -= luaMainValue.OnAllianceResApplyNtf;
		//MainValue.mxDataManager.AllianceData.OnManageAllianceResApplyResponse -= luaMainValue.OnManageAllianceResApplyResponse;

		//MainValue.mxDataManager.DataMapUserNtf.OnFormationStyleInfo -= luaMainValue.OnFormationStyleInfo;
		//MainValue.mxDataManager.DataMapUserNtf.OnSetFormationStyleResult -= luaMainValue.OnSetFormationStyleResult;

		////黑市
		//MainValue.mxDataManager.BlackmarketData.OnBlackmarket -= luaMainValue.OnBlackmarket;
		//MainValue.mxDataManager.BlackmarketData.OnBlackmarketRefresh -= luaMainValue.OnBlackmarketRefresh;
		//MainValue.mxDataManager.BlackmarketData.OnBlackmarketBuyItem -= luaMainValue.OnBlackmarketBuyItem;

		//// 集结防御
		//MainValue.mxDataManager.RallyDataNtf.OnResponse_RallyAtkListNtf -= luaMainValue.OnResponse_RallyAtkListNtf;
		//MainValue.mxDataManager.RallyDataNtf.OnResponse_RallyDefListNtf -= luaMainValue.OnResponse_RallyDefListNtf;
		////集结
		//MainValue.mxDataManager.RallyDataNtf.OnResponse_RallyListNtf -= luaMainValue.OnResponse_RallyListNtf;
		//MainValue.mxDataManager.RallyDataNtf.OnResponse_RallyList -= luaMainValue.OnResponse_RallyList;

		//MainValue.mxDataManager.ActivityData.OnActivityFistPayNtf -= luaMainValue.OnActivityFistPayNtf;
		//MainValue.mxDataManager.ActivityData.OnActivityUnlimitedNtf -= luaMainValue.OnActivityUnlimitedNtf;
		//MainValue.mxDataManager.ActivityData.OnCollectActFistPayResponse -= luaMainValue.OnCollectActFistPayResponse;
		//MainValue.mxDataManager.ActivityData.OnCollectActHeroLevelResponse -= luaMainValue.OnCollectActHeroLevelResponse;
		//MainValue.mxDataManager.ActivityData.OnCollectActPowerResponse -= luaMainValue.OnCollectActPowerResponse;
		//MainValue.mxDataManager.ActivityData.OnCollectActSevenDaysResponse -= luaMainValue.OnCollectActSevenDaysResponse;
		//MainValue.mxDataManager.ActivityData.OnMonthSinginResponse -= luaMainValue.OnMonthSinginResponse;
		//MainValue.mxDataManager.ActivityData.OnCollectCumulativeResponse -= luaMainValue.OnCollectCumulativeResponse;

		//MainValue.mxDataManager.ActivityData.OnGachaResponse -= luaMainValue.OnGachaResponse;
		//MainValue.mxDataManager.ActivityData.OnGachaNtf -= luaMainValue.OnGachaNtf;
		//MainValue.mxDataManager.ActivityData.OnGachaGetiamondBoxResponse -= luaMainValue.OnGachaGetiamondBoxResponse;
		//MainValue.mxDataManager.ActivityData.OnGachaGetCashBoxResponse -= luaMainValue.OnGachaGetCashBoxResponse;
		//MainValue.mxDataManager.ActivityData.OnGachaDiamondResponse -= luaMainValue.OnGachaDiamondResponse;
		//MainValue.mxDataManager.ActivityData.OnGachaCashResponse -= luaMainValue.OnGachaCashResponse;

		//MainValue.mxDataManager.ActivityData.OnFundBuyResponse -= luaMainValue.OnFundBuyResponse;
		//MainValue.mxDataManager.ActivityData.OnFundCollectResponse -= luaMainValue.OnFundCollectResponse;
		//MainValue.mxDataManager.ActivityData.OnDailyTargetGetRewardResponse -= luaMainValue.OnDailyTargetGetRewardResponse;
		//MainValue.mxDataManager.ActivityData.OnDailyTargetShopResponse -= luaMainValue.OnDailyTargetShopResponse;
		//MainValue.mxDataManager.ActivityData.OnCardCollectResponse -= luaMainValue.OnCardCollectResponse;

		//MainValue.mxDataManager.ChatManager.OnChatDataNtf -= luaMainValue.OnChatDataNtf;
		//MainValue.mxDataManager.ChatManager.OnChatTokenNtf -= luaMainValue.OnChatTokenNtf;

		//MainValue.mxDataManager.ChatManager.OnLoginChatServerResponse -= luaMainValue.OnLoginChatServerResponse;
		//MainValue.mxDataManager.ChatManager.OnChatMessageNtf -= luaMainValue.OnChatMessageNtf;
		//MainValue.mxDataManager.ChatManager.OnChatMessageResponse -= luaMainValue.OnChatMessageResponse;
		//MainValue.mxDataManager.ChatManager.OnChatAnnounceNtf -= luaMainValue.OnChatAnnounceNtf;
		//MainValue.mxDataManager.ChatManager.OnChatMoreMessageResponse -= luaMainValue.OnChatMoreMessageResponse;





		//MainValue.mxDataManager.ObserverData.ScreenCenterPstAction -= luaMainValue.OnSetPstValue;

		//MainValue.mxDataManager.DataUserstatis.OnUserStatisticsResponse -= luaMainValue.OnUserStatisticsResponse;

		//MainValue.mxDataManager.MapPveData.OnFindNearestElement -= luaMainValue.OnFindNearestElement;
		//MainValue.mxDataManager.MapPveData.OnRefreshNearestElement -= luaMainValue.OnRefreshNearestElement;

		//MainValue.mxDataManager.MarchData.OnMarchNtf -= luaMainValue.OnNewMarchNtf;
		//MainValue.mxDataManager.MarchData.OnMarchCompleteNtf -= luaMainValue.OnMarchCompleteNtf;

		//MainValue.mxDataManager.ManoeuverData.OnGetManoeuvreInfo -= luaMainValue.OnGetManoeuvreInfo;
		//MainValue.mxDataManager.ManoeuverData.OnGetManoeuvreMatch -= luaMainValue.OnGetManoeuvreMatch;
		//MainValue.mxDataManager.ManoeuverData.OnGetGlobalManoeuvre -= luaMainValue.OnGetGlobalManoeuvre;
		//MainValue.mxDataManager.ManoeuverData.OnGetManoeuvreRank -= luaMainValue.OnGetManoeuvreRank;
		//MainValue.mxDataManager.ManoeuverData.OnGetManoeuvreInfoUpdateNtf -= luaMainValue.OnGetManoeuvreInfoUpdateNtf;
		//MainValue.mxDataManager.ManoeuverData.OnGetManoeuvreSetStyleRespons -= luaMainValue.OnGetManoeuvreSetStyleRespons;

		//MainValue.mxDataManager.ManoeuverShopData.OnManoeuvreShopNtf -= luaMainValue.OnManoeuvreShopNtf;

		//MainValue.mxDataManager.ManoeuverShopData.OnGetManoeuvreShopInfoResponse -= luaMainValue.OnGetManoeuvreShopInfoResponse;
		//MainValue.mxDataManager.ManoeuverShopData.OnRefreshManoeuvreShopResponse -= luaMainValue.OnRefreshManoeuvreShopResponse;
		//MainValue.mxDataManager.ManoeuverShopData.OnManoeuvreShopBuyItemResponse -= luaMainValue.OnManoeuvreShopBuyItemResponse;



		//MainValue.mxDataManager.PveData.OnPveStartLevelResponse -= luaMainValue.OnPveStartLevelResponse;
		//MainValue.mxDataManager.PveData.OnPveOpenChapterBoxResponse -= luaMainValue.OnPveOpenChapterBoxResponse;
		//MainValue.mxDataManager.PveData.OnPveSetStyleResponse -= luaMainValue.OnPveSetStyleResponse;
		////MainValue.mxDataManager.PveData.OnPveGetStyleResponse -=luaMainValue.OnPveGetStyleResponse;
		//MainValue.mxDataManager.PveData.OnPveWipeOutResponse -= luaMainValue.OnPveWipeOutResponse;

		//MainValue.mxDataManager.ManoeuverData.OnManoeuvreBuyChallengeTimesResponse -= luaMainValue.OnManoeuvreBuyChallengeTimesResponse;

		//MainValue.mxDataManager.FtueData.OnNewbieGuideNtf -= luaMainValue.OnNewbieGuideNtf;
		//MainValue.mxDataManager.FtueData.OnNewbieGuideProgResponse -= luaMainValue.OnNewbieGuideProgResponse;
		//MainValue.mxDataManager.FtueData.OnNewbieGuideEventResponse -= luaMainValue.OnNewbieGuideEventResponse;
		//MainValue.mxDataManager.FtueData.OnNewbieGuideSkipResponse -= luaMainValue.OnNewbieGuideSkipResponse;

		//MainValue.mxDataManager.CapitalData.OnCapitalTroopInfo -= luaMainValue.OnCapitalTroopInfo;

		//MainValue.mxDataManager.CapitalData.OnCapitalsOccupyInfo -= luaMainValue.OnCapitalsOccupyInfo;
		//MainValue.mxDataManager.ScrollData.OnScrollTextNtf -= luaMainValue.OnScrollTextNtf;

		//MainValue.mxDataManager.HuoDongData.OnHuodongGetBriefListResponse -= luaMainValue.OnHuodongGetBriefListResponse;
		//MainValue.mxDataManager.HuoDongData.OnHuodongGetDetailResponse -= luaMainValue.OnHuodongGetDetailResponse;
		//MainValue.mxDataManager.HuoDongData.OnHuodongBriefListNtf -= luaMainValue.OnHuodongBriefListNtf;
		//MainValue.mxDataManager.HuoDongData.OnHuodongGetPrizeResponse -= luaMainValue.OnHuodongGetPrizeResponse;



		//MainValue.mxDataManager.CapitalData.OnCapitalBattleRecordResponse -= luaMainValue.OnCapitalBattleRecordResponse;

		//MainValue.mxDataManager.CapitalData.OnCapitalSetTaxResponse -= luaMainValue.OnCapitalSetTaxResponse;


		//MainValue.mxDataManager.RankingData.OnUserRankListResponse -= luaMainValue.OnUserRankListResponse;
		//MainValue.mxDataManager.RankingData.OnDetailRankListResponse -= luaMainValue.OnDetailRankListResponse;
		//MainValue.mxDataManager.RankingData.OnAllianceRankListResponse -= luaMainValue.OnAllianceRankListResponse;
		//MainValue.mxDataManager.RankingData.OnUserRankInfoNtf -= luaMainValue.OnUserRankInfoNtf;




	}

	#endregion



	public void ShowMemory()
	{
		//if (null != uiManager)
		//{
		//	// uiManager.ShowMemory();
		//	uiManager.ShowSnapshot();
		//}
	}


	public void UpdatePreSecond()
	{
		if (null != luaenv)
		{
			//uint old = Profiler.GetMonoUsedSize() / 1000;
			luaenv.Tick();
			//uint current = Profiler.GetMonoUsedSize() / 1000;
		}
	}


	public new void Dispose()
	{
		//luaenv.Global.Set("dbManager", (Game.Data.CSVManager)null);
		//luaenv.Global.Set("dataManager", (Game.Data.DataManager)null);
		UnInitLuaEvent();

		//if (null != uiManager)
		//{
		//	uiManager.Dispose();
		//	uiManager = null;
		//}

		base.Dispose();
	}
}