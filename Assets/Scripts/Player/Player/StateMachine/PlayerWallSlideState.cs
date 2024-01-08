using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerWallSlideState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Hello from Wall Slide State");

        //Đặt velocity.x = 0 để hạn chế bug Dash xuyên tường
        player.Rb.velocity = new Vector2(0f, player.Rb.velocity.y);
        player.Anim.SetInteger("State", (int)StateEnum.EPlayerState.wallSlide);
    }

    public override void OnCollisionEnter2D(PlayerStateManager player)
    {

    }

    public override void UpdateState(PlayerStateManager player)
    {
        player.DirX = Input.GetAxisRaw("Horizontal");
        if ((player.DirX > 0 && player.RaycastDirX < 0) || (player.DirX < 0 && player.RaycastDirX > 0))
        {
            player.SwitchState(player.FallState);
        }
        else if (Input.GetButtonDown("Jump"))
        {
            player.SwitchState(player.WallJumpState);
        }
        else
        {
            player.Rb.velocity = new Vector2(player.DirX, player.Rb.velocity.y / 1.5f);
        }
    }
}
