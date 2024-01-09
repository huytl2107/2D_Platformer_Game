using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }

    public override void EnterState()
    {
        player.Anim.SetInteger("State", (int)StateEnum.EPlayerState.run);
    }

    public override void UpdateState()
    {
        player.CanMove();
        CheckSwitchState();
        PlayerStateManager.UpdateObjectDirX(player);
    }

    public override void CheckSwitchState()
    {
        if (player.IsGrounded())
        {
            if (Input.GetButtonDown("Jump"))
            {
                SwitchState(factory.Jump());
            }
            else if (Input.GetKeyDown(player.ThrowWeaponKey) && player.CanThrowWeapon)
            {
                SwitchState(factory.ThrowWeapon());
            }
            else if (Input.GetKeyDown(player.DashKey) && player.CanDash)
            {
                SwitchState(factory.Dash());
            }
            else if (player.DirX == 0)
            {
                SwitchState(factory.Idle());
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
}
