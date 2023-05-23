using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

/// <summary>
/// Attach to a Manager object in the scene.
/// </summary>
public class FileIO : MonoBehaviour
{
    string filename;

    public void WriteFile() // save data
    {
        filename = Application.dataPath + "/output.txt";

        if(File.Exists(filename))
        {
            Debug.Log(filename + " already exists");
            return;
        }

        StreamWriter streamWriter = File.CreateText(filename);
        streamWriter.WriteLine("This is my file");
        streamWriter.WriteLine("I can write ints {0} or floats {1}, and so on.", 1, 4.2);
        streamWriter.Close();
    }

    public void ReadFile() // load data
    {
        filename = Application.dataPath + "/output.txt";

        if(!File.Exists (filename))
        {
            Debug.Log("Could not Open the file: " + filename + " for reading.");
            return;
        }

        StreamReader sr = File.OpenText(filename);
        string line = sr.ReadLine();

        while(line != null)
        {
            Debug.Log(line);
            line = sr.ReadLine();
        }
    }
}
