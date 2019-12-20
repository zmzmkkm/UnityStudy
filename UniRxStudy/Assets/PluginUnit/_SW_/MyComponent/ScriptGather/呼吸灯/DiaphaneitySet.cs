using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[AddComponentMenu("SW_Component/ScriptGather/呼吸灯（DiaphaneitySet）")]
public class DiaphaneitySet : MonoBehaviour
{
    public enum Type
    {
        单向播放模式,
        呼吸灯模式
    }

    public enum UiComponent
    {
        Image组件,
        Text组件
    }


    [Header("挂载到“需要呼吸灯效果的UI上”上：")]
    [Space(10)]

    [Range(0.001f, 1f)]
    public float from = 0.001f;
    [Range(0.001f, 1f)]
    public float to = 1f;
    [Tooltip("选择哪种动画模式")]
    public Type type = Type.单向播放模式;
    [Header("一些其他的属性：")]
    [Tooltip("单向动画播放时间")]
    public float delayTime = 3;
    [Tooltip("做呼吸灯的效果的组件是Image或Text")]
    public UiComponent uiComponent = UiComponent.Image组件;
    //public bool componentIsImage = true;
    //public bool componentIsText = false;

    private float timer = 0;
    private Color _colorChange;

    void OnEnable()
    {
    }

    void Start()
    {
        switch (uiComponent)
        {
            case UiComponent.Image组件:
                _colorChange = this.GetComponent<Image>().color;
                _colorChange.a = from;
                break;
            case UiComponent.Text组件:
                _colorChange = this.GetComponent<Text>().color;
                _colorChange.a = from;
                break;
        }
    }

    void Update()
    {
        if (type == Type.单向播放模式)
        {
            #region Logo逐渐变亮
            timer += Time.deltaTime;
            if (timer >= delayTime) return;

            if (_colorChange.a != to)
            {
                switch (uiComponent)
                {
                    case UiComponent.Image组件:
                        _colorChange.a = Mathf.Lerp(from, to, timer / delayTime);
                        this.GetComponent<Image>().color = _colorChange;
                        break;
                    case UiComponent.Text组件:
                        _colorChange.a = Mathf.Lerp(from, to, timer / delayTime);
                        this.GetComponent<Text>().color = _colorChange;
                        break;
                    default:
                        break;
                }
            }
            #endregion
        }
        else if (type == Type.呼吸灯模式)
        {
            #region 呼吸灯效果

            timer += Time.deltaTime;
            if (timer >= delayTime)
            {
                timer = 0;
                float temp = from;
                from = to;
                to = temp;
            }

            switch (uiComponent)
            {
                case UiComponent.Image组件:
                    _colorChange.a = Mathf.Lerp(from, to, timer / delayTime);
                    this.GetComponent<Image>().color = _colorChange;
                    break;
                case UiComponent.Text组件:
                    _colorChange.a = Mathf.Lerp(from, to, timer / delayTime);
                    this.GetComponent<Text>().color = _colorChange;
                    break;
                default:
                    break;
            }

            #endregion
        }
    }
}




