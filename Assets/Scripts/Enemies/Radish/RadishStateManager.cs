using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadishStateManager : EnemiesStateManager
{
    public RadishStateManager()
    {
    }

    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        CurrentState = State.RadishFly();
        CurrentState.EnterState();
    }

    public override void Update()
    {
        base.Update();
        FlipXObjectIfSeeGround();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.name == "Player")
        {
            Health -=1;
        }
    }
}
