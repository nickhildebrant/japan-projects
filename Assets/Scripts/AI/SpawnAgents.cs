using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnAgents : MonoBehaviour
{
    private float timer = 0.0f;

    public int numberOfAgents = 5;
    public float timeInterval = 5.0f;
    public GameObject agentPrefab;

    public GameObject DropOffLocation, DropOffPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > Random.Range(timeInterval - 2, timeInterval + 2))
        {
            timer = 0.0f;

            var possibleSeats = GameObject.FindGameObjectsWithTag("Seat");
            int randomSeat = Random.Range(0, possibleSeats.Length);
            for (int i = 0; i < numberOfAgents; i++)
            {
                GameObject newAgent = GameObject.Instantiate(agentPrefab, transform.position, Quaternion.identity);
                newAgent.tag = tag;
                if (newAgent.GetComponent<FindASeat>())
                {
                    newAgent.GetComponent<FindASeat>().partySize = numberOfAgents;
                    newAgent.GetComponent<NavMeshAgent>().destination = possibleSeats[randomSeat].transform.position;
                }

                if(DropOffLocation && DropOffPrefab)
                {
                    newAgent.GetComponent<CarMove>().DropOffPrefab = DropOffPrefab;
                    newAgent.GetComponent<CarMove>().DropOffLocation = DropOffLocation;
                }
            }
        }
    }
}
