using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Hello from Jump State");
        player.Anim.SetInteger("State", (int)StateEnum.EPlayerState.jump);
        player.Rb.velocity = new Vector2(player.Rb.velocity.x, player.JumpForce);
    }

    public override void OnCollisionEnter2D(PlayerStateManager player)
    {

    }

    public override void UpdateState(PlayerStateManager player)
    {
        player.DirX = Input.GetAxisRaw("Horizontal");
        player.Rb.velocity = new Vector2(player.DirX * player.Speed, player.Rb.velocity.y);
        if(player.IsSeeingGround)
        {
            Debug.Log(player.IsSeeingGround);
            player.SwitchState(player.WallSlideState);
        }
        else
        {
            if (player.Rb.velocity.y < .1f)
        {
            player.SwitchState(player.FallState);
        }
        else if(Input.GetButtonDown("Jump"))
        {
            player.IsDoubleJump = true;
            player.SwitchState(player.DoubleJumpState);
        }
        }
        PlayerStateManager.UpdateObjectDirX(player);
    }
}
