using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakEnemiesMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currenWaypointIndex = 0;
    [SerializeField] private float speed = 3f;
    [SerializeField] EnemiesDeath enemiesDeath;
    private SpriteRenderer sprite;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        enemiesDeath = GetComponent<EnemiesDeath>();
    }
    // Update is called once per frame
    private void Update()
    {
        if (enemiesDeath.isDeath())
        { }
        else
        {
            if (Vector2.Distance(waypoints[currenWaypointIndex].transform.position, transform.position) < .1f)
            {
                currenWaypointIndex++;
                sprite.flipX = false;
                if (currenWaypointIndex >= waypoints.Length)
                {
                    currenWaypointIndex = 0;
                    sprite.flipX = true;
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currenWaypointIndex].transform.position, Time.deltaTime * speed);
        }
    }
}