using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Train : MonoBehaviour
{
    public float speed = 10f;
    public float acceleration = 0.0f;
    public bool isStop = false;
    public Material redMaterial;

    public GameObject SendToObject;

    public Transform targetA, targetB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isStop) return;

        speed += acceleration;

        Vector3 directionVector = Vector3.Normalize(targetA.position - targetB.position);
        transform.rotation = Quaternion.LookRotation(directionVector);

        transform.position += speed * directionVector * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        acceleration = -0.0005f;
        SendToObject.GetComponent<Renderer>().material = redMaterial;
    }
}
