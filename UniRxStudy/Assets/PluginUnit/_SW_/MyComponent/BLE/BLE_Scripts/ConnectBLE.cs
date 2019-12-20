using System;
using UnityEngine;

public class ConnectBLE
{
    /// <summary>
    /// 初始化并搜索周围蓝牙设备(Android)
    /// </summary>
    /// <param name="serviceUUID"></param>
    /// <param name="action"></param>
    /// <param name="actionAdvertisingInfo"></param>
    public static void InitBluetooth_Android(string[] serviceUUID, Action<string, string> action, Action<string, string, int, byte[]> actionAdvertisingInfo = null)
    {
        //初始化蓝牙
        BluetoothLEHardwareInterface.Initialize(true, false, delegate
        {
            Debug.Log("蓝牙初始化成功!");

            //当蓝牙初始化成功后，开始搜索蓝牙设备
            //Invoke("ScanBluetooth", 1f);
            BluetoothLEHardwareInterface.ScanForPeripheralsWithServices(serviceUUID, action, actionAdvertisingInfo);

        }, delegate (string errorInfo)
        {
            Debug.Log("蓝牙初始化失败:" + errorInfo);
            //todo：执行打开手机蓝牙的操作
        });
    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="serviceUUID"></param>
    /// <param name="action"></param>
    /// <param name="actionAdvertisingInfo"></param>
    public static void InitBluetooth_IOS(string[] serviceUUID, Action<string, string> action, Action<string, string, int, byte[]> actionAdvertisingInfo = null)
    {
        //初始化蓝牙
        BluetoothLEHardwareInterface.Initialize(true, false, delegate
        {
            Debug.Log("蓝牙初始化成功!");

            //当蓝牙初始化成功后，开始搜索蓝牙设备
            BluetoothLEHardwareInterface.ScanForPeripheralsWithServices(serviceUUID, action, actionAdvertisingInfo);

        }, delegate (string errorInfo)
        {
            Debug.Log("蓝牙初始化失败:" + errorInfo);
            //todo：执行打开手机蓝牙的操作
        });
    }

}
