using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D col;
    public bool isHeadStomped = false;
    private int lives = 3;
    private float dirX = 1;
    private float horizontal = 0;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource gotHitSound;
    [SerializeField] private Image head1Image;
    [SerializeField] private Image head2Image;
    [SerializeField] private Image head3Image;
    [SerializeField] private Sprite head;
    [SerializeField] private Sprite nullHead;

    public global::System.Boolean IsHeadStomped { get => isHeadStomped; set => isHeadStomped = value; }

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }
    private void Update() 
    {
        dirX = Input.GetAxisRaw("Horizontal");
        if(dirX!=0)
        {
            horizontal = dirX;
        }
        if(lives > 3){lives = 3;}
        UpdatePlayerLivesUI();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Trap") || col.gameObject.CompareTag("WeakEnemies") || col.gameObject.CompareTag("StrongEnemies"))
        {
            DeathOrAlive();
            Debug.Log("Lives: " + lives);
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
            DeathOrAlive();
            Debug.Log("Lives: " + lives);
        }
    }
    private void GotHit()
    {
        gotHitSound.Play();
        rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
        lives -= 1;
        anim.SetBool("Hit", true);
    }
    private void Die(){
        deathSoundEffect.Play();
        anim.SetTrigger("death");
        col.isTrigger = true;
        rb.bodyType = RigidbodyType2D.Static;
    }
    private void DeathOrAlive()
    {
        if(lives>0)
        {
            GotHit();
        }
        else
        {
            Die();
        }
    }
    private void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void SetIdle()
    {
        anim.SetBool("Hit", false);
    }
    public void UpdatePlayerLivesUI()
    {
        switch (lives)
        {
            case 3:
                head1Image.sprite = head;
                head2Image.sprite = head;
                head3Image.sprite = head;
                break;
            case 2:
                head1Image.sprite = head;
                head2Image.sprite = head;
                head3Image.sprite = nullHead;
                break;
            case 1:
                head1Image.sprite = head;
                head2Image.sprite = nullHead;
                head3Image.sprite = nullHead;
                break;
            case 0:
                head1Image.sprite = nullHead;
                head2Image.sprite = nullHead;
                head3Image.sprite = nullHead;
                break;
        }
    }
}
