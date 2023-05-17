using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainStation : MonoBehaviour
{
    public GameObject correctObject;

    private bool trainEntered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other == correctObject.GetComponent<Collider>()) { print("Entered"); trainEntered = true; }
    }

    void OnTriggerExit(Collider other)
    {
        if (other == correctObject.GetComponent<Collider>()) { print("Exit"); trainEntered = false; }
    }

    private void Update()
    {
        if (trainEntered)
        {
            float distance = Vector3.Distance(transform.position, correctObject.transform.position);

            if (correctObject.GetComponent<TrainSchedule>().speed >= 0)
            {
                correctObject.GetComponent<TrainSchedule>().speed -= distance * Time.deltaTime;
            }
            else
            {
                //correctObject.transform.position = new Vector3(transform.position.x, correctObject.transform.position.y, transform.position.z);
                trainEntered = false;
            }
        }
    }
}
