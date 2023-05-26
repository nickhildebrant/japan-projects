using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        if (minHappyTime > time) minHappyTime = time;

        if (maxHappyTime < time) maxHappyTime = time;
    }

    public void UpdateAngry(int time)
    {
        angryGuys++;

        if (minAngryTime > time) minAngryTime = time;

        if (maxAngryTime < time) maxAngryTime = time;
    }

    public void WriteToFile()
    {

    }
}
