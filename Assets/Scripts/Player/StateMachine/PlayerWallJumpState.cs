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
        SoundManager.Instant.PlaySound(GameEnum.ESound.jump);
        player.Rb.AddForce(Vector2.up * player.JumpForce, ForceMode2D.Impulse);
        player.Anim.SetInteger("State", (int)StateEnum.EPlayerState.wallJump);
    }

    public override void UpdateState()
    {
        CheckSwitchState();
    }

    public override void FixedUpdateState()
    {
        player.Rb.velocity = new Vector2(player.Speed * -player.RaycastDirX, player.Rb.velocity.y);
    }

    public override void CheckSwitchState()
    {
        if (player.Rb.velocity.y < player.JumpForce / 2f)
        {
            player.Rb.velocity = new Vector2 (player.Rb.velocity.x, player.JumpForce/2f);
            SwitchState(factory.Jump());
        }
    }

    public override void ExitState()
    {

    }
}
