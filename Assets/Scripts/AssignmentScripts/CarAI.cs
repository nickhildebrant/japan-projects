using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

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
        if(Vector3.Distance(destination.position, transform.position) <= 1.0f) 
        {
            int agentNumber = PlayerPrefs.GetInt("AgentNum");
            PlayerPrefs.SetInt("AgentNum", ++agentNumber);
            GameObject.Find("Car UI Text").GetComponent<Text>().text = "Cars that Reached their Destination: " + agentNumber;
            Destroy(gameObject); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<TrafficLight>()) agent.isStopped = other.GetComponent<TrafficLight>().GetLightColor();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<TrafficLight>()) agent.isStopped = other.GetComponent<TrafficLight>().GetLightColor();
    }
}
