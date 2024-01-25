using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NhismStateManager : EnemiesStateManager
{
    public override void Start()
    {
        CurrentState = State.NhismNonSpikes();
        CurrentState.EnterState();
    }

    public override void Update()
    {
        base.Update();
        HandleGroundDetection();
    }

    public override void GotHit()
    {
        CurrentState = State.NhismGotHit();
        CurrentState.EnterState();
    }
}
