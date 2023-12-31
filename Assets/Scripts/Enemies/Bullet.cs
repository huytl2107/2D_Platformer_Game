using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    [SerializeField] public bool right = false;
    [SerializeField] private bool down = false;
    [SerializeField] public float shootAngle = 0f;
    private float moveDir;
    // Update is called once per frame
    private void Update()
    {
        if (shootAngle != 0)
        {
            //Xoay góc viên đạn
            Quaternion rotation = Quaternion.Euler(0f, 0f, shootAngle);
            transform.rotation = rotation;

            float angleRad = shootAngle * 3.14f / 180;
            float moveX = Mathf.Cos(angleRad) * speed * Time.deltaTime;
            float moveY = Mathf.Sin(angleRad) * speed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x + moveX, transform.position.y + moveY, transform.position.z);
            Invoke("Destroy", 4f);
        }
        else
        {
            moveDir = right ? 1 : -1;
            if (!down)
            {
                transform.position = new Vector3(transform.position.x + moveDir * speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
            }
            Invoke("Destroy", 4f);
        }
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            Destroy();
        }
    }
    public float GetSpeed()
    {
        return speed;
    }
}
