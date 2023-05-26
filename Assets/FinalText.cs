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

        string filename = Application.dataPath + "/results.txt";

        if (!File.Exists(filename))
        {
            Debug.Log("Could not Open the file: " + filename + " for reading.");
            return;
        }

        StreamReader streamReader = File.OpenText(filename);
        string line = streamReader.ReadLine();

        while (line != null)
        {
            print(line);
            text.text += line + "\n";
            line = streamReader.ReadLine();
        }

        streamReader.Close();
    }
}
