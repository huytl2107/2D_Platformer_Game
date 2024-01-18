using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundAheadCheck : MonoBehaviour
{
    BoxCollider2D col;
    EnemiesStateManager enemiesStateManager;
    private bool _isOverlappingGround = true;

    public bool IsOverlappingGround { get => _isOverlappingGround; set => _isOverlappingGround = value; }

    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        enemiesStateManager = transform.parent.GetComponent<EnemiesStateManager>();
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Ground"))
        {
            IsOverlappingGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Ground"))
        {
            IsOverlappingGround = true;
        }
    }
}
