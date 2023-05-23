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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Customer" && !other.gameObject.GetComponent<FindASeat>().CustomerEatingStatus())
        {
            int partySize = other.GetComponent<FindASeat>().partySize;

            for(int i = 0; i < restaurantSeats.Length; i++)
            {
                List<GameObject> openSeats = new List<GameObject>();

                for(int j = i; j < partySize; j++)
                {
                    if (restaurantSeats[i].GetComponent<SeatStatus>().IsOpen()) openSeats.Add(restaurantSeats[i]);
                }

                if(openSeats.Count >= partySize)
                {
                    for(int k = 0; k < openSeats.Count; k++)
                    {
                        other.gameObject.GetComponent<NavMeshAgent>().SetDestination(openSeats[k].transform.position);
                        print("New Destination for Party of " + partySize);
                    }
                    break;
                }
                else
                {
                    openSeats.Clear();
                }    
            }

            // TODO make the customers go somewhere else
        }
    }
}
