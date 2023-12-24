using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigMovement : StrongEnemiesMovement
{
    [SerializeField] EnemiesRaycast leftRaycast;
    [SerializeField] EnemiesRaycast rightRaycast;
    private SpriteRenderer sprite;
    
    protected override void Start()
    {
        base.Start();
        sprite = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    private void Update()
    {
        leftRaycast.RaycastCheck();
        rightRaycast.RaycastCheck();
        if (leftRaycast.seeGround)
        {
            move = 1;
            sprite.flipX = true;
        }
        if (rightRaycast.seeGround)
        {
            move = -1;
            sprite.flipX = false;
        }
        if ((leftRaycast.seePlayer || rightRaycast.seePlayer) && !isStartedRunning)
        {
            if (leftRaycast.seePlayer && move == 1)
            {
                sprite.flipX = false;
                move = -1;
                anim.SetBool("State", true);
                Running();
            }
            if (rightRaycast.seePlayer && move == -1)
            {
                sprite.flipX = true;
                move = 1;
                anim.SetBool("State", true);
                Running();
            }
            else
            {
                anim.SetBool("State", true);
                Running();
            }
        }
        else if (isStartedRunning)
        {
            DelayRunning();
        }
        else
        {
            anim.SetBool("State", false);
            Walking();
        }
        if(enemiesDeath.isDeath())
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
        ChangeAudioSound();

    }


}
