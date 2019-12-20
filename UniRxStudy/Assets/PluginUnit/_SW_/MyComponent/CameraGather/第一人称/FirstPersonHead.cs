using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[AddComponentMenu("SW_Component/CameraGather/第一人称相机/头部（FirstPersonHead）")]
public class FirstPersonHead : MonoBehaviour
{
    [Header("挂载到“第一人称相机的头部”上")]
    [Space(10)]


    #region  变量
    /// <summary>
    /// X方向旋转度数
    /// </summary>
    private float rotationX = 0f;

    /// <summary>
    /// Y方向旋转度数
    /// </summary>
    private float rotationY = 0f;

    private bool isMouseLock = false;

    /// <summary>
    /// 上一帧鼠标所在的位置
    /// </summary>
    private Vector3 oldMousePosition = Vector3.zero;

    /// <summary>
    /// 当前帧鼠标所在的位置
    /// </summary>
    private Vector3 newMousePosition = Vector3.zero;

    private bool isTuodong = false;
    #endregion



    void Start()
    {
        InitializationVariableGather_VG.Instance.firstPersonHead_VG.mouseImage.enabled = false;
        if (InitializationVariableGather_VG.Instance.firstPersonHead_VG.lockMouseMode == InitializationVariableGather_VG.LockMouseMode.点击Btn锁定 || InitializationVariableGather_VG.Instance.firstPersonHead_VG.lockMouseMode == InitializationVariableGather_VG.LockMouseMode.按键与Btn锁定)
        {
            Add_LockMouse_BtnEvent(InitializationVariableGather_VG.Instance.firstPersonHead_VG.lockMouseBtn);
        }
    }

    void Update()
    {
        if (isMouseLock)
        {
            if (InitializationVariableGather_VG.Instance.firstPersonHead_VG.isRemoteOperation)
            {
                MouseFreedomObserveRemote();
            }
            else
            {
                MouseFreedomObserve();
            }
        }
        else
        {
            //!EventSystem.current.IsPointerOverGameObject() : 判断鼠标是否在Ui层上
            if (Input.GetMouseButton(0)/*&&MouseInWhatGameObject.Instance.isNotInMeiduiPanel*/&& !EventSystem.current.IsPointerOverGameObject())
            {
                if (InitializationVariableGather_VG.Instance.firstPersonHead_VG.isRemoteOperation)
                {
                    MouseFreedomObserveRemote();
                }
                else
                {
                    MouseFreedomObserve();
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                isTuodong = false;
            }
        }

        Add_LockMouse_KeyEvent();
    }

    /// <summary>
    /// 视角跟谁鼠标自由观察
    /// </summary>
    private void MouseFreedomObserve()
    {
        //根据鼠标移动的快慢(增量), 获得相机上下旋转的角度(处理Y)
        rotationY += Input.GetAxis("Mouse Y") * InitializationVariableGather_VG.Instance.firstPersonHead_VG.sensitivityY;
        //rotationY= 
        //角度限制. rotationY小于min,返回min. 大于max,返回max. 否则返回value 
        rotationY = Mathf.Clamp(rotationY, InitializationVariableGather_VG.Instance.firstPersonHead_VG.minimumY, InitializationVariableGather_VG.Instance.firstPersonHead_VG.maximumY);
        //根据鼠标移动的快慢(增量), 获得相机左右旋转的角度(处理X)
        rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * InitializationVariableGather_VG.Instance.firstPersonHead_VG.sensitivityX;

        //总体设置一下相机角度
        this.transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }

    /// <summary>
    /// 远程操作下的  ：视角跟谁鼠标自由观察
    /// </summary>
    private void MouseFreedomObserveRemote()
    {

        newMousePosition = Input.mousePosition;

        if (!isTuodong)
        {
            oldMousePosition = newMousePosition;
            isTuodong = true;
        }
        else
        {
            //根据鼠标移动的快慢(增量), 获得相机上下旋转的角度(处理Y)
            rotationY += (newMousePosition.y - oldMousePosition.y) * InitializationVariableGather_VG.Instance.firstPersonHead_VG.sensitivityY;
            //角度限制. rotationY小于min,返回min. 大于max,返回max. 否则返回value 
            rotationY = Mathf.Clamp(rotationY, InitializationVariableGather_VG.Instance.firstPersonHead_VG.minimumY, InitializationVariableGather_VG.Instance.firstPersonHead_VG.maximumY);
            //根据鼠标移动的快慢(增量), 获得相机左右旋转的角度(处理X)
            rotationX = transform.localEulerAngles.y + (newMousePosition.x - oldMousePosition.x) * InitializationVariableGather_VG.Instance.firstPersonHead_VG.sensitivityX;
            //总体设置一下相机角度
            this.transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        oldMousePosition = newMousePosition;
    }


    /// <summary>
    /// 按下键盘按键时显示与隐藏鼠标
    /// </summary>
    public void Add_LockMouse_KeyEvent()
    {
        //按键情况下的鼠标锁定
        if (InitializationVariableGather_VG.Instance.firstPersonHead_VG.lockMouseMode == InitializationVariableGather_VG.LockMouseMode.按键盘上的键锁定 || InitializationVariableGather_VG.Instance.firstPersonHead_VG.lockMouseMode == InitializationVariableGather_VG.LockMouseMode.按键与Btn锁定)
        {
            if (Input.GetKeyDown(InitializationVariableGather_VG.Instance.firstPersonHead_VG.lockMouseKey))
            {
                if (!isMouseLock)
                {
                    MouseLockAndHide();
                    isMouseLock = true;
                }
                else
                {
                    MouseUnlockAndShow();
                    isMouseLock = false;
                }
            }
        }

        //解锁鼠标的锁定
        switch (InitializationVariableGather_VG.Instance.firstPersonHead_VG.lockMouseMode)
        {
            case InitializationVariableGather_VG.LockMouseMode.按键盘上的键锁定:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    MouseUnlockAndShow();
                    isMouseLock = false;
                }
                break;
            case InitializationVariableGather_VG.LockMouseMode.点击Btn锁定:
                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(InitializationVariableGather_VG.Instance.firstPersonHead_VG.lockMouseKey))
                {
                    MouseUnlockAndShow();
                    isMouseLock = false;
                }
                break;
            case InitializationVariableGather_VG.LockMouseMode.按键与Btn锁定:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    MouseUnlockAndShow();
                    isMouseLock = false;
                }
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 按下Btn时显示与隐藏鼠标
    /// </summary>
    /// <param name="btn">控制显示与隐藏鼠标是Btn</param>
    public void Add_LockMouse_BtnEvent(Button btn)
    {
        btn.onClick.AddListener(delegate ()
        {
            if (!isMouseLock)
            {
                MouseLockAndHide();
                isMouseLock = true;
            }
        });

    }

    /// <summary>
    /// 锁定并隐藏鼠标
    /// </summary>
    private void MouseLockAndHide()
    {
        //锁定鼠标在屏幕中心点
        //Screen.lockCursor = true;
        Cursor.lockState = CursorLockMode.Locked;

        //以藏鼠标
        Cursor.visible = false;
        InitializationVariableGather_VG.Instance.firstPersonHead_VG.mouseImage.enabled = true;
    }

    /// <summary>
    /// 解除鼠标锁定并显示
    /// </summary>
    private void MouseUnlockAndShow()
    {
        //解除鼠标锁定
        //Screen.lockCursor = false;
        Cursor.lockState = CursorLockMode.None;
        //显示鼠标
        Cursor.visible = true;
        InitializationVariableGather_VG.Instance.firstPersonHead_VG.mouseImage.enabled = false;
    }
}
