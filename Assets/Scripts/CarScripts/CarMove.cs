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

    private Vector3 tempDirection;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(2, maxSpeed);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        tempDirection = transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TrafficLight>()) GetComponent<Rigidbody>().velocity = other.GetComponent<TrafficLight>().GetLightColor() ? Vector3.zero : GetComponent<Rigidbody>().velocity;

        if (other.tag == "StreetNode")
        {
            var nextStops = other.GetComponent<StreetNode>().nextNodes;
            if (nextStops.Length == 0) Destroy(gameObject);
            else
            {
                int randomID = Random.Range(0, nextStops.Length);
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

        if (other.GetComponent<TrafficLight>() && !other.GetComponent<TrafficLight>().GetLightColor()) GetComponent<Rigidbody>().velocity = tempDirection * speed;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Car")
        {
            GetComponent<Rigidbody>().velocity = tempDirection * speed;
        }
    }
}
