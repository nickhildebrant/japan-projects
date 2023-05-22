using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class FindASeat : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject dayNightManager;

    private bool foundSeat = false;

    public float walkingSpeed = 5.0f;
    public int partySize = 1;

    private float timer = 0.0f;

    [SerializeField]
    private GameObject finalDestination;

    private GameObject timerText;

    // Start is called before the first frame update
    void Start()
    {
        dayNightManager = GameObject.Find("Directional Light");

        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(foundSeat)
        {
            timer += Time.deltaTime;
        }

        if(timer >= 30.0f)
        {
            agent.destination = finalDestination.transform.position;
            timer = 0;
        }

        if (Vector3.Distance(transform.position, agent.destination) <= (agent.radius * 3) && foundSeat)
        {
            //GameObject.Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Seat")
        {
            int numOfExits = GameObject.FindGameObjectsWithTag("Finish").Length;
            finalDestination = GameObject.FindGameObjectsWithTag("Finish")[Random.Range(0, numOfExits)];

            foundSeat = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Seat")
        {
            
        }
    }
}
