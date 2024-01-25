using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyStateManager : EnemiesStateManager
{

    public override void Start()
    {
        CurrentState = State.BunnyIdle();
        CurrentState.EnterState();
    }

    public override void Update()
    {
        base.Update();
        PlayerCheck();
        HandleGroundDetection();
    }

    public override void GotHit()
    {
        //
    }

    public override void HandleGroundDetection()
    {
        if (SeeGround)
        {
            FlipXObject();
        }
    }
}
