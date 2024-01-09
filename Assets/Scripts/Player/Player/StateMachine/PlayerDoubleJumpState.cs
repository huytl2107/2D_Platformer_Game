using UnityEngine;

public class PlayerDoubleJumpState : PlayerBaseState
{
    public PlayerDoubleJumpState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Hello from Double Jump State");
        player.Anim.SetInteger("State", (int)StateEnum.EPlayerState.doubleJump);
        player.Rb.velocity = new Vector2(player.Rb.velocity.x, player.JumpForce);
    }

    public override void UpdateState()
    {
        player.CanMove();
        CheckSwitchState();
        PlayerStateManager.UpdateObjectDirX(player);
    }

    public override void CheckSwitchState()
    {
        if (Input.GetKeyDown(player.DashKey) && player.CanDash)
        {
            SwitchState(factory.Dash());
        }
        else if (player.IsSeeingGround)
        {
            SwitchState(factory.WallSlide());
        }
        else if (Input.GetKeyDown(player.ThrowWeaponKey) && player.CanThrowWeapon)
        {
            SwitchState(factory.ThrowWeapon());
        }
        else if (player.Rb.velocity.y < .1f)
        {
            SwitchState(factory.Fall());
        }
    }

    public override void ExitState()
    {

    }
}
