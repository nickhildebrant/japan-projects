using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColors : MonoBehaviour
{
    public GameObject correctObject;

    public Material redMaterial;

    void OnTriggerEnter(Collider other)
    {
        if (other == correctObject.GetComponent<Collider>()) 
        { 
            print("Entered");
            correctObject.GetComponent<Renderer>().enabled = true; //show up
            correctObject.GetComponent<Renderer>().material = redMaterial;
        }
    }
}
