using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RinoMovement : StrongEnemiesMovement
{
    [SerializeField] private EnemiesRaycast enemiesRaycast;
    private enum state {idle, running, hitwall};
    state currentState;

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        move = enemiesRaycast.right ? 1: -1;
        enemiesRaycast.RaycastCheck();
        if(enemiesRaycast.seePlayer && !isStartedRunning)
        {
            Running();
            currentState = state.running;
        }
        else if (isStartedRunning)
        {
            DelayRunning();
        }

        else
        {
            currentState = state.idle;
        }

        //Set enim Death
        if(enemiesDeath.isDeath())
        {
            rb.bodyType = RigidbodyType2D.Static;
        }

        if(enemiesRaycast.seeGround)
        {
            currentState = state.hitwall;
            Debug.Log("Hit wall");
            Invoke("Destroy", 1f);
            rb.velocity = new Vector2(-1*  move * speed, rb.velocity.y);
        }
        anim.SetInteger("State", (int)currentState);
        ChangeAudioSound();
    }
}
