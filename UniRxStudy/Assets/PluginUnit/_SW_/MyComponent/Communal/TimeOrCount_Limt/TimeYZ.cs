using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Xml;
using UnityEngine;

public class TimeYZ : MonoBehaviour
{
    private string _xml文件;
    private XmlDocument xmlDoc = new XmlDocument();
    private string tempPath = string.Empty;
    private string tempName = string.Empty;
    private bool isThisPC = false;

    void Start()
    {
        StartCoroutine(aaaa());
    }

    private IEnumerator aaaa()
    {
        yield return StartCoroutine(PanDuanMAC());
        yield return StartCoroutine(CreatZCB());
        yield return StartCoroutine(ChangeZCB());
        yield return StartCoroutine(PanDuanZCB());
    }

    private IEnumerator PanDuanMAC()
    {
        isThisPC = false;
        NetworkInterface[] nis = NetworkInterface.GetAllNetworkInterfaces();
        foreach (NetworkInterface ni in nis)
        {
            //Debug.Log("Name = " + ni.Name);
            //Debug.Log("Des = " + ni.Description);
            //Debug.Log("Type = " + ni.NetworkInterfaceType.ToString());
            //Debug.Log("Mac = " + ni.GetPhysicalAddress().ToString());
            //Debug.Log("------------------------------------");
            if (ni.GetPhysicalAddress().ToString() == "ACE2D3CD94C3")//"28D2442B9650"现场  "086266B84283"me    "606DC7528786"张显     28D2442B9650  舒畅   "ACE2D3CD94C3"张涤平    68F728787337  ???
            {
                isThisPC = true;
            }
        }

        if (!isThisPC)
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
        yield return null;
    }

    private IEnumerator CreatZCB()
    {
        _xml文件 = Application.dataPath + "/System_Win.xml";


        XmlDocument xmlDoc01 = new XmlDocument();
        if (!File.Exists(_xml文件))
        {
            XmlElement root = xmlDoc01.CreateElement("Root");
            xmlDoc01.AppendChild(root);
            XmlElement user = xmlDoc01.CreateElement("用户信息");
            user.SetAttribute("time", "0001E_65_K23_AS98_AC");
            user.SetAttribute("年", "2017");
            user.SetAttribute("月", "11");
            user.SetAttribute("日", "2");
            root.AppendChild(user);
            xmlDoc01.Save(_xml文件);
        }
        yield return null;
    }


    private IEnumerator PanDuanZCB()
    {
        xmlDoc.Load(_xml文件);
        XmlNodeList nodeList = xmlDoc.SelectSingleNode("Root").ChildNodes;
        foreach (XmlElement xe in nodeList)
        {
            if (xe.GetAttribute("time") == "0001E_65_K23_AS98_AC")
            {
                if ((System.DateTime.Today.Year.ToString() == xe.GetAttribute("年")) && (System.DateTime.Today.Month.ToString() == xe.GetAttribute("月")) && (System.DateTime.Today.Day >= int.Parse(xe.GetAttribute("日"))))
                {

                }
                else
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
        }
        yield return null;
    }



    private IEnumerator ChangeZCB()
    {
        xmlDoc.Load(_xml文件);
        XmlNodeList nodeList = xmlDoc.SelectSingleNode("Root").ChildNodes;
        foreach (XmlElement xe in nodeList)
        {
            if (xe.GetAttribute("年") == "2017")
            {

                xe.SetAttribute("年", System.DateTime.Today.Year.ToString());
                xe.SetAttribute("月", System.DateTime.Today.Month.ToString());
                xe.SetAttribute("日", System.DateTime.Today.Day.ToString());
                xmlDoc.Save(_xml文件);
            }
        }
        yield return null;
    }



    void CreateFile(string path, string name, string info)
    {
        StreamWriter sw;
        FileInfo t = new FileInfo(path + "//" + name);
        if (!t.Exists)
        {
            sw = t.CreateText();
        }
        else
        {
            sw = t.AppendText();
        }
        sw.WriteLine(info);
        sw.Close();
        sw.Dispose();
    }
}
