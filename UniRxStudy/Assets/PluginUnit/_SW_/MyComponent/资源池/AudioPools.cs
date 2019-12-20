// ========================================================
// 描 述：
// 作 者：SW
// 创建时间：2019/02/15 10:50:42
// 版 本：v 1.0
// ========================================================
// ========================================================
// 描 述：声音源的资源池
// 作 者：SW
// 创建时间：2019/01/04 09:46:45
// 版 本：v 1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Internal;

public class AudioPools : MonoBehaviour
{
    #region SingletonMode
    private static AudioPools _instance;

    public static AudioPools Instance
    {
        get { return _instance; }
    }
    #endregion

    public int Count = 30;//预定义声音源的数量
    private readonly List<GameObject> _audioList = new List<GameObject>();//列表存储实例化的声音源

    private void Awake()
    {
        _instance = this;
        InitPool();
    }

    //初始化资源池
    private void InitPool()
    {
        for (int i = 0; i < Count; i++)
        {
            CreatAudio();
        }
    }

    //实例化一个声音源，加入到列表中，并隐藏
    private GameObject CreatAudio()
    {
        GameObject go = new GameObject("One Audio");
        go.AddComponent(typeof(AudioSource));
        _audioList.Add(go);
        go.transform.SetParent(transform);
        go.SetActive(false);
        return go;
    }

    //返回声音源列表中还没有使用的声音源对象，如果没有的话，则实例化新的声音源
    public GameObject GetAudioSource(AudioClip clip, Vector3 position, [DefaultValue("1.0F")] float volume)
    {
        foreach (GameObject audioGo in _audioList)
        {
            if (!audioGo.activeInHierarchy)
            {
                audioGo.SetActive(true);
                audioGo.transform.position = position;
                AudioSource audioSource = audioGo.GetComponent<AudioSource>();
                audioSource.clip = clip;
                audioSource.spatialBlend = 1f;
                audioSource.volume = volume;
                audioSource.Play();
                StartCoroutine(EndRecycl(audioGo));
                return audioGo;
            }
        }
        return CreatAudio();
    }
    
    //
    //回收声音源到资源池中
    //回收成功返回true，失败返回false
    public bool PutBack(GameObject go)
    {
        if (_audioList.Contains(go))
        {
            go.SetActive(false);
            return true;
        }
        return false;
    }

    /// <summary>
    //
    /// </summary>
    /// <param name="audioGo"></param>
    /// <returns></returns>
    private IEnumerator EndRecycl(GameObject audioGo)
    {
        yield return new WaitForSeconds(audioGo.GetComponent<AudioSource>().clip.length);
        PutBack(audioGo);
    }
}
