using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastOnlyPlayer : MonoBehaviour
{
    [SerializeField] float distance = 10f;
    [SerializeField] public bool right = false;
    [SerializeField] public float rayDirectionAngle = 0f;
    RaycastHit2D hit;
    public bool seePlayer;
    // Start is called before the first frame update
    public void RaycastCheck()
    {
        Vector2 rayDirection;
        if(rayDirectionAngle != 0)
        {
        rayDirection = Quaternion.Euler(0, 0, rayDirectionAngle) * Vector2.right;
        }
        else
        {
        rayDirection = right ? Vector2.right : Vector2.left;
        }
        hit = Physics2D.Raycast(transform.position, rayDirection, distance);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                seePlayer = true;
                Debug.Log("See Player");
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
