using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UI;

public class StorageScript : MonoBehaviour
{
    public int happyGuys = 0;
    public int angryGuys = 0;

    public int happyTimer = 0;
    public int angryTimer = 0;

    public int minHappyTime = 0;
    public int minAngryTime = 0;

    public int maxHappyTime = 0;
    public int maxAngryTime = 0;

    public void UpdateHappy(int time)
    {
        happyGuys++;

        happyTimer += time;

        minHappyTime = Mathf.Min(minHappyTime, time);

        if (maxHappyTime > 2147483640) maxHappyTime = time;
        else Mathf.Max(maxHappyTime, time);
    }

    public void UpdateAngry(int time)
    {
        angryGuys++;

        angryTimer += time;

        if (maxAngryTime > 2147483640) maxAngryTime = time;
        else Mathf.Max(maxAngryTime, time);

        minAngryTime = Mathf.Min(minAngryTime, time);
        //maxAngryTime = Mathf.Max(maxAngryTime, time);
    }

    public void WriteToFile()
    {
        string text = "";
        string variable = GameObject.Find("Toggle").GetComponent<Toggle>().isOn ? "find new Restaurants." : "stay in line.";

        text = "Results for Sim when Customers " + variable;
        text += "\nNumber of Happy Customers: " + happyGuys;
        text += "\nLowest time spent by a Happy Customer: " + minHappyTime;
        text += "\nHighest time spent by a Happy Customer: " + maxHappyTime;
        if (happyGuys > 0) text += "\nAverage Happy Time: " + (happyTimer / happyGuys);
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
