using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NhismStateManager : EnemiesStateManager
{
    public override void Start()
    {
        CurrentState = State.NhismNonSpikes();
        CurrentState. EnterState();
    }

    public override void Update()
    {
        base.Update();
        FlipXObjectIfSeeGround();
    }

        private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            CurrentState = State.NhismGotHit();
            CurrentState.EnterState();
        }
    }
}
