using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D col;
    public bool isHeadStomped = false;
    [SerializeField] private AudioSource deathSoundEffect;

    public global::System.Boolean IsHeadStomped { get => isHeadStomped; set => isHeadStomped = value; }

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Trap") || col.gameObject.CompareTag("WeakEnemies") || col.gameObject.CompareTag("StrongEnemies"))
        {
            Die();
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("WeakEnemies") || col.gameObject.CompareTag("StrongEnemies"))
        {
            IsHeadStomped = true;
        }
        if(col.gameObject.CompareTag("TriggerTrap"))
        {
            Die();
        }
    }

    private void Die(){
        deathSoundEffect.Play();
        anim.SetTrigger("death");
        col.isTrigger = true;
        rb.bodyType = RigidbodyType2D.Static;
    }
    private void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
