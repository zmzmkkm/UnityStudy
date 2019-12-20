using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.iOS;

public class WorldMapManager : MonoBehaviour
{
    [SerializeField]
    UnityARCameraManager m_ARCameraManager;

    ARWorldMap m_LoadedMap;
    serializableARWorldMap serializedWorldMap;


    void Start()
    {
        UnityARSessionNativeInterface.ARFrameUpdatedEvent += OnFrameUpdate;
    }

    ARTrackingStateReason m_LastReason;

    void OnFrameUpdate(UnityARCamera arCamera)
    {
        if (arCamera.trackingReason != m_LastReason)
        {
            Application.SetStackTraceLogType(LogType.Log, StackTraceLogType.None);
            Debug.LogFormat("worldTransform: {0}", arCamera.worldTransform.column3);
            Debug.LogFormat("trackingState: {0} {1}", arCamera.trackingState, arCamera.trackingReason);
            m_LastReason = arCamera.trackingReason;
        }
    }

    static UnityARSessionNativeInterface Session
    {
        get { return UnityARSessionNativeInterface.GetARSessionNativeInterface(); }
    }

    static string Path
    {
        get { return System.IO.Path.Combine(Application.persistentDataPath, "myFirstWorldMap.worldmap"); }
    }

    void OnWorldMap(ARWorldMap worldMap)
    {
        if (worldMap != null)
        {
            worldMap.Save(Path);
            Debug.LogFormat("ARWorldMap saved to {0}", Path);
        }
    }

    public void Save()
    {
        Session.GetCurrentWorldMapAsync(OnWorldMap);
    }

    #region 加载ARWorldMap
    /// <summary>
    /// 加载ARWorldMap
    /// </summary>
    public void Load()
    {
        Debug.LogFormat("Loading ARWorldMap {0}", Path);
#if !UNITY_EDITOR
        var worldMap = ARWorldMap.Load(Path);
        if (worldMap != null)
        {
            m_LoadedMap = worldMap;
            Debug.LogFormat("Map loaded. Center: {0} Extent: {1}", worldMap.center, worldMap.extent);

            UnityARSessionNativeInterface.ARSessionShouldAttemptRelocalization = true;

            var config = m_ARCameraManager.sessionConfiguration;
            config.worldMap = worldMap;
            UnityARSessionRunOption runOption = UnityARSessionRunOption.ARSessionRunOptionRemoveExistingAnchors | UnityARSessionRunOption.ARSessionRunOptionResetTracking;

            Debug.Log("Restarting session with worldMap");
            Session.RunWithConfigAndOptions(config, runOption);
        }
#endif
        StartCoroutine(SceneRecogOver());
    }
    /// <summary>
    /// 识别到特征点点确定坐标后加载新的场景
    /// </summary>
    /// <returns></returns>
    private IEnumerator SceneRecogOver()
    {
        yield return null;
        while (m_LastReason != ARTrackingStateReason.ARTrackingStateReasonNone)
        {
            yield return null;
        }
        SceneManager.LoadSceneAsync("Demo07");
    }
    #endregion



    void OnWorldMapSerialized(ARWorldMap worldMap)
    {
        if (worldMap != null)
        {
            //we have an operator that converts a ARWorldMap to a serializableARWorldMap
            serializedWorldMap = worldMap;
            Debug.Log("ARWorldMap serialized to serializableARWorldMap");
        }
    }


    public void SaveSerialized()
    {
        Session.GetCurrentWorldMapAsync(OnWorldMapSerialized);
    }

    public void LoadSerialized()
    {
        Debug.Log("Loading ARWorldMap from serialized data");
        //we have an operator that converts a serializableARWorldMap to a ARWorldMap
        ARWorldMap worldMap = serializedWorldMap;
        if (worldMap != null)
        {
            m_LoadedMap = worldMap;
            Debug.LogFormat("Map loaded. Center: {0} Extent: {1}", worldMap.center, worldMap.extent);

            UnityARSessionNativeInterface.ARSessionShouldAttemptRelocalization = true;

            var config = m_ARCameraManager.sessionConfiguration;
            config.worldMap = worldMap;
            UnityARSessionRunOption runOption = UnityARSessionRunOption.ARSessionRunOptionRemoveExistingAnchors | UnityARSessionRunOption.ARSessionRunOptionResetTracking;

            Debug.Log("Restarting session with worldMap");
            Session.RunWithConfigAndOptions(config, runOption);
        }

    }
}
