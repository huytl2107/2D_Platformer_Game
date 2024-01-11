using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdIdleState : EnemiesIdleState
{
    public BirdIdleState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
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
            SwitchState(factory.BirdAttack());
        }
    }
}
