using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TaxiScript : MonoBehaviour
{
    public GameObject destination;
    public float carSpeed = 5.0f;
    private float tempSpeed = 5.0f;

    private int holdingPassengers = 0;

    public GameObject leftLight, rightLight;
    public GameObject directionalLight;

    public GameObject origin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * carSpeed * Time.deltaTime;

        if(directionalLight.GetComponent<DaylightCycle>().IsNight())
        {
            leftLight.GetComponent<Light>().enabled = true;
            rightLight.GetComponent<Light>().enabled = true;
        }

        if (!directionalLight.GetComponent<DaylightCycle>().IsNight())
        {
            leftLight.GetComponent<Light>().enabled = false;
            rightLight.GetComponent<Light>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Customer")
        {
            tempSpeed = carSpeed;
            carSpeed = 0;

            if(holdingPassengers < 5)
            {
                if(other.gameObject.GetComponentInParent<FindASeat>().GoingHome())
                {
                    holdingPassengers++;
                }
            }
        }

        if(other.name == "TaxiDestination")
        {
            transform.position = origin.transform.position;
            print("Dropped off " + holdingPassengers + " passengers.");
            holdingPassengers = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Customer")
        {
            carSpeed = 5;
        }
    }
}
