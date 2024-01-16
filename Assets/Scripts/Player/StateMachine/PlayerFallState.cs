using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public PlayerFallState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }

    public override void EnterState()
    {
        player.Rb.gravityScale = 11f;
        player.Anim.SetInteger("State", (int)StateEnum.EPlayerState.fall);
        player.Anim.SetBool("GotHit", false);
    }

    public override void UpdateState()
    {
        player.CanMove();
        CheckSwitchState();
        PlayerStateManager.UpdateObjectDirX(player);
        if(player.Rb.velocity.y <= -25f)
        {
            player.Rb.velocity = new Vector2(player.Rb.velocity.x, -25f);
        }
    }

    public override void CheckSwitchState()
    {
        if (player.IsSeeingGround)
        {
            SwitchState(factory.WallSlide());
        }
        else if (Input.GetKeyDown(player.DashKey) && player.CanDash)
        {
            SwitchState(factory.Dash());
        }
        else if (Input.GetKeyDown(player.ThrowWeaponKey) && player.CanThrowWeapon)
        {
            SwitchState(factory.ThrowWeapon());
        }
        else if (Input.GetKeyDown(player.ThrowWeaponKey) && player.CurrentWeapon != null)
        {
            player.transform.position = player.CurrentWeapon.transform.position;
            player.DestroyObject(player.CurrentWeapon);
            player.CurrentWeapon = null;
            player.Rb.velocity = new Vector2(player.Rb.velocity.x, 0f);
            SwitchState(factory.Fall());
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
        player.Rb.gravityScale = 9f;
    }
}
