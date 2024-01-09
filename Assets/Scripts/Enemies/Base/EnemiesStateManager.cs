using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemiesStateManager : MonoBehaviour
{
    private EnemiesBaseState _currentState;

    private BoxCollider2D _col;
    private SpriteRenderer _sprite;
    private Rigidbody2D _rb;
    
    [Header("Speed")]
    private float _walkSpeed = 3f;

    [Header("Raycast")]
    private RaycastHit2D _raycastGround;
    private float _raycastDirX = 1;
    [SerializeField] private float _distanceWallCheck = 2f;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private LayerMask _ignoreLayer;

    public EnemiesBaseState CurrentState { get => _currentState; set => _currentState = value; }
    
    public float WalkSpeed { get => _walkSpeed; set => _walkSpeed = value; }
    
    public RaycastHit2D RaycastGround { get => _raycastGround; set => _raycastGround = value; }
    public float DistanceWallCheck { get => _distanceWallCheck; set => _distanceWallCheck = value; }
    public LayerMask Ground { get => _ground; set => _ground = value; }
    public LayerMask IgnoreLayer { get => _ignoreLayer; set => _ignoreLayer = value; }
    public float RaycastDirX { get => _raycastDirX; set => _raycastDirX = value; }
    public BoxCollider2D Col { get => _col; set => _col = value; }
    public SpriteRenderer Sprite { get => _sprite; set => _sprite = value; }
    public Rigidbody2D Rb { get => _rb; set => _rb = value; }

    public abstract void SwitchState(EnemiesBaseState enemyState);

    public virtual void Awake()
    {
        Col = GetComponent<BoxCollider2D>();
        Sprite = GetComponent<SpriteRenderer>();
        Rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Update()
    {
        WallCheck();
    }

    public void WallCheck()
    {
        if (RaycastDirX > 0)
        {
            RaycastGround = Physics2D.Raycast(Col.bounds.center, Vector2.right, DistanceWallCheck, Ground, ~IgnoreLayer);
            RaycastCheck();
        }
        else if (RaycastDirX < 0)
        {
            RaycastGround = Physics2D.Raycast(Col.bounds.center, Vector2.left, DistanceWallCheck, Ground, ~IgnoreLayer);
            RaycastCheck();
        }
    }
    public void RaycastCheck()
    {
        if (RaycastGround.collider != null && RaycastGround.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Debug.Log("SeeGround");
            Debug.DrawLine(transform.position, RaycastGround.point, Color.white);
            FlipXObject();
        }
    }

    public void FlipXObject()
    {
        Sprite.flipX = !Sprite.flipX;
        RaycastDirX = -RaycastDirX;
    }

}
