// ========================================================
// 描 述：创建自己常用的物体
// 作 者：SW
// 创建时间：2018/10/17 17:50:01
// 版 本：v 1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateMyGameObject : MonoBehaviour
{
    [MenuItem("GameObject/SW_GameObject/ScriptsGather", false, 30)]
    public static void CreatScriptsGather()
    {
        GameObject go = new GameObject();
        go.name = "ScriptsGather";
        go.transform.position = Vector3.zero;
    }

    [MenuItem("GameObject/SW_GameObject/ScenceGameObjects", false, 31)]
    public static void CreatScenceGameObjects()
    {
        GameObject go = new GameObject();
        go.name = "ScenceGameObjects";
        go.transform.position = Vector3.zero;
    }


    [MenuItem("GameObject/SW_GameObject/Prototypes", false, 32)]
    public static void CreatPrototypes()
    {
        GameObject go = new GameObject();
        go.name = "Prototypes";
        go.transform.position = Vector3.zero;
    }

    [MenuItem("GameObject/SW_GameObject/UIPrototypes", false, 33)]
    public static void creatText()
    {
        GameObject go = new GameObject();
        go.name = "UIPrototypes";
        go.AddComponent<RectTransform>();
        GameObject parent = Selection.activeGameObject;
        if (parent)
        {
            go.transform.parent = parent.transform;
        }
        else
        {
            Transform canvasTransform = GameObject.Find("Canvas").transform;
            if (canvasTransform)
            {
                go.transform.parent = canvasTransform;
            }
        }
        go.transform.localPosition = new Vector3(0, 0, 0);
    }


}
