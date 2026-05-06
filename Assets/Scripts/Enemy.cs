using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]protected float moveSpeed = 3f;
    public string enemyName {private set; get;}
    private void Update()
    {
        //MoveArrund();// 这里注释掉了敌人自动移动的代码，暂时让敌人保持静止，方便测试攻击功能
        if (Input.GetKeyDown(KeyCode.F))
        {
            Attack();
        }
        MoveAround();
    }

    private void MoveAround()
    {
        Debug.Log(enemyName + " is moving around." + moveSpeed);
    }

    protected virtual void Attack()
    {
        Debug.Log(enemyName + " is attacking.");
    }

    public void TakeDamage(int damage)
    {
        // Debug.Log(enemyName + " took " + damage + " damage.");
    }

    // public string GetEnemyName()
    // {
    //     return enemyName;
    // }
}
