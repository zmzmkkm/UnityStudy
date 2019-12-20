// ========================================================
// 描 述：
// 作 者：SW
// 创建时间：2019/02/15 11:27:11
// 版 本：v 1.0
// ========================================================
// ========================================================
// 描 述：
// 作 者：SW
// 创建时间：2018/10/26 17:56:21
// 版 本：v 1.0
// ========================================================
// ========================================================
// 描 述：设置世界中心点
// 作 者：SW
// 创建时间：2018/10/16 09:24:24
// 版 本：v 1.0
// ========================================================
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.iOS;

public class SetWordCenter : MonoBehaviour
{
    public Button setWord_Btn;
    public Camera MaiCamera;


    void Start()
    {
        setWord_Btn.onClick.AddListener(OnBtnClick);
    }

    public void OnBtnClick()
    {
        UnityARSessionNativeInterface.GetARSessionNativeInterface().SetWorldOrigin(MaiCamera.transform);//获取Session，并设置世界的中心点
    }
}
