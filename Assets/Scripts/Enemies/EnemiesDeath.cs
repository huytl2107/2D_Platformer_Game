using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesDeath : MonoBehaviour
{
    protected Animator anim;
    protected bool death = false;
    protected Rigidbody2D rb;
    protected BoxCollider2D col;
    protected SpriteRenderer sprite;
    protected bool canKill = true;

    // Start is called before the first frame update
    protected void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        GotHitEffect();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.gameObject.name == "Player") || col.CompareTag("Weapon"))
        {
            Debug.Log("Va chạm");
            Death();
        }
    }
    private void OnCollisionEnter2D(Collision2D col) 
    {
        if (col.gameObject.CompareTag("Trap"))
        {
            Death();
        }
    }

    protected void Death()
    {
        if (canKill)
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
        if (gameObject.tag == "WeakEnemies")
        {
            if (death)
            {
                if (sprite.flipX)
                {
                    rb.velocity = new Vector2(-6, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(6, rb.velocity.y);
                }
            }
        }
        else if (gameObject.tag == "StrongEnemies")
        {
            if (death)
            {
                if (sprite.flipX)
                {
                    rb.velocity = new Vector2(-6, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(6, rb.velocity.y);
                }
            }
        }
    }
}
