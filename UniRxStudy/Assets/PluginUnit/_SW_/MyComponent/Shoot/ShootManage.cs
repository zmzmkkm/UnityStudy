// ========================================================
// 描 述：
// 作 者：SW
// 创建时间：2019/02/15 10:53:13
// 版 本：v 1.0
// ========================================================
// ========================================================
// 描 述：枪的基本类型及参数(特效  声音)
// 作 者：SW
// 创建时间：2018/10/23 10:18:40
// 版 本：v 1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunType
{
    GunType1 = 0,
    GunType2 = 1,
    GunType3 = 2,
}

public enum ShootType
{
    按屏幕 = 0,
    蓝牙枪 = 1,
}

//
public class ShootManage
{
    public GunType gunType = GunType.GunType1;
    public GunParameter gunParameter_GunType;


    public GunParameter GunParameterSet()
    {
        switch (gunType)
        {
            case GunType.GunType1:
                gunParameter_GunType = new GunParameter() { moveSpeed = 200, bulletCount = 30, allBulletCount = 180, rateOfFire = 0.08f, timer_ChangeAmmunition = 1.3f, maxDistance = 50f, bulletPower = 15f };
                break;
            case GunType.GunType2:
                gunParameter_GunType = new GunParameter() { moveSpeed = 100, bulletCount = 100000, allBulletCount = 10000, rateOfFire = 0.116f, timer_ChangeAmmunition = 2.3f, maxDistance = 70f, bulletPower = 40f };
                break;
            case GunType.GunType3:
                gunParameter_GunType = new GunParameter() { moveSpeed = 800, bulletCount = 10, allBulletCount = 60, rateOfFire = 1f, timer_ChangeAmmunition = 1.5f, maxDistance = 200f, bulletPower = 100f };
                break;
            default:
                break;
        }

        return gunParameter_GunType;
    }
}



/// <summary>
/// 子弹参数类
/// </summary>
public class GunParameter
{
    /// <summary>
    /// 子弹移动速度
    /// </summary>
    public int moveSpeed;

    /// <summary>
    /// 弹夹容量
    /// </summary>
    public int bulletCount;

    /// <summary>
    /// 备用子弹数量
    /// </summary>
    public int allBulletCount;

    /// <summary>
    /// 射速（连发的子弹时间间隔）
    /// </summary>
    public float rateOfFire;

    /// <summary>
    /// 换弹时间
    /// </summary>
    public float timer_ChangeAmmunition;

    /// <summary>
    /// 子弹最大飞行距离
    /// </summary>
    public float maxDistance;

    /// <summary>
    /// 火力值（没发子弹的伤害）
    /// </summary>
    public float bulletPower;
}
