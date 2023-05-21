using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FindASeat : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject dayNightManager;

    public float walkingSpeed = 1.0f;
    public float partySize = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        dayNightManager = GameObject.Find("Directional Light");

        agent = GetComponent<NavMeshAgent>();
        var possibleSeats = GameObject.FindGameObjectsWithTag("Seat");
        int randomSeat = Random.Range(0, possibleSeats.Length);
        agent.destination = possibleSeats[randomSeat].transform.position;
        agent.isStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.speed = walkingSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Seat")
        {
            GameObject.Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Seat")
        {
            
        }
    }
}
