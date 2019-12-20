using System;
using UnityEngine;

[AddComponentMenu("SW_Component/CameraGather/定点观察/无阻尼（AroundTheObservation）")]
public class AroundTheObservation : MonoBehaviour
{
    [Header("挂载到“定点旋转观察的相机”上,同时如果")]
    [Header("isSelfSelcetRotationTarget=true,")]
    [Header("则需在目标物体上挂载IsDoubleClick脚本。")]
    [Space(10)]



    [Tooltip("是否可以选择围绕旋转的目标物体")]
    public bool isSelfSelcetRotationTarget;
    /// <summary>
    /// 位置偏移量
    /// </summary>
    private Vector3 offsetPosition;
    //private string thisTag;
    //public ChooseCameraTag chooseCameraTag;

    [Tooltip("围绕旋转的目标物体")]
    public GameObject rotationTarget;
    [Tooltip("相机旋转轴，默认是Y轴")]
    public Vector3 rotationAxis = new Vector3(0, 1, 0);
    [Tooltip("视角与物体的当前距离")]
    public float distance;//向量长度
    [Tooltip("拉近拉远的速度")]
    public float scrollSpeed = 3;
    [Tooltip("旋转观察的速度")]
    public float rotareSpeed = 10;
    public DistanceScope 视距范围 = new DistanceScope();
    public ObserveAngle 观察角度 = new ObserveAngle();



    /// <summary>
    /// 上一帧鼠标所在的位置
    /// </summary>
    private Vector3 oldMousePosition = Vector3.zero;
    /// <summary>
    /// 当前帧鼠标所在的位置
    /// </summary>
    private Vector3 newMousePosition = Vector3.zero;
    private bool isTuodong = false;

    [Serializable]
    public class ObserveAngle
    {
        [Range(-360, 360f)]
        public int min = -360;
        [Range(-360, 360f)]
        public int max = 360;
    }
    [Serializable]
    public class DistanceScope
    {
        public int min = 1;
        public int max = 18;
    }


    void Start()
    {
        transform.LookAt(rotationTarget.transform.position);
        offsetPosition = transform.position - rotationTarget.transform.position;//得到偏移量
        //thisTag = this.gameObject.tag;

        distance = offsetPosition.magnitude;
        distance = Mathf.Clamp(distance, 视距范围.min, 视距范围.max);
        offsetPosition = offsetPosition.normalized * distance;
    }


    void LateUpdate()
    {
        transform.position = offsetPosition + rotationTarget.transform.position;
        //RotateView();
        RotateViewRemote();
        ScrollView();

        if (isSelfSelcetRotationTarget)
        {
            ClickSelectRotationTarget();
        }
    }


    /// <summary>
    /// 处理视野的拉近和拉远效果
    /// </summary>
    void ScrollView()
    {
        //if (chooseCameraTag.cameraTag == thisTag)
        //{
        distance = offsetPosition.magnitude;
        distance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        distance = Mathf.Clamp(distance, 视距范围.min, 视距范围.max);
        offsetPosition = offsetPosition.normalized * distance;
        //}
    }


    /// <summary>
    /// 视角旋转观察
    /// </summary>
    private void RotateView()
    {
        if (Input.GetMouseButton(1)/* && chooseCameraTag.cameraTag == thisTag*/)
        {
            transform.RotateAround(rotationTarget.transform.position, rotationAxis, rotareSpeed * Input.GetAxis("Mouse X"));

            Vector3 originalPos = transform.position;
            Quaternion originalRotation = transform.rotation;

            transform.RotateAround(rotationTarget.transform.position, transform.right, -rotareSpeed * Input.GetAxis("Mouse Y"));
            float x = transform.eulerAngles.x;
            if (x < 观察角度.min || x > 观察角度.max)
            {
                transform.position = originalPos;
                transform.rotation = originalRotation;
            }
        }

        offsetPosition = transform.position - rotationTarget.transform.position;
    }


    /// <summary>
    /// 远程操作下的  ：视角旋转观察
    /// </summary>
    private void RotateViewRemote()
    {
        newMousePosition = Input.mousePosition;

        if (!isTuodong)
        {
            oldMousePosition = newMousePosition;
            isTuodong = true;
        }
        else
        {
            if (Input.GetMouseButton(1)/* && chooseCameraTag.cameraTag == thisTag*/)
            {
                transform.RotateAround(rotationTarget.transform.position, rotationAxis, rotareSpeed * (newMousePosition.x - oldMousePosition.x));

                Vector3 originalPos = transform.position;
                Quaternion originalRotation = transform.rotation;

                transform.RotateAround(rotationTarget.transform.position, transform.right, -rotareSpeed * (newMousePosition.y - oldMousePosition.y));
                float x = transform.eulerAngles.x;
                if (x < 观察角度.min || x > 观察角度.max)
                {
                    transform.position = originalPos;
                    transform.rotation = originalRotation;
                }
            }

            offsetPosition = transform.position - rotationTarget.transform.position;
        }
        oldMousePosition = newMousePosition;
    }


    /// <summary>
    /// 点击选择围绕旋转的目标物体
    /// </summary>
    private void ClickSelectRotationTarget()
    {
        Ray ray = this.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.GetComponent<IsDoubleClick>() != null)
            {
                if (hit.collider.gameObject.GetComponent<IsDoubleClick>().isDoubleClickEnd)
                {
                    //Debug.Log(hit.collider.name);
                    rotationTarget = hit.collider.gameObject;
                }
            }
        }
    }
}