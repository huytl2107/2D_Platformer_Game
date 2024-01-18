using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChameleonStateManager : EnemiesStateManager
{
    public ChameleonStateManager()
    {
    }

    public override void Start()
    {
        CurrentState = State.ChameleonIdle();
        CurrentState.EnterState();
    }

    public override void Update()
    {
        base.Update();
        HandleGroundDetection();
        PlayerCheck();
    }
}
