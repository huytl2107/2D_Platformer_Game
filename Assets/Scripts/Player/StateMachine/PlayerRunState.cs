using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }

    public override void EnterState()
    {
        player.Anim.SetInteger("State", (int)StateEnum.EPlayerState.run);
        player.SpawnDustEffcect();
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
        if (player.IsGrounded())
        {
            if (Input.GetButtonDown("Jump"))
            {
                player.SpawnDustEffcect();
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
            else if (player.DirX == 0)
            {
                SwitchState(factory.Idle());
            }
        }
        else if (player.Rb.velocity.y < -10f)
        {
            SwitchState(factory.Fall());
        }
    }

    public override void ExitState()
    {

    }
}
