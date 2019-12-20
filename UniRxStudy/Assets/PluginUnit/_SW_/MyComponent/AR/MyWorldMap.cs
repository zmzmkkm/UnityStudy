// ========================================================
// 描 述：
// 作 者：SW
// 创建时间：2019/02/15 11:27:11
// 版 本：v 1.0
// ========================================================
// ========================================================
// 描 述：
// 作 者：SW
// 创建时间：2018/10/31 17:45:02
// 版 本：v 1.0
// ========================================================

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.iOS;

public class MyWorldMap : MonoBehaviour
{
    public ARWorldMap m_arWorldMap;
    public UnityARCameraManager m_ARCameraManager;


    public Text Text01;
    public Button SaveButton;
    public Button LoadButton;
    void Start()
    {
        SaveButton.onClick.AddListener(OnSaveClick);
        LoadButton.onClick.AddListener(OnLoadClick);

        UnityARSessionNativeInterface.ARFrameUpdatedEvent += OnWorldStatusChange;
    }


    void OnWorldStatusChange(UnityARCamera myArCamera)
    {
        if (myArCamera.worldMappingStatus == ARWorldMappingStatus.ARWorldMappingStatusMapped)
        {
            Config.m_Swssion.GetCurrentWorldMapAsync(OnWorldMap);
        }
        else
        {
            Text01.text = myArCamera.worldMappingStatus.ToString();
        }
    }


    void OnWorldMap(ARWorldMap arWorldMap)
    {
        m_arWorldMap = arWorldMap;
        Text01.text = "已存在";
    }

    private void OnSaveClick()
    {
        if (m_arWorldMap != null)
        {
            m_arWorldMap.Save(Config.path);
        }
    }

    private void OnLoadClick()
    {
        UnityARSessionNativeInterface.ARSessionShouldAttemptRelocalization = true;//重定位

        ARWorldMap newWorldMap = ARWorldMap.Load(Config.path);
        ARKitWorldTrackingSessionConfiguration configration = m_ARCameraManager.sessionConfiguration;
        configration.worldMap = newWorldMap;
        UnityARSessionRunOption option = UnityARSessionRunOption.ARSessionRunOptionRemoveExistingAnchors | UnityARSessionRunOption.ARSessionRunOptionResetTracking;
        Config.m_Swssion.RunWithConfigAndOptions(configration, option);
    }



    public GameObject model;
    public Button MaoDianButton;
    private HashSet<string> m_Clones;

    void Awake()
    {
        MaoDianButton.onClick.AddListener(OnMaoDianButtonClick);
        m_Clones = new HashSet<string>();
    }

    private void OnMaoDianButtonClick()
    {
        foreach (string id in m_Clones)
        {
            UnityARSessionNativeInterface.GetARSessionNativeInterface().RemoveUserAnchor(id);
        }

        if (model.GetComponent<UnityARUserAnchorComponent>() == null)
        {
            model.AddComponent<UnityARUserAnchorComponent>();
        }
        UnityARUserAnchorComponent component = model.GetComponent<UnityARUserAnchorComponent>();

        m_Clones.Add(component.AnchorId);
    }
}
