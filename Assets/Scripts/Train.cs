using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    private float speed = 10f;
    private bool isStopped = false;
    public Material redMaterial, greenMaterial;

    public GameObject SendToObject;

    private Transform targetA, targetB, prevStop;

    private float acceleration = 0.0f;
    private float timer = 0.0f;

    [SerializeField]
    public Transform[] targets;
    private bool nextStop = true;
    private int i = 0;

    private void Start()
    {
        prevStop = targets[i];
        targetA = targets[i];
        targetB = targets[i + 1];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isStopped && timer >= 1.0f)
        {
            acceleration = 0.1f;
            timer = 0.0f;
            isStopped = false;
        }

        if (isStopped)
        {
            timer += Time.deltaTime;
            return;
        }

        speed += acceleration;

        Vector3 directionVector = Vector3.Normalize(targetB.position - targetA.position);
        transform.rotation = Quaternion.LookRotation(directionVector);

        transform.position += speed * directionVector * Time.deltaTime;

        float distance = Vector3.Distance(transform.position, targetB.position);
        if (distance <= 0.5f && nextStop)
        {
            nextStop = false;

            if (i < targets.Length - 2)
            {
                prevStop = targets[i++];
                targetA = targets[i];
                targetB = targets[i + 1];
            }
            else
            {
                i = 0;
                prevStop = targets[i];
                targetA = targets[i];
                targetB = targets[i + 1];
                transform.position = targetA.position;
            }
        }

        if(Vector3.Distance(transform.position, prevStop.position) > 0.5f) { nextStop = true; }

        if (speed <= 0)
        {
            isStopped = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Station")
        {
            acceleration = -0.1f;
            SendToObject.GetComponent<Renderer>().material = redMaterial;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Station")
        {
            SendToObject.GetComponent<Renderer>().material = greenMaterial;
            acceleration = 0;
        }
    }
}
