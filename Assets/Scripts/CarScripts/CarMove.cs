using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Attach to the car prefab. Makes the car move.
/// </summary>
public class CarMove : MonoBehaviour
{
    public float speed; // Random from 2-Max
    public float maxSpeed = 10.0f;

    public Material redMaterial, greenMaterial;

    public GameObject DropOffLocation, DropOffPrefab;

    private Vector3 tempDirection;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(4, maxSpeed);
        tempDirection = Vector3.Normalize(GameObject.Find("PrefabStreetNodeCenter" + tag).transform.position - transform.position);
        transform.rotation = Quaternion.LookRotation(tempDirection);

        GetComponent<Rigidbody>().velocity = tempDirection * speed;
        tempDirection = transform.forward;
    }

    private void Update()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;

        GetComponent<Renderer>().material = speed == 0 ? redMaterial : greenMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TrafficLight>() && (tag == "East" || tag == "South" || tag == "North" || tag == "West")) speed = 0;

        if ((tag == "East" || tag == "South" || tag == "North" || tag == "West") && other.tag == "StreetNode")
        {
            var nextStops = other.GetComponent<StreetNode>().nextNodes;
            if (nextStops.Length == 0)
            {
                if(DropOffPrefab && DropOffLocation)
                {
                    GameObject.Instantiate(DropOffPrefab, DropOffLocation.transform.position, Quaternion.identity);
                }

                Destroy(gameObject);
            }
            else
            {
                int randomID = CheckSameOrigin(other, nextStops.Length);
                tempDirection = other.GetComponent<StreetNode>().directions[randomID];
                transform.rotation = Quaternion.LookRotation(tempDirection);
                GetComponent<Rigidbody>().velocity = tempDirection * speed;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //if(other.tag == "Car")
        //{
        //    GetComponent<Rigidbody>().velocity = Vector3.zero;
        //    transform.position -= transform.forward * speed;
        //    other.transform.position += other.transform.forward * other.GetComponent<CarMove>().speed;
        //}

        if ((tag == "East" || tag == "South" || tag == "North" || tag == "West") && other.GetComponent<TrafficLight>() && !other.GetComponent<TrafficLight>().GetLightColor())
        {
            speed = Random.Range(4f, maxSpeed);
        }
    }

    private int CheckSameOrigin(Collider other, int arrayLength)
    {
        int randomID = Random.Range(0, arrayLength);

        while(true)
        {
            string checkName = "StreetNode" + tag;
            if (other.GetComponent<StreetNode>().nextNodes[randomID].name == checkName || other.GetComponent<StreetNode>().nextNodes[randomID].name == "PrefabStreetNodeCenter"+tag)
            {
                randomID = Random.Range(0, arrayLength);
            }
            else
            {
                return randomID;
            }
        }
    }
}
