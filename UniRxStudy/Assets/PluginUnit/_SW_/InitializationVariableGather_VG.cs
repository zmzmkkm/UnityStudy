using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

[AddComponentMenu("SW_Component/全局变量（InitializationVariableGather）")]
public class InitializationVariableGather_VG : MonoBehaviour
{
    [Header("挂载到“ScriptGather”上")]
    [Space(10)]
    #region SingletonMode
    private static InitializationVariableGather_VG _instance ;
    public static InitializationVariableGather_VG Instance { get { return _instance; } }
    //private InitializationVariableGather_VG() { }
    private void Awake()
    {
        _instance = this;
    }
    #endregion


    #region  FirstPersonBody
    /// <summary>
    /// 行走方式列表
    /// </summary>
    public enum MoveMode
    {
        移动方式一,
        移动方式二,
        移动方式三_带重力
    }

    [Header("第一人称身体")]
    public FirstPersonBody_VG firstPersonBody_VG = new FirstPersonBody_VG();

    [Serializable]
    public class FirstPersonBody_VG
    {
        [Tooltip("行走方式")]
        public MoveMode moveMode = MoveMode.移动方式一;

        [Range(0f, 200f)]
        [Tooltip("行走速度")]
        public float moveSpeed = 4f;

        [Range(0f, 50f)]
        [Tooltip("跳跃的初始速度")]
        public float jumpSpeed = 8f;

        [Tooltip("几段跳？")]
        public int jumpCount = 2;

        [Range(0f, 50f)]
        [Tooltip("鼠标中键拖动场景的速度")]
        public float dragingSpeed = 2f;

        [Range(0f, 50f)]
        [Tooltip("拉近拉远的速度度")]
        public float scrollSpeed = 3;
    }
    #endregion


    #region  FirstPersonHead
    /// <summary>
    /// 鼠标锁定方式
    /// </summary>
    public enum LockMouseMode
    {
        按键盘上的键锁定,
        点击Btn锁定,
        按键与Btn锁定
    }

    [Header("第一人称身头部")]
    public FirstPersonHead_VG firstPersonHead_VG = new FirstPersonHead_VG();

    [Serializable]
    public class FirstPersonHead_VG
    {
        [Range(0f, 20f)]
        [Tooltip("鼠标在X方向的灵敏度")]
        public float sensitivityX = 2F;

        [Range(0f, 20f)]
        [Tooltip("鼠标在Y方向的灵敏度")]
        public float sensitivityY = 2F;

        [Range(-90f, 00f)]
        [Tooltip("Y轴上最小视角")]
        public float minimumY = -60F;

        [Range(0f, 90f)]
        [Tooltip("Y轴上最大视角")]
        public float maximumY = 60F;

        [Tooltip("是否需要远程操作")]
        public bool isRemoteOperation = false;

        [Header("以一下参数是不需要远程操作时设置:")]
        [Header("使鼠标定在屏幕中心")]
        [Space(10)]
        [Tooltip("锁定鼠标的方法")]
        public LockMouseMode lockMouseMode = LockMouseMode.按键盘上的键锁定;

        [Tooltip("锁定鼠标的按键")]
        public KeyCode lockMouseKey = KeyCode.L;

        [Tooltip("锁定鼠标的Btn")]
        public Button lockMouseBtn;

        [Tooltip("鼠标中心点图片")]
        public Image mouseImage;
    }
    #endregion


    #region  CameraMoveInSence
    [Header("进入场景相机")]
    public CameraMoveInSence_VG cameraMoveInSence_VG = new CameraMoveInSence_VG();

    [Serializable]
    public class CameraMoveInSence_VG
    {
        [Tooltip("相机进入场景的速度")]
        public float speed = 10;

        [Tooltip("相机最后停到 什么位置")]
        public float endZ = -4.9f;
    }
    #endregion


    #region  CursorManage
    [Header("鼠标样式")]
    public CursorManage_VG cursorManage_VG = new CursorManage_VG();

    [Serializable]
    public class CursorManage_VG
    {
        [Header("将鼠标图片拖到下面的Texture2D中")]
        [Tooltip("鼠标样式：箭头")]
        public Texture2D cursor_normal;

        [Tooltip("鼠标样式：手")]
        public Texture2D cursor_hand;

        [Tooltip("鼠标样式：other")]
        public Texture2D cursor_attack;
    }
    #endregion









    #region  aaa
    [Header("aaa")]
    public aaa_VG aaaa_VG = new aaa_VG();

    [Serializable]
    public class aaa_VG
    {

    }
    #endregion
}