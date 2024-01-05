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
    private bool isHeadStomped = false;
    private int lives = 3;
    public int pushDir = -1;
    public bool gotHit = false;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource gotHitSound;
    [SerializeField] private Image head1Image;
    [SerializeField] private Image head2Image;
    [SerializeField] private Image head3Image;
    [SerializeField] private Sprite head;
    [SerializeField] private Sprite nullHead;
    
    
    public int Lives { get => lives; set => lives = value; }
    public bool IsHeadStomped { get => isHeadStomped; set => isHeadStomped = value; }

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }
    private void Update() 
    {
        if(Lives > 3){Lives = 3;}
        UpdatePlayerLivesUI();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Trap") || col.gameObject.CompareTag("WeakEnemies") || col.gameObject.CompareTag("StrongEnemies"))
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
            DeathOrAlive();
            Debug.Log("Lives: " + Lives);
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
            float distanceX = col.gameObject.transform.position.x - transform.position.x;
            if(distanceX > 0)
            {
                pushDir = -1;
            }
            else
            {
                pushDir = 1;
            }
            DeathOrAlive();
            Debug.Log("Lives: " + Lives);
        }
        if(col.gameObject.CompareTag("LivesItem"))
        {
            Lives += 1;
        }
    }
    private void GotHit()
    {
        gotHit = true;
        Invoke("setFalseGotHit", .5f);
        gotHitSound.Play();
        rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
        Lives -= 1;
        anim.SetBool("Hit", true);
    }
    private void Die(){
        deathSoundEffect.Play();
        anim.SetTrigger("death");
        col.isTrigger = true;
        rb.bodyType = RigidbodyType2D.Static;
    }
    public void DeathOrAlive()
    {
        if(Lives>0)
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
    private void setFalseGotHit()
    {
        gotHit = false;
    }
    public void UpdatePlayerLivesUI()
    {
        switch (Lives)
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
