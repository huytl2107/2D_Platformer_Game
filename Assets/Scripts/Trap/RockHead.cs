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
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale *= 3f;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.CompareTag("Ground"))
        {
           Invoke("Destroy", 1f);
        }
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
