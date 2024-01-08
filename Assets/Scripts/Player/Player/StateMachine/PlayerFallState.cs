using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public PlayerFallState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Hello from Fall State");
        player.Anim.SetInteger("State", (int)StateEnum.EPlayerState.fall);
        player.Anim.SetBool("GotHit", false);
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
        if (player.IsSeeingGround)
        {
            SwitchState(factory.WallSlide());
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && player.CanDash)
        {
            SwitchState(factory.Dash());
        }
        else if (player.IsGrounded())
        {
            player.IsDoubleJump = false;
            if (player.DirX == 0)
            {
                SwitchState(factory.Idle());
            }
            else
            {
                SwitchState(factory.Run());
            }
        }
        else if (Input.GetButtonDown("Jump") && !player.IsDoubleJump)
        {
            player.IsDoubleJump = true;
            SwitchState(factory.DoubleJump());
        }
    }

    public override void ExitState()
    {

    }

    public override void InitializeSubState()
    {

    }
}
