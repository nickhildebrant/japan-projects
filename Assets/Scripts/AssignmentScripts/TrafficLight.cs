using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrafficLight : MonoBehaviour
{
    private float timer = 0.0f;
    public bool isStopped = false;

    public Material greenMaterial, redMaterial;
    public GameObject trafficLight;

    private Text timerText;

    public GameObject pedestrianBlocker;

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("Time Counter")) timerText = GameObject.Find("Time Counter").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 10.0f)
        {
            trafficLight.GetComponent<Renderer>().enabled = true; //show up
            trafficLight.GetComponent<Renderer>().material = isStopped ? greenMaterial : redMaterial;

            if(pedestrianBlocker)
            {
                //pedestrianBlocker.GetComponent<BoxCollider>().isTrigger = !isStopped;
                pedestrianBlocker.GetComponent<Renderer>().enabled = !isStopped;
            }


            timer = 0;
            isStopped = !isStopped;
        }

        if (timerText) timerText.text = "Time: " + (int)Time.realtimeSinceStartup;
    }

    public bool GetLightColor() { return isStopped; }
}
