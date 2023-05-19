using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FindASeat : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject dayNightManager;

    public float walkingSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        dayNightManager = GameObject.Find("Directional Light");

        agent = GetComponent<NavMeshAgent>();
        var possibleSeats = GameObject.FindGameObjectsWithTag("Seat");
        int randomSeat = Random.Range(0, possibleSeats.Length - 1);
        agent.destination = possibleSeats[randomSeat].transform.position;
        agent.isStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.speed = walkingSpeed * dayNightManager.GetComponent<DaylightCycle>().simulationSpeed;
    }
}
