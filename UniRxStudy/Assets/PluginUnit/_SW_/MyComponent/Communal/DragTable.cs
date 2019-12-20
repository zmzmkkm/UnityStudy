// ========================================================
// 描 述：拖拽面板
// 作 者：SW
// 创建时间：2017/11/10 20:41:26
// 版 本：v 1.0
// ========================================================
using UnityEngine;
using UnityEngine.EventSystems;

public class DragTable : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    private Transform DragTargetTable;

    private GameObject canvas;
    private Vector3[] corners;
    private Vector3 screenSpace = Vector3.zero;
    private Vector3 offset;


    void Start()
    {
        canvas = GameObject.Find("Canvas");
        DragTargetTable = this.transform.parent;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        //获取屏幕的四角的坐标
        corners = new Vector3[4];
        canvas.GetComponent<RectTransform>().GetWorldCorners(corners);
        offset = DragTargetTable.position - Input.mousePosition;
    }


    public void OnDrag(PointerEventData eventData)
    {
        Vector3 curScreenSpace = new Vector3(Mathf.Clamp(Input.mousePosition.x, corners[0].x + 10, corners[2].x - 10), Mathf.Clamp(Input.mousePosition.y, corners[0].y + 10, corners[1].y - 10), screenSpace.z);
        Vector3 curPosition = curScreenSpace + offset;
        DragTargetTable.position = curPosition;
    }
}
