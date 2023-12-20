using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyWall : MonoBehaviour
{
    public bool isWallJump = false;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("StickyWall"))
        {
            isWallJump = true;
        }
    } 
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("StickyWall"))
        {
            isWallJump = false;
        }
    } 
}
