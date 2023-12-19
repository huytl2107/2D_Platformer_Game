using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currenWaypointIndex = 0;
    [SerializeField] private float speed = 4f;
    // Update is called once per frame
    private void Update()
    {
        if(Vector2.Distance(waypoints[currenWaypointIndex].transform.position, transform.position) < .1f)
        {
            currenWaypointIndex++;
            if(currenWaypointIndex >= waypoints.Length)
            {
                currenWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currenWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
