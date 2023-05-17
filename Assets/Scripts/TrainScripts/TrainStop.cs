using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainStop : MonoBehaviour
{
    public Transform currentStop;
    public Transform nextStop;

    void Start()
    {
        currentStop = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
