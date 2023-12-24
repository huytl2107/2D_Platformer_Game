using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RinoMovement : MonoBehaviour
{
    [SerializeField] private EnemiesRaycast enemiesRaycast;
    [SerializeField] private float speed = 3f;
    [SerializeField] LayerMask ground;
    [SerializeField] EnemiesDeath enemiesDeath;
    private Rigidbody2D rb;
    private bool isStartedRunning = false;
    private enum state {idle, running, hitwall};
    state currentState;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemiesDeath = GetComponent<EnemiesDeath>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        enemiesRaycast.RaycastCheck();
        if(enemiesRaycast.seePlayer && !isStartedRunning)
        {
            rb.velocity = new Vector2(-1 * speed * 2, rb.velocity.y);
            isStartedRunning = true;
            currentState = state.running;
        }
        else if (isStartedRunning)
        {
            rb.velocity = new Vector2(-1* speed * 2, rb.velocity.y);
            Invoke("StopRunning", 3f);
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
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        anim.SetInteger("State", (int)currentState);
    }
    private void StopRunning()
    {
        isStartedRunning = false;
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }

}
