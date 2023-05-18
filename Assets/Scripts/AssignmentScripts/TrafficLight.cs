using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    private float timer = 0.0f;
    private bool isStopped = false;

    public Material greenMaterial, redMaterial;
    public GameObject trafficLight;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 5.0f)
        {
            trafficLight.GetComponent<Renderer>().enabled = true; //show up
            trafficLight.GetComponent<Renderer>().material = isStopped ? greenMaterial : redMaterial;
            timer = 0;
            isStopped = !isStopped;
        }
    }

    public bool GetLightColor() { return isStopped; }
}