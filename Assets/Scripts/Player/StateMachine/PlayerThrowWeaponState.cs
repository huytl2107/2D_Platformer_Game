using System.Collections;
using UnityEngine;

public class PlayerThrowWeaponState : PlayerBaseState
{
    public PlayerThrowWeaponState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }

    public override void EnterState()
    {
        player.Anim.SetInteger("State", (int)StateEnum.EPlayerState.throwWeapon);
        player.ThrowAxe();
    }

    public override void UpdateState()
    {
        CheckSwitchState();
    }

    public override void CheckSwitchState()
    {
        player.StartCoroutine(WaitBeforeSwitchState());
    }

    public override void ExitState()
    {

    }

    private IEnumerator WaitBeforeSwitchState()
    {
        player.CanMove();
        yield return new WaitForSeconds(.15f);
        if (player.IsGrounded())
        {
            if (player.DirX != 0)
            {
                SwitchState(factory.Run());
            }
            else
            {
                SwitchState(factory.Idle());
            }
        }
        else
        {
            SwitchState(factory.Fall());
        }
    }

    public override void FixedUpdateState()
    {

    }
}
