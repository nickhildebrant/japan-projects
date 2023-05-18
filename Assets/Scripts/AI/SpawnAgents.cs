using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class SpawnAgents : MonoBehaviour
{
    private float timer = 0.0f;

    public int numberOfAgents = 5;
    public GameObject agentPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 3.0f)
        {
            timer = 0.0f;
            for(int i = 0; i < numberOfAgents; i++) GameObject.Instantiate(agentPrefab, transform.position, Quaternion.identity);
        }
    }
}
