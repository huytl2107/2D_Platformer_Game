using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    [SerializeField] public bool right = false;
    private float moveDir;
    // Update is called once per frame
    private void Update()
    {
        moveDir = right ? 1 : -1;
        transform.position = new Vector3(transform.position.x + moveDir * speed * Time.deltaTime, transform.position.y, transform.position.z);
        Invoke("Destroy", 4f);
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
