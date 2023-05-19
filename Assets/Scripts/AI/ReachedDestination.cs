using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ReachedDestination : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
        }
    }
}
