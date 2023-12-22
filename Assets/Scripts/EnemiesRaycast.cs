using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesRaycast : MonoBehaviour
{
    [SerializeField] float distance = 5f;
    [SerializeField] bool right = false;
    RaycastHit2D hit, hitground;
    public bool seePlayer, seeGround;
    // Start is called before the first frame update
    public void RaycastCheck()
    {
        Vector2 rayDirection = right ? Vector2.right : Vector2.left;
        hit = Physics2D.Raycast(transform.position, rayDirection, distance);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                seePlayer = true;
                Debug.DrawLine(transform.position, hit.point, Color.white);
            }
            else
            {
                seePlayer = false;
            }
        }
        else
        {
           seePlayer = false;
        }
        hitground = Physics2D.Raycast(transform.position, rayDirection, 2f);
        if (hitground.collider != null)
        {
            if (hitground.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                seeGround = true;
                Debug.DrawLine(transform.position, hitground.point, Color.white);
                Debug.Log("See Ground");
            }
            else
            {
                seeGround = false;
            }
        }
        else
        {
            seeGround = false;
        }
    }
}
