using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadishIdleState : EnemiesIdleState
{
    public RadishIdleState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.ERadishState.idle);
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
        if(enemy.IsGrounded())
        {
            SwitchState(factory.RadishWalk());
        }
    }
}
