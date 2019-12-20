using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("SW_Component/ScriptGather/显示系统时间（SystemTime）")]
public class SystemTime : MonoBehaviour
{
    public enum TimeFromat
    {
        年_月_日__时_分_秒,
        时_分_秒__年_月_日,
        时_分_秒,
        年_月_日,
    }

    [Header("挂载到“ScriptGather”上：")]
    [Space(10)]

    [Tooltip("显示时间的格式")]
    public TimeFromat timeFromat = TimeFromat.年_月_日__时_分_秒;

    [Tooltip("将系统时间显示在showTimeText上")]
    public Text showTimeText;

    void Update()
    {
        int year = System.DateTime.Now.Year;
        int month = System.DateTime.Now.Month;
        int day = System.DateTime.Now.Day;

        int hourr = System.DateTime.Now.Hour;
        int minn = System.DateTime.Now.Minute;
        int ss = System.DateTime.Now.Second;
        string sHour = hourr < 10 ? "0" + hourr : hourr.ToString();
        string sMin = minn < 10 ? "0" + minn : minn.ToString();
        string sss = ss < 10 ? "0" + ss : ss.ToString();
        switch (timeFromat)
        {
            case TimeFromat.年_月_日__时_分_秒:
                showTimeText.text = year + "/" + month + "/" + day + "    " + sHour + ":" + sMin + ":" + sss;
                break;
            case TimeFromat.时_分_秒__年_月_日:
                showTimeText.text = sHour + ":" + sMin + ":" + sss + "    " + year + "/" + month + "/" + day;
                break;
            case TimeFromat.时_分_秒:
                showTimeText.text = sHour + ":" + sMin + ":" + sss;
                break;
            case TimeFromat.年_月_日:
                showTimeText.text = year + "/" + month + "/" + day;
                break;
            default:
                break;
        }
    }
}
