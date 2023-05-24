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

    private List<GameObject> listOfAgents;

    // Start is called before the first frame update
    void Start()
    {
        listOfAgents = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > Random.Range(timeInterval - 2, timeInterval + 2))
        {
            timer = 0.0f;

            var possibleRestaurants = GameObject.FindGameObjectsWithTag("Entrance");
            int randomSeat = Random.Range(0, possibleRestaurants.Length);
            for (int i = 0; i < numberOfAgents; i++)
            {
                GameObject newAgent = GameObject.Instantiate(agentPrefab, transform.position, Quaternion.identity);
                if(tag != "Finish") newAgent.tag = tag;
                if (newAgent.GetComponent<FindASeat>())
                {
                    newAgent.GetComponent<FindASeat>().partySize = numberOfAgents;
                    newAgent.GetComponent<NavMeshAgent>().destination = possibleRestaurants[randomSeat].transform.position;
                    newAgent.GetComponent<NavMeshAgent>().speed = 5.0f;
                }

                if(DropOffLocation && DropOffPrefab)
                {
                    newAgent.GetComponent<CarMove>().DropOffPrefab = DropOffPrefab;
                    newAgent.GetComponent<CarMove>().DropOffLocation = DropOffLocation;
                }

                newAgent.GetComponent<FindASeat>().friends = new GameObject[numberOfAgents];
                listOfAgents.Add(newAgent);
            }

            foreach(var agent in listOfAgents)
            {
                agent.GetComponent<FindASeat>().friends = listOfAgents.ToArray();
            }

            listOfAgents.Clear();
        }
    }
}
