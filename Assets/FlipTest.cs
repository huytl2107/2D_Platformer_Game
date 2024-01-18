using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipTest : MonoBehaviour
{
    public RaycastHit2D raycast;
    BoxCollider2D col;
    public LayerMask ignoreLayer;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        transform.rotation = Quaternion.Euler(0,180,0);
    }

    // Update is called once per frame
    void Update()
    {
        raycast = Physics2D.Raycast(col.bounds.center, Vector2.right, 5f);
        Debug.DrawLine(col.bounds.center, raycast.point, Color.red, ~ignoreLayer);
    }
}
