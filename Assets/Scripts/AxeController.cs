using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour
{

    [SerializeField] private float speed = 2f;
    private float x = 0;
    private float y = 0;
    private float dirX = 0;
    private SpriteRenderer sprite;

    private float direction = 1; // Mặc định là bên phải
    public void SetDirection(float dir)
    {
        direction = dir;
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(direction > 0){sprite.flipX = false;}
        else {sprite.flipX = true;}
        
        dirX = Input.GetAxisRaw("Horizontal");
        x += speed;
        y = -(1f / 100f) * (x * x);
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
    private IEnumerator DestroyAfterDelay(GameObject objectToDestroy, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(objectToDestroy);
    }
}
