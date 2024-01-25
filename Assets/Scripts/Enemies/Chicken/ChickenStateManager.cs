using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenStateManager : EnemiesStateManager
{
    public override void Start()
    {
        CurrentState = State.ChickenIdle();
        CurrentState.EnterState();
    }

    public override void Update()
    {
        base.Update();
        PlayerCheck();
    }


    public override void GotHit()
    {
        CurrentState = State.ChickenGotHit();
        CurrentState.EnterState();
    }

}
