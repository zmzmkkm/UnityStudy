using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[AddComponentMenu("SW_Component/ScriptGather/文本自适应（TextSelfChange）")]
public class TextSelfChange : MonoBehaviour
{
    [Header("挂载到“需要自适应的Text”上：")]
    [Space(10)]

    [Tooltip("目标文本")]
    public Text t;
    [Tooltip("背景图片")]
    public Image image;
    [Tooltip("文本最小长度")]
    public float minlength;
    [Tooltip("文本最大长度")]
    public float targetlength;//希望的目标最大长度
    private float sx, sy;
    private float sxOffset, syOffset;

    void Start()
    {
        sxOffset = image.rectTransform.sizeDelta.x - t.rectTransform.sizeDelta.x;
        syOffset = image.rectTransform.sizeDelta.y - t.rectTransform.sizeDelta.y;
        sx = minlength;
    }

    void Update()
    {
        sy = t.preferredHeight;
        //t.preferredHeight  文字的高度
        //t.preferredWidth   文字的宽度
        //t.rectTransform.sizeDelta.x  文本框当前的宽度

        // 文本框当前的宽度  小于 目标宽度  就拉长
        if (t.rectTransform.sizeDelta.x <= targetlength && t.preferredWidth >= minlength)
        {
            sx = t.preferredWidth;
        }


        //文字的宽度  小于   文本框当前的宽度   就缩短
        if (t.preferredWidth < t.rectTransform.sizeDelta.x)
        {
            if (t.preferredWidth >= minlength)
            {
                sx = t.preferredWidth;
            }
            else
            {
                sx = minlength;
            }
        }

        t.rectTransform.sizeDelta = new Vector2(sx, sy);
        image.rectTransform.sizeDelta = new Vector2(sx + sxOffset, sy + syOffset);
    }
}
