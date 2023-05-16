using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script is attached to the main camera
/// </summary>
public class CameraMove : MonoBehaviour
{
    public float movementSpeed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        
        // Basic camera key controls
        if(Input.GetKey(KeyCode.W)) { newPosition.z -= movementSpeed * Time.deltaTime; }
        if(Input.GetKey(KeyCode.A)) { newPosition.x += movementSpeed * Time.deltaTime; }
        if(Input.GetKey(KeyCode.S)) { newPosition.z += movementSpeed * Time.deltaTime; }
        if(Input.GetKey(KeyCode.D)) { newPosition.x -= movementSpeed * Time.deltaTime; }

        transform.position = newPosition;  // Updates the camera position
    }
}
