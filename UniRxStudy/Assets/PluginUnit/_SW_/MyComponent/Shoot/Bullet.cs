// ========================================================
// 描 述：
// 作 者：SW
// 创建时间：2018/10/23 16:19:56
// 版 本：v 1.0
// ========================================================

using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    /// <summary>
    /// 子弹资源池
    /// </summary>
    [HideInInspector]
    public BulletPool bulletPool;
    /// <summary>
    /// 子弹初始坐标
    /// </summary>
    [HideInInspector]
    public Vector3 startVector3;
    /// <summary>
    /// 子弹落点坐标
    /// </summary>
    [HideInInspector]
    public Vector3 endVector3;
    /// <summary>
    /// 子弹速度
    /// </summary>
    [HideInInspector]
    public float moveSpeed;
    /// <summary>
    /// 子弹飞行的最大距离
    /// </summary>
    [HideInInspector]
    public float maxDistance;
    /// <summary>
    /// 持有被击中的物体
    /// </summary>
    [HideInInspector]
    public GameObject HitGameObject;
    /// <summary>
    /// 持有击中物体时的声音
    /// </summary>
    [HideInInspector]
    public AudioClip DazhongClip;
    /// <summary>
    /// 持有击中蜘蛛时的声音
    /// </summary>
    [HideInInspector]
    public AudioClip hit;
    /// <summary>
    /// 火力值（每发子弹的伤害）
    /// </summary>
    [HideInInspector]
    public float bulletPower;

    private float t = 0;
    private GameObject _shouji;
    private GameObject _huoHua;
    /// <summary>
    /// 子弹打中物体时的粒子特效
    /// </summary>
    private GameObject texiao;
    public bool IsXueWuTexiao = false;



    void OnEnable()
    {
        t = 0;
        _shouji = GameObject.Find("SHOUJI");
        _huoHua = GameObject.Find("HuoHua");
    }

    void Update()
    {
        Shooting();
    }

    //
    /// <summary>
    /// 发射子弹
    /// </summary>
    private void Shooting()
    {
        //transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.Self);
        //transform.position += transform.up * Time.deltaTime * moveSpeed;
        t += Time.deltaTime * moveSpeed;
        this.transform.position = Vector3.MoveTowards(startVector3, endVector3, t);

        if (Vector3.Distance(this.transform.position, startVector3) > maxDistance)
        {
            bulletPool.PutBack(this.gameObject);
        }
        else if (this.transform.position == endVector3)
        {
            //todo:回收子弹到资源池，声音特效，粒子特效,掉血功能销毁物体，受伤特效，弹痕特效
            bulletPool.PutBack(this.gameObject);

            //AudioSource.PlayClipAtPoint(DazhongClip, transform.localPosition);


            if (IsXueWuTexiao)
            {
                AudioPools.Instance.GetAudioSource(hit, transform.localPosition, 0.8f);
                texiao = Instantiate(_shouji);
                texiao.SetActive(true);
                texiao.transform.position = endVector3;
                texiao.AddComponent<DestroySelf>();
                texiao.GetComponent<DestroySelf>().Timer = 0.6f;
                IsXueWuTexiao = false;
            }
            else
            {
                //todo:播放火花特效
                AudioPools.Instance.GetAudioSource(DazhongClip, transform.localPosition, 0.7f);
                texiao = Instantiate(_huoHua);
                texiao.SetActive(true);
                texiao.transform.position = endVector3;
                texiao.AddComponent<DestroySelf>();
                texiao.GetComponent<DestroySelf>().Timer = 0.6f;
                IsXueWuTexiao = false;
            }

            if (HitGameObject != null)
            {
                Enemy aEnemy = HitGameObject.GetComponent<Enemy>();
                if (aEnemy != null)
                {
                    HitGameObject.GetComponent<Enemy>().Hp -= bulletPower;

                }
            }
        }
    }
}
