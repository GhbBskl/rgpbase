using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    private Animator anim;// 角色动画控制器，用来控制动画参数，比如 isMoving
    private Rigidbody2D rb;// 角色的 2D 刚体组件，用来控制移动、跳跃等物理行为

    [Header("Attack details")]
    [SerializeField] private float attackRange = 0.5f;// 角色攻击范围
    [SerializeField] private Transform attackPoint;// 角色攻击点位置，用来检测攻击范围内的敌人
    [SerializeField] private LayerMask whatIsEnemy;// 用来指定哪些层被认为是敌人

    [Header("Movement details")]
    // SerializeField 可以让 private 变量显示在 Unity Inspector 面板中
    [SerializeField] private float moveSpeed = 3.5f;// 角色移动速度
    [SerializeField] private float jumpForce = 8f;// 角色跳跃力度
    private float xInput;// 水平方向输入值 (-1 表示向左，0 表示不动，1 表示向右)
    // // 用来记录角色当前是否面向右边
    private bool facingRight = true;
    private bool canMove = true;// 用来控制角色是否可以移动，比如在攻击动画播放时可能不允许移动
    private bool canJump = true;// 用来控制角色是否可以跳跃，比如在攻击动画播放时可能不允许跳跃


    [Header("Collision details")]
    [SerializeField] private float groundCheckDistance; // 用来检测角色是否在地面上的位置
    [SerializeField] private LayerMask whatIsGround; // 用来指定哪些层被认为是地面
    private bool isGrounded; // 用来指定哪些层被认为是地面

    private void Awake()
    {
        // 获取当前物体上的 Rigidbody2D 组件
        rb = GetComponent<Rigidbody2D>();
        // 获取当前物体或子物体上的 Animator 组件
        // 如果 Animator 挂在角色的子物体上，用 GetComponentInChildren 更合适
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        HandleCollision();// 处理碰撞检测，更新isGrounded状态
        HandleInput();// 读取玩家输入
        HandleMovement();// 根据输入控制角色移动
        HandleAnimations();// 根据当前状态更新动画
        HandleFlip();// 根据移动方向决定是否翻转角色
    }

    public void DamageEnemies()
    {
        Collider2D[] enemyColliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, whatIsEnemy);
        foreach (Collider2D enemyCollider in enemyColliders)
        {
            Enemy enemyScript = enemyCollider.GetComponent<Enemy>();
            enemyScript.TakeDamage(1); // 这里假设每次攻击造成 1 点伤害
            Debug.Log("Attacked " + enemyScript.enemyName + " for 1 damage!"); // 输出攻击日志
        }
    }

    public void EnableMovementAndJump(bool enable)
    {
        canJump = enable;
        canMove = enable;
    }

    private void HandleInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space)) TryToJump();

        if (Input.GetKeyDown(KeyCode.J)) TryToAttack();
    }

    private void TryToAttack()
    {
        if(isGrounded)
        {
            anim.SetTrigger("attack");
        }   
    }

    private void TryToJump()
    {
        if(isGrounded && canJump) rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);// 第二种：直接修改 y 轴速度
        // rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);//第一种:给刚体一个向上的瞬间冲力
            
    }

    private void HandleMovement()   
    {
        if(canMove) rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocity.y);
        else rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);// 攻击时停止角色移动
    }

    private void HandleCollision()
    {
        // 这里可以添加检测角色是否在地面上的逻辑使用 Physics2D.Raycast从角色位置向下发射一条射线，检测是否碰到地面
        isGrounded  = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    private void HandleAnimations()
    {
        // 把 isMoving 的值传给 Animator,Animator 里必须有一个 Bool 参数，名字叫 isMoving
        anim.SetFloat("xVelocity", rb.linearVelocity.x);
        anim.SetFloat("yVelocity", rb.linearVelocity.y);
        anim.SetBool("isGrounded", isGrounded);
    }

    private void HandleFlip()
    {
        // 如果角色移动方向和当前面朝方向不同,就需要翻转
        if (rb.linearVelocity.x > 0 && !facingRight) Flip();
        else if (rb.linearVelocity.x < 0 && facingRight) Flip();
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);

        facingRight = !facingRight;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -groundCheckDistance));
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}