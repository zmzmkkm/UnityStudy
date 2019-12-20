using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Calendar : MonoBehaviour
{
    #region SingletonMode
    private static Calendar _instance;
    public static Calendar Instance { get { return _instance; } }
    #endregion


    #region public变量
    [HideInInspector]
    public string date_year_day;
    [HideInInspector]
    public string date_All;


    [Tooltip("本月的文字颜色")]
    public Color nowWenziColor;
    [Tooltip("非本月的文字颜色")]
    public Color otherWenziColor;
    [Tooltip("选中框的背景颜色")]
    public Color selectColor;
    [Tooltip("非选中框背景颜色")]
    public Color notSelectColor;
    [Tooltip("选中框的背景图")]
    public Sprite selectSprite;
    [Tooltip("非选中框的背景图")]
    public Sprite notSelectSprite;
    #endregion


    #region Private变量
    private GameObject DayGrid;
    private Text timeShow_Text;
    private Button NowDay_Btn;
    private Button UpMonth_Btn;
    private Button DownMonth_Btn;
    private InputField startTimetHour_InputField;
    private InputField startTimeMinute_InputField;
    private InputField startTimeSecond_InputField;
    private Button TiJiao_Button;

    Dictionary<string, int> WeekOfNumber = new Dictionary<string, int>();
    private string nowWeek = DateTime.Now.DayOfWeek.ToString();//今天星期几
    private int nowYear = DateTime.Now.Year;
    private int nowMonth = DateTime.Now.Month;
    private int nowDay = DateTime.Now.Day;
    private Image[] allDayGrid;//所有日期的实体


    private int month_Days = 0;//这个月有几天
    private int upmonth_Days = 0;//上个月有几天
    private int month_Number = 0;//月份数值，用来记录操作的是哪个月份
    private int firstDayIndext = 0;//当月一号的Grid索引
    private int lastDayIndext = 41;//当月最后一天的Grid的索引
    private int firstWeekSunday_DayNumber = 7;//第一周周末是几号
    #endregion



    void Awake()
    {
        _instance = this;

        DayGrid = this.transform.Find("DayGrid").gameObject;
        timeShow_Text = this.transform.Find("Title_Btns/Date_year_day_Text").GetComponent<Text>();
        NowDay_Btn = this.transform.Find("Title_Btns/NowDay_Btn").GetComponent<Button>();
        UpMonth_Btn = this.transform.Find("Title_Btns/UpMonth_Btn").GetComponent<Button>();
        DownMonth_Btn = this.transform.Find("Title_Btns/DownMonth_Btn").GetComponent<Button>();
        NowDay_Btn.onClick.AddListener(() => InitializationCalendar());
        UpMonth_Btn.onClick.AddListener(() => UpMonthCalendar());
        DownMonth_Btn.onClick.AddListener(() => DownMonthCalendar());
        startTimetHour_InputField = this.transform.Find("InputTime/StartTime/Hour_InputField").GetComponent<InputField>();
        startTimeMinute_InputField = this.transform.Find("InputTime/StartTime/Minute_InputField").GetComponent<InputField>();
        startTimeSecond_InputField = this.transform.Find("InputTime/StartTime/Second_InputField").GetComponent<InputField>();//TiJiao_Button
        TiJiao_Button = this.transform.Find("InputTime/TiJiao_Button").GetComponent<Button>();
        TiJiao_Button.onClick.AddListener(() => PrintSelectTime());


        WeekOfNumber.Add("Monday", 0);
        WeekOfNumber.Add("Tuesday", 1);
        WeekOfNumber.Add("Wednesday", 2);
        WeekOfNumber.Add("Thursday", 3);
        WeekOfNumber.Add("Friday", 4);//
        WeekOfNumber.Add("Saturday", 5);
        WeekOfNumber.Add("Sunday", 6);

        allDayGrid = DayGrid.GetComponentsInChildren<Image>();//所有日期的实体
        for (int i = 0; i < allDayGrid.Length; i++)
        {
            Button clickGrid_Btn = allDayGrid[i].GetComponent<Button>();
            clickGrid_Btn.onClick.AddListener(delegate () { ReadSelcetDateTime(clickGrid_Btn.gameObject); });
        }
    }

    private void OnEnable()
    {
        NowMonthCalendar(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        GetTime();
    }


    /// <summary>
    /// 当前月份的日历
    /// </summary>
    /// <param name="allDay"></param>
    private void NowMonthCalendar(int nowYear, int nowMonth, int nowDay)
    {
        #region 显示当前的年月
        string nowYearStr = nowYear < 10 ? "0" + nowYear : nowYear.ToString();
        string nowMontStr = nowMonth < 10 ? "0" + nowMonth : nowMonth.ToString();
        timeShow_Text.text = nowYearStr + "年" + nowMontStr + "月";
        #endregion

        month_Days = DateTime.DaysInMonth(nowYear, nowMonth);
        nowWeek = DateTime.Parse(nowYear + "/" + nowMonth + "/" + nowDay).DayOfWeek.ToString();
        lastDayIndext = 41;

        int nowIndext = WeekOfNumber[nowWeek];//今天星期的索引
        if (nowDay - 1 <= nowIndext)
        {
            firstDayIndext = nowIndext - nowDay + 1;
        }
        else
        {
            firstWeekSunday_DayNumber = nowDay - (nowIndext + 1);//第一周周末是几号
            while (firstWeekSunday_DayNumber > 7)
            {
                firstWeekSunday_DayNumber -= 7;
            }
            firstDayIndext = 7 - firstWeekSunday_DayNumber;
        }

        //当月及下个月的日历
        for (int i = firstDayIndext; i < allDayGrid.Length; i++)
        {
            allDayGrid[i].GetComponentInChildren<Text>().text = (i - firstDayIndext + 1).ToString();

            //将当天标记出来
            if ((i - firstDayIndext + 1) == nowDay)
            {
                allDayGrid[i].color = selectColor;
                allDayGrid[i].sprite = selectSprite;
            }
            else
            {
                allDayGrid[i].color = notSelectColor;
                allDayGrid[i].sprite = notSelectSprite;
            }


            if (allDayGrid[i].GetComponentInChildren<Text>().text == month_Days.ToString())
            {
                lastDayIndext = i;
            }
            if (i > lastDayIndext)
            {
                allDayGrid[i].GetComponentInChildren<Text>().text = (i - lastDayIndext).ToString();
                allDayGrid[i].GetComponentInChildren<Text>().color = otherWenziColor;
                allDayGrid[i].GetComponent<Button>().enabled = false;
            }
            else
            {
                allDayGrid[i].GetComponentInChildren<Text>().color = nowWenziColor;
                allDayGrid[i].GetComponent<Button>().enabled = true;
            }


        }

        //上个月的日历
        if (nowMonth - 1 == 0)
        {
            month_Number = 12;
            nowYear--;
        }
        else
        {
            month_Number = nowMonth - 1;
            upmonth_Days = DateTime.DaysInMonth(nowYear, month_Number);
        }
        for (int i = 0; i < firstDayIndext; i++)
        {
            allDayGrid[i].GetComponentInChildren<Text>().text = (upmonth_Days - firstDayIndext + i + 1).ToString();
            allDayGrid[i].color = notSelectColor;
            allDayGrid[i].sprite = notSelectSprite;
            allDayGrid[i].GetComponentInChildren<Text>().color = otherWenziColor;
            allDayGrid[i].GetComponent<Button>().enabled = false;
        }
    }


    /// <summary>
    /// 上个月的日历
    /// </summary>
    public void UpMonthCalendar()
    {
        nowMonth = (nowMonth - 1) % 13;
        if (nowMonth == 0)
        {
            nowMonth = 12;
            nowYear--;
        }
        nowDay = 1;
        NowMonthCalendar(nowYear, nowMonth, nowDay);
    }


    /// <summary>
    /// 下个月的日历
    /// </summary>
    public void DownMonthCalendar()
    {
        nowMonth = (nowMonth + 1) % 13;
        if (nowMonth == 0)
        {
            nowMonth = 1;
            nowYear++;
        }
        nowDay = 1;
        NowMonthCalendar(nowYear, nowMonth, nowDay);
    }


    /// <summary>
    /// 返回到今日的日历
    /// </summary>
    public void InitializationCalendar()
    {
        nowYear = DateTime.Now.Year;
        nowMonth = DateTime.Now.Month;
        nowDay = DateTime.Now.Day;
        NowMonthCalendar(nowYear, nowMonth, nowDay);
    }


    /// <summary>
    /// 获取选择的日期
    /// </summary>
    private void ReadSelcetDateTime(GameObject temp)
    {
        for (int i = 0; i < allDayGrid.Length; i++)
        {
            if (allDayGrid[i].GetComponent<Image>().sprite == selectSprite)
            {
                string selectDayGrid_Text = allDayGrid[i].GetComponentInChildren<Text>().text.Length < 2
                    ? "0" + allDayGrid[i].GetComponentInChildren<Text>().text
                    : allDayGrid[i].GetComponentInChildren<Text>().text;
                date_year_day = timeShow_Text.text.Replace("年", "-").Replace("月", "-") + selectDayGrid_Text;
            }
        }
        for (int i = 0; i < allDayGrid.Length; i++)
        {
            allDayGrid[i].color = notSelectColor;
            allDayGrid[i].sprite = notSelectSprite;
        }
        temp.GetComponentInChildren<Image>().color = selectColor;
        temp.GetComponentInChildren<Image>().sprite = selectSprite;
    }



    /// <summary>
    /// 获取当前输入的时间
    /// </summary>
    private void GetTime()
    {
        startTimetHour_InputField.text = DateTime.Now.Hour < 10 ? "0" + DateTime.Now.Hour : DateTime.Now.Hour.ToString();
        startTimeMinute_InputField.text = DateTime.Now.Minute < 10 ? "0" + DateTime.Now.Minute : DateTime.Now.Minute.ToString();
        startTimeSecond_InputField.text = DateTime.Now.Second < 10 ? "0" + DateTime.Now.Second : DateTime.Now.Second.ToString();
    }



    public GameObject InputFieldGameObject = null;
    /// <summary>
    /// 输出选择的时间
    /// </summary>
    public void PrintSelectTime()
    {
        for (int i = 0; i < allDayGrid.Length; i++)
        {
            if (allDayGrid[i].GetComponent<Image>().sprite == selectSprite)
            {
                string selectDayGrid_Text = allDayGrid[i].GetComponentInChildren<Text>().text.Length < 2
                    ? "0" + allDayGrid[i].GetComponentInChildren<Text>().text
                    : allDayGrid[i].GetComponentInChildren<Text>().text;
                date_year_day = timeShow_Text.text.Replace("年", "-").Replace("月", "-") + selectDayGrid_Text;
            }
        }

        string startTimetHour_InputField_Text = startTimetHour_InputField.text.Length < 2 ? "0" + startTimetHour_InputField.text : startTimetHour_InputField.text;
        string startTimeMinute_InputField_Text = startTimeMinute_InputField.text.Length < 2 ? "0" + startTimeMinute_InputField.text : startTimeMinute_InputField.text;
        string startTimeSecond_InputField_Text = startTimeSecond_InputField.text.Length < 2 ? "0" + startTimeSecond_InputField.text : startTimeSecond_InputField.text;
        date_All = date_year_day + " " + startTimetHour_InputField_Text + ":" + startTimeMinute_InputField_Text + ":" +
                       startTimeSecond_InputField_Text;
        InputFieldGameObject.GetComponent<InputField>().text = date_All;
        Destroy(this.gameObject);
    }
}
