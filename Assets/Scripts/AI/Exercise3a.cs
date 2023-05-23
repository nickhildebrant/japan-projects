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
        agent.SetDestination(targets[Random.Range(0, targets.Length)].transform.position);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, agent.destination) < 1.1f)
        {
            GameObject.Instantiate(gameObject, targets[Random.Range(0, targets.Length)].transform.position, Quaternion.identity);
            Destroy(gameObject);

            int numAgents = PlayerPrefs.GetInt("NumAgents");
            PlayerPrefs.SetInt("NumAgents", ++numAgents);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        agent.isStopped = true;
    }
}
