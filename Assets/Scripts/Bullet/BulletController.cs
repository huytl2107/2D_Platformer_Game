using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField] private float speed = 1f;
    [SerializeField] private float _rightAngle = -45;
    [SerializeField] private float _leftAngle = 135;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;

    private float direction = 1; // Mặc định là bên phải
    public void SetDirection(float dir)
    {
        direction = dir;
        transform.rotation = Quaternion.Euler(0, 0, (direction > 0) ? _rightAngle : _leftAngle);
    }

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.right * speed * direction;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.name == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
