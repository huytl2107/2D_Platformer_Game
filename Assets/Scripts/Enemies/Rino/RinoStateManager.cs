using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RinoStateManager : EnemiesStateManager
{
    public override void Awake()
    {
        base.Awake();
    }
    public override void Start()
    {
        CurrentState = State.RinoIdle();
        CurrentState.EnterState();
    }

    public override void Update()
    {
        base.Update();
        PlayerCheck();
    }
}
