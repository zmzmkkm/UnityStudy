using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("SW_Component/ScriptGather/限制行走范围（SpaceLimition）")]
public class SpaceLimition : MonoBehaviour
{
    [Header("需要在管理移动脚本的Update中添加：")]
    [Header("this.GetComponent<SpaceLimition>().SpaceLimitMethod();")]
    [Space(20)]
    public Transform boxLimit;
    private Vector3 startPosition;
    private Vector3 endtPosition;

    void Start()
    {
        startPosition = boxLimit.position - boxLimit.localScale / 2;
        endtPosition = boxLimit.position + boxLimit.localScale / 2;
    }

    public void SpaceLimitMethod()
    {
        float x = this.transform.position.x;
        x = Mathf.Clamp(x, startPosition.x, endtPosition.x);
        float y = this.transform.position.y;
        y = Mathf.Clamp(y, startPosition.y, endtPosition.y);
        float z = this.transform.position.z;
        z = Mathf.Clamp(z, startPosition.z, endtPosition.z);

        this.transform.position = new Vector3(x, y, z);
    }
}



