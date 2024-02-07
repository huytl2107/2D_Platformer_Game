using UnityEngine;

public class PlayerDoubleJumpState : PlayerBaseState
{
    public PlayerDoubleJumpState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }

    public override void EnterState()
    {
        SoundManager.Instant.PlaySound(GameEnum.ESound.jump);
        player.Anim.SetInteger("State", (int)StateEnum.EPlayerState.doubleJump);
        player.Rb.velocity = new Vector2(player.Rb.velocity.x, player.JumpForce);
    }

    public override void UpdateState()
    {
        CheckSwitchState();
        PlayerStateManager.UpdateObjectDirX(player);
    }

    public override void FixedUpdateState()
    {
        player.CanMove();
    }

    public override void CheckSwitchState()
    {
        if (Input.GetKeyDown(player.DashKey) && player.CanDash)
        {
            SwitchState(factory.Dash());
        }
        else if (player.IsSeeingGround)
        {
            SwitchState(factory.WallSlide());
        }
        //Tạm bỏ tính năng này vì chưa biết để làm gì :v
        //else if (Input.GetKeyDown(player.ThrowWeaponKey) && player.CanThrowWeapon)
        //{
        //    SwitchState(factory.ThrowWeapon());
        //}
        else if (Input.GetKeyDown(player.ThrowWeaponKey) && player.CurrentWeapon != null)
        {
            player.transform.position = player.CurrentWeapon.transform.position;
            player.DestroyObject(player.CurrentWeapon);
            player.CurrentWeapon = null;
            player.Rb.velocity = new Vector2(player.Rb.velocity.x, 0f);
            SwitchState(factory.Fall());
        }
        else if (player.Rb.velocity.y < .1f)
        {
            SwitchState(factory.Fall());
        }
    }

    public override void ExitState()
    {

    }
}
