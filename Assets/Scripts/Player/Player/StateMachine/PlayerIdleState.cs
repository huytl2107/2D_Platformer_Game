using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Hello from Idle State");
        player.Anim.SetInteger("State", (int)StateEnum.EPlayerState.idle);
        player.Rb.velocity = new Vector2(0f, player.Rb.velocity.y);
    }

    public override void OnCollisionEnter2D(PlayerStateManager player)
    {

    }

    public override void UpdateState(PlayerStateManager player)
    {
        player.DirX = Input.GetAxisRaw("Horizontal");
        if(player.IsGrounded())
        {
            if(Input.GetButtonDown("Jump"))
            {
                player.SwitchState(player.JumpState);
            }
            else if(Input.GetKeyDown(KeyCode.LeftShift) && player.CanDash)
            {
                player.SwitchState(player.DashState);
            }
            else if(player.DirX !=0)
            {
                player.SwitchState(player.RunState);
            }
        }
        else if(player.Rb.velocity.y <.1f)
        {
            player.SwitchState(player.FallState);
        }
    }
}
