// ========================================================
// 描 述：0.3秒销毁自身物体
// 作 者：SW
// 创建时间：2018/10/24 11:29:09
// 版 本：v 1.0
// ========================================================
using System.Collections;
using UnityEngine;

public class SetActiveSelf : MonoBehaviour
{
    public float Timer = 1f;

    void OnEnable()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(Timer);
        this.gameObject.SetActive(false);
    }
}