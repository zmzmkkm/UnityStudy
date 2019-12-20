using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;

[AddComponentMenu("SW_Component/场景切换/异步加载进度条（UIProgressBar）")]
public class UIProgressBar : MonoBehaviour
{
    #region 单利模式
    private static UIProgressBar _instance;
    public static UIProgressBar Instance { get { return _instance; } }
    private void Awake()
    {
        _instance = this;
    }
    #endregion

    [Header("挂载到“ScriptGather”上：")]
    [Space(10)]

    [Tooltip("切换场景的进度条")]
    public Slider progressSlider;
    [Tooltip("进度条进度显示文字 ")]
    public Text ProgressSliderText;
    private int nowProcess;//当前加载进度  
    private AsyncOperation async;

    #region 固定不动
    void Start()
    {
        progressSlider.gameObject.SetActive(false);
        ProgressSliderText.gameObject.SetActive(false);
    }


    void Update()
    {
        if (async == null)
        {
            return;
        }

        int toProcess;
        // async.progress 你正在读取的场景的进度值  0---0.9      
        // 如果当前的进度小于0.9，说明它还没有加载完成，就说明进度条还需要移动      
        // 如果，场景的数据加载完毕，async.progress 的值就会等于0.9    
        if (async.progress < 0.9f)
        {
            toProcess = (int)async.progress * 100;
        }
        else
        {
            toProcess = 100;
        }
        // 如果滑动条的当前进度，小于，当前加载场景的方法返回的进度     
        if (nowProcess < toProcess)
        {
            nowProcess++;
        }

        progressSlider.value = nowProcess / 100f;
        //设置progressText进度显示  
        ProgressSliderText.text = progressSlider.value * 100 + "%";
        // 设置为true的时候，如果场景数据加载完毕，就可以自动跳转场景     
        if (nowProcess == 100)
        {
            async.allowSceneActivation = true;
        }
    }


    /// <summary>
    /// 异步加载scene  
    /// </summary>
    /// <param name="sceneId">要加载场景的id</param>
    /// <returns></returns>
    IEnumerator LoadScene(int sceneId)
    {
        //async = Application.LoadLevelAsync(sceneId);
        async = SceneManager.LoadSceneAsync(sceneId);
        
        async.allowSceneActivation = false;
        yield return async;
    }
    #endregion

    /// <summary>
    /// 外部调用的加载的方法  
    /// </summary>
    /// <param name="id">要加载场景的id</param> 
    public void ShowProgressBar(int id)
    {
        progressSlider.gameObject.SetActive(true);
        ProgressSliderText.gameObject.SetActive(true);
        StartCoroutine("LoadScene", id);
    }
}
