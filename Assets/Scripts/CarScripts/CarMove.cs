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
    public float maxSpeed = 5.0f;

    private Vector3 origin;
    private Vector3 tempDirection;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        speed = Random.Range(2, maxSpeed);
        tempDirection = Vector3.Normalize(GameObject.Find("PrefabStreetNodeCenter").transform.position - transform.position);
        transform.rotation = Quaternion.LookRotation(tempDirection);

        GetComponent<Rigidbody>().velocity = tempDirection * speed;
        tempDirection = transform.forward;
    }

    private void Update()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TrafficLight>() && tag == "Car") speed = 0;

        if (tag == "Car" && other.tag == "StreetNode")
        {
            var nextStops = other.GetComponent<StreetNode>().nextNodes;
            if (nextStops.Length == 0) Destroy(gameObject);
            else
            {
                int randomID = Random.Range(0, nextStops.Length);
                while (other.GetComponent<StreetNode>().nextNodes[randomID].position == origin) { randomID = Random.Range(0, nextStops.Length); }
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

        if (tag == "Car" && other.GetComponent<TrafficLight>() && !other.GetComponent<TrafficLight>().GetLightColor()) speed = Random.Range(2f, maxSpeed);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Car")
        {
            //GetComponent<Rigidbody>().velocity = tempDirection * speed;
        }
    }
}
