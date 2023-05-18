using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 origin;

    public Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destination.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        agent.isStopped = other.GetComponent<TrafficLight>().GetLightColor();
    }

    private void OnTriggerStay(Collider other)
    {
        agent.isStopped = other.GetComponent<TrafficLight>().GetLightColor();
    }
}
