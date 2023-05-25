using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushHourSpawning : MonoBehaviour
{
    public GameObject timeManager;
    public const int peakDinnerTime = 60 * 7;
    public const int peakLunchTime = 60 * 11;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (peakLunchTime - timeManager.GetComponent<DaylightCycle>().GetTime() <= 90 && peakLunchTime - timeManager.GetComponent<DaylightCycle>().GetTime() > 0)
        {
            GetComponent<SpawnAgents>().numberOfAgents = Random.Range(1, 3);
            //GetComponent<SpawnAgents>().numberOfAgents = 1;
            GetComponent<SpawnAgents>().timeInterval = Random.Range(10, 15);
        }

        if (peakDinnerTime - timeManager.GetComponent<DaylightCycle>().GetTime() <= 90 && peakDinnerTime - timeManager.GetComponent<DaylightCycle>().GetTime() > 0)
        {
            GetComponent<SpawnAgents>().numberOfAgents = Random.Range(2, 6);
            GetComponent<SpawnAgents>().timeInterval = Random.Range(5, 10);
        }
    }
}