using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyRunState : EnemiesWalkState
{
    public BunnyRunState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.EBunnyState.run);
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
        if(Math.Abs(enemy.DistanceToPlayer()) < 4f)
        {
            SwitchState(factory.BunnyJump());
        }
    }
}
