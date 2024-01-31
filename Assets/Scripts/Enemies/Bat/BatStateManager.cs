using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatStateManager : EnemiesStateManager
{
    public override void Start()
    {
        CurrentState = State.BatIdle();
        CurrentState.EnterState();
    }

    public override void Update()
    {
        base.Update();
        PlayerCheck();
    }

    public override void GotHit()
    {
        CurrentState = State.BatGotHit();
        CurrentState.EnterState();
    }
}
