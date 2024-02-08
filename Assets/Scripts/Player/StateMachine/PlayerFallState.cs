using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public PlayerFallState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }

    public override void EnterState()
    {
        player.Rb.gravityScale = 11f;
        player.Anim.SetInteger("State", (int)StateEnum.EPlayerState.fall);
        player.Anim.SetBool("GotHit", false);
    }

    public override void UpdateState()
    {
        player.CanMove();
        CheckSwitchState();
        PlayerStateManager.UpdateObjectDirX(player);

        //Hạn chế tốc độ rơi
        if (player.Rb.velocity.y <= -25f)
        {
            player.Rb.velocity = new Vector2(player.Rb.velocity.x, -25f);
        }
    }
    
    public override void FixedUpdateState()
    {
        player.CanMove();
    }

    public override void CheckSwitchState()
    {
        if (player.IsSeeingGround)
        {
            SwitchState(factory.WallSlide());
        }
        else if (InputManager.Instant.Dash() && player.CanDash)
        {
            SwitchState(factory.Dash());
        }
        else if (player.IsGrounded())
        {
            player.IsDoubleJump = false;
            if (InputManager.Instant.Moving())
            {
                SwitchState(factory.Run());
            }
            else
            {
                SwitchState(factory.Idle());
            }
        }
        else if (InputManager.Instant.Jump() && !player.IsDoubleJump)
        {
            player.IsDoubleJump = true;
            SwitchState(factory.DoubleJump());
        }
    }

    public override void ExitState()
    {
        player.Rb.gravityScale = 9f;
    }
}
