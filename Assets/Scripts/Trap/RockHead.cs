using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHead : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask ground;
    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.name == "Player")
        {
            anim.SetBool("State", true);
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale *= 3f;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.CompareTag("Ground"))
        {
            SoundManager.Instant.PlaySound(GameEnum.ESound.hitGroundSound);
            rb.AddForce(Vector2.up * 7f, ForceMode2D.Impulse);
            anim.SetTrigger("Death");
            Invoke("Destroy", .5f);
        }
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
