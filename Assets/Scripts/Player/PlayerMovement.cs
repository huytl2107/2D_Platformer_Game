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
    public float DirX { get => dirX; set => dirX = value; }
    private float horizontal = 1;
    private bool isDoubleJump = false;
    [SerializeField] private float moveSpeed = 7;
    public float MoveSpeed {get => moveSpeed; set => moveSpeed = value; }
    [SerializeField] private float jumpForce = 8;
    [SerializeField] private LayerMask jumpableGround;
    private enum movementState { idle, running, jumping, falling, doubleJump, wallJump, throwAxe };
    movementState state;
    [SerializeField] private AudioSource jumpSoundEffect;
    private StickyWall stickyWall;
    private PlayerLife playerLife;
    private bool jumpOnStickyWall = false;
    private bool canMove = true;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        stickyWall = GetComponent<StickyWall>();
        playerLife = GetComponent<PlayerLife>();
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateAnimationState();
        if(!canMove)
        {
            return;
        }
        DirX = Input.GetAxisRaw("Horizontal");
        if(DirX != 0)
        {
            horizontal = DirX;
        }
        if(!jumpOnStickyWall)
        {
        rb.velocity = new Vector2(DirX * moveSpeed, rb.velocity.y);
        }
        if(playerLife.isHeadStomped)
        {
            playerLife.isHeadStomped = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSoundEffect.Play();
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                isDoubleJump = false;
                //Jump
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpSoundEffect.Play();
            }
            else if (stickyWall.isWallJump)
            {
                isDoubleJump = false;
                jumpOnStickyWall = true;
                //Jump
                rb.velocity = new Vector2(-DirX*6f, jumpForce);
                jumpSoundEffect.Play();
            }
            else if (!isDoubleJump)
            {
                isDoubleJump = true;
                jumpOnStickyWall = false;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpSoundEffect.Play();
            }
        }
        if(playerLife.gotHit)
        {
            rb.velocity = new Vector2(-horizontal * moveSpeed/2, rb.velocity.y);
        }
    }

    private void UpdateAnimationState()
    {
        if (DirX > 0f && canMove)
        {
            state = movementState.running;
            sprite.flipX = false;
        }
        else if (DirX < 0f && canMove)
        {
            state = movementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = movementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            if (!isDoubleJump)
            {
                state = movementState.jumping;
            }
            else
            {
                state = movementState.doubleJump;
            }
            if(rb.velocity.y < 4f)
            {
                jumpOnStickyWall = false;
            }
        }
        else if (rb.velocity.y < -.1f)
        {
            state = movementState.falling;
        }
        if(stickyWall.isWallJump)
        {
            state = movementState.wallJump;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            state = movementState.throwAxe;
        }

        anim.SetInteger("state", (int)state);
    }


    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    private void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.CompareTag("NPC"))
        {
            rb.velocity = Vector2.zero;
            canMove = false;
        }
    }
    private void OnTriggerExit2D(Collider2D col) 
    {
        canMove = true;
    }

}
