using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatStateManager : EnemiesStateManager
{
    public override void Start()
    {
        CurrentState = State.BatIdle();
        CurrentState.EnterState();
    }

    public override void Update()
    {
        base.Update();
        PlayerCheck();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            CurrentState = State.BatGotHit();
            CurrentState.EnterState();
        }
    }
}
