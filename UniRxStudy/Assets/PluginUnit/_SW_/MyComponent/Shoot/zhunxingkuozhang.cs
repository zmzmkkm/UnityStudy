// ========================================================
// 描 述：
// 作 者：SW
// 创建时间：2019/02/15 10:54:14
// 版 本：v 1.0
// ========================================================
// ========================================================
// 描 述：准星变色及扩大
// 作 者：SW
// 创建时间：2018/11/19 12:21:01
// 版 本：v 1.0
// ========================================================
/*========================================================
* 描 述：准星扩张
* 作 者：deskerkimq
* 创建时间：2018/11/17 16:03:21
========================================================*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zhunxingkuozhang : MonoBehaviour
{
    public Transform Up;
    public Transform Down;
    public Transform Left;
    public Transform Right;
    public float Aaaa = 0f;

    public Sprite Zhengchang;
    public Sprite Sheji;


    /// <summary>
    /// 按键按下时准星扩大
    /// </summary>
    /// <param name="go"></param>
    public void FrontSight_Expand()
    {
        //Up.localPosition = new Vector3(0, 35 + Aaaa, 0);
        //Down.localPosition = new Vector3(0, -35 - Aaaa, 0);
        //Left.localPosition = new Vector3(-35 - Aaaa, 0, 0);
        //Right.localPosition = new Vector3(35 + Aaaa, 0, 0);

        this.GetComponent<Image>().sprite = Sheji;
    }

    //
    /// <summary>
    /// 按键抬起时准星恢复原状
    /// </summary>
    /// <param name="go"></param>
    public void FrontSight_Restore()
    {
        //Up.localPosition = new Vector3(0, 35, 0);
        //Down.localPosition = new Vector3(0, -35, 0);
        //Left.localPosition = new Vector3(-35, 0, 0);
        //Right.localPosition = new Vector3(35, 0, 0);

        this.GetComponent<Image>().sprite = Zhengchang;
    }


    /// <summary>
    /// 使准星的颜色变为红色
    /// </summary>
    public void ChangeColorRed()
    {
        Up.GetComponent<Image>().color = Color.red;
        Down.GetComponent<Image>().color = Color.red;
        Left.GetComponent<Image>().color = Color.red;
        Right.GetComponent<Image>().color = Color.red;
    }


    /// <summary>
    /// 使准星的颜色变为白色
    /// </summary>
    public void ChangeColorWrite()
    {
        //Up.GetComponent<Image>().color = new Color(0.4186788f, 0, 1, 1);
        //Down.GetComponent<Image>().color = new Color(0.4186788f, 0, 1, 1);
        //Left.GetComponent<Image>().color = new Color(0.4186788f, 0, 1, 1);
        //Right.GetComponent<Image>().color = new Color(0.4186788f, 0, 1, 1);

        Up.GetComponent<Image>().color = Color.red;
        Down.GetComponent<Image>().color = Color.red;
        Left.GetComponent<Image>().color = Color.red;
        Right.GetComponent<Image>().color = Color.red;
    }
}
