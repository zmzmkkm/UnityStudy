using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


[AddComponentMenu("SW_Component/鼠标指针样式/鼠标在物体上的样式（MouseChange）")]
public class MouseChange : MonoBehaviour
{
    void OnMouseEnter()
    {
        CursorManage.Instance.Cursor_Hand();
    }

    void OnMouseExit()
    {
        CursorManage.Instance.Cursor_Normal();
    }
}
