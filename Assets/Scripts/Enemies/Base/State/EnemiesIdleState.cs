using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesIdleState : EnemiesBaseState
{
    public EnemiesIdleState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void CheckSwitchState()
    {

    }

    public override void EnterState()
    {
        Debug.Log("Hello from Idle State");
        enemy.Rb.velocity = new Vector2(0f,0f);
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        CheckSwitchState();
    }
}
