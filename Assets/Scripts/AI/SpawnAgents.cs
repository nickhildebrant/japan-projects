using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            for (int i = 0; i < numberOfAgents; i++)
            {
                GameObject newAgent = GameObject.Instantiate(agentPrefab, transform.position, Quaternion.identity);
                newAgent.tag = tag;

                if(DropOffLocation && DropOffPrefab)
                {
                    newAgent.GetComponent<CarMove>().DropOffPrefab = DropOffPrefab;
                    newAgent.GetComponent<CarMove>().DropOffLocation = DropOffLocation;
                }
            }
        }
    }
}
