using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatStatus : MonoBehaviour
{
    public Material redMaterial, greenMaterial;

    private bool isOpen = true;

    private void OnTriggerEnter(Collider other)
    {
        //print("Seat detected trigger enter");

        if(other.tag == "Customer")
        {
            other.GetComponent<FindASeat>().ShowTimer();
            GetComponent<Renderer>().material = redMaterial;
            isOpen = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //print("Seat detected trigger exit");

        if (other.tag == "Customer")
        {
            GetComponent<Renderer>().material = greenMaterial;
            other.gameObject.GetComponentInParent<FindASeat>().ShowTimer();
            isOpen = true;
        }
    }

    public bool IsOpen()
    {
        return isOpen;
    }

    public void OccupySeat()
    {
        isOpen = false;
    }
}
