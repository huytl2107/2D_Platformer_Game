using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkStateManager : EnemiesStateManager
{
    public override void Awake()
    {
        base.Awake();
        FlipXObject();
    }
    public override void Start()
    {
        CurrentState = State.TrunkWalk();
        CurrentState.EnterState();
    }

    public override void Update()
    {
        base.Update();
        PlayerCheck();
        FlipXObjectIfSeeGround();
    }

}
