using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

[AddComponentMenu("SW_Component/CameraGather/定点观察/带阻尼（AroundTheObservation）")]
public class Preview : MonoBehaviour
{
    public Transform target;//目标物体
    [Tooltip("是否启用阻尼")]
    public bool needDamping = true;
    [Tooltip("阻尼系数")]
    public float damping = 5.0f;

    public float xSpeed = 150;//X轴移动速度
    public float ySpeed = 150;//Y轴移动速度
    public float mSpeed = 50;//缩放速度
    public float yMinLimit = 3;//Y轴移动最小角度
    public float yMaxLimit = 90;//Y轴移动最大角度
    public float distance = 130;//初始距离目标体距离
    public float minDistance = 10;//缩放最小距离
    public float maxDistance = 300;//缩放最大距离
    public float x = 50;
    public float y = 25;
    
    void LateUpdate()
    {       
        if (target)
        {
            if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

                y = ClampAngle(y, yMinLimit, yMaxLimit);

            }

            if (Input.GetMouseButton(2))
            {
                float xx = Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                float yy = Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
                //transform.position = Vector3.Lerp(transform.position,new Vector3(xx,yy,transform.position.z), Time.deltaTime * damping);
                transform.Translate(new Vector3(-xx, -yy, 0) * Time.deltaTime * 50);
                //x = transform.position.x;
                //y = transform.position.y;

            }
            
            distance -= Input.GetAxis("Mouse ScrollWheel") * mSpeed;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);

            Quaternion rotation = Quaternion.Euler(y, x, 0.0f);
            Vector3 disVector = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * disVector + target.position;
            //adjust the camera  
            if (needDamping)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * damping);
                transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * damping);
            }
            else
            {
                transform.rotation = rotation;
                transform.position = position;
            }            
        }
    }

    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }

}