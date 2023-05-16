using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is attached to a moving object that has collision detection.
/// Object will move A to B.
/// </summary>
public class MoveAtoB : MonoBehaviour
{
    public Transform targetA, targetB;

    public float speed = 1.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 directionVector = Vector3.Normalize(targetB.position - targetA.position);
        transform.rotation = Quaternion.LookRotation(directionVector);

        transform.position += speed * directionVector * Time.deltaTime;
    }
}
