// ========================================================
// 描 述：
// 作 者：SW
// 创建时间：2019/02/15 11:27:11
// 版 本：v 1.0
// ========================================================
// ========================================================
// 描 述：
// 作 者：SW
// 创建时间：2018/10/31 17:44:39
// 版 本：v 1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.XR.iOS;

public class Config : MonoBehaviour
{
    public static UnityARSessionNativeInterface m_Swssion
    {
        get { return UnityARSessionNativeInterface.GetARSessionNativeInterface(); }
    }


    public static string path
    {
        get { return Path.Combine(Application.persistentDataPath, "worldMap.worldMap"); }
    }
}
