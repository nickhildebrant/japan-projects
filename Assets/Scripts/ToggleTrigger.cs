using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script should be attached to the gameobject,
/// or zone, that a GameObject will enter.
/// </summary>
public class ToggleTrigger : MonoBehaviour
{
    public GameObject correctObject;

    void OnTriggerEnter(Collider other)
    {
        if (other == correctObject.GetComponent<Collider>()) { print("Entered"); }
    }

    void OnTriggerExit(Collider other)
    {
        if (other == correctObject.GetComponent<Collider>()) { print("Exit"); }
    }

}
