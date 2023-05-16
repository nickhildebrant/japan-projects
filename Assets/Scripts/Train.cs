using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Train : MonoBehaviour
{
    public float speed = 10f;
    public bool isStopped = false;
    public Material redMaterial, greenMaterial;

    public GameObject SendToObject;

    public Transform targetA, targetB;

    private float acceleration = 0.0f;
    public float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
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

        if (speed <= 0)
        {
            isStopped = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        acceleration = -0.1f;
        SendToObject.GetComponent<Renderer>().material = redMaterial;
    }

    private void OnTriggerExit(Collider other)
    {
        SendToObject.GetComponent<Renderer>().material = greenMaterial;
        acceleration = 0;
    }
}
