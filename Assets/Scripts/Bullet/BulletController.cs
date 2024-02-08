using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField] protected float speed = 1f;
    [SerializeField] protected float _rightAngle = -45;
    [SerializeField] protected float _leftAngle = 135;
    protected bool _isRight = false;
    protected SpriteRenderer sprite;
    protected Rigidbody2D rb;

    protected float direction = 1; // Mặc định là bên phải
    public void SetDirection(float dir)
    {
        direction = dir;
        transform.rotation = Quaternion.Euler(0, 0, (direction > 0) ? _rightAngle : _leftAngle);
    }

    protected void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected void FixedUpdate()
    {
        rb.velocity = Vector2.right * speed * direction;
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.name == "Player")
        {
            _isRight = (rb.velocity.x < 0);
            //rb.velocity.x < 0 => Viên đạn đang di chuyển về bên trái
            //=> Hướng mảnh đạn văng sẽ là bên phải
            gameObject.SetActive(false);
            SpawnPiece();
        }
    }

    public virtual void SpawnPiece()
    {
        SoundManager.Instant.PlaySound(GameEnum.ESound.bulletHit);
    }
}
