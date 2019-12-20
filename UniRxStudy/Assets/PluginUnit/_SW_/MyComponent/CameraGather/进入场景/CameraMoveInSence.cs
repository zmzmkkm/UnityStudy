using UnityEngine;
using System.Collections;
[AddComponentMenu("SW_Component/CameraGather/进入场景（CameraMoveInSence）")]
public class CameraMoveInSence : MonoBehaviour
{
    [Header("挂载到“进入场景的相机”上")]
    [Space(10)]

    [Tooltip("相机进入场景的速度")]
    public float speed = 10;

    [Tooltip("相机最后停到 什么位置")]
    public float endZ = -4.9f;

    void Update()
    {
        if (Camera.main.transform.position.z < endZ)
        {
            #region 相机漫游由远及近
            Camera.main.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            #endregion
        }
    }
}
