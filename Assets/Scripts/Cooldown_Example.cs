using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown_Example : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] private float redColorDuration = 0.3f; // 受伤后颜色持续时间

    [SerializeField]private float currentTimeInGame; // 游戏开始到当前这一帧的时间
    [SerializeField]private float lastTimeWasDamaged; // 上次受到伤害的时间
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        ChanceColorIfNeeded();
    }

    private void ChanceColorIfNeeded()
    {
        currentTimeInGame = Time.time; // 累加游戏时间
        if (currentTimeInGame - lastTimeWasDamaged >= redColorDuration && sr.color == Color.red)
        {
            TurnWhite(); // 如果距离上次受伤时间超过了红色持续时间，则恢复颜色
        }
    }

    public void TakeDamage(int damage)
    {
        sr.color = Color.red; // 这里简单地将敌人颜色变为红色，表示受伤
        lastTimeWasDamaged = currentTimeInGame; // 更新上次受伤时间为当前时间
    }

    private void TurnWhite()
    {
        sr.color = Color.white; // 将敌人颜色恢复为白色
    }
}
