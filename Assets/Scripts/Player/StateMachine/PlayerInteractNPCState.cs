using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractNPCState : PlayerBaseState
{
    public PlayerInteractNPCState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }

    public override void CheckSwitchState()
    {
    }

    public override void EnterState()
    {
        //Đặt gravity về originial để tránh bug từ DashState
        player.Rb.gravityScale = 9f;

        player.Anim.SetInteger("State", (int)StateEnum.EPlayerState.idle);
        player.Rb.velocity = new Vector2(0f, player.Rb.velocity.y);
    }

    public override void ExitState()
    {
    }

    public override void FixedUpdateState()
    {
        player.Rb.velocity = new Vector2(0f, player.Rb.velocity.y);
    }

    public override void UpdateState()
    {
    }
}
