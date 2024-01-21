using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }

    public override void EnterState()
    {
        player.Anim.SetInteger("State", (int)StateEnum.EPlayerState.idle);
        player.Rb.velocity = new Vector2(0f, player.Rb.velocity.y);
    }

    public override void UpdateState()
    {
        CheckSwitchState();
    }

    public override void CheckSwitchState()
    {
        player.DirX = Input.GetAxisRaw("Horizontal");
        if (player.IsGrounded())
        {
            if (Input.GetButtonDown("Jump"))
            {
                player.Dust.Play();
                player.Rb.AddForce(Vector2.up * player.JumpForce, ForceMode2D.Impulse);
                SwitchState(factory.Jump());
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
            }
            else if (Input.GetKeyDown(player.DashKey) && player.CanDash)
            {
                SwitchState(factory.Dash());
            }
            else if (player.DirX != 0)
            {
                SwitchState(factory.Run());
            }
        }
        else if (player.Rb.velocity.y < .1f)
        {
            SwitchState(factory.Fall());
        }
    }

    public override void ExitState()
    {

    }

    public override void FixedUpdateState()
    {
    }
}
