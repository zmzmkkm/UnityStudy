// ========================================================
// 描 述：射击
// 作 者：SW
// 创建时间：2018/10/22 10:19:39
// 版 本：v 1.0
// ========================================================

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    #region 暂时不用
    ///// <summary>
    ///// 换枪按钮
    ///// </summary>
    //public Button ChangeGun_Btn;
    #endregion

    /// <summary>
    /// 枪口
    /// </summary>
    public GameObject muzzle;
    /// <summary>
    /// 枪焰
    /// </summary>
    public GameObject gunFlame;

    /// <summary>
    /// 子弹资源池
    /// </summary>
    public BulletPool bulletPool;

    /// <summary>
    /// 准星控制
    /// </summary>
    public zhunxingkuozhang zhunxingkuozhang;


    /// <summary>
    /// 但要数量显示
    /// </summary>
    public Text bulletCount_Text;

    /// <summary>
    /// 更换弹夹按键
    /// </summary>
    public Button ChangeBullet_Btn;
    /// <summary>
    /// 换弹进度提示
    /// </summary>
    public Image TimeImage;
    public Text TimeText;


    /// <summary>
    /// 使用枪的类型
    /// </summary>
    public GunType MyGunType;

    /// <summary>
    /// 枪的基本类型及参数
    /// </summary>
    private ShootManage shootManage = new ShootManage();
    /// <summary>
    /// 枪的类型
    /// </summary>
    private GunParameter gunParameter_GunType;
    /// <summary>
    /// 子弹移动速度
    /// </summary>
    private int moveSpeed;
    /// <summary>
    /// 当前弹夹所剩子弹数
    /// </summary>
    private int bulletCount;
    private int bulletCount_Init;
    /// <summary>
    /// 备用子弹数量
    /// </summary>
    private int allBulletCount;
    /// <summary>
    /// 射速（连发的子弹时间间隔）
    /// </summary>
    private float rateOfFire;
    private float rateOfFire_Init;
    /// <summary>
    /// 是否允许开下一枪
    /// </summary>
    private bool isAllowedToFire = true;
    /// <summary>
    /// 换弹时间
    /// </summary>
    private float timer_ChangeAmmunition;
    private float timer_ChangeAmmunition_Init;
    /// <summary>
    /// 子弹最大飞行距离
    /// </summary>
    private float maxDistance;
    /// <summary>
    /// 火力值（没发子弹的伤害）
    /// </summary>
    private float bulletPower;

    [HideInInspector]
    public bool isFire01 = false;
    [HideInInspector]
    public bool isFire02 = false;
    [HideInInspector]
    public bool isFire03 = false;

    [HideInInspector]
    public bool IsStartShoot = false;

    /// <summary>
    /// 是否正在更换弹夹
    /// </summary>
    private bool isChangeAmmuniting = false;


    //layermask参数设置的一些总结： 
    //1 << 10 打开第10的层。 
    //~(1 << 10) 打开除了第10之外的层。 
    //~(1 << 0) 打开所有的层。 
    //(1 << 10) | (1 << 8) 打开第10和第8的层。
    private int _layerMask = (1 << 9) | (1 << 10);


    public int AllBulletCount
    {
        get
        {
            return allBulletCount;
        }

        set
        {
            allBulletCount = value;
            if (allBulletCount > 10000)
            {
                allBulletCount = 10000;
            }
        }
    }

    void Start()
    {
        ChangeBullet_Btn.onClick.AddListener(HuanDanClick);

        if (!muzzle)
        {
            var gun = Instantiate(Resources.Load("Gun")) as GameObject;
            gun.transform.SetParent(Camera.main.transform);
            gun.transform.localPosition = Vector3.zero;
            gun.transform.localRotation = Quaternion.Euler(Vector3.zero);
            muzzle = gun.transform.Find("muzzle").gameObject;
        }
        Init();


        //ChangeGun_Btn.onClick.AddListener(() =>
        //{
        //    MyGunType = (GunType)((MyGunType.GetHashCode() + 1) % Enum.GetNames(MyGunType.GetType()).Length);
        //    Init();
        //});
    }


    /// <summary>
    /// 初始化枪的参数
    /// </summary>
    private void Init()
    {
        shootManage.gunType = MyGunType;
        gunParameter_GunType = shootManage.GunParameterSet();

        moveSpeed = gunParameter_GunType.moveSpeed;
        bulletCount = gunParameter_GunType.bulletCount;
        AllBulletCount = gunParameter_GunType.allBulletCount;
        rateOfFire = gunParameter_GunType.rateOfFire;
        timer_ChangeAmmunition = gunParameter_GunType.timer_ChangeAmmunition;
        maxDistance = gunParameter_GunType.maxDistance;
        bulletPower = gunParameter_GunType.bulletPower;

        rateOfFire_Init = rateOfFire;
        bulletCount_Init = bulletCount;
        timer_ChangeAmmunition_Init = timer_ChangeAmmunition;

        TimeImage.fillAmount = 0;
        bulletCount_Text.text = bulletCount + "/" + AllBulletCount;
    }



    void Update()
    {
        ShejiCtrol();

        HuanDan();

        DetectionEnemy();
    }

    private int beishu;
    /// <summary>
    /// 点射与连发控制
    /// </summary>
    private void ShejiCtrol()
    {
        if ((Input.GetMouseButton(0) || isFire01) && IsStartShoot)
        {
            if (isAllowedToFire)
            {
                isAllowedToFire = false;
                Shooting();
            }
            zhunxingkuozhang.FrontSight_Expand();
        }
        else
        {
            zhunxingkuozhang.FrontSight_Restore();
        }



        #region 二倍镜子
        //if (isFire03)
        //{
        //    isFire03 = false;
        //    beishu++;
        //    if (beishu > 2)
        //    {
        //        beishu = 0;
        //    }
        //}

        //switch (beishu)
        //{
        //    case 0:
        //        GameObjectManager.GetInstance().MainCamera.GetComponent<Camera>().fieldOfView = 60;
        //        break;
        //    case 1:
        //        GameObjectManager.GetInstance().MainCamera.GetComponent<Camera>().fieldOfView = 30;
        //        break;
        //    case 2:
        //        GameObjectManager.GetInstance().MainCamera.GetComponent<Camera>().fieldOfView = 10;
        //        break;
        //    default:
        //        break;
        //}
        #endregion


        if (!isAllowedToFire)
        {
            rateOfFire -= Time.deltaTime;
            if (rateOfFire <= 0)
            {
                isAllowedToFire = true;
                rateOfFire = rateOfFire_Init;
            }
        }
    }



    /// <summary>
    /// 检测是否瞄准了敌人
    /// </summary>
    private void DetectionEnemy()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 200f, _layerMask))
        {
            if (hit.collider.tag == "Enemy")
            {
                zhunxingkuozhang.ChangeColorRed();
            }
            else
            {
                zhunxingkuozhang.ChangeColorWrite();
            }
        }
    }




    /// <summary>
    /// 射击方法
    /// </summary>
    private void Shooting()
    {

        if (Camera.main != null)
        {
            if (bulletCount > 0 && !isChangeAmmuniting)
            {
                //todo:实例化显示枪焰
                GameObject flame = Instantiate(gunFlame);
                flame.transform.parent = muzzle.transform;
                flame.transform.position = muzzle.transform.position;
                flame.transform.localRotation = Quaternion.Euler(new Vector3(180, 0, 0));
                flame.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

                bulletCount--;

                // 以摄像机所在位置为起点，创建一条向里侧发射的射线  
                Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                RaycastHit hit;

                GameObject go = bulletPool.GetBullet();
                go.transform.position = muzzle.transform.position;
                go.transform.rotation = muzzle.transform.rotation;
                Bullet bullet = go.GetComponent<Bullet>();
                bullet.bulletPool = bulletPool;
                bullet.moveSpeed = moveSpeed;
                bullet.maxDistance = maxDistance;
                bullet.startVector3 = muzzle.transform.position;
                //todo:  bullet.DazhongClip = GameObjectManager.Instance.DazhongClip;
                //todo:  bullet.hit = GameObjectManager.Instance.Hit2;
                bullet.bulletPower = bulletPower;

                if (Physics.Raycast(ray, out hit, 200f, _layerMask))
                {
                    if (hit.collider.tag == "Enemy")
                    {
                        bullet.HitGameObject = hit.collider.gameObject;
                        bullet.IsXueWuTexiao = true;
                    }
                    bullet.endVector3 = hit.point;
                }
                //todo:  AudioPools.Instance.GetAudioSource(GameObjectManager.Instance.A, GameObjectManager.Instance.MainCamera.transform.position, 0.4f);
                bulletCount_Text.text = bulletCount + "/" + AllBulletCount;


                //if (Physics.Raycast(ray, out hit /*, Mathf.Infinity*/))
                //{
                //    // 如果射线与平面碰撞，打印碰撞物体信息  
                //    Debug.Log("碰撞对象: " + hit.collider.name);
                //    //在场景视图中绘制射线
                //    Debug.DrawLine(ray.origin, hit.point, Color.red);
                //    Destroy(hit.collider.gameObject);
                //    //Shooting01(hit.point, hit.collider.gameObject);
                //}
            }
        }
        else
        {
            //todo:  AudioPools.Instance.GetAudioSource(GameObjectManager.Instance.A, GameObjectManager.Instance.MainCamera.transform.position, 0.4f);
        }
    }


    #region 更换弹夹
    /// <summary>
    /// 点击按钮更换弹夹
    /// </summary>
    private void HuanDanClick()
    {
        if (bulletCount < bulletCount_Init && AllBulletCount > 0)
        {
            isChangeAmmuniting = true;
            TimeImage.fillAmount = 1;
        }
    }

    /// <summary>
    /// 更换子弹
    /// </summary>
    private void HuanDan()
    {
        //if (isFire02 && bulletCount < bulletCount_Init && AllBulletCount > 0)
        //{
        //    isFire02 = false;
        //    isChangeAmmuniting = true;
        //    TimeImage.fillAmount = 1;
        //}

        //没有子弹时自动更换弹夹
        if (bulletCount <= 0)
        {
            isChangeAmmuniting = true;
            TimeImage.fillAmount = 1;
        }

        if (isChangeAmmuniting)
        {
            TimeImage.gameObject.SetActive(true);

            timer_ChangeAmmunition -= Time.deltaTime;
            TimeImage.fillAmount = (timer_ChangeAmmunition / timer_ChangeAmmunition_Init);
            TimeText.text = timer_ChangeAmmunition.ToString("f2");

            if (timer_ChangeAmmunition <= 0)
            {
                TimeText.text = "";
                timer_ChangeAmmunition = timer_ChangeAmmunition_Init;

                int needAdd = bulletCount_Init - bulletCount;
                if (AllBulletCount >= needAdd)
                {
                    bulletCount = bulletCount_Init;
                    AllBulletCount -= needAdd;
                }
                else
                {
                    bulletCount += AllBulletCount;
                    AllBulletCount = 0;
                }

                bulletCount_Text.text = bulletCount + "/" + AllBulletCount;
                isChangeAmmuniting = false;
            }
        }
    }
    #endregion


    /// <summary>
    /// 获取子弹
    /// </summary>
    /// <param name="count"></param>
    private void GetBullet(int count)
    {
        AllBulletCount += count;
        bulletCount_Text.text = bulletCount + "/" + AllBulletCount;
    }
}
