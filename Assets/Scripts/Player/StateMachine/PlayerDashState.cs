using UnityEngine;

public class PlayerDashState : PlayerBaseState
{
    public PlayerDashState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }

    public override void EnterState()
    {
        SoundManager.Instant.PlaySound(GameEnum.ESound.dashSound);
        player.StartCoroutine(player.Dash(player));
        player.Rb.gravityScale = 0f;
        player.Anim.SetInteger("State", (int)StateEnum.EPlayerState.dash);
    }

    public override void UpdateState()
    {
        CheckSwitchState();
    }

    public override void FixedUpdateState()
    {
        player.Rb.velocity = new Vector2(player.RaycastDirX * player.DashForce, 0);
    }

    public override void CheckSwitchState()
    {
        if (player.IsSeeingGround && player.IsDashing)
        {
            SwitchState(factory.WallSlide());
        }
        else if(player.IsDashing)
        {
            
        }
        else if (player.Rb.velocity.y < .1f)
        {
            SwitchState(factory.Fall());
        }
        else if (InputManager.Instant.Moving())
        {
            SwitchState(factory.Run());
        }
        else
        {
            SwitchState(factory.Idle());
        }
    }
    public override void ExitState()
    {
        player.Rb.gravityScale = 9f;
    }
}
