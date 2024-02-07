using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Player")
        {
            StartCoroutine(FallAndDestroy());
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(0f, -10f);
    }

    private IEnumerator FallAndDestroy()
    {
        yield return new WaitForSeconds(1f);
        rb.bodyType = RigidbodyType2D.Kinematic;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}