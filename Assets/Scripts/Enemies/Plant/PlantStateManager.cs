using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantStateManager : EnemiesStateManager
{
    public override void Awake()
    {
        base.Awake();
        FlipXObject();
        PlantIdle = new PlantIdleState(this);
        PlantAttack = new PlantAttackState(this);
    }

    private void Start()
    {
        CurrentState = PlantIdle;
        CurrentState.EnterState();
    }

    public override void Update()
    {
        base.Update();
        PlayerCheck();
    }
}
