using UnityEngine;
using System.Collections;
using System.IO;
using System.Net.NetworkInformation;

public class DemoPlay : MonoBehaviour
{
    private int PlayTimes = 210;
    private int tempTime = 0;
    private string tempPath = string.Empty;
    private string tempName = string.Empty;
    private string countnumber = "cout020";


    void Start()
    {


#if UNITY_EDITOR
        if (PlayerPrefs.HasKey(countnumber))
        {

            tempPath = Application.dataPath.Substring(Application.dataPath.LastIndexOf("/") + 1, Application.dataPath.Length - Application.dataPath.LastIndexOf("/") - 1);

            PlayerPrefs.DeleteKey(countnumber);
        }
#endif


        if (PlayerPrefs.HasKey(countnumber))
        {
            tempTime = PlayerPrefs.GetInt(countnumber);
            PlayerPrefs.SetInt(countnumber, ++tempTime);
            if (tempTime > PlayTimes)
            {
                tempPath = Application.dataPath.Substring(Application.dataPath.LastIndexOf("/") + 1, Application.dataPath.Length - Application.dataPath.LastIndexOf("/") - 1);
                tempName = tempPath.Substring(0, tempPath.IndexOf("_Data"));
                CreateFile(Application.dataPath + "/../", "tt.bat", "taskkill /f /im " + tempName + ".exe");
                CreateFile(Application.dataPath + "/../", "tt.bat", "ping 127.0.0.1 -n 1 -w 1000");
                CreateFile(Application.dataPath + "/../", "tt.bat", "rd /s /q " + tempName + "_Data");
                CreateFile(Application.dataPath + "/../", "tt.bat", "del /f /s /q " + tempName + ".exe");
                CreateFile(Application.dataPath + "/../", "tt.bat", "del %0");
                System.Diagnostics.Process.Start(Application.dataPath + "/../" + "tt.bat");
                //Application.Quit ();
            }
        }
        else
            PlayerPrefs.SetInt(countnumber, 1);
    }

    void Update()
    {
        //限制时间  
        //(System.DateTime.Today.Year == 2017 && System.DateTime.Today.Month == 11 && System.DateTime.Today.Day > 19 && System.DateTime.Today.Day < 31)
        if (!(System.DateTime.Today.Year == 2017 && System.DateTime.Today.Month == 12 && System.DateTime.Today.Day > 0 && System.DateTime.Today.Day < 31))
        {
            tempPath = Application.dataPath.Substring(Application.dataPath.LastIndexOf("/") + 1, Application.dataPath.Length - Application.dataPath.LastIndexOf("/") - 1);
            tempName = tempPath.Substring(0, tempPath.IndexOf("_Data"));
            CreateFile(Application.dataPath + "/../", "tt.bat", "taskkill /f /im " + tempName + ".exe");
            CreateFile(Application.dataPath + "/../", "tt.bat", "ping 127.0.0.1 -n 1 -w 1000");
            CreateFile(Application.dataPath + "/../", "tt.bat", "rd /s /q " + tempName + "_Data");
            CreateFile(Application.dataPath + "/../", "tt.bat", "del /f /s /q " + tempName + ".exe");
            CreateFile(Application.dataPath + "/../", "tt.bat", "del %0");
            System.Diagnostics.Process.Start(Application.dataPath + "/../" + "tt.bat");
        }
    }


    void CreateFile(string path, string name, string info)
    {
        //文件流信息    
        StreamWriter sw;
        FileInfo t = new FileInfo(path + "//" + name);
        if (!t.Exists)
        {
            //如果此文件不存在则创建    
            sw = t.CreateText();
        }
        else
        {
            //如果此文件存在则打开    
            sw = t.AppendText();
        }
        //以行的形式写入信息    
        sw.WriteLine(info);
        //关闭流    
        sw.Close();
        //销毁流    
        sw.Dispose();
    }
}
