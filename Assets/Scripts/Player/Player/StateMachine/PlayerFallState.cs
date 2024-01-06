using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Hello from Fall State");
        player.Anim.SetInteger("State", (int)StateEnum.EPlayerState.fall);
    }

    public override void OnCollisionEnter2D(PlayerStateManager player)
    {

    }

    public override void UpdateState(PlayerStateManager player)
    {
        player.DirX = Input.GetAxisRaw("Horizontal");
        player.Rb.velocity = new Vector2(player.DirX * player.Speed, player.Rb.velocity.y);
        if (player.IsSeeingGround)
        {
            player.SwitchState(player.WallSlideState);
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && player.CanDash)
        {
            player.SwitchState(player.DashState);
        }
        else if (player.IsGrounded())
        {
            player.IsDoubleJump = false;
            if (player.DirX == 0)
            {
                player.SwitchState(player.IdleState);
            }
            else
            {
                player.SwitchState(player.RunState);
            }
        }
        else if (Input.GetButtonDown("Jump") && !player.IsDoubleJump)
        {
            player.IsDoubleJump = true;
            player.SwitchState(player.DoubleJumpState);
        }
        PlayerStateManager.UpdateObjectDirX(player);
    }
}
