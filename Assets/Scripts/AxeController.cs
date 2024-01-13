using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour
{

    [SerializeField] private float speed = 1f;
    private float x = 7;
    private float y = 0;
    private float dirX = 0;
    private SpriteRenderer sprite;

    private float direction = 1; // Mặc định là bên phải
    public void SetDirection(float dir)
    {
        direction = dir;
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(DestroyWeapon());
        if (direction > 0) { transform.Rotate(0,0,-45f); }
        else { transform.Rotate(0,0,135f); }
    }

    private void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");
        x += speed;
        //y = -(1f / 180f) * (x * x);
        y = 0f;
        if (dirX != 0)
        {
            transform.position += new Vector3(direction * x + dirX * 7, y, 0) * Time.deltaTime;
        }
        else
        {
            transform.position += new Vector3(direction * x, y, 0) * Time.deltaTime;
        }
        if (transform.position.y < -50f)
        {
            Destroy(gameObject);
        }
    }
    private IEnumerator DestroyWeapon()
    {
        yield return new WaitForSeconds(.75f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
