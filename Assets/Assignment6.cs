using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

using TMPro;
using UnityEngine.UI;

public class Assignment6 : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    public Slider slider;

    private float previousTime = 1.0f;
    string filename;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetString("Time", Time.time.ToString("0.00"));
    }

    public void PauseGame()
    {
        previousTime = Time.timeScale;
        Time.timeScale = 0;
    }

    public void SetTimeScale()
    {
        Time.timeScale = slider.GetComponent<Slider>().value;
    }

    public void SaveFile()
    {
        filename = Application.dataPath + "/assignment6.txt";

        StreamWriter streamWriter = File.CreateText(filename);
        streamWriter.WriteLine("Number of Agents who reached their goal {0}", PlayerPrefs.GetInt("NumAgents"));
        streamWriter.WriteLine("Total time passed: {0}", PlayerPrefs.GetString("Time"));
        streamWriter.Close();
    }

    public void ReadFile()
    {
        filename = Application.dataPath + "/assignment6.txt";

        if (!File.Exists(filename))
        {
            Debug.Log("Could not Open the file: " + filename + " does not exist.");
            return;
        }

        StreamReader streamReader = File.OpenText(filename);
        string line = streamReader.ReadLine();

        string newText = "";
        while (line != null)
        {
            newText += line;
            newText += "\n";
            Debug.Log(line);
            line = streamReader.ReadLine();
        }

        displayText.text = newText;

        streamReader.Close();
    }
}
