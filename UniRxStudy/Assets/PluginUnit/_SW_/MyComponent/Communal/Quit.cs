// ========================================================
// 描 述：退出程序
// 作 者：SW
// 创建时间：2017/11/10 20:41:26
// 版 本：v 1.0
// ========================================================
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void QuitMethod()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
//执行退出命令
        		Application.Quit();
#endif
    }
}
