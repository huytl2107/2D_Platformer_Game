using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RinoIdleState : EnemiesIdleState
{
    public RinoIdleState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
        if(enemy.SeePlayer)
        {
            SwitchState(factory.RinoAttack());
        }
    }
}
