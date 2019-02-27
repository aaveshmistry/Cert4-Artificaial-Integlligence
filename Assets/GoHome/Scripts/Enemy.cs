using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform waypointParent;
    public float moveSpeed = 2f;
    public float stoppingDistance = 1f;
    
    public Transform[] waypoints;
    private int currentIndex = 1;

    private NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        // Get the children form WaypointParent
        waypoints = waypointParent.GetComponentsInChildren<Transform>();

        // Get the AI component
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Run Patrol Every Frame
        Patrol();
    }

   void OnDrawGizmosSelected()
    {
        // If waypoint is not null AND waypoint is not empty
        if (waypoints != null && waypoints.Length > 0)
        {
            // Get current waypoint
            Transform point = waypoints[currentIndex];
            // Draw line from position to waypoint
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, point.position);
            // Draw stopping distance sphere
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(point.position, stoppingDistance);
        }
    }
    void Patrol()
    {
        // 1 - Get the current waypoint
        Transform point = waypoints[currentIndex];

        // 2 - Get distance from waypoint
        float distance = Vector3.Distance(transform.position, point.position);

        // 3 - If distance is less than stopping distance
        if (distance < stoppingDistance)
        {
            // 4 -  Move to next waypoint
            currentIndex++; // currentIndex = currentIndex + 1;
            // 4.1 - If currentIndex >= waypoints.Length
            if (currentIndex >= waypoints.Length)
            {
                //      4.2 - Set currentIndex to 1
                currentIndex = 1;
            }
        }

        // 5 - Translate Enemy towards current waypoint
        //transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed * Time.deltaTime);
        //transform.LookAt(point.position);
        agent.SetDestination(point.position);
    }
}
