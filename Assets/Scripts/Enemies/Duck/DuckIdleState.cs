using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckIdleState : EnemiesIdleState
{
    public DuckIdleState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.EDuckState.idle);
    }
    public override void UpdateState()
    {
        base.UpdateState();
        enemy.Rb.velocity = new Vector2(0f,enemy.Rb.velocity.y);
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
        if (enemy.SeePlayer)
        {
            SwitchState(factory.DuckRun());
        }
    }
}
