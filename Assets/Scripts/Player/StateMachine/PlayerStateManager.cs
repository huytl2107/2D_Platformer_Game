using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

//Sử dụng State Manager để quản lý các State của Player giúp tách biệt các hành vi
//giúp làm cho hệ thống linh hoạt và dễ bảo trì hơn
public class PlayerStateManager : MonoBehaviour
{
    //Khởi tạo các state
    PlayerBaseState _currentState;
    PlayerStateFactory _state;

    private SpriteRenderer _sprite;
    private Rigidbody2D _rb;
    private Collider2D _col;
    private Animator _anim;
    private Transform _myTransform;

    [Header("Move and Jump")]
    [SerializeField] private float _speed = 8f;
    [SerializeField] private float _jumpForce = 8f;

    [Header("Dash")]
    [SerializeField] private float _dashForce = 20f;
    [SerializeField] private float _dashTime = .2f;
    [SerializeField] private float _dashCooldown = 1f;
    [SerializeField] private TrailRenderer tr;
    private bool _canDash = true;
    private bool _isDashing = false;

    [Header("Weapon")]
    [SerializeField] private GameObject _weapon;
    [SerializeField] private float _plusXWeapon;
    [SerializeField] private float _plusYWeapon;
    private bool _canThrowWeapon = true;
    private GameObject _currentWeapon;

    [Header("Raycast")]
    [SerializeField] private float _distanceWallCheck = 2f;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private LayerMask _ignoreLayer;

    [Header("Sound Effect")]
    [SerializeField] private AudioSource _gotHitSound;

    [Header("ItemCollector")]
    [SerializeField] private Text _fruitText;
    private int _fruitNumb = 0;
    
    [Header("Button")]
    [SerializeField] private KeyCode _throwWeaponKey = KeyCode.J;
    [SerializeField] private KeyCode _dashKey = KeyCode.LeftShift;

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
    public Transform MyTransform { get => _myTransform; set => _myTransform = value; }

    public AudioSource GotHitSound { get => _gotHitSound; set => _gotHitSound = value; }

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
    
    public PlayerBaseState CurrentState { get => _currentState; set => _currentState = value; }
    public PlayerStateFactory State { get => _state; set => _state = value; }
    
    public KeyCode ThrowWeaponKey { get => _throwWeaponKey; set => _throwWeaponKey = value; }
    public KeyCode DashKey { get => _dashKey; set => _dashKey = value; }
    public bool CanThrowWeapon { get => _canThrowWeapon; set => _canThrowWeapon = value; }
    public GameObject CurrentWeapon { get => _currentWeapon; set => _currentWeapon = value; }

    // Start is called before the first frame update
    private void Awake()
    {
        State = new PlayerStateFactory(this);
        tr.emitting = false;
        Rb = GetComponent<Rigidbody2D>();
        Sprite = GetComponent<SpriteRenderer>();
        Col = GetComponent<BoxCollider2D>();
        Anim = GetComponent<Animator>();
        
        PlayerHealthController.Instane.UpdatePlayerHealthUI();
    }

    void Start()
    {
        CurrentState = State.Idle();
        CurrentState.EnterState();
    }

    // Update is called once per frame
    void Update()
    {
        WallCheck();
        CurrentState.UpdateState();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Trap"))
        {
            CurrentState = State.GotHit();
            CurrentState.EnterState();
        }    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Apple"))
        {
            _fruitNumb += 1;
            _fruitText.text = "Fruit: " + _fruitNumb;
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Enemies"))
        {
            CurrentState = State.Jump();
            CurrentState.EnterState();
        }
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
        if (DirX != 0) { RaycastDirX = DirX; }
        if (RaycastDirX > 0)
        {
            Raycast = Physics2D.Raycast(Col.bounds.center, Vector2.right, DistanceWallCheck, Ground, ~IgnoreLayer);
            RaycastCheck();
        }
        else if (RaycastDirX < 0)
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

    public void ThrowAxe()
    {
        StartCoroutine(CoolDownThrowWeapon());
        Vector3 weaponPosition = new Vector3(transform.position.x + _plusXWeapon * RaycastDirX, transform.position.y + _plusYWeapon , transform.position.z);
        CurrentWeapon = Instantiate(_weapon, weaponPosition, transform.rotation);

        AxeController axeController = CurrentWeapon.GetComponent<AxeController>();
        axeController.SetDirection(RaycastDirX);
    }

    public IEnumerator CoolDownThrowWeapon()
    {
        CanThrowWeapon = false;
        yield return new WaitForSeconds(1f);
        CanThrowWeapon = true;
    }

    public void CanMove()
    {
        DirX = Input.GetAxisRaw("Horizontal");
        Rb.velocity = new Vector2(DirX * Speed, Rb.velocity.y);
    }

    public void DestroyObject (GameObject objectToDestroy)
    {
        Destroy(objectToDestroy);
    }
}
