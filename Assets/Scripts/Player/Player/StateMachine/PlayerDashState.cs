using UnityEngine;

public class PlayerDashState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Hello From Dash State");
        player.StartCoroutine(player.Dash(player));
        player.Anim.SetInteger("State", (int)StateEnum.EPlayerState.dash);
    }

    public override void OnCollisionEnter2D(PlayerStateManager player)
    {

    }

    public override void UpdateState(PlayerStateManager player)
    {
        player.DirX = Input.GetAxisRaw("Horizontal");
        //Kiểm tra nếu thấy Tường thì ngay lập tức chuyển sang WallSlideState
        if(player.IsSeeingGround && player.IsDashing)
        {
            player.SwitchState(player.WallSlideState);
        }
        else if(player.IsDashing)
        {
            player.Rb.velocity = new Vector2(player.RaycastDirX * player.DashForce, 0);
        }
        else if(player.Rb.velocity.y < .1f)
        {
            player.SwitchState(player.FallState);
        }
        else if(player.DirX !=0)
        {
            player.SwitchState(player.RunState);
        }
        else
        {
            player.SwitchState(player.IdleState);
        }
    }
}
