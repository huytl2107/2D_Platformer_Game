using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] protected GameObject[] waypoints;
    private int currenWaypointIndex = 0;
    [SerializeField] protected float speed = 4f;
    // Update is called once per frame
    private void Update()
    {
        FollowWaypoints();
    }
    protected void FollowWaypoints()
    {
        if (Vector2.Distance(waypoints[currenWaypointIndex].transform.position, transform.position) < .1f)
        {
            currenWaypointIndex++;
            if (currenWaypointIndex >= waypoints.Length)
            {
                currenWaypointIndex = 0;
            }
            if (waypoints.Length == 1)
            {
                Destroy(gameObject);
                return;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currenWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
