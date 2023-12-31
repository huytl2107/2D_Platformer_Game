using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radish : StrongEnemiesMovement
{
    private enum state{idle1, gothit, idle2, running};
    private EnemiesLife radishLife;
    private BoxCollider2D col;
    [SerializeField] private LayerMask ground;
    [SerializeField] private EnemiesRaycast raycast;
    private bool isRunning = false;
    private bool isFlying = false;
    private bool isCalled = false;
    protected override void Start()
    {
        base.Start();
        radishLife = GetComponent<EnemiesLife>();
        col = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        raycast.RaycastCheck();
        UpdateAnimation();
        if(IsGrounded() && !isCalled)
        {
            WaitAndRunning();
        }
        if(isRunning)
        {
            Running();
        }
        else
        {
            StopRunning();
        }
        if (raycast.seeGround && canFlip)
        {
            FlipObject();
        }
        if(isFlying)
        {
            Flying();
        }
    }
    private void UpdateAnimation()
    {
        if(radishLife.lives == 1)
        {
            anim.SetInteger("State",(int)state.idle1);
        }
    }
    private void SetAnimIdle2()
    {
        anim.SetInteger("State", (int)state.idle2);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, ground);
    }
    private void WaitAndRunning()
    {
        isCalled = true;
        Invoke("Run", 2f);
    }
    private void Run()
    {
        isRunning = true;
        anim.SetInteger("State", (int)state.running);
        Invoke("Fly", 2f);
    }
    private void Fly()
    {
        radishLife.lives += 1;
        Debug.Log(radishLife.lives);
        isRunning = false;
        rb.bodyType = RigidbodyType2D.Kinematic;
        isFlying = true;
        Invoke("ReturnIdle1", 3f);
    }
    private void ReturnIdle1()
    {
        isCalled = false;
        isFlying = false;
        rb.bodyType = RigidbodyType2D.Static;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    private void FlipObject()
    {
        sprite.flipX = !sprite.flipX;
        move = -move;
        raycast.right = !raycast.right;
        canFlip = false;
        Invoke("CanFlipTrue", 1f);
    }
}
