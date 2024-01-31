using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdStateManager : EnemiesStateManager
{
    public override void Start()
    {
        CurrentState = State.BirdIdle();
        CurrentState.EnterState();
    }

    public override void Update()
    {
        base.Update();
        PlayerCheck();
        HandleGroundDetection();
    }

    public override void HandleGroundDetection()
    {
    }

    public override void GotHit()
    {
        CurrentState = State.BirdGotHit();
        CurrentState.EnterState();
    }
}
