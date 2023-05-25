using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    public TextMeshProUGUI displayText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string filename = Application.dataPath + "/assignment6.txt";

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
