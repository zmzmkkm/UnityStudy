// ========================================================
// 描 述：关闭面板自身
// 作 者：SW
// 创建时间：2017/11/07 11:50:50
// 版 本：v 1.0
// ========================================================
using UnityEngine;
using UnityEngine.UI;

public class CloseSelf_Panel : MonoBehaviour
{
    public bool isDestroy = false;

    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(() => CloseSelfPanelMethod());
    }

    private void CloseSelfPanelMethod()
    {
        if (isDestroy)
        {
            Destroy(this.transform.parent.parent.gameObject);
        }
        else
        {
            this.transform.parent.parent.gameObject.SetActive(false);
        }
    }
}
