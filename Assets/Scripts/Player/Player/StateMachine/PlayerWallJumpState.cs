using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerWallJumpState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Hello from Wall Jump State");
        player.Rb.velocity = new Vector2(player.Rb.velocity.x, player.JumpForce);
        player.Anim.SetInteger("State", (int)StateEnum.EPlayerState.wallJump);
    }

    public override void OnCollisionEnter2D(PlayerStateManager player)
    {

    }

    public override void UpdateState(PlayerStateManager player)
    {
        if(player.Rb.velocity.y < player.JumpForce/2)
        {
            player.SwitchState(player.JumpState);
        }
        else if(player.RaycastDirX > 0)
        {
            player.Rb.velocity = new Vector2(-player.Speed , player.Rb.velocity.y);
        }
        else
        {
            player.Rb.velocity = new Vector2(player.Speed , player.Rb.velocity.y);
        }
    }
}
