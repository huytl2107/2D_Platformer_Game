using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class EnemiesStateManager : MonoBehaviour
{
    private EnemiesBaseState _currentState;
    private EnemiesStateFactory _state;

    private BoxCollider2D _col;
    private SpriteRenderer _sprite;
    private Rigidbody2D _rb;
    private Animator _anim;
    private Vector2 _firstPosition;

    private  PlayerStateManager _player;
    [SerializeField] private bool _flipObject = false;

    [Header("Speed")]
    [SerializeField] private float _walkSpeed = 3f;

    [Header("Health")]
    [SerializeField] private int _health = 0;

    [Header("Raycast")]
    [SerializeField] private float _distance = 5f;
    [SerializeField] private float _angleRaycast = 0f;
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
    public float AngleRaycast { get => _angleRaycast; set => _angleRaycast = value; }
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
    public PlayerStateManager Player { get => _player; set => _player = value; }
    public Vector2 FirstPosition { get => _firstPosition; set => _firstPosition = value; }

    public virtual void Awake()
    {
        State = new EnemiesStateFactory(this);
        Col = GetComponent<BoxCollider2D>();
        Sprite = GetComponent<SpriteRenderer>();
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        FirstPosition = transform.position;
        Player = FindObjectOfType<PlayerStateManager>();
        if (FlipObject)
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
        Vector2 rayDirection;
        rayDirection = (RaycastDirX > 0) ? Vector2.right : Vector2.left;
        RaycastGround = Physics2D.Raycast(Col.bounds.center, rayDirection, DistanceWallCheck, ~IgnoreLayer);
        RaycastCheckGround();
    }
    public void PlayerCheck()
    {
        Vector2 rayDirection;
        if (AngleRaycast == 0)
        {
            rayDirection = (RaycastDirX > 0) ? Vector2.right : Vector2.left;
        }
        else
        {
            rayDirection = Quaternion.Euler(0, 0, AngleRaycast) * Vector2.right;
        }
        Raycast = Physics2D.Raycast(Col.bounds.center, rayDirection, Distance, ~IgnoreLayer);
        RaycastCheckPlayer();
        Debug.DrawLine(Col.bounds.center, Raycast.point, Color.white);
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

    public bool IsRightPlayer()
    {
        if (Player != null)
        {
            float distancetoPlayer = transform.position.x - Player.transform.position.x;
            if (distancetoPlayer > 0)
            {
                return true;
            }
            return false;
        }
        return false;
    }

    public void LookAtFirstPosition()
    {
        if (FirstPosition != null)
        {
            float distanceToFirstPosition = transform.position.x - FirstPosition.x;
            if(distanceToFirstPosition > 0)
            {
                Sprite.flipX = false;
            }
            else
            {
                Sprite.flipX = true;
            }
        }
    }

    public void LookAtPlayer()
    {
        if (FlipObject)
        {
            if (IsRightPlayer())
            {
                Sprite.flipX = false;
            }
            else
            {
                Sprite.flipX = true;
            }
        }
        else
        {
            if (IsRightPlayer())
            {
                Sprite.flipX = true;
            }
            else
            {
                Sprite.flipX = false;
            }
        }
    }
}
