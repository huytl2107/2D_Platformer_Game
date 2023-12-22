using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastOnlyPlayer : MonoBehaviour
{
    [SerializeField] float distance = 10f;
    [SerializeField] bool right = false;
    RaycastHit2D hit;
    public bool seePlayer;
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
    }
}
