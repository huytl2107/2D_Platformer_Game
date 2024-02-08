using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }

    public override void EnterState()
    {
        player.Anim.SetInteger("State", (int)StateEnum.EPlayerState.idle);
        player.Rb.velocity = new Vector2(0f, player.Rb.velocity.y);
    }

    public override void UpdateState()
    {
        CheckSwitchState();
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
            else if (InputManager.Instant.Moving())
            {
                SwitchState(factory.Run());
            }
        }
        else if (player.Rb.velocity.y < .1f)
        {
            SwitchState(factory.Fall());
        }
    }

    public override void ExitState()
    {

    }

    public override void FixedUpdateState()
    {
    }
}
