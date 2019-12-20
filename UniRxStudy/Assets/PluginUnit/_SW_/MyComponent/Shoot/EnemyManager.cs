// ========================================================
// 描 述：敌人类型
// 作 者：SW
// 创建时间：2019/02/15 11:08:12
// 版 本：v 1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Enemy_little = 0,
    Enemy_mormal = 1,
    Enemy_fly = 2,
    Enemy_fly_suspension = 3,
    Enemy_Boss = 4
}

public class EnemyManager
{
    public EnemyType enemyType = EnemyType.Enemy_little;
    public EnemyParameter enemyParameter_EnemyType;

    public EnemyParameter EnemyParameterSet()
    {
        switch (enemyType)
        {
            case EnemyType.Enemy_little:
                enemyParameter_EnemyType = new EnemyParameter() { hp = 100, attackRate = 1f, moveSeed = 0.5f, attackDistance = 0.8f, walkDistance = 107, damage = 2, Score = 1 };
                break;
            case EnemyType.Enemy_mormal:
                enemyParameter_EnemyType = new EnemyParameter() { hp = 150, attackRate = 2.0f, moveSeed = 0.3f, attackDistance = 1.5f, walkDistance = 104, damage = 7, Score = 1 };
                break;
            case EnemyType.Enemy_fly:
                enemyParameter_EnemyType = new EnemyParameter() { hp = 150, attackRate = 2f, moveSeed = 0.4f, attackDistance = 1.5f, walkDistance = 106, damage = 7, Score = 1 };
                break;
            case EnemyType.Enemy_fly_suspension:
                enemyParameter_EnemyType = new EnemyParameter() { hp = 150, attackRate = 2f, moveSeed = 0.4f, attackDistance = 1.5f, walkDistance = 106, damage = 7, Score = 1 };
                break;
            case EnemyType.Enemy_Boss:
                enemyParameter_EnemyType = new EnemyParameter() { hp = 6000, attackRate = 2f, moveSeed = 0, attackDistance = 6f, walkDistance = 4f, damage = 15, Score = 66 };
                break;
            default:
                break;
        }

        return enemyParameter_EnemyType;
    }
}
// 

/// <summary>
/// 蜘蛛参数类
/// </summary>
public class EnemyParameter
{
    /// <summary>
    /// 蜘蛛总血量
    /// </summary>
    public float hp;

    /// <summary>
    /// 攻击间隔（秒）
    /// </summary>
    public float attackRate;

    /// <summary>
    /// 移动速度
    /// </summary>
    public float moveSeed;

    /// <summary>
    /// 攻击距离（到相机的最小距离）
    /// </summary>
    public float attackDistance;

    /// <summary>
    /// 开始移动距离
    /// </summary>
    public float walkDistance;

    /// <summary>
    /// 攻击伤害
    /// </summary>
    public float damage;

    /// <summary>
    /// 打死得分
    /// </summary>
    public float Score;
}
