using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using RakNet;
public enum MessageID:short
{
ID_PLAYER_CHAT = 130,
ID_NEED_CRC_BEGIN, 
ID_PLAYER_STOP, 
ID_PLAYER_HURT, 
ID_PLAYER_HURT_RSP, 
ID_PLAYER_DEAD, 
ID_PLAYER_DEAD_RSP, 
ID_PLAYER_REVIVE, 
ID_PLAYER_REVIVE_RSP, 
ID_PLAYER_FIRE, 
ID_PLAYER_FIRE_RSP, 
ID_PLAYER_BULLET_NUM_RSP, 
ID_PLAYER_ATTACK, 
ID_PLAYER_ATTACK_RSP, 
ID_BATTLE_MONSTER_DROP, 
ID_BATTLE_PICKUP_ITEM, 
ID_BATTLE_PICKUP_ITEM_RSP, 
ID_BATTLE_DROP_RSP, 
ID_PLAYER_POSITION_SYNC, 
ID_PLAYER_POSITION_SYNC_RSP, 
ID_PLAYER_SKILL_ALARM, 
ID_PLAYER_SKILL_ALARM_RSP, 
ID_PLAYER_SKILL_BREAK_RSP, 
ID_PLAYER_SKILL, 
ID_PLAYER_SKILL_RSP, 
ID_SKILL_DAMAGE_RSP, 
ID_AI_SPAWN_RSP, 
ID_AI_MOVE_RSP, 
ID_AI_MONSTER_ACT_RSP, 
ID_AI_ATTACK_RSP, 
ID_PLAYER_BUFF_ATTR_RSP, 
ID_PLAYER_CHANGE_TANK, 
ID_PLAYER_CHANGE_TANK_RSP, 
ID_GAME_LOADCOMPLETE, 
ID_GAME_TIME_START_RSP, 
ID_PLAYER_TIMESTAMP, 
ID_PLAYER_TIMESTAMP_RSP, 
ID_PLAYER_EXIT_INSTANCE, 
ID_PLAYER_EXIT_INSTANCE_RSP, 
ID_BATTLE_SCORE, 
ID_LOBBY_ROOM_ENTERINFO_RSP, 
ID_TRAP_ENTER, 
ID_TRAP_LEAVE, 
ID_PLAYER_ATTR_CHANGE_RSP, 
ID_BATTLE_OBJECT_CREATE_RSP, 
ID_BATTLE_MOVE_RSP, 
ID_BATTLE_POS_RSP, 
ID_BATTLESERVER_END, 
ID_PLAYER_GET_USERID, 
ID_PLAYER_GET_USERID_RSP, 
ID_PLAYER_DISCONNECT, 
ID_LOBBY_LINE, 
ID_LOBBY_LINE_RSP, 
ID_LOBBY_ROOM, 
ID_LOBBY_ROOM_RSP, 
ID_LOBBY_CREATE_ROOM, 
ID_LOBBY_CREATE_ROOM_RSP, 
ID_LOBBY_ROOM_QUICK_JOIN, 
ID_LOBBY_ROOM_QUICK_JOIN_RSP, 
ID_LOBBY_ROOM_JOIN, 
ID_LOBBY_ROOM_JOIN_RSP, 
ID_LOBBY_ROOM_CHANGE_TANK_RSP, 
ID_LOBBY_ROOM_INVITE, 
ID_LOBBY_ROOM_INVITE_RSP, 
ID_LOBBY_ROOM_EXIT, 
ID_LOBBY_ROOM_EXIT_RSP, 
ID_LOBBY_ROOM_CHANGE, 
ID_LOBBY_ROOM_CHANGE_RSP, 
ID_LOBBY_ROOM_READY, 
ID_LOBBY_ROOM_READY_RSP, 
ID_LOBBY_ROOM_START, 
ID_GAME_FINSIHED_RSP, 
ID_PLAYER_LOGIN, 
ID_PLAYER_CREATE_ROLE, 
ID_PLAYER_LOGIN_FINISHED_RSP, 
ID_PLAYER_REPEATED_LOGIN_RSP, 
ID_PLAYER_DETAIL_INFO_RSP, 
ID_PLAYER_LOGINOUT, 
ID_PLAYER_LOGINOUT_RSP, 
ID_PLAYER_PVE_LEVELINFOS, 
ID_PLAYER_PVE_LEVELINFOS_RSP, 
ID_PLAYER_PVE_START, 
ID_PLAYER_PVE_START_RSP, 
ID_PLAYER_PVE_RESULT, 
ID_PLAYER_PVE_RESULT_RSP, 
ID_PLAYER_INFO_CHANGE_RSP, 
ID_WAREHOUSE_TANK_LIST, 
ID_WAREHOUSE_TANK_LIST_RSP, 
ID_WAREHOUSE_TANK_DETAIL_INFO, 
ID_WAREHOUSE_TANK_DETAIL_INFO_RSP, 
ID_WAREHOUSE_TANK_ADD_EXP, 
ID_WAREHOUSE_TANK_ADD_EXP_RSP, 
ID_WAREHOUSE_TANK_RANK_UP, 
ID_WAREHOUSE_TANK_RANK_UP_RSP, 
ID_WAREHOUSE_TANK_EQUIP_LVLUP, 
ID_WAREHOUSE_TANK_EQUIP_LVLUP_RSP, 
ID_ITEM_LIST, 
ID_ITEM_LIST_RSP, 
ID_BATTLE_SCORE_RSP, 
ID_PVP_BATTLE_CHAOS_FINISHED_RSP, 
ID_PLAYER_ACTIVE, 
ID_GM_MSG, 
ID_MAIL_NEW_COMING_RSP, 
ID_BATLLESERVER_IP_RSP, 
ID_BATTLE_TO_LOGIC_INIT, 
ID_LOGIC_TO_BATTLE_INIT_FINISHED, 
ID_LOGIC_TO_BATTLE_START, 
ID_BATTLE_TO_LOGIC_FINISHED, 
ID_LOGIC_TO_BATTLE_EXIT_BATTLE, 
ID_BATTLE_TO_LOGIC_PLAYER_REVIVE, 
ID_BATTLE_TO_LOGIC_LOAD_COMPLETE, 
ID_ERROR_RSP, 
ID_BATTLE_TO_LOGIC_PLAYER_STATE, 
ID_BATTLE_TO_LOGIC_PPVE_FINISH, 
ID_MULTI_COMMAND = 249,
ID_PROTOBUF_MSG = 250,
ID_GAMESERVER_RSP = 251,
ID_RECONNECT_SET_IP = 252,
ID_SUBMSG_BEGIN = 255,
}
public enum SubMessageID:short
{
SUB_ID_LOG_OUT, 
SUB_ID_LOG_OUT_RSP, 
SUB_ID_PAIL_LIST_RSP, 
SUB_ID_PAIL_HIT, 
SUB_ID_PAIL_HIT_RSP, 
SUB_ID_TORNADO_EFFECT, 
SUB_ID_TORNADO_EFFECT_RSP, 
SUB_ID_SYNC_PLAYER_LOAD, 
SUB_ID_SYNC_PLAYER_LOAD_RSP, 
SUB_ID_BATTLE_GET_BATTLEINFO, 
SUB_ID_BATTLESERVER_END, 
SUB_ID_ITEM_USE, 
SUB_ID_ITEM_USE_RSP, 
SUB_ID_ITEM_SELL, 
SUB_ID_ITEM_SELL_RSP, 
SUB_ID_PILOT_LIST, 
SUB_ID_PILOT_LIST_RSP, 
SUB_ID_PILOT_DETAIL_INFO, 
SUB_ID_PILOT_DETAIL_INFO_RSP, 
SUB_ID_PILOT_ADD_EXP, 
SUB_ID_PILOT_ADD_EXP_RSP, 
SUB_ID_PILOT_RANK_UP, 
SUB_ID_PILOT_RANK_UP_RSP, 
SUB_ID_PILOT_MAJOR_LVLUP, 
SUB_ID_PILOT_MAJOR_LVLUP_RSP, 
SUB_ID_EXCHANGE, 
SUB_ID_EXCHANGE_RSP, 
SUB_ID_TANK_SETTING, 
SUB_ID_TANK_SETTING_RSP, 
SUB_ID_TANK_SETTING_UNLOCK_SOCKET, 
SUB_ID_TANK_SETTING_UNLOCK_SOCKET_RSP, 
SUB_ID_NOTIFY_MESSAGE_RSP, 
SUB_ID_CHAT, 
SUB_ID_CHAT_RSP, 
SUB_ID_LOBBY_EXIT, 
SUB_ID_EMOTION, 
SUB_ID_EMOTION_RSP, 
SUB_ID_TASK_LIST, 
SUB_ID_TASK_LIST_RSP, 
SUB_ID_TASK_GET, 
SUB_ID_TASK_GET_RSP, 
SUB_ID_TASK_FINISHED_RSP, 
SUB_ID_ACTIVE_REWARD, 
SUB_ID_ACTIVE_REWARD_RSP, 
SUB_ID_ACTIVE_GOTTEN_RSP, 
SUB_ID_PLAYER_PPVE_TASK_COMPLETE_RSP, 
SUB_ID_PLAYER_PPVE_TASK_LIST_RSP, 
SUB_ID_PLAYER_PPVE_MATCH, 
SUB_ID_TEST_BOSS_SKILL_RSP, 
SUB_ID_PROFESSOR_LIST, 
SUB_ID_PROFESSOR_LIST_RSP, 
SUB_ID_FRIEND_GET_FRIENDS_LIST, 
SUB_ID_FRIEND_GET_FRIENDS_LIST_RSP, 
SUB_ID_FRIEND_GET_FRIENDSREQ_LIST, 
SUB_ID_FRIEND_GET_FRIENDSREQ_LIST_RSP, 
SUB_ID_FRIEND_ADD, 
SUB_ID_FRIEND_ADD_RSP, 
SUB_ID_FRIEND_REQUEST, 
SUB_ID_FRIEND_REQUEST_RSP, 
SUB_ID_FRIEND_DELETE, 
SUB_ID_FRIEND_DELETE_RSP, 
SUB_ID_FRIEND_MODIFY_LINESTATUS_RSP, 
SUB_ID_FRIEND_MODIFY_LEVEL_RSP, 
SUB_ID_FRIEND_MODIFY_ICON_RSP, 
SUB_ID_FRIEND_BATCH_ADD, 
SUB_ID_FRIEND_BATCH_ADD_RSP, 
SUB_ID_WAREHOUSE_TANK_STAR_UP, 
SUB_ID_WAREHOUSE_TANK_STAR_UP_RSP, 
SUB_ID_ACTIVE_PILOT, 
SUB_ID_WAREHOUSE_TANK_SKILL_RESET, 
SUB_ID_WAREHOUSE_TANK_SKILL_RESET_RSP, 
SUB_ID_WAREHOUSE_TACTIC_PAGE, 
SUB_ID_WAREHOUSE_TACTIC_PAGE_RSP, 
SUB_ID_WAREHOUSE_TACTIC_PAGE_LSIT, 
SUB_ID_WAREHOUSE_TACTIC_PAGE_LSIT_RSP, 
SUB_ID_WAREHOUSE_TACTIC_UP_RUNE, 
SUB_ID_WAREHOUSE_TACTIC_UP_RUNE_RSP, 
SUB_ID_WAREHOUSE_TACTIC_DOWN_RUNE, 
SUB_ID_WAREHOUSE_TACTIC_DOWN_RUNE_RSP, 
SUB_ID_WAREHOUSE_TACTIC_UNLOCK_SOCKET, 
SUB_ID_WAREHOUSE_TACTIC_UNLOCK_SOCKET_RSP, 
SUB_ID_WAREHOUSE_TACTIC_SET_NAME, 
SUB_ID_WAREHOUSE_TACTIC_SET_NAME_RSP, 
SUB_ID_WAREHOUSE_TACTIC_DOWN_ALL_RUNE, 
SUB_ID_WAREHOUSE_TACTIC_DOWN_ALL_RUNE_RSP, 
SUB_ID_WAREHOUSE_TACTIC_DECOMPOSE, 
SUB_ID_WAREHOUSE_TACTIC_DECOMPOSE_RSP, 
SUB_ID_WAREHOUSE_TACTIC_COMPOSE, 
SUB_ID_WAREHOUSE_TACTIC_COMPOSE_RSP, 
SUB_ID_OPEN_FUNCTION_RSP, 
SUB_ID_CONSUME, 
SUB_ID_CONSUME_RSP, 
SUB_ID_TUTORIAL_MODIFY, 
SUB_ID_TUTORIAL_RSP, 
SUB_ID_TUTORIAL_IGNORE, 
SUB_ID_WAREHOUSE_TANK_SPLIT, 
SUB_ID_WAREHOUSE_TANK_SPLIT_RSP, 
SUB_ID_PLAYER_SELECT_HEAD, 
SUB_ID_PLAYER_SELECT_HEAD_RSP, 
SUB_ID_PPVE_TEAM_OVER_RSP, 
SUB_ID_PLAYER_ELO_MATCH, 
SUB_ID_PLAYER_ELO_MATCH_RSP, 
SUB_ID_PLAYER_ELO_MATCH_CANCEL, 
SUB_ID_PLAYER_ELO_MATCH_CANCEL_RSP, 
SUB_ID_PLAYER_ELO_MATCH_LOCK_RSP, 
SUB_ID_PLAYER_ELO_MATCH_RESETROOM_RSP, 
SUB_ID_ASK_PLAYER_INFO, 
SUB_ID_ASK_PLAYER_INFO_RSP, 
SUB_ID_ASK_PLAYER_RECORD, 
SUB_ID_ASK_PLAYER_RECORD_RSP, 
SUB_ID_BATTLE_CAPTURE_FLAG_SCORE_RSP, 
SUB_ID_BATTLE_KILL_PEOPLE_RSP, 
SUB_ID_PLAYER_PASSIVE_SKILL_RSP, 
SUB_ID_USESKILL_RSP, 
SUB_ID_PPVE_CHALLENGE_RESULT_RSP, 
}
public enum ProtoVersion{
ProtoVersion_ID 	= 2041,
}
public enum ServerErrorCode{
ERROR_SYSTEM_PROTOVERSION_DIFFERENT = 1,
ERROR_SYSTEM_UNKNOWN = 100,
ERROR_LOGIN_NOUSER = 101 ,
ERROR_LOGIN_NAME_EXISTS = 102,
ERROR_LOGIN_DIRTYWORD_EXISTS = 103,
ERROR_LOGIN_PLAYER_ONLINE = 104,
ERROR_LOGIN_KICKOFF_PLAYER = 105,

ERROR_PLAYER_OFFLINE	= 106,
ERROR_PLAYER_LESS_ENERGY	= 108,
ERROR_PLAYER_LESS_DIAMOND	= 110,
ERROR_LOBBY_ROOM_NOT_READY = 200,

ERROR_PVE_NULL_LEVEL = 300,
ERROR_PVP_LOBBY_NULL = 301,
ERROR_PVP_ROOM_NOT_EXIST = 302,
ERROR_PVP_ROOM_IN_BATTLE = 303,
ERROR_PVP_ROOM_FULL = 304,
ERROR_PVP_ROOM_ALARMING = 305,

ERROR_FRIEND_DELETE_SUCCESS = 400,
ERROR_FRIEND_LIST_NULL = 401,
ERROR_FRIEND_REQLIST_NULL = 402,
ERROR_FRIEND_NOT_EXIST = 403,
ERROR_FRIEND_EXIST = 404,
ERROR_FRIEND_REQ_EXIST = 405,
ERROR_FRIEND_COUNT_MAX = 406,
ERROR_FRIEND_REQUEST_TIMEOUT = 410,
ERROR_FRIEND_ADD_SELF  = 411,
ERROR_FRIEND_REQUEST_SUCCESS = 6001,

ERROR_LEVELUP_LESS_MATERIAL = 501,
ERROR_PILOT_ACTIVED 		= 502,
ERROR_PILOT_CANT_ACTIVE		= 503,

ERROR_CHAT_TEAM_IS_FULL	= 601,
ERROR_CHAT_ROOM_DETAIL_FAILED	= 602,
ERROR_CHAT_LESS_LEVEL_ENTER_ROOM	= 603,
ERROR_CHAT_ROOM_ISNOT_OPEN	= 604,

ERROR_DAILY_TASK_NOT_FINISHED	= 701,
ERROR_DAILY_TASK_HAS_GOTTEN		= 702,
ERROR_DAILY_TASK_NOT_EXIST		= 703,
ERROR_MAIN_TASK_NOT_FINISHED	= 731,
ERROR_MAIN_TASK_HAS_GOTTEN		= 732,
ERROR_MAIN_TASK_NOT_EXIST		= 733,
ERROR_ACTIVE_LESS				= 761,
ERROR_ACTIVE_HAS_GOTTEN			= 762,

ERROR_ASSISTANT					= 805,

ERROR_FRIEND_REQ_SELF_COUNT_MAX = 3003,
ERROR_FRIEND_RES_SELF_COUNT_MAX = 3004,
ERROR_FRIEND_RES_OTHER_COUNT_MAX = 3005,
}
public enum ChangeAttr{
ATTR_COIN			= 0,
ATTR_GOLD			= 1,
ATTR_DIAMOND		= 2,
ATTR_ENERGY			= 3,
ATTR_EXP			= 4,
ATTR_ACTIVE			= 5,
ATTR_HONOR			= 6,
ATTR_LEVEL			= 7,
ATTR_BUYGOLDTIMES	= 8,
ATTR_BUYENERGYTIMES = 9,

ATTR_TANK_HP			= 10,
ATTR_TANK_ATTMIN		= 11,
ATTR_TANK_ATTMAX		= 12,
ATTR_TANK_AC1			= 13,
ATTR_TANK_AC2			= 14,
ATTR_TANK_AC3			= 15,
ATTR_TANK_AC4			= 16,
ATTR_TANK_AC5			= 17,
ATTR_TANK_AC6			= 18,
ATTR_TANK_SPEED			= 19,
ATTR_TANK_CANNON_ROT_SPEED	= 20,
ATTR_TANK_ROT_SPEED		= 21,
ATTR_TANK_CRIT			= 22,
ATTR_TANK_IMMCRIT		= 23,
ATTR_TANK_RICOCHET		= 24,
ATTR_TANK_PENETRATE		= 25,
ATTR_TANK_REPLACE_SPEED		= 26,
ATTR_TANK_CRITICAL_HIT		= 27,
ATTR_TANK_FORT_HIT		= 28,
ATTR_TANK_CANNON_PRECISION_MAX	= 29,
ATTR_TANK_CANNON_PRECISION_MIN	= 30,
ATTR_TANK_SIGHT_SPEED		= 31,
ATTR_TANK_CANNON_SPEED		= 32,
ATTR_TANK_TRACKING_RANGE	= 33,
ATTR_TANK_CD			= 34,
ATTR_SIGHT_RANGE		= 35,
ATTR_ADD_DAMAGE_LIGHT		= 36,
ATTR_ADD_DAMAGE_MID			= 37,
ATTR_ADD_DAMAGE_HEAVY		= 38,
ATTR_DEC_DAMAGE_LIGHT		= 39,
ATTR_DEC_DAMAGE_MID			= 40,
ATTR_DEC_DAMAGE_HEAVY		= 41,
ATTR_TANK_ARMOR				= 42,
ATTR_TANK_ViewCof			= 43,
ATTR_TANK_ANGER				= 44,
ATTR_TANK_POWER				= 45,
ATTR_TANK_CURR_HP			= 46,
ATTR_TANK_CURR_POWER			= 47,
ATTR_TANK_CURR_ANGER			= 48,
ATTR_TANK_End				= 49,


ATTR_TANK_CAN_FIRE		= 196,
ATTR_TANK_CAN_AIMING		= 197,
ATTR_TANK_INVINCIBLE		= 198,
ATTR_TANK_SLIENT		= 199,
ATTR_STRATEGYPOTIN		= 200,

ATTR_DEXP				= 201,
ATTR_REXP				= 202,
ATTR_YEXP				= 203,
ATTR_SEXP				= 204,
ATTR_MEXP				= 205,
ATTR_GLOBAL_EXP				= 206,

ATTR_RECHARGE6			= 240,
ATTR_RECHARGE30			= 241,
ATTR_RECHARGE68			= 242,
ATTR_RECHARGE128		= 243,
ATTR_RECHARGE328		= 244,
ATTR_RECHARGE648		= 245,

ATTR_RMB				= 250,
ATTR_RECHARGE			= 251,
ATTR_ARMORPOINT			= 252,
ATTR_RECHARGERMB		= 253,
ATTR_MONTHCARD25		= 254,


ATTR_TANK_ADD_ATTACK			= 1001,
ATTR_TANK_ADD_ATTACK_PERCENT	= 1002,
ATTR_TANK_ADD_PRECISION			= 1003,
ATTR_TANK_DEC_CD  				= 1004,
ATTR_TANK_ADD_ATTACK_LIGHT		= 1005,
ATTR_TANK_ADD_ATTACK_MID		= 1006,
ATTR_TANK_ADD_ATTACK_HEAVY		= 1007,
ATTR_TANK_ADD_HP_PERCENT		= 1008,
ATTR_TANK_ADD_RANGE				= 1009,
}
public enum PvEModeType{
PvEMode_Normal = 0,
PvEMode_EndLess,
PvEMode_Boss,
}
public enum MailType{
MailType_Unknown = 0,
MailType_System,
MailType_Reward,

MailType_Max = 255,
}
public enum MailStatus{
MailStatus_Unread,
MailStatus_Read,
MailStatus_Got,
MailStatus_Delete,
}
public enum FriendReqStatus{
FRStatus_UnHandle = 0,
FRStatus_Accept,
FRStatus_Refuse,
}
public enum FriendReqType{
FRType_Initiative = 0,
FRType_Positive,
}
public enum FriendLineStatus{
FLStatus_Offline = 0,
FLStatus_Online,
FLStatus_Room,
FLStatus_Instance,
FLStatus_Fighting,
}
public enum NotifyMsgID{
NotifyMsgID_Battle_Kill_Three 			= 50001,
NotifyMsgID_Battle_Kill_Four			= 50002,
NotifyMsgID_Battle_Kill_Five			= 50003,
NotifyMsgID_Battle_Kill_Six				= 50004,
NotifyMsgID_Battle_Kill_Seven			= 50005,
NotifyMsgID_Battle_Kill_Eight			= 50006,
NotifyMsgID_Battle_Kill_Nine			= 50007,
NotifyMsgID_Battle_Kill_Ten				= 50008,
NotifyMsgID_Battle_Champion				= 50009,
NotifyMsgID_Battle_Second				= 50010,
NotifyMsgID_Battle_Third				= 50011,
NotifyMsgID_Battle_Exit_Room			= 50012,
NotifyMsgID_Battle_Got_Title			= 60001,
NotifyMsgID_Battle_Kill_People			= 60002,
NotifyMsgID_Battle_Help_Other_Revive	= 60004,
NotifyMsgID_Battle_First_Kill_People	= 60006,
NotifyMsgID_Battle_Quick_Notify			= 70001,
NotifyMsgID_Battle_Quick_Talk			= 70002,
NotifyMsgID_Battle_Drop_Item			= 60008,
}
public enum TRoomChangeKey{
CHANGE_MAP,
CHANGE_PLAYER_NUM,
CHANGE_OWNER,
CHANGE_PASSWARD,
CHANGE_SIDE,
}
public enum Channel{
Channel_World,
Channel_Lobby,
Channel_Room,
Channel_Battlefield,
Channel_Team,
Channel_Whisper,
Channel_Alliance,
Channel_MainUI,
Channel_Corps,
}
public enum TaskType{
TaskType_Daily	= 0,
TaskType_Main	= 1,
}
public enum ItemFrom{
NONE = 0,
DB = 1,
TASK_AWARD_ACTIVITY = 2,
TASK_AWARD_COMPLETE = 3,
MAIL = 4,
PVE = 5,
PVP = 6,
STRATEGY = 7,
GM = 8,
ITEM_EXCHANGE = 9,
TANK_SPLIT = 10,
LUA = 11,
USE = 12,
ACTIVITY_COMPLETE = 13,
SHOPBUY = 14,
DAILYSIGN = 15,
STAGINGPOST = 16,
TURNTABLE_GOLD_FREE = 17,
TURNTABLE_GOLD_ONCE = 18,
TURNTABLE_GOLD_TEN = 19,
TURNTABLE_DIAMOND_FREE = 20,
TURNTABLE_DIAMOND_ONCE = 21,
TURNTABLE_DIAMOND_TEN = 22,
TANK_REPEAT = 23,
CORPS = 24,
PILOT_DECLARE_LOVE = 25,
DAILY_TASK_AWARD_COMPLETE = 26,
MAIN_TASK_AWARD_COMPLETE = 27,
INVITE = 28,
TANKCHEST = 29,
TANKCHEST_TEN = 30,
SUPER_TANKCHEST = 31,
SUPER_TANKCHEST_TEN = 32,
SUPER_BULLET = 33,
COATING = 34,
FINISH_ASSIGN = 35,
}
public enum TankFrom{
TANK_FROM_NONE = 0,
TANK_FROM_DB,
TANK_FROM_AI_TEMPLATE,
TANK_FROM_LUA,
TANK_FROM_GM,
}
public enum ERecordItemType{
JoinTime = 0,
WinTime,
LoseTime,
EscapeTime,
KillTankNum,
AssistTime,
DeadTime,
HighestDamage,
DailyKill,
}
public enum EPlayerRecord{
level = 0,
headid,
exp,
pilot_count_sum,
tank_count_sum,
}
public enum KillPeopleType{
KILL_PEOPLE_TYPE_NONE = 0,
KILL_PEOPLE_TYPE_COMMON,
KILL_PEOPLE_TYPE_REVENGE,
KILL_PEOPLE_TYPE_FIRST,
}
public enum BattlefieldHonorAward{
BATTLEFIELD_HONOR_AWARD_NONE = 0,
BATTLEFIELD_HONOR_AWARD_BANNER = 1,
BATTLEFIELD_HONOR_AWARD_MVP = 2,
BATTLEFIELD_HONOR_AWARD_ASSISTANT = 4,
}
public enum AIMoveE{
AI_MOVE,
AI_STOP,
AI_TRACK,
AI_WALK_BACKOF_OBSTACLE
}
public enum AIAttackE{
AI_ATT_NOR,
AI_ATT_SKI,
AI_MONSTER_NOR,
AI_MONSTER_SKI
}
public enum RoomType{
RoomType_None	= 0,
RoomType_PVE,
RoomType_PVP,
RoomType_Match,
RoomType_PVE_TmpMatch,
RoomType_PVP_TmpMatch,
RoomType_PVP_Union,
RoomType_PVP_TmpUnion,
RoomType_PVP_Props,
RoomType_PVP_TmpProps,
}
public enum TankDetailChange{
TankDetailChangeInit = 0,
TankDetailChangeTempId,
TankDetailChangeRank,
TankDetailChangeLvl,
TankDetailChangeExp,
TankDetailChangeEquip,
}
public enum PilotDetailChange{
PilotDetailChangeInit = 0,
PilotDetailChangeTempId,
PilotDetailChangeRank,
PilotDetailChangeLvl,
PilotDetailChangeExp,
PilotDetailChangeMajor,
PilotDetailChangeActiveSkill,
PilotDetailChangePassiveSkill,
}
public class UInteger : IData
{
public uint value;
public UInteger(uint value)
{
this.value = value;
}
}
public class PlayerHurtInfo : IData
{
public uint attackUserID;
public uint defendUserID;
public ushort hurtValue;
public uint timestamp;
public PlayerHurtInfo(uint attackUserID,uint defendUserID,ushort hurtValue,uint timestamp)
{
this.attackUserID = attackUserID;
this.defendUserID = defendUserID;
this.hurtValue = hurtValue;
this.timestamp = timestamp;
}
}
public class PlayerAttackInfo : IData
{
public uint target;
public bool hitTurret;
public byte hitArea;
public byte percent;
public short x;
public short y;
public short z;
public PlayerAttackInfo(uint target,bool hitTurret,byte hitArea,byte percent,short x,short y,short z)
{
this.target = target;
this.hitTurret = hitTurret;
this.hitArea = hitArea;
this.percent = percent;
this.x = x;
this.y = y;
this.z = z;
}
}
public class PlayerAttackInfoRsp : IData
{
public uint target;
public byte shootType;
public bool hitTurret;
public byte hitArea;
public byte percent;
public short x;
public short y;
public short z;
public int damage;
public int hp;
public ushort rage;
public PlayerAttackInfoRsp(uint target,byte shootType,bool hitTurret,byte hitArea,byte percent,short x,short y,short z,int damage,int hp,ushort rage)
{
this.target = target;
this.shootType = shootType;
this.hitTurret = hitTurret;
this.hitArea = hitArea;
this.percent = percent;
this.x = x;
this.y = y;
this.z = z;
this.damage = damage;
this.hp = hp;
this.rage = rage;
}
}
public class DropItem : IData
{
public uint itemID;
public DropItem(uint itemID)
{
this.itemID = itemID;
}
}
public class HurtInfo : IData
{
public uint target;
public uint key;
public int value;
public HurtInfo(uint target,uint key,int value)
{
this.target = target;
this.key = key;
this.value = value;
}
}
public class Point : IData
{
public ushort x;
public ushort y;
public Point(ushort x,ushort y)
{
this.x = x;
this.y = y;
}
}
public class AIEntityInfo : IData
{
public byte AIType;
public uint AIInsID;
public uint bindUserid;
public uint aiId;
public byte group;
public ushort tankTempId;
public byte tankRank;
public int x;
public int y;
public int z;
public uint timestamp;
public AIEntityInfo(byte AIType,uint AIInsID,uint bindUserid,uint aiId,byte group,ushort tankTempId,byte tankRank,int x,int y,int z,uint timestamp)
{
this.AIType = AIType;
this.AIInsID = AIInsID;
this.bindUserid = bindUserid;
this.aiId = aiId;
this.group = group;
this.tankTempId = tankTempId;
this.tankRank = tankRank;
this.x = x;
this.y = y;
this.z = z;
this.timestamp = timestamp;
}
}
public class AIPathArea : IData
{
public uint tarX;
public uint tarZ;
public ushort radius;
public AIPathArea(uint tarX,uint tarZ,ushort radius)
{
this.tarX = tarX;
this.tarZ = tarZ;
this.radius = radius;
}
}
public class AIAttack : IData
{
public uint tarId;
public uint skillId;
public AIAttack(uint tarId,uint skillId)
{
this.tarId = tarId;
this.skillId = skillId;
}
}
public class BuffKeyValue : IData
{
public ushort key;
public uint value;
public BuffKeyValue(ushort key,uint value)
{
this.key = key;
this.value = value;
}
}
public class PlayerEnterRoomRsp : IData
{
public uint bindUID;
public uint userid;
public byte group;
public ushort x;
public ushort y;
public ushort z;
public ushort rot;
public ushort cd;
public ushort speed;
public ushort vision;
public ushort viewCof;
public ushort cannonPrecisionMax;
public ushort cannonPrecisionMin;
public uint hp;
public ushort rageMax;
public ushort rage;
public PlayerEnterRoomRsp(uint bindUID,uint userid,byte group,ushort x,ushort y,ushort z,ushort rot,ushort cd,ushort speed,ushort vision,ushort viewCof,ushort cannonPrecisionMax,ushort cannonPrecisionMin,uint hp,ushort rageMax,ushort rage)
{
this.bindUID = bindUID;
this.userid = userid;
this.group = group;
this.x = x;
this.y = y;
this.z = z;
this.rot = rot;
this.cd = cd;
this.speed = speed;
this.vision = vision;
this.viewCof = viewCof;
this.cannonPrecisionMax = cannonPrecisionMax;
this.cannonPrecisionMin = cannonPrecisionMin;
this.hp = hp;
this.rageMax = rageMax;
this.rage = rage;
}
}
public class AttrKeyValue : IData
{
public ushort attr;
public uint value;
public uint userID;
public AttrKeyValue(ushort attr,uint value,uint userID)
{
this.attr = attr;
this.value = value;
this.userID = userID;
}
}
public class BattleObject : IData
{
public byte objID;
public byte tableID;
public short x;
public short y;
public short z;
public BattleObject(byte objID,byte tableID,short x,short y,short z)
{
this.objID = objID;
this.tableID = tableID;
this.x = x;
this.y = y;
this.z = z;
}
}
public class LobbyLine : IData
{
public uint lobbyID;
public byte flag;
public byte percent;
public LobbyLine(uint lobbyID,byte flag,byte percent)
{
this.lobbyID = lobbyID;
this.flag = flag;
this.percent = percent;
}
}
public class LobbyRoom : IData
{
public uint roomID;
public byte index;
public byte type;
public bool isPassword;
public bool opened;
public uint battleID;
public byte maxPlayer;
public byte currPlayer;
public RakNet.RakString name;
public LobbyRoom(uint roomID,byte index,byte type,bool isPassword,bool opened,uint battleID,byte maxPlayer,byte currPlayer,RakNet.RakString name)
{
this.roomID = roomID;
this.index = index;
this.type = type;
this.isPassword = isPassword;
this.opened = opened;
this.battleID = battleID;
this.maxPlayer = maxPlayer;
this.currPlayer = currPlayer;
this.name = name;
}
}
public class RoomPlayerInfo : IData
{
public uint userID;
public bool isHost;
public bool isReady;
public byte group;
public byte index;
public RakNet.RakString userName;
public ushort tankID;
public byte tankSubid;
public ushort pilotAId;
public byte pilotASubid;
public ushort pilotBId;
public byte pilotBSubid;
public ushort pilotCId;
public byte pilotCSubid;
public ushort lv;
public ushort head;
public uint coatingId;
public uint matchGroupId;
public RakNet.RakString corpsName;
public RakNet.RakString corpsLvName;
public uint decortionPos1;
public uint decortionPos2;
public uint decortionPos3;
public uint decortionPos4;
public uint decortionPos5;
public uint decortionPos6;
public uint decortionPos7;
public uint killRank;
public uint corpsKillRank;
public RoomPlayerInfo(uint userID,bool isHost,bool isReady,byte group,byte index,RakNet.RakString userName,ushort tankID,byte tankSubid,ushort pilotAId,byte pilotASubid,ushort pilotBId,byte pilotBSubid,ushort pilotCId,byte pilotCSubid,ushort lv,ushort head,uint coatingId,uint matchGroupId,RakNet.RakString corpsName,RakNet.RakString corpsLvName,uint decortionPos1,uint decortionPos2,uint decortionPos3,uint decortionPos4,uint decortionPos5,uint decortionPos6,uint decortionPos7,uint killRank,uint corpsKillRank)
{
this.userID = userID;
this.isHost = isHost;
this.isReady = isReady;
this.group = group;
this.index = index;
this.userName = userName;
this.tankID = tankID;
this.tankSubid = tankSubid;
this.pilotAId = pilotAId;
this.pilotASubid = pilotASubid;
this.pilotBId = pilotBId;
this.pilotBSubid = pilotBSubid;
this.pilotCId = pilotCId;
this.pilotCSubid = pilotCSubid;
this.lv = lv;
this.head = head;
this.coatingId = coatingId;
this.matchGroupId = matchGroupId;
this.corpsName = corpsName;
this.corpsLvName = corpsLvName;
this.decortionPos1 = decortionPos1;
this.decortionPos2 = decortionPos2;
this.decortionPos3 = decortionPos3;
this.decortionPos4 = decortionPos4;
this.decortionPos5 = decortionPos5;
this.decortionPos6 = decortionPos6;
this.decortionPos7 = decortionPos7;
this.killRank = killRank;
this.corpsKillRank = corpsKillRank;
}
}
public class RoomReadyInfo : IData
{
public uint userid;
public bool isReady;
public RoomReadyInfo(uint userid,bool isReady)
{
this.userid = userid;
this.isReady = isReady;
}
}
public class PlayerDetailInfo : IData
{
public byte type;
public uint hp;
public RakNet.RakString name;
public uint exp;
public ushort level;
public byte gender;
public uint gold;
public ushort energy;
public uint diamond;
public byte rank;
public uint rankLevel;
public uint active;
public uint honor;
public uint buyGoldTimes;
public uint buyEnergyTimes;
public bool ignoreTutorial;
public uint avatarid;
public uint strategypoint;
public uint dexp;
public uint rexp;
public uint yexp;
public uint sexp;
public uint mexp;
public uint globalExp;
public uint country;
public uint touchneedtime;
public byte touchremaincount;
public uint recharge;
public uint corpsid;
public uint armorpoint;
public uint recharge6;
public uint recharge30;
public uint recharge68;
public uint recharge128;
public uint recharge328;
public uint recharge648;
public uint monthCard25;
public uint invite;
public PlayerDetailInfo(byte type,uint hp,RakNet.RakString name,uint exp,ushort level,byte gender,uint gold,ushort energy,uint diamond,byte rank,uint rankLevel,uint active,uint honor,uint buyGoldTimes,uint buyEnergyTimes,bool ignoreTutorial,uint avatarid,uint strategypoint,uint dexp,uint rexp,uint yexp,uint sexp,uint mexp,uint globalExp,uint country,uint touchneedtime,byte touchremaincount,uint recharge,uint corpsid,uint armorpoint,uint recharge6,uint recharge30,uint recharge68,uint recharge128,uint recharge328,uint recharge648,uint monthCard25,uint invite)
{
this.type = type;
this.hp = hp;
this.name = name;
this.exp = exp;
this.level = level;
this.gender = gender;
this.gold = gold;
this.energy = energy;
this.diamond = diamond;
this.rank = rank;
this.rankLevel = rankLevel;
this.active = active;
this.honor = honor;
this.buyGoldTimes = buyGoldTimes;
this.buyEnergyTimes = buyEnergyTimes;
this.ignoreTutorial = ignoreTutorial;
this.avatarid = avatarid;
this.strategypoint = strategypoint;
this.dexp = dexp;
this.rexp = rexp;
this.yexp = yexp;
this.sexp = sexp;
this.mexp = mexp;
this.globalExp = globalExp;
this.country = country;
this.touchneedtime = touchneedtime;
this.touchremaincount = touchremaincount;
this.recharge = recharge;
this.corpsid = corpsid;
this.armorpoint = armorpoint;
this.recharge6 = recharge6;
this.recharge30 = recharge30;
this.recharge68 = recharge68;
this.recharge128 = recharge128;
this.recharge328 = recharge328;
this.recharge648 = recharge648;
this.monthCard25 = monthCard25;
this.invite = invite;
}
}
public class TankDetailInfo : IData
{
public byte name;
public byte academy;
public byte quality;
public ushort level;
public byte advance;
public uint life;
public ushort leastAtk;
public ushort maxAtk;
public ushort speed;
public ushort speedOfWhirlFort;
public ushort speedOfWhirlTank;
public uint crit;
public uint tough;
public uint ricochet;
public uint penetrate;
public ushort reload;
public uint critHit;
public uint turretHit;
public ushort leastAccuracy;
public ushort maxAccuracy;
public ushort aimSpeed;
public ushort bulletSpeed;
public ushort targetScope;
public ushort leadership;
public ushort leadershipAddition;
public TankDetailInfo(byte name,byte academy,byte quality,ushort level,byte advance,uint life,ushort leastAtk,ushort maxAtk,ushort speed,ushort speedOfWhirlFort,ushort speedOfWhirlTank,uint crit,uint tough,uint ricochet,uint penetrate,ushort reload,uint critHit,uint turretHit,ushort leastAccuracy,ushort maxAccuracy,ushort aimSpeed,ushort bulletSpeed,ushort targetScope,ushort leadership,ushort leadershipAddition)
{
this.name = name;
this.academy = academy;
this.quality = quality;
this.level = level;
this.advance = advance;
this.life = life;
this.leastAtk = leastAtk;
this.maxAtk = maxAtk;
this.speed = speed;
this.speedOfWhirlFort = speedOfWhirlFort;
this.speedOfWhirlTank = speedOfWhirlTank;
this.crit = crit;
this.tough = tough;
this.ricochet = ricochet;
this.penetrate = penetrate;
this.reload = reload;
this.critHit = critHit;
this.turretHit = turretHit;
this.leastAccuracy = leastAccuracy;
this.maxAccuracy = maxAccuracy;
this.aimSpeed = aimSpeed;
this.bulletSpeed = bulletSpeed;
this.targetScope = targetScope;
this.leadership = leadership;
this.leadershipAddition = leadershipAddition;
}
}
public class DriverDetailInfo : IData
{
public ushort name;
public byte academy;
public byte quality;
public ushort level;
public byte advance;
public DriverDetailInfo(ushort name,byte academy,byte quality,ushort level,byte advance)
{
this.name = name;
this.academy = academy;
this.quality = quality;
this.level = level;
this.advance = advance;
}
}
public class PlayerHeadInfo : IData
{
public uint headinfos;
public PlayerHeadInfo(uint headinfos)
{
this.headinfos = headinfos;
}
}
public class LevelBasicInfo : IData
{
public uint levelid;
public uint tankid;
public byte modetype;
public byte times;
public byte stars;
public LevelBasicInfo(uint levelid,uint tankid,byte modetype,byte times,byte stars)
{
this.levelid = levelid;
this.tankid = tankid;
this.modetype = modetype;
this.times = times;
this.stars = stars;
}
}
public class PVEDropItemCount : IData
{
public bool isFirst;
public uint itemid;
public uint count;
public PVEDropItemCount(bool isFirst,uint itemid,uint count)
{
this.isFirst = isFirst;
this.itemid = itemid;
this.count = count;
}
}
public class PlayerInfoChangeRsp : IData
{
public byte changeid;
public uint curValue;
public uint value1;
public uint value2;
public PlayerInfoChangeRsp(byte changeid,uint curValue,uint value1,uint value2)
{
this.changeid = changeid;
this.curValue = curValue;
this.value1 = value1;
this.value2 = value2;
}
}
public class WarehouseTankInfo : IData
{
public ushort tankId;
public ushort tankTempId;
public byte tankRank;
public byte tankLvl;
public uint tankExp;
public WarehouseTankInfo(ushort tankId,ushort tankTempId,byte tankRank,byte tankLvl,uint tankExp)
{
this.tankId = tankId;
this.tankTempId = tankTempId;
this.tankRank = tankRank;
this.tankLvl = tankLvl;
this.tankExp = tankExp;
}
}
public class WarehouseTankDetailInfo : IData
{
public ushort tankId;
public ushort tankTempId;
public byte tankRank;
public byte tankLvl;
public uint tankExp;
public byte equipALvl;
public byte equipBLvl;
public byte equipCLvl;
public byte equipDLvl;
public byte equipELvl;
public ushort pilotAId;
public ushort pilotBId;
public ushort pilotCId;
public ushort pilotDId;
public ushort pilotEId;
public uint professorId;
public uint skillId;
public uint useTimes;
public uint devExp;
public uint skillResetTimes;
public WarehouseTankDetailInfo(ushort tankId,ushort tankTempId,byte tankRank,byte tankLvl,uint tankExp,byte equipALvl,byte equipBLvl,byte equipCLvl,byte equipDLvl,byte equipELvl,ushort pilotAId,ushort pilotBId,ushort pilotCId,ushort pilotDId,ushort pilotEId,uint professorId,uint skillId,uint useTimes,uint devExp,uint skillResetTimes)
{
this.tankId = tankId;
this.tankTempId = tankTempId;
this.tankRank = tankRank;
this.tankLvl = tankLvl;
this.tankExp = tankExp;
this.equipALvl = equipALvl;
this.equipBLvl = equipBLvl;
this.equipCLvl = equipCLvl;
this.equipDLvl = equipDLvl;
this.equipELvl = equipELvl;
this.pilotAId = pilotAId;
this.pilotBId = pilotBId;
this.pilotCId = pilotCId;
this.pilotDId = pilotDId;
this.pilotEId = pilotEId;
this.professorId = professorId;
this.skillId = skillId;
this.useTimes = useTimes;
this.devExp = devExp;
this.skillResetTimes = skillResetTimes;
}
}
public class TankExpMaterial : IData
{
public byte type;
public uint id;
public byte num;
public TankExpMaterial(byte type,uint id,byte num)
{
this.type = type;
this.id = id;
this.num = num;
}
}
public class ItemInfo : IData
{
public uint itemId;
public uint itemNum;
public ItemInfo(uint itemId,uint itemNum)
{
this.itemId = itemId;
this.itemNum = itemNum;
}
}
public class PVPScoreInfo : IData
{
public uint userID;
public byte tankID;
public byte tankType;
public int hurt;
public byte kill;
public uint honor;
public byte dead;
public uint point;
public uint freeReviveCount;
public uint expendReviveCount;
public uint assistant;
public uint award;
public uint vip;
public uint extraItemID;
public uint extraItemCount;
public PVPScoreInfo(uint userID,byte tankID,byte tankType,int hurt,byte kill,uint honor,byte dead,uint point,uint freeReviveCount,uint expendReviveCount,uint assistant,uint award,uint vip,uint extraItemID,uint extraItemCount)
{
this.userID = userID;
this.tankID = tankID;
this.tankType = tankType;
this.hurt = hurt;
this.kill = kill;
this.honor = honor;
this.dead = dead;
this.point = point;
this.freeReviveCount = freeReviveCount;
this.expendReviveCount = expendReviveCount;
this.assistant = assistant;
this.award = award;
this.vip = vip;
this.extraItemID = extraItemID;
this.extraItemCount = extraItemCount;
}
}
public class PilotFavor : IData
{
public uint id;
public uint favor;
public PilotFavor(uint id,uint favor)
{
this.id = id;
this.favor = favor;
}
}
public class Pail : IData
{
public uint idx;
public uint tid;
public uint blood;
public short x;
public short y;
public short z;
public Pail(uint idx,uint tid,uint blood,short x,short y,short z)
{
this.idx = idx;
this.tid = tid;
this.blood = blood;
this.x = x;
this.y = y;
this.z = z;
}
}
public class StateData : IData
{
public uint playerid;
public byte state;
public StateData(uint playerid,byte state)
{
this.playerid = playerid;
this.state = state;
}
}
public class PilotInfo : IData
{
public ushort pilotId;
public ushort pilotTempId;
public byte pilotRank;
public byte pilotLvl;
public uint pilotExp;
public PilotInfo(ushort pilotId,ushort pilotTempId,byte pilotRank,byte pilotLvl,uint pilotExp)
{
this.pilotId = pilotId;
this.pilotTempId = pilotTempId;
this.pilotRank = pilotRank;
this.pilotLvl = pilotLvl;
this.pilotExp = pilotExp;
}
}
public class PilotDetailInfo : IData
{
public ushort pilotId;
public ushort pilotTempId;
public byte pilotRank;
public byte pilotLvl;
public uint pilotExp;
public byte major1Lvl;
public byte major2Lvl;
public byte major3Lvl;
public byte major4Lvl;
public byte major5Lvl;
public uint activeSkill;
public uint passiveSkill;
public uint perfessionSkill;
public uint activeSkillexp;
public uint passiveSkillexp;
public uint perfessionSkillexp;
public ushort favorPoint;
public PilotDetailInfo(ushort pilotId,ushort pilotTempId,byte pilotRank,byte pilotLvl,uint pilotExp,byte major1Lvl,byte major2Lvl,byte major3Lvl,byte major4Lvl,byte major5Lvl,uint activeSkill,uint passiveSkill,uint perfessionSkill,uint activeSkillexp,uint passiveSkillexp,uint perfessionSkillexp,ushort favorPoint)
{
this.pilotId = pilotId;
this.pilotTempId = pilotTempId;
this.pilotRank = pilotRank;
this.pilotLvl = pilotLvl;
this.pilotExp = pilotExp;
this.major1Lvl = major1Lvl;
this.major2Lvl = major2Lvl;
this.major3Lvl = major3Lvl;
this.major4Lvl = major4Lvl;
this.major5Lvl = major5Lvl;
this.activeSkill = activeSkill;
this.passiveSkill = passiveSkill;
this.perfessionSkill = perfessionSkill;
this.activeSkillexp = activeSkillexp;
this.passiveSkillexp = passiveSkillexp;
this.perfessionSkillexp = perfessionSkillexp;
this.favorPoint = favorPoint;
}
}
public class PilotExpMaterial : IData
{
public byte type;
public uint id;
public byte num;
public PilotExpMaterial(byte type,uint id,byte num)
{
this.type = type;
this.id = id;
this.num = num;
}
}
public class TankSetting : IData
{
public byte settingIdx;
public ushort tankId;
public ushort pilotAId;
public ushort pilotBId;
public ushort pilotCId;
public ushort pilotDId;
public ushort pilotEId;
public uint professorId;
public TankSetting(byte settingIdx,ushort tankId,ushort pilotAId,ushort pilotBId,ushort pilotCId,ushort pilotDId,ushort pilotEId,uint professorId)
{
this.settingIdx = settingIdx;
this.tankId = tankId;
this.pilotAId = pilotAId;
this.pilotBId = pilotBId;
this.pilotCId = pilotCId;
this.pilotDId = pilotDId;
this.pilotEId = pilotEId;
this.professorId = professorId;
}
}
public class NotifyMsg : IData
{
public uint paramInt;
public RakNet.RakString paramStr;
public NotifyMsg(uint paramInt,RakNet.RakString paramStr)
{
this.paramInt = paramInt;
this.paramStr = paramStr;
}
}
public class TaskInfo : IData
{
public uint ID;
public uint counter;
public uint time;
public bool isFinished;
public bool isGotten;
public TaskInfo(uint ID,uint counter,uint time,bool isFinished,bool isGotten)
{
this.ID = ID;
this.counter = counter;
this.time = time;
this.isFinished = isFinished;
this.isGotten = isGotten;
}
}
public class PlayerPPVETaskInfo : IData
{
public uint group;
public byte complete;
public PlayerPPVETaskInfo(uint group,byte complete)
{
this.group = group;
this.complete = complete;
}
}
public class ProfessorDetailInfo : IData
{
public uint id;
public uint templateId;
public byte level;
public ProfessorDetailInfo(uint id,uint templateId,byte level)
{
this.id = id;
this.templateId = templateId;
this.level = level;
}
}
public class FriendBasicInfo : IData
{
public uint fid;
public ushort flevel;
public uint lastofflinetime;
public byte lineStatus;
public RakNet.RakString fname;
public uint icon;
public RakNet.RakString corpsname;
public RakNet.RakString lvname;
public FriendBasicInfo(uint fid,ushort flevel,uint lastofflinetime,byte lineStatus,RakNet.RakString fname,uint icon,RakNet.RakString corpsname,RakNet.RakString lvname)
{
this.fid = fid;
this.flevel = flevel;
this.lastofflinetime = lastofflinetime;
this.lineStatus = lineStatus;
this.fname = fname;
this.icon = icon;
this.corpsname = corpsname;
this.lvname = lvname;
}
}
public class FriendReqBasicInfo : IData
{
public uint fid;
public ushort flevel;
public byte type;
public byte status;
public RakNet.RakString fname;
public uint icon;
public FriendReqBasicInfo(uint fid,ushort flevel,byte type,byte status,RakNet.RakString fname,uint icon)
{
this.fid = fid;
this.flevel = flevel;
this.type = type;
this.status = status;
this.fname = fname;
this.icon = icon;
}
}
public class TacticSocket : IData
{
public int socketitem;
public TacticSocket(int socketitem)
{
this.socketitem = socketitem;
}
}
public class Tutorial : IData
{
public uint id;
public bool isFinished;
public Tutorial(uint id,bool isFinished)
{
this.id = id;
this.isFinished = isFinished;
}
}
public class RecordData : IData
{
public uint key;
public uint value;
public RecordData(uint key,uint value)
{
this.key = key;
this.value = value;
}
}
public class ServerSkillData : IData
{
public short x;
public short y;
public short z;
public uint skillID;
public ushort delayTime;
public ServerSkillData(short x,short y,short z,uint skillID,ushort delayTime)
{
this.x = x;
this.y = y;
this.z = z;
this.skillID = skillID;
this.delayTime = delayTime;
}
}

public class ID_PLAYER_STOP : IData
{
public uint instanceID;
public int x;
public int z;
public uint y;
public byte dura;
public uint timestamp;
public ID_PLAYER_STOP(uint instanceID,int x,int z,uint y,byte dura,uint timestamp)
{
this.instanceID = instanceID;
this.x = x;
this.z = z;
this.y = y;
this.dura = dura;
this.timestamp = timestamp;
}
}
public class ID_PLAYER_HURT : IData
{
public uint instanceID;
public uint defendUserID;
public ushort hurtValue;
public uint timestamp;
public ID_PLAYER_HURT(uint instanceID,uint defendUserID,ushort hurtValue,uint timestamp)
{
this.instanceID = instanceID;
this.defendUserID = defendUserID;
this.hurtValue = hurtValue;
this.timestamp = timestamp;
}
}
public class ID_PLAYER_DEAD : IData
{
public uint instanceID;
public uint timestamp;
public ID_PLAYER_DEAD(uint instanceID,uint timestamp)
{
this.instanceID = instanceID;
this.timestamp = timestamp;
}
}
public class ID_PLAYER_DEAD_RSP : IData
{
public uint userID;
public byte reviveInterval;
public uint timestamp;
public ID_PLAYER_DEAD_RSP(uint userID,byte reviveInterval,uint timestamp)
{
this.userID = userID;
this.reviveInterval = reviveInterval;
this.timestamp = timestamp;
}
}
public class ID_PLAYER_REVIVE : IData
{
public uint instanceID;
public uint aiID;
public uint timestamp;
public uint consumeType;
public ID_PLAYER_REVIVE(uint instanceID,uint aiID,uint timestamp,uint consumeType)
{
this.instanceID = instanceID;
this.aiID = aiID;
this.timestamp = timestamp;
this.consumeType = consumeType;
}
}
public class ID_PLAYER_REVIVE_RSP : IData
{
public uint userID;
public uint timestamp;
public short x;
public short y;
public short z;
public ID_PLAYER_REVIVE_RSP(uint userID,uint timestamp,short x,short y,short z)
{
this.userID = userID;
this.timestamp = timestamp;
this.x = x;
this.y = y;
this.z = z;
}
}
public class ID_PLAYER_FIRE : IData
{
public uint aiID;
public uint instanceID;
public byte type;
public byte bulletID;
public byte bulletNum;
public short dirX;
public short dirY;
public short dirZ;
public ushort gravity;
public ushort speed;
public uint timestamp;
public short x;
public short y;
public short z;
public ID_PLAYER_FIRE(uint aiID,uint instanceID,byte type,byte bulletID,byte bulletNum,short dirX,short dirY,short dirZ,ushort gravity,ushort speed,uint timestamp,short x,short y,short z)
{
this.aiID = aiID;
this.instanceID = instanceID;
this.type = type;
this.bulletID = bulletID;
this.bulletNum = bulletNum;
this.dirX = dirX;
this.dirY = dirY;
this.dirZ = dirZ;
this.gravity = gravity;
this.speed = speed;
this.timestamp = timestamp;
this.x = x;
this.y = y;
this.z = z;
}
}
public class ID_PLAYER_FIRE_RSP : IData
{
public uint attacker;
public byte type;
public byte bulletID;
public short dirX;
public short dirY;
public short dirZ;
public ushort gravity;
public ushort speed;
public uint timestamp;
public short x;
public short y;
public short z;
public ID_PLAYER_FIRE_RSP(uint attacker,byte type,byte bulletID,short dirX,short dirY,short dirZ,ushort gravity,ushort speed,uint timestamp,short x,short y,short z)
{
this.attacker = attacker;
this.type = type;
this.bulletID = bulletID;
this.dirX = dirX;
this.dirY = dirY;
this.dirZ = dirZ;
this.gravity = gravity;
this.speed = speed;
this.timestamp = timestamp;
this.x = x;
this.y = y;
this.z = z;
}
}
public class ID_PLAYER_BULLET_NUM_RSP : IData
{
public byte bulletID;
public byte bulletNum;
public ID_PLAYER_BULLET_NUM_RSP(byte bulletID,byte bulletNum)
{
this.bulletID = bulletID;
this.bulletNum = bulletNum;
}
}
public class ID_BATTLE_MONSTER_DROP : IData
{
public uint instanceID;
public short x;
public short y;
public short z;
public int monsterID;
public ID_BATTLE_MONSTER_DROP(uint instanceID,short x,short y,short z,int monsterID)
{
this.instanceID = instanceID;
this.x = x;
this.y = y;
this.z = z;
this.monsterID = monsterID;
}
}
public class ID_BATTLE_PICKUP_ITEM : IData
{
public uint instanceID;
public uint userid;
public byte index;
public ID_BATTLE_PICKUP_ITEM(uint instanceID,uint userid,byte index)
{
this.instanceID = instanceID;
this.userid = userid;
this.index = index;
}
}
public class ID_BATTLE_PICKUP_ITEM_RSP : IData
{
public uint instanceID;
public uint owner;
public byte index;
public ID_BATTLE_PICKUP_ITEM_RSP(uint instanceID,uint owner,byte index)
{
this.instanceID = instanceID;
this.owner = owner;
this.index = index;
}
}
public class ID_PLAYER_POSITION_SYNC : IData
{
public uint aiID;
public uint instanceID;
public int x;
public int y;
public int z;
public int dirX;
public int dirY;
public int dirZ;
public int angle;
public uint timestamp;
public ushort speed;
public bool isReverse;
public sbyte angleDir;
public ID_PLAYER_POSITION_SYNC(uint aiID,uint instanceID,int x,int y,int z,int dirX,int dirY,int dirZ,int angle,uint timestamp,ushort speed,bool isReverse,sbyte angleDir)
{
this.aiID = aiID;
this.instanceID = instanceID;
this.x = x;
this.y = y;
this.z = z;
this.dirX = dirX;
this.dirY = dirY;
this.dirZ = dirZ;
this.angle = angle;
this.timestamp = timestamp;
this.speed = speed;
this.isReverse = isReverse;
this.angleDir = angleDir;
}
}
public class ID_PLAYER_POSITION_SYNC_RSP : IData
{
public uint userid;
public int x;
public int y;
public int z;
public int dirX;
public int dirY;
public int dirZ;
public int angle;
public uint timestamp;
public ushort speed;
public bool isReverse;
public sbyte angleDir;
public ID_PLAYER_POSITION_SYNC_RSP(uint userid,int x,int y,int z,int dirX,int dirY,int dirZ,int angle,uint timestamp,ushort speed,bool isReverse,sbyte angleDir)
{
this.userid = userid;
this.x = x;
this.y = y;
this.z = z;
this.dirX = dirX;
this.dirY = dirY;
this.dirZ = dirZ;
this.angle = angle;
this.timestamp = timestamp;
this.speed = speed;
this.isReverse = isReverse;
this.angleDir = angleDir;
}
}
public class ID_PLAYER_SKILL_ALARM : IData
{
public uint instanceID;
public uint aiID;
public uint skillID;
public int x;
public int z;
public int y;
public ID_PLAYER_SKILL_ALARM(uint instanceID,uint aiID,uint skillID,int x,int z,int y)
{
this.instanceID = instanceID;
this.aiID = aiID;
this.skillID = skillID;
this.x = x;
this.z = z;
this.y = y;
}
}
public class ID_PLAYER_SKILL_ALARM_RSP : IData
{
public uint skillID;
public uint attacker;
public int x;
public int z;
public int y;
public ID_PLAYER_SKILL_ALARM_RSP(uint skillID,uint attacker,int x,int z,int y)
{
this.skillID = skillID;
this.attacker = attacker;
this.x = x;
this.z = z;
this.y = y;
}
}
public class ID_PLAYER_SKILL_BREAK_RSP : IData
{
public uint skillID;
public uint attacker;
public ID_PLAYER_SKILL_BREAK_RSP(uint skillID,uint attacker)
{
this.skillID = skillID;
this.attacker = attacker;
}
}
public class ID_AI_MONSTER_ACT_RSP : IData
{
public uint aiId;
public byte type;
public ushort duration;
public short x;
public short y;
public short z;
public ID_AI_MONSTER_ACT_RSP(uint aiId,byte type,ushort duration,short x,short y,short z)
{
this.aiId = aiId;
this.type = type;
this.duration = duration;
this.x = x;
this.y = y;
this.z = z;
}
}
public class ID_PLAYER_CHANGE_TANK : IData
{
public ushort tankIndex;
public ushort pilotIndex;
public ID_PLAYER_CHANGE_TANK(ushort tankIndex,ushort pilotIndex)
{
this.tankIndex = tankIndex;
this.pilotIndex = pilotIndex;
}
}
public class ID_PLAYER_CHANGE_TANK_RSP : IData
{
public uint userID;
public ushort tankID;
public byte tankSubid;
public byte tankLv;
public ushort pilotID;
public byte pilotSubid;
public ID_PLAYER_CHANGE_TANK_RSP(uint userID,ushort tankID,byte tankSubid,byte tankLv,ushort pilotID,byte pilotSubid)
{
this.userID = userID;
this.tankID = tankID;
this.tankSubid = tankSubid;
this.tankLv = tankLv;
this.pilotID = pilotID;
this.pilotSubid = pilotSubid;
}
}
public class ID_GAME_TIME_START_RSP : IData
{
public uint timestamp;
public byte interval;
public ID_GAME_TIME_START_RSP(uint timestamp,byte interval)
{
this.timestamp = timestamp;
this.interval = interval;
}
}
public class ID_PLAYER_TIMESTAMP : IData
{
public uint timestamp;
public bool reconnect;
public ID_PLAYER_TIMESTAMP(uint timestamp,bool reconnect)
{
this.timestamp = timestamp;
this.reconnect = reconnect;
}
}
public class ID_PLAYER_TIMESTAMP_RSP : IData
{
public int diff;
public ID_PLAYER_TIMESTAMP_RSP(int diff)
{
this.diff = diff;
}
}
public class ID_PLAYER_EXIT_INSTANCE : IData
{
public uint instanceID;
public ID_PLAYER_EXIT_INSTANCE(uint instanceID)
{
this.instanceID = instanceID;
}
}
public class ID_PLAYER_EXIT_INSTANCE_RSP : IData
{
public uint userID;
public ID_PLAYER_EXIT_INSTANCE_RSP(uint userID)
{
this.userID = userID;
}
}
public class ID_BATTLE_SCORE : IData
{
public uint instanceID;
public ID_BATTLE_SCORE(uint instanceID)
{
this.instanceID = instanceID;
}
}
public class ID_TRAP_ENTER : IData
{
public uint instanceID;
public ushort objID;
public ID_TRAP_ENTER(uint instanceID,ushort objID)
{
this.instanceID = instanceID;
this.objID = objID;
}
}
public class ID_TRAP_LEAVE : IData
{
public uint instanceID;
public ushort objID;
public ID_TRAP_LEAVE(uint instanceID,ushort objID)
{
this.instanceID = instanceID;
this.objID = objID;
}
}
public class ID_BATTLE_MOVE_RSP : IData
{
public uint id;
public ushort duration;
public short x;
public short z;
public uint timestamp;
public ID_BATTLE_MOVE_RSP(uint id,ushort duration,short x,short z,uint timestamp)
{
this.id = id;
this.duration = duration;
this.x = x;
this.z = z;
this.timestamp = timestamp;
}
}
public class ID_BATTLE_POS_RSP : IData
{
public uint id;
public short x;
public short z;
public ID_BATTLE_POS_RSP(uint id,short x,short z)
{
this.id = id;
this.x = x;
this.z = z;
}
}
public class ID_PLAYER_GET_USERID : IData
{
public uint channelUserid;
public byte channelID;
public ID_PLAYER_GET_USERID(uint channelUserid,byte channelID)
{
this.channelUserid = channelUserid;
this.channelID = channelID;
}
}
public class ID_PLAYER_GET_USERID_RSP : IData
{
public uint userID;
public byte svrID;
public byte type;
public ID_PLAYER_GET_USERID_RSP(uint userID,byte svrID,byte type)
{
this.userID = userID;
this.svrID = svrID;
this.type = type;
}
}
public class ID_PLAYER_DISCONNECT : IData
{
public uint instanceID;
public ushort roomID;
public ID_PLAYER_DISCONNECT(uint instanceID,ushort roomID)
{
this.instanceID = instanceID;
this.roomID = roomID;
}
}
public class ID_LOBBY_ROOM : IData
{
public uint lobbyID;
public byte type;
public byte begin;
public byte end;
public ID_LOBBY_ROOM(uint lobbyID,byte type,byte begin,byte end)
{
this.lobbyID = lobbyID;
this.type = type;
this.begin = begin;
this.end = end;
}
}
public class ID_LOBBY_CREATE_ROOM : IData
{
public byte roomType;
public uint battleID;
public ID_LOBBY_CREATE_ROOM(byte roomType,uint battleID)
{
this.roomType = roomType;
this.battleID = battleID;
}
}
public class ID_LOBBY_CREATE_ROOM_RSP : IData
{
public byte roomType;
public uint roomID;
public uint battleID;
public ID_LOBBY_CREATE_ROOM_RSP(byte roomType,uint roomID,uint battleID)
{
this.roomType = roomType;
this.roomID = roomID;
this.battleID = battleID;
}
}
public class ID_LOBBY_ROOM_QUICK_JOIN : IData
{
public uint lobbyID;
public ID_LOBBY_ROOM_QUICK_JOIN(uint lobbyID)
{
this.lobbyID = lobbyID;
}
}
public class ID_LOBBY_ROOM_QUICK_JOIN_RSP : IData
{
public int roomID;
public ID_LOBBY_ROOM_QUICK_JOIN_RSP(int roomID)
{
this.roomID = roomID;
}
}
public class ID_LOBBY_ROOM_JOIN : IData
{
public ushort lobbyID;
public ushort roomID;
public ID_LOBBY_ROOM_JOIN(ushort lobbyID,ushort roomID)
{
this.lobbyID = lobbyID;
this.roomID = roomID;
}
}
public class ID_LOBBY_ROOM_CHANGE_TANK_RSP : IData
{
public uint userID;
public ushort tankID;
public byte tankSubid;
public ushort pilotAId;
public ushort pilotBId;
public ushort pilotCId;
public ID_LOBBY_ROOM_CHANGE_TANK_RSP(uint userID,ushort tankID,byte tankSubid,ushort pilotAId,ushort pilotBId,ushort pilotCId)
{
this.userID = userID;
this.tankID = tankID;
this.tankSubid = tankSubid;
this.pilotAId = pilotAId;
this.pilotBId = pilotBId;
this.pilotCId = pilotCId;
}
}
public class ID_LOBBY_ROOM_INVITE : IData
{
public byte serverID;
public uint inviteUserid;
public byte roomType;
public uint battleID;
public ID_LOBBY_ROOM_INVITE(byte serverID,uint inviteUserid,byte roomType,uint battleID)
{
this.serverID = serverID;
this.inviteUserid = inviteUserid;
this.roomType = roomType;
this.battleID = battleID;
}
}
public class ID_LOBBY_ROOM_INVITE_RSP : IData
{
public byte serverID;
public uint userID;
public byte lobbyID;
public ushort roomID;
public byte roomType;
public uint battleID;
public ID_LOBBY_ROOM_INVITE_RSP(byte serverID,uint userID,byte lobbyID,ushort roomID,byte roomType,uint battleID)
{
this.serverID = serverID;
this.userID = userID;
this.lobbyID = lobbyID;
this.roomID = roomID;
this.roomType = roomType;
this.battleID = battleID;
}
}
public class ID_LOBBY_ROOM_EXIT : IData
{
public uint userID;
public uint roomID;
public ID_LOBBY_ROOM_EXIT(uint userID,uint roomID)
{
this.userID = userID;
this.roomID = roomID;
}
}
public class ID_LOBBY_ROOM_EXIT_RSP : IData
{
public uint userID;
public ID_LOBBY_ROOM_EXIT_RSP(uint userID)
{
this.userID = userID;
}
}
public class ID_LOBBY_ROOM_CHANGE : IData
{
public uint key;
public uint value;
public ID_LOBBY_ROOM_CHANGE(uint key,uint value)
{
this.key = key;
this.value = value;
}
}
public class ID_LOBBY_ROOM_CHANGE_RSP : IData
{
public uint key;
public uint value;
public uint value2;
public uint value3;
public ID_LOBBY_ROOM_CHANGE_RSP(uint key,uint value,uint value2,uint value3)
{
this.key = key;
this.value = value;
this.value2 = value2;
this.value3 = value3;
}
}
public class ID_LOBBY_ROOM_READY : IData
{
public bool isReady;
public ID_LOBBY_ROOM_READY(bool isReady)
{
this.isReady = isReady;
}
}
public class ID_LOBBY_ROOM_START : IData
{
public uint battleID;
public ID_LOBBY_ROOM_START(uint battleID)
{
this.battleID = battleID;
}
}
public class ID_PLAYER_LOGIN : IData
{
public uint userid;
public ushort channelID;
public RakNet.RakString device;
public uint protoVersion;
public RakNet.RakString token;
public ID_PLAYER_LOGIN(uint userid,ushort channelID,RakNet.RakString device,uint protoVersion,RakNet.RakString token)
{
this.userid = userid;
this.channelID = channelID;
this.device = device;
this.protoVersion = protoVersion;
this.token = token;
}
}
public class ID_PLAYER_CREATE_ROLE : IData
{
public uint userID;
public RakNet.RakString name;
public byte gender;
public uint avatarID;
public uint pilotID;
public byte pilotSubID;
public ID_PLAYER_CREATE_ROLE(uint userID,RakNet.RakString name,byte gender,uint avatarID,uint pilotID,byte pilotSubID)
{
this.userID = userID;
this.name = name;
this.gender = gender;
this.avatarID = avatarID;
this.pilotID = pilotID;
this.pilotSubID = pilotSubID;
}
}
public class ID_PLAYER_PVE_LEVELINFOS : IData
{
public byte modetype;
public ID_PLAYER_PVE_LEVELINFOS(byte modetype)
{
this.modetype = modetype;
}
}
public class ID_PLAYER_PVE_START : IData
{
public uint levelid;
public ID_PLAYER_PVE_START(uint levelid)
{
this.levelid = levelid;
}
}
public class ID_PLAYER_PVE_START_RSP : IData
{
public uint energy;
public ID_PLAYER_PVE_START_RSP(uint energy)
{
this.energy = energy;
}
}
public class ID_PLAYER_PVE_RESULT : IData
{
public uint levelid;
public byte modetype;
public bool isWin;
public uint tankid;
public uint star;
public uint count;
public ID_PLAYER_PVE_RESULT(uint levelid,byte modetype,bool isWin,uint tankid,uint star,uint count)
{
this.levelid = levelid;
this.modetype = modetype;
this.isWin = isWin;
this.tankid = tankid;
this.star = star;
this.count = count;
}
}
public class ID_WAREHOUSE_TANK_DETAIL_INFO : IData
{
public ushort tankId;
public ID_WAREHOUSE_TANK_DETAIL_INFO(ushort tankId)
{
this.tankId = tankId;
}
}
public class ID_WAREHOUSE_TANK_ADD_EXP_RSP : IData
{
public ushort tankId;
public uint curExp;
public byte curLvl;
public ID_WAREHOUSE_TANK_ADD_EXP_RSP(ushort tankId,uint curExp,byte curLvl)
{
this.tankId = tankId;
this.curExp = curExp;
this.curLvl = curLvl;
}
}
public class ID_WAREHOUSE_TANK_RANK_UP : IData
{
public ushort tankId;
public ID_WAREHOUSE_TANK_RANK_UP(ushort tankId)
{
this.tankId = tankId;
}
}
public class ID_WAREHOUSE_TANK_RANK_UP_RSP : IData
{
public ushort tankId;
public byte curRank;
public uint skillId;
public ID_WAREHOUSE_TANK_RANK_UP_RSP(ushort tankId,byte curRank,uint skillId)
{
this.tankId = tankId;
this.curRank = curRank;
this.skillId = skillId;
}
}
public class ID_WAREHOUSE_TANK_EQUIP_LVLUP : IData
{
public ushort tankId;
public byte equipIdx;
public byte oneKey;
public ID_WAREHOUSE_TANK_EQUIP_LVLUP(ushort tankId,byte equipIdx,byte oneKey)
{
this.tankId = tankId;
this.equipIdx = equipIdx;
this.oneKey = oneKey;
}
}
public class ID_WAREHOUSE_TANK_EQUIP_LVLUP_RSP : IData
{
public ushort tankId;
public byte equipIdx;
public byte equipLvl;
public ID_WAREHOUSE_TANK_EQUIP_LVLUP_RSP(ushort tankId,byte equipIdx,byte equipLvl)
{
this.tankId = tankId;
this.equipIdx = equipIdx;
this.equipLvl = equipLvl;
}
}
public class ID_PLAYER_ACTIVE : IData
{
public byte flag;
public ID_PLAYER_ACTIVE(byte flag)
{
this.flag = flag;
}
}
public class ID_GM_MSG : IData
{
public byte gmCmdType;
public RakNet.RakString gmCmdStr;
public ID_GM_MSG(byte gmCmdType,RakNet.RakString gmCmdStr)
{
this.gmCmdType = gmCmdType;
this.gmCmdStr = gmCmdStr;
}
}
public class ID_BATLLESERVER_IP_RSP : IData
{
public ushort svrID;
public uint tokenID;
public RakNet.RakString ip;
public ID_BATLLESERVER_IP_RSP(ushort svrID,uint tokenID,RakNet.RakString ip)
{
this.svrID = svrID;
this.tokenID = tokenID;
this.ip = ip;
}
}
public class ID_ERROR_RSP : IData
{
public uint errorCode;
public uint param;
public ID_ERROR_RSP(uint errorCode,uint param)
{
this.errorCode = errorCode;
this.param = param;
}
}
public class ID_BATTLE_TO_LOGIC_PLAYER_STATE : IData
{
public uint userId;
public uint playerState;
public ID_BATTLE_TO_LOGIC_PLAYER_STATE(uint userId,uint playerState)
{
this.userId = userId;
this.playerState = playerState;
}
}
public class ID_BATTLE_TO_LOGIC_PPVE_FINISH : IData
{
public uint lobbyId;
public uint roomId;
public uint battleId;
public uint parameter;
public ID_BATTLE_TO_LOGIC_PPVE_FINISH(uint lobbyId,uint roomId,uint battleId,uint parameter)
{
this.lobbyId = lobbyId;
this.roomId = roomId;
this.battleId = battleId;
this.parameter = parameter;
}
}
public class SUB_ID_PAIL_HIT : IData
{
public uint bulletID;
public uint pailidx;
public SUB_ID_PAIL_HIT(uint bulletID,uint pailidx)
{
this.bulletID = bulletID;
this.pailidx = pailidx;
}
}
public class SUB_ID_TORNADO_EFFECT : IData
{
public uint idx;
public SUB_ID_TORNADO_EFFECT(uint idx)
{
this.idx = idx;
}
}
public class SUB_ID_TORNADO_EFFECT_RSP : IData
{
public short x;
public short y;
public short z;
public SUB_ID_TORNADO_EFFECT_RSP(short x,short y,short z)
{
this.x = x;
this.y = y;
this.z = z;
}
}
public class SUB_ID_SYNC_PLAYER_LOAD : IData
{
public uint playerid;
public byte state;
public SUB_ID_SYNC_PLAYER_LOAD(uint playerid,byte state)
{
this.playerid = playerid;
this.state = state;
}
}
public class SUB_ID_BATTLE_GET_BATTLEINFO : IData
{
public uint instanceID;
public SUB_ID_BATTLE_GET_BATTLEINFO(uint instanceID)
{
this.instanceID = instanceID;
}
}
public class SUB_ID_ITEM_USE : IData
{
public uint itemId;
public byte itemNum;
public SUB_ID_ITEM_USE(uint itemId,byte itemNum)
{
this.itemId = itemId;
this.itemNum = itemNum;
}
}
public class SUB_ID_ITEM_SELL : IData
{
public uint itemId;
public byte itemNum;
public SUB_ID_ITEM_SELL(uint itemId,byte itemNum)
{
this.itemId = itemId;
this.itemNum = itemNum;
}
}
public class SUB_ID_PILOT_DETAIL_INFO : IData
{
public ushort pilotId;
public SUB_ID_PILOT_DETAIL_INFO(ushort pilotId)
{
this.pilotId = pilotId;
}
}
public class SUB_ID_PILOT_ADD_EXP_RSP : IData
{
public ushort pilotId;
public uint curExp;
public byte curLvl;
public SUB_ID_PILOT_ADD_EXP_RSP(ushort pilotId,uint curExp,byte curLvl)
{
this.pilotId = pilotId;
this.curExp = curExp;
this.curLvl = curLvl;
}
}
public class SUB_ID_PILOT_RANK_UP : IData
{
public ushort pilotId;
public SUB_ID_PILOT_RANK_UP(ushort pilotId)
{
this.pilotId = pilotId;
}
}
public class SUB_ID_PILOT_RANK_UP_RSP : IData
{
public ushort pilotId;
public byte curRank;
public SUB_ID_PILOT_RANK_UP_RSP(ushort pilotId,byte curRank)
{
this.pilotId = pilotId;
this.curRank = curRank;
}
}
public class SUB_ID_PILOT_MAJOR_LVLUP : IData
{
public ushort pilotId;
public byte majorIdx;
public SUB_ID_PILOT_MAJOR_LVLUP(ushort pilotId,byte majorIdx)
{
this.pilotId = pilotId;
this.majorIdx = majorIdx;
}
}
public class SUB_ID_PILOT_MAJOR_LVLUP_RSP : IData
{
public ushort pilotId;
public byte majorIdx;
public byte majorLvl;
public SUB_ID_PILOT_MAJOR_LVLUP_RSP(ushort pilotId,byte majorIdx,byte majorLvl)
{
this.pilotId = pilotId;
this.majorIdx = majorIdx;
this.majorLvl = majorLvl;
}
}
public class SUB_ID_EXCHANGE : IData
{
public ushort recipeId;
public SUB_ID_EXCHANGE(ushort recipeId)
{
this.recipeId = recipeId;
}
}
public class SUB_ID_CHAT : IData
{
public byte channel;
public RakNet.RakString chatContent;
public uint value;
public uint value2;
public SUB_ID_CHAT(byte channel,RakNet.RakString chatContent,uint value,uint value2)
{
this.channel = channel;
this.chatContent = chatContent;
this.value = value;
this.value2 = value2;
}
}
public class SUB_ID_CHAT_RSP : IData
{
public byte channel;
public RakNet.RakString chatContent;
public uint value;
public uint value2;
public uint value3;
public uint value4;
public RakNet.RakString name;
public SUB_ID_CHAT_RSP(byte channel,RakNet.RakString chatContent,uint value,uint value2,uint value3,uint value4,RakNet.RakString name)
{
this.channel = channel;
this.chatContent = chatContent;
this.value = value;
this.value2 = value2;
this.value3 = value3;
this.value4 = value4;
this.name = name;
}
}
public class SUB_ID_EMOTION : IData
{
public uint emotionID;
public RakNet.RakString pilotID;
public SUB_ID_EMOTION(uint emotionID,RakNet.RakString pilotID)
{
this.emotionID = emotionID;
this.pilotID = pilotID;
}
}
public class SUB_ID_EMOTION_RSP : IData
{
public uint playerID;
public uint emotionID;
public RakNet.RakString pilotID;
public SUB_ID_EMOTION_RSP(uint playerID,uint emotionID,RakNet.RakString pilotID)
{
this.playerID = playerID;
this.emotionID = emotionID;
this.pilotID = pilotID;
}
}
public class SUB_ID_TASK_LIST : IData
{
public byte taskType;
public SUB_ID_TASK_LIST(byte taskType)
{
this.taskType = taskType;
}
}
public class SUB_ID_TASK_GET : IData
{
public byte taskType;
public uint ID;
public SUB_ID_TASK_GET(byte taskType,uint ID)
{
this.taskType = taskType;
this.ID = ID;
}
}
public class SUB_ID_TASK_GET_RSP : IData
{
public byte taskType;
public uint ID;
public SUB_ID_TASK_GET_RSP(byte taskType,uint ID)
{
this.taskType = taskType;
this.ID = ID;
}
}
public class SUB_ID_ACTIVE_REWARD : IData
{
public uint activeValue;
public SUB_ID_ACTIVE_REWARD(uint activeValue)
{
this.activeValue = activeValue;
}
}
public class SUB_ID_ACTIVE_REWARD_RSP : IData
{
public uint activeValue;
public SUB_ID_ACTIVE_REWARD_RSP(uint activeValue)
{
this.activeValue = activeValue;
}
}
public class SUB_ID_PLAYER_PPVE_MATCH : IData
{
public uint taskID;
public SUB_ID_PLAYER_PPVE_MATCH(uint taskID)
{
this.taskID = taskID;
}
}
public class SUB_ID_FRIEND_ADD : IData
{
public uint userID;
public RakNet.RakString name;
public SUB_ID_FRIEND_ADD(uint userID,RakNet.RakString name)
{
this.userID = userID;
this.name = name;
}
}
public class SUB_ID_FRIEND_ADD_RSP : IData
{
public uint userID;
public RakNet.RakString name;
public SUB_ID_FRIEND_ADD_RSP(uint userID,RakNet.RakString name)
{
this.userID = userID;
this.name = name;
}
}
public class SUB_ID_FRIEND_REQUEST : IData
{
public uint userID;
public bool isAccept;
public SUB_ID_FRIEND_REQUEST(uint userID,bool isAccept)
{
this.userID = userID;
this.isAccept = isAccept;
}
}
public class SUB_ID_FRIEND_REQUEST_RSP : IData
{
public uint userID;
public bool isAccept;
public SUB_ID_FRIEND_REQUEST_RSP(uint userID,bool isAccept)
{
this.userID = userID;
this.isAccept = isAccept;
}
}
public class SUB_ID_FRIEND_DELETE : IData
{
public uint userID;
public SUB_ID_FRIEND_DELETE(uint userID)
{
this.userID = userID;
}
}
public class SUB_ID_FRIEND_DELETE_RSP : IData
{
public uint userID;
public SUB_ID_FRIEND_DELETE_RSP(uint userID)
{
this.userID = userID;
}
}
public class SUB_ID_FRIEND_MODIFY_LINESTATUS_RSP : IData
{
public uint userID;
public byte lineStatus;
public SUB_ID_FRIEND_MODIFY_LINESTATUS_RSP(uint userID,byte lineStatus)
{
this.userID = userID;
this.lineStatus = lineStatus;
}
}
public class SUB_ID_FRIEND_MODIFY_LEVEL_RSP : IData
{
public uint userID;
public ushort flevel;
public SUB_ID_FRIEND_MODIFY_LEVEL_RSP(uint userID,ushort flevel)
{
this.userID = userID;
this.flevel = flevel;
}
}
public class SUB_ID_FRIEND_MODIFY_ICON_RSP : IData
{
public uint userID;
public ushort ficon;
public SUB_ID_FRIEND_MODIFY_ICON_RSP(uint userID,ushort ficon)
{
this.userID = userID;
this.ficon = ficon;
}
}
public class SUB_ID_WAREHOUSE_TANK_STAR_UP : IData
{
public byte type;
public ushort tankId;
public SUB_ID_WAREHOUSE_TANK_STAR_UP(byte type,ushort tankId)
{
this.type = type;
this.tankId = tankId;
}
}
public class SUB_ID_WAREHOUSE_TANK_STAR_UP_RSP : IData
{
public ushort tankId;
public byte curLvl;
public SUB_ID_WAREHOUSE_TANK_STAR_UP_RSP(ushort tankId,byte curLvl)
{
this.tankId = tankId;
this.curLvl = curLvl;
}
}
public class SUB_ID_ACTIVE_PILOT : IData
{
public ushort pilotId;
public byte rank;
public SUB_ID_ACTIVE_PILOT(ushort pilotId,byte rank)
{
this.pilotId = pilotId;
this.rank = rank;
}
}
public class SUB_ID_WAREHOUSE_TANK_SKILL_RESET : IData
{
public ushort tankId;
public SUB_ID_WAREHOUSE_TANK_SKILL_RESET(ushort tankId)
{
this.tankId = tankId;
}
}
public class SUB_ID_WAREHOUSE_TANK_SKILL_RESET_RSP : IData
{
public ushort tankId;
public uint skillId;
public uint remainTimes;
public SUB_ID_WAREHOUSE_TANK_SKILL_RESET_RSP(ushort tankId,uint skillId,uint remainTimes)
{
this.tankId = tankId;
this.skillId = skillId;
this.remainTimes = remainTimes;
}
}
public class SUB_ID_WAREHOUSE_TACTIC_PAGE : IData
{
public byte pageIdx;
public byte opration;
public SUB_ID_WAREHOUSE_TACTIC_PAGE(byte pageIdx,byte opration)
{
this.pageIdx = pageIdx;
this.opration = opration;
}
}
public class SUB_ID_WAREHOUSE_TACTIC_PAGE_RSP : IData
{
public byte pageIdx;
public byte opration;
public byte res;
public SUB_ID_WAREHOUSE_TACTIC_PAGE_RSP(byte pageIdx,byte opration,byte res)
{
this.pageIdx = pageIdx;
this.opration = opration;
this.res = res;
}
}
public class SUB_ID_WAREHOUSE_TACTIC_PAGE_LSIT : IData
{
public byte pageIdx;
public SUB_ID_WAREHOUSE_TACTIC_PAGE_LSIT(byte pageIdx)
{
this.pageIdx = pageIdx;
}
}
public class SUB_ID_WAREHOUSE_TACTIC_UP_RUNE : IData
{
public byte pageIdx;
public byte idx;
public int itemId;
public SUB_ID_WAREHOUSE_TACTIC_UP_RUNE(byte pageIdx,byte idx,int itemId)
{
this.pageIdx = pageIdx;
this.idx = idx;
this.itemId = itemId;
}
}
public class SUB_ID_WAREHOUSE_TACTIC_UP_RUNE_RSP : IData
{
public byte pageIdx;
public byte idx;
public int itemId;
public SUB_ID_WAREHOUSE_TACTIC_UP_RUNE_RSP(byte pageIdx,byte idx,int itemId)
{
this.pageIdx = pageIdx;
this.idx = idx;
this.itemId = itemId;
}
}
public class SUB_ID_WAREHOUSE_TACTIC_DOWN_RUNE : IData
{
public byte pageIdx;
public byte idx;
public SUB_ID_WAREHOUSE_TACTIC_DOWN_RUNE(byte pageIdx,byte idx)
{
this.pageIdx = pageIdx;
this.idx = idx;
}
}
public class SUB_ID_WAREHOUSE_TACTIC_DOWN_RUNE_RSP : IData
{
public byte pageIdx;
public byte idx;
public int itemId;
public SUB_ID_WAREHOUSE_TACTIC_DOWN_RUNE_RSP(byte pageIdx,byte idx,int itemId)
{
this.pageIdx = pageIdx;
this.idx = idx;
this.itemId = itemId;
}
}
public class SUB_ID_WAREHOUSE_TACTIC_UNLOCK_SOCKET : IData
{
public byte pageIdx;
public byte idx;
public SUB_ID_WAREHOUSE_TACTIC_UNLOCK_SOCKET(byte pageIdx,byte idx)
{
this.pageIdx = pageIdx;
this.idx = idx;
}
}
public class SUB_ID_WAREHOUSE_TACTIC_UNLOCK_SOCKET_RSP : IData
{
public byte pageIdx;
public byte idx;
public byte res;
public SUB_ID_WAREHOUSE_TACTIC_UNLOCK_SOCKET_RSP(byte pageIdx,byte idx,byte res)
{
this.pageIdx = pageIdx;
this.idx = idx;
this.res = res;
}
}
public class SUB_ID_WAREHOUSE_TACTIC_SET_NAME : IData
{
public byte pageIdx;
public RakNet.RakString name;
public SUB_ID_WAREHOUSE_TACTIC_SET_NAME(byte pageIdx,RakNet.RakString name)
{
this.pageIdx = pageIdx;
this.name = name;
}
}
public class SUB_ID_WAREHOUSE_TACTIC_SET_NAME_RSP : IData
{
public byte pageIdx;
public byte res;
public SUB_ID_WAREHOUSE_TACTIC_SET_NAME_RSP(byte pageIdx,byte res)
{
this.pageIdx = pageIdx;
this.res = res;
}
}
public class SUB_ID_WAREHOUSE_TACTIC_DOWN_ALL_RUNE : IData
{
public byte pageIdx;
public SUB_ID_WAREHOUSE_TACTIC_DOWN_ALL_RUNE(byte pageIdx)
{
this.pageIdx = pageIdx;
}
}
public class SUB_ID_WAREHOUSE_TACTIC_DOWN_ALL_RUNE_RSP : IData
{
public byte pageIdx;
public byte res;
public SUB_ID_WAREHOUSE_TACTIC_DOWN_ALL_RUNE_RSP(byte pageIdx,byte res)
{
this.pageIdx = pageIdx;
this.res = res;
}
}
public class SUB_ID_WAREHOUSE_TACTIC_DECOMPOSE_RSP : IData
{
public byte res;
public uint stragypoint;
public SUB_ID_WAREHOUSE_TACTIC_DECOMPOSE_RSP(byte res,uint stragypoint)
{
this.res = res;
this.stragypoint = stragypoint;
}
}
public class SUB_ID_WAREHOUSE_TACTIC_COMPOSE : IData
{
public uint strategyItem;
public SUB_ID_WAREHOUSE_TACTIC_COMPOSE(uint strategyItem)
{
this.strategyItem = strategyItem;
}
}
public class SUB_ID_WAREHOUSE_TACTIC_COMPOSE_RSP : IData
{
public byte res;
public SUB_ID_WAREHOUSE_TACTIC_COMPOSE_RSP(byte res)
{
this.res = res;
}
}
public class SUB_ID_CONSUME : IData
{
public byte type;
public SUB_ID_CONSUME(byte type)
{
this.type = type;
}
}
public class SUB_ID_CONSUME_RSP : IData
{
public byte type;
public uint value;
public uint rate;
public SUB_ID_CONSUME_RSP(byte type,uint value,uint rate)
{
this.type = type;
this.value = value;
this.rate = rate;
}
}
public class SUB_ID_TUTORIAL_IGNORE : IData
{
public bool ignore;
public SUB_ID_TUTORIAL_IGNORE(bool ignore)
{
this.ignore = ignore;
}
}
public class SUB_ID_WAREHOUSE_TANK_SPLIT : IData
{
public ushort tankId;
public byte type;
public SUB_ID_WAREHOUSE_TANK_SPLIT(ushort tankId,byte type)
{
this.tankId = tankId;
this.type = type;
}
}
public class SUB_ID_PLAYER_SELECT_HEAD : IData
{
public uint avatarId;
public SUB_ID_PLAYER_SELECT_HEAD(uint avatarId)
{
this.avatarId = avatarId;
}
}
public class SUB_ID_PLAYER_SELECT_HEAD_RSP : IData
{
public uint avatarId;
public byte result;
public SUB_ID_PLAYER_SELECT_HEAD_RSP(uint avatarId,byte result)
{
this.avatarId = avatarId;
this.result = result;
}
}
public class SUB_ID_PLAYER_ELO_MATCH : IData
{
public uint battleID;
public SUB_ID_PLAYER_ELO_MATCH(uint battleID)
{
this.battleID = battleID;
}
}
public class SUB_ID_PLAYER_ELO_MATCH_RSP : IData
{
public uint battleID;
public uint waitTimeOut;
public uint avgMatchTime;
public SUB_ID_PLAYER_ELO_MATCH_RSP(uint battleID,uint waitTimeOut,uint avgMatchTime)
{
this.battleID = battleID;
this.waitTimeOut = waitTimeOut;
this.avgMatchTime = avgMatchTime;
}
}
public class SUB_ID_PLAYER_ELO_MATCH_CANCEL_RSP : IData
{
public byte error;
public SUB_ID_PLAYER_ELO_MATCH_CANCEL_RSP(byte error)
{
this.error = error;
}
}
public class SUB_ID_ASK_PLAYER_INFO : IData
{
public uint playerid;
public SUB_ID_ASK_PLAYER_INFO(uint playerid)
{
this.playerid = playerid;
}
}
public class SUB_ID_ASK_PLAYER_RECORD : IData
{
public uint playerid;
public byte type;
public SUB_ID_ASK_PLAYER_RECORD(uint playerid,byte type)
{
this.playerid = playerid;
this.type = type;
}
}
public class SUB_ID_BATTLE_CAPTURE_FLAG_SCORE_RSP : IData
{
public byte group;
public uint score;
public SUB_ID_BATTLE_CAPTURE_FLAG_SCORE_RSP(byte group,uint score)
{
this.group = group;
this.score = score;
}
}
public class SUB_ID_BATTLE_KILL_PEOPLE_RSP : IData
{
public byte type;
public uint count;
public SUB_ID_BATTLE_KILL_PEOPLE_RSP(byte type,uint count)
{
this.type = type;
this.count = count;
}
}
public class SUB_ID_PLAYER_PASSIVE_SKILL_RSP : IData
{
public uint playerId;
public uint skillId;
public SUB_ID_PLAYER_PASSIVE_SKILL_RSP(uint playerId,uint skillId)
{
this.playerId = playerId;
this.skillId = skillId;
}
}
public class SUB_ID_PPVE_CHALLENGE_RESULT_RSP : IData
{
public uint parameter;
public SUB_ID_PPVE_CHALLENGE_RESULT_RSP(uint parameter)
{
this.parameter = parameter;
}
}

public class AutoGenProto
{

public static void Send_ID_PLAYER_CHAT()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_PLAYER_CHAT, new RakNet.BitStream()));}


public static void Send_ID_NEED_CRC_BEGIN()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_NEED_CRC_BEGIN, new RakNet.BitStream()));}


public static void Send_ID_PLAYER_STOP(uint instanceID,int x,int z,uint y,byte dura,uint timestamp)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(instanceID);
bs.WriteCompressed(x);
bs.WriteCompressed(z);
bs.WriteCompressed(y);
bs.WriteCompressed(dura);
bs.WriteCompressed(timestamp);
TankSendMsg.SendImmediate(Common.CraetePkg(MessageID.ID_PLAYER_STOP, bs));
}


public static void Send_ID_PLAYER_HURT(uint instanceID,uint defendUserID,ushort hurtValue,uint timestamp)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(instanceID);
bs.WriteCompressed(defendUserID);
bs.WriteCompressed(hurtValue);
bs.WriteCompressed(timestamp);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_PLAYER_HURT, bs));
}

public delegate void  Delegate_ID_PLAYER_HURT_RSP(int _errcode, uint attackUserID,uint defendUserID,ushort hurtValue,uint timestamp);
public static  Delegate_ID_PLAYER_HURT_RSP delegate_ID_PLAYER_HURT_RSP = null;
public delegate void  Delegate_ID_PLAYER_HURT_RSP_completed();
public static  Delegate_ID_PLAYER_HURT_RSP_completed delegate_ID_PLAYER_HURT_RSP_completed = null;

public static void Recv_ID_PLAYER_HURT_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
List<IData>list = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
 {
uint attackUserID;
bs.ReadCompressed(out attackUserID);
uint defendUserID;
bs.ReadCompressed(out defendUserID);
ushort hurtValue;
bs.ReadCompressed(out hurtValue);
uint timestamp;
bs.ReadCompressed(out timestamp);

PlayerHurtInfo data = new PlayerHurtInfo(attackUserID,defendUserID,hurtValue,timestamp);
list.Add(data);
if(delegate_ID_PLAYER_HURT_RSP!=null)
{
delegate_ID_PLAYER_HURT_RSP(_errcode, attackUserID,defendUserID,hurtValue,timestamp);
}
}
DataHelper.Refresh(typeof(PlayerHurtInfo), list);
if(delegate_ID_PLAYER_HURT_RSP_completed!=null)
{
delegate_ID_PLAYER_HURT_RSP_completed();}
}


public static void Send_ID_PLAYER_DEAD(uint instanceID,uint timestamp)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(instanceID);
bs.WriteCompressed(timestamp);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_PLAYER_DEAD, bs));
}

public delegate void  Delegate_ID_PLAYER_DEAD_RSP(int _errcode, uint userID,byte reviveInterval,uint timestamp);
public static  Delegate_ID_PLAYER_DEAD_RSP delegate_ID_PLAYER_DEAD_RSP = null;

public static void Recv_ID_PLAYER_DEAD_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
uint userID;
bs.ReadCompressed(out userID);
byte reviveInterval;
bs.ReadCompressed(out reviveInterval);
uint timestamp;
bs.ReadCompressed(out timestamp);
if(delegate_ID_PLAYER_DEAD_RSP!=null)
{
delegate_ID_PLAYER_DEAD_RSP(_errcode, userID,reviveInterval,timestamp);
}
}


public static void Send_ID_PLAYER_REVIVE(uint instanceID,uint aiID,uint timestamp,uint consumeType)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(instanceID);
bs.WriteCompressed(aiID);
bs.WriteCompressed(timestamp);
bs.WriteCompressed(consumeType);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_PLAYER_REVIVE, bs));
}

public delegate void  Delegate_ID_PLAYER_REVIVE_RSP(int _errcode, uint userID,uint timestamp,short x,short y,short z);
public static  Delegate_ID_PLAYER_REVIVE_RSP delegate_ID_PLAYER_REVIVE_RSP = null;

public static void Recv_ID_PLAYER_REVIVE_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
uint userID;
bs.ReadCompressed(out userID);
uint timestamp;
bs.ReadCompressed(out timestamp);
short x;
bs.ReadCompressed(out x);
short y;
bs.ReadCompressed(out y);
short z;
bs.ReadCompressed(out z);
if(delegate_ID_PLAYER_REVIVE_RSP!=null)
{
delegate_ID_PLAYER_REVIVE_RSP(_errcode, userID,timestamp,x,y,z);
}
}


public static void Send_ID_PLAYER_FIRE(uint aiID,uint instanceID,byte type,byte bulletID,byte bulletNum,short dirX,short dirY,short dirZ,ushort gravity,ushort speed,uint timestamp,short x,short y,short z)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(aiID);
bs.WriteCompressed(instanceID);
bs.WriteCompressed(type);
bs.WriteCompressed(bulletID);
bs.WriteCompressed(bulletNum);
bs.WriteCompressed(dirX);
bs.WriteCompressed(dirY);
bs.WriteCompressed(dirZ);
bs.WriteCompressed(gravity);
bs.WriteCompressed(speed);
bs.WriteCompressed(timestamp);
bs.WriteCompressed(x);
bs.WriteCompressed(y);
bs.WriteCompressed(z);
TankSendMsg.SendImmediate(Common.CraetePkg(MessageID.ID_PLAYER_FIRE, bs));
}

public delegate void  Delegate_ID_PLAYER_FIRE_RSP(int _errcode, uint attacker,byte type,byte bulletID,short dirX,short dirY,short dirZ,ushort gravity,ushort speed,uint timestamp,short x,short y,short z);
public static  Delegate_ID_PLAYER_FIRE_RSP delegate_ID_PLAYER_FIRE_RSP = null;

public static void Recv_ID_PLAYER_FIRE_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
uint attacker;
bs.ReadCompressed(out attacker);
byte type;
bs.ReadCompressed(out type);
byte bulletID;
bs.ReadCompressed(out bulletID);
short dirX;
bs.ReadCompressed(out dirX);
short dirY;
bs.ReadCompressed(out dirY);
short dirZ;
bs.ReadCompressed(out dirZ);
ushort gravity;
bs.ReadCompressed(out gravity);
ushort speed;
bs.ReadCompressed(out speed);
uint timestamp;
bs.ReadCompressed(out timestamp);
short x;
bs.ReadCompressed(out x);
short y;
bs.ReadCompressed(out y);
short z;
bs.ReadCompressed(out z);
if(delegate_ID_PLAYER_FIRE_RSP!=null)
{
delegate_ID_PLAYER_FIRE_RSP(_errcode, attacker,type,bulletID,dirX,dirY,dirZ,gravity,speed,timestamp,x,y,z);
}
}

public delegate void  Delegate_ID_PLAYER_BULLET_NUM_RSP(int _errcode, byte bulletID,byte bulletNum);
public static  Delegate_ID_PLAYER_BULLET_NUM_RSP delegate_ID_PLAYER_BULLET_NUM_RSP = null;

public static void Recv_ID_PLAYER_BULLET_NUM_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
byte bulletID;
bs.ReadCompressed(out bulletID);
byte bulletNum;
bs.ReadCompressed(out bulletNum);
if(delegate_ID_PLAYER_BULLET_NUM_RSP!=null)
{
delegate_ID_PLAYER_BULLET_NUM_RSP(_errcode, bulletID,bulletNum);
}
}


public static void Send_ID_PLAYER_ATTACK(uint aiID,uint instanceID,uint timestamp,byte bulletID,PlayerAttackInfo[] attackInfo)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(aiID);
bs.WriteCompressed(instanceID);
bs.WriteCompressed(timestamp);
bs.WriteCompressed(bulletID);
foreach(PlayerAttackInfo val in attackInfo)
{
bs.WriteCompressed(val.target);
bs.WriteCompressed(val.hitTurret);
bs.WriteCompressed(val.hitArea);
bs.WriteCompressed(val.percent);
bs.WriteCompressed(val.x);
bs.WriteCompressed(val.y);
bs.WriteCompressed(val.z);
}
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_PLAYER_ATTACK, bs));
}

public delegate void  Delegate_ID_PLAYER_ATTACK_RSP(int _errcode, uint attacker,uint timestamp,byte bulletID,ushort atkRage,PlayerAttackInfoRsp[]  list );
public static  Delegate_ID_PLAYER_ATTACK_RSP delegate_ID_PLAYER_ATTACK_RSP = null;

public static void Recv_ID_PLAYER_ATTACK_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
uint attacker;
bs.ReadCompressed(out attacker);
uint timestamp;
bs.ReadCompressed(out timestamp);
byte bulletID;
bs.ReadCompressed(out bulletID);
ushort atkRage;
bs.ReadCompressed(out atkRage);
List<PlayerAttackInfoRsp> list = new List<PlayerAttackInfoRsp>();
List<IData> lst = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
{uint target;
bs.ReadCompressed(out target);
byte shootType;
bs.ReadCompressed(out shootType);
bool hitTurret;
bs.ReadCompressed(out hitTurret);
byte hitArea;
bs.ReadCompressed(out hitArea);
byte percent;
bs.ReadCompressed(out percent);
short x;
bs.ReadCompressed(out x);
short y;
bs.ReadCompressed(out y);
short z;
bs.ReadCompressed(out z);
int damage;
bs.ReadCompressed(out damage);
int hp;
bs.ReadCompressed(out hp);
ushort rage;
bs.ReadCompressed(out rage);
PlayerAttackInfoRsp val = new PlayerAttackInfoRsp(target,shootType,hitTurret,hitArea,percent,x,y,z,damage,hp,rage);
list.Add(val); 
lst.Add(val); 
}
 DataHelper.Refresh(typeof(PlayerAttackInfoRsp), lst);
if(delegate_ID_PLAYER_ATTACK_RSP!=null)
{
delegate_ID_PLAYER_ATTACK_RSP(_errcode, attacker,timestamp,bulletID,atkRage, list.ToArray());
}
}


public static void Send_ID_BATTLE_MONSTER_DROP(uint instanceID,short x,short y,short z,int monsterID)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(instanceID);
bs.WriteCompressed(x);
bs.WriteCompressed(y);
bs.WriteCompressed(z);
bs.WriteCompressed(monsterID);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_BATTLE_MONSTER_DROP, bs));
}


public static void Send_ID_BATTLE_PICKUP_ITEM(uint instanceID,uint userid,byte index)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(instanceID);
bs.WriteCompressed(userid);
bs.WriteCompressed(index);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_BATTLE_PICKUP_ITEM, bs));
}

public delegate void  Delegate_ID_BATTLE_PICKUP_ITEM_RSP(int _errcode, uint instanceID,uint owner,byte index);
public static  Delegate_ID_BATTLE_PICKUP_ITEM_RSP delegate_ID_BATTLE_PICKUP_ITEM_RSP = null;

public static void Recv_ID_BATTLE_PICKUP_ITEM_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
uint instanceID;
bs.ReadCompressed(out instanceID);
uint owner;
bs.ReadCompressed(out owner);
byte index;
bs.ReadCompressed(out index);
if(delegate_ID_BATTLE_PICKUP_ITEM_RSP!=null)
{
delegate_ID_BATTLE_PICKUP_ITEM_RSP(_errcode, instanceID,owner,index);
}
}

public delegate void  Delegate_ID_BATTLE_DROP_RSP(int _errcode, byte showType,byte index,short x,short y,short z,uint delayTime,uint timestamp,DropItem[]  list );
public static  Delegate_ID_BATTLE_DROP_RSP delegate_ID_BATTLE_DROP_RSP = null;

public static void Recv_ID_BATTLE_DROP_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
byte showType;
bs.ReadCompressed(out showType);
byte index;
bs.ReadCompressed(out index);
short x;
bs.ReadCompressed(out x);
short y;
bs.ReadCompressed(out y);
short z;
bs.ReadCompressed(out z);
uint delayTime;
bs.ReadCompressed(out delayTime);
uint timestamp;
bs.ReadCompressed(out timestamp);
List<DropItem> list = new List<DropItem>();
List<IData> lst = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
{uint itemID;
bs.ReadCompressed(out itemID);
DropItem val = new DropItem(itemID);
list.Add(val); 
lst.Add(val); 
}
 DataHelper.Refresh(typeof(DropItem), lst);
if(delegate_ID_BATTLE_DROP_RSP!=null)
{
delegate_ID_BATTLE_DROP_RSP(_errcode, showType,index,x,y,z,delayTime,timestamp, list.ToArray());
}
}


public static void Send_ID_PLAYER_POSITION_SYNC(uint aiID,uint instanceID,int x,int y,int z,int dirX,int dirY,int dirZ,int angle,uint timestamp,ushort speed,bool isReverse,sbyte angleDir)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(aiID);
bs.WriteCompressed(instanceID);
bs.WriteCompressed(x);
bs.WriteCompressed(y);
bs.WriteCompressed(z);
bs.WriteCompressed(dirX);
bs.WriteCompressed(dirY);
bs.WriteCompressed(dirZ);
bs.WriteCompressed(angle);
bs.WriteCompressed(timestamp);
bs.WriteCompressed(speed);
bs.WriteCompressed(isReverse);
bs.WriteCompressed(angleDir);
TankSendMsg.SendImmediate(Common.CraetePkg(MessageID.ID_PLAYER_POSITION_SYNC, bs));
}

public delegate void  Delegate_ID_PLAYER_POSITION_SYNC_RSP(int _errcode, uint userid,int x,int y,int z,int dirX,int dirY,int dirZ,int angle,uint timestamp,ushort speed,bool isReverse,sbyte angleDir);
public static  Delegate_ID_PLAYER_POSITION_SYNC_RSP delegate_ID_PLAYER_POSITION_SYNC_RSP = null;

public static void Recv_ID_PLAYER_POSITION_SYNC_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
uint userid;
bs.ReadCompressed(out userid);
int x;
bs.ReadCompressed(out x);
int y;
bs.ReadCompressed(out y);
int z;
bs.ReadCompressed(out z);
int dirX;
bs.ReadCompressed(out dirX);
int dirY;
bs.ReadCompressed(out dirY);
int dirZ;
bs.ReadCompressed(out dirZ);
int angle;
bs.ReadCompressed(out angle);
uint timestamp;
bs.ReadCompressed(out timestamp);
ushort speed;
bs.ReadCompressed(out speed);
bool isReverse;
bs.ReadCompressed(out isReverse);
sbyte angleDir;
bs.ReadCompressed(out angleDir);
if(delegate_ID_PLAYER_POSITION_SYNC_RSP!=null)
{
delegate_ID_PLAYER_POSITION_SYNC_RSP(_errcode, userid,x,y,z,dirX,dirY,dirZ,angle,timestamp,speed,isReverse,angleDir);
}
}


public static void Send_ID_PLAYER_SKILL_ALARM(uint instanceID,uint aiID,uint skillID,int x,int z,int y)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(instanceID);
bs.WriteCompressed(aiID);
bs.WriteCompressed(skillID);
bs.WriteCompressed(x);
bs.WriteCompressed(z);
bs.WriteCompressed(y);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_PLAYER_SKILL_ALARM, bs));
}

public delegate void  Delegate_ID_PLAYER_SKILL_ALARM_RSP(int _errcode, uint skillID,uint attacker,int x,int z,int y);
public static  Delegate_ID_PLAYER_SKILL_ALARM_RSP delegate_ID_PLAYER_SKILL_ALARM_RSP = null;

public static void Recv_ID_PLAYER_SKILL_ALARM_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
uint skillID;
bs.ReadCompressed(out skillID);
uint attacker;
bs.ReadCompressed(out attacker);
int x;
bs.ReadCompressed(out x);
int z;
bs.ReadCompressed(out z);
int y;
bs.ReadCompressed(out y);
if(delegate_ID_PLAYER_SKILL_ALARM_RSP!=null)
{
delegate_ID_PLAYER_SKILL_ALARM_RSP(_errcode, skillID,attacker,x,z,y);
}
}

public delegate void  Delegate_ID_PLAYER_SKILL_BREAK_RSP(int _errcode, uint skillID,uint attacker);
public static  Delegate_ID_PLAYER_SKILL_BREAK_RSP delegate_ID_PLAYER_SKILL_BREAK_RSP = null;

public static void Recv_ID_PLAYER_SKILL_BREAK_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
uint skillID;
bs.ReadCompressed(out skillID);
uint attacker;
bs.ReadCompressed(out attacker);
if(delegate_ID_PLAYER_SKILL_BREAK_RSP!=null)
{
delegate_ID_PLAYER_SKILL_BREAK_RSP(_errcode, skillID,attacker);
}
}


public static void Send_ID_PLAYER_SKILL(uint instanceID,uint aiID,uint skillID,short x,short z,short y,HurtInfo[] infos)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(instanceID);
bs.WriteCompressed(aiID);
bs.WriteCompressed(skillID);
bs.WriteCompressed(x);
bs.WriteCompressed(z);
bs.WriteCompressed(y);
foreach(HurtInfo val in infos)
{
bs.WriteCompressed(val.target);
bs.WriteCompressed(val.key);
bs.WriteCompressed(val.value);
}
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_PLAYER_SKILL, bs));
}

public delegate void  Delegate_ID_PLAYER_SKILL_RSP(int _errcode, uint skillID,uint attacker,short x,short z,short y,HurtInfo[]  list );
public static  Delegate_ID_PLAYER_SKILL_RSP delegate_ID_PLAYER_SKILL_RSP = null;

public static void Recv_ID_PLAYER_SKILL_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
uint skillID;
bs.ReadCompressed(out skillID);
uint attacker;
bs.ReadCompressed(out attacker);
short x;
bs.ReadCompressed(out x);
short z;
bs.ReadCompressed(out z);
short y;
bs.ReadCompressed(out y);
List<HurtInfo> list = new List<HurtInfo>();
List<IData> lst = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
{uint target;
bs.ReadCompressed(out target);
uint key;
bs.ReadCompressed(out key);
int value;
bs.ReadCompressed(out value);
HurtInfo val = new HurtInfo(target,key,value);
list.Add(val); 
lst.Add(val); 
}
 DataHelper.Refresh(typeof(HurtInfo), lst);
if(delegate_ID_PLAYER_SKILL_RSP!=null)
{
delegate_ID_PLAYER_SKILL_RSP(_errcode, skillID,attacker,x,z,y, list.ToArray());
}
}

public delegate void  Delegate_ID_AI_SPAWN_RSP(int _errcode, byte AIType,uint AIInsID,uint bindUserid,uint aiId,byte group,ushort tankTempId,byte tankRank,int x,int y,int z,uint timestamp);
public static  Delegate_ID_AI_SPAWN_RSP delegate_ID_AI_SPAWN_RSP = null;
public delegate void  Delegate_ID_AI_SPAWN_RSP_completed();
public static  Delegate_ID_AI_SPAWN_RSP_completed delegate_ID_AI_SPAWN_RSP_completed = null;

public static void Recv_ID_AI_SPAWN_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
List<IData>list = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
 {
byte AIType;
bs.ReadCompressed(out AIType);
uint AIInsID;
bs.ReadCompressed(out AIInsID);
uint bindUserid;
bs.ReadCompressed(out bindUserid);
uint aiId;
bs.ReadCompressed(out aiId);
byte group;
bs.ReadCompressed(out group);
ushort tankTempId;
bs.ReadCompressed(out tankTempId);
byte tankRank;
bs.ReadCompressed(out tankRank);
int x;
bs.ReadCompressed(out x);
int y;
bs.ReadCompressed(out y);
int z;
bs.ReadCompressed(out z);
uint timestamp;
bs.ReadCompressed(out timestamp);

AIEntityInfo data = new AIEntityInfo(AIType,AIInsID,bindUserid,aiId,group,tankTempId,tankRank,x,y,z,timestamp);
list.Add(data);
if(delegate_ID_AI_SPAWN_RSP!=null)
{
delegate_ID_AI_SPAWN_RSP(_errcode, AIType,AIInsID,bindUserid,aiId,group,tankTempId,tankRank,x,y,z,timestamp);
}
}
DataHelper.Refresh(typeof(AIEntityInfo), list);
if(delegate_ID_AI_SPAWN_RSP_completed!=null)
{
delegate_ID_AI_SPAWN_RSP_completed();}
}

public delegate void  Delegate_ID_AI_MOVE_RSP(int _errcode, byte type,uint aiId,uint tarId,byte obstacleId,AIPathArea[]  list );
public static  Delegate_ID_AI_MOVE_RSP delegate_ID_AI_MOVE_RSP = null;

public static void Recv_ID_AI_MOVE_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
byte type;
bs.ReadCompressed(out type);
uint aiId;
bs.ReadCompressed(out aiId);
uint tarId;
bs.ReadCompressed(out tarId);
byte obstacleId;
bs.ReadCompressed(out obstacleId);
List<AIPathArea> list = new List<AIPathArea>();
List<IData> lst = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
{uint tarX;
bs.ReadCompressed(out tarX);
uint tarZ;
bs.ReadCompressed(out tarZ);
ushort radius;
bs.ReadCompressed(out radius);
AIPathArea val = new AIPathArea(tarX,tarZ,radius);
list.Add(val); 
lst.Add(val); 
}
 DataHelper.Refresh(typeof(AIPathArea), lst);
if(delegate_ID_AI_MOVE_RSP!=null)
{
delegate_ID_AI_MOVE_RSP(_errcode, type,aiId,tarId,obstacleId, list.ToArray());
}
}

public delegate void  Delegate_ID_AI_MONSTER_ACT_RSP(int _errcode, uint aiId,byte type,ushort duration,short x,short y,short z);
public static  Delegate_ID_AI_MONSTER_ACT_RSP delegate_ID_AI_MONSTER_ACT_RSP = null;

public static void Recv_ID_AI_MONSTER_ACT_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
uint aiId;
bs.ReadCompressed(out aiId);
byte type;
bs.ReadCompressed(out type);
ushort duration;
bs.ReadCompressed(out duration);
short x;
bs.ReadCompressed(out x);
short y;
bs.ReadCompressed(out y);
short z;
bs.ReadCompressed(out z);
if(delegate_ID_AI_MONSTER_ACT_RSP!=null)
{
delegate_ID_AI_MONSTER_ACT_RSP(_errcode, aiId,type,duration,x,y,z);
}
}

public delegate void  Delegate_ID_AI_ATTACK_RSP(int _errcode, byte type,uint aiId,AIAttack[]  list );
public static  Delegate_ID_AI_ATTACK_RSP delegate_ID_AI_ATTACK_RSP = null;

public static void Recv_ID_AI_ATTACK_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
byte type;
bs.ReadCompressed(out type);
uint aiId;
bs.ReadCompressed(out aiId);
List<AIAttack> list = new List<AIAttack>();
List<IData> lst = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
{uint tarId;
bs.ReadCompressed(out tarId);
uint skillId;
bs.ReadCompressed(out skillId);
AIAttack val = new AIAttack(tarId,skillId);
list.Add(val); 
lst.Add(val); 
}
 DataHelper.Refresh(typeof(AIAttack), lst);
if(delegate_ID_AI_ATTACK_RSP!=null)
{
delegate_ID_AI_ATTACK_RSP(_errcode, type,aiId, list.ToArray());
}
}

public delegate void  Delegate_ID_PLAYER_BUFF_ATTR_RSP(int _errcode, uint attacker,uint target,ushort buffID,ushort lastTime,bool addBuff,BuffKeyValue[]  list );
public static  Delegate_ID_PLAYER_BUFF_ATTR_RSP delegate_ID_PLAYER_BUFF_ATTR_RSP = null;

public static void Recv_ID_PLAYER_BUFF_ATTR_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
uint attacker;
bs.ReadCompressed(out attacker);
uint target;
bs.ReadCompressed(out target);
ushort buffID;
bs.ReadCompressed(out buffID);
ushort lastTime;
bs.ReadCompressed(out lastTime);
bool addBuff;
bs.ReadCompressed(out addBuff);
List<BuffKeyValue> list = new List<BuffKeyValue>();
List<IData> lst = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
{ushort key;
bs.ReadCompressed(out key);
uint value;
bs.ReadCompressed(out value);
BuffKeyValue val = new BuffKeyValue(key,value);
list.Add(val); 
lst.Add(val); 
}
 DataHelper.Refresh(typeof(BuffKeyValue), lst);
if(delegate_ID_PLAYER_BUFF_ATTR_RSP!=null)
{
delegate_ID_PLAYER_BUFF_ATTR_RSP(_errcode, attacker,target,buffID,lastTime,addBuff, list.ToArray());
}
}


public static void Send_ID_PLAYER_CHANGE_TANK(ushort tankIndex,ushort pilotIndex)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(tankIndex);
bs.WriteCompressed(pilotIndex);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_PLAYER_CHANGE_TANK, bs));
}

public delegate void  Delegate_ID_PLAYER_CHANGE_TANK_RSP(int _errcode, uint userID,ushort tankID,byte tankSubid,byte tankLv,ushort pilotID,byte pilotSubid);
public static  Delegate_ID_PLAYER_CHANGE_TANK_RSP delegate_ID_PLAYER_CHANGE_TANK_RSP = null;

public static void Recv_ID_PLAYER_CHANGE_TANK_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
uint userID;
bs.ReadCompressed(out userID);
ushort tankID;
bs.ReadCompressed(out tankID);
byte tankSubid;
bs.ReadCompressed(out tankSubid);
byte tankLv;
bs.ReadCompressed(out tankLv);
ushort pilotID;
bs.ReadCompressed(out pilotID);
byte pilotSubid;
bs.ReadCompressed(out pilotSubid);
if(delegate_ID_PLAYER_CHANGE_TANK_RSP!=null)
{
delegate_ID_PLAYER_CHANGE_TANK_RSP(_errcode, userID,tankID,tankSubid,tankLv,pilotID,pilotSubid);
}
}


public static void Send_ID_GAME_LOADCOMPLETE()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_GAME_LOADCOMPLETE, new RakNet.BitStream()));}

public delegate void  Delegate_ID_GAME_TIME_START_RSP(int _errcode, uint timestamp,byte interval);
public static  Delegate_ID_GAME_TIME_START_RSP delegate_ID_GAME_TIME_START_RSP = null;

public static void Recv_ID_GAME_TIME_START_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
uint timestamp;
bs.Read(out timestamp);
byte interval;
bs.Read(out interval);
if(delegate_ID_GAME_TIME_START_RSP!=null)
{
delegate_ID_GAME_TIME_START_RSP(_errcode, timestamp,interval);
}
}


public static void Send_ID_PLAYER_TIMESTAMP(uint timestamp,bool reconnect)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(timestamp);
bs.WriteCompressed(reconnect);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_PLAYER_TIMESTAMP, bs));
}

public delegate void  Delegate_ID_PLAYER_TIMESTAMP_RSP(int _errcode, int diff);
public static  Delegate_ID_PLAYER_TIMESTAMP_RSP delegate_ID_PLAYER_TIMESTAMP_RSP = null;

public static void Recv_ID_PLAYER_TIMESTAMP_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
int diff;
bs.ReadCompressed(out diff);
if(delegate_ID_PLAYER_TIMESTAMP_RSP!=null)
{
delegate_ID_PLAYER_TIMESTAMP_RSP(_errcode, diff);
}
}


public static void Send_ID_PLAYER_EXIT_INSTANCE(uint instanceID)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(instanceID);
TankSendMsg.SendImmediate(Common.CraetePkg(MessageID.ID_PLAYER_EXIT_INSTANCE, bs));
}

public delegate void  Delegate_ID_PLAYER_EXIT_INSTANCE_RSP(int _errcode, uint userID);
public static  Delegate_ID_PLAYER_EXIT_INSTANCE_RSP delegate_ID_PLAYER_EXIT_INSTANCE_RSP = null;

public static void Recv_ID_PLAYER_EXIT_INSTANCE_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
uint userID;
bs.ReadCompressed(out userID);
if(delegate_ID_PLAYER_EXIT_INSTANCE_RSP!=null)
{
delegate_ID_PLAYER_EXIT_INSTANCE_RSP(_errcode, userID);
}
}


public static void Send_ID_BATTLE_SCORE(uint instanceID)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(instanceID);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_BATTLE_SCORE, bs));
}

public delegate void  Delegate_ID_LOBBY_ROOM_ENTERINFO_RSP(int _errcode, uint instanceID,uint battleID,PlayerEnterRoomRsp[]  list );
public static  Delegate_ID_LOBBY_ROOM_ENTERINFO_RSP delegate_ID_LOBBY_ROOM_ENTERINFO_RSP = null;

public static void Recv_ID_LOBBY_ROOM_ENTERINFO_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
uint instanceID;
bs.ReadCompressed(out instanceID);
uint battleID;
bs.ReadCompressed(out battleID);
List<PlayerEnterRoomRsp> list = new List<PlayerEnterRoomRsp>();
List<IData> lst = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
{uint bindUID;
bs.ReadCompressed(out bindUID);
uint userid;
bs.ReadCompressed(out userid);
byte group;
bs.ReadCompressed(out group);
ushort x;
bs.ReadCompressed(out x);
ushort y;
bs.ReadCompressed(out y);
ushort z;
bs.ReadCompressed(out z);
ushort rot;
bs.ReadCompressed(out rot);
ushort cd;
bs.ReadCompressed(out cd);
ushort speed;
bs.ReadCompressed(out speed);
ushort vision;
bs.ReadCompressed(out vision);
ushort viewCof;
bs.ReadCompressed(out viewCof);
ushort cannonPrecisionMax;
bs.ReadCompressed(out cannonPrecisionMax);
ushort cannonPrecisionMin;
bs.ReadCompressed(out cannonPrecisionMin);
uint hp;
bs.ReadCompressed(out hp);
ushort rageMax;
bs.ReadCompressed(out rageMax);
ushort rage;
bs.ReadCompressed(out rage);
PlayerEnterRoomRsp val = new PlayerEnterRoomRsp(bindUID,userid,group,x,y,z,rot,cd,speed,vision,viewCof,cannonPrecisionMax,cannonPrecisionMin,hp,rageMax,rage);
list.Add(val); 
lst.Add(val); 
}
 DataHelper.Refresh(typeof(PlayerEnterRoomRsp), lst);
if(delegate_ID_LOBBY_ROOM_ENTERINFO_RSP!=null)
{
delegate_ID_LOBBY_ROOM_ENTERINFO_RSP(_errcode, instanceID,battleID, list.ToArray());
}
}


public static void Send_ID_TRAP_ENTER(uint instanceID,ushort objID)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(instanceID);
bs.WriteCompressed(objID);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_TRAP_ENTER, bs));
}


public static void Send_ID_TRAP_LEAVE(uint instanceID,ushort objID)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(instanceID);
bs.WriteCompressed(objID);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_TRAP_LEAVE, bs));
}

public delegate void  Delegate_ID_PLAYER_ATTR_CHANGE_RSP(int _errcode, ushort attr,uint value,uint userID);
public static  Delegate_ID_PLAYER_ATTR_CHANGE_RSP delegate_ID_PLAYER_ATTR_CHANGE_RSP = null;
public delegate void  Delegate_ID_PLAYER_ATTR_CHANGE_RSP_completed();
public static  Delegate_ID_PLAYER_ATTR_CHANGE_RSP_completed delegate_ID_PLAYER_ATTR_CHANGE_RSP_completed = null;

public static void Recv_ID_PLAYER_ATTR_CHANGE_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
List<IData>list = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
 {
ushort attr;
bs.ReadCompressed(out attr);
uint value;
bs.ReadCompressed(out value);
uint userID;
bs.ReadCompressed(out userID);

AttrKeyValue data = new AttrKeyValue(attr,value,userID);
list.Add(data);
if(delegate_ID_PLAYER_ATTR_CHANGE_RSP!=null)
{
delegate_ID_PLAYER_ATTR_CHANGE_RSP(_errcode, attr,value,userID);
}
}
DataHelper.Refresh(typeof(AttrKeyValue), list);
if(delegate_ID_PLAYER_ATTR_CHANGE_RSP_completed!=null)
{
delegate_ID_PLAYER_ATTR_CHANGE_RSP_completed();}
}

public delegate void  Delegate_ID_BATTLE_OBJECT_CREATE_RSP(int _errcode, byte objID,byte tableID,short x,short y,short z);
public static  Delegate_ID_BATTLE_OBJECT_CREATE_RSP delegate_ID_BATTLE_OBJECT_CREATE_RSP = null;
public delegate void  Delegate_ID_BATTLE_OBJECT_CREATE_RSP_completed();
public static  Delegate_ID_BATTLE_OBJECT_CREATE_RSP_completed delegate_ID_BATTLE_OBJECT_CREATE_RSP_completed = null;

public static void Recv_ID_BATTLE_OBJECT_CREATE_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
List<IData>list = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
 {
byte objID;
bs.ReadCompressed(out objID);
byte tableID;
bs.ReadCompressed(out tableID);
short x;
bs.ReadCompressed(out x);
short y;
bs.ReadCompressed(out y);
short z;
bs.ReadCompressed(out z);

BattleObject data = new BattleObject(objID,tableID,x,y,z);
list.Add(data);
if(delegate_ID_BATTLE_OBJECT_CREATE_RSP!=null)
{
delegate_ID_BATTLE_OBJECT_CREATE_RSP(_errcode, objID,tableID,x,y,z);
}
}
DataHelper.Refresh(typeof(BattleObject), list);
if(delegate_ID_BATTLE_OBJECT_CREATE_RSP_completed!=null)
{
delegate_ID_BATTLE_OBJECT_CREATE_RSP_completed();}
}

public delegate void  Delegate_ID_BATTLE_MOVE_RSP(int _errcode, uint id,ushort duration,short x,short z,uint timestamp);
public static  Delegate_ID_BATTLE_MOVE_RSP delegate_ID_BATTLE_MOVE_RSP = null;

public static void Recv_ID_BATTLE_MOVE_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
uint id;
bs.ReadCompressed(out id);
ushort duration;
bs.ReadCompressed(out duration);
short x;
bs.ReadCompressed(out x);
short z;
bs.ReadCompressed(out z);
uint timestamp;
bs.ReadCompressed(out timestamp);
if(delegate_ID_BATTLE_MOVE_RSP!=null)
{
delegate_ID_BATTLE_MOVE_RSP(_errcode, id,duration,x,z,timestamp);
}
}

public delegate void  Delegate_ID_BATTLE_POS_RSP(int _errcode, uint id,short x,short z);
public static  Delegate_ID_BATTLE_POS_RSP delegate_ID_BATTLE_POS_RSP = null;

public static void Recv_ID_BATTLE_POS_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
uint id;
bs.ReadCompressed(out id);
short x;
bs.ReadCompressed(out x);
short z;
bs.ReadCompressed(out z);
if(delegate_ID_BATTLE_POS_RSP!=null)
{
delegate_ID_BATTLE_POS_RSP(_errcode, id,x,z);
}
}


public static void Send_ID_BATTLESERVER_END()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_BATTLESERVER_END, new RakNet.BitStream()));}


public static void Send_ID_PLAYER_GET_USERID(uint channelUserid,byte channelID)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(channelUserid);
bs.WriteCompressed(channelID);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_PLAYER_GET_USERID, bs));
}

public delegate void  Delegate_ID_PLAYER_GET_USERID_RSP(int _errcode, uint userID,byte svrID,byte type);
public static  Delegate_ID_PLAYER_GET_USERID_RSP delegate_ID_PLAYER_GET_USERID_RSP = null;

public static void Recv_ID_PLAYER_GET_USERID_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
uint userID;
bs.ReadCompressed(out userID);
byte svrID;
bs.ReadCompressed(out svrID);
byte type;
bs.ReadCompressed(out type);
if(delegate_ID_PLAYER_GET_USERID_RSP!=null)
{
delegate_ID_PLAYER_GET_USERID_RSP(_errcode, userID,svrID,type);
}
}


public static void Send_ID_PLAYER_DISCONNECT(uint instanceID,ushort roomID)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(instanceID);
bs.WriteCompressed(roomID);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_PLAYER_DISCONNECT, bs));
}


public static void Send_ID_LOBBY_LINE()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_LOBBY_LINE, new RakNet.BitStream()));}

public delegate void  Delegate_ID_LOBBY_LINE_RSP(int _errcode, uint lobbyID,byte flag,byte percent);
public static  Delegate_ID_LOBBY_LINE_RSP delegate_ID_LOBBY_LINE_RSP = null;
public delegate void  Delegate_ID_LOBBY_LINE_RSP_completed();
public static  Delegate_ID_LOBBY_LINE_RSP_completed delegate_ID_LOBBY_LINE_RSP_completed = null;

public static void Recv_ID_LOBBY_LINE_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
List<IData>list = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
 {
uint lobbyID;
bs.ReadCompressed(out lobbyID);
byte flag;
bs.ReadCompressed(out flag);
byte percent;
bs.ReadCompressed(out percent);

LobbyLine data = new LobbyLine(lobbyID,flag,percent);
list.Add(data);
if(delegate_ID_LOBBY_LINE_RSP!=null)
{
delegate_ID_LOBBY_LINE_RSP(_errcode, lobbyID,flag,percent);
}
}
DataHelper.Refresh(typeof(LobbyLine), list);
if(delegate_ID_LOBBY_LINE_RSP_completed!=null)
{
delegate_ID_LOBBY_LINE_RSP_completed();}
}


public static void Send_ID_LOBBY_ROOM(uint lobbyID,byte type,byte begin,byte end)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(lobbyID);
bs.WriteCompressed(type);
bs.WriteCompressed(begin);
bs.WriteCompressed(end);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_LOBBY_ROOM, bs));
}

public delegate void  Delegate_ID_LOBBY_ROOM_RSP(int _errcode, uint roomID,byte index,byte type,bool isPassword,bool opened,uint battleID,byte maxPlayer,byte currPlayer,RakNet.RakString name);
public static  Delegate_ID_LOBBY_ROOM_RSP delegate_ID_LOBBY_ROOM_RSP = null;
public delegate void  Delegate_ID_LOBBY_ROOM_RSP_completed();
public static  Delegate_ID_LOBBY_ROOM_RSP_completed delegate_ID_LOBBY_ROOM_RSP_completed = null;

public static void Recv_ID_LOBBY_ROOM_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
List<IData>list = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
 {
uint roomID;
bs.ReadCompressed(out roomID);
byte index;
bs.ReadCompressed(out index);
byte type;
bs.ReadCompressed(out type);
bool isPassword;
bs.ReadCompressed(out isPassword);
bool opened;
bs.ReadCompressed(out opened);
uint battleID;
bs.ReadCompressed(out battleID);
byte maxPlayer;
bs.ReadCompressed(out maxPlayer);
byte currPlayer;
bs.ReadCompressed(out currPlayer);
RakNet.RakString name;
name = new RakNet.RakString();
bs.ReadCompressed(name);

LobbyRoom data = new LobbyRoom(roomID,index,type,isPassword,opened,battleID,maxPlayer,currPlayer,name);
list.Add(data);
if(delegate_ID_LOBBY_ROOM_RSP!=null)
{
delegate_ID_LOBBY_ROOM_RSP(_errcode, roomID,index,type,isPassword,opened,battleID,maxPlayer,currPlayer,name);
}
}
DataHelper.Refresh(typeof(LobbyRoom), list);
if(delegate_ID_LOBBY_ROOM_RSP_completed!=null)
{
delegate_ID_LOBBY_ROOM_RSP_completed();}
}


public static void Send_ID_LOBBY_CREATE_ROOM(byte roomType,uint battleID)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(roomType);
bs.WriteCompressed(battleID);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_LOBBY_CREATE_ROOM, bs));
}

public delegate void  Delegate_ID_LOBBY_CREATE_ROOM_RSP(int _errcode, byte roomType,uint roomID,uint battleID);
public static  Delegate_ID_LOBBY_CREATE_ROOM_RSP delegate_ID_LOBBY_CREATE_ROOM_RSP = null;

public static void Recv_ID_LOBBY_CREATE_ROOM_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
byte roomType;
bs.ReadCompressed(out roomType);
uint roomID;
bs.ReadCompressed(out roomID);
uint battleID;
bs.ReadCompressed(out battleID);
if(delegate_ID_LOBBY_CREATE_ROOM_RSP!=null)
{
delegate_ID_LOBBY_CREATE_ROOM_RSP(_errcode, roomType,roomID,battleID);
}
}


public static void Send_ID_LOBBY_ROOM_QUICK_JOIN(uint lobbyID)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(lobbyID);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_LOBBY_ROOM_QUICK_JOIN, bs));
}

public delegate void  Delegate_ID_LOBBY_ROOM_QUICK_JOIN_RSP(int _errcode, int roomID);
public static  Delegate_ID_LOBBY_ROOM_QUICK_JOIN_RSP delegate_ID_LOBBY_ROOM_QUICK_JOIN_RSP = null;

public static void Recv_ID_LOBBY_ROOM_QUICK_JOIN_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
int roomID;
bs.ReadCompressed(out roomID);
if(delegate_ID_LOBBY_ROOM_QUICK_JOIN_RSP!=null)
{
delegate_ID_LOBBY_ROOM_QUICK_JOIN_RSP(_errcode, roomID);
}
}


public static void Send_ID_LOBBY_ROOM_JOIN(ushort lobbyID,ushort roomID)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(lobbyID);
bs.WriteCompressed(roomID);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_LOBBY_ROOM_JOIN, bs));
}

public delegate void  Delegate_ID_LOBBY_ROOM_JOIN_RSP(int _errcode, uint userID,bool isHost,bool isReady,byte group,byte index,RakNet.RakString userName,ushort tankID,byte tankSubid,ushort pilotAId,byte pilotASubid,ushort pilotBId,byte pilotBSubid,ushort pilotCId,byte pilotCSubid,ushort lv,ushort head,uint coatingId,uint matchGroupId,RakNet.RakString corpsName,RakNet.RakString corpsLvName,uint decortionPos1,uint decortionPos2,uint decortionPos3,uint decortionPos4,uint decortionPos5,uint decortionPos6,uint decortionPos7,uint killRank,uint corpsKillRank);
public static  Delegate_ID_LOBBY_ROOM_JOIN_RSP delegate_ID_LOBBY_ROOM_JOIN_RSP = null;
public delegate void  Delegate_ID_LOBBY_ROOM_JOIN_RSP_completed();
public static  Delegate_ID_LOBBY_ROOM_JOIN_RSP_completed delegate_ID_LOBBY_ROOM_JOIN_RSP_completed = null;

public static void Recv_ID_LOBBY_ROOM_JOIN_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
List<IData>list = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
 {
uint userID;
bs.ReadCompressed(out userID);
bool isHost;
bs.ReadCompressed(out isHost);
bool isReady;
bs.ReadCompressed(out isReady);
byte group;
bs.ReadCompressed(out group);
byte index;
bs.ReadCompressed(out index);
RakNet.RakString userName;
userName = new RakNet.RakString();
bs.ReadCompressed(userName);
ushort tankID;
bs.ReadCompressed(out tankID);
byte tankSubid;
bs.ReadCompressed(out tankSubid);
ushort pilotAId;
bs.ReadCompressed(out pilotAId);
byte pilotASubid;
bs.ReadCompressed(out pilotASubid);
ushort pilotBId;
bs.ReadCompressed(out pilotBId);
byte pilotBSubid;
bs.ReadCompressed(out pilotBSubid);
ushort pilotCId;
bs.ReadCompressed(out pilotCId);
byte pilotCSubid;
bs.ReadCompressed(out pilotCSubid);
ushort lv;
bs.ReadCompressed(out lv);
ushort head;
bs.ReadCompressed(out head);
uint coatingId;
bs.ReadCompressed(out coatingId);
uint matchGroupId;
bs.ReadCompressed(out matchGroupId);
RakNet.RakString corpsName;
corpsName = new RakNet.RakString();
bs.ReadCompressed(corpsName);
RakNet.RakString corpsLvName;
corpsLvName = new RakNet.RakString();
bs.ReadCompressed(corpsLvName);
uint decortionPos1;
bs.ReadCompressed(out decortionPos1);
uint decortionPos2;
bs.ReadCompressed(out decortionPos2);
uint decortionPos3;
bs.ReadCompressed(out decortionPos3);
uint decortionPos4;
bs.ReadCompressed(out decortionPos4);
uint decortionPos5;
bs.ReadCompressed(out decortionPos5);
uint decortionPos6;
bs.ReadCompressed(out decortionPos6);
uint decortionPos7;
bs.ReadCompressed(out decortionPos7);
uint killRank;
bs.ReadCompressed(out killRank);
uint corpsKillRank;
bs.ReadCompressed(out corpsKillRank);

RoomPlayerInfo data = new RoomPlayerInfo(userID,isHost,isReady,group,index,userName,tankID,tankSubid,pilotAId,pilotASubid,pilotBId,pilotBSubid,pilotCId,pilotCSubid,lv,head,coatingId,matchGroupId,corpsName,corpsLvName,decortionPos1,decortionPos2,decortionPos3,decortionPos4,decortionPos5,decortionPos6,decortionPos7,killRank,corpsKillRank);
list.Add(data);
if(delegate_ID_LOBBY_ROOM_JOIN_RSP!=null)
{
delegate_ID_LOBBY_ROOM_JOIN_RSP(_errcode, userID,isHost,isReady,group,index,userName,tankID,tankSubid,pilotAId,pilotASubid,pilotBId,pilotBSubid,pilotCId,pilotCSubid,lv,head,coatingId,matchGroupId,corpsName,corpsLvName,decortionPos1,decortionPos2,decortionPos3,decortionPos4,decortionPos5,decortionPos6,decortionPos7,killRank,corpsKillRank);
}
}
DataHelper.Refresh(typeof(RoomPlayerInfo), list);
if(delegate_ID_LOBBY_ROOM_JOIN_RSP_completed!=null)
{
delegate_ID_LOBBY_ROOM_JOIN_RSP_completed();}
}

public delegate void  Delegate_ID_LOBBY_ROOM_CHANGE_TANK_RSP(int _errcode, uint userID,ushort tankID,byte tankSubid,ushort pilotAId,ushort pilotBId,ushort pilotCId);
public static  Delegate_ID_LOBBY_ROOM_CHANGE_TANK_RSP delegate_ID_LOBBY_ROOM_CHANGE_TANK_RSP = null;

public static void Recv_ID_LOBBY_ROOM_CHANGE_TANK_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
uint userID;
bs.ReadCompressed(out userID);
ushort tankID;
bs.ReadCompressed(out tankID);
byte tankSubid;
bs.ReadCompressed(out tankSubid);
ushort pilotAId;
bs.ReadCompressed(out pilotAId);
ushort pilotBId;
bs.ReadCompressed(out pilotBId);
ushort pilotCId;
bs.ReadCompressed(out pilotCId);
if(delegate_ID_LOBBY_ROOM_CHANGE_TANK_RSP!=null)
{
delegate_ID_LOBBY_ROOM_CHANGE_TANK_RSP(_errcode, userID,tankID,tankSubid,pilotAId,pilotBId,pilotCId);
}
}


public static void Send_ID_LOBBY_ROOM_INVITE(byte serverID,uint inviteUserid,byte roomType,uint battleID)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(serverID);
bs.WriteCompressed(inviteUserid);
bs.WriteCompressed(roomType);
bs.WriteCompressed(battleID);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_LOBBY_ROOM_INVITE, bs));
}

public delegate void  Delegate_ID_LOBBY_ROOM_INVITE_RSP(int _errcode, byte serverID,uint userID,byte lobbyID,ushort roomID,byte roomType,uint battleID);
public static  Delegate_ID_LOBBY_ROOM_INVITE_RSP delegate_ID_LOBBY_ROOM_INVITE_RSP = null;

public static void Recv_ID_LOBBY_ROOM_INVITE_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
byte serverID;
bs.ReadCompressed(out serverID);
uint userID;
bs.ReadCompressed(out userID);
byte lobbyID;
bs.ReadCompressed(out lobbyID);
ushort roomID;
bs.ReadCompressed(out roomID);
byte roomType;
bs.ReadCompressed(out roomType);
uint battleID;
bs.ReadCompressed(out battleID);
if(delegate_ID_LOBBY_ROOM_INVITE_RSP!=null)
{
delegate_ID_LOBBY_ROOM_INVITE_RSP(_errcode, serverID,userID,lobbyID,roomID,roomType,battleID);
}
}


public static void Send_ID_LOBBY_ROOM_EXIT(uint userID,uint roomID)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(userID);
bs.WriteCompressed(roomID);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_LOBBY_ROOM_EXIT, bs));
}

public delegate void  Delegate_ID_LOBBY_ROOM_EXIT_RSP(int _errcode, uint userID);
public static  Delegate_ID_LOBBY_ROOM_EXIT_RSP delegate_ID_LOBBY_ROOM_EXIT_RSP = null;

public static void Recv_ID_LOBBY_ROOM_EXIT_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
uint userID;
bs.ReadCompressed(out userID);
if(delegate_ID_LOBBY_ROOM_EXIT_RSP!=null)
{
delegate_ID_LOBBY_ROOM_EXIT_RSP(_errcode, userID);
}
}


public static void Send_ID_LOBBY_ROOM_CHANGE(uint key,uint value)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(key);
bs.WriteCompressed(value);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_LOBBY_ROOM_CHANGE, bs));
}

public delegate void  Delegate_ID_LOBBY_ROOM_CHANGE_RSP(int _errcode, uint key,uint value,uint value2,uint value3);
public static  Delegate_ID_LOBBY_ROOM_CHANGE_RSP delegate_ID_LOBBY_ROOM_CHANGE_RSP = null;

public static void Recv_ID_LOBBY_ROOM_CHANGE_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
uint key;
bs.ReadCompressed(out key);
uint value;
bs.ReadCompressed(out value);
uint value2;
bs.ReadCompressed(out value2);
uint value3;
bs.ReadCompressed(out value3);
if(delegate_ID_LOBBY_ROOM_CHANGE_RSP!=null)
{
delegate_ID_LOBBY_ROOM_CHANGE_RSP(_errcode, key,value,value2,value3);
}
}


public static void Send_ID_LOBBY_ROOM_READY(bool isReady)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(isReady);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_LOBBY_ROOM_READY, bs));
}

public delegate void  Delegate_ID_LOBBY_ROOM_READY_RSP(int _errcode, uint userid,bool isReady);
public static  Delegate_ID_LOBBY_ROOM_READY_RSP delegate_ID_LOBBY_ROOM_READY_RSP = null;
public delegate void  Delegate_ID_LOBBY_ROOM_READY_RSP_completed();
public static  Delegate_ID_LOBBY_ROOM_READY_RSP_completed delegate_ID_LOBBY_ROOM_READY_RSP_completed = null;

public static void Recv_ID_LOBBY_ROOM_READY_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
List<IData>list = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
 {
uint userid;
bs.ReadCompressed(out userid);
bool isReady;
bs.ReadCompressed(out isReady);

RoomReadyInfo data = new RoomReadyInfo(userid,isReady);
list.Add(data);
if(delegate_ID_LOBBY_ROOM_READY_RSP!=null)
{
delegate_ID_LOBBY_ROOM_READY_RSP(_errcode, userid,isReady);
}
}
DataHelper.Refresh(typeof(RoomReadyInfo), list);
if(delegate_ID_LOBBY_ROOM_READY_RSP_completed!=null)
{
delegate_ID_LOBBY_ROOM_READY_RSP_completed();}
}


public static void Send_ID_LOBBY_ROOM_START(uint battleID)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(battleID);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_LOBBY_ROOM_START, bs));
}

public delegate void  Delegate_ID_GAME_FINSIHED_RSP(int _errcode);
public static  Delegate_ID_GAME_FINSIHED_RSP delegate_ID_GAME_FINSIHED_RSP = null;

public static void Recv_ID_GAME_FINSIHED_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
if(delegate_ID_GAME_FINSIHED_RSP!=null)
{
delegate_ID_GAME_FINSIHED_RSP(_errcode);
}
}


public static void Send_ID_PLAYER_LOGIN(uint userid,ushort channelID,RakNet.RakString device,uint protoVersion,RakNet.RakString token)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(userid);
bs.WriteCompressed(channelID);
bs.WriteCompressed(device);
bs.WriteCompressed(protoVersion);
bs.WriteCompressed(token);
TankSendMsg.SendImmediate(Common.CraetePkg(MessageID.ID_PLAYER_LOGIN, bs));
}


public static void Send_ID_PLAYER_CREATE_ROLE(uint userID,RakNet.RakString name,byte gender,uint avatarID,uint pilotID,byte pilotSubID)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(userID);
bs.WriteCompressed(name);
bs.WriteCompressed(gender);
bs.WriteCompressed(avatarID);
bs.WriteCompressed(pilotID);
bs.WriteCompressed(pilotSubID);
TankSendMsg.SendImmediate(Common.CraetePkg(MessageID.ID_PLAYER_CREATE_ROLE, bs));
}

public delegate void  Delegate_ID_PLAYER_LOGIN_FINISHED_RSP(int _errcode);
public static  Delegate_ID_PLAYER_LOGIN_FINISHED_RSP delegate_ID_PLAYER_LOGIN_FINISHED_RSP = null;

public static void Recv_ID_PLAYER_LOGIN_FINISHED_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
if(delegate_ID_PLAYER_LOGIN_FINISHED_RSP!=null)
{
delegate_ID_PLAYER_LOGIN_FINISHED_RSP(_errcode);
}
}

public delegate void  Delegate_ID_PLAYER_REPEATED_LOGIN_RSP(int _errcode);
public static  Delegate_ID_PLAYER_REPEATED_LOGIN_RSP delegate_ID_PLAYER_REPEATED_LOGIN_RSP = null;

public static void Recv_ID_PLAYER_REPEATED_LOGIN_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
if(delegate_ID_PLAYER_REPEATED_LOGIN_RSP!=null)
{
delegate_ID_PLAYER_REPEATED_LOGIN_RSP(_errcode);
}
}


public static void Send_ID_PLAYER_LOGINOUT()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_PLAYER_LOGINOUT, new RakNet.BitStream()));}

public delegate void  Delegate_ID_PLAYER_LOGINOUT_RSP(int _errcode);
public static  Delegate_ID_PLAYER_LOGINOUT_RSP delegate_ID_PLAYER_LOGINOUT_RSP = null;

public static void Recv_ID_PLAYER_LOGINOUT_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
if(delegate_ID_PLAYER_LOGINOUT_RSP!=null)
{
delegate_ID_PLAYER_LOGINOUT_RSP(_errcode);
}
}


public static void Send_ID_PLAYER_PVE_LEVELINFOS(byte modetype)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.Write(modetype);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_PLAYER_PVE_LEVELINFOS, bs));
}

public delegate void  Delegate_ID_PLAYER_PVE_LEVELINFOS_RSP(int _errcode, uint totalStars,LevelBasicInfo[]  list );
public static  Delegate_ID_PLAYER_PVE_LEVELINFOS_RSP delegate_ID_PLAYER_PVE_LEVELINFOS_RSP = null;

public static void Recv_ID_PLAYER_PVE_LEVELINFOS_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
uint totalStars;
bs.ReadCompressed(out totalStars);
List<LevelBasicInfo> list = new List<LevelBasicInfo>();
List<IData> lst = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
{uint levelid;
bs.Read(out levelid);
uint tankid;
bs.Read(out tankid);
byte modetype;
bs.Read(out modetype);
byte times;
bs.Read(out times);
byte stars;
bs.Read(out stars);
LevelBasicInfo val = new LevelBasicInfo(levelid,tankid,modetype,times,stars);
list.Add(val); 
lst.Add(val); 
}
 DataHelper.Refresh(typeof(LevelBasicInfo), lst);
if(delegate_ID_PLAYER_PVE_LEVELINFOS_RSP!=null)
{
delegate_ID_PLAYER_PVE_LEVELINFOS_RSP(_errcode, totalStars, list.ToArray());
}
}


public static void Send_ID_PLAYER_PVE_START(uint levelid)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(levelid);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_PLAYER_PVE_START, bs));
}

public delegate void  Delegate_ID_PLAYER_PVE_START_RSP(int _errcode, uint energy);
public static  Delegate_ID_PLAYER_PVE_START_RSP delegate_ID_PLAYER_PVE_START_RSP = null;

public static void Recv_ID_PLAYER_PVE_START_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
uint energy;
bs.ReadCompressed(out energy);
if(delegate_ID_PLAYER_PVE_START_RSP!=null)
{
delegate_ID_PLAYER_PVE_START_RSP(_errcode, energy);
}
}


public static void Send_ID_PLAYER_PVE_RESULT(uint levelid,byte modetype,bool isWin,uint tankid,uint star,uint count)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(levelid);
bs.WriteCompressed(modetype);
bs.WriteCompressed(isWin);
bs.WriteCompressed(tankid);
bs.WriteCompressed(star);
bs.WriteCompressed(count);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_PLAYER_PVE_RESULT, bs));
}

public delegate void  Delegate_ID_PLAYER_PVE_RESULT_RSP(int _errcode, bool first,bool isSuccess,PVEDropItemCount[]  list );
public static  Delegate_ID_PLAYER_PVE_RESULT_RSP delegate_ID_PLAYER_PVE_RESULT_RSP = null;

public static void Recv_ID_PLAYER_PVE_RESULT_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
bool first;
bs.ReadCompressed(out first);
bool isSuccess;
bs.ReadCompressed(out isSuccess);
List<PVEDropItemCount> list = new List<PVEDropItemCount>();
List<IData> lst = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
{bool isFirst;
bs.ReadCompressed(out isFirst);
uint itemid;
bs.ReadCompressed(out itemid);
uint count;
bs.ReadCompressed(out count);
PVEDropItemCount val = new PVEDropItemCount(isFirst,itemid,count);
list.Add(val); 
lst.Add(val); 
}
 DataHelper.Refresh(typeof(PVEDropItemCount), lst);
if(delegate_ID_PLAYER_PVE_RESULT_RSP!=null)
{
delegate_ID_PLAYER_PVE_RESULT_RSP(_errcode, first,isSuccess, list.ToArray());
}
}

public delegate void  Delegate_ID_PLAYER_INFO_CHANGE_RSP(int _errcode, byte changeid,uint curValue,uint value1,uint value2);
public static  Delegate_ID_PLAYER_INFO_CHANGE_RSP delegate_ID_PLAYER_INFO_CHANGE_RSP = null;
public delegate void  Delegate_ID_PLAYER_INFO_CHANGE_RSP_completed();
public static  Delegate_ID_PLAYER_INFO_CHANGE_RSP_completed delegate_ID_PLAYER_INFO_CHANGE_RSP_completed = null;

public static void Recv_ID_PLAYER_INFO_CHANGE_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
List<IData>list = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
 {
byte changeid;
bs.ReadCompressed(out changeid);
uint curValue;
bs.ReadCompressed(out curValue);
uint value1;
bs.ReadCompressed(out value1);
uint value2;
bs.ReadCompressed(out value2);

PlayerInfoChangeRsp data = new PlayerInfoChangeRsp(changeid,curValue,value1,value2);
list.Add(data);
if(delegate_ID_PLAYER_INFO_CHANGE_RSP!=null)
{
delegate_ID_PLAYER_INFO_CHANGE_RSP(_errcode, changeid,curValue,value1,value2);
}
}
DataHelper.Refresh(typeof(PlayerInfoChangeRsp), list);
if(delegate_ID_PLAYER_INFO_CHANGE_RSP_completed!=null)
{
delegate_ID_PLAYER_INFO_CHANGE_RSP_completed();}
}


public static void Send_ID_WAREHOUSE_TANK_LIST()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_WAREHOUSE_TANK_LIST, new RakNet.BitStream()));}

public delegate void  Delegate_ID_WAREHOUSE_TANK_LIST_RSP(int _errcode, byte type,byte tankFrom,WarehouseTankDetailInfo[]  list );
public static  Delegate_ID_WAREHOUSE_TANK_LIST_RSP delegate_ID_WAREHOUSE_TANK_LIST_RSP = null;

public static void Recv_ID_WAREHOUSE_TANK_LIST_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
byte type;
bs.ReadCompressed(out type);
byte tankFrom;
bs.ReadCompressed(out tankFrom);
List<WarehouseTankDetailInfo> list = new List<WarehouseTankDetailInfo>();
List<IData> lst = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
{ushort tankId;
bs.ReadCompressed(out tankId);
ushort tankTempId;
bs.ReadCompressed(out tankTempId);
byte tankRank;
bs.ReadCompressed(out tankRank);
byte tankLvl;
bs.ReadCompressed(out tankLvl);
uint tankExp;
bs.ReadCompressed(out tankExp);
byte equipALvl;
bs.ReadCompressed(out equipALvl);
byte equipBLvl;
bs.ReadCompressed(out equipBLvl);
byte equipCLvl;
bs.ReadCompressed(out equipCLvl);
byte equipDLvl;
bs.ReadCompressed(out equipDLvl);
byte equipELvl;
bs.ReadCompressed(out equipELvl);
ushort pilotAId;
bs.ReadCompressed(out pilotAId);
ushort pilotBId;
bs.ReadCompressed(out pilotBId);
ushort pilotCId;
bs.ReadCompressed(out pilotCId);
ushort pilotDId;
bs.ReadCompressed(out pilotDId);
ushort pilotEId;
bs.ReadCompressed(out pilotEId);
uint professorId;
bs.ReadCompressed(out professorId);
uint skillId;
bs.ReadCompressed(out skillId);
uint useTimes;
bs.ReadCompressed(out useTimes);
uint devExp;
bs.ReadCompressed(out devExp);
uint skillResetTimes;
bs.ReadCompressed(out skillResetTimes);
WarehouseTankDetailInfo val = new WarehouseTankDetailInfo(tankId,tankTempId,tankRank,tankLvl,tankExp,equipALvl,equipBLvl,equipCLvl,equipDLvl,equipELvl,pilotAId,pilotBId,pilotCId,pilotDId,pilotEId,professorId,skillId,useTimes,devExp,skillResetTimes);
list.Add(val); 
lst.Add(val); 
}
 DataHelper.Refresh(typeof(WarehouseTankDetailInfo), lst);
if(delegate_ID_WAREHOUSE_TANK_LIST_RSP!=null)
{
delegate_ID_WAREHOUSE_TANK_LIST_RSP(_errcode, type,tankFrom, list.ToArray());
}
}


public static void Send_ID_WAREHOUSE_TANK_DETAIL_INFO(ushort tankId)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(tankId);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_WAREHOUSE_TANK_DETAIL_INFO, bs));
}

public delegate void  Delegate_ID_WAREHOUSE_TANK_DETAIL_INFO_RSP(int _errcode, byte type,WarehouseTankDetailInfo[]  list );
public static  Delegate_ID_WAREHOUSE_TANK_DETAIL_INFO_RSP delegate_ID_WAREHOUSE_TANK_DETAIL_INFO_RSP = null;

public static void Recv_ID_WAREHOUSE_TANK_DETAIL_INFO_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
byte type;
bs.ReadCompressed(out type);
List<WarehouseTankDetailInfo> list = new List<WarehouseTankDetailInfo>();
List<IData> lst = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
{ushort tankId;
bs.ReadCompressed(out tankId);
ushort tankTempId;
bs.ReadCompressed(out tankTempId);
byte tankRank;
bs.ReadCompressed(out tankRank);
byte tankLvl;
bs.ReadCompressed(out tankLvl);
uint tankExp;
bs.ReadCompressed(out tankExp);
byte equipALvl;
bs.ReadCompressed(out equipALvl);
byte equipBLvl;
bs.ReadCompressed(out equipBLvl);
byte equipCLvl;
bs.ReadCompressed(out equipCLvl);
byte equipDLvl;
bs.ReadCompressed(out equipDLvl);
byte equipELvl;
bs.ReadCompressed(out equipELvl);
ushort pilotAId;
bs.ReadCompressed(out pilotAId);
ushort pilotBId;
bs.ReadCompressed(out pilotBId);
ushort pilotCId;
bs.ReadCompressed(out pilotCId);
ushort pilotDId;
bs.ReadCompressed(out pilotDId);
ushort pilotEId;
bs.ReadCompressed(out pilotEId);
uint professorId;
bs.ReadCompressed(out professorId);
uint skillId;
bs.ReadCompressed(out skillId);
uint useTimes;
bs.ReadCompressed(out useTimes);
uint devExp;
bs.ReadCompressed(out devExp);
uint skillResetTimes;
bs.ReadCompressed(out skillResetTimes);
WarehouseTankDetailInfo val = new WarehouseTankDetailInfo(tankId,tankTempId,tankRank,tankLvl,tankExp,equipALvl,equipBLvl,equipCLvl,equipDLvl,equipELvl,pilotAId,pilotBId,pilotCId,pilotDId,pilotEId,professorId,skillId,useTimes,devExp,skillResetTimes);
list.Add(val); 
lst.Add(val); 
}
 DataHelper.Refresh(typeof(WarehouseTankDetailInfo), lst);
if(delegate_ID_WAREHOUSE_TANK_DETAIL_INFO_RSP!=null)
{
delegate_ID_WAREHOUSE_TANK_DETAIL_INFO_RSP(_errcode, type, list.ToArray());
}
}


public static void Send_ID_WAREHOUSE_TANK_ADD_EXP(ushort tankId,TankExpMaterial[] itemIdList)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(tankId);
foreach(TankExpMaterial val in itemIdList)
{
bs.WriteCompressed(val.type);
bs.WriteCompressed(val.id);
bs.WriteCompressed(val.num);
}
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_WAREHOUSE_TANK_ADD_EXP, bs));
}

public delegate void  Delegate_ID_WAREHOUSE_TANK_ADD_EXP_RSP(int _errcode, ushort tankId,uint curExp,byte curLvl);
public static  Delegate_ID_WAREHOUSE_TANK_ADD_EXP_RSP delegate_ID_WAREHOUSE_TANK_ADD_EXP_RSP = null;

public static void Recv_ID_WAREHOUSE_TANK_ADD_EXP_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
ushort tankId;
bs.ReadCompressed(out tankId);
uint curExp;
bs.ReadCompressed(out curExp);
byte curLvl;
bs.ReadCompressed(out curLvl);
if(delegate_ID_WAREHOUSE_TANK_ADD_EXP_RSP!=null)
{
delegate_ID_WAREHOUSE_TANK_ADD_EXP_RSP(_errcode, tankId,curExp,curLvl);
}
}


public static void Send_ID_WAREHOUSE_TANK_RANK_UP(ushort tankId)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(tankId);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_WAREHOUSE_TANK_RANK_UP, bs));
}

public delegate void  Delegate_ID_WAREHOUSE_TANK_RANK_UP_RSP(int _errcode, ushort tankId,byte curRank,uint skillId);
public static  Delegate_ID_WAREHOUSE_TANK_RANK_UP_RSP delegate_ID_WAREHOUSE_TANK_RANK_UP_RSP = null;

public static void Recv_ID_WAREHOUSE_TANK_RANK_UP_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
ushort tankId;
bs.ReadCompressed(out tankId);
byte curRank;
bs.ReadCompressed(out curRank);
uint skillId;
bs.ReadCompressed(out skillId);
if(delegate_ID_WAREHOUSE_TANK_RANK_UP_RSP!=null)
{
delegate_ID_WAREHOUSE_TANK_RANK_UP_RSP(_errcode, tankId,curRank,skillId);
}
}


public static void Send_ID_WAREHOUSE_TANK_EQUIP_LVLUP(ushort tankId,byte equipIdx,byte oneKey)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(tankId);
bs.WriteCompressed(equipIdx);
bs.WriteCompressed(oneKey);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_WAREHOUSE_TANK_EQUIP_LVLUP, bs));
}

public delegate void  Delegate_ID_WAREHOUSE_TANK_EQUIP_LVLUP_RSP(int _errcode, ushort tankId,byte equipIdx,byte equipLvl);
public static  Delegate_ID_WAREHOUSE_TANK_EQUIP_LVLUP_RSP delegate_ID_WAREHOUSE_TANK_EQUIP_LVLUP_RSP = null;

public static void Recv_ID_WAREHOUSE_TANK_EQUIP_LVLUP_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
ushort tankId;
bs.ReadCompressed(out tankId);
byte equipIdx;
bs.ReadCompressed(out equipIdx);
byte equipLvl;
bs.ReadCompressed(out equipLvl);
if(delegate_ID_WAREHOUSE_TANK_EQUIP_LVLUP_RSP!=null)
{
delegate_ID_WAREHOUSE_TANK_EQUIP_LVLUP_RSP(_errcode, tankId,equipIdx,equipLvl);
}
}


public static void Send_ID_ITEM_LIST()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_ITEM_LIST, new RakNet.BitStream()));}

public delegate void  Delegate_ID_ITEM_LIST_RSP(int _errcode, byte updateType,byte itemFrom,ItemInfo[]  list );
public static  Delegate_ID_ITEM_LIST_RSP delegate_ID_ITEM_LIST_RSP = null;

public static void Recv_ID_ITEM_LIST_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
byte updateType;
bs.ReadCompressed(out updateType);
byte itemFrom;
bs.ReadCompressed(out itemFrom);
List<ItemInfo> list = new List<ItemInfo>();
List<IData> lst = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
{uint itemId;
bs.ReadCompressed(out itemId);
uint itemNum;
bs.ReadCompressed(out itemNum);
ItemInfo val = new ItemInfo(itemId,itemNum);
list.Add(val); 
lst.Add(val); 
}
 DataHelper.Refresh(typeof(ItemInfo), lst);
if(delegate_ID_ITEM_LIST_RSP!=null)
{
delegate_ID_ITEM_LIST_RSP(_errcode, updateType,itemFrom, list.ToArray());
}
}

public delegate void  Delegate_ID_PVP_BATTLE_CHAOS_FINISHED_RSP(int _errcode, bool result,uint coin,uint exp,uint memberExp,uint dropItem,uint vitality,uint honor,ushort coinVip,ushort expVip,ushort honorVip,ushort expoverflow,uint expRate,uint rewardExpRate,uint rewardGoldRate,uint rewardHonorRate,uint rewardItemRate,uint successExp,uint honorExp,uint hurtExp,uint fightCountExp,uint activeExp,uint specialTankExp,uint corpsExp,uint vipExp,uint winResult,PilotFavor[]  list );
public static  Delegate_ID_PVP_BATTLE_CHAOS_FINISHED_RSP delegate_ID_PVP_BATTLE_CHAOS_FINISHED_RSP = null;

public static void Recv_ID_PVP_BATTLE_CHAOS_FINISHED_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
bool result;
bs.ReadCompressed(out result);
uint coin;
bs.ReadCompressed(out coin);
uint exp;
bs.ReadCompressed(out exp);
uint memberExp;
bs.ReadCompressed(out memberExp);
uint dropItem;
bs.ReadCompressed(out dropItem);
uint vitality;
bs.ReadCompressed(out vitality);
uint honor;
bs.ReadCompressed(out honor);
ushort coinVip;
bs.ReadCompressed(out coinVip);
ushort expVip;
bs.ReadCompressed(out expVip);
ushort honorVip;
bs.ReadCompressed(out honorVip);
ushort expoverflow;
bs.ReadCompressed(out expoverflow);
uint expRate;
bs.ReadCompressed(out expRate);
uint rewardExpRate;
bs.ReadCompressed(out rewardExpRate);
uint rewardGoldRate;
bs.ReadCompressed(out rewardGoldRate);
uint rewardHonorRate;
bs.ReadCompressed(out rewardHonorRate);
uint rewardItemRate;
bs.ReadCompressed(out rewardItemRate);
uint successExp;
bs.ReadCompressed(out successExp);
uint honorExp;
bs.ReadCompressed(out honorExp);
uint hurtExp;
bs.ReadCompressed(out hurtExp);
uint fightCountExp;
bs.ReadCompressed(out fightCountExp);
uint activeExp;
bs.ReadCompressed(out activeExp);
uint specialTankExp;
bs.ReadCompressed(out specialTankExp);
uint corpsExp;
bs.ReadCompressed(out corpsExp);
uint vipExp;
bs.ReadCompressed(out vipExp);
uint winResult;
bs.ReadCompressed(out winResult);
List<PilotFavor> list = new List<PilotFavor>();
List<IData> lst = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
{uint id;
bs.ReadCompressed(out id);
uint favor;
bs.ReadCompressed(out favor);
PilotFavor val = new PilotFavor(id,favor);
list.Add(val); 
lst.Add(val); 
}
 DataHelper.Refresh(typeof(PilotFavor), lst);
if(delegate_ID_PVP_BATTLE_CHAOS_FINISHED_RSP!=null)
{
delegate_ID_PVP_BATTLE_CHAOS_FINISHED_RSP(_errcode, result,coin,exp,memberExp,dropItem,vitality,honor,coinVip,expVip,honorVip,expoverflow,expRate,rewardExpRate,rewardGoldRate,rewardHonorRate,rewardItemRate,successExp,honorExp,hurtExp,fightCountExp,activeExp,specialTankExp,corpsExp,vipExp,winResult, list.ToArray());
}
}


public static void Send_ID_PLAYER_ACTIVE(byte flag)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(flag);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_PLAYER_ACTIVE, bs));
}


public static void Send_ID_GM_MSG(byte gmCmdType,RakNet.RakString gmCmdStr)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(gmCmdType);
bs.WriteCompressed(gmCmdStr);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_GM_MSG, bs));
}

public delegate void  Delegate_ID_MAIL_NEW_COMING_RSP(int _errcode);
public static  Delegate_ID_MAIL_NEW_COMING_RSP delegate_ID_MAIL_NEW_COMING_RSP = null;

public static void Recv_ID_MAIL_NEW_COMING_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
if(delegate_ID_MAIL_NEW_COMING_RSP!=null)
{
delegate_ID_MAIL_NEW_COMING_RSP(_errcode);
}
}

public delegate void  Delegate_ID_BATLLESERVER_IP_RSP(int _errcode, ushort svrID,uint tokenID,RakNet.RakString ip);
public static  Delegate_ID_BATLLESERVER_IP_RSP delegate_ID_BATLLESERVER_IP_RSP = null;

public static void Recv_ID_BATLLESERVER_IP_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
ushort svrID;
bs.ReadCompressed(out svrID);
uint tokenID;
bs.ReadCompressed(out tokenID);
RakNet.RakString ip;
ip = new RakNet.RakString();
bs.ReadCompressed(ip);
if(delegate_ID_BATLLESERVER_IP_RSP!=null)
{
delegate_ID_BATLLESERVER_IP_RSP(_errcode, svrID,tokenID,ip);
}
}


public static void Send_ID_BATTLE_TO_LOGIC_INIT()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_BATTLE_TO_LOGIC_INIT, new RakNet.BitStream()));}


public static void Send_ID_LOGIC_TO_BATTLE_INIT_FINISHED()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_LOGIC_TO_BATTLE_INIT_FINISHED, new RakNet.BitStream()));}


public static void Send_ID_LOGIC_TO_BATTLE_START()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_LOGIC_TO_BATTLE_START, new RakNet.BitStream()));}


public static void Send_ID_BATTLE_TO_LOGIC_FINISHED()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_BATTLE_TO_LOGIC_FINISHED, new RakNet.BitStream()));}


public static void Send_ID_LOGIC_TO_BATTLE_EXIT_BATTLE()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_LOGIC_TO_BATTLE_EXIT_BATTLE, new RakNet.BitStream()));}


public static void Send_ID_BATTLE_TO_LOGIC_PLAYER_REVIVE()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_BATTLE_TO_LOGIC_PLAYER_REVIVE, new RakNet.BitStream()));}


public static void Send_ID_BATTLE_TO_LOGIC_LOAD_COMPLETE()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_BATTLE_TO_LOGIC_LOAD_COMPLETE, new RakNet.BitStream()));}

public delegate void  Delegate_ID_ERROR_RSP(int _errcode, uint errorCode,uint param);
public static  Delegate_ID_ERROR_RSP delegate_ID_ERROR_RSP = null;

public static void Recv_ID_ERROR_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
uint errorCode;
bs.ReadCompressed(out errorCode);
uint param;
bs.ReadCompressed(out param);
if(delegate_ID_ERROR_RSP!=null)
{
delegate_ID_ERROR_RSP(_errcode, errorCode,param);
}
}


public static void Send_ID_BATTLE_TO_LOGIC_PLAYER_STATE(uint userId,uint playerState)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(userId);
bs.WriteCompressed(playerState);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_BATTLE_TO_LOGIC_PLAYER_STATE, bs));
}


public static void Send_ID_BATTLE_TO_LOGIC_PPVE_FINISH(uint lobbyId,uint roomId,uint battleId,uint parameter)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(lobbyId);
bs.WriteCompressed(roomId);
bs.WriteCompressed(battleId);
bs.WriteCompressed(parameter);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_BATTLE_TO_LOGIC_PPVE_FINISH, bs));
}


public static void Send_ID_MULTI_COMMAND()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_MULTI_COMMAND, new RakNet.BitStream()));}


public static void Send_ID_PROTOBUF_MSG()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_PROTOBUF_MSG, new RakNet.BitStream()));}

public delegate void  Delegate_ID_GAMESERVER_RSP(int _errcode);
public static  Delegate_ID_GAMESERVER_RSP delegate_ID_GAMESERVER_RSP = null;

public static void Recv_ID_GAMESERVER_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
if(delegate_ID_GAMESERVER_RSP!=null)
{
delegate_ID_GAMESERVER_RSP(_errcode);
}
}


public static void Send_ID_RECONNECT_SET_IP()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_RECONNECT_SET_IP, new RakNet.BitStream()));}


public static void Send_ID_SUBMSG_BEGIN()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, new RakNet.BitStream()));}


public static void Send_SUB_ID_LOG_OUT()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_LOG_OUT,  new RakNet.BitStream()));
}

public delegate void  Delegate_SUB_ID_LOG_OUT_RSP(int _errcode);
public static  Delegate_SUB_ID_LOG_OUT_RSP delegate_SUB_ID_LOG_OUT_RSP = null;

public static void Recv_SUB_ID_LOG_OUT_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
if(delegate_SUB_ID_LOG_OUT_RSP!=null)
{
delegate_SUB_ID_LOG_OUT_RSP(_errcode);
}
}

public delegate void  Delegate_SUB_ID_PAIL_LIST_RSP(int _errcode, uint idx,uint tid,uint blood,short x,short y,short z);
public static  Delegate_SUB_ID_PAIL_LIST_RSP delegate_SUB_ID_PAIL_LIST_RSP = null;
public delegate void  Delegate_SUB_ID_PAIL_LIST_RSP_completed();
public static  Delegate_SUB_ID_PAIL_LIST_RSP_completed delegate_SUB_ID_PAIL_LIST_RSP_completed = null;

public static void Recv_SUB_ID_PAIL_LIST_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
List<IData>list = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
 {
uint idx;
bs.ReadCompressed(out idx);
uint tid;
bs.ReadCompressed(out tid);
uint blood;
bs.ReadCompressed(out blood);
short x;
bs.ReadCompressed(out x);
short y;
bs.ReadCompressed(out y);
short z;
bs.ReadCompressed(out z);

Pail data = new Pail(idx,tid,blood,x,y,z);
list.Add(data);
if(delegate_SUB_ID_PAIL_LIST_RSP!=null)
{
delegate_SUB_ID_PAIL_LIST_RSP(_errcode, idx,tid,blood,x,y,z);
}
}
DataHelper.Refresh(typeof(Pail), list);
if(delegate_SUB_ID_PAIL_LIST_RSP_completed!=null)
{
delegate_SUB_ID_PAIL_LIST_RSP_completed();}
}


public static void Send_SUB_ID_PAIL_HIT(uint bulletID,uint pailidx)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(bulletID);
bs.WriteCompressed(pailidx);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_PAIL_HIT, bs));
}

public delegate void  Delegate_SUB_ID_PAIL_HIT_RSP(int _errcode, uint idx,uint tid,uint blood,short x,short y,short z);
public static  Delegate_SUB_ID_PAIL_HIT_RSP delegate_SUB_ID_PAIL_HIT_RSP = null;
public delegate void  Delegate_SUB_ID_PAIL_HIT_RSP_completed();
public static  Delegate_SUB_ID_PAIL_HIT_RSP_completed delegate_SUB_ID_PAIL_HIT_RSP_completed = null;

public static void Recv_SUB_ID_PAIL_HIT_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
List<IData>list = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
 {
uint idx;
bs.ReadCompressed(out idx);
uint tid;
bs.ReadCompressed(out tid);
uint blood;
bs.ReadCompressed(out blood);
short x;
bs.ReadCompressed(out x);
short y;
bs.ReadCompressed(out y);
short z;
bs.ReadCompressed(out z);

Pail data = new Pail(idx,tid,blood,x,y,z);
list.Add(data);
if(delegate_SUB_ID_PAIL_HIT_RSP!=null)
{
delegate_SUB_ID_PAIL_HIT_RSP(_errcode, idx,tid,blood,x,y,z);
}
}
DataHelper.Refresh(typeof(Pail), list);
if(delegate_SUB_ID_PAIL_HIT_RSP_completed!=null)
{
delegate_SUB_ID_PAIL_HIT_RSP_completed();}
}


public static void Send_SUB_ID_TORNADO_EFFECT(uint idx)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(idx);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_TORNADO_EFFECT, bs));
}

public delegate void  Delegate_SUB_ID_TORNADO_EFFECT_RSP(int _errcode, short x,short y,short z);
public static  Delegate_SUB_ID_TORNADO_EFFECT_RSP delegate_SUB_ID_TORNADO_EFFECT_RSP = null;

public static void Recv_SUB_ID_TORNADO_EFFECT_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
short x;
bs.ReadCompressed(out x);
short y;
bs.ReadCompressed(out y);
short z;
bs.ReadCompressed(out z);
if(delegate_SUB_ID_TORNADO_EFFECT_RSP!=null)
{
delegate_SUB_ID_TORNADO_EFFECT_RSP(_errcode, x,y,z);
}
}


public static void Send_SUB_ID_SYNC_PLAYER_LOAD(uint playerid,byte state)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(playerid);
bs.WriteCompressed(state);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_SYNC_PLAYER_LOAD, bs));
}

public delegate void  Delegate_SUB_ID_SYNC_PLAYER_LOAD_RSP(int _errcode, uint playerid,byte state);
public static  Delegate_SUB_ID_SYNC_PLAYER_LOAD_RSP delegate_SUB_ID_SYNC_PLAYER_LOAD_RSP = null;
public delegate void  Delegate_SUB_ID_SYNC_PLAYER_LOAD_RSP_completed();
public static  Delegate_SUB_ID_SYNC_PLAYER_LOAD_RSP_completed delegate_SUB_ID_SYNC_PLAYER_LOAD_RSP_completed = null;

public static void Recv_SUB_ID_SYNC_PLAYER_LOAD_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
List<IData>list = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
 {
uint playerid;
bs.ReadCompressed(out playerid);
byte state;
bs.ReadCompressed(out state);

StateData data = new StateData(playerid,state);
list.Add(data);
if(delegate_SUB_ID_SYNC_PLAYER_LOAD_RSP!=null)
{
delegate_SUB_ID_SYNC_PLAYER_LOAD_RSP(_errcode, playerid,state);
}
}
DataHelper.Refresh(typeof(StateData), list);
if(delegate_SUB_ID_SYNC_PLAYER_LOAD_RSP_completed!=null)
{
delegate_SUB_ID_SYNC_PLAYER_LOAD_RSP_completed();}
}


public static void Send_SUB_ID_BATTLE_GET_BATTLEINFO(uint instanceID)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(instanceID);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_BATTLE_GET_BATTLEINFO, bs));
}


public static void Send_SUB_ID_BATTLESERVER_END()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_BATTLESERVER_END,  new RakNet.BitStream()));
}


public static void Send_SUB_ID_ITEM_USE(uint itemId,byte itemNum)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(itemId);
bs.WriteCompressed(itemNum);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_ITEM_USE, bs));
}

public delegate void  Delegate_SUB_ID_ITEM_USE_RSP(int _errcode);
public static  Delegate_SUB_ID_ITEM_USE_RSP delegate_SUB_ID_ITEM_USE_RSP = null;

public static void Recv_SUB_ID_ITEM_USE_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
if(delegate_SUB_ID_ITEM_USE_RSP!=null)
{
delegate_SUB_ID_ITEM_USE_RSP(_errcode);
}
}


public static void Send_SUB_ID_ITEM_SELL(uint itemId,byte itemNum)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(itemId);
bs.WriteCompressed(itemNum);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_ITEM_SELL, bs));
}

public delegate void  Delegate_SUB_ID_ITEM_SELL_RSP(int _errcode);
public static  Delegate_SUB_ID_ITEM_SELL_RSP delegate_SUB_ID_ITEM_SELL_RSP = null;

public static void Recv_SUB_ID_ITEM_SELL_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
if(delegate_SUB_ID_ITEM_SELL_RSP!=null)
{
delegate_SUB_ID_ITEM_SELL_RSP(_errcode);
}
}


public static void Send_SUB_ID_PILOT_LIST()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_PILOT_LIST,  new RakNet.BitStream()));
}

public delegate void  Delegate_SUB_ID_PILOT_LIST_RSP(int _errcode, byte type,PilotDetailInfo[]  list );
public static  Delegate_SUB_ID_PILOT_LIST_RSP delegate_SUB_ID_PILOT_LIST_RSP = null;

public static void Recv_SUB_ID_PILOT_LIST_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
byte type;
bs.ReadCompressed(out type);
List<PilotDetailInfo> list = new List<PilotDetailInfo>();
List<IData> lst = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
{ushort pilotId;
bs.ReadCompressed(out pilotId);
ushort pilotTempId;
bs.ReadCompressed(out pilotTempId);
byte pilotRank;
bs.ReadCompressed(out pilotRank);
byte pilotLvl;
bs.ReadCompressed(out pilotLvl);
uint pilotExp;
bs.ReadCompressed(out pilotExp);
byte major1Lvl;
bs.ReadCompressed(out major1Lvl);
byte major2Lvl;
bs.ReadCompressed(out major2Lvl);
byte major3Lvl;
bs.ReadCompressed(out major3Lvl);
byte major4Lvl;
bs.ReadCompressed(out major4Lvl);
byte major5Lvl;
bs.ReadCompressed(out major5Lvl);
uint activeSkill;
bs.ReadCompressed(out activeSkill);
uint passiveSkill;
bs.ReadCompressed(out passiveSkill);
uint perfessionSkill;
bs.ReadCompressed(out perfessionSkill);
uint activeSkillexp;
bs.ReadCompressed(out activeSkillexp);
uint passiveSkillexp;
bs.ReadCompressed(out passiveSkillexp);
uint perfessionSkillexp;
bs.ReadCompressed(out perfessionSkillexp);
ushort favorPoint;
bs.ReadCompressed(out favorPoint);
PilotDetailInfo val = new PilotDetailInfo(pilotId,pilotTempId,pilotRank,pilotLvl,pilotExp,major1Lvl,major2Lvl,major3Lvl,major4Lvl,major5Lvl,activeSkill,passiveSkill,perfessionSkill,activeSkillexp,passiveSkillexp,perfessionSkillexp,favorPoint);
list.Add(val); 
lst.Add(val); 
}
 DataHelper.Refresh(typeof(PilotDetailInfo), lst);
if(delegate_SUB_ID_PILOT_LIST_RSP!=null)
{
delegate_SUB_ID_PILOT_LIST_RSP(_errcode, type, list.ToArray());
}
}


public static void Send_SUB_ID_PILOT_DETAIL_INFO(ushort pilotId)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(pilotId);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_PILOT_DETAIL_INFO, bs));
}

public delegate void  Delegate_SUB_ID_PILOT_DETAIL_INFO_RSP(int _errcode, byte type,PilotDetailInfo[]  list );
public static  Delegate_SUB_ID_PILOT_DETAIL_INFO_RSP delegate_SUB_ID_PILOT_DETAIL_INFO_RSP = null;

public static void Recv_SUB_ID_PILOT_DETAIL_INFO_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
byte type;
bs.ReadCompressed(out type);
List<PilotDetailInfo> list = new List<PilotDetailInfo>();
List<IData> lst = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
{ushort pilotId;
bs.ReadCompressed(out pilotId);
ushort pilotTempId;
bs.ReadCompressed(out pilotTempId);
byte pilotRank;
bs.ReadCompressed(out pilotRank);
byte pilotLvl;
bs.ReadCompressed(out pilotLvl);
uint pilotExp;
bs.ReadCompressed(out pilotExp);
byte major1Lvl;
bs.ReadCompressed(out major1Lvl);
byte major2Lvl;
bs.ReadCompressed(out major2Lvl);
byte major3Lvl;
bs.ReadCompressed(out major3Lvl);
byte major4Lvl;
bs.ReadCompressed(out major4Lvl);
byte major5Lvl;
bs.ReadCompressed(out major5Lvl);
uint activeSkill;
bs.ReadCompressed(out activeSkill);
uint passiveSkill;
bs.ReadCompressed(out passiveSkill);
uint perfessionSkill;
bs.ReadCompressed(out perfessionSkill);
uint activeSkillexp;
bs.ReadCompressed(out activeSkillexp);
uint passiveSkillexp;
bs.ReadCompressed(out passiveSkillexp);
uint perfessionSkillexp;
bs.ReadCompressed(out perfessionSkillexp);
ushort favorPoint;
bs.ReadCompressed(out favorPoint);
PilotDetailInfo val = new PilotDetailInfo(pilotId,pilotTempId,pilotRank,pilotLvl,pilotExp,major1Lvl,major2Lvl,major3Lvl,major4Lvl,major5Lvl,activeSkill,passiveSkill,perfessionSkill,activeSkillexp,passiveSkillexp,perfessionSkillexp,favorPoint);
list.Add(val); 
lst.Add(val); 
}
 DataHelper.Refresh(typeof(PilotDetailInfo), lst);
if(delegate_SUB_ID_PILOT_DETAIL_INFO_RSP!=null)
{
delegate_SUB_ID_PILOT_DETAIL_INFO_RSP(_errcode, type, list.ToArray());
}
}


public static void Send_SUB_ID_PILOT_ADD_EXP(ushort pilotId,PilotExpMaterial[] itemIdList)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(pilotId);
foreach(PilotExpMaterial val in itemIdList)
{
bs.WriteCompressed(val.type);
bs.WriteCompressed(val.id);
bs.WriteCompressed(val.num);
}
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_PILOT_ADD_EXP, bs));
}

public delegate void  Delegate_SUB_ID_PILOT_ADD_EXP_RSP(int _errcode, ushort pilotId,uint curExp,byte curLvl);
public static  Delegate_SUB_ID_PILOT_ADD_EXP_RSP delegate_SUB_ID_PILOT_ADD_EXP_RSP = null;

public static void Recv_SUB_ID_PILOT_ADD_EXP_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
ushort pilotId;
bs.ReadCompressed(out pilotId);
uint curExp;
bs.ReadCompressed(out curExp);
byte curLvl;
bs.ReadCompressed(out curLvl);
if(delegate_SUB_ID_PILOT_ADD_EXP_RSP!=null)
{
delegate_SUB_ID_PILOT_ADD_EXP_RSP(_errcode, pilotId,curExp,curLvl);
}
}


public static void Send_SUB_ID_PILOT_RANK_UP(ushort pilotId)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(pilotId);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_PILOT_RANK_UP, bs));
}

public delegate void  Delegate_SUB_ID_PILOT_RANK_UP_RSP(int _errcode, ushort pilotId,byte curRank);
public static  Delegate_SUB_ID_PILOT_RANK_UP_RSP delegate_SUB_ID_PILOT_RANK_UP_RSP = null;

public static void Recv_SUB_ID_PILOT_RANK_UP_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
ushort pilotId;
bs.ReadCompressed(out pilotId);
byte curRank;
bs.ReadCompressed(out curRank);
if(delegate_SUB_ID_PILOT_RANK_UP_RSP!=null)
{
delegate_SUB_ID_PILOT_RANK_UP_RSP(_errcode, pilotId,curRank);
}
}


public static void Send_SUB_ID_PILOT_MAJOR_LVLUP(ushort pilotId,byte majorIdx)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(pilotId);
bs.WriteCompressed(majorIdx);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_PILOT_MAJOR_LVLUP, bs));
}

public delegate void  Delegate_SUB_ID_PILOT_MAJOR_LVLUP_RSP(int _errcode, ushort pilotId,byte majorIdx,byte majorLvl);
public static  Delegate_SUB_ID_PILOT_MAJOR_LVLUP_RSP delegate_SUB_ID_PILOT_MAJOR_LVLUP_RSP = null;

public static void Recv_SUB_ID_PILOT_MAJOR_LVLUP_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
ushort pilotId;
bs.ReadCompressed(out pilotId);
byte majorIdx;
bs.ReadCompressed(out majorIdx);
byte majorLvl;
bs.ReadCompressed(out majorLvl);
if(delegate_SUB_ID_PILOT_MAJOR_LVLUP_RSP!=null)
{
delegate_SUB_ID_PILOT_MAJOR_LVLUP_RSP(_errcode, pilotId,majorIdx,majorLvl);
}
}


public static void Send_SUB_ID_EXCHANGE(ushort recipeId)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(recipeId);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_EXCHANGE, bs));
}

public delegate void  Delegate_SUB_ID_EXCHANGE_RSP(int _errcode);
public static  Delegate_SUB_ID_EXCHANGE_RSP delegate_SUB_ID_EXCHANGE_RSP = null;

public static void Recv_SUB_ID_EXCHANGE_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
if(delegate_SUB_ID_EXCHANGE_RSP!=null)
{
delegate_SUB_ID_EXCHANGE_RSP(_errcode);
}
}


public static void Send_SUB_ID_TANK_SETTING(byte curSelectTankSetIdx,TankSetting[] tankSettingList)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(curSelectTankSetIdx);
foreach(TankSetting val in tankSettingList)
{
bs.WriteCompressed(val.settingIdx);
bs.WriteCompressed(val.tankId);
bs.WriteCompressed(val.pilotAId);
bs.WriteCompressed(val.pilotBId);
bs.WriteCompressed(val.pilotCId);
bs.WriteCompressed(val.pilotDId);
bs.WriteCompressed(val.pilotEId);
bs.WriteCompressed(val.professorId);
}
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_TANK_SETTING, bs));
}

public delegate void  Delegate_SUB_ID_TANK_SETTING_RSP(int _errcode, byte curSelectTankSetIdx,TankSetting[]  list );
public static  Delegate_SUB_ID_TANK_SETTING_RSP delegate_SUB_ID_TANK_SETTING_RSP = null;

public static void Recv_SUB_ID_TANK_SETTING_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
byte curSelectTankSetIdx;
bs.ReadCompressed(out curSelectTankSetIdx);
List<TankSetting> list = new List<TankSetting>();
List<IData> lst = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
{byte settingIdx;
bs.ReadCompressed(out settingIdx);
ushort tankId;
bs.ReadCompressed(out tankId);
ushort pilotAId;
bs.ReadCompressed(out pilotAId);
ushort pilotBId;
bs.ReadCompressed(out pilotBId);
ushort pilotCId;
bs.ReadCompressed(out pilotCId);
ushort pilotDId;
bs.ReadCompressed(out pilotDId);
ushort pilotEId;
bs.ReadCompressed(out pilotEId);
uint professorId;
bs.ReadCompressed(out professorId);
TankSetting val = new TankSetting(settingIdx,tankId,pilotAId,pilotBId,pilotCId,pilotDId,pilotEId,professorId);
list.Add(val); 
lst.Add(val); 
}
 DataHelper.Refresh(typeof(TankSetting), lst);
if(delegate_SUB_ID_TANK_SETTING_RSP!=null)
{
delegate_SUB_ID_TANK_SETTING_RSP(_errcode, curSelectTankSetIdx, list.ToArray());
}
}


public static void Send_SUB_ID_TANK_SETTING_UNLOCK_SOCKET()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_TANK_SETTING_UNLOCK_SOCKET,  new RakNet.BitStream()));
}

public delegate void  Delegate_SUB_ID_TANK_SETTING_UNLOCK_SOCKET_RSP(int _errcode);
public static  Delegate_SUB_ID_TANK_SETTING_UNLOCK_SOCKET_RSP delegate_SUB_ID_TANK_SETTING_UNLOCK_SOCKET_RSP = null;

public static void Recv_SUB_ID_TANK_SETTING_UNLOCK_SOCKET_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
if(delegate_SUB_ID_TANK_SETTING_UNLOCK_SOCKET_RSP!=null)
{
delegate_SUB_ID_TANK_SETTING_UNLOCK_SOCKET_RSP(_errcode);
}
}

public delegate void  Delegate_SUB_ID_NOTIFY_MESSAGE_RSP(int _errcode, uint id,NotifyMsg[]  list );
public static  Delegate_SUB_ID_NOTIFY_MESSAGE_RSP delegate_SUB_ID_NOTIFY_MESSAGE_RSP = null;

public static void Recv_SUB_ID_NOTIFY_MESSAGE_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
uint id;
bs.ReadCompressed(out id);
List<NotifyMsg> list = new List<NotifyMsg>();
List<IData> lst = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
{uint paramInt;
bs.ReadCompressed(out paramInt);
RakNet.RakString paramStr;
paramStr = new RakNet.RakString();
bs.ReadCompressed(paramStr);
NotifyMsg val = new NotifyMsg(paramInt,paramStr);
list.Add(val); 
lst.Add(val); 
}
 DataHelper.Refresh(typeof(NotifyMsg), lst);
if(delegate_SUB_ID_NOTIFY_MESSAGE_RSP!=null)
{
delegate_SUB_ID_NOTIFY_MESSAGE_RSP(_errcode, id, list.ToArray());
}
}


public static void Send_SUB_ID_CHAT(byte channel,RakNet.RakString chatContent,uint value,uint value2)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(channel);
bs.WriteCompressed(chatContent);
bs.WriteCompressed(value);
bs.WriteCompressed(value2);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_CHAT, bs));
}

public delegate void  Delegate_SUB_ID_CHAT_RSP(int _errcode, byte channel,RakNet.RakString chatContent,uint value,uint value2,uint value3,uint value4,RakNet.RakString name);
public static  Delegate_SUB_ID_CHAT_RSP delegate_SUB_ID_CHAT_RSP = null;

public static void Recv_SUB_ID_CHAT_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
byte channel;
bs.ReadCompressed(out channel);
RakNet.RakString chatContent;
chatContent = new RakNet.RakString();
bs.ReadCompressed(chatContent);
uint value;
bs.ReadCompressed(out value);
uint value2;
bs.ReadCompressed(out value2);
uint value3;
bs.ReadCompressed(out value3);
uint value4;
bs.ReadCompressed(out value4);
RakNet.RakString name;
name = new RakNet.RakString();
bs.ReadCompressed(name);
if(delegate_SUB_ID_CHAT_RSP!=null)
{
delegate_SUB_ID_CHAT_RSP(_errcode, channel,chatContent,value,value2,value3,value4,name);
}
}


public static void Send_SUB_ID_LOBBY_EXIT()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_LOBBY_EXIT,  new RakNet.BitStream()));
}


public static void Send_SUB_ID_EMOTION(uint emotionID,RakNet.RakString pilotID)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(emotionID);
bs.WriteCompressed(pilotID);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_EMOTION, bs));
}

public delegate void  Delegate_SUB_ID_EMOTION_RSP(int _errcode, uint playerID,uint emotionID,RakNet.RakString pilotID);
public static  Delegate_SUB_ID_EMOTION_RSP delegate_SUB_ID_EMOTION_RSP = null;

public static void Recv_SUB_ID_EMOTION_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
uint playerID;
bs.ReadCompressed(out playerID);
uint emotionID;
bs.ReadCompressed(out emotionID);
RakNet.RakString pilotID;
pilotID = new RakNet.RakString();
bs.ReadCompressed(pilotID);
if(delegate_SUB_ID_EMOTION_RSP!=null)
{
delegate_SUB_ID_EMOTION_RSP(_errcode, playerID,emotionID,pilotID);
}
}


public static void Send_SUB_ID_TASK_LIST(byte taskType)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(taskType);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_TASK_LIST, bs));
}

public delegate void  Delegate_SUB_ID_TASK_LIST_RSP(int _errcode, byte taskType,TaskInfo[]  list );
public static  Delegate_SUB_ID_TASK_LIST_RSP delegate_SUB_ID_TASK_LIST_RSP = null;

public static void Recv_SUB_ID_TASK_LIST_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
byte taskType;
bs.ReadCompressed(out taskType);
List<TaskInfo> list = new List<TaskInfo>();
List<IData> lst = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
{uint ID;
bs.ReadCompressed(out ID);
uint counter;
bs.ReadCompressed(out counter);
uint time;
bs.ReadCompressed(out time);
bool isFinished;
bs.ReadCompressed(out isFinished);
bool isGotten;
bs.ReadCompressed(out isGotten);
TaskInfo val = new TaskInfo(ID,counter,time,isFinished,isGotten);
list.Add(val); 
lst.Add(val); 
}
 DataHelper.Refresh(typeof(TaskInfo), lst);
if(delegate_SUB_ID_TASK_LIST_RSP!=null)
{
delegate_SUB_ID_TASK_LIST_RSP(_errcode, taskType, list.ToArray());
}
}


public static void Send_SUB_ID_TASK_GET(byte taskType,uint ID)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(taskType);
bs.WriteCompressed(ID);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_TASK_GET, bs));
}

public delegate void  Delegate_SUB_ID_TASK_GET_RSP(int _errcode, byte taskType,uint ID);
public static  Delegate_SUB_ID_TASK_GET_RSP delegate_SUB_ID_TASK_GET_RSP = null;

public static void Recv_SUB_ID_TASK_GET_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
byte taskType;
bs.ReadCompressed(out taskType);
uint ID;
bs.ReadCompressed(out ID);
if(delegate_SUB_ID_TASK_GET_RSP!=null)
{
delegate_SUB_ID_TASK_GET_RSP(_errcode, taskType,ID);
}
}

public delegate void  Delegate_SUB_ID_TASK_FINISHED_RSP(int _errcode, byte taskType,TaskInfo[]  list );
public static  Delegate_SUB_ID_TASK_FINISHED_RSP delegate_SUB_ID_TASK_FINISHED_RSP = null;

public static void Recv_SUB_ID_TASK_FINISHED_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
byte taskType;
bs.ReadCompressed(out taskType);
List<TaskInfo> list = new List<TaskInfo>();
List<IData> lst = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
{uint ID;
bs.ReadCompressed(out ID);
uint counter;
bs.ReadCompressed(out counter);
uint time;
bs.ReadCompressed(out time);
bool isFinished;
bs.ReadCompressed(out isFinished);
bool isGotten;
bs.ReadCompressed(out isGotten);
TaskInfo val = new TaskInfo(ID,counter,time,isFinished,isGotten);
list.Add(val); 
lst.Add(val); 
}
 DataHelper.Refresh(typeof(TaskInfo), lst);
if(delegate_SUB_ID_TASK_FINISHED_RSP!=null)
{
delegate_SUB_ID_TASK_FINISHED_RSP(_errcode, taskType, list.ToArray());
}
}


public static void Send_SUB_ID_ACTIVE_REWARD(uint activeValue)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(activeValue);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_ACTIVE_REWARD, bs));
}

public delegate void  Delegate_SUB_ID_ACTIVE_REWARD_RSP(int _errcode, uint activeValue);
public static  Delegate_SUB_ID_ACTIVE_REWARD_RSP delegate_SUB_ID_ACTIVE_REWARD_RSP = null;

public static void Recv_SUB_ID_ACTIVE_REWARD_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
uint activeValue;
bs.ReadCompressed(out activeValue);
if(delegate_SUB_ID_ACTIVE_REWARD_RSP!=null)
{
delegate_SUB_ID_ACTIVE_REWARD_RSP(_errcode, activeValue);
}
}

public delegate void  Delegate_SUB_ID_ACTIVE_GOTTEN_RSP(int _errcode, uint value);
public static  Delegate_SUB_ID_ACTIVE_GOTTEN_RSP delegate_SUB_ID_ACTIVE_GOTTEN_RSP = null;
public delegate void  Delegate_SUB_ID_ACTIVE_GOTTEN_RSP_completed();
public static  Delegate_SUB_ID_ACTIVE_GOTTEN_RSP_completed delegate_SUB_ID_ACTIVE_GOTTEN_RSP_completed = null;

public static void Recv_SUB_ID_ACTIVE_GOTTEN_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
List<IData>list = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
 {
uint value;
bs.ReadCompressed(out value);

UInteger data = new UInteger(value);
list.Add(data);
if(delegate_SUB_ID_ACTIVE_GOTTEN_RSP!=null)
{
delegate_SUB_ID_ACTIVE_GOTTEN_RSP(_errcode, value);
}
}
DataHelper.Refresh(typeof(UInteger), list);
if(delegate_SUB_ID_ACTIVE_GOTTEN_RSP_completed!=null)
{
delegate_SUB_ID_ACTIVE_GOTTEN_RSP_completed();}
}

public delegate void  Delegate_SUB_ID_PLAYER_PPVE_TASK_COMPLETE_RSP(int _errcode, uint group,byte complete);
public static  Delegate_SUB_ID_PLAYER_PPVE_TASK_COMPLETE_RSP delegate_SUB_ID_PLAYER_PPVE_TASK_COMPLETE_RSP = null;
public delegate void  Delegate_SUB_ID_PLAYER_PPVE_TASK_COMPLETE_RSP_completed();
public static  Delegate_SUB_ID_PLAYER_PPVE_TASK_COMPLETE_RSP_completed delegate_SUB_ID_PLAYER_PPVE_TASK_COMPLETE_RSP_completed = null;

public static void Recv_SUB_ID_PLAYER_PPVE_TASK_COMPLETE_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
List<IData>list = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
 {
uint group;
bs.ReadCompressed(out group);
byte complete;
bs.ReadCompressed(out complete);

PlayerPPVETaskInfo data = new PlayerPPVETaskInfo(group,complete);
list.Add(data);
if(delegate_SUB_ID_PLAYER_PPVE_TASK_COMPLETE_RSP!=null)
{
delegate_SUB_ID_PLAYER_PPVE_TASK_COMPLETE_RSP(_errcode, group,complete);
}
}
DataHelper.Refresh(typeof(PlayerPPVETaskInfo), list);
if(delegate_SUB_ID_PLAYER_PPVE_TASK_COMPLETE_RSP_completed!=null)
{
delegate_SUB_ID_PLAYER_PPVE_TASK_COMPLETE_RSP_completed();}
}

public delegate void  Delegate_SUB_ID_PLAYER_PPVE_TASK_LIST_RSP(int _errcode, uint group,byte complete);
public static  Delegate_SUB_ID_PLAYER_PPVE_TASK_LIST_RSP delegate_SUB_ID_PLAYER_PPVE_TASK_LIST_RSP = null;
public delegate void  Delegate_SUB_ID_PLAYER_PPVE_TASK_LIST_RSP_completed();
public static  Delegate_SUB_ID_PLAYER_PPVE_TASK_LIST_RSP_completed delegate_SUB_ID_PLAYER_PPVE_TASK_LIST_RSP_completed = null;

public static void Recv_SUB_ID_PLAYER_PPVE_TASK_LIST_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
List<IData>list = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
 {
uint group;
bs.ReadCompressed(out group);
byte complete;
bs.ReadCompressed(out complete);

PlayerPPVETaskInfo data = new PlayerPPVETaskInfo(group,complete);
list.Add(data);
if(delegate_SUB_ID_PLAYER_PPVE_TASK_LIST_RSP!=null)
{
delegate_SUB_ID_PLAYER_PPVE_TASK_LIST_RSP(_errcode, group,complete);
}
}
DataHelper.Refresh(typeof(PlayerPPVETaskInfo), list);
if(delegate_SUB_ID_PLAYER_PPVE_TASK_LIST_RSP_completed!=null)
{
delegate_SUB_ID_PLAYER_PPVE_TASK_LIST_RSP_completed();}
}


public static void Send_SUB_ID_PLAYER_PPVE_MATCH(uint taskID)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(taskID);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_PLAYER_PPVE_MATCH, bs));
}

public delegate void  Delegate_SUB_ID_TEST_BOSS_SKILL_RSP(int _errcode);
public static  Delegate_SUB_ID_TEST_BOSS_SKILL_RSP delegate_SUB_ID_TEST_BOSS_SKILL_RSP = null;

public static void Recv_SUB_ID_TEST_BOSS_SKILL_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
if(delegate_SUB_ID_TEST_BOSS_SKILL_RSP!=null)
{
delegate_SUB_ID_TEST_BOSS_SKILL_RSP(_errcode);
}
}


public static void Send_SUB_ID_PROFESSOR_LIST()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_PROFESSOR_LIST,  new RakNet.BitStream()));
}

public delegate void  Delegate_SUB_ID_PROFESSOR_LIST_RSP(int _errcode, byte type,ProfessorDetailInfo[]  list );
public static  Delegate_SUB_ID_PROFESSOR_LIST_RSP delegate_SUB_ID_PROFESSOR_LIST_RSP = null;

public static void Recv_SUB_ID_PROFESSOR_LIST_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
byte type;
bs.ReadCompressed(out type);
List<ProfessorDetailInfo> list = new List<ProfessorDetailInfo>();
List<IData> lst = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
{uint id;
bs.ReadCompressed(out id);
uint templateId;
bs.ReadCompressed(out templateId);
byte level;
bs.ReadCompressed(out level);
ProfessorDetailInfo val = new ProfessorDetailInfo(id,templateId,level);
list.Add(val); 
lst.Add(val); 
}
 DataHelper.Refresh(typeof(ProfessorDetailInfo), lst);
if(delegate_SUB_ID_PROFESSOR_LIST_RSP!=null)
{
delegate_SUB_ID_PROFESSOR_LIST_RSP(_errcode, type, list.ToArray());
}
}


public static void Send_SUB_ID_FRIEND_GET_FRIENDS_LIST()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_FRIEND_GET_FRIENDS_LIST,  new RakNet.BitStream()));
}

public delegate void  Delegate_SUB_ID_FRIEND_GET_FRIENDS_LIST_RSP(int _errcode, uint fid,ushort flevel,uint lastofflinetime,byte lineStatus,RakNet.RakString fname,uint icon,RakNet.RakString corpsname,RakNet.RakString lvname);
public static  Delegate_SUB_ID_FRIEND_GET_FRIENDS_LIST_RSP delegate_SUB_ID_FRIEND_GET_FRIENDS_LIST_RSP = null;
public delegate void  Delegate_SUB_ID_FRIEND_GET_FRIENDS_LIST_RSP_completed();
public static  Delegate_SUB_ID_FRIEND_GET_FRIENDS_LIST_RSP_completed delegate_SUB_ID_FRIEND_GET_FRIENDS_LIST_RSP_completed = null;

public static void Recv_SUB_ID_FRIEND_GET_FRIENDS_LIST_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
List<IData>list = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
 {
uint fid;
bs.ReadCompressed(out fid);
ushort flevel;
bs.ReadCompressed(out flevel);
uint lastofflinetime;
bs.ReadCompressed(out lastofflinetime);
byte lineStatus;
bs.ReadCompressed(out lineStatus);
RakNet.RakString fname;
fname = new RakNet.RakString();
bs.ReadCompressed(fname);
uint icon;
bs.ReadCompressed(out icon);
RakNet.RakString corpsname;
corpsname = new RakNet.RakString();
bs.ReadCompressed(corpsname);
RakNet.RakString lvname;
lvname = new RakNet.RakString();
bs.ReadCompressed(lvname);

FriendBasicInfo data = new FriendBasicInfo(fid,flevel,lastofflinetime,lineStatus,fname,icon,corpsname,lvname);
list.Add(data);
if(delegate_SUB_ID_FRIEND_GET_FRIENDS_LIST_RSP!=null)
{
delegate_SUB_ID_FRIEND_GET_FRIENDS_LIST_RSP(_errcode, fid,flevel,lastofflinetime,lineStatus,fname,icon,corpsname,lvname);
}
}
DataHelper.Refresh(typeof(FriendBasicInfo), list);
if(delegate_SUB_ID_FRIEND_GET_FRIENDS_LIST_RSP_completed!=null)
{
delegate_SUB_ID_FRIEND_GET_FRIENDS_LIST_RSP_completed();}
}


public static void Send_SUB_ID_FRIEND_GET_FRIENDSREQ_LIST()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_FRIEND_GET_FRIENDSREQ_LIST,  new RakNet.BitStream()));
}

public delegate void  Delegate_SUB_ID_FRIEND_GET_FRIENDSREQ_LIST_RSP(int _errcode, uint fid,ushort flevel,byte type,byte status,RakNet.RakString fname,uint icon);
public static  Delegate_SUB_ID_FRIEND_GET_FRIENDSREQ_LIST_RSP delegate_SUB_ID_FRIEND_GET_FRIENDSREQ_LIST_RSP = null;
public delegate void  Delegate_SUB_ID_FRIEND_GET_FRIENDSREQ_LIST_RSP_completed();
public static  Delegate_SUB_ID_FRIEND_GET_FRIENDSREQ_LIST_RSP_completed delegate_SUB_ID_FRIEND_GET_FRIENDSREQ_LIST_RSP_completed = null;

public static void Recv_SUB_ID_FRIEND_GET_FRIENDSREQ_LIST_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
List<IData>list = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
 {
uint fid;
bs.ReadCompressed(out fid);
ushort flevel;
bs.ReadCompressed(out flevel);
byte type;
bs.ReadCompressed(out type);
byte status;
bs.ReadCompressed(out status);
RakNet.RakString fname;
fname = new RakNet.RakString();
bs.ReadCompressed(fname);
uint icon;
bs.ReadCompressed(out icon);

FriendReqBasicInfo data = new FriendReqBasicInfo(fid,flevel,type,status,fname,icon);
list.Add(data);
if(delegate_SUB_ID_FRIEND_GET_FRIENDSREQ_LIST_RSP!=null)
{
delegate_SUB_ID_FRIEND_GET_FRIENDSREQ_LIST_RSP(_errcode, fid,flevel,type,status,fname,icon);
}
}
DataHelper.Refresh(typeof(FriendReqBasicInfo), list);
if(delegate_SUB_ID_FRIEND_GET_FRIENDSREQ_LIST_RSP_completed!=null)
{
delegate_SUB_ID_FRIEND_GET_FRIENDSREQ_LIST_RSP_completed();}
}


public static void Send_SUB_ID_FRIEND_ADD(uint userID,RakNet.RakString name)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(userID);
bs.WriteCompressed(name);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_FRIEND_ADD, bs));
}

public delegate void  Delegate_SUB_ID_FRIEND_ADD_RSP(int _errcode, uint userID,RakNet.RakString name);
public static  Delegate_SUB_ID_FRIEND_ADD_RSP delegate_SUB_ID_FRIEND_ADD_RSP = null;

public static void Recv_SUB_ID_FRIEND_ADD_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
uint userID;
bs.ReadCompressed(out userID);
RakNet.RakString name;
name = new RakNet.RakString();
bs.ReadCompressed(name);
if(delegate_SUB_ID_FRIEND_ADD_RSP!=null)
{
delegate_SUB_ID_FRIEND_ADD_RSP(_errcode, userID,name);
}
}


public static void Send_SUB_ID_FRIEND_REQUEST(uint userID,bool isAccept)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(userID);
bs.WriteCompressed(isAccept);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_FRIEND_REQUEST, bs));
}

public delegate void  Delegate_SUB_ID_FRIEND_REQUEST_RSP(int _errcode, uint userID,bool isAccept);
public static  Delegate_SUB_ID_FRIEND_REQUEST_RSP delegate_SUB_ID_FRIEND_REQUEST_RSP = null;

public static void Recv_SUB_ID_FRIEND_REQUEST_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
uint userID;
bs.ReadCompressed(out userID);
bool isAccept;
bs.ReadCompressed(out isAccept);
if(delegate_SUB_ID_FRIEND_REQUEST_RSP!=null)
{
delegate_SUB_ID_FRIEND_REQUEST_RSP(_errcode, userID,isAccept);
}
}


public static void Send_SUB_ID_FRIEND_DELETE(uint userID)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(userID);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_FRIEND_DELETE, bs));
}

public delegate void  Delegate_SUB_ID_FRIEND_DELETE_RSP(int _errcode, uint userID);
public static  Delegate_SUB_ID_FRIEND_DELETE_RSP delegate_SUB_ID_FRIEND_DELETE_RSP = null;

public static void Recv_SUB_ID_FRIEND_DELETE_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
uint userID;
bs.ReadCompressed(out userID);
if(delegate_SUB_ID_FRIEND_DELETE_RSP!=null)
{
delegate_SUB_ID_FRIEND_DELETE_RSP(_errcode, userID);
}
}

public delegate void  Delegate_SUB_ID_FRIEND_MODIFY_LINESTATUS_RSP(int _errcode, uint userID,byte lineStatus);
public static  Delegate_SUB_ID_FRIEND_MODIFY_LINESTATUS_RSP delegate_SUB_ID_FRIEND_MODIFY_LINESTATUS_RSP = null;

public static void Recv_SUB_ID_FRIEND_MODIFY_LINESTATUS_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
uint userID;
bs.ReadCompressed(out userID);
byte lineStatus;
bs.ReadCompressed(out lineStatus);
if(delegate_SUB_ID_FRIEND_MODIFY_LINESTATUS_RSP!=null)
{
delegate_SUB_ID_FRIEND_MODIFY_LINESTATUS_RSP(_errcode, userID,lineStatus);
}
}

public delegate void  Delegate_SUB_ID_FRIEND_MODIFY_LEVEL_RSP(int _errcode, uint userID,ushort flevel);
public static  Delegate_SUB_ID_FRIEND_MODIFY_LEVEL_RSP delegate_SUB_ID_FRIEND_MODIFY_LEVEL_RSP = null;

public static void Recv_SUB_ID_FRIEND_MODIFY_LEVEL_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
uint userID;
bs.ReadCompressed(out userID);
ushort flevel;
bs.ReadCompressed(out flevel);
if(delegate_SUB_ID_FRIEND_MODIFY_LEVEL_RSP!=null)
{
delegate_SUB_ID_FRIEND_MODIFY_LEVEL_RSP(_errcode, userID,flevel);
}
}

public delegate void  Delegate_SUB_ID_FRIEND_MODIFY_ICON_RSP(int _errcode, uint userID,ushort ficon);
public static  Delegate_SUB_ID_FRIEND_MODIFY_ICON_RSP delegate_SUB_ID_FRIEND_MODIFY_ICON_RSP = null;

public static void Recv_SUB_ID_FRIEND_MODIFY_ICON_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
uint userID;
bs.ReadCompressed(out userID);
ushort ficon;
bs.ReadCompressed(out ficon);
if(delegate_SUB_ID_FRIEND_MODIFY_ICON_RSP!=null)
{
delegate_SUB_ID_FRIEND_MODIFY_ICON_RSP(_errcode, userID,ficon);
}
}


public static void Send_SUB_ID_FRIEND_BATCH_ADD()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_FRIEND_BATCH_ADD,  new RakNet.BitStream()));
}

public delegate void  Delegate_SUB_ID_FRIEND_BATCH_ADD_RSP(int _errcode, uint fid,ushort flevel,uint lastofflinetime,byte lineStatus,RakNet.RakString fname,uint icon,RakNet.RakString corpsname,RakNet.RakString lvname);
public static  Delegate_SUB_ID_FRIEND_BATCH_ADD_RSP delegate_SUB_ID_FRIEND_BATCH_ADD_RSP = null;
public delegate void  Delegate_SUB_ID_FRIEND_BATCH_ADD_RSP_completed();
public static  Delegate_SUB_ID_FRIEND_BATCH_ADD_RSP_completed delegate_SUB_ID_FRIEND_BATCH_ADD_RSP_completed = null;

public static void Recv_SUB_ID_FRIEND_BATCH_ADD_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
List<IData>list = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
 {
uint fid;
bs.ReadCompressed(out fid);
ushort flevel;
bs.ReadCompressed(out flevel);
uint lastofflinetime;
bs.ReadCompressed(out lastofflinetime);
byte lineStatus;
bs.ReadCompressed(out lineStatus);
RakNet.RakString fname;
fname = new RakNet.RakString();
bs.ReadCompressed(fname);
uint icon;
bs.ReadCompressed(out icon);
RakNet.RakString corpsname;
corpsname = new RakNet.RakString();
bs.ReadCompressed(corpsname);
RakNet.RakString lvname;
lvname = new RakNet.RakString();
bs.ReadCompressed(lvname);

FriendBasicInfo data = new FriendBasicInfo(fid,flevel,lastofflinetime,lineStatus,fname,icon,corpsname,lvname);
list.Add(data);
if(delegate_SUB_ID_FRIEND_BATCH_ADD_RSP!=null)
{
delegate_SUB_ID_FRIEND_BATCH_ADD_RSP(_errcode, fid,flevel,lastofflinetime,lineStatus,fname,icon,corpsname,lvname);
}
}
DataHelper.Refresh(typeof(FriendBasicInfo), list);
if(delegate_SUB_ID_FRIEND_BATCH_ADD_RSP_completed!=null)
{
delegate_SUB_ID_FRIEND_BATCH_ADD_RSP_completed();}
}


public static void Send_SUB_ID_WAREHOUSE_TANK_STAR_UP(byte type,ushort tankId)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(type);
bs.WriteCompressed(tankId);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_WAREHOUSE_TANK_STAR_UP, bs));
}

public delegate void  Delegate_SUB_ID_WAREHOUSE_TANK_STAR_UP_RSP(int _errcode, ushort tankId,byte curLvl);
public static  Delegate_SUB_ID_WAREHOUSE_TANK_STAR_UP_RSP delegate_SUB_ID_WAREHOUSE_TANK_STAR_UP_RSP = null;

public static void Recv_SUB_ID_WAREHOUSE_TANK_STAR_UP_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
ushort tankId;
bs.ReadCompressed(out tankId);
byte curLvl;
bs.ReadCompressed(out curLvl);
if(delegate_SUB_ID_WAREHOUSE_TANK_STAR_UP_RSP!=null)
{
delegate_SUB_ID_WAREHOUSE_TANK_STAR_UP_RSP(_errcode, tankId,curLvl);
}
}


public static void Send_SUB_ID_ACTIVE_PILOT(ushort pilotId,byte rank)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(pilotId);
bs.WriteCompressed(rank);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_ACTIVE_PILOT, bs));
}


public static void Send_SUB_ID_WAREHOUSE_TANK_SKILL_RESET(ushort tankId)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(tankId);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_WAREHOUSE_TANK_SKILL_RESET, bs));
}

public delegate void  Delegate_SUB_ID_WAREHOUSE_TANK_SKILL_RESET_RSP(int _errcode, ushort tankId,uint skillId,uint remainTimes);
public static  Delegate_SUB_ID_WAREHOUSE_TANK_SKILL_RESET_RSP delegate_SUB_ID_WAREHOUSE_TANK_SKILL_RESET_RSP = null;

public static void Recv_SUB_ID_WAREHOUSE_TANK_SKILL_RESET_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
ushort tankId;
bs.ReadCompressed(out tankId);
uint skillId;
bs.ReadCompressed(out skillId);
uint remainTimes;
bs.ReadCompressed(out remainTimes);
if(delegate_SUB_ID_WAREHOUSE_TANK_SKILL_RESET_RSP!=null)
{
delegate_SUB_ID_WAREHOUSE_TANK_SKILL_RESET_RSP(_errcode, tankId,skillId,remainTimes);
}
}


public static void Send_SUB_ID_WAREHOUSE_TACTIC_PAGE(byte pageIdx,byte opration)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(pageIdx);
bs.WriteCompressed(opration);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_WAREHOUSE_TACTIC_PAGE, bs));
}

public delegate void  Delegate_SUB_ID_WAREHOUSE_TACTIC_PAGE_RSP(int _errcode, byte pageIdx,byte opration,byte res);
public static  Delegate_SUB_ID_WAREHOUSE_TACTIC_PAGE_RSP delegate_SUB_ID_WAREHOUSE_TACTIC_PAGE_RSP = null;

public static void Recv_SUB_ID_WAREHOUSE_TACTIC_PAGE_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
byte pageIdx;
bs.ReadCompressed(out pageIdx);
byte opration;
bs.ReadCompressed(out opration);
byte res;
bs.ReadCompressed(out res);
if(delegate_SUB_ID_WAREHOUSE_TACTIC_PAGE_RSP!=null)
{
delegate_SUB_ID_WAREHOUSE_TACTIC_PAGE_RSP(_errcode, pageIdx,opration,res);
}
}


public static void Send_SUB_ID_WAREHOUSE_TACTIC_PAGE_LSIT(byte pageIdx)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(pageIdx);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_WAREHOUSE_TACTIC_PAGE_LSIT, bs));
}

public delegate void  Delegate_SUB_ID_WAREHOUSE_TACTIC_PAGE_LSIT_RSP(int _errcode, byte pageIdx,byte pagestate,RakNet.RakString pagename,TacticSocket[]  list );
public static  Delegate_SUB_ID_WAREHOUSE_TACTIC_PAGE_LSIT_RSP delegate_SUB_ID_WAREHOUSE_TACTIC_PAGE_LSIT_RSP = null;

public static void Recv_SUB_ID_WAREHOUSE_TACTIC_PAGE_LSIT_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
byte pageIdx;
bs.ReadCompressed(out pageIdx);
byte pagestate;
bs.ReadCompressed(out pagestate);
RakNet.RakString pagename;
pagename = new RakNet.RakString();
bs.ReadCompressed(pagename);
List<TacticSocket> list = new List<TacticSocket>();
List<IData> lst = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
{int socketitem;
bs.ReadCompressed(out socketitem);
TacticSocket val = new TacticSocket(socketitem);
list.Add(val); 
lst.Add(val); 
}
 DataHelper.Refresh(typeof(TacticSocket), lst);
if(delegate_SUB_ID_WAREHOUSE_TACTIC_PAGE_LSIT_RSP!=null)
{
delegate_SUB_ID_WAREHOUSE_TACTIC_PAGE_LSIT_RSP(_errcode, pageIdx,pagestate,pagename, list.ToArray());
}
}


public static void Send_SUB_ID_WAREHOUSE_TACTIC_UP_RUNE(byte pageIdx,byte idx,int itemId)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(pageIdx);
bs.WriteCompressed(idx);
bs.WriteCompressed(itemId);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_WAREHOUSE_TACTIC_UP_RUNE, bs));
}

public delegate void  Delegate_SUB_ID_WAREHOUSE_TACTIC_UP_RUNE_RSP(int _errcode, byte pageIdx,byte idx,int itemId);
public static  Delegate_SUB_ID_WAREHOUSE_TACTIC_UP_RUNE_RSP delegate_SUB_ID_WAREHOUSE_TACTIC_UP_RUNE_RSP = null;

public static void Recv_SUB_ID_WAREHOUSE_TACTIC_UP_RUNE_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
byte pageIdx;
bs.ReadCompressed(out pageIdx);
byte idx;
bs.ReadCompressed(out idx);
int itemId;
bs.ReadCompressed(out itemId);
if(delegate_SUB_ID_WAREHOUSE_TACTIC_UP_RUNE_RSP!=null)
{
delegate_SUB_ID_WAREHOUSE_TACTIC_UP_RUNE_RSP(_errcode, pageIdx,idx,itemId);
}
}


public static void Send_SUB_ID_WAREHOUSE_TACTIC_DOWN_RUNE(byte pageIdx,byte idx)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(pageIdx);
bs.WriteCompressed(idx);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_WAREHOUSE_TACTIC_DOWN_RUNE, bs));
}

public delegate void  Delegate_SUB_ID_WAREHOUSE_TACTIC_DOWN_RUNE_RSP(int _errcode, byte pageIdx,byte idx,int itemId);
public static  Delegate_SUB_ID_WAREHOUSE_TACTIC_DOWN_RUNE_RSP delegate_SUB_ID_WAREHOUSE_TACTIC_DOWN_RUNE_RSP = null;

public static void Recv_SUB_ID_WAREHOUSE_TACTIC_DOWN_RUNE_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
byte pageIdx;
bs.ReadCompressed(out pageIdx);
byte idx;
bs.ReadCompressed(out idx);
int itemId;
bs.ReadCompressed(out itemId);
if(delegate_SUB_ID_WAREHOUSE_TACTIC_DOWN_RUNE_RSP!=null)
{
delegate_SUB_ID_WAREHOUSE_TACTIC_DOWN_RUNE_RSP(_errcode, pageIdx,idx,itemId);
}
}


public static void Send_SUB_ID_WAREHOUSE_TACTIC_UNLOCK_SOCKET(byte pageIdx,byte idx)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(pageIdx);
bs.WriteCompressed(idx);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_WAREHOUSE_TACTIC_UNLOCK_SOCKET, bs));
}

public delegate void  Delegate_SUB_ID_WAREHOUSE_TACTIC_UNLOCK_SOCKET_RSP(int _errcode, byte pageIdx,byte idx,byte res);
public static  Delegate_SUB_ID_WAREHOUSE_TACTIC_UNLOCK_SOCKET_RSP delegate_SUB_ID_WAREHOUSE_TACTIC_UNLOCK_SOCKET_RSP = null;

public static void Recv_SUB_ID_WAREHOUSE_TACTIC_UNLOCK_SOCKET_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
byte pageIdx;
bs.ReadCompressed(out pageIdx);
byte idx;
bs.ReadCompressed(out idx);
byte res;
bs.ReadCompressed(out res);
if(delegate_SUB_ID_WAREHOUSE_TACTIC_UNLOCK_SOCKET_RSP!=null)
{
delegate_SUB_ID_WAREHOUSE_TACTIC_UNLOCK_SOCKET_RSP(_errcode, pageIdx,idx,res);
}
}


public static void Send_SUB_ID_WAREHOUSE_TACTIC_SET_NAME(byte pageIdx,RakNet.RakString name)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(pageIdx);
bs.WriteCompressed(name);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_WAREHOUSE_TACTIC_SET_NAME, bs));
}

public delegate void  Delegate_SUB_ID_WAREHOUSE_TACTIC_SET_NAME_RSP(int _errcode, byte pageIdx,byte res);
public static  Delegate_SUB_ID_WAREHOUSE_TACTIC_SET_NAME_RSP delegate_SUB_ID_WAREHOUSE_TACTIC_SET_NAME_RSP = null;

public static void Recv_SUB_ID_WAREHOUSE_TACTIC_SET_NAME_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
byte pageIdx;
bs.ReadCompressed(out pageIdx);
byte res;
bs.ReadCompressed(out res);
if(delegate_SUB_ID_WAREHOUSE_TACTIC_SET_NAME_RSP!=null)
{
delegate_SUB_ID_WAREHOUSE_TACTIC_SET_NAME_RSP(_errcode, pageIdx,res);
}
}


public static void Send_SUB_ID_WAREHOUSE_TACTIC_DOWN_ALL_RUNE(byte pageIdx)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(pageIdx);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_WAREHOUSE_TACTIC_DOWN_ALL_RUNE, bs));
}

public delegate void  Delegate_SUB_ID_WAREHOUSE_TACTIC_DOWN_ALL_RUNE_RSP(int _errcode, byte pageIdx,byte res);
public static  Delegate_SUB_ID_WAREHOUSE_TACTIC_DOWN_ALL_RUNE_RSP delegate_SUB_ID_WAREHOUSE_TACTIC_DOWN_ALL_RUNE_RSP = null;

public static void Recv_SUB_ID_WAREHOUSE_TACTIC_DOWN_ALL_RUNE_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
byte pageIdx;
bs.ReadCompressed(out pageIdx);
byte res;
bs.ReadCompressed(out res);
if(delegate_SUB_ID_WAREHOUSE_TACTIC_DOWN_ALL_RUNE_RSP!=null)
{
delegate_SUB_ID_WAREHOUSE_TACTIC_DOWN_ALL_RUNE_RSP(_errcode, pageIdx,res);
}
}


public static void Send_SUB_ID_WAREHOUSE_TACTIC_DECOMPOSE(byte itemCount,ItemInfo[] itemList)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(itemCount);
foreach(ItemInfo val in itemList)
{
bs.WriteCompressed(val.itemId);
bs.WriteCompressed(val.itemNum);
}
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_WAREHOUSE_TACTIC_DECOMPOSE, bs));
}

public delegate void  Delegate_SUB_ID_WAREHOUSE_TACTIC_DECOMPOSE_RSP(int _errcode, byte res,uint stragypoint);
public static  Delegate_SUB_ID_WAREHOUSE_TACTIC_DECOMPOSE_RSP delegate_SUB_ID_WAREHOUSE_TACTIC_DECOMPOSE_RSP = null;

public static void Recv_SUB_ID_WAREHOUSE_TACTIC_DECOMPOSE_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
byte res;
bs.ReadCompressed(out res);
uint stragypoint;
bs.ReadCompressed(out stragypoint);
if(delegate_SUB_ID_WAREHOUSE_TACTIC_DECOMPOSE_RSP!=null)
{
delegate_SUB_ID_WAREHOUSE_TACTIC_DECOMPOSE_RSP(_errcode, res,stragypoint);
}
}


public static void Send_SUB_ID_WAREHOUSE_TACTIC_COMPOSE(uint strategyItem)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(strategyItem);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_WAREHOUSE_TACTIC_COMPOSE, bs));
}

public delegate void  Delegate_SUB_ID_WAREHOUSE_TACTIC_COMPOSE_RSP(int _errcode, byte res);
public static  Delegate_SUB_ID_WAREHOUSE_TACTIC_COMPOSE_RSP delegate_SUB_ID_WAREHOUSE_TACTIC_COMPOSE_RSP = null;

public static void Recv_SUB_ID_WAREHOUSE_TACTIC_COMPOSE_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
byte res;
bs.ReadCompressed(out res);
if(delegate_SUB_ID_WAREHOUSE_TACTIC_COMPOSE_RSP!=null)
{
delegate_SUB_ID_WAREHOUSE_TACTIC_COMPOSE_RSP(_errcode, res);
}
}

public delegate void  Delegate_SUB_ID_OPEN_FUNCTION_RSP(int _errcode, bool isSingle,UInteger[]  list );
public static  Delegate_SUB_ID_OPEN_FUNCTION_RSP delegate_SUB_ID_OPEN_FUNCTION_RSP = null;

public static void Recv_SUB_ID_OPEN_FUNCTION_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
bool isSingle;
bs.ReadCompressed(out isSingle);
List<UInteger> list = new List<UInteger>();
List<IData> lst = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
{uint value;
bs.ReadCompressed(out value);
UInteger val = new UInteger(value);
list.Add(val); 
lst.Add(val); 
}
 DataHelper.Refresh(typeof(UInteger), lst);
if(delegate_SUB_ID_OPEN_FUNCTION_RSP!=null)
{
delegate_SUB_ID_OPEN_FUNCTION_RSP(_errcode, isSingle, list.ToArray());
}
}


public static void Send_SUB_ID_CONSUME(byte type)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(type);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_CONSUME, bs));
}

public delegate void  Delegate_SUB_ID_CONSUME_RSP(int _errcode, byte type,uint value,uint rate);
public static  Delegate_SUB_ID_CONSUME_RSP delegate_SUB_ID_CONSUME_RSP = null;

public static void Recv_SUB_ID_CONSUME_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
byte type;
bs.ReadCompressed(out type);
uint value;
bs.ReadCompressed(out value);
uint rate;
bs.ReadCompressed(out rate);
if(delegate_SUB_ID_CONSUME_RSP!=null)
{
delegate_SUB_ID_CONSUME_RSP(_errcode, type,value,rate);
}
}


public static void Send_SUB_ID_TUTORIAL_MODIFY(Tutorial[] tutorial)
{
RakNet.BitStream bs = new RakNet.BitStream();
foreach(Tutorial val in tutorial)
{
bs.WriteCompressed(val.id);
bs.WriteCompressed(val.isFinished);
}
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_TUTORIAL_MODIFY, bs));
}

public delegate void  Delegate_SUB_ID_TUTORIAL_RSP(int _errcode, uint id,bool isFinished);
public static  Delegate_SUB_ID_TUTORIAL_RSP delegate_SUB_ID_TUTORIAL_RSP = null;
public delegate void  Delegate_SUB_ID_TUTORIAL_RSP_completed();
public static  Delegate_SUB_ID_TUTORIAL_RSP_completed delegate_SUB_ID_TUTORIAL_RSP_completed = null;

public static void Recv_SUB_ID_TUTORIAL_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
List<IData>list = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
 {
uint id;
bs.ReadCompressed(out id);
bool isFinished;
bs.ReadCompressed(out isFinished);

Tutorial data = new Tutorial(id,isFinished);
list.Add(data);
if(delegate_SUB_ID_TUTORIAL_RSP!=null)
{
delegate_SUB_ID_TUTORIAL_RSP(_errcode, id,isFinished);
}
}
DataHelper.Refresh(typeof(Tutorial), list);
if(delegate_SUB_ID_TUTORIAL_RSP_completed!=null)
{
delegate_SUB_ID_TUTORIAL_RSP_completed();}
}


public static void Send_SUB_ID_TUTORIAL_IGNORE(bool ignore)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(ignore);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_TUTORIAL_IGNORE, bs));
}


public static void Send_SUB_ID_WAREHOUSE_TANK_SPLIT(ushort tankId,byte type)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(tankId);
bs.WriteCompressed(type);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_WAREHOUSE_TANK_SPLIT, bs));
}

public delegate void  Delegate_SUB_ID_WAREHOUSE_TANK_SPLIT_RSP(int _errcode);
public static  Delegate_SUB_ID_WAREHOUSE_TANK_SPLIT_RSP delegate_SUB_ID_WAREHOUSE_TANK_SPLIT_RSP = null;

public static void Recv_SUB_ID_WAREHOUSE_TANK_SPLIT_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
if(delegate_SUB_ID_WAREHOUSE_TANK_SPLIT_RSP!=null)
{
delegate_SUB_ID_WAREHOUSE_TANK_SPLIT_RSP(_errcode);
}
}


public static void Send_SUB_ID_PLAYER_SELECT_HEAD(uint avatarId)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(avatarId);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_PLAYER_SELECT_HEAD, bs));
}

public delegate void  Delegate_SUB_ID_PLAYER_SELECT_HEAD_RSP(int _errcode, uint avatarId,byte result);
public static  Delegate_SUB_ID_PLAYER_SELECT_HEAD_RSP delegate_SUB_ID_PLAYER_SELECT_HEAD_RSP = null;

public static void Recv_SUB_ID_PLAYER_SELECT_HEAD_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
uint avatarId;
bs.ReadCompressed(out avatarId);
byte result;
bs.ReadCompressed(out result);
if(delegate_SUB_ID_PLAYER_SELECT_HEAD_RSP!=null)
{
delegate_SUB_ID_PLAYER_SELECT_HEAD_RSP(_errcode, avatarId,result);
}
}

public delegate void  Delegate_SUB_ID_PPVE_TEAM_OVER_RSP(int _errcode);
public static  Delegate_SUB_ID_PPVE_TEAM_OVER_RSP delegate_SUB_ID_PPVE_TEAM_OVER_RSP = null;

public static void Recv_SUB_ID_PPVE_TEAM_OVER_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
if(delegate_SUB_ID_PPVE_TEAM_OVER_RSP!=null)
{
delegate_SUB_ID_PPVE_TEAM_OVER_RSP(_errcode);
}
}


public static void Send_SUB_ID_PLAYER_ELO_MATCH(uint battleID)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(battleID);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_PLAYER_ELO_MATCH, bs));
}

public delegate void  Delegate_SUB_ID_PLAYER_ELO_MATCH_RSP(int _errcode, uint battleID,uint waitTimeOut,uint avgMatchTime);
public static  Delegate_SUB_ID_PLAYER_ELO_MATCH_RSP delegate_SUB_ID_PLAYER_ELO_MATCH_RSP = null;

public static void Recv_SUB_ID_PLAYER_ELO_MATCH_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
uint battleID;
bs.ReadCompressed(out battleID);
uint waitTimeOut;
bs.ReadCompressed(out waitTimeOut);
uint avgMatchTime;
bs.ReadCompressed(out avgMatchTime);
if(delegate_SUB_ID_PLAYER_ELO_MATCH_RSP!=null)
{
delegate_SUB_ID_PLAYER_ELO_MATCH_RSP(_errcode, battleID,waitTimeOut,avgMatchTime);
}
}


public static void Send_SUB_ID_PLAYER_ELO_MATCH_CANCEL()
{
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_PLAYER_ELO_MATCH_CANCEL,  new RakNet.BitStream()));
}

public delegate void  Delegate_SUB_ID_PLAYER_ELO_MATCH_CANCEL_RSP(int _errcode, byte error);
public static  Delegate_SUB_ID_PLAYER_ELO_MATCH_CANCEL_RSP delegate_SUB_ID_PLAYER_ELO_MATCH_CANCEL_RSP = null;

public static void Recv_SUB_ID_PLAYER_ELO_MATCH_CANCEL_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
byte error;
bs.ReadCompressed(out error);
if(delegate_SUB_ID_PLAYER_ELO_MATCH_CANCEL_RSP!=null)
{
delegate_SUB_ID_PLAYER_ELO_MATCH_CANCEL_RSP(_errcode, error);
}
}

public delegate void  Delegate_SUB_ID_PLAYER_ELO_MATCH_LOCK_RSP(int _errcode);
public static  Delegate_SUB_ID_PLAYER_ELO_MATCH_LOCK_RSP delegate_SUB_ID_PLAYER_ELO_MATCH_LOCK_RSP = null;

public static void Recv_SUB_ID_PLAYER_ELO_MATCH_LOCK_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
if(delegate_SUB_ID_PLAYER_ELO_MATCH_LOCK_RSP!=null)
{
delegate_SUB_ID_PLAYER_ELO_MATCH_LOCK_RSP(_errcode);
}
}

public delegate void  Delegate_SUB_ID_PLAYER_ELO_MATCH_RESETROOM_RSP(int _errcode);
public static  Delegate_SUB_ID_PLAYER_ELO_MATCH_RESETROOM_RSP delegate_SUB_ID_PLAYER_ELO_MATCH_RESETROOM_RSP = null;

public static void Recv_SUB_ID_PLAYER_ELO_MATCH_RESETROOM_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
if(delegate_SUB_ID_PLAYER_ELO_MATCH_RESETROOM_RSP!=null)
{
delegate_SUB_ID_PLAYER_ELO_MATCH_RESETROOM_RSP(_errcode);
}
}


public static void Send_SUB_ID_ASK_PLAYER_INFO(uint playerid)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(playerid);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_ASK_PLAYER_INFO, bs));
}

public delegate void  Delegate_SUB_ID_ASK_PLAYER_INFO_RSP(int _errcode, uint playerid,RakNet.RakString name,RakNet.RakString corpsName,RakNet.RakString corpsLvName,RecordData[]  list );
public static  Delegate_SUB_ID_ASK_PLAYER_INFO_RSP delegate_SUB_ID_ASK_PLAYER_INFO_RSP = null;

public static void Recv_SUB_ID_ASK_PLAYER_INFO_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
uint playerid;
bs.ReadCompressed(out playerid);
RakNet.RakString name;
name = new RakNet.RakString();
bs.ReadCompressed(name);
RakNet.RakString corpsName;
corpsName = new RakNet.RakString();
bs.ReadCompressed(corpsName);
RakNet.RakString corpsLvName;
corpsLvName = new RakNet.RakString();
bs.ReadCompressed(corpsLvName);
List<RecordData> list = new List<RecordData>();
List<IData> lst = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
{uint key;
bs.ReadCompressed(out key);
uint value;
bs.ReadCompressed(out value);
RecordData val = new RecordData(key,value);
list.Add(val); 
lst.Add(val); 
}
 DataHelper.Refresh(typeof(RecordData), lst);
if(delegate_SUB_ID_ASK_PLAYER_INFO_RSP!=null)
{
delegate_SUB_ID_ASK_PLAYER_INFO_RSP(_errcode, playerid,name,corpsName,corpsLvName, list.ToArray());
}
}


public static void Send_SUB_ID_ASK_PLAYER_RECORD(uint playerid,byte type)
{
RakNet.BitStream bs = new RakNet.BitStream();
bs.WriteCompressed(playerid);
bs.WriteCompressed(type);
TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_SUBMSG_BEGIN, SubMessageID.SUB_ID_ASK_PLAYER_RECORD, bs));
}

public delegate void  Delegate_SUB_ID_ASK_PLAYER_RECORD_RSP(int _errcode, uint playerid,byte type,RecordData[]  list );
public static  Delegate_SUB_ID_ASK_PLAYER_RECORD_RSP delegate_SUB_ID_ASK_PLAYER_RECORD_RSP = null;

public static void Recv_SUB_ID_ASK_PLAYER_RECORD_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
uint playerid;
bs.ReadCompressed(out playerid);
byte type;
bs.ReadCompressed(out type);
List<RecordData> list = new List<RecordData>();
List<IData> lst = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
{uint key;
bs.ReadCompressed(out key);
uint value;
bs.ReadCompressed(out value);
RecordData val = new RecordData(key,value);
list.Add(val); 
lst.Add(val); 
}
 DataHelper.Refresh(typeof(RecordData), lst);
if(delegate_SUB_ID_ASK_PLAYER_RECORD_RSP!=null)
{
delegate_SUB_ID_ASK_PLAYER_RECORD_RSP(_errcode, playerid,type, list.ToArray());
}
}

public delegate void  Delegate_SUB_ID_BATTLE_CAPTURE_FLAG_SCORE_RSP(int _errcode, byte group,uint score);
public static  Delegate_SUB_ID_BATTLE_CAPTURE_FLAG_SCORE_RSP delegate_SUB_ID_BATTLE_CAPTURE_FLAG_SCORE_RSP = null;

public static void Recv_SUB_ID_BATTLE_CAPTURE_FLAG_SCORE_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
byte group;
bs.ReadCompressed(out group);
uint score;
bs.ReadCompressed(out score);
if(delegate_SUB_ID_BATTLE_CAPTURE_FLAG_SCORE_RSP!=null)
{
delegate_SUB_ID_BATTLE_CAPTURE_FLAG_SCORE_RSP(_errcode, group,score);
}
}

public delegate void  Delegate_SUB_ID_BATTLE_KILL_PEOPLE_RSP(int _errcode, byte type,uint count);
public static  Delegate_SUB_ID_BATTLE_KILL_PEOPLE_RSP delegate_SUB_ID_BATTLE_KILL_PEOPLE_RSP = null;

public static void Recv_SUB_ID_BATTLE_KILL_PEOPLE_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
byte type;
bs.ReadCompressed(out type);
uint count;
bs.ReadCompressed(out count);
if(delegate_SUB_ID_BATTLE_KILL_PEOPLE_RSP!=null)
{
delegate_SUB_ID_BATTLE_KILL_PEOPLE_RSP(_errcode, type,count);
}
}

public delegate void  Delegate_SUB_ID_PLAYER_PASSIVE_SKILL_RSP(int _errcode, uint playerId,uint skillId);
public static  Delegate_SUB_ID_PLAYER_PASSIVE_SKILL_RSP delegate_SUB_ID_PLAYER_PASSIVE_SKILL_RSP = null;

public static void Recv_SUB_ID_PLAYER_PASSIVE_SKILL_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
uint playerId;
bs.ReadCompressed(out playerId);
uint skillId;
bs.ReadCompressed(out skillId);
if(delegate_SUB_ID_PLAYER_PASSIVE_SKILL_RSP!=null)
{
delegate_SUB_ID_PLAYER_PASSIVE_SKILL_RSP(_errcode, playerId,skillId);
}
}

public delegate void  Delegate_SUB_ID_USESKILL_RSP(int _errcode, uint monsterID,ServerSkillData[]  list );
public static  Delegate_SUB_ID_USESKILL_RSP delegate_SUB_ID_USESKILL_RSP = null;

public static void Recv_SUB_ID_USESKILL_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
uint monsterID;
bs.ReadCompressed(out monsterID);
List<ServerSkillData> list = new List<ServerSkillData>();
List<IData> lst = new List<IData>();
while (bs.GetNumberOfUnreadBits() > 8)
{short x;
bs.ReadCompressed(out x);
short y;
bs.ReadCompressed(out y);
short z;
bs.ReadCompressed(out z);
uint skillID;
bs.ReadCompressed(out skillID);
ushort delayTime;
bs.ReadCompressed(out delayTime);
ServerSkillData val = new ServerSkillData(x,y,z,skillID,delayTime);
list.Add(val); 
lst.Add(val); 
}
 DataHelper.Refresh(typeof(ServerSkillData), lst);
if(delegate_SUB_ID_USESKILL_RSP!=null)
{
delegate_SUB_ID_USESKILL_RSP(_errcode, monsterID, list.ToArray());
}
}

public delegate void  Delegate_SUB_ID_PPVE_CHALLENGE_RESULT_RSP(int _errcode, uint parameter);
public static  Delegate_SUB_ID_PPVE_CHALLENGE_RESULT_RSP delegate_SUB_ID_PPVE_CHALLENGE_RESULT_RSP = null;

public static void Recv_SUB_ID_PPVE_CHALLENGE_RESULT_RSP(RakNet.BitStream bs) 
 {
 int _errcode = 0;
 string str = System.Text.Encoding.Default.GetString(bs.GetData());
 if (str.StartsWith("^"))
{
_errcode = int.Parse(str.Substring(1, str.Length - 1));
}
uint parameter;
bs.ReadCompressed(out parameter);
if(delegate_SUB_ID_PPVE_CHALLENGE_RESULT_RSP!=null)
{
delegate_SUB_ID_PPVE_CHALLENGE_RESULT_RSP(_errcode, parameter);
}
}


public static void GlobalRegister(Dispatcher dispatcher)
{
 dispatcher.Register((byte)MessageID.ID_SUBMSG_BEGIN, AutoGenProto.Recv_Sub_Message);
 dispatcher.Register((byte)MessageID.ID_PLAYER_HURT_RSP, AutoGenProto.Recv_ID_PLAYER_HURT_RSP);
 dispatcher.Register((byte)MessageID.ID_PLAYER_DEAD_RSP, AutoGenProto.Recv_ID_PLAYER_DEAD_RSP);
 dispatcher.Register((byte)MessageID.ID_PLAYER_REVIVE_RSP, AutoGenProto.Recv_ID_PLAYER_REVIVE_RSP);
 dispatcher.Register((byte)MessageID.ID_PLAYER_FIRE_RSP, AutoGenProto.Recv_ID_PLAYER_FIRE_RSP);
 dispatcher.Register((byte)MessageID.ID_PLAYER_BULLET_NUM_RSP, AutoGenProto.Recv_ID_PLAYER_BULLET_NUM_RSP);
 dispatcher.Register((byte)MessageID.ID_PLAYER_ATTACK_RSP, AutoGenProto.Recv_ID_PLAYER_ATTACK_RSP);
 dispatcher.Register((byte)MessageID.ID_BATTLE_PICKUP_ITEM_RSP, AutoGenProto.Recv_ID_BATTLE_PICKUP_ITEM_RSP);
 dispatcher.Register((byte)MessageID.ID_BATTLE_DROP_RSP, AutoGenProto.Recv_ID_BATTLE_DROP_RSP);
 dispatcher.Register((byte)MessageID.ID_PLAYER_POSITION_SYNC_RSP, AutoGenProto.Recv_ID_PLAYER_POSITION_SYNC_RSP);
 dispatcher.Register((byte)MessageID.ID_PLAYER_SKILL_ALARM_RSP, AutoGenProto.Recv_ID_PLAYER_SKILL_ALARM_RSP);
 dispatcher.Register((byte)MessageID.ID_PLAYER_SKILL_BREAK_RSP, AutoGenProto.Recv_ID_PLAYER_SKILL_BREAK_RSP);
 dispatcher.Register((byte)MessageID.ID_PLAYER_SKILL_RSP, AutoGenProto.Recv_ID_PLAYER_SKILL_RSP);
 dispatcher.Register((byte)MessageID.ID_AI_SPAWN_RSP, AutoGenProto.Recv_ID_AI_SPAWN_RSP);
 dispatcher.Register((byte)MessageID.ID_AI_MOVE_RSP, AutoGenProto.Recv_ID_AI_MOVE_RSP);
 dispatcher.Register((byte)MessageID.ID_AI_MONSTER_ACT_RSP, AutoGenProto.Recv_ID_AI_MONSTER_ACT_RSP);
 dispatcher.Register((byte)MessageID.ID_AI_ATTACK_RSP, AutoGenProto.Recv_ID_AI_ATTACK_RSP);
 dispatcher.Register((byte)MessageID.ID_PLAYER_BUFF_ATTR_RSP, AutoGenProto.Recv_ID_PLAYER_BUFF_ATTR_RSP);
 dispatcher.Register((byte)MessageID.ID_PLAYER_CHANGE_TANK_RSP, AutoGenProto.Recv_ID_PLAYER_CHANGE_TANK_RSP);
 dispatcher.Register((byte)MessageID.ID_GAME_TIME_START_RSP, AutoGenProto.Recv_ID_GAME_TIME_START_RSP);
 dispatcher.Register((byte)MessageID.ID_PLAYER_TIMESTAMP_RSP, AutoGenProto.Recv_ID_PLAYER_TIMESTAMP_RSP);
 dispatcher.Register((byte)MessageID.ID_PLAYER_EXIT_INSTANCE_RSP, AutoGenProto.Recv_ID_PLAYER_EXIT_INSTANCE_RSP);
 dispatcher.Register((byte)MessageID.ID_LOBBY_ROOM_ENTERINFO_RSP, AutoGenProto.Recv_ID_LOBBY_ROOM_ENTERINFO_RSP);
 dispatcher.Register((byte)MessageID.ID_PLAYER_ATTR_CHANGE_RSP, AutoGenProto.Recv_ID_PLAYER_ATTR_CHANGE_RSP);
 dispatcher.Register((byte)MessageID.ID_BATTLE_OBJECT_CREATE_RSP, AutoGenProto.Recv_ID_BATTLE_OBJECT_CREATE_RSP);
 dispatcher.Register((byte)MessageID.ID_BATTLE_MOVE_RSP, AutoGenProto.Recv_ID_BATTLE_MOVE_RSP);
 dispatcher.Register((byte)MessageID.ID_BATTLE_POS_RSP, AutoGenProto.Recv_ID_BATTLE_POS_RSP);
 dispatcher.Register((byte)MessageID.ID_PLAYER_GET_USERID_RSP, AutoGenProto.Recv_ID_PLAYER_GET_USERID_RSP);
 dispatcher.Register((byte)MessageID.ID_LOBBY_LINE_RSP, AutoGenProto.Recv_ID_LOBBY_LINE_RSP);
 dispatcher.Register((byte)MessageID.ID_LOBBY_ROOM_RSP, AutoGenProto.Recv_ID_LOBBY_ROOM_RSP);
 dispatcher.Register((byte)MessageID.ID_LOBBY_CREATE_ROOM_RSP, AutoGenProto.Recv_ID_LOBBY_CREATE_ROOM_RSP);
 dispatcher.Register((byte)MessageID.ID_LOBBY_ROOM_QUICK_JOIN_RSP, AutoGenProto.Recv_ID_LOBBY_ROOM_QUICK_JOIN_RSP);
 dispatcher.Register((byte)MessageID.ID_LOBBY_ROOM_JOIN_RSP, AutoGenProto.Recv_ID_LOBBY_ROOM_JOIN_RSP);
 dispatcher.Register((byte)MessageID.ID_LOBBY_ROOM_CHANGE_TANK_RSP, AutoGenProto.Recv_ID_LOBBY_ROOM_CHANGE_TANK_RSP);
 dispatcher.Register((byte)MessageID.ID_LOBBY_ROOM_INVITE_RSP, AutoGenProto.Recv_ID_LOBBY_ROOM_INVITE_RSP);
 dispatcher.Register((byte)MessageID.ID_LOBBY_ROOM_EXIT_RSP, AutoGenProto.Recv_ID_LOBBY_ROOM_EXIT_RSP);
 dispatcher.Register((byte)MessageID.ID_LOBBY_ROOM_CHANGE_RSP, AutoGenProto.Recv_ID_LOBBY_ROOM_CHANGE_RSP);
 dispatcher.Register((byte)MessageID.ID_LOBBY_ROOM_READY_RSP, AutoGenProto.Recv_ID_LOBBY_ROOM_READY_RSP);
 dispatcher.Register((byte)MessageID.ID_GAME_FINSIHED_RSP, AutoGenProto.Recv_ID_GAME_FINSIHED_RSP);
 dispatcher.Register((byte)MessageID.ID_PLAYER_LOGIN_FINISHED_RSP, AutoGenProto.Recv_ID_PLAYER_LOGIN_FINISHED_RSP);
 dispatcher.Register((byte)MessageID.ID_PLAYER_REPEATED_LOGIN_RSP, AutoGenProto.Recv_ID_PLAYER_REPEATED_LOGIN_RSP);
 dispatcher.Register((byte)MessageID.ID_PLAYER_LOGINOUT_RSP, AutoGenProto.Recv_ID_PLAYER_LOGINOUT_RSP);
 dispatcher.Register((byte)MessageID.ID_PLAYER_PVE_LEVELINFOS_RSP, AutoGenProto.Recv_ID_PLAYER_PVE_LEVELINFOS_RSP);
 dispatcher.Register((byte)MessageID.ID_PLAYER_PVE_START_RSP, AutoGenProto.Recv_ID_PLAYER_PVE_START_RSP);
 dispatcher.Register((byte)MessageID.ID_PLAYER_PVE_RESULT_RSP, AutoGenProto.Recv_ID_PLAYER_PVE_RESULT_RSP);
 dispatcher.Register((byte)MessageID.ID_PLAYER_INFO_CHANGE_RSP, AutoGenProto.Recv_ID_PLAYER_INFO_CHANGE_RSP);
 dispatcher.Register((byte)MessageID.ID_WAREHOUSE_TANK_LIST_RSP, AutoGenProto.Recv_ID_WAREHOUSE_TANK_LIST_RSP);
 dispatcher.Register((byte)MessageID.ID_WAREHOUSE_TANK_DETAIL_INFO_RSP, AutoGenProto.Recv_ID_WAREHOUSE_TANK_DETAIL_INFO_RSP);
 dispatcher.Register((byte)MessageID.ID_WAREHOUSE_TANK_ADD_EXP_RSP, AutoGenProto.Recv_ID_WAREHOUSE_TANK_ADD_EXP_RSP);
 dispatcher.Register((byte)MessageID.ID_WAREHOUSE_TANK_RANK_UP_RSP, AutoGenProto.Recv_ID_WAREHOUSE_TANK_RANK_UP_RSP);
 dispatcher.Register((byte)MessageID.ID_WAREHOUSE_TANK_EQUIP_LVLUP_RSP, AutoGenProto.Recv_ID_WAREHOUSE_TANK_EQUIP_LVLUP_RSP);
 dispatcher.Register((byte)MessageID.ID_ITEM_LIST_RSP, AutoGenProto.Recv_ID_ITEM_LIST_RSP);
 dispatcher.Register((byte)MessageID.ID_PVP_BATTLE_CHAOS_FINISHED_RSP, AutoGenProto.Recv_ID_PVP_BATTLE_CHAOS_FINISHED_RSP);
 dispatcher.Register((byte)MessageID.ID_MAIL_NEW_COMING_RSP, AutoGenProto.Recv_ID_MAIL_NEW_COMING_RSP);
 dispatcher.Register((byte)MessageID.ID_BATLLESERVER_IP_RSP, AutoGenProto.Recv_ID_BATLLESERVER_IP_RSP);
 dispatcher.Register((byte)MessageID.ID_ERROR_RSP, AutoGenProto.Recv_ID_ERROR_RSP);
 dispatcher.Register((byte)MessageID.ID_GAMESERVER_RSP, AutoGenProto.Recv_ID_GAMESERVER_RSP);
}

public static void Recv_Sub_Message(RakNet.BitStream bs)
{
  short i = 0;
bs.Read(out i);
 SubMessageID subID = (SubMessageID)i;
switch (subID)
{
case SubMessageID.SUB_ID_LOG_OUT_RSP:
Recv_SUB_ID_LOG_OUT_RSP(bs);
break;
case SubMessageID.SUB_ID_PAIL_LIST_RSP:
Recv_SUB_ID_PAIL_LIST_RSP(bs);
break;
case SubMessageID.SUB_ID_PAIL_HIT_RSP:
Recv_SUB_ID_PAIL_HIT_RSP(bs);
break;
case SubMessageID.SUB_ID_TORNADO_EFFECT_RSP:
Recv_SUB_ID_TORNADO_EFFECT_RSP(bs);
break;
case SubMessageID.SUB_ID_SYNC_PLAYER_LOAD_RSP:
Recv_SUB_ID_SYNC_PLAYER_LOAD_RSP(bs);
break;
case SubMessageID.SUB_ID_ITEM_USE_RSP:
Recv_SUB_ID_ITEM_USE_RSP(bs);
break;
case SubMessageID.SUB_ID_ITEM_SELL_RSP:
Recv_SUB_ID_ITEM_SELL_RSP(bs);
break;
case SubMessageID.SUB_ID_PILOT_LIST_RSP:
Recv_SUB_ID_PILOT_LIST_RSP(bs);
break;
case SubMessageID.SUB_ID_PILOT_DETAIL_INFO_RSP:
Recv_SUB_ID_PILOT_DETAIL_INFO_RSP(bs);
break;
case SubMessageID.SUB_ID_PILOT_ADD_EXP_RSP:
Recv_SUB_ID_PILOT_ADD_EXP_RSP(bs);
break;
case SubMessageID.SUB_ID_PILOT_RANK_UP_RSP:
Recv_SUB_ID_PILOT_RANK_UP_RSP(bs);
break;
case SubMessageID.SUB_ID_PILOT_MAJOR_LVLUP_RSP:
Recv_SUB_ID_PILOT_MAJOR_LVLUP_RSP(bs);
break;
case SubMessageID.SUB_ID_EXCHANGE_RSP:
Recv_SUB_ID_EXCHANGE_RSP(bs);
break;
case SubMessageID.SUB_ID_TANK_SETTING_RSP:
Recv_SUB_ID_TANK_SETTING_RSP(bs);
break;
case SubMessageID.SUB_ID_TANK_SETTING_UNLOCK_SOCKET_RSP:
Recv_SUB_ID_TANK_SETTING_UNLOCK_SOCKET_RSP(bs);
break;
case SubMessageID.SUB_ID_NOTIFY_MESSAGE_RSP:
Recv_SUB_ID_NOTIFY_MESSAGE_RSP(bs);
break;
case SubMessageID.SUB_ID_CHAT_RSP:
Recv_SUB_ID_CHAT_RSP(bs);
break;
case SubMessageID.SUB_ID_EMOTION_RSP:
Recv_SUB_ID_EMOTION_RSP(bs);
break;
case SubMessageID.SUB_ID_TASK_LIST_RSP:
Recv_SUB_ID_TASK_LIST_RSP(bs);
break;
case SubMessageID.SUB_ID_TASK_GET_RSP:
Recv_SUB_ID_TASK_GET_RSP(bs);
break;
case SubMessageID.SUB_ID_TASK_FINISHED_RSP:
Recv_SUB_ID_TASK_FINISHED_RSP(bs);
break;
case SubMessageID.SUB_ID_ACTIVE_REWARD_RSP:
Recv_SUB_ID_ACTIVE_REWARD_RSP(bs);
break;
case SubMessageID.SUB_ID_ACTIVE_GOTTEN_RSP:
Recv_SUB_ID_ACTIVE_GOTTEN_RSP(bs);
break;
case SubMessageID.SUB_ID_PLAYER_PPVE_TASK_COMPLETE_RSP:
Recv_SUB_ID_PLAYER_PPVE_TASK_COMPLETE_RSP(bs);
break;
case SubMessageID.SUB_ID_PLAYER_PPVE_TASK_LIST_RSP:
Recv_SUB_ID_PLAYER_PPVE_TASK_LIST_RSP(bs);
break;
case SubMessageID.SUB_ID_TEST_BOSS_SKILL_RSP:
Recv_SUB_ID_TEST_BOSS_SKILL_RSP(bs);
break;
case SubMessageID.SUB_ID_PROFESSOR_LIST_RSP:
Recv_SUB_ID_PROFESSOR_LIST_RSP(bs);
break;
case SubMessageID.SUB_ID_FRIEND_GET_FRIENDS_LIST_RSP:
Recv_SUB_ID_FRIEND_GET_FRIENDS_LIST_RSP(bs);
break;
case SubMessageID.SUB_ID_FRIEND_GET_FRIENDSREQ_LIST_RSP:
Recv_SUB_ID_FRIEND_GET_FRIENDSREQ_LIST_RSP(bs);
break;
case SubMessageID.SUB_ID_FRIEND_ADD_RSP:
Recv_SUB_ID_FRIEND_ADD_RSP(bs);
break;
case SubMessageID.SUB_ID_FRIEND_REQUEST_RSP:
Recv_SUB_ID_FRIEND_REQUEST_RSP(bs);
break;
case SubMessageID.SUB_ID_FRIEND_DELETE_RSP:
Recv_SUB_ID_FRIEND_DELETE_RSP(bs);
break;
case SubMessageID.SUB_ID_FRIEND_MODIFY_LINESTATUS_RSP:
Recv_SUB_ID_FRIEND_MODIFY_LINESTATUS_RSP(bs);
break;
case SubMessageID.SUB_ID_FRIEND_MODIFY_LEVEL_RSP:
Recv_SUB_ID_FRIEND_MODIFY_LEVEL_RSP(bs);
break;
case SubMessageID.SUB_ID_FRIEND_MODIFY_ICON_RSP:
Recv_SUB_ID_FRIEND_MODIFY_ICON_RSP(bs);
break;
case SubMessageID.SUB_ID_FRIEND_BATCH_ADD_RSP:
Recv_SUB_ID_FRIEND_BATCH_ADD_RSP(bs);
break;
case SubMessageID.SUB_ID_WAREHOUSE_TANK_STAR_UP_RSP:
Recv_SUB_ID_WAREHOUSE_TANK_STAR_UP_RSP(bs);
break;
case SubMessageID.SUB_ID_WAREHOUSE_TANK_SKILL_RESET_RSP:
Recv_SUB_ID_WAREHOUSE_TANK_SKILL_RESET_RSP(bs);
break;
case SubMessageID.SUB_ID_WAREHOUSE_TACTIC_PAGE_RSP:
Recv_SUB_ID_WAREHOUSE_TACTIC_PAGE_RSP(bs);
break;
case SubMessageID.SUB_ID_WAREHOUSE_TACTIC_PAGE_LSIT_RSP:
Recv_SUB_ID_WAREHOUSE_TACTIC_PAGE_LSIT_RSP(bs);
break;
case SubMessageID.SUB_ID_WAREHOUSE_TACTIC_UP_RUNE_RSP:
Recv_SUB_ID_WAREHOUSE_TACTIC_UP_RUNE_RSP(bs);
break;
case SubMessageID.SUB_ID_WAREHOUSE_TACTIC_DOWN_RUNE_RSP:
Recv_SUB_ID_WAREHOUSE_TACTIC_DOWN_RUNE_RSP(bs);
break;
case SubMessageID.SUB_ID_WAREHOUSE_TACTIC_UNLOCK_SOCKET_RSP:
Recv_SUB_ID_WAREHOUSE_TACTIC_UNLOCK_SOCKET_RSP(bs);
break;
case SubMessageID.SUB_ID_WAREHOUSE_TACTIC_SET_NAME_RSP:
Recv_SUB_ID_WAREHOUSE_TACTIC_SET_NAME_RSP(bs);
break;
case SubMessageID.SUB_ID_WAREHOUSE_TACTIC_DOWN_ALL_RUNE_RSP:
Recv_SUB_ID_WAREHOUSE_TACTIC_DOWN_ALL_RUNE_RSP(bs);
break;
case SubMessageID.SUB_ID_WAREHOUSE_TACTIC_DECOMPOSE_RSP:
Recv_SUB_ID_WAREHOUSE_TACTIC_DECOMPOSE_RSP(bs);
break;
case SubMessageID.SUB_ID_WAREHOUSE_TACTIC_COMPOSE_RSP:
Recv_SUB_ID_WAREHOUSE_TACTIC_COMPOSE_RSP(bs);
break;
case SubMessageID.SUB_ID_OPEN_FUNCTION_RSP:
Recv_SUB_ID_OPEN_FUNCTION_RSP(bs);
break;
case SubMessageID.SUB_ID_CONSUME_RSP:
Recv_SUB_ID_CONSUME_RSP(bs);
break;
case SubMessageID.SUB_ID_TUTORIAL_RSP:
Recv_SUB_ID_TUTORIAL_RSP(bs);
break;
case SubMessageID.SUB_ID_WAREHOUSE_TANK_SPLIT_RSP:
Recv_SUB_ID_WAREHOUSE_TANK_SPLIT_RSP(bs);
break;
case SubMessageID.SUB_ID_PLAYER_SELECT_HEAD_RSP:
Recv_SUB_ID_PLAYER_SELECT_HEAD_RSP(bs);
break;
case SubMessageID.SUB_ID_PPVE_TEAM_OVER_RSP:
Recv_SUB_ID_PPVE_TEAM_OVER_RSP(bs);
break;
case SubMessageID.SUB_ID_PLAYER_ELO_MATCH_RSP:
Recv_SUB_ID_PLAYER_ELO_MATCH_RSP(bs);
break;
case SubMessageID.SUB_ID_PLAYER_ELO_MATCH_CANCEL_RSP:
Recv_SUB_ID_PLAYER_ELO_MATCH_CANCEL_RSP(bs);
break;
case SubMessageID.SUB_ID_PLAYER_ELO_MATCH_LOCK_RSP:
Recv_SUB_ID_PLAYER_ELO_MATCH_LOCK_RSP(bs);
break;
case SubMessageID.SUB_ID_PLAYER_ELO_MATCH_RESETROOM_RSP:
Recv_SUB_ID_PLAYER_ELO_MATCH_RESETROOM_RSP(bs);
break;
case SubMessageID.SUB_ID_ASK_PLAYER_INFO_RSP:
Recv_SUB_ID_ASK_PLAYER_INFO_RSP(bs);
break;
case SubMessageID.SUB_ID_ASK_PLAYER_RECORD_RSP:
Recv_SUB_ID_ASK_PLAYER_RECORD_RSP(bs);
break;
case SubMessageID.SUB_ID_BATTLE_CAPTURE_FLAG_SCORE_RSP:
Recv_SUB_ID_BATTLE_CAPTURE_FLAG_SCORE_RSP(bs);
break;
case SubMessageID.SUB_ID_BATTLE_KILL_PEOPLE_RSP:
Recv_SUB_ID_BATTLE_KILL_PEOPLE_RSP(bs);
break;
case SubMessageID.SUB_ID_PLAYER_PASSIVE_SKILL_RSP:
Recv_SUB_ID_PLAYER_PASSIVE_SKILL_RSP(bs);
break;
case SubMessageID.SUB_ID_USESKILL_RSP:
Recv_SUB_ID_USESKILL_RSP(bs);
break;
case SubMessageID.SUB_ID_PPVE_CHALLENGE_RESULT_RSP:
Recv_SUB_ID_PPVE_CHALLENGE_RESULT_RSP(bs);
break;
}
}
}