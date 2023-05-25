using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script is attached to the main camera
/// </summary>
public class CameraMove : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float rotateSpeed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        
        // Basic camera key controls
        if(Input.GetKey(KeyCode.W)) { newPosition.z += movementSpeed * Time.deltaTime; }
        if(Input.GetKey(KeyCode.A)) { newPosition.x -= movementSpeed * Time.deltaTime; }
        if(Input.GetKey(KeyCode.S)) { newPosition.z -= movementSpeed * Time.deltaTime; }
        if(Input.GetKey(KeyCode.D)) { newPosition.x += movementSpeed * Time.deltaTime; }

        // Basic camera key controls
        if (Input.GetKey(KeyCode.UpArrow)) { transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.Self); }
        if (Input.GetKey(KeyCode.LeftArrow)) { transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.Self); }
        if (Input.GetKey(KeyCode.DownArrow)) { transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.Self); }
        if (Input.GetKey(KeyCode.RightArrow)) { transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.Self); }

        transform.position = newPosition;
    }
}
