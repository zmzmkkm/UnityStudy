using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.iOS;

public class SetWorldOriginControl : MonoBehaviour
{

    public GameObject HitCube;
    public Text PositionText;
    public Text RotationText;

    void Update()
    {
        PositionText.text = "Camera position=" + HitCube.transform.position.ToString();
        RotationText.text = "Camera rotation=" + HitCube.transform.rotation.ToString();
    }

    public void SetWorldOrigin()
    {
        UnityARSessionNativeInterface.GetARSessionNativeInterface().SetWorldOrigin(HitCube.transform);
    }
}
