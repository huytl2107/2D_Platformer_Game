using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatfom : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Player")
        {
            col.gameObject.transform.SetParent(transform);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.name == "Player")
        {
            col.gameObject.transform.SetParent(null);
        }
    }
}
