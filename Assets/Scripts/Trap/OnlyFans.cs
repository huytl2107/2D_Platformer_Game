using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyFans : MonoBehaviour
{
    [SerializeField] private float fanForce = 10f;

    private void OnTriggerStay2D(Collider2D other)
    {
        // Kiểm tra xem đối tượng có component Rigidbody không
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Lấy hướng từ quạt đến đối tượng
            Vector2 direction = (other.transform.position - transform.position).normalized;

            // Áp dụng lực dựa trên hướng gió và tốc độ hiện tại của đối tượng
            rb.AddForce(direction * fanForce * rb.velocity.magnitude);
        }
    }
}
