using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesRaycast : MonoBehaviour
{
    [SerializeField] private float distance = 5f;
    [SerializeField] private float distanceGround = 1.5f;
    [SerializeField] public bool right = false;
    RaycastHit2D hit, hitground;
    public bool seePlayer, seeGround;
    public LayerMask ignoreLayer;
    // Start is called before the first frame update
    public void RaycastCheck()
    {
        Vector2 rayDirection = right ? Vector2.right : Vector2.left;
        hit = Physics2D.Raycast(transform.position, rayDirection, distance, ~ignoreLayer);
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
        hitground = Physics2D.Raycast(transform.position, rayDirection, distanceGround, ~ignoreLayer);
        if (hitground.collider != null)
        {
            if (hitground.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                seeGround = true;
                Debug.DrawLine(transform.position, hitground.point, Color.white);
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
