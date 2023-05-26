using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TaxiScript : MonoBehaviour
{
    public GameObject destination;
    public float carSpeed = 5.0f;
    private float tempSpeed = 5.0f;

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
        else
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
        }

        if(other.name == "TaxiDestination")
        {
            transform.position = origin.transform.position;
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
