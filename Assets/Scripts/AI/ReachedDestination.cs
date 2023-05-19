using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class ReachedDestination : MonoBehaviour
{

    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = GetComponent<NavMeshAgent>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(GetComponent<NavMeshAgent>().destination, transform.position) < 1.0f)
        {
            var possibleSeats = GameObject.FindGameObjectsWithTag("Seat");
            int randomSeat = Random.Range(0, possibleSeats.Length);
            GetComponent<NavMeshAgent>().destination = possibleSeats[randomSeat].transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Crosswalk")
        {
            if(!other.GetComponent<Renderer>().isVisible)
            {
                GetComponent<NavMeshAgent>().isStopped = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Crosswalk")
        {
            if (other.GetComponent<Renderer>().isVisible)
            {
                GetComponent<NavMeshAgent>().isStopped = false;
            }
            else
            {
                GetComponent<NavMeshAgent>().speed = GetComponent<NavMeshAgent>().speed + 5;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Crosswalk")
        {
            GetComponent<NavMeshAgent>().speed = speed;
        }
    }
}
