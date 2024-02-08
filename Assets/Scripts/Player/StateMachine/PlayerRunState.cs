using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }

    public override void EnterState()
    {
        player.Anim.SetInteger("State", (int)StateEnum.EPlayerState.run);
        player.SpawnDustEffcect();
    }

    public override void UpdateState()
    {
        CheckSwitchState();
        PlayerStateManager.UpdateObjectDirX(player);
    }

    public override void FixedUpdateState()
    {
        player.CanMove();
    }

    public override void CheckSwitchState()
    {
        if (player.IsGrounded())
        {
            if (InputManager.Instant.Jump())
            {
                SoundManager.Instant.PlaySound(GameEnum.ESound.jump);
                player.SpawnDustEffcect();
                player.Rb.AddForce(Vector2.up * player.JumpForce, ForceMode2D.Impulse);
                SwitchState(factory.Jump());
            }
            else if (InputManager.Instant.Dash() && player.CanDash)
            {
                SwitchState(factory.Dash());
            }
            else if (!InputManager.Instant.Moving())
            {
                SwitchState(factory.Idle());
            }
        }
        else if (player.Rb.velocity.y < -10f)
        {
            SwitchState(factory.Fall());
        }
    }

    public override void ExitState()
    {

    }
}
