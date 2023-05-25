using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script is attached to the main camera
/// </summary>
public class CameraMove : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float rotateSpeed = 30.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        
        // Basic camera key controls
        if(Input.GetKey(KeyCode.W)) { newPosition += transform.forward * movementSpeed * Time.deltaTime; }
        if(Input.GetKey(KeyCode.A)) { newPosition -= transform.right * movementSpeed * Time.deltaTime; }
        if(Input.GetKey(KeyCode.S)) { newPosition -= transform.forward * movementSpeed * Time.deltaTime; }
        if(Input.GetKey(KeyCode.D)) { newPosition += transform.right * movementSpeed * Time.deltaTime; }
        if(Input.GetKey(KeyCode.E)) { newPosition.y += movementSpeed * Time.deltaTime; }
        if(Input.GetKey(KeyCode.Q)) { newPosition.y -= movementSpeed * Time.deltaTime; }

        // Basic camera key controls
        if (Input.GetKey(KeyCode.UpArrow)) { transform.Rotate(-transform.right * rotateSpeed * Time.deltaTime, Space.World); }
        if (Input.GetKey(KeyCode.LeftArrow)) { transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime, Space.World); }
        if (Input.GetKey(KeyCode.DownArrow)) { transform.Rotate(transform.right * rotateSpeed * Time.deltaTime, Space.World); }
        if (Input.GetKey(KeyCode.RightArrow)) { transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World); }

        transform.position = newPosition;
    }
}
