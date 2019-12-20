using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[AddComponentMenu("SW_Component/场景切换/加载场景（LoadScence）")]
[RequireComponent(typeof(UIProgressBar))]
public class LoadScence : MonoBehaviour
{
    public enum LoadMethod
    {
        按任意键加载,
        按键盘上的键加载,
        点击按钮加载,
    }
     
    public enum LoadMode
    {
        直接加载,
        进度条加载,
        变色加载,
    }

    [Header("挂载到“ScriptGather”上：")]
    [Space(10)]

    [Tooltip("加载场景的模式")]
    public LoadMode loadMode = LoadMode.直接加载;
    [Tooltip("加载场景的方法")]
    public LoadMethod loadMethod = LoadMethod.按任意键加载;
    [Tooltip("需要加载场景的id")]
    public int scenceID = 1;
    [Tooltip("加载场景的案件")]
    public KeyCode loadScenceKey;
    [Tooltip("加载场景的Btn按钮")]
    public Button loadBtn;


    private bool isLoading = false;

    private void Start()
    {
        if (loadMethod == LoadMethod.点击按钮加载)
        {
            Add_LoadScence_BtnEvent(loadBtn);
        }
    }

    private void Update()
    {
        if (!isLoading)
        {
            switch (loadMethod)
            {
                case LoadMethod.按任意键加载:
                    if (Input.anyKey)
                    {
                        LoadScenceMethod();
                    }
                    break;
                case LoadMethod.按键盘上的键加载:
                    if (Input.GetKeyDown(loadScenceKey))
                    {
                        LoadScenceMethod();
                    }
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// 监测点击UI上Btn出发LoadScenceMethod()事件
    /// </summary>
    /// <param name="btn">指定监测的Btn按钮</param>
    public void Add_LoadScence_BtnEvent(Button btn)
    {
        btn.onClick.AddListener(delegate ()
        {
            LoadScenceMethod();
        });
    }

    /// <summary>
    /// 用来加载场景的方法
    /// </summary>
    public void LoadScenceMethod()
    {
        isLoading = true;
        switch (loadMode)
        {
            case LoadMode.直接加载:
                SceneManager.LoadScene(scenceID);
                break;
            case LoadMode.进度条加载:
                UIProgressBar.Instance.ShowProgressBar(scenceID);
                break;
            case LoadMode.变色加载:
                //todo:添加变色加载场的方法
                break;
            default:
                break;
        }
        if (loadBtn!=null)
        {
            loadBtn.interactable = false; 
        } 
    }
}