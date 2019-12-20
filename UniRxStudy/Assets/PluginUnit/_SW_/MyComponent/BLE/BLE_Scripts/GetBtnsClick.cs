using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GetBtnsClick : MonoBehaviour
{
    public Text DebugText;
    public Shoot Shoot;

    private string bleName = "SHOWBABY_00:E4:79";  //SHOWBABY_BC:5B:00     SHOWBABY_00:E4:79
    //private string bleAddress;
    //private string bleAddress_Adroid = "30:22:00:00:5B:BC";
    //private string bleAddress_IOS = "FAEBEB17-476D-48F1-B3C0-52D9E61BF0B0";

    private string _serviceUUID = "fff0";
    private string _readCharacteristicUUID = "fff4";
    private string _writeCharacteristicUUID = "1525";// "2222";
    private string _fullUUID = "-0000-1000-8000-00805f9b34fb";


    void Start()
    {
        //Connect_Btn.onClick.AddListener(InitBluetooth);
        InitBluetooth();
        _readCharacteristicUUID = FullUUID(_readCharacteristicUUID);
    }

    string FullUUID(string uuid)
    {
        return "0000" + uuid + _fullUUID;
    }

    /// <summary>
    /// 初始化蓝牙
    /// </summary>
    public void InitBluetooth()
    {
        BluetoothLEHardwareInterface.Initialize(true, false, delegate
        {
            Show("蓝牙初始化成功");
            ScanBluetooth();
        }, delegate (string errorInfo)
        {
            Show("蓝牙初始化失败");
        });
    }

    /// <summary>
    /// 搜索蓝牙设备
    /// </summary>
    public void ScanBluetooth()
    {
        Show("开始搜索蓝牙设备... ...");
        BluetoothLEHardwareInterface.ScanForPeripheralsWithServices(null, (bleAddress, name) =>
            {
                AddPeripheral(name, bleAddress);
            }, (address, name, rssi, advertisingInfo) => { });
    }


    #region 连接成功后的数据处理
    /// <summary>
    /// 检查蓝牙合法性
    /// </summary>
    void AddPeripheral(string name, string bleAddress)
    {
        if (name == bleName)
        {
            Show(bleAddress + "    " + name);
            Show("遥控器已上线");
            ConnectBluetooth(bleAddress);
            //OnConnect(bleAddress);
        }

        //#if UNITY_IPHONE
        //        bleAddress = bleAddress_IOS;
        //#elif UNITY_ANDROID
        //		bleAddress=bleAddress_Adroid;
        //#endif
    }


    #region MyRegion
    private bool _connecting = false;
    bool _connected = false;
    bool Connected
    {
        get { return _connected; }
        set
        {
            _connected = value;

            if (_connected)
            {

                _connecting = false;
            }


        }
    }
    public void OnConnect(string bleAddress)
    {
        if (!_connecting)
        {
            if (Connected)
            {
                return;
            }
            else
            {
                BluetoothLEHardwareInterface.ConnectToPeripheral(bleAddress, (address) =>
                {
                },
                    (address, serviceUUID) =>
                    {
                    },
                    (address, serviceUUID, characteristicUUID) =>
                    {
                        Show("蓝牙连接成功!");
                        SubscribeBluetoothMsg(bleAddress);

                    }, (address) =>
                    {
                        // this will get called when the device disconnects
                        // be aware that this will also get called when the disconnect
                        // is called above. both methods get call for the same action
                        // this is for backwards compatibility

                        Shoot.isFire01 = false;
                        Show("蓝牙已断开，请尝试重新连接......");
                        //InitBluetooth();
                        Connected = false;
                    });

                _connecting = true;
            }
        }
    }


    void disconnect(Action<string> action, string bleAddress)
    {
        BluetoothLEHardwareInterface.DisconnectPeripheral(bleAddress, action);
    }
    #endregion


    /// <summary>
    /// 连接到蓝牙
    /// </summary>
    public void ConnectBluetooth(string bleAddress)
    {
        Show("开始连接到蓝牙... ...");
        BluetoothLEHardwareInterface.ConnectToPeripheral(bleAddress, (address) => { }, (address, serviceUUID) => { }, (address, serviceUUID, characteristicUUID) =>
         {
             Show("蓝牙连接成功!");
             SubscribeBluetoothMsg(bleAddress);
         }, (address) =>
        {
            // this will get called when the device disconnects
            // be aware that this will also get called when the disconnect
            // is called above. both methods get call for the same action
            // this is for backwards compatibility
            //Connected = false;
        });
    }


    /// <summary>
    /// 订阅蓝牙消息
    /// </summary>
    public void SubscribeBluetoothMsg(string bleAddress)
    {
        Show("开始订阅蓝牙消息... ...");
        BluetoothLEHardwareInterface.SubscribeCharacteristicWithDeviceAddress(bleAddress, _serviceUUID, _readCharacteristicUUID, (deviceAddress, notification) => { },
            (deviceAddress, characteristicUUID, data) =>
            {
                //Show(BitConverter.ToString(data));
                FireBtn(data);
            });
    }


    private void FireBtn(byte[] data)
    {
        switch (BitConverter.ToString(data))
        {
            case "42-32-44-4F-57-4E":
                Show("按下按键1");
                Shoot.isFire01 = true;
                break;
            case "42-32-55-50":
                Show("抬起按键1");
                Shoot.isFire01 = false;
                break;
            case "42-33-44-4F-57-4E":
                Show("按下按键2");
                Shoot.isFire02 = true;
                break;
            case "42-33-55-50":
                Show("抬起按键2");
                Shoot.isFire02 = false;
                break;
            case "42-34-44-4F-57-4E":
                Show("按下按键3");
                Shoot.isFire03 = true;
                break;
            case "42-34-55-50":
                Show("抬起按键3");
                Shoot.isFire03 = false;
                break;
            default:
                break;
        }
    }
    #endregion



    /// <summary>
    /// 将信息输出到UI上 方便观察
    /// </summary>
    /// <param name="str">输出的值 不需要加换行符</param>
    void Show(string str)
    {
        DebugText.text = str + "\n";
    }
}
