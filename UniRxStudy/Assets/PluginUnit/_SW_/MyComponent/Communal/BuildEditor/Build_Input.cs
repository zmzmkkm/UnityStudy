// ========================================================
// 描 述：控制台命令程序
// 作 者：SW
// 创建时间：2018/01/05 14:20:46
// 版 本：v 1.0
// ========================================================

using UnityEngine;
using UnityEngine.UI;

public class Build_Input : MonoBehaviour
{
    private bool isShow = false;

    public GameObject cmdWindow_InputField;

    public GameObject mianCamera;
    public GameObject FPS;

    public GameObject Help_Table;



    void Start()
    {
        cmdWindow_InputField.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote) && Input.GetKey(KeyCode.Z))
        {
            if (isShow)
            {
                cmdWindow_InputField.SetActive(true);
            }
            else
            {
                cmdWindow_InputField.SetActive(false);
            }
            isShow = !isShow;
        }

    }


    /// <summary>
    /// 命令框中输入的命令
    /// </summary>
    public void InputField_cmd()
    {
        //帮助文档室面板
        if (cmdWindow_InputField.GetComponent<InputField>().text == "cmd_help")
        {

            Help_Table.SetActive(true);
        }



        //todo:添加命令对应的事件

    }


    /// <summary>
    /// 保存浏览相机的数据到BrowseLocation.text
    /// </summary>
    public void Save_CmaeraParameter()
    {
        //string filePath = Application.streamingAssetsPath + "\\BrowseLocation.text";

        //WWWMessage.Instance.BrowseLocation_Lists.Find(q => q.AreaName == MoNiJZBtn.Instance.MainCamera.GetComponent<Preview>().target.name).Distance = MoNiJZBtn.Instance.MainCamera.GetComponent<Preview>().distance.ToString();
        //WWWMessage.Instance.BrowseLocation_Lists.Find(q => q.AreaName == MoNiJZBtn.Instance.MainCamera.GetComponent<Preview>().target.name).X = MoNiJZBtn.Instance.MainCamera.GetComponent<Preview>().x.ToString();
        //WWWMessage.Instance.BrowseLocation_Lists.Find(q => q.AreaName == MoNiJZBtn.Instance.MainCamera.GetComponent<Preview>().target.name).Y = MoNiJZBtn.Instance.MainCamera.GetComponent<Preview>().y.ToString();

        //string cmaeraParameter_Json = JsonConvert.SerializeObject(WWWMessage.Instance.BrowseLocation_Lists);
        //File.WriteAllText(filePath, cmaeraParameter_Json);
    }






    private void MousePointPos()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit hit = new RaycastHit();
            Physics.Raycast(ray, out hit);
            if (hit.transform != null)
            {
                print(hit.point);
            }
        }
    }
}
