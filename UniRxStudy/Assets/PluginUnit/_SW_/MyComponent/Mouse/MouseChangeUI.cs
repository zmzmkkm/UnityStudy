using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[AddComponentMenu("SW_Component/鼠标指针样式/鼠标在UI上的样式（MouseChangeUI）")]
public class MouseChangeUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        CursorManage.Instance.Cursor_Hand();
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        CursorManage.Instance.Cursor_Normal();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        CursorManage.Instance.Cursor_Normal();
    }
}
