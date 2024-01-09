using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerWallJumpState : PlayerBaseState
{
    public PlayerWallJumpState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }

    public override void EnterState()
    {
        player.IsDoubleJump = false;
        player.Rb.velocity = new Vector2(player.Rb.velocity.x, player.JumpForce);
        player.Anim.SetInteger("State", (int)StateEnum.EPlayerState.wallJump);
    }

    public override void UpdateState()
    {
        CheckSwitchState();
    }

    public override void CheckSwitchState()
    {
        if (player.Rb.velocity.y < player.JumpForce / 2)
        {
            SwitchState(factory.Jump());
        }
        else if (player.RaycastDirX > 0)
        {
            player.Rb.velocity = new Vector2(-player.Speed, player.Rb.velocity.y);
        }
        else
        {
            player.Rb.velocity = new Vector2(player.Speed, player.Rb.velocity.y);
        }
    }

    public override void ExitState()
    {

    }
}
