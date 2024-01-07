using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Animator _anim;
    private Rigidbody2D _rb;
    private BoxCollider2D _col;
    private bool _isHeadStomped = false;
    private int _lives = 3;
    public int _pushDir = -1;
    public bool _gotHit = false;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource gotHitSound;

    [Header("UI")]
    [SerializeField] private Image head1Image;
    [SerializeField] private Image head2Image;
    [SerializeField] private Image head3Image;
    [SerializeField] private Sprite head;
    [SerializeField] private Sprite nullHead;
    
    
    public int Lives { get => _lives; set => _lives = value; }
    public bool IsHeadStomped { get => _isHeadStomped; set => _isHeadStomped = value; }

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<BoxCollider2D>();
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
                _pushDir = -1;
            }
            else
            {
                _pushDir = 1;
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
                _pushDir = -1;
            }
            else
            {
                _pushDir = 1;
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
        _gotHit = true;
        Invoke("setFalseGotHit", .5f);
        gotHitSound.Play();
        _rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
        Lives -= 1;
        _anim.SetBool("Hit", true);
    }
    private void Die(){
        deathSoundEffect.Play();
        _anim.SetTrigger("death");
        _col.isTrigger = true;
        _rb.bodyType = RigidbodyType2D.Static;
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
        _anim.SetBool("Hit", false);
    }
    private void setFalseGotHit()
    {
        _gotHit = false;
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
