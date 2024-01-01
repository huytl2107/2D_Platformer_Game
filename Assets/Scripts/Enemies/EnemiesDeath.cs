using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesDeath : MonoBehaviour
{
    protected Animator anim;
    protected bool death = false;
    protected bool gotHit = false;
    protected Rigidbody2D rb;
    protected BoxCollider2D col;
    protected SpriteRenderer sprite;
    protected bool canAttack = true;
    private int pushDir = -1;

    // Start is called before the first frame update
    protected void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
    }
    protected void Update()
    {
        GotHitEffect();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.gameObject.name == "Player") || col.CompareTag("Weapon"))
        {
            float distanceX = col.gameObject.transform.position.x - transform.position.x;
            if(distanceX > 0)
            {
                pushDir = -1;
            }
            else
            {
                pushDir = 1;
            }
            Debug.Log("Va chạm");
            Death();
        }
    }
    private void OnCollisionEnter2D(Collision2D col) 
    {
        if (col.gameObject.CompareTag("Trap"))
        {
            float distanceX = col.gameObject.transform.position.x - transform.position.x;
            if(distanceX > 0)
            {
                pushDir = -1;
            }
            else
            {
                pushDir = 1;
            }
            Death();
        }
    }

    protected void Death()
    {
        if (canAttack)
        {
            anim.SetTrigger("Death");
            death = true;
            col.isTrigger = true;
            rb.AddForce(Vector2.up * 3f, ForceMode2D.Impulse);
            Invoke("Destroy", 1f);
            Debug.Log("Death");
        }
    }
    protected void Destroy()
    {
        Destroy(gameObject);
        death = false;
    }
    protected void GotHitEffect()
    {
        if(death || gotHit)
        {
            rb.velocity = new Vector2(pushDir*6, rb.velocity.y);
        }
    }
}
