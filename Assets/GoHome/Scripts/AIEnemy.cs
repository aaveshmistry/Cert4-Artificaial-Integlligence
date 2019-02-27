using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    public Transform target;

    private NavMeshAgent agent; // Reference to NavMeshAgenet component

    private void Start()
    {
        // Getting NavMeshAgent from list of componets
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Tell NavMeshAgent to follow target psoition
        agent.SetDestination(target.position);
    }
}
