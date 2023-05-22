using System.Collections;
using System.Collections.Generic;
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
        if(other.tag == "Customer")
        {
            bool hasOpenSeats = false;
            int partySize = other.GetComponent<FindASeat>().partySize;
            List<GameObject> openSeats = new List<GameObject>();

            // Getting the open seats
            for(int i = 0; i < restaurantSeats.Length; i++)
            {
                if (restaurantSeats[i].GetComponent<SeatStatus>().IsOpen()) openSeats.Add(restaurantSeats[i]);
            }

            if (partySize <= openSeats.Count)
            {
                for (int j = 0; j < openSeats.Count; j++)
                {
                    if (other.GetComponent<NavMeshAgent>().destination == openSeats[j].transform.position)
                    {
                        hasOpenSeats = true;
                    }
                }
            }

            // TODO make the customers go somewhere else
        }
    }
}
