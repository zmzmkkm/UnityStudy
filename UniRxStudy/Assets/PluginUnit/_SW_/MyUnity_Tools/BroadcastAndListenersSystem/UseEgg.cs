// ========================================================
// 描 述：
// 作 者：SW
// 创建时间：2019/01/24 14:48:27
// 版 本：v 1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseEgg : MonoBehaviour
{

    void Start()
    {
        //this.GetComponent<Button>().onClick.AddListener(() => EventCenter.BroadListener(EventName.ShowTexzt, "按就是看", 23, 12, true));

        EventCenter.BroadListener(EventName.ShowTexzt, "按就是看", 23, 12.0f, true);
    }
}
