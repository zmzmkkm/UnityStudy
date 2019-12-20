// ========================================================
// 描 述：切换场景
// 作 者：SW
// 创建时间：2017/11/07 11:24:42
// 版 本：v 1.0
// ========================================================
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScence : MonoBehaviour
{
    #region 单例模式
    private static ChangeScence _instance;
    public static ChangeScence Instance
    {
        get { return _instance; }
    }
    private void Awake()
    {
        _instance = this;
    }
    #endregion


    /// <summary>
    /// 跳转到主场景
    /// </summary>
    public void MainScence()
    {
        SceneManager.LoadScene("Main");
    }


    /// <summary>
    /// 跳转到配电间场景
    /// </summary>
    public void PeiDianJianScence()
    {
        SceneManager.LoadScene("PeiDianJian");
    }
}
