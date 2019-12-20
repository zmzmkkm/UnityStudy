using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 全局变量与常量初始化
/// </summary>
public class GV_GlobalVariables
{
    #region 单利模式
    private static GV_GlobalVariables _instance;
    public static GV_GlobalVariables Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        _instance = this;
    }
    #endregion

    #region 变量初始化
    /// <summary>
    /// 来开始定义您的第一个变量吧！！！
    /// </summary>
    public int a=10;


    #endregion


    #region 常量初始化
    /// <summary>
    /// 来开始定义您的第一个常量吧！！！
    /// </summary>
    public const int b = 10;

    #endregion
}