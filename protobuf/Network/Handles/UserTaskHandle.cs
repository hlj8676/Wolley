using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DataWrapper;
public class UserTaskHandle :SuperBOBO.NetInterface
{
    public delegate void TaskListLuaHeper(byte taskType, TaskInfo[] list);
    public delegate void TaskGetLuaHeper(byte taskType, uint ID);
    public delegate void TaskFinishedLuaHeper(byte taskType, TaskInfo info);

    public static TaskListLuaHeper taskListLuaHelper;
    public static TaskGetLuaHeper taskGetLuaHelper;
    public static TaskFinishedLuaHeper taskFinishedLuaHelper;

    private void Delegate_SUB_ID_TASK_LIST_RSP(int errorCode, byte taskType, TaskInfo[] list)
    {
        if (taskType == (byte)TaskType.TaskType_Daily)
        {
            Player.instance.task.dailyTasks.Clear();
            Player.instance.task.dailyTasks.AddRange(list);
        }
        else
        {
//            Util.Log("todo");
            Player.instance.task.mainTasks.Clear();
            Player.instance.task.mainTasks.AddRange(list);
        }

        DataWrapper.ModelDispatcher.Instance.Dispatch(DataWrapper.Player.instance.task);

        if (taskListLuaHelper != null && list.Length != 0)
        {
            taskListLuaHelper(taskType, list);
        }


    }

    private void Delegate_SUB_ID_TASK_GET_RSP(int errorCode, byte taskType, uint ID)
    {
        if (GuideManager.instance != null)
            GuideManager.instance.CheckGuideToTrigger(3, ID);//任务开启引导
        TaskInfo info = Player.instance.task.Find((TaskType)taskType, ID);
        if (info != null)
            info.isGotten = true;
        else
            Util.LogError("TaskType " + taskType + " ID " + ID + "not exsit!");

        DataWrapper.ModelDispatcher.Instance.Dispatch(DataWrapper.Player.instance.task);

        if (taskGetLuaHelper != null)
        {
            taskGetLuaHelper(taskType, ID);
        }
    }

    private void Delegate_SUB_ID_TASK_FINISHED_RSP(int errorCode, byte taskType, TaskInfo[] list)
    {
        TaskInfo newInfo = list[0];

        
        TaskInfo info = Player.instance.task.Find((TaskType)taskType, newInfo.ID);
        if (info != null)
            info = newInfo;
        else
            Util.LogError("TaskType " + taskType + " ID " + newInfo.ID + "not exsit!");

        DataWrapper.ModelDispatcher.Instance.Dispatch(DataWrapper.Player.instance.task);

        if (taskFinishedLuaHelper != null)
        {
            taskFinishedLuaHelper(taskType, newInfo);
        }
    }


    public void OnRegister()
    {
        AutoGenProto.delegate_SUB_ID_TASK_LIST_RSP += Delegate_SUB_ID_TASK_LIST_RSP;
        AutoGenProto.delegate_SUB_ID_TASK_GET_RSP += Delegate_SUB_ID_TASK_GET_RSP;
        AutoGenProto.delegate_SUB_ID_TASK_FINISHED_RSP += Delegate_SUB_ID_TASK_FINISHED_RSP;
        
    }

    public static void SendGetDailyTaskList()
    {
        AutoGenProto.Send_SUB_ID_TASK_LIST((byte)TaskType.TaskType_Daily);
    }

    public static void SendGetMainTaskList()
    {
        AutoGenProto.Send_SUB_ID_TASK_LIST((byte)TaskType.TaskType_Main);        
    }

    public static void SendActiveRewardPoint(uint point)
    {
        AutoGenProto.Send_SUB_ID_ACTIVE_REWARD(point);
    }

    public static void SendTaskGetReward(byte taskType,uint id)
    {
        AutoGenProto.Send_SUB_ID_TASK_GET(taskType, id);
    }

    public void OnUnRegister()
    {
        AutoGenProto.delegate_SUB_ID_TASK_LIST_RSP -= Delegate_SUB_ID_TASK_LIST_RSP;
        AutoGenProto.delegate_SUB_ID_TASK_GET_RSP -= Delegate_SUB_ID_TASK_GET_RSP;
        AutoGenProto.delegate_SUB_ID_TASK_FINISHED_RSP -= Delegate_SUB_ID_TASK_FINISHED_RSP;
        
    }

    //断线重连后，数据同步调用方法 by shilongquan
    public void OnDataUpdate()
    {

    }
}
