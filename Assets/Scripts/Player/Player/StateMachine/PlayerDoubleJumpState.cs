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
        CheckSwitchState();
        PlayerStateManager.UpdateObjectDirX(player);
    }

    public override void CheckSwitchState()
    {
        player.DirX = Input.GetAxisRaw("Horizontal");
        player.Rb.velocity = new Vector2(player.DirX * player.Speed, player.Rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.LeftShift) && player.CanDash)
        {
            SwitchState(factory.Dash());
        }
        else if (player.IsSeeingGround)
        {
            SwitchState(factory.WallSlide());
        }
        else if (player.Rb.velocity.y < .1f)
        {
            SwitchState(factory.Fall());
        }
    }

    public override void ExitState()
    {

    }

    public override void InitializeSubState()
    {

    }
}
