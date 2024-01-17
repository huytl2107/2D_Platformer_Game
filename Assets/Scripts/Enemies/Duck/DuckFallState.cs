using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckFallState : EnemiesWalkState
{
    public DuckFallState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Rb.gravityScale = 11f;
        enemy.Anim.SetInteger("State", (int)StateEnum.EDuckState.fall);
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
            SwitchState(factory.DuckIdle());
        }
    }

    public override void ExitState()
    {
        enemy.FlipXObject();
        base.ExitState();
        enemy.Rb.gravityScale = 1f;
    }
}
