using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongEnemiesMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private GameObject[] waypointsclone;
    private int currenWaypointIndex = 0;
    [SerializeField] private float speed = 3f;
    private SpriteRenderer sprite;
    private bool playerEnter = false;
    [SerializeField] private AudioSource dangerSound;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        waypointsclone = waypoints;
    }
    // Update is called once per frame
    private void Update()
    {
        if (playerEnter)
        {
            Vector3 targetPosition = new Vector3(waypoints[0].transform.position.x, transform.position.y, transform.position.z);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * 2 * speed);
            if(targetPosition.x - transform.position.x < 0)
            {
                sprite.flipX = false;
            }
            else
            {
                sprite.flipX = true;
            }
        }
        else
        {
            waypoints = waypointsclone;
            if(transform.position.x - waypoints[currenWaypointIndex].transform.position.x > 0)
            {
                sprite.flipX = false;
            }
            else
            {
                sprite.flipX = true;
            }
    
            if (Vector2.Distance(waypoints[currenWaypointIndex].transform.position, transform.position) < .1f)
            {
                currenWaypointIndex++;
                if (currenWaypointIndex >= waypoints.Length)
                {
                    currenWaypointIndex = 0;
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currenWaypointIndex].transform.position, Time.deltaTime * speed);

        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            dangerSound.Play();
            waypoints = null;
            waypoints = new GameObject[] { col.gameObject };
            playerEnter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            dangerSound.Stop();
            playerEnter = false;
        }
    }
}
