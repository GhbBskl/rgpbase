using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Archer : Enemy
{
    [ContextMenu("Shoot arrow!")]
    protected override void Attack()
    {
        Debug.Log(enemyName + " shoots an arrow!"); // 输出射箭日志
    }
}
