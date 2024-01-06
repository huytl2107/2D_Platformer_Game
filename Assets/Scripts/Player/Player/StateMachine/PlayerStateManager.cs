using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    //Khởi tạo các state
    PlayerBaseState _currentState;
    public PlayerIdleState IdleState = new PlayerIdleState();
    public PlayerRunState RunState = new PlayerRunState();
    public PlayerJumpState JumpState = new PlayerJumpState();
    public PlayerFallState FallState = new PlayerFallState();
    public PlayerDoubleJumpState DoubleJumpState = new PlayerDoubleJumpState();
    public PlayerWallSlideState WallSlideState = new PlayerWallSlideState();
    public PlayerWallJumpState WallJumpState = new PlayerWallJumpState();
    public PlayerDashState DashState = new PlayerDashState();

    private SpriteRenderer _sprite;
    private Rigidbody2D _rb;
    private Collider2D _col;
    private Animator _anim;

    [Header("Move and Jump")]
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _jumpForce = 7f;

    [Header("Dash")]
    [SerializeField] private float _dashForce = 20f;
    [SerializeField] private float _dashTime = .2f;
    [SerializeField] private float _dashCooldown = 1f;
    [SerializeField] private TrailRenderer tr;
    private bool _canDash = true;
    private bool _isDashing = false;
   
    [Header("Raycast")]
    [SerializeField] private float _distanceWallCheck = 2f;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private LayerMask _ignoreLayer;

    private float _dirX;
    private float _raycastDirX = 1;
    private bool _isDoubleJump;
    private RaycastHit2D _raycast;
    private bool _isSeeingGround = false;

    public SpriteRenderer Sprite { get => _sprite; set => _sprite = value; }
    public Rigidbody2D Rb { get => _rb; set => _rb = value; }
    public LayerMask Ground { get => _ground; set => _ground = value; }
    public LayerMask IgnoreLayer { get => _ignoreLayer; set => _ignoreLayer = value; }
    public RaycastHit2D Raycast { get => _raycast; set => _raycast = value; }
    public Collider2D Col { get => _col; set => _col = value; }
    public Animator Anim { get => _anim; set => _anim = value; }

    public float Speed { get => _speed; set => _speed = value; }
    public float DirX { get => _dirX; set => _dirX = value; }
    public float JumpForce { get => _jumpForce; set => _jumpForce = value; }
    public bool IsDoubleJump { get => _isDoubleJump; set => _isDoubleJump = value; }
    public float DistanceWallCheck { get => _distanceWallCheck; set => _distanceWallCheck = value; }
    public bool IsSeeingGround { get => _isSeeingGround; set => _isSeeingGround = value; }
    public float RaycastDirX { get => _raycastDirX; set => _raycastDirX = value; }
    public bool CanDash { get => _canDash; set => _canDash = value; }
    public bool IsDashing { get => _isDashing; set => _isDashing = value; }
    public float DashForce { get => _dashForce; set => _dashForce = value; }

    // Start is called before the first frame update
    private void Awake() 
    {
        Rb = GetComponent<Rigidbody2D>();
        Sprite = GetComponent<SpriteRenderer>();
        Col = GetComponent<BoxCollider2D>();
        Anim = GetComponent<Animator>();
    }
    void Start()
    {
        _currentState = IdleState;
        _currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        WallCheck();
        _currentState.UpdateState(this);
    }
    public void SwitchState(PlayerBaseState state)
    {
        _currentState = state;
        state.EnterState(this);
    }

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(Col.bounds.center, Col.bounds.size, 0f, Vector2.down, .1f, Ground);
    }
    public static void UpdateObjectDirX(PlayerStateManager player)
    {
        switch (player.DirX)
        {
            case 1:
                player.Sprite.flipX = false;
                break;
            case -1:
                player.Sprite.flipX = true;
                break;
        }
    }
    public IEnumerator Dash(PlayerStateManager player)
    {
        IsDashing = true;
        CanDash = false;
        tr.emitting = true;
        yield return new WaitForSeconds(_dashTime);
        IsDashing = false;
        tr.emitting = false;
        yield return new WaitForSeconds(_dashCooldown);
        CanDash = true;
    }

    public void WallCheck()
    {
        if(DirX != 0) {RaycastDirX = DirX;}
        if(RaycastDirX > 0)
        {
            Raycast = Physics2D.Raycast(Col.bounds.center, Vector2.right, DistanceWallCheck, Ground, ~IgnoreLayer);
            RaycastCheck();
        }
        else if(RaycastDirX < 0)
        {
            Raycast = Physics2D.Raycast(Col.bounds.center, Vector2.left, DistanceWallCheck, Ground, ~IgnoreLayer);
            RaycastCheck();
        }
    }
    public void RaycastCheck()
{
    if (Raycast.collider != null && Raycast.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
    {
        Debug.DrawLine(transform.position, Raycast.point, Color.white);
        IsSeeingGround = true;
    }
    else
    {
        IsSeeingGround = false;
    }
}
}
