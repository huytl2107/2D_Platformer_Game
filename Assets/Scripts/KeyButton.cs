using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyButton : MonoBehaviour
{
    [SerializeField] private KeyCode _key;
    private Rigidbody2D rb;
    private BoxCollider2D col;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        rb.bodyType = RigidbodyType2D.Static;
        col.isTrigger = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(_key))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 3f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("DeathZone"))
        {
            Invoke("Destroy", 1f);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }


}
