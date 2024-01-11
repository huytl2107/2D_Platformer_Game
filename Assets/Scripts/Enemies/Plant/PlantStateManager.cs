using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantStateManager : EnemiesStateManager
{
    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        CurrentState = State.PlantIdle();
        CurrentState.EnterState();
    }

    public override void Update()
    {
        base.Update();
        PlayerCheck();
    }
}
