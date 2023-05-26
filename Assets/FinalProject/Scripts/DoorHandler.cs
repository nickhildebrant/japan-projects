using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class DoorHandler : MonoBehaviour
{
    public GameObject mainObject;

    private GameObject[] restaurantSeats;

    // Start is called before the first frame update
    void Start()
    {
        restaurantSeats = mainObject.GetComponent<RestaurantManager>().seatsInRestaurant;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Customer" && !other.gameObject.GetComponent<FindASeat>().foundSeat)
        {
            int partySize = other.GetComponent<FindASeat>().partySize;

            for(int i = 0; i < restaurantSeats.Length; i++)
            {
                List<GameObject> openSeats = new List<GameObject>();

                for(int j = i; j < i + partySize && j < restaurantSeats.Length; j++)
                {
                    if (restaurantSeats[j].GetComponent<SeatStatus>().IsOpen()) openSeats.Add(restaurantSeats[j]);
                }
                
                if(openSeats.Count >= partySize)
                {
                    for(int k = 0; k < openSeats.Count; k++)
                    {
                        openSeats[k].GetComponent<SeatStatus>().OccupySeat();
                        other.GetComponent<FindASeat>().friends[k].GetComponent<FindASeat>().foundSeat = true;
                        other.GetComponent<FindASeat>().friends[k].GetComponent<NavMeshAgent>().SetDestination(openSeats[k].transform.position);
                        other.GetComponent<FindASeat>().friends[k].GetComponent<NavMeshAgent>().isStopped = false;
                    }
                    return;
                }
                else
                {
                    openSeats.Clear();
                }    
            }

            // TODO make the customers go somewhere else
            other.GetComponent<NavMeshAgent>().isStopped = true;
        }
    }
}
