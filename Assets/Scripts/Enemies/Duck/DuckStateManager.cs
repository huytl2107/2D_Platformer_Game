using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckStateManager : EnemiesStateManager
{
    public override void Start()
    {
        CurrentState = State.DuckIdle();
        CurrentState.EnterState();
    }

    public override void Update()
    {
        Debug.Log(SeePlayer);
        base.Update();
        PlayerCheck();
    }
}
