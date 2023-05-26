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

        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetInt("SatisfiedCustomers", 0);
        PlayerPrefs.SetInt("TotalHappyTime", 0);
        PlayerPrefs.SetInt("MinHappyTime", int.MaxValue);
        //PlayerPrefs.SetInt("MaxHappyTime", int.MinValue);
        PlayerPrefs.SetInt("AngryCustomers", 0);
        PlayerPrefs.SetInt("TotalAngryTime", 0);
        //PlayerPrefs.SetInt("MinAngryTime", int.MaxValue);
        PlayerPrefs.SetInt("MaxAngryTime", int.MinValue);
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = (int)simulationSlider.value;

        timer += Time.deltaTime * 4;
        seconds = (int)timer % 60;
        minutes = (int)timer / 60 % 12 + 12;
        if (timer >= (60 * 7) && timer < (60 * 19)) isNight = true;
        else isNight = false;
        minutes = minutes > 12 ? minutes - 12 : minutes;

        if(timer >= 2400)
        {
            timer -= 2400;
        }


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
