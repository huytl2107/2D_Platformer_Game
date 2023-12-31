using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongEnemiesMovement : MonoBehaviour
{
    [SerializeField] protected float speed = 3f;
    [SerializeField] private float flyingSpeed = 5f;
    [SerializeField] protected float delayRun = 3f;
    protected Rigidbody2D rb;
    protected Animator anim;
    [SerializeField] protected LayerMask Wall;
    protected float move = -1;
    [SerializeField] protected AudioSource dangerSound;
    protected bool dangerSoundPlaying = false;
    protected bool isStartedRunning = false;
    protected bool canFlip = true;
    protected SpriteRenderer sprite;
    
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    protected void ChangeAudioSound()
    {
        if(isStartedRunning && !dangerSoundPlaying)
        {
            dangerSound.Play();
            dangerSoundPlaying = true;
        }
        if(!isStartedRunning && dangerSoundPlaying)
        {
            dangerSound.Stop();
            dangerSoundPlaying = false;
        }
    }
    protected void Running()
    {
        rb.velocity = new Vector2(move * speed * 2, rb.velocity.y);
        isStartedRunning = true;
    }
    protected void Walking()
    {
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        isStartedRunning = false;
    }
    protected void DelayRunning()
    {
        rb.velocity = new Vector2(move* speed * 2, rb.velocity.y);
        Debug.Log("Delay run");
        Invoke("StopRunning", delayRun);
    }
    protected void StopRunning()
    {
        isStartedRunning = false;
        rb.velocity = new Vector2(0f, rb.velocity.y);
    }
    protected void Flying()
    {
        rb.velocity = new Vector2(rb.velocity.x , flyingSpeed);
    }
    protected void StopFlying()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
    }
    protected void Destroy()
    {
        Destroy(gameObject);
    }
    protected void CanFlipTrue()
    {
        canFlip = true;
    }

}
