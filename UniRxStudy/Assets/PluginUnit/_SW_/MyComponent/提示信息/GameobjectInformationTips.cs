using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[AddComponentMenu("SW_Component/提示信息/鼠标移入显示信息面板（GameobjectInformationTips）")]
public class GameobjectInformationTips : MonoBehaviour
{
    [Header("挂载到“需要显示信息的物体”上：")]
    [Header("具体操作需要打开自行编写更改：")]
    [Space(10)]

    [Tooltip("指定显示哪个信息面板")]
    public GameObject informationImage;

    private void Start()
    {
        informationImage.SetActive(false);
    }

    private void OnMouseOver()
    {
        //打开面板的方式
        if (Input.GetMouseButtonDown(0)&&(Input.GetKey(KeyCode.LeftControl)||(Input.GetKey(KeyCode.RightControl))))
        {
            informationImage.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        informationImage.SetActive(false);
    }
}
