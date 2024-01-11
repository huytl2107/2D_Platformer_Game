using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigStateManager : EnemiesStateManager
{
    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        CurrentState = State.PigWalk();
        CurrentState.EnterState();
    }

    public override void Update()
    {
        base.Update();
        FlipXObjectIfSeeGround();
        PlayerCheck();
    }
}
