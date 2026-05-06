 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponentInParent<Player>();
    }

    public void DamageEnemies() => player.DamageEnemies();

    public void DisableJumpAndMovement() => player.EnableMovementAndJump(false);
    public void EnableJumpAndMovement() => player.EnableMovementAndJump(true);
}
