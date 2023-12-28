using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesDeath : MonoBehaviour
{
    private Animator anim;
    private bool death = false;
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (gameObject.tag == "WeakEnemies")
        {
            if (death)
            {
                if(sprite.flipX)
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
                if(sprite.flipX)
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.gameObject.name == "Player") || col.CompareTag("Weapon"))
        {
            Debug.Log("Va chạm");
            anim.SetTrigger("Death");
            Death();
        }
    }

    private void Death()
    {
        death = true;
        col.isTrigger = true;
        rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
        Invoke("Destroy", 1f);
    }
    private void Destroy()
    {
        Destroy(gameObject);
        death = false;
    }
}
