// ========================================================
// 描 述：改变物体的Sharder
// 作 者：SW
// 创建时间：2017/11/10 20:41:26
// 版 本：v 1.0
// ========================================================
using UnityEngine;
using System.Collections;

public class ChangeSharders : MonoBehaviour
{
    #region SingletonMode
    private static ChangeSharders _instance;
    public static ChangeSharders Instance { get { return _instance; } }
    #endregion
    void Awake()
    {
        _instance = this;
    }


    public GameObject PeiDianJian_MC;
    public GameObject FeiFaChaungRu_Alarm;
    public GameObject GaoFengXian_Alarm;

    Shader touming;
    Shader butouming;

    void Start()
    {
        PeiDianJian_MC.SetActive(false);
        FeiFaChaungRu_Alarm.SetActive(false);
        GaoFengXian_Alarm.SetActive(true);

        touming = Shader.Find("SpritesDiffuse");
        butouming = Shader.Find("MyShaders/DoubleSides/Bumped Diffuse Lighted");
    }

    public void ChangeChangQuTouMing(GameObject gameObject)
    {
        if (gameObject.GetComponent<MeshRenderer>() != null)
        {
            To_Color(gameObject, new Color(1, 1, 1, 0.3f), touming);
        }
        if (gameObject.GetComponent<MeshCollider>() == null)
        {
            Destroy(gameObject.GetComponent<MeshCollider>());
        }
    }


    public void ChangeChangQuBuTouMing(GameObject gameObject)
    {
        if (gameObject.GetComponent<MeshRenderer>() != null)
        {
            To_Color(gameObject, new Color(1, 1, 1, 1), butouming);
        }
        if (gameObject.GetComponent<MeshCollider>() == null)
        {
            gameObject.AddComponent<MeshCollider>();
        }
    }


    public void ChangeMCTouMing_Yellow(GameObject gameObject)
    {
        if (gameObject.GetComponent<MeshRenderer>() != null)
        {
            To_Color(gameObject, new Color(1, 1, 0, 0.5f), touming);
        }
    }


    public void ChangeMCTouMing_Green(GameObject gameObject)
    {
        if (gameObject.GetComponent<MeshRenderer>() != null)
        {
            To_Color(gameObject, new Color(0, 1, 0, 0.5f), touming);
        }
    }


    /// <summary>
    /// 改变物体的透明度
    /// </summary>
    /// <param name="go"></param>
    /// <param name="color"></param>
    /// <param name="shader"></param>
    private void To_Color(GameObject go, Color color, Shader shader)
    {
        for (int y = 0; y < go.GetComponent<MeshRenderer>().materials.Length; y++)
        {
            go.gameObject.GetComponent<MeshRenderer>().materials[y].shader = shader;
            go.gameObject.GetComponent<MeshRenderer>().materials[y].color = color;
        }
    }
}
