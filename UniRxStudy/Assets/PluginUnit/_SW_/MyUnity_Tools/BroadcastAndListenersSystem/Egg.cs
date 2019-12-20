// ========================================================
// 描 述：
// 作 者：SW
// 创建时间：2019/01/16 10:08:08
// 版 本：v 1.0
// ========================================================

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Egg : MonoBehaviour
{

    void Awake()
    {
        EventCenter.AddListener<string, int, float, bool>(EventName.ShowTexzt, Aaa);
    }


    private void OnDestroy()
    {
        EventCenter.RemoveListener<string, int, float, bool>(EventName.ShowTexzt, Aaa);
    }



    private void Aaa(string str, int a, float b, bool c)
    {
        Debug.Log("asdfasdfasdf");
        this.GetComponent<Text>().text = string.Format("{0}==={1}==={2}==={3}", str, a, b, c);
    }

}
