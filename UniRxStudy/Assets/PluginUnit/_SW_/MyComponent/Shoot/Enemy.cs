// ========================================================
// 描 述：敌人
// 作 者：SW
// 创建时间：2018/10/24 14:34:53
// 版 本：v 1.0
// ========================================================

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    /// <summary>
    /// 使用蜘蛛的类型
    /// </summary>
    public EnemyType EnemyType;
    /// <summary>
    /// 蜘蛛的基本类型及参数
    /// </summary>
    private readonly EnemyManager _enemyManager = new EnemyManager();
    /// <summary>
    /// 蜘蛛的类型
    /// </summary>
    private EnemyParameter _enemyParameterEnemyType;


    #region 蜘蛛的基础参数
    private float hp;
    private float _maxHp;
    /// <summary>
    /// 攻击间隔（秒）
    /// </summary>
    private float attackRate;
    private float attackTimer = 0;
    /// <summary>
    /// 移动速度
    /// </summary>
    private float moveSeed;
    /// <summary>
    /// 攻击距离（到相机的最小距离）
    /// </summary>
    private float attackDistance;
    /// <summary>
    /// 开始移动距离
    /// </summary>
    private float walkDistance = 5;
    /// <summary>
    /// 攻击伤害
    /// </summary>
    private float damage;
    /// <summary>
    /// 打死得分
    /// </summary>
    private float score;
    #endregion


    public float Hp
    {
        get
        {
            return hp;
        }

        set
        {
            hp = value;

            if (hp <= 0)
            {
                hp = 0;
                if (EnemyType == EnemyType.Enemy_fly || EnemyType == EnemyType.Enemy_fly_suspension)
                {
                    //StartCoroutine(Dead_Fly());
                }
                else
                {
                    //StartCoroutine(Dead());
                }
            }


            if (this.EnemyType == EnemyType.Enemy_Boss)
            {
                this.transform.parent.GetComponentsInChildren<Image>()[1].fillAmount = Hp / _maxHp;
            }
        }
    }


    private void Start()
    {
        Init();
        InvokeRepeating("CalcDistance", 0, 0.5f);
    }

    /// <summary>
    /// 初始化蜘蛛的参数
    /// </summary>
    private void Init()
    {
        _enemyManager.enemyType = EnemyType;
        _enemyParameterEnemyType = _enemyManager.EnemyParameterSet();

        hp = _enemyParameterEnemyType.hp;
        _maxHp = _enemyParameterEnemyType.hp;
        attackRate = _enemyParameterEnemyType.attackRate;
        moveSeed = _enemyParameterEnemyType.moveSeed;
        attackDistance = _enemyParameterEnemyType.attackDistance;
        walkDistance = _enemyParameterEnemyType.walkDistance;
        damage = _enemyParameterEnemyType.damage;
        score = _enemyParameterEnemyType.Score;
    }



    void Update()
    {
        if (hp > 0)
        {
            switch (EnemyType)
            {
                case EnemyType.Enemy_little:
                    //Enemy_mormal();
                    break;
                case EnemyType.Enemy_mormal:
                    //Enemy_mormal();
                    break;
                case EnemyType.Enemy_fly:
                    //StartCoroutine(Enemy_fly());
                    break;
                case EnemyType.Enemy_fly_suspension:
                    //Enemy_fly_suspension();
                    break;
                case EnemyType.Enemy_Boss:
                    //Enemy_Boss();
                    break;
                default:
                    break;
            }
        }
    }
}
