using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StorageScript : MonoBehaviour
{
    public int happyGuys = 0;
    public int angryGuys = 0;

    public int happyTimer = 0;
    public int angryTimer = 0;

    public int minHappyTime = int.MaxValue;
    public int minAngryTime = int.MaxValue;

    public int maxHappyTime = int.MinValue;
    public int maxAngryTime = int.MinValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHappy(int time)
    {
        happyGuys++;

        happyTimer += time;

        if (minHappyTime > time) minHappyTime = time;

        if (maxHappyTime < time) maxHappyTime = time;
    }

    public void UpdateAngry(int time)
    {
        angryGuys++;

        angryTimer += time;

        if (minAngryTime > time) minAngryTime = time;

        if (maxAngryTime < time) maxAngryTime = time;
    }

    public void WriteToFile()
    {
        string text = "";
        string variable = GameObject.Find("Toggle").GetComponent<Toggle>().isOn ? "find new Restaurants." : "stay in line.";

        text = "Results for Sim when Customers " + variable;
        text += "\nNumber of Happy Customers: " + happyGuys;
        text += "\nLowest time spent by a Happy Customer: " + minHappyTime;
        text += "\nHighest time spent by a Happy Customer: " + maxHappyTime;
        if (happyGuys > 0) text += "\nAverage Happy Time: " + happyTimer / happyGuys;
        else text += "\nAverage Happy Time: " + (happyTimer / 1);

        text += "\n\nNumber of Angry Customers: " + angryGuys;
        text += "\nLowest time spent by an Angry Customer: " + minAngryTime;
        text += "\nHighest time spent by an Angry Customer: " + maxAngryTime;
        if (angryGuys > 0) text += "\nAverage Angry Time: " + (angryTimer / angryGuys);
        else text += "\nAverage Angry Time: " + (angryTimer / 1);

        text += "\nTry the Simulation again with different parameters!";

        StreamWriter streamWriter = File.CreateText(Application.dataPath + "/results.txt");
        streamWriter.WriteLine(text);
        streamWriter.Close();
    }
}
