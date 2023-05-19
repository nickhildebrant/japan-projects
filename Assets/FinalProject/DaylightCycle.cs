using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script controls the rotation of the sun, emulating a Day/Night Cycle.
/// Attach to the directional light in the scene.
/// </summary>
public class DaylightCycle : MonoBehaviour
{
    private GameObject textUI;
    private int minutes = 12, seconds = 0;
    private float timer = 0.0f;

    public int simulationSpeed = 1;

    public Slider simulationSlider;

    // Start is called before the first frame update
    void Start()
    {
        textUI = GameObject.Find("TimeClock");
    }

    // Update is called once per frame
    void Update()
    {
        simulationSpeed = (int)simulationSlider.value;

        timer += Time.deltaTime * simulationSpeed * 4;
        seconds = (int)timer % 60;
        minutes = (int)timer / 60 % 12 + 12;
        minutes = minutes > 12 ? minutes - 12 : minutes;

        transform.Rotate(new Vector3(Time.deltaTime * simulationSpeed, 0, 0));

        // Updating the clock if the UI exists
        if(textUI)
        {
            textUI.GetComponent<Text>().text = "Current Time: " + minutes + ":" + seconds.ToString("00") + "\n"
                + "Simulation Speed: " + simulationSpeed;
        }
    }
}
