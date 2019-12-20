// ========================================================
// 描 述：不同事件的监听，不通事件的移除监听，广播
// 作 者：SW
// 创建时间：2019/01/16 09:57:30
// 版 本：v 1.0
// ========================================================

using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class EventCenter : MonoBehaviour
{
    private static readonly Dictionary<EventName, Delegate> EventTable = new Dictionary<EventName, Delegate>();


    #region 无参的监听
    /// <summary>
    /// 无参的添加监听
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="callBack"></param>
    public static void AddListener(EventName eventName, CallBack callBack)
    {
        OnListerAding(eventName, callBack);

        EventTable[eventName] = (CallBack)EventTable[eventName] + callBack;
    }


    /// <summary>
    /// 移除无参的监听
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="callBack"></param>
    public static void RemoveListener(EventName eventName, [NotNull] CallBack callBack)
    {
        OnlistenerRemoveing(eventName, callBack);

        EventTable[eventName] = (CallBack)EventTable[eventName] - callBack;

        OnlistenerRemoved(eventName);
    }


    /// <summary>
    /// 广播无参的监听
    /// </summary>
    /// <param name="eventName"></param>
    public static void BroadListener(EventName eventName)
    {
        Delegate d;
        if (EventTable.TryGetValue(eventName, out d))
        {
            CallBack callBack = d as CallBack;
            if (callBack != null)
            {
                callBack();
            }
            else
            {
                throw new Exception(string.Format("广播事件错误：事件{0}对应的委托具有不同的类型", eventName));
            }
        }
    }
    #endregion


    #region 一个参数的监听
    /// <summary>
    /// 一个参数的添加监听
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="callBack"></param>
    public static void AddListener<T>(EventName eventName, CallBack<T> callBack)
    {
        OnListerAding(eventName, callBack);

        EventTable[eventName] = (CallBack<T>)EventTable[eventName] + callBack;
    }


    /// <summary>
    /// 移除一个参数的监听
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="callBack"></param>
    public static void RemoveListener<T>(EventName eventName, [NotNull] CallBack<T> callBack)
    {
        OnlistenerRemoveing(eventName, callBack);

        EventTable[eventName] = (CallBack<T>)EventTable[eventName] - callBack;

        OnlistenerRemoved(eventName);
    }


    /// <summary>
    /// 广播一个参数的监听
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="arg"></param>
    public static void BroadListener<T>(EventName eventName, T arg)
    {
        Delegate d;
        if (EventTable.TryGetValue(eventName, out d))
        {
            CallBack<T> callBack = d as CallBack<T>;
            if (callBack != null)
            {
                callBack(arg);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误：事件{0}对应的委托具有不同的类型", eventName));
            }
        }

    }
    #endregion


    #region 两个参数的监听
    /// <summary>
    /// 两个参数的添加监听
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="callBack"></param>
    public static void AddListener<T, TX>(EventName eventName, CallBack<T, TX> callBack)
    {
        OnListerAding(eventName, callBack);

        EventTable[eventName] = (CallBack<T, TX>)EventTable[eventName] + callBack;
    }


    /// <summary>
    /// 移除两个参数的监听
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="callBack"></param>
    public static void RemoveListener<T, TX>(EventName eventName, [NotNull] CallBack<T, TX> callBack)
    {
        OnlistenerRemoveing(eventName, callBack);

        EventTable[eventName] = (CallBack<T, TX>)EventTable[eventName] - callBack;

        OnlistenerRemoved(eventName);
    }


    /// <summary>
    /// 广播两个参数的监听
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    public static void BroadListener<T, TX>(EventName eventName, T arg1, TX arg2)
    {
        Delegate d;
        if (EventTable.TryGetValue(eventName, out d))
        {
            CallBack<T, TX> callBack = d as CallBack<T, TX>;
            if (callBack != null)
            {
                callBack(arg1, arg2);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误：事件{0}对应的委托具有不同的类型", eventName));
            }
        }

    }
    #endregion


    #region 三个参数的监听
    /// <summary>
    /// 三个参数的添加监听
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="callBack"></param>
    public static void AddListener<T, TX, TY>(EventName eventName, CallBack<T, TX, TY> callBack)
    {
        OnListerAding(eventName, callBack);

        EventTable[eventName] = (CallBack<T, TX, TY>)EventTable[eventName] + callBack;
    }


    /// <summary>
    /// 移除三个参数的监听
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="callBack"></param>
    public static void RemoveListener<T, TX, TY>(EventName eventName, [NotNull] CallBack<T, TX, TY> callBack)
    {
        OnlistenerRemoveing(eventName, callBack);

        EventTable[eventName] = (CallBack<T, TX, TY>)EventTable[eventName] - callBack;

        OnlistenerRemoved(eventName);
    }


    /// <summary>
    /// 广播三个参数的监听
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    public static void BroadListener<T, TX, TY>(EventName eventName, T arg1, TX arg2, TY arg3)
    {
        Delegate d;
        if (EventTable.TryGetValue(eventName, out d))
        {
            CallBack<T, TX, TY> callBack = d as CallBack<T, TX, TY>;
            if (callBack != null)
            {
                callBack(arg1, arg2, arg3);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误：事件{0}对应的委托具有不同的类型", eventName));
            }
        }

    }
    #endregion


    #region 四个参数的监听
    /// <summary>
    /// 四个参数的添加监听
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="callBack"></param>
    public static void AddListener<T, TX, TY, TZ>(EventName eventName, CallBack<T, TX, TY, TZ> callBack)
    {
        OnListerAding(eventName, callBack);

        EventTable[eventName] = (CallBack<T, TX, TY, TZ>)EventTable[eventName] + callBack;
    }


    /// <summary>
    /// 移除四个参数的监听
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="callBack"></param>
    public static void RemoveListener<T, TX, TY, TZ>(EventName eventName, [NotNull] CallBack<T, TX, TY, TZ> callBack)
    {
        OnlistenerRemoveing(eventName, callBack);

        EventTable[eventName] = (CallBack<T, TX, TY, TZ>)EventTable[eventName] - callBack;

        OnlistenerRemoved(eventName);
    }


    /// <summary>
    /// 广播四个参数的监听
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    /// <param name="arg4"></param>
    public static void BroadListener<T, TX, TY, TZ>(EventName eventName, T arg1, TX arg2, TY arg3, TZ arg4)
    {
        Delegate d;
        if (EventTable.TryGetValue(eventName, out d))
        {
            CallBack<T, TX, TY, TZ> callBack = d as CallBack<T, TX, TY, TZ>;
            if (callBack != null)
            {
                callBack(arg1, arg2, arg3, arg4);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误：事件{0}对应的委托具有不同的类型", eventName));
            }
        }

    }
    #endregion


    #region 五个参数的监听
    /// <summary>
    /// 五个参数的添加监听
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="callBack"></param>
    public static void AddListener<T, TX, TY, TZ, TW>(EventName eventName, CallBack<T, TX, TY, TZ, TW> callBack)
    {
        OnListerAding(eventName, callBack);

        EventTable[eventName] = (CallBack<T, TX, TY, TZ, TW>)EventTable[eventName] + callBack;
    }


    /// <summary>
    /// 移除五个参数的监听
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="callBack"></param>
    public static void RemoveListener<T, TX, TY, TZ, TW>(EventName eventName, [NotNull] CallBack<T, TX, TY, TZ, TW> callBack)
    {
        OnlistenerRemoveing(eventName, callBack);

        EventTable[eventName] = (CallBack<T, TX, TY, TZ, TW>)EventTable[eventName] - callBack;

        OnlistenerRemoved(eventName);
    }


    /// <summary>
    /// 广播五个参数的监听
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    /// <param name="arg4"></param>
    /// <param name="arg5"></param>
    public static void BroadListener<T, TX, TY, TZ, TW>(EventName eventName, T arg1, TX arg2, TY arg3, TZ arg4, TW arg5)
    {
        Delegate d;
        if (EventTable.TryGetValue(eventName, out d))
        {
            CallBack<T, TX, TY, TZ, TW> callBack = d as CallBack<T, TX, TY, TZ, TW>;
            if (callBack != null)
            {
                callBack(arg1, arg2, arg3, arg4, arg5);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误：事件{0}对应的委托具有不同的类型", eventName));
            }
        }

    }
    #endregion





    #region 公共事件
    /// <summary>
    /// 正在添加监听
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="callBack"></param>
    private static void OnListerAding(EventName eventName, Delegate callBack)
    {
        if (!EventTable.ContainsKey(eventName))
        {
            EventTable.Add(eventName, null);
        }

        Delegate d = EventTable[eventName];
        if (d != null && d.GetType() != callBack.GetType())
        {
            throw new Exception(string.Format("尝试为事件{0}添加不同类型的委托，当前事件所对应的委托是{1}，要添加的委托类型为{2}", eventName, d.GetType(),
                callBack.GetType()));
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="callBack"></param>
    private static void OnlistenerRemoveing(EventName eventName, Delegate callBack)
    {
        //安全校验
        if (EventTable.ContainsKey(eventName))
        {
            Delegate d = EventTable[eventName];
            if (d == null)
            {
                throw new Exception(string.Format("移除监听错误：事件{0}没有对应的委托", eventName));
            }
            else if (d.GetType() != callBack.GetType())
            {
                throw new Exception(string.Format("移除监听错误：尝试为事件{0}移除同类型的委托，当前委托类型为{1}，要移除的类型为{2}", eventName,
                    d.GetType(), callBack.GetType()));
            }
        }
        else
        {
            throw new Exception(string.Format("移除监听错误：没有事件码{0}", eventName));
        }
    }


    /// <summary>
    /// 当委托移除后，对应的事件码也要移除
    /// </summary>
    /// <param name="eventName"></param>
    private static void OnlistenerRemoved(EventName eventName)
    {
        if (EventTable[eventName] == null)
        {
            EventTable.Remove(eventName);
        }
    }
    #endregion

}
