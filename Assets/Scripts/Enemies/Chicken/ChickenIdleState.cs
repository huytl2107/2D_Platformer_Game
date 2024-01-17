using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenIdleState : EnemiesIdleState
{
    public ChickenIdleState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.EChickenState.idle);
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
        if(enemy.SeePlayer)
        {
            SwitchState(factory.ChickenRun());
        }
    }
}
