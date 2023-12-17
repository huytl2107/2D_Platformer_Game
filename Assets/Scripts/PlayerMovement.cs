using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    private Animator anim;
    private float dirX = 0;
    [SerializeField] private float moveSpeed = 7;
    [SerializeField] private float jumpForce = 7;
    [SerializeField] private LayerMask jumpableGround;
    private enum movementState{idle, running, jumping, falling};   
    
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX*moveSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {   
            //Jump
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        movementState state;
        if(dirX > 0f)
        {
            state = movementState.running;
            sprite.flipX = false;
        } else if(dirX < 0f)
        {
            state = movementState.running;
            sprite.flipX = true;
        } else
        {
            state = movementState.idle;
        }
        
        if(rb.velocity.y > .1f)
        {
            state = movementState.jumping;
        } else if(rb.velocity.y < -.1f)
        {
            state = movementState.falling;
        }

        anim.SetInteger("state",(int)state);
    }

    private bool IsGrounded(){
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround); 
    }
    
}
