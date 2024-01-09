using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesIdleState : EnemiesBaseState
{
    public EnemiesIdleState(EnemiesStateManager currentContext) : base(currentContext)
    {
    }

    public override void CheckSwitchState()
    {

    }

    public override void EnterState()
    {
        Debug.Log("Hello from Idle State");
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {

    }
}
