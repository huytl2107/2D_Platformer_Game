using UnityEngine;

public class PlayerRunState : PlayerBaseState
{

    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Hello from Run State");
        player.Anim.SetInteger("State", (int)StateEnum.EPlayerState.run);
    }

    public override void OnCollisionEnter2D(PlayerStateManager player)
    {

    }

    public override void UpdateState(PlayerStateManager player)
    {
        player.DirX = Input.GetAxisRaw("Horizontal");
        if (player.IsGrounded())
        {
            if (Input.GetButtonDown("Jump"))
            {
                player.SwitchState(player.JumpState);
            } else if(Input.GetKeyDown(KeyCode.LeftShift) && player.CanDash)
            {
                player.SwitchState(player.DashState);
            }
            else if (player.DirX == 0)
            {
                player.SwitchState(player.IdleState);
            }
            else
            {
                player.Rb.velocity = new Vector2(player.DirX * player.Speed, player.Rb.velocity.y);
            }
        }
        else if(player.Rb.velocity.y < .1f)
        {
            player.SwitchState(player.FallState);
        }
        PlayerStateManager.UpdateObjectDirX(player);
    }
}
