using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;

[AddComponentMenu("SW_Component/提示信息/UI面板始终跟随鼠标（UIFollowMouse）")]
public class UIFollowMouse : MonoBehaviour
{
    [Header("挂载到“显示信息的面板”上：")]
    [Space(10)]

    [Tooltip("UI面板左上角相对鼠标的偏移量")]
    public Vector3 offset = new Vector3(70, -30, 0);
    private Vector3 lastPositin;
    private Vector3 currentPosition;
    
    void Update()
    {
        Vector3 offect = Input.mousePosition - lastPositin;
        lastPositin = Input.mousePosition;
        currentPosition = currentPosition + offect;
        transform.GetComponent<RectTransform>().position = currentPosition + offset;

        //Dictionary<string, string> ssss = new Dictionary<string, string>();
        //if (!ssss.ContainsKey("a"))
        //{
        //    ssss.Add("a", "b");
        //}
        //else
        //{
        //    string hu = ssss["a"];
        //}
        
        ////bool aadas= ssss.ContainsKey("a");
    }
}
