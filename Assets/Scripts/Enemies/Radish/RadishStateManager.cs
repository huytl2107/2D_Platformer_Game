using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadishStateManager : EnemiesStateManager
{
    public RadishStateManager()
    {
    }

    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        CurrentState = State.RadishFly();
        CurrentState.EnterState();
    }

    public override void Update()
    {
        base.Update();
        HandleGroundDetection();
    }

    public override void GotHit()
    {
        CurrentState = State.RadishGotHit();
        CurrentState.EnterState();
    }
}
