using UnityEngine;

public class PlayerDashState : PlayerBaseState
{
    public PlayerDashState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }

    public override void EnterState()
    {
        SoundManager.Instant.PlaySound(GameEnum.ESound.dashSound);
        player.StartCoroutine(player.Dash(player));
        player.Rb.gravityScale = 0f;
        player.Anim.SetInteger("State", (int)StateEnum.EPlayerState.dash);
    }

    public override void UpdateState()
    {
        CheckSwitchState();
    }

    public override void FixedUpdateState()
    {

    }

    public override void CheckSwitchState()
    {
        player.DirX = Input.GetAxisRaw("Horizontal");
        //Kiểm tra nếu thấy Tường thì ngay lập tức chuyển sang WallSlideState
        if (player.IsSeeingGround && player.IsDashing)
        {
            SwitchState(factory.WallSlide());
        }
        else if (player.IsDashing)
        {
            player.Rb.velocity = new Vector2(player.RaycastDirX * player.DashForce, 0);
        }
        else if (player.Rb.velocity.y < .1f)
        {
            SwitchState(factory.Fall());
        }
        else if (player.DirX != 0)
        {
            SwitchState(factory.Run());
        }
        else
        {
            SwitchState(factory.Idle());
        }
    }
    public override void ExitState()
    {
        player.Rb.gravityScale = 9f;
    }
}
