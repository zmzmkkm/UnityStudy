using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("SW_Component/ScriptGather/鼠标双击（IsDoubleClick）")]
public class IsDoubleClick : MonoBehaviour
{
    [HideInInspector]
    /// <summary>
    /// 判断是否双击了鼠标
    /// </summary>
    public bool isDoubleClickEnd = false;

    private float time = 0;
    private int count = 0;

    #region  双击模型执行事件
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            count++;
            if (count == 1)
            {
                time = Time.time;
            }
            if (count == 2 && Time.time - time <= 0.3f)
            {
                isDoubleClickEnd = true;
                count = 0;
            }
            if (Time.time - time > 0.3f)
            {
                time = 0;
                count = 0;
                isDoubleClickEnd = false;
            }
        }
    }


    void OnMouseExit()
    {
        time = 0;
        count = 0;
        isDoubleClickEnd = false;
    }
    #endregion
}