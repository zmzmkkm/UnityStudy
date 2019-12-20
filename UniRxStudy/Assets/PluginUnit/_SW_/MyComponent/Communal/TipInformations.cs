// ========================================================
// 描 述：弹出文本框，显示窗口内的详细信息
// 作 者：SW
// 创建时间：2017/11/10 20:41:26
// 版 本：v 1.0
// ========================================================
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class TipInformations : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    private GameObject tip_Panel;



    void Start()
    {
        //tip_Panel = GameObject.Find("ScriptGather").GetComponent<AddTableTitles>().Tip_Panel;
        tip_Panel.SetActive(false);
    }

    /// <summary>
    /// 用弹框显示指定文本框里的文字
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.GetComponent<Text>())
        {
            tip_Panel.SetActive(true);
            string tipText = this.GetComponent<Text>().text;
            tip_Panel.GetComponentInChildren<Text>().text = tipText;
        }
    } 


    /// <summary>
    /// 隐藏弹框
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        tip_Panel.SetActive(false);
    }

   
}
