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

    private GameObject[] possibleRestaurants;// = GameObject.FindGameObjectsWithTag("Entrance");

    // Start is called before the first frame update
    void Start()
    {
        listOfAgents = new List<GameObject>();
        possibleRestaurants = GameObject.FindGameObjectsWithTag("Entrance");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer > Random.Range(timeInterval - 2, timeInterval + 2))
        {
            timer = 0.0f;

            int randomSeat = Random.Range(0, possibleRestaurants.Length);
            for (int i = 0; i < numberOfAgents; i++)
            {
                GameObject newAgent = GameObject.Instantiate(agentPrefab, transform.position + new Vector3(Random.Range(0f, 3f), Random.Range(0f, 1f), Random.Range(0f, 3f)), Quaternion.EulerRotation(0, Random.Range(0f, 5f), 0));
                if(tag != "Finish") newAgent.tag = tag;
                if (newAgent.GetComponent<FindASeat>())
                {
                    newAgent.GetComponent<NavMeshAgent>().destination = possibleRestaurants[randomSeat].transform.position;
                    newAgent.GetComponent<NavMeshAgent>().speed = 5.0f;
                    newAgent.GetComponent<FindASeat>().partySize = numberOfAgents;
                }

                if(DropOffLocation && DropOffPrefab)
                {
                    newAgent.GetComponent<CarMove>().DropOffPrefab = DropOffPrefab;
                    newAgent.GetComponent<CarMove>().DropOffLocation = DropOffLocation;
                }

                newAgent.GetComponent<FindASeat>().friends = new GameObject[numberOfAgents];
                listOfAgents.Add(newAgent);
            }

            foreach(GameObject agent in listOfAgents)
            {
                agent.GetComponent<FindASeat>().friends = listOfAgents.ToArray();
            }

            listOfAgents.Clear();
        }
    }
}
