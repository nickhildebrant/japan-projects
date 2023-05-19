using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatStatus : MonoBehaviour
{
    public Material redMaterial, greenMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Customer")
        {
            GetComponent<Renderer>().material = redMaterial;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Customer")
        {
            GetComponent<Renderer>().material = greenMaterial;
        }
    }
}
