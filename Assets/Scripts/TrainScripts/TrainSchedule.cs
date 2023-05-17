using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class TrainSchedule : MonoBehaviour
{
    public float speed = 10.0f;
    public float acceleration = 0.005f;
    private float timer = 0.0f;

    public GameObject stop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 directionVector = Vector3.Normalize(stop.GetComponent<TrainStop>().nextStop.position - stop.GetComponent<TrainStop>().currentStop.position);
        transform.rotation = Quaternion.LookRotation(directionVector);

        transform.position += speed * directionVector * Time.deltaTime;

        if (speed <= 0)
        {
            timer += Time.deltaTime;

            if (timer >= 1.0f)
            {
                print("Timer is reset");
                timer = 0.0f;
                stop.GetComponent<TrainStop>().currentStop = stop.GetComponent<TrainStop>().nextStop;
                speed += acceleration;
            }
        }
    }
}
