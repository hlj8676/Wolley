//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: ResultInfo.proto
namespace network.message
{
    [global::ProtoBuf.ProtoContract(Name=@"Result")]
    public enum Result
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"SUCCESS", Value=0)]
      SUCCESS = 0,
            
      [global::ProtoBuf.ProtoEnum(Name=@"FAILURE", Value=-1)]
      FAILURE = -1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"NO_RIGHT", Value=-2)]
      NO_RIGHT = -2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BASEDATA_NOT_FOUND", Value=-3)]
      BASEDATA_NOT_FOUND = -3,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PARAM_INVALID", Value=-1000)]
      PARAM_INVALID = -1000,
            
      [global::ProtoBuf.ProtoEnum(Name=@"USER_ID_REPEAT", Value=-1001)]
      USER_ID_REPEAT = -1001,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PASSWORD_INVALID", Value=-1002)]
      PASSWORD_INVALID = -1002,
            
      [global::ProtoBuf.ProtoEnum(Name=@"LOGIN_KEYWORD_TIMEOUT", Value=-1003)]
      LOGIN_KEYWORD_TIMEOUT = -1003,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SERVER_STOP", Value=-1004)]
      SERVER_STOP = -1004,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SERVER_NOT_OPEN", Value=-1005)]
      SERVER_NOT_OPEN = -1005,
            
      [global::ProtoBuf.ProtoEnum(Name=@"USER_NOT_EXIST", Value=-1006)]
      USER_NOT_EXIST = -1006,
            
      [global::ProtoBuf.ProtoEnum(Name=@"USER_EXISTED", Value=-1007)]
      USER_EXISTED = -1007,
            
      [global::ProtoBuf.ProtoEnum(Name=@"USER_REGISTER_ERROR", Value=-1008)]
      USER_REGISTER_ERROR = -1008,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BAD_USER_NAME", Value=-1009)]
      BAD_USER_NAME = -1009,
            
      [global::ProtoBuf.ProtoEnum(Name=@"USER_NAME_EXISTED", Value=-1010)]
      USER_NAME_EXISTED = -1010,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BAD_WORDS", Value=-1011)]
      BAD_WORDS = -1011,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INVALID_DATA_FROM_USER", Value=-1012)]
      INVALID_DATA_FROM_USER = -1012,
            
      [global::ProtoBuf.ProtoEnum(Name=@"USER_ID_ERROR", Value=-1013)]
      USER_ID_ERROR = -1013,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BAD_SEARCH_MODE", Value=-1014)]
      BAD_SEARCH_MODE = -1014,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BAD_SEARCH_TYPE", Value=-1015)]
      BAD_SEARCH_TYPE = -1015,
            
      [global::ProtoBuf.ProtoEnum(Name=@"VERSION_ERROR", Value=-1016)]
      VERSION_ERROR = -1016,
            
      [global::ProtoBuf.ProtoEnum(Name=@"RUNTIME_ERROR", Value=-1017)]
      RUNTIME_ERROR = -1017,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PARAM_REPEAT", Value=-1018)]
      PARAM_REPEAT = -1018,
            
      [global::ProtoBuf.ProtoEnum(Name=@"USER_PLATFORM_ID_ERROR", Value=-1019)]
      USER_PLATFORM_ID_ERROR = -1019,
            
      [global::ProtoBuf.ProtoEnum(Name=@"USER_TOKEN_INVALID", Value=-1020)]
      USER_TOKEN_INVALID = -1020,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CONFIG_NOT_EXIST", Value=-1021)]
      CONFIG_NOT_EXIST = -1021,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BUILDING_PROGRESS_DISABLE", Value=-2000)]
      BUILDING_PROGRESS_DISABLE = -2000,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BAD_BUILDING_POS", Value=-2001)]
      BAD_BUILDING_POS = -2001,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BUILDING_POS_USED", Value=-2002)]
      BUILDING_POS_USED = -2002,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BUILDING_WAITING_POS_EXIST", Value=-2003)]
      BUILDING_WAITING_POS_EXIST = -2003,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BAD_BUILDING_TYPE", Value=-2004)]
      BAD_BUILDING_TYPE = -2004,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BUILDING_LIMITED", Value=-2005)]
      BUILDING_LIMITED = -2005,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PREV_BUILDING_CHECK_ERR", Value=-2006)]
      PREV_BUILDING_CHECK_ERR = -2006,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ADD_BUILDING_ERR", Value=-2007)]
      ADD_BUILDING_ERR = -2007,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BAD_BUILDING_ID", Value=-2008)]
      BAD_BUILDING_ID = -2008,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PROG_CAN_NOT_FIND", Value=-2009)]
      PROG_CAN_NOT_FIND = -2009,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MAXN_FREE_TIME_EXCEEDED", Value=-2010)]
      MAXN_FREE_TIME_EXCEEDED = -2010,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BUILDING_HARVEST_MIN_TIME", Value=-2011)]
      BUILDING_HARVEST_MIN_TIME = -2011,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PROG_TYPE_ERROR", Value=-2012)]
      PROG_TYPE_ERROR = -2012,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BUILDING_REMOVE_DISABLE", Value=-2013)]
      BUILDING_REMOVE_DISABLE = -2013,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DIAMOND_MINE_UNBIND_TOO_BUSY", Value=-2014)]
      DIAMOND_MINE_UNBIND_TOO_BUSY = -2014,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BUILDING_HARVEST_CHEST_LIMIT", Value=-2015)]
      BUILDING_HARVEST_CHEST_LIMIT = -2015,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BUILDING_HARVEST_CHEST_NOT_FOUND", Value=-2016)]
      BUILDING_HARVEST_CHEST_NOT_FOUND = -2016,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ALLIANCE_FUND_LIMIT", Value=-2017)]
      ALLIANCE_FUND_LIMIT = -2017,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TARGET_NOT_CURRENT_SERVER", Value=-2018)]
      TARGET_NOT_CURRENT_SERVER = -2018,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CASH_LIMIT", Value=-2100)]
      CASH_LIMIT = -2100,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DIAMOND_LIMIT", Value=-2101)]
      DIAMOND_LIMIT = -2101,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ENERGY_LIMIT", Value=-2102)]
      ENERGY_LIMIT = -2102,
            
      [global::ProtoBuf.ProtoEnum(Name=@"FOOD_LIMIT", Value=-2103)]
      FOOD_LIMIT = -2103,
            
      [global::ProtoBuf.ProtoEnum(Name=@"OIL_LIMIT", Value=-2104)]
      OIL_LIMIT = -2104,
            
      [global::ProtoBuf.ProtoEnum(Name=@"STEEL_LIMIT", Value=-2105)]
      STEEL_LIMIT = -2105,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DOMINO_LIMIT", Value=-2106)]
      DOMINO_LIMIT = -2106,
            
      [global::ProtoBuf.ProtoEnum(Name=@"UNKNOWN_RESOURCE", Value=-2107)]
      UNKNOWN_RESOURCE = -2107,
            
      [global::ProtoBuf.ProtoEnum(Name=@"QUEST_NOT_FINISH", Value=-2200)]
      QUEST_NOT_FINISH = -2200,
            
      [global::ProtoBuf.ProtoEnum(Name=@"QUEST_REWARD_HAVE_RECEIVE", Value=-2201)]
      QUEST_REWARD_HAVE_RECEIVE = -2201,
            
      [global::ProtoBuf.ProtoEnum(Name=@"QUEST_NOT_INFO", Value=-2202)]
      QUEST_NOT_INFO = -2202,
            
      [global::ProtoBuf.ProtoEnum(Name=@"QUEST_DAILY_FULL", Value=-2203)]
      QUEST_DAILY_FULL = -2203,
            
      [global::ProtoBuf.ProtoEnum(Name=@"QUEST_ALLIANCE_FULL", Value=-2204)]
      QUEST_ALLIANCE_FULL = -2204,
            
      [global::ProtoBuf.ProtoEnum(Name=@"QUEST_NOT_EXIST", Value=-2205)]
      QUEST_NOT_EXIST = -2205,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DAILY_EVENT_REWARD_REPEAT", Value=-2206)]
      DAILY_EVENT_REWARD_REPEAT = -2206,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DAILY_EVENT_REWARD_NO_FOUND", Value=-2207)]
      DAILY_EVENT_REWARD_NO_FOUND = -2207,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_BEHAVIOR_NO_FOUND", Value=-2300)]
      ITEM_BEHAVIOR_NO_FOUND = -2300,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_TYPE_ERR", Value=-2301)]
      ITEM_TYPE_ERR = -2301,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_CAN_NOT_USE", Value=-2302)]
      ITEM_CAN_NOT_USE = -2302,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_USE_EXPIRED", Value=-2303)]
      ITEM_USE_EXPIRED = -2303,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_USE_LEVEL_LIMIT", Value=-2304)]
      ITEM_USE_LEVEL_LIMIT = -2304,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_CNT_ERR", Value=-2305)]
      ITEM_CNT_ERR = -2305,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_BEHAVIOR_WRONG_ARGS", Value=-2306)]
      ITEM_BEHAVIOR_WRONG_ARGS = -2306,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_NO_FOUND_PROMOTION", Value=-2307)]
      ITEM_NO_FOUND_PROMOTION = -2307,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_PROMOTE_TIMEOUT", Value=-2308)]
      ITEM_PROMOTE_TIMEOUT = -2308,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_PROMOTE_BUY_LIMIT", Value=-2309)]
      ITEM_PROMOTE_BUY_LIMIT = -2309,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MATERIALS_LIMIT", Value=-2310)]
      MATERIALS_LIMIT = -2310,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MATERIALS_TYPE_ERROR", Value=-2311)]
      MATERIALS_TYPE_ERROR = -2311,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TROOP_TYPE_ERROR", Value=-2400)]
      TROOP_TYPE_ERROR = -2400,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TROOP_PROGRESS_DISABLE", Value=-2401)]
      TROOP_PROGRESS_DISABLE = -2401,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TROOP_TRAIN_CNT_ERROR", Value=-2402)]
      TROOP_TRAIN_CNT_ERROR = -2402,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TROOP_CNT_ERROR", Value=-2403)]
      TROOP_CNT_ERROR = -2403,
            
      [global::ProtoBuf.ProtoEnum(Name=@"RESEARCH_PRETECH_LIMIT", Value=-2500)]
      RESEARCH_PRETECH_LIMIT = -2500,
            
      [global::ProtoBuf.ProtoEnum(Name=@"RESEARCH_NOT_EXIST", Value=-2501)]
      RESEARCH_NOT_EXIST = -2501,
            
      [global::ProtoBuf.ProtoEnum(Name=@"RESEARCH_PROGRESS_DISABLE", Value=-2502)]
      RESEARCH_PROGRESS_DISABLE = -2502,
            
      [global::ProtoBuf.ProtoEnum(Name=@"RESEARCH_BAD_TYPE", Value=-2503)]
      RESEARCH_BAD_TYPE = -2503,
            
      [global::ProtoBuf.ProtoEnum(Name=@"RESEARCH_STATUS_LIMITED", Value=-2504)]
      RESEARCH_STATUS_LIMITED = -2504,
            
      [global::ProtoBuf.ProtoEnum(Name=@"RESEARCH_WAITING", Value=-2505)]
      RESEARCH_WAITING = -2505,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BAD_BLACKMARKET_TYPE", Value=-2551)]
      BAD_BLACKMARKET_TYPE = -2551,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BAD_BLACKMARKET_ITEM_ID", Value=-2552)]
      BAD_BLACKMARKET_ITEM_ID = -2552,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BLACKMARKET_BUY_LIMIT", Value=-2553)]
      BLACKMARKET_BUY_LIMIT = -2553,
            
      [global::ProtoBuf.ProtoEnum(Name=@"RANK_NOT_EXIST", Value=-2600)]
      RANK_NOT_EXIST = -2600,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BAD_RANK_TYPE", Value=-2601)]
      BAD_RANK_TYPE = -2601,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HERO_ID_ERROR", Value=-2700)]
      HERO_ID_ERROR = -2700,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HERO_PAGE_ALREADY_WORK", Value=-2701)]
      HERO_PAGE_ALREADY_WORK = -2701,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HERO_PAGE_NOT_FIND", Value=-2702)]
      HERO_PAGE_NOT_FIND = -2702,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HERO_NOT_FIND", Value=-2703)]
      HERO_NOT_FIND = -2703,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HERO_IS_ALIVE", Value=-2704)]
      HERO_IS_ALIVE = -2704,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HERO_STATUS_ERROR", Value=-2705)]
      HERO_STATUS_ERROR = -2705,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HERO_TALENT_POINTS_ERROR", Value=-2706)]
      HERO_TALENT_POINTS_ERROR = -2706,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HERO_TALENT_TYPE_ERROR", Value=-2707)]
      HERO_TALENT_TYPE_ERROR = -2707,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HERO_TALENT_LEVEL_ERROR", Value=-2708)]
      HERO_TALENT_LEVEL_ERROR = -2708,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HERO_PREVIOUS_TALENT_ERROR", Value=-2709)]
      HERO_PREVIOUS_TALENT_ERROR = -2709,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HERO_MODEL_ERROR", Value=-2710)]
      HERO_MODEL_ERROR = -2710,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HERO_NOT_AVAILABLE", Value=-2711)]
      HERO_NOT_AVAILABLE = -2711,
            
      [global::ProtoBuf.ProtoEnum(Name=@"OFFICER_CANNOT_FIND", Value=-2712)]
      OFFICER_CANNOT_FIND = -2712,
            
      [global::ProtoBuf.ProtoEnum(Name=@"OFFICER_ALREADY_EXIT", Value=-2713)]
      OFFICER_ALREADY_EXIT = -2713,
            
      [global::ProtoBuf.ProtoEnum(Name=@"OFFICER_KIND_ERROR", Value=-2714)]
      OFFICER_KIND_ERROR = -2714,
            
      [global::ProtoBuf.ProtoEnum(Name=@"OFFICER_MATERIALS_LIMIT", Value=-2715)]
      OFFICER_MATERIALS_LIMIT = -2715,
            
      [global::ProtoBuf.ProtoEnum(Name=@"OFFICER_STAR_LIMIT", Value=-2716)]
      OFFICER_STAR_LIMIT = -2716,
            
      [global::ProtoBuf.ProtoEnum(Name=@"OFFICER_ALREADY_EQUIPED", Value=-2717)]
      OFFICER_ALREADY_EQUIPED = -2717,
            
      [global::ProtoBuf.ProtoEnum(Name=@"OFFICER_POS_IS_LOCKED", Value=-2718)]
      OFFICER_POS_IS_LOCKED = -2718,
            
      [global::ProtoBuf.ProtoEnum(Name=@"OFFICER_POS_ERROR", Value=-2719)]
      OFFICER_POS_ERROR = -2719,
            
      [global::ProtoBuf.ProtoEnum(Name=@"OFFICER_LEVEL_LIMIT", Value=-2720)]
      OFFICER_LEVEL_LIMIT = -2720,
            
      [global::ProtoBuf.ProtoEnum(Name=@"OFFICER_POS_IS_EMPTY", Value=-2721)]
      OFFICER_POS_IS_EMPTY = -2721,
            
      [global::ProtoBuf.ProtoEnum(Name=@"OFFICER_NOT_EQUIPED", Value=-2722)]
      OFFICER_NOT_EQUIPED = -2722,
            
      [global::ProtoBuf.ProtoEnum(Name=@"OFFICER_EMBED_POS_ERROR", Value=-2723)]
      OFFICER_EMBED_POS_ERROR = -2723,
            
      [global::ProtoBuf.ProtoEnum(Name=@"OFFICER_EMBED_TYPE_ERROR", Value=-2724)]
      OFFICER_EMBED_TYPE_ERROR = -2724,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HERO_SKILL_NOT_FIND", Value=-2725)]
      HERO_SKILL_NOT_FIND = -2725,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HERO_SKILL_NOT_ONLOCK", Value=-2726)]
      HERO_SKILL_NOT_ONLOCK = -2726,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HERO_SKILL_ONLOCK", Value=-2727)]
      HERO_SKILL_ONLOCK = -2727,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HERO_SKILL_NOT_CONFIG", Value=-2728)]
      HERO_SKILL_NOT_CONFIG = -2728,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HERO_SKILL_MAX", Value=-2729)]
      HERO_SKILL_MAX = -2729,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HERO_SKILL_UNOPEN", Value=-2730)]
      HERO_SKILL_UNOPEN = -2730,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HERO_LEVEL_LIMIT", Value=-2731)]
      HERO_LEVEL_LIMIT = -2731,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HERO_MODEL_NOT_ONLOCK", Value=-2732)]
      HERO_MODEL_NOT_ONLOCK = -2732,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HERO_MODEL_ALREADY_ONLOCK", Value=-2733)]
      HERO_MODEL_ALREADY_ONLOCK = -2733,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CHEST_ERROR", Value=-2800)]
      CHEST_ERROR = -2800,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CHEST_EXPIRED_ERROR", Value=-2801)]
      CHEST_EXPIRED_ERROR = -2801,
            
      [global::ProtoBuf.ProtoEnum(Name=@"NEWBIE_GUIDE_SKIP_ERR", Value=-2821)]
      NEWBIE_GUIDE_SKIP_ERR = -2821,
            
      [global::ProtoBuf.ProtoEnum(Name=@"IAP_PACKAGEID_NOFOUND", Value=-2900)]
      IAP_PACKAGEID_NOFOUND = -2900,
            
      [global::ProtoBuf.ProtoEnum(Name=@"IAP_VERIFY_ERR", Value=-2901)]
      IAP_VERIFY_ERR = -2901,
            
      [global::ProtoBuf.ProtoEnum(Name=@"IAP_VERIFY_REPEAT", Value=-2902)]
      IAP_VERIFY_REPEAT = -2902,
            
      [global::ProtoBuf.ProtoEnum(Name=@"IAP_PAY_TYPE_ERR", Value=-2903)]
      IAP_PAY_TYPE_ERR = -2903,
            
      [global::ProtoBuf.ProtoEnum(Name=@"USER_BORN_ERROR", Value=-3001)]
      USER_BORN_ERROR = -3001,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GRID_PST_ERROR", Value=-3002)]
      GRID_PST_ERROR = -3002,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TILE_PST_ERROR", Value=-3003)]
      TILE_PST_ERROR = -3003,
            
      [global::ProtoBuf.ProtoEnum(Name=@"RELOCATE_COND_RALLY_LIMIT", Value=-3004)]
      RELOCATE_COND_RALLY_LIMIT = -3004,
            
      [global::ProtoBuf.ProtoEnum(Name=@"RELOCATE_COND_MARCHING_LIMIT", Value=-3005)]
      RELOCATE_COND_MARCHING_LIMIT = -3005,
            
      [global::ProtoBuf.ProtoEnum(Name=@"RELOCATE_COND_MONUMENT_REINFORCE_LIMIT", Value=-3006)]
      RELOCATE_COND_MONUMENT_REINFORCE_LIMIT = -3006,
            
      [global::ProtoBuf.ProtoEnum(Name=@"RELOCATE_CITY_INTERNAL_ERROR", Value=-3007)]
      RELOCATE_CITY_INTERNAL_ERROR = -3007,
            
      [global::ProtoBuf.ProtoEnum(Name=@"RELOCATE_DOMINION_ALLIANCE_ERROR", Value=-3008)]
      RELOCATE_DOMINION_ALLIANCE_ERROR = -3008,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CANNOT_ASSIGN_HERO", Value=-3101)]
      CANNOT_ASSIGN_HERO = -3101,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HERO_NOT_IN_CITY", Value=-3102)]
      HERO_NOT_IN_CITY = -3102,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MARCH_TROOP_ERROR", Value=-3103)]
      MARCH_TROOP_ERROR = -3103,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MARCH_TYPE_ERROR", Value=-3104)]
      MARCH_TYPE_ERROR = -3104,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MARCH_PROG_LIMIT", Value=-3105)]
      MARCH_PROG_LIMIT = -3105,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MARCH_ARMY_CNT_LIMIT", Value=-3106)]
      MARCH_ARMY_CNT_LIMIT = -3106,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MARCH_ARMY_NOT_ENOUGH", Value=-3107)]
      MARCH_ARMY_NOT_ENOUGH = -3107,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CAN_NOT_OCCUPY", Value=-3108)]
      CAN_NOT_OCCUPY = -3108,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TILE_NOT_UPON_ALLIANCE", Value=-3109)]
      TILE_NOT_UPON_ALLIANCE = -3109,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CAN_NOT_OCCUPY_ALLIANCE_MEMBER", Value=-3110)]
      CAN_NOT_OCCUPY_ALLIANCE_MEMBER = -3110,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TILE_RUINS_CANT_OCCUPY", Value=-3111)]
      TILE_RUINS_CANT_OCCUPY = -3111,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MARCH_TIME_LIMIT", Value=-3112)]
      MARCH_TIME_LIMIT = -3112,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CAN_NOT_SCOUT_DUETO_LV", Value=-3113)]
      CAN_NOT_SCOUT_DUETO_LV = -3113,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CAN_NOT_SCOUT", Value=-3114)]
      CAN_NOT_SCOUT = -3114,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MARCH_CAN_NOT_SPEEDUP", Value=-3115)]
      MARCH_CAN_NOT_SPEEDUP = -3115,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MARCH_ID_ERROR", Value=-3116)]
      MARCH_ID_ERROR = -3116,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MARCH_CAN_NOT_RECALL", Value=-3117)]
      MARCH_CAN_NOT_RECALL = -3117,
            
      [global::ProtoBuf.ProtoEnum(Name=@"REBEL_NO_FOUND", Value=-3118)]
      REBEL_NO_FOUND = -3118,
            
      [global::ProtoBuf.ProtoEnum(Name=@"REBEL_POINT_NOT_ENOUGH", Value=-3119)]
      REBEL_POINT_NOT_ENOUGH = -3119,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INEXISTENCE_STYLE", Value=-3120)]
      INEXISTENCE_STYLE = -3120,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SHIELD_COND_ATKING_LIMIT", Value=-3121)]
      SHIELD_COND_ATKING_LIMIT = -3121,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SHIELD_COND_BE_REINFORCE_LIMIT", Value=-3122)]
      SHIELD_COND_BE_REINFORCE_LIMIT = -3122,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SHIELD_COND_REINFORCE_LIMIT", Value=-3123)]
      SHIELD_COND_REINFORCE_LIMIT = -3123,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SHIELD_COND_RALLY_LIMIT", Value=-3124)]
      SHIELD_COND_RALLY_LIMIT = -3124,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SHIELD_COND_BASE_TYPE_RUINS", Value=-3125)]
      SHIELD_COND_BASE_TYPE_RUINS = -3125,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SHIELD_COND_PRESEND_LIMIT", Value=-3126)]
      SHIELD_COND_PRESEND_LIMIT = -3126,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SHIELD_HAS_CAPTIVE_LIMIT", Value=-3127)]
      SHIELD_HAS_CAPTIVE_LIMIT = -3127,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CAN_NOT_REINFORCE", Value=-3128)]
      CAN_NOT_REINFORCE = -3128,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CAN_NOT_REINFORCE_BACK", Value=-3129)]
      CAN_NOT_REINFORCE_BACK = -3129,
            
      [global::ProtoBuf.ProtoEnum(Name=@"REINFORCE_CAPACITY_LIMIT", Value=-3130)]
      REINFORCE_CAPACITY_LIMIT = -3130,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BUILDING_CANT_MOVE", Value=-3131)]
      BUILDING_CANT_MOVE = -3131,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BUILDING_STATUS_ERR", Value=-3132)]
      BUILDING_STATUS_ERR = -3132,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BUILDING_INTER_ERR", Value=-3133)]
      BUILDING_INTER_ERR = -3133,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BUILDING_PROG_EXIST", Value=3134)]
      BUILDING_PROG_EXIST = 3134,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BUILDING_CANT_REMOVE", Value=3135)]
      BUILDING_CANT_REMOVE = 3135,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BUILDING_CANT_UPGRADE", Value=3136)]
      BUILDING_CANT_UPGRADE = 3136,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GROUP_NOT_EXIST", Value=-3137)]
      GROUP_NOT_EXIST = -3137,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TILE_NOT_YOUR_ALLIANCE", Value=-3138)]
      TILE_NOT_YOUR_ALLIANCE = -3138,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PVE_LEVEL_NOT_ENOUGH", Value=-3139)]
      PVE_LEVEL_NOT_ENOUGH = -3139,
            
      [global::ProtoBuf.ProtoEnum(Name=@"STYLE_TYPE_ERROR", Value=-3140)]
      STYLE_TYPE_ERROR = -3140,
            
      [global::ProtoBuf.ProtoEnum(Name=@"OCCUPY_CAPITAL_LIMIT", Value=-3141)]
      OCCUPY_CAPITAL_LIMIT = -3141,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CAPITAL_CANT_SET_TAX", Value=-3142)]
      CAPITAL_CANT_SET_TAX = -3142,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CAPITAL_SET_TAX_LIMIT", Value=-3143)]
      CAPITAL_SET_TAX_LIMIT = -3143,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MAIL_NOT_EXIST", Value=-4001)]
      MAIL_NOT_EXIST = -4001,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MAIL_ALREADY_SAVED", Value=-4002)]
      MAIL_ALREADY_SAVED = -4002,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MAIL_SAVE_FAIL", Value=-4003)]
      MAIL_SAVE_FAIL = -4003,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MAIL_DELETE_FAIL", Value=-4004)]
      MAIL_DELETE_FAIL = -4004,
            
      [global::ProtoBuf.ProtoEnum(Name=@"UNKNOW_FIGHT_REPORT", Value=-4021)]
      UNKNOW_FIGHT_REPORT = -4021,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BAD_FIGHT_REPORT", Value=-4022)]
      BAD_FIGHT_REPORT = -4022,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SHARE_FIGHT_REPORT_FAIL", Value=-4023)]
      SHARE_FIGHT_REPORT_FAIL = -4023,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CAN_NOT_SEND_RES_TO_HIDING_USER", Value=-4024)]
      CAN_NOT_SEND_RES_TO_HIDING_USER = -4024,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CAN_NOT_SEND", Value=-4025)]
      CAN_NOT_SEND = -4025,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TRADING_POST_UNLOCK_ERR", Value=-4026)]
      TRADING_POST_UNLOCK_ERR = -4026,
            
      [global::ProtoBuf.ProtoEnum(Name=@"RES_CNT_ERR", Value=-4027)]
      RES_CNT_ERR = -4027,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CAN_NOT_RALLY", Value=-4028)]
      CAN_NOT_RALLY = -4028,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BAD_RALLY_ID", Value=-4029)]
      BAD_RALLY_ID = -4029,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CAN_NOT_RALLY_REINFORCE", Value=-4030)]
      CAN_NOT_RALLY_REINFORCE = -4030,
            
      [global::ProtoBuf.ProtoEnum(Name=@"RALLY_REINFORCE_TROOP_LIMIT", Value=-4031)]
      RALLY_REINFORCE_TROOP_LIMIT = -4031,
            
      [global::ProtoBuf.ProtoEnum(Name=@"RALLY_REINFORCE_DUP_ERROR", Value=-4032)]
      RALLY_REINFORCE_DUP_ERROR = -4032,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BAD_EVENT_ID", Value=-4100)]
      BAD_EVENT_ID = -4100,
            
      [global::ProtoBuf.ProtoEnum(Name=@"USER_ALREADY_IN_ALLIANCE", Value=-5000)]
      USER_ALREADY_IN_ALLIANCE = -5000,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CREATE_ALLIANCE_NAME_ERROR", Value=-5001)]
      CREATE_ALLIANCE_NAME_ERROR = -5001,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CREATE_ALLIANCE_BUILDING_LEVEL_ERR", Value=-5002)]
      CREATE_ALLIANCE_BUILDING_LEVEL_ERR = -5002,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BAD_ALLIANCE_NAME", Value=-5003)]
      BAD_ALLIANCE_NAME = -5003,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ALLIANCE_NAME_EXIST", Value=-5004)]
      ALLIANCE_NAME_EXIST = -5004,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BAD_ALLIANCE_ABBR", Value=-5005)]
      BAD_ALLIANCE_ABBR = -5005,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ALLIANCE_ABBR_EXIST", Value=-5006)]
      ALLIANCE_ABBR_EXIST = -5006,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CREATE_ALLIANCE_ERROR", Value=-5007)]
      CREATE_ALLIANCE_ERROR = -5007,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BAD_ALLIANCE_ID", Value=-5008)]
      BAD_ALLIANCE_ID = -5008,
            
      [global::ProtoBuf.ProtoEnum(Name=@"YOU_ARE_ALLIANCE_RANK_OWNER", Value=-5009)]
      YOU_ARE_ALLIANCE_RANK_OWNER = -5009,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ALREADY_APPLY_JOIN_ALLIANCE", Value=-5010)]
      ALREADY_APPLY_JOIN_ALLIANCE = -5010,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ASMEMBER_SIZE_LIMIT_EXCEEDED", Value=-5011)]
      ASMEMBER_SIZE_LIMIT_EXCEEDED = -5011,
            
      [global::ProtoBuf.ProtoEnum(Name=@"USER_NOT_IN_ALLIANCE", Value=-5012)]
      USER_NOT_IN_ALLIANCE = -5012,
            
      [global::ProtoBuf.ProtoEnum(Name=@"JOIN_ALLIANCE_ERROR", Value=-5013)]
      JOIN_ALLIANCE_ERROR = -5013,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ALLIANCE_DONATE_LIMIT", Value=-5014)]
      ALLIANCE_DONATE_LIMIT = -5014,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HAS_REQUEST_HELP", Value=-5015)]
      HAS_REQUEST_HELP = -5015,
            
      [global::ProtoBuf.ProtoEnum(Name=@"NOT_IN_SAME_ALLIANCE", Value=-5016)]
      NOT_IN_SAME_ALLIANCE = -5016,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HELP_CAN_NOT_FIND", Value=-5017)]
      HELP_CAN_NOT_FIND = -5017,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ALREADY_HAS_OFFERED_HELP", Value=-5018)]
      ALREADY_HAS_OFFERED_HELP = -5018,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HELP_TIMES_EXCEEDED", Value=-5019)]
      HELP_TIMES_EXCEEDED = -5019,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ERROR_ALLIANCE_RANK", Value=-5500)]
      ERROR_ALLIANCE_RANK = -5500,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ERROR_ALLIANCE_LANG", Value=-5501)]
      ERROR_ALLIANCE_LANG = -5501,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ERROR_ALLIANCE_LOGO", Value=-5502)]
      ERROR_ALLIANCE_LOGO = -5502,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ERROR_ALLIANCE_DESC", Value=-5503)]
      ERROR_ALLIANCE_DESC = -5503,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ERROR_ALLIANCE_HEADLINE", Value=-5504)]
      ERROR_ALLIANCE_HEADLINE = -5504,
            
      [global::ProtoBuf.ProtoEnum(Name=@"NO_PROMOTE_PERMISSION", Value=-5505)]
      NO_PROMOTE_PERMISSION = -5505,
            
      [global::ProtoBuf.ProtoEnum(Name=@"NO_DEMOTE_PERMISSION", Value=-5506)]
      NO_DEMOTE_PERMISSION = -5506,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ALLIANCE_RANK_LIMIT_EXCEED", Value=-5507)]
      ALLIANCE_RANK_LIMIT_EXCEED = -5507,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ALLIANCE_R4_MUST_NO_SQUAD", Value=-5508)]
      ALLIANCE_R4_MUST_NO_SQUAD = -5508,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ALLIANCE_PERMISSION_ERROR", Value=-5509)]
      ALLIANCE_PERMISSION_ERROR = -5509,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BAD_ALLIANCE_TITLE", Value=-5510)]
      BAD_ALLIANCE_TITLE = -5510,
            
      [global::ProtoBuf.ProtoEnum(Name=@"NO_FOUND_ALLIANCE_GIFT", Value=-5511)]
      NO_FOUND_ALLIANCE_GIFT = -5511,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ALLIANCE_GIFT_EXPIRED", Value=-5512)]
      ALLIANCE_GIFT_EXPIRED = -5512,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ALREADY_APPLIED_ALLIANCE_RESOURCE", Value=-5513)]
      ALREADY_APPLIED_ALLIANCE_RESOURCE = -5513,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INVALID_ALLIANCE_RES_APPLY", Value=-5514)]
      INVALID_ALLIANCE_RES_APPLY = -5514,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ALLIANCE_RES_LIMIT", Value=-5515)]
      ALLIANCE_RES_LIMIT = -5515,
            
      [global::ProtoBuf.ProtoEnum(Name=@"NO_TRANSFER_PERMISSION", Value=-5516)]
      NO_TRANSFER_PERMISSION = -5516,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PLATFORM_SERVER_ERR", Value=-6001)]
      PLATFORM_SERVER_ERR = -6001,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PLATFORM_INVAILD_ACCESSTOKEN", Value=-6002)]
      PLATFORM_INVAILD_ACCESSTOKEN = -6002,
            
      [global::ProtoBuf.ProtoEnum(Name=@"LOCAL_SERVER_ERR", Value=-6003)]
      LOCAL_SERVER_ERR = -6003,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PLATFORM_DATA_ERR", Value=-6004)]
      PLATFORM_DATA_ERR = -6004,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PLATFORM_GET_URL_ERR", Value=-6005)]
      PLATFORM_GET_URL_ERR = -6005,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PUSH_SEND_ERR", Value=-6006)]
      PUSH_SEND_ERR = -6006,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PLATFORM_SEND_TYPE_ERR", Value=-6007)]
      PLATFORM_SEND_TYPE_ERR = -6007,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PLATFORM_SEND_RESP_ERR", Value=-6008)]
      PLATFORM_SEND_RESP_ERR = -6008,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PLATFORM_URL_PARSE_ERR", Value=-6009)]
      PLATFORM_URL_PARSE_ERR = -6009,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PLATFORM_SEND_STATUS_ERR", Value=-6010)]
      PLATFORM_SEND_STATUS_ERR = -6010,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PLATFORM_UNMARSHAL_ERR", Value=-6011)]
      PLATFORM_UNMARSHAL_ERR = -6011,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ACTIVITY_ALREADY_RW", Value=-6200)]
      ACTIVITY_ALREADY_RW = -6200,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ACTIVITY_NOT_CONFIG_RW", Value=-6201)]
      ACTIVITY_NOT_CONFIG_RW = -6201,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ACTIVITY_RW_TARGET_FAILED", Value=-6202)]
      ACTIVITY_RW_TARGET_FAILED = -6202,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ACTIVITY_DATE_ERROR", Value=-6203)]
      ACTIVITY_DATE_ERROR = -6203,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ACTIVITY_NUM_ERROR", Value=-6204)]
      ACTIVITY_NUM_ERROR = -6204,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ACTIVITY_NOT_CONFIG", Value=-6205)]
      ACTIVITY_NOT_CONFIG = -6205,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ACTIVITY_ALREADY", Value=-6206)]
      ACTIVITY_ALREADY = -6206,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ACTIVITY_NOT_CONDITIONS", Value=-6207)]
      ACTIVITY_NOT_CONDITIONS = -6207,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ACTIVITY_NOT_ID", Value=-6208)]
      ACTIVITY_NOT_ID = -6208,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ACTIVITY_PARAM_ERROR", Value=-6209)]
      ACTIVITY_PARAM_ERROR = -6209,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ACTIVITY_CARD_INVAILD", Value=-6210)]
      ACTIVITY_CARD_INVAILD = -6210,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ACTIVITY_CARD_REPEAT", Value=-6211)]
      ACTIVITY_CARD_REPEAT = -6211,
            
      [global::ProtoBuf.ProtoEnum(Name=@"KEY_NOT_FIND", Value=-6500)]
      KEY_NOT_FIND = -6500,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PARMS_NOT_ENOUGH", Value=-6501)]
      PARMS_NOT_ENOUGH = -6501,
            
      [global::ProtoBuf.ProtoEnum(Name=@"LANG_NOT_FIND", Value=-6502)]
      LANG_NOT_FIND = -6502,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GM_CMD_TURN_OFF", Value=-6503)]
      GM_CMD_TURN_OFF = -6503,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GM_CMD_NOT_EXIST", Value=-6504)]
      GM_CMD_NOT_EXIST = -6504,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GM_CMD_INVALID_PARAMS", Value=-6505)]
      GM_CMD_INVALID_PARAMS = -6505,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GM_CMD_INVALID_EXP", Value=-6506)]
      GM_CMD_INVALID_EXP = -6506,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GM_CMD_NOT_ENOUGH_PARAMS", Value=-6507)]
      GM_CMD_NOT_ENOUGH_PARAMS = -6507,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PVE_LEVEL_ID_ERROR", Value=-6801)]
      PVE_LEVEL_ID_ERROR = -6801,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PVE_NOT_CONFIG", Value=-6802)]
      PVE_NOT_CONFIG = -6802,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PVE_PRE_LEVEL_LIMIT", Value=-6803)]
      PVE_PRE_LEVEL_LIMIT = -6803,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PVE_REWARD_LIMIT", Value=-6804)]
      PVE_REWARD_LIMIT = -6804,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PVE_ALREADY_REWARD", Value=-6805)]
      PVE_ALREADY_REWARD = -6805,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PVE_FIGHT_ERROR_RESULT", Value=-6806)]
      PVE_FIGHT_ERROR_RESULT = -6806,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PVE_STAR_ERROR", Value=-6807)]
      PVE_STAR_ERROR = -6807,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PVP_NO_AVAILABLE_TIMES", Value=-6901)]
      PVP_NO_AVAILABLE_TIMES = -6901,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PVP_RANK_CHANGED", Value=-6902)]
      PVP_RANK_CHANGED = -6902,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PVP_MANOEUVRE_CLOSED", Value=-6903)]
      PVP_MANOEUVRE_CLOSED = -6903,
            
      [global::ProtoBuf.ProtoEnum(Name=@"BAD_MANOEUVRE_SHOP_ITEM_ID", Value=-6921)]
      BAD_MANOEUVRE_SHOP_ITEM_ID = -6921,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MANOEUVRE_NOT_ENOUGH_SCORE", Value=-6922)]
      MANOEUVRE_NOT_ENOUGH_SCORE = -6922,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MANOEUVRE_SHOP_BUY_LIMIT", Value=-6923)]
      MANOEUVRE_SHOP_BUY_LIMIT = -6923
    }
  
}