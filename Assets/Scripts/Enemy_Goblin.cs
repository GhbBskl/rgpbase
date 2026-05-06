using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Enemy_Goblin : Enemy
{
    private void StealGold()
    {
        Debug.Log(enemyName + " stole some gold!");
    }

    [ContextMenu("Steal gold!")]
    protected override void Attack()
    {
        base.Attack(); // 调用父类的 Attack 方法，输出攻击日志
        StealGold(); // 额外调用 Goblin 特有的 StealGold 方法
    }
}
