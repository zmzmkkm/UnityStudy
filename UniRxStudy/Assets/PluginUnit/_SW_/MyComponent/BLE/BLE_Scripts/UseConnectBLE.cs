using UnityEngine;
using UnityEngine.UI;

public class UseConnectBLE : MonoBehaviour
{
    public Image BtnImage;
    public Text AaaText;
    private string[] serviceUUID = new string[] { "00001803-494c-4f47-4943-544543480000" };

    private int minRSSI = -70;

    void Start()
    {

    }


    /// <summary>
    /// 连接并使用蓝牙设备
    /// </summary>
    public void InitConnect()
    {
#if UNITY_IPHONE
			ConnectBLE.InitBluetooth_IOS(serviceUUID, (address, name) =>
        {
            //todo:储存并显示蓝牙的名称及信号强度
            ShowBLE();



        }, (address, name, rssi, advertisingInfo) =>
        {
            ShowYouy002(name, rssi, minRSSI);



        });
#elif UNITY_ANDROID
        ConnectBLE.InitBluetooth_Android(serviceUUID, (address, name) =>
        {
            //todo:储存并显示蓝牙的名称及信号强度
            ShowBLE();



        }, (address, name, rssi, advertisingInfo) =>
        {
            ShowYouy002(name, rssi, minRSSI);



        });
#endif
    }



    /// <summary>
    /// todo:储存并显示蓝牙的名称及信号强度
    /// </summary>
    private void ShowBLE()
    {
        //if (!Btn_par.Find(address + "_" + name) && name != "No Name")
        //{
        //    GameObject go = GameObject.Instantiate(Btn);
        //    go.SetActive(true);
        //    go.name = address + "_" + name;
        //    go.transform.SetParent(Btn_par, false);
        //    go.GetComponentInChildren<Text>().text = address + "    " + name;
        //    go.GetComponent<Button>().onClick.AddListener(() => AddPeripheral(name, address));
        //}

        //todo:将最小信号强度存储到minRSSI中
    }


    /// <summary>
    /// todo:利用信号强度大小来判断执行什么事件
    /// </summary>
    /// <param name="name"></param>
    /// <param name="rssi"></param>
    /// <param name="minRssi"></param>
    private void ShowYouy002(string name, int rssi, int minRssi)
    {
        switch (name)
        {
            case "youy001":

                break;
            case "youy002":
                if (rssi > minRssi)
                {
                    BtnImage.gameObject.SetActive(true);
                }
                else
                {
                    BtnImage.gameObject.SetActive(false);
                }
                break;
            default:
                break;
        }
    }
}
