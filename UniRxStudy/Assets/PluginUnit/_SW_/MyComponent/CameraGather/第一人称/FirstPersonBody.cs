using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("SW_Component/CameraGather/第一人称相机/身体（FirstPersonBody）")]
[RequireComponent(typeof(CharacterController))]
public class FirstPersonBody : MonoBehaviour
{
    [Header("挂载到“第一人称相机的身体”上")]
    [Space(10)]

    #region 变量
    /// </summary>
    ///记录跳跃的初始速度
    /// </summary>
    private float realyspeed;

    /// <summary>
    ///记录跳跃段数
    /// </summary>
    private int realyJumpCount;

    private bool isJumping = false;//是否在空中    

    private Transform[] cameraHead;
    private CharacterController characterController;

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
        cameraHead = this.GetComponentsInChildren<Transform>();
        characterController = this.GetComponent<CharacterController>();
        realyJumpCount = InitializationVariableGather_VG.Instance.firstPersonBody_VG.jumpCount;
    }

    void Update()
    {
        switch (InitializationVariableGather_VG.Instance.firstPersonBody_VG.moveMode)
        {
            case InitializationVariableGather_VG.MoveMode.移动方式一:
                CameraMove1();
                DragingScence();
                ScrollView();
                break;
            case InitializationVariableGather_VG.MoveMode.移动方式二:
                CameraMove2();
                DragingScence();
                ScrollView();
                break;
            case InitializationVariableGather_VG.MoveMode.移动方式三_带重力:
                CameraMove3_Gravity();
                break;
            default:
                break;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            InitializationVariableGather_VG.Instance.firstPersonBody_VG.moveSpeed *= 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            InitializationVariableGather_VG.Instance.firstPersonBody_VG.moveSpeed /= 2;
        }
    }

    /// <summary>
    /// WS前后移动时受方向影响
    /// </summary>
    private void CameraMove1()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //this.transform.Translate(cameraHead[1].transform.forward * Time.deltaTime * InitializationVariableGather_VG.Instance.moveSpeed); //无碰撞
            characterController.Move(cameraHead[1].transform.forward * Time.deltaTime * InitializationVariableGather_VG.Instance.firstPersonBody_VG.moveSpeed);//有碰撞
        }

        if (Input.GetKey(KeyCode.S))
        {
            characterController.Move(cameraHead[1].transform.forward * Time.deltaTime * -InitializationVariableGather_VG.Instance.firstPersonBody_VG.moveSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            characterController.Move(cameraHead[1].transform.right * Time.deltaTime * -InitializationVariableGather_VG.Instance.firstPersonBody_VG.moveSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            characterController.Move(cameraHead[1].transform.right * Time.deltaTime * InitializationVariableGather_VG.Instance.firstPersonBody_VG.moveSpeed);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            characterController.Move(Vector3.up * Time.deltaTime * InitializationVariableGather_VG.Instance.firstPersonBody_VG.moveSpeed);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            characterController.Move(Vector3.down * Time.deltaTime * InitializationVariableGather_VG.Instance.firstPersonBody_VG.moveSpeed);
        }

        //this.GetComponent<SpaceLimition>().SpaceLimitMethod();
    }



    /// <summary>
    /// WS前后移动时不受方向影响
    /// </summary>
    private void CameraMove2()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 foeward = new Vector3(cameraHead[1].transform.forward.x, 0, cameraHead[1].transform.forward.z);
            characterController.Move(foeward * Time.deltaTime * InitializationVariableGather_VG.Instance.firstPersonBody_VG.moveSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector3 foeward = new Vector3(cameraHead[1].transform.forward.x, 0, cameraHead[1].transform.forward.z);
            characterController.Move(foeward * Time.deltaTime * -InitializationVariableGather_VG.Instance.firstPersonBody_VG.moveSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            characterController.Move(cameraHead[1].transform.right * Time.deltaTime * -InitializationVariableGather_VG.Instance.firstPersonBody_VG.moveSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            characterController.Move(cameraHead[1].transform.right * Time.deltaTime * InitializationVariableGather_VG.Instance.firstPersonBody_VG.moveSpeed);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            characterController.Move(Vector3.up * Time.deltaTime * InitializationVariableGather_VG.Instance.firstPersonBody_VG.moveSpeed);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            characterController.Move(Vector3.down * Time.deltaTime * InitializationVariableGather_VG.Instance.firstPersonBody_VG.moveSpeed);
        }
        //this.GetComponent<SpaceLimition>().SpaceLimitMethod();
    }



    /// <summary>
    /// WS前后移动时不受方向影响,受重力影响
    /// </summary>
    private void CameraMove3_Gravity()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 foeward = new Vector3(cameraHead[1].transform.forward.x, 0, cameraHead[1].transform.forward.z);
            characterController.Move(foeward * Time.deltaTime * InitializationVariableGather_VG.Instance.firstPersonBody_VG.moveSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector3 foeward = new Vector3(cameraHead[1].transform.forward.x, 0, cameraHead[1].transform.forward.z);
            characterController.Move(foeward * Time.deltaTime * -InitializationVariableGather_VG.Instance.firstPersonBody_VG.moveSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            characterController.Move(cameraHead[1].transform.right * Time.deltaTime * -InitializationVariableGather_VG.Instance.firstPersonBody_VG.moveSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            characterController.Move(cameraHead[1].transform.right * Time.deltaTime * InitializationVariableGather_VG.Instance.firstPersonBody_VG.moveSpeed);
        }

        Junp();
    }

    /// <summary>
    /// 跳跃(多段跳跃)
    /// </summary>
    private void Junp()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (!isJumping))
        {
            InitializationVariableGather_VG.Instance.firstPersonBody_VG.jumpCount--;
            realyspeed = InitializationVariableGather_VG.Instance.firstPersonBody_VG.jumpSpeed;
        }
        if (InitializationVariableGather_VG.Instance.firstPersonBody_VG.jumpCount > 0)
        {
            characterController.Move(Vector3.up * Time.deltaTime * realyspeed);
            if (characterController.isGrounded)
            {
                realyspeed = -0.001f;
                isJumping = false;
                InitializationVariableGather_VG.Instance.firstPersonBody_VG.jumpCount = realyJumpCount;
            }
            else
            {
                realyspeed -= 20.0f * Time.deltaTime;
            }
        }
        else
        {
            isJumping = true;
            InitializationVariableGather_VG.Instance.firstPersonBody_VG.jumpCount = realyJumpCount;
        }
    }



    /// <summary>
    /// 按住鼠标中键拖动场景移动
    /// </summary>
    private void DragingScence()
    {
        if (Input.GetMouseButtonUp(2))
        {
            isTuodong = false;
        }
        if (Input.GetMouseButton(2))
        {
            newMousePosition = Input.mousePosition;

            if (!isTuodong)
            {
                oldMousePosition = newMousePosition;
                isTuodong = true;
            }
            else
            {
                characterController.Move(cameraHead[1].transform.right * (newMousePosition - oldMousePosition).x * InitializationVariableGather_VG.Instance.firstPersonBody_VG.dragingSpeed / -50);
                characterController.Move(cameraHead[1].transform.up * (newMousePosition - oldMousePosition).y * InitializationVariableGather_VG.Instance.firstPersonBody_VG.dragingSpeed / -50);
            }
            oldMousePosition = newMousePosition;
        }
    }



    /// <summary>
    /// 鼠标滚轮控制视角的远近
    /// </summary>
    private void ScrollView()
    {
        //var a = Input.GetAxis("Mouse ScrollWheel") * InitializationVariableGather_VG.Instance.firstPersonBody_VG.scrollSpeed;
        //characterController.Move(cameraHead[1].transform.forward * a);
    }
}
