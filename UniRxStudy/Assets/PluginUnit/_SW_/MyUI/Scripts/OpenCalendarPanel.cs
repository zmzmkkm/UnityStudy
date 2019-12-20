// ========================================================
// 描 述：打开日历面板
// 作 者：SW
// 创建时间：2017/12/12 08:42:15
// 版 本：v 1.0
// ========================================================
using UnityEngine;
using UnityEngine.EventSystems;


[AddComponentMenu("SW_Component/InputField/OpenCalendarPanel（打开日历面板）")]
public class OpenCalendarPanel : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (this.transform.parent.GetComponentsInChildren<Calendar>().Length == 0)
        {
            GameObject go = Instantiate(Resources.Load("SW_MyPrefabs/Calendar", typeof(GameObject))) as GameObject;
            go.name = "Calendar";
            go.transform.parent = this.transform.parent;
            go.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - (this.GetComponent<RectTransform>().sizeDelta.y / 2 + go.GetComponent<RectTransform>().sizeDelta.y / 2), this.transform.position.z);
            go.transform.Find("Title/X_Btn").GetComponent<CloseSelf_Panel>().isDestroy = true;
            Calendar.Instance.InputFieldGameObject = this.gameObject;
        }
    }
}
