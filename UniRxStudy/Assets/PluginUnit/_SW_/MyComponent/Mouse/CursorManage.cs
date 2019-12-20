using UnityEngine;
using System.Collections;


[AddComponentMenu("SW_Component/鼠标指针样式/CursorManage（CursorManage）")]
public class CursorManage : MonoBehaviour
{
    [Header("挂载到“ScriptsGather”上：")]
    [Space(10)]
    #region 单例模式
    private static CursorManage _instance;
    public static CursorManage Instance { get { return _instance; } }
    private void Awake()
    {
        _instance = this;
    }
    #endregion

    /// <summary>
    /// 设置鼠标是中心点为左上角
    /// </summary>
    private Vector2 hotspot = Vector2.zero;

    /// <summary>
    /// 让电脑自己选择是 在硬件还是在软件上选择鼠标的图片
    /// </summary>
    private CursorMode mode = CursorMode.Auto;

    void Start()
    {
        Cursor_Normal();
    }


    public void Cursor_Normal()
    {
        Cursor.SetCursor(InitializationVariableGather_VG.Instance.cursorManage_VG.cursor_normal, hotspot, mode);
    }

    public void Cursor_Hand()
    {
        Cursor.SetCursor(InitializationVariableGather_VG.Instance.cursorManage_VG.cursor_hand, hotspot, mode);
    }

    public void Mei()
    {
        Cursor.SetCursor(InitializationVariableGather_VG.Instance.cursorManage_VG.cursor_attack, hotspot, mode);
    }
}
