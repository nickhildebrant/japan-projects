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

    public Slider simulationSlider;

    private bool isNight = false;

    // Start is called before the first frame update
    void Start()
    {
        textUI = GameObject.Find("TimeClock");

        PlayerPrefs.SetInt("SatisfiedCustomers", 0);
        PlayerPrefs.SetInt("TotalHappyTime", 0);
        PlayerPrefs.SetInt("MinHappyTime", 0);
        PlayerPrefs.SetInt("MaxHappyTime", 0);
        PlayerPrefs.SetInt("MaxHappyTime", 0);
        PlayerPrefs.SetInt("AngryCustomers", 0);
        PlayerPrefs.SetInt("TotalAngryTime", 0);
        PlayerPrefs.SetInt("MinAngryTime", 0);
        PlayerPrefs.SetInt("MaxAngryTime", 0);
        PlayerPrefs.SetInt("TotalCustomers", 0);
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = (int)simulationSlider.value;

        timer += Time.deltaTime * 4;
        seconds = (int)timer % 60;
        minutes = (int)timer / 60 % 12 + 12;
        minutes = minutes > 12 ? minutes - 12 : minutes;
        if (minutes == 7 && seconds <= 1 && isNight) isNight = false;
        else if(minutes == 7 && seconds <= 1 && !isNight) isNight = true;

        transform.Rotate(new Vector3(Time.deltaTime, 0, 0));

        // Updating the clock if the UI exists
        if(textUI)
        {
            textUI.GetComponent<Text>().text = "Current Time: " + minutes + ":" + seconds.ToString("00") + "\n"
                + "Simulation Speed: " + Time.timeScale;
        }
    }

    public int GetTime()
    {
        return minutes * 60 + seconds;
    }

    public bool IsNight()
    {
        return isNight;
    }
}
