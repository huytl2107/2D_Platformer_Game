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
    public float Horizontal { get => horizontal; set => horizontal = value; }
    private bool isDoubleJump = false;
    [SerializeField] private float moveSpeed = 7;
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    [SerializeField] private float jumpForce = 8;
    [SerializeField] private LayerMask jumpableGround;
    private enum movementState { idle, running, jumping, falling, doubleJump, wallJump, throwAxe, dash };
    movementState state;
    [SerializeField] private AudioSource jumpSoundEffect;
    private PlayerLife playerLife;
    private bool jumpOnStickyWall = false;
    public bool isWallJump = false;
    private bool canMove = true;
    [SerializeField] private ParticleSystem moveEffect;
    [SerializeField] private PlayerRaycast playerRaycast;

    private bool canDash = true;
    private bool isDashing = false;
    private float dashPower = 30f;
    private float dashTime = .2f;
    private float dashCooldown = 1f;
    [SerializeField] private TrailRenderer tr;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        playerLife = GetComponent<PlayerLife>();
    }

    // Update is called once per frame
    private void Update()
    {
        RayCastUpdate();
        if (isWallJump)
        {
            SlideWall();
            return;
        }
        if (isDashing)
        {
            anim.SetInteger("state", (int)movementState.dash);
            rb.velocity = new Vector2(Horizontal * transform.localScale.x * dashPower, 0f);
            return;
        }
        if ((Input.GetKeyDown(KeyCode.LeftShift) && canDash))
        {
            Debug.Log("Dash");
            StartCoroutine(Dash());
        }
        UpdateAnimationState();
        GotHitEffect();
        if (!canMove)
        {
            return;
        }
        DirX = Input.GetAxisRaw("Horizontal");
        if (DirX != 0)
        {
            horizontal = DirX;
            if (IsGrounded())
            {
                moveEffect.Play();
                float angle = (DirX > 0) ? -25 : -155;
                Transform effectTrans = moveEffect.transform;
                effectTrans.rotation = Quaternion.Euler(angle, -90, -90);
            }
            else
            {
                moveEffect.Stop();
            }
        }
        else
        {
            moveEffect.Stop();
        }
        if (!jumpOnStickyWall)
        {
            rb.velocity = new Vector2(DirX * moveSpeed, rb.velocity.y);
        }
        if (playerLife.isHeadStomped)
        {
            playerLife.isHeadStomped = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSoundEffect.Play();
        }
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
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
            if (rb.velocity.y < 4f)
            {
                jumpOnStickyWall = false;
            }
        }
        else if (rb.velocity.y < -.1f)
        {
            state = movementState.falling;
        }
        if (Input.GetKeyDown(KeyCode.J) && canMove)
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
        if (col.gameObject.CompareTag("NPC"))
        {
            rb.velocity = Vector2.zero;
            canMove = false;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        canMove = true;
    }
    public bool CanMove()
    {
        return canMove;
    }
    private void Jump()
    {
        if (IsGrounded())
        {
            isDoubleJump = false;
            //Jump
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSoundEffect.Play();
        }
        else if (isWallJump)
        {
            isDoubleJump = false;
            jumpOnStickyWall = true;
            //Jump
            rb.velocity = new Vector2(-DirX * 6f, jumpForce);
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
    private void GotHitEffect()
    {
        if (playerLife.gotHit)
        {
            canMove = false;
            rb.velocity = new Vector2(playerLife.pushDir * moveSpeed, rb.velocity.y);
        }
        else
        {
            canMove = true;
        }
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originialGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        tr.emitting = false;
        rb.gravityScale = originialGravity;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
    private void RayCastUpdate()
    {
        playerRaycast.right = (horizontal > 0) ? true : false;
        playerRaycast.RaycastCheck();
        if(playerRaycast.seeGround)
        {
            isWallJump = true;
        }
        else
        {
            isWallJump = false;
        }
    }
    private void SlideWall()
    {
        anim.SetInteger("state", (int)movementState.wallJump);
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y/1.5f);
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }
}
