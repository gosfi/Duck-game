﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public bool start = false;

    public Transform[] waypoints;
    public int speed;

    public int waypointIndex;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            distance = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
            if (distance < 1)
            {
                IncreaseIndex();
            }
            Patrolling();
        }
    }

    void Patrolling()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void IncreaseIndex()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].position);
    }
}
