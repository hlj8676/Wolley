using System.Collections.Generic;
using System.Collections.ObjectModel;
//using network.message;
using UnityEngine;
//using Game.Data;

[XLua.CSharpCallLua]
public interface LuaMainValue
{
	//ILuaUiManager GetUIManager();
	//ILuaWorldGuiManager GetWorldGuiManager();

	//string GetVersion();

	void UpdatePreSecond();
	void Reset();
	//void EnterScene( Game.Type.TypeScene currentScene , Game.Type.TypeScene oldScene );
	//void ExitScene( Game.Type.TypeScene scene );


	//void OnNetDisonnected( bool canReConnect );


	void Update();
	//void LateUpdate();

	//string GetAssetsName( string assetsName , out string prefab );

	//bool GetFtueState();

	//void CompleteFute();

	//UnityEngine.Sprite LoadSprite( string name );
	#region event


	//void On6WavesLoginResult();

	//void OnBeScoutInfoList( List<BeScoutInfo> info );
	//void OnBeAtkInfoList( List<BeAtkInfo> info );
	//void OnBeCollisionInfoList( List<BeCollisionInfo> info );
	//void OnRallyAlertNtf( RallyAtkInfo info );
	//void OnRallyDefenceAlertNtf( RallyDefInfo info );
	//void OnRadarNtf(RadarMap arg1);


	//void OnRename( Result result );
	//bool OnLoadSceneProgress( string sceneName , float progress );

	//void OnLoginResult( Result result , UserInfo value );
	//void OnPowerUpdate( long power , int powerRank );
	//void OnTempBuyIAP( Result result );
	//void OnTempGetIAPTime( Result result , long endTime );
	//void OnStoryGuideComplete( Result result );
 //   void OnSetUserNationalFlagResponse(Result arg1, int arg2);
 //   void OnNewbieGuideNtf( NewbieGuideInfo obj , List<int> eventIds );
	//void OnSearchUser( Result result );


	//void OnBuildingBegin( Result result , BuildingInfo value );
	//void OnBuildingLevelUp( Result result , BuildingInfo value );
	//void OnBuildingComplete( BuildingInfo value );
	//void OnBuildingInfoList( List<BuildingInfo> value );
	//void OnBuildingProgInfoList( List<BuildingProgInfo> value );
	//void OnWaitInfoList( List<BuildingWaitInfo> value );
	//void OnBuildUpdateNtf( BuildingInfo value );
	//void OnBuildingRemove( Result result , BuildingInfo value );
	//void OnBuildingCancel( Result result , BuildingInfo value );
	//void OnBuildingHarvest( Result result , int id , bool chest );
	//void OnHarvestChest( Result result , int buildingId , ReadOnlyCollection<ChestItemsInfo> infos );

	//void OnCityList( Dictionary<string , TileCity> value );

	//void OnTaskComplete( List<network.message.QuestBasicInfo> value );
	//void OnGetReward( Result result , int id );
	//void OnTaskGetDailyList( long lastUpdateTime , long updateTimeLength , List<QuestDailyInfo> questList );
	//void OnTaskBeginDaily( Result result , QuestDailyInfo questInfo );
	//void OnBuildingUnlockResponse(Result obj);
	//void OnTaskGetDailyReward( Result result , int id );
	//void OnTaskUpdateNtf( QuestUpdateNtf data );
	//void OnDailyEventNtf( Result result , DailyEventInfo info );
	//void OnDailyEventGetRewardNtf( Result result );

	//void OnResourceData( ResouceNtf value );

	//void OnUseItem( Result result , int id , int opType );
	//void OnItemSpeedup( Result result );
	//void OnItemUserNtf( List<ItemInfo> obj );
	//void OnItemUpdateNtf( ItemInfo info );
	//void OnItemBuy( Result result , ItemBuyInfo info );


	//void OnTroopTrain( Result result , TroopProgInfo info );
	//void OnGarrisonTotalTroops( List<ArmyInfo> obj );
	//void OnTroopsTotal( List<ArmyInfo> value );
	//void OnGarrisonProgInfo( List<GarrisonProgInfo> obj );
	//void OnTroopsCity( List<ArmyInfo> value );
	//void OnGarrisonTrainCancelResponse( Result obj );
	//void OnTroopProgs( List<TroopProgInfo> value );
	//void OnTroopWaitings( List<TroopProgInfo> value );
	//void OnTroopDissmiss( Result obj );
	//void OnResearchBaseInfoList( Result result , List<ResearchBaseInfo> value );
	//void OnTroopTrainCancel( Result obj );
	//void OnResearchUpgradeNtf( ResearchUpgradeNtf value );
	//void OnResearchDetailInfo( ResearchDetailInfo value );
	//void OnResearchBaseInfo( ResearchBaseInfo value );
	//void OnResearchUpgrade( Result result , ResearchBaseInfo value );
	//void OnResearchCancel( Result result );
	//void OnResearchCompleteNtf( ResearchBaseInfo value );

	//void OnUserInfo( UserInfo value );
	//void OnRankInfos( Result result , List<RankInfo> value );

	//void OnTileDetailInfos( TileDetailInfo value );
	//void OnHeroLevel( int value , int value2);
	//void OnHeroInfo( List<HeroInfo> value );
	//void OnHeroMode( Result result , int heroId , int mode );
	//void OnHeroView( Result result , HeroViewInfo info );
	//void OnHeroEmploy( Result result );
	//void OnHeroTalentPageSelect( Result result , int heroId , int pageId );
	//void OnHeroTalentGetList( Result result );
	//void OnHeroTalent( HeroTalentListInfo info );
	//void OnHeroTalentPointsInfo( HeroTalentPointsInfo info );
	//void OnHeroTalentUpgrade( Result result , HeroTalentInfo info );
	//void OnHeroTalentReset( Result result , HeroTalentPointsInfo info );
	//void OnHeroEquipInfo( HeroEquipInfo info );
	//void OnHeroSkillUnlockResponse(HeroSkillUnlockResponse info);
	//void OnHeroSkillUpgradeResponse(HeroSkillUpgradeResponse info);
	//void OnHeroModelCombineResponse(Result result);

	


	//void OnRecruitHallInfo( RecruitHallInfo info );
	//void OnOfficerRecruit( Result result );
	//void OnOfficerUpgradeStar( Result result );
	//void OnOfficerShow( Result result );
	//void OnOfficeShowInfo( List<OfficerShowInfo> info );
	//void OnOfficerEquip( Result result );
	//void OnOfficerRemove( Result result );
	//void OnOfficerUpdate( OfficerInfo info );
	//void OnOfficerNew( OfficerInfo info );
	//void OnOfficerResolve( OfficerResolveInfo info );
	//void OnMedalCombine( Result result , MedalCombineResponseInfo info );
	//void OnMedalUse( Result result );
	//void OnMedalRemove( Result result );

	//void OnBuffList( List<BuffNtfInfo> buffList );
	//void OnBuffUpdate( BuffNtfInfo buff );
	//void OnHeroBuffList( int heroId , List<BuffHeroInfo> buffList );
	//void OnHeroBuff( BuffHeroInfo buff );
	//void MailListInfoEvent( MailListInfo mail );

	//void OnGetMailList( List<MailListInfo> mails , int remainCount );
	//void OnNewMailNtf( NewMailNtf value );
	//void OnUnreadMailCountNtf( List<MailUnreadCountInfo> value );
	//void OnCreateMail( Result value );
	//void OnCreateMailByName( Result value );
	//void OnDeleteMail( Result value );
	//void OnMarkMailReaded( Result value );
	//void OnSaveMail( Result value );

	//void OnPrizeInfo( long id , int type , long create_time , PrizeDetailInfo info );
	//void OnGetManoeuvreReportListResponse( List<ManoeuvreReportInfo> list );
	//// 	void OnReadMail( Result result , MailBasicInfo info );

	//void OnReadMail( Result result , MailDetailInfo info );
	//void OnGetPrize( Result result , List<long> mailId );
	//void OnGetPrizeCurr(Result result, List<long> mailId);
	

	//void OnReadOnGetRewardListMail( List<PrizeInfo> listInfo , int count );


	//void OnChestGetReward( Result result , int type , int id , int itemId );
	//void OnChestNtf( List<ChestInfo> value );

	//void OnRepair( Result result , RepairFactoryInfo value );
	//void OnRepairNtf( RepairFactoryInfo value );
	//void OnRepairTroopNtf( List<ArmyInfo> value );

	//void OnGetIapList( Result result , IapListInfo iapList );
	//void OnIapFinish( Result result , IapFinishRspInfo iapFinish );
	//void OnVipNtf( VipNtfInfo obj );
	//void OnVipLevelUpNtf( int obj );
	//void OnBuildingFreeResponse( Result arg1 , int arg2 );
	//void OnBuildingFreeInfoNtf( long obj );

	//void OnEventListNtf( EventListInfo obj );
	//void OnEventNtf( int state , EventInfo info );
	//void OnEventDetail( Result arg1 , EventDetailInfo arg2 );
	//void OnBlackmarket( List<BlackMarketInfo> value );
	//void OnBlackmarketRefresh( Result result );
	//void OnBlackmarketBuyItem( Result result );

	//void OnCreateAlliance( Result result , AllianceBriefInfo briefInfo );
	//void OnAllianceListResponse( Result result , List<AllianceBriefInfo> briefInfo );

	//void OnJoinAllianceResponse( Result result );
	//void OnAllianceJoinApplyNtf( AllianceJoinApplyInfo applyInfo );
	//void OnJoinAllianceNtf( UserAllianceNtfInfo joinNtfInfo );
	//void OnQuitAllianceNtf( UserAllianceNtfInfo quitNtfInfo );
	//void OnAllianceMemberResponse( Result obj , AllianceMemberResponseInfo respInfo );
	//void OnAllianceModRankResponse( Result result );
	//void OnAllianceModRankNtf( long dstUid , int newRank , List<int> permissions );

	//void OnUpdateAllianceAuthorityResponse( Result result );
	//void OnUpdateAllianceAuthorityNtf( UpdateAllianceAuthorityInfo infos );
	//void OnOfficerDecompositionResponse( Result arg1 , int arg2 );
	//void OnSearchAllianceResponse( Result result , int type , List<AllianceBriefInfo> briefList );
	//void OnAllianceLevelInfoResponse( Result arg1 , AllianceLevelInfo arg2 );
	//void OnAllianceDonateResponse( Result arg1 , int currentDonateCnt , List<ItemGiftInfo> arg2 );
	//void OnAllianceDonateHistoryResponse( Result obj , List<AllianceDonateInfo> info );
	//void OnDismissAllianceResponse( Result obj );
	//void OnDismissAllianceNtf( DismissAllianceNtf info );
	//void OnQuitAllianceResponseNtf( Result arg1 );
	//void OnAllianceMemberTitleNtf( Result arg1 );
	//void OnUpdateAllianceMemberTitleNtf( UpdateAllianceMemberTitleNtf arg1 );
	//void OnFormationStyleInfo( Result result , int type , StyleInfo atk , StyleInfo def );
	//void OnSetFormationStyleResult( Result result );
	//void OnAllianceOfferHelpResponse( Result obj );
	//void OnAllianceHelpResponse( Result obj );
	//void OnAllianceHelpNtf( AllianceHelpInfo obj );
	//void OnAllianceOfferHelpNtf( long arg1 , string name , int arg2 , int arg3 );
	//void OnAllianceDeleteHelpNtf( long arg1 , int arg2 );
	//void OnAllianceUpdateHelpNtf( long arg1 , int arg2 , int arg3 );
	//void OnAllianceListHelpResponse( Result arg1 , List<AllianceHelpInfo> arg2 );
	//void OnCreditUpdateNtf( CreditInfo obj );
	//void OnAllianceOfferHelpAllResponse( Result obj );

	//void OnListAllianceDominionResponse( ListAllianceDominionInfo info );

	//void OnWorldPopInfoPanel( TileDetailInfo TileDetailInfos );

	//void OnListAllianceGiftNtf( ListAllianceGiftInfo info );
	//void OnOpenAllianceGiftResponse( OpenAllianceGiftResponse result );
	//void OnListAllianceGiftResponse( ListAllianceGiftResponse data );
	//void OnReceiveAllianceGiftNtf( int arg1 );
	//void OnAllianceGiftLevelNtf( AllianceGiftLevelNtf data );



	//void OnFightReady();
	//void OnFightStart();
	//void OnFightOver( bool isWin );

	//void OnFightLeftDamage( long hp );
	//void OnFightRightDamage( long hp );
	//void OnResponse_RallyAtkListNtf( List<RallyAtkInfo> arg1 );
	//void OnResponse_RallyDefListNtf( List<RallyDefInfo> arg2 );
	//void OnResponse_RallyListNtf( RallyListNtf data );


	//void OnChatDataNtf( ChatDataNtf obj );
	//void OnChatTokenNtf( ChatTokenNtf obj );
	//void OnChatMoreMessageResponse( ChatType arg1 , List<ChatMessageDetailInfo> arg2 , int arg3 );
	//void OnChatMessageResponse( Result obj );
	//void OnChatMessageNtf( ChatMessageDetailInfo obj );
	//void OnChatAnnounceNtf( ChatAnnounceNtf obj );
	//void OnLoginChatServerResponse( Result arg1 , long arg2 );

	//void OnActivityFistPayNtf( ActivityFistPayInfo obj );
	//void OnActivityUnlimitedNtf( ActivityUnlimitedInfo obj );
	//void OnCollectActFistPayResponse( Result arg1 , ActivityFistPayInfo arg2 );
	//void OnCollectActHeroLevelResponse( Result arg1 , List<int> arg2 );
	//void OnCollectActPowerResponse( Result arg1 , List<long> arg2 );

	//void OnCurrentMarchCountFunction( int count );

	//void OnSetPstValue( Util.Vec3 pst );
	//void OnUserStatisticsResponse( Result arg1 , long arg2 , List<UserStatisticsInfo> arg3 );


	//void OnEventRankListResponse( Result arg1 , EventRanklistInfo arg2 );
	//void OnEventLastListResponse( Result arg1 , EventLastListInfo arg2 );
	//void OnFindNearestElement( Result result , int param , Pst pst );
	//void OnRefreshNearestElement( Result result , int param , Pst pst );

	//void OnResponse_RallyList( Result obj );
	//void OnNewMarchNtf( MarchNtf obj );
	//void OnMarchCompleteNtf( MarchCompleteNtf obj );
	//void OnCollectActSevenDaysResponse( Result arg1 , ActivitySevenDaysInfo arg2 );
	//void OnMonthSinginResponse( Result arg1 , ActivityMonthSinginInfo arg2 );
	//void OnCollectCumulativeResponse( Result arg1 , ActivityMonthSinginInfo arg2 );


	//void OnGetManoeuvreInfo( Result result , ManoeuvreInfo mInfo );
	//void OnManoeuvreSwitchNtf(ManoeuvreSwitchNtf arg1);
	
	//void OnGetManoeuvreMatch( int arg1 , List<ManoeuvreInfo> list , Result result);
	//void OnGetGlobalManoeuvre( Result result , FightReportInfo arg1 );
	//void OnGetManoeuvreRank( Result result , List<ManoeuvreScoreRankInfo> rankList , int kind , ManoeuvreScoreRankInfo info );
	//void OnGetManoeuvreInfoUpdateNtf( ManoeuvreInfoUpdateNtf info );
	//void OnGetManoeuvreSetStyleRespons( Result result );

	//void OnManoeuvreBuyChallengeTimesResponse( Result result , int arg1 );

	//void OnManoeuvreShopNtf( ManoeuvreShopInfo info );
	//void OnGetManoeuvreShopInfoResponse( ManoeuvreShopInfo info );

	//void OnRefreshManoeuvreShopResponse( Result result );

	//void OnManoeuvreShopBuyItemResponse( Result result );


	//void OnPveStartLevelResponse( Result result , PveLevelInfo levelInfo , FightReportInfo reportInfo , int hp , List<ItemGiftInfo> firstItems , List<ItemGiftInfo> levelItems );

	//void OnPveStartLevelResponse( Result arg1 , PveLevelInfo arg2 , FightReportInfo arg3 , int arg4 );
	//void OnPveOpenChapterBoxResponse( Result arg1 , PveChapterInfo arg2 );
	//void OnPveSetStyleResponse( Result obj );
	//void OnPveWipeOutResponse( Result arg1 , List<PveWipeOutInfo> arg2 , int arg3 );
	//void OnNewbieGuideProgResponse( Result obj );
	//void OnCapitalTroopInfo( CapitalTroopInfo arg1 );
	//void OnNewbieGuideEventResponse( Result obj );
	////	void OnPveGetStyleResponse( StyleInfo obj );
	//void InputControllerOnFingerDown( Vector3 pos );
	//void InputControllerOnFingerUp( Vector3 pos );
	//void OnCapitalsOccupyInfo( CapitalsOccupyInfoResponse arg1 );
	//void OnGachaResponse( Result obj );
	//void OnGachaNtf( GachaInfo obj );
	//void OnGachaGetiamondBoxResponse( Result arg1 , List<ItemGiftInfo> arg2 );
	//void OnGachaGetCashBoxResponse( Result arg1 , List<ItemGiftInfo> arg2 );
	//void OnGachaDiamondResponse( Result arg1 , List<ItemGiftInfo> arg2 );
	//void OnGachaCashResponse( Result arg1 , List<ItemGiftInfo> arg2 );
	//void OnScrollTextNtf( ScrollTextNtf obj );
	//void OnHuodongGetDetailResponse( List<HuodongDetailInfo> obj );
	//void OnHuodongGetBriefListResponse( List<ActivityBaseInfo> obj );

	//void OnCapitalBattleRecordResponse( List<CapitalBattleRecord> arg2 );
	//void OnCapitalSetTaxResponse(CapitalSetTaxResponse arg1);

	//void OnUserRankListResponse( Result arg1 , List<RankListInfo> arg2 );
	//void OnDetailRankListResponse( Result arg1 , RankListInfo arg2 );
	//void OnAllianceRankListResponse( Result arg1 , List<RankListInfo> arg2 );
	//void OnUserRankInfoNtf( int arg1 , int arg2 , List<RankInfo> arg3 );
	//void OnChangeAllianceNameResponse( Result obj );
	//void OnChangeAllianceAbbrResponse( Result obj );
	//void OnChangeAllianceLogoResponse( Result obj );
	//void OnChangeAllianceLangResponse( Result obj );
	//void OnChangeAllianceDescResponse( Result obj );
	//void OnUpdateAllianceBriefNtf( UpdateAllianceBriefNtf obj );
	//void OnAllianceResHistoryNtf( List<AllianceResApplyInfo> obj );
	//void OnAllianceResUpdateNtf( List<ResTypeInfo> obj );
	//void OnAllianceResListNtf( List<ResTypeInfo> obj );
	//void OnListAllianceResApplyNtf( List<AllianceResApplyInfo> obj );

	//void OnCapitalDetailInfo(CapitalDetailInfo arg1);


	//void OnAllianceResApplyNtf( long arg1 , ResTypeInfo arg2 , long arg3 );
	//void OnAllianceResApplyResultNtf( long arg1 , ResTypeInfo arg2 , bool arg3 );
	//void OnManageAllianceResApplyResponse( Result obj );
	//void OnAllianceResApplyResponse( Result obj );
	//void OnAllianceResApplyCancelResponse( Result obj );
	//void OnDelAllianceResApplyNtf( long arg1 , ResTypeInfo arg2 , long arg3 );
	//void OnFundBuyResponse( Result obj );
	//void OnFundCollectResponse( Result obj );
	//void OnHuodongBriefListNtf( List<ActivityBaseInfo> obj );
	//void OnDailyTargetGetRewardResponse( Result arg1 , int arg2 );
	//void OnDailyTargetShopResponse( Result arg1 , int arg2 );
	//void OnHuodongGetPrizeResponse( Result obj );
	//void OnNewbieGuideSkipResponse( Result obj );
	//void OnCardCollectResponse( Result obj );





	#endregion


}
