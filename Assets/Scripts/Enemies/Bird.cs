using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : WaypointFollower
{
    [SerializeField] private RaycastOnlyPlayer raycast;
    private bool seenPlayer;
    private void Update()
    {
        raycast.RaycastCheck();
        if(raycast.seePlayer)
        {
            seenPlayer = true;
        }
        if(seenPlayer)
        {
            FollowWaypoints();
        }
    }
    private void OnCollisionEnter2D(Collision2D col) {
        Destroy(gameObject);
    }
}

