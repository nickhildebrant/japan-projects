using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Exercise3a : MonoBehaviour
{
    [SerializeField]
    public GameObject[] targets;

    private NavMeshAgent agent;

    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Finish");
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(targets[Random.Range(0, targets.Length-1)].transform.position);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, agent.destination) < 1.1f) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        agent.Stop();
    }
}
