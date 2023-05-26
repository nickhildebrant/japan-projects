using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
using System.IO;

public class FinalText : MonoBehaviour
{
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        text.text = "";
        text.text += "Number of Happy Customers: " + PlayerPrefs.GetInt("SatisfiedCustomers");
        text.text += "\nLowest time spent by a Happy Customer: " + PlayerPrefs.GetInt("MinHappyTime");
        if (PlayerPrefs.GetInt("SatisfiedCustomers") > 0) text.text += "\nAverage Happy Time: " + (PlayerPrefs.GetInt("TotalHappyTime") / PlayerPrefs.GetInt("SatisfiedCustomers"));
        else text.text += "\nAverage Happy Time: " + (PlayerPrefs.GetInt("TotalHappyTime") / 1);

        text.text += "\n\nNumber of Angry Customers: " + PlayerPrefs.GetInt("AngryCustomers");
        text.text += "\nHighest time spent by an Angry Customer: " + PlayerPrefs.GetInt("MaxAngryTime");
        if (PlayerPrefs.GetInt("AngryCustomers") > 0) text.text += "\nAverage Angry Time: " + (PlayerPrefs.GetInt("TotalAngryTime") / PlayerPrefs.GetInt("AngryCustomers"));
        else text.text += "\nAverage Angry Time: " + (PlayerPrefs.GetInt("TotalAngryTime") / 1);

        text.text += "\nTry the Simulation again with different parameters!";

        StreamWriter streamWriter = File.CreateText(Application.dataPath + "/results.txt");
        streamWriter.WriteLine(text.text);
        streamWriter.Close();
    }
}
