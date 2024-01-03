using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private float distance = 5f;
    [SerializeField] public bool right = false;
    RaycastHit2D hitground;
    public bool seeGround;
    public LayerMask ignoreLayer;
    // Start is called before the first frame update
    public void RaycastCheck()
    {
        Vector2 rayDirection = right ? Vector2.right : Vector2.left;
        hitground = Physics2D.Raycast(transform.position, rayDirection, distance, ~ignoreLayer);
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
