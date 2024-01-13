using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatIdleState : EnemiesIdleState
{
    public BatIdleState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.EBatState.idle);
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
        if(enemy.SeePlayer)
        {
            SwitchState(factory.BatCellingOut());
        }
    }
}
