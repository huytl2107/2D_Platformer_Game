using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesGotHitState : EnemiesBaseState
{
    public EnemiesGotHitState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }
    public override void EnterState()
    {
        Debug.Log("Hello from Got Hit State");
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        CheckSwitchState();
    }

    public override void CheckSwitchState()
    {

    }

}
