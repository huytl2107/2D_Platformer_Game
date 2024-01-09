using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Hello from Idle State");
        player.Anim.SetInteger("State", (int)StateEnum.EPlayerState.idle);
        player.Rb.velocity = new Vector2(0f, player.Rb.velocity.y);
    }

    public override void UpdateState()
    {
        CheckSwitchState();
    }

    public override void CheckSwitchState()
    {
        player.DirX = Input.GetAxisRaw("Horizontal");
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
            else if (player.DirX != 0)
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
}
