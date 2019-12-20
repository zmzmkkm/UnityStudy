// ========================================================
// 描 述：
// 作 者：SW
// 创建时间：2019/02/15 10:50:35
// 版 本：v 1.0
// ========================================================
// ========================================================
// 描 述：子弹的资源池
// 作 者：SW
// 创建时间：2018/10/22 10:14:29
// 版 本：v 1.0
// ========================================================
using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour
{
    public int count = 30;//预定义子弹的数量
    public GameObject bulletPrefab;

    private List<GameObject> bulletList = new List<GameObject>();//列表存储实例化的子弹

    private void Awake()
    {
        InitPool();
    }

    //初始化资源池
    private void InitPool()
    {
        for (int i = 0; i < count; i++)
        {
            CreatBullet();
        }
    }

    //实例化一个子弹，加入到列表中，并隐藏
    private GameObject CreatBullet()
    {
        GameObject go = Instantiate(bulletPrefab) as GameObject;
        bulletList.Add(go);
        go.transform.SetParent(transform);
        go.SetActive(false);
        return go;
    }

    //返回子弹列表中还没有使用的子弹对象，如果没有的话，则实例化新的子弹
    public GameObject GetBullet()
    {
        foreach (GameObject bullet in bulletList)
        {
            if (bullet.activeInHierarchy == false)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }
        return CreatBullet();
    }

    //回收子弹到资源池中
    //回收成功返回true，失败返回false
    public bool PutBack(GameObject go)
    {
        if (bulletList.Contains(go))
        {
            go.SetActive(false);
            return true;
        }
        return false;
    }
}
