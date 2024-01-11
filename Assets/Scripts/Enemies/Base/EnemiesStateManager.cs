using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemiesStateManager : MonoBehaviour
{
    private EnemiesBaseState _currentState;
    private EnemiesStateFactory _state;

    private BoxCollider2D _col;
    private SpriteRenderer _sprite;
    private Rigidbody2D _rb;
    private Animator _anim;
    [Header("FlipXObject")]
    [SerializeField] private bool _flipObject = false;

    [Header("Speed")]
    [SerializeField] private float _walkSpeed = 3f;

    [Header("Health")]
    [SerializeField] private int _health = 0;

    [Header("Raycast")]
    [SerializeField] private float _distance = 5f;
    [SerializeField] private LayerMask _ignoreLayerSelf;
    private RaycastHit2D _raycast;
    private float _raycastDirX = 1;
    private bool _seePlayer = false;

    [Header("Raycast Ground")]
    [SerializeField] private float _distanceWallCheck = 2f;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private LayerMask _ignoreLayer;
    private RaycastHit2D _raycastGround;
    private bool _seeGround = false;

    public EnemiesBaseState CurrentState { get => _currentState; set => _currentState = value; }

    public float WalkSpeed { get => _walkSpeed; set => _walkSpeed = value; }

    public RaycastHit2D RaycastGround { get => _raycastGround; set => _raycastGround = value; }
    public float DistanceWallCheck { get => _distanceWallCheck; set => _distanceWallCheck = value; }
    public LayerMask Ground { get => _ground; set => _ground = value; }
    public LayerMask IgnoreLayer { get => _ignoreLayer; set => _ignoreLayer = value; }
    public RaycastHit2D Raycast { get => _raycast; set => _raycast = value; }
    public float Distance { get => _distance; set => _distance = value; }
    public LayerMask IgnoreLayerSelf { get => _ignoreLayerSelf; set => _ignoreLayerSelf = value; }
    public bool SeePlayer { get => _seePlayer; set => _seePlayer = value; }

    public float RaycastDirX { get => _raycastDirX; set => _raycastDirX = value; }
    public BoxCollider2D Col { get => _col; set => _col = value; }
    public SpriteRenderer Sprite { get => _sprite; set => _sprite = value; }
    public Rigidbody2D Rb { get => _rb; set => _rb = value; }
    public Animator Anim { get => _anim; set => _anim = value; }
    public EnemiesStateFactory State { get => _state; set => _state = value; }
    public bool SeeGround { get => _seeGround; set => _seeGround = value; }
    public int Health { get => _health; set => _health = value; }
    public bool FlipObject { get => _flipObject; set => _flipObject = value; }

    public virtual void Awake()
    {
        State = new EnemiesStateFactory(this);
        Col = GetComponent<BoxCollider2D>();
        Sprite = GetComponent<SpriteRenderer>();
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        if(FlipObject)
        {
            FlipXObject();
        }
    }

    public abstract void Start();

    public virtual void Update()
    {
        CurrentState.UpdateState();
        WallCheck();
    }

    public void WallCheck()
    {
        if (RaycastDirX > 0)
        {
            RaycastGround = Physics2D.Raycast(Col.bounds.center, Vector2.right, DistanceWallCheck, Ground, ~IgnoreLayer);
            Raycast = Physics2D.Raycast(Col.bounds.center, Vector2.right, Distance, ~IgnoreLayerSelf);
            RaycastCheckGround();
        }
        else if (RaycastDirX < 0)
        {
            RaycastGround = Physics2D.Raycast(Col.bounds.center, Vector2.left, DistanceWallCheck, Ground, ~IgnoreLayer);
            Raycast = Physics2D.Raycast(Col.bounds.center, Vector2.left, Distance, ~IgnoreLayerSelf);
            RaycastCheckGround();
        }
    }

    public void PlayerCheck()
    {
        if (RaycastDirX > 0)
        {
            Raycast = Physics2D.Raycast(Col.bounds.center, Vector2.right, Distance, ~IgnoreLayerSelf);
            RaycastCheckPlayer();
        }
        else if (RaycastDirX < 0)
        {
            Raycast = Physics2D.Raycast(Col.bounds.center, Vector2.left, Distance, ~IgnoreLayerSelf);
            RaycastCheckPlayer();
        }
    }
    public void RaycastCheckGround()
    {
        if (RaycastGround.collider != null && RaycastGround.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Debug.Log("SeeGround");
            Debug.DrawLine(transform.position, RaycastGround.point, Color.white);
            SeeGround = true;
        }
        else
        {
            SeeGround = false;
        }
    }

    public void RaycastCheckPlayer()
    {
        if (Raycast.collider != null && Raycast.collider.gameObject.name == "Player")
        {
            SeePlayer = true;
        }
        else
        {
            SeePlayer = false;
        }
    }

    public void FlipXObjectIfSeeGround()
    {
        if (SeeGround)
        {
            FlipXObject();
        }
    }
    public void FlipXObject()
    {
        Sprite.flipX = !Sprite.flipX;
        RaycastDirX = -RaycastDirX;
    }

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(Col.bounds.center, Col.bounds.size, 0f, Vector2.down, .1f, Ground);
    }

}
