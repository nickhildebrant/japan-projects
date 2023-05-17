using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Attach this script the the AI agent.
/// </summary>
public class NavMeshTest : MonoBehaviour
{
    public Transform goal;

    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goal.position);
    }

    private void FixedUpdate()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goal.position);
    }

}
