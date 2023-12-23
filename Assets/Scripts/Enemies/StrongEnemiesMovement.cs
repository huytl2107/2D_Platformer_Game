using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongEnemiesMovement : MonoBehaviour
{
    [SerializeField] EnemiesRaycast leftRaycast;
    [SerializeField] EnemiesRaycast rightRaycast;
    [SerializeField] private float speed = 3f;
    [SerializeField] private AudioSource dangerSound;
    [SerializeField] LayerMask ground;
    [SerializeField] EnemiesDeath enemiesDeath;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private Animator anim;
    private int move = -1;
    private bool isStartedRunning = false;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        enemiesDeath = GetComponent<EnemiesDeath>();
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
                rb.velocity = new Vector2(move * speed * 2, rb.velocity.y);
                isStartedRunning = true;
            }
            if (rightRaycast.seePlayer && move == -1)
            {
                sprite.flipX = true;
                move = 1;
                anim.SetBool("State", true);
                rb.velocity = new Vector2(move * speed * 2, rb.velocity.y);
                isStartedRunning = true;

            }
            else
            {
                anim.SetBool("State", true);
                rb.velocity = new Vector2(move * speed * 2, rb.velocity.y);
                isStartedRunning = true;
            }
        }
        else if (isStartedRunning)
        {
            rb.velocity = new Vector2(move * speed * 2, rb.velocity.y);
            Invoke("StopRunning", 1.5f);
        }
        else
        {
            anim.SetBool("State", false);
            rb.velocity = new Vector2(move * speed, rb.velocity.y);
        }

        if(enemiesDeath.Death())
        {
            rb.bodyType = RigidbodyType2D.Static;
            Debug.Log("Enemy Death");
        };

    }
    void StopRunning()
    {
        isStartedRunning = false;
    }
}
