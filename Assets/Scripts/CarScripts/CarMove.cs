using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach to the car prefab. Makes the car move.
/// </summary>
public class CarMove : MonoBehaviour
{
    public float speed; // Random from 2-Max
    public float maxSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(2, maxSpeed);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "StreetNode")
        {
            var nextStops = other.GetComponent<StreetNode>().nextNodes;
            if (nextStops.Length == 0) Destroy(gameObject);
            else
            {
                int randomID = Random.Range(0, nextStops.Length-1);
                //GetComponent<Rigidbody>().velocity = other.GetComponent<StreetNode>().directions[randomID];
                var tempDirection = other.GetComponent<StreetNode>().directions[randomID];
                transform.rotation = Quaternion.LookRotation(tempDirection);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Car")
        {
            
        }
    }
}
