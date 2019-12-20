using UnityEngine;
using UnityEngine.EventSystems;

[AddComponentMenu("SW_Component/ScriptGather/按钮声音（PlaySound）")]
public class PlaySound : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public enum Trigger
    {
        OnClick,
        OnMouseEnter,
        OnMouseExite,
        OnMouseDown,
        OnMouseUp,
    }


    [Header("挂载到“需要声音的UI上”上：")]
    [Space(10)]

    [Tooltip("添加要播放的声音")]
    public AudioClip audioClip;
    [Tooltip("选择播放声音的触发方式")]
    public Trigger trigger = Trigger.OnClick;

    [Tooltip("控制音量大小")]
    [Range(0f, 1f)]
    public float volume = 1f;
    //[Tooltip("播放频率")]
    //[Range(0f, 2f)]
    //public float pitch = 1f;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (trigger == Trigger.OnClick)
        {
            AudioPlayMehod();
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (trigger == Trigger.OnMouseEnter)
        {
            AudioPlayMehod();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (trigger == Trigger.OnMouseExite)
        {
            AudioPlayMehod();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (trigger == Trigger.OnMouseDown)
        {
            AudioPlayMehod();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (trigger == Trigger.OnMouseUp)
        {
            AudioPlayMehod();
        }
    }


    /// <summary>
    /// 播放声音的方法
    /// </summary>
    private void AudioPlayMehod()
    {
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, volume);
    }
}
