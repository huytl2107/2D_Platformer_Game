using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyFallState : EnemiesWalkState
{
    public BunnyFallState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Rb.gravityScale = 11f;
        enemy.Anim.SetInteger("State", (int)StateEnum.EBunnyState.fall);
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
        if (enemy.IsGrounded())
        {
            SwitchState(factory.BunnyIdle());
        }
    }

    public override void ExitState()
    {
        enemy.Rb.gravityScale = 1f;
        base.ExitState();
    }
}
