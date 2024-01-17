using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckRunState : EnemiesWalkState
{
    public DuckRunState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.EDuckState.run);
        enemy.FlipXObject();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
        if(enemy.SeeGround)
        {
            SwitchState(factory.DuckJump());
        }
    }
}
