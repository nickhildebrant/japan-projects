using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CarView : MonoBehaviour
{
    private bool isClose;
    private bool isStop;

    public Material greenMaterial, redMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update
        if (isClose || isStop) gameObject.transform.parent.GetComponent<CarMove>().speed = 0;
        gameObject.transform.parent.GetComponent<Renderer>().material = redMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Trigger Enter
        if (other.tag == "Car") isClose = true;
    }

    private void OnTriggerExit(Collider other)
    {
        // Trigger Exit
        if (other.tag == "Car") isClose = false;

        gameObject.transform.parent.GetComponent<CarMove>().speed = Random.Range(2, 5);
        gameObject.transform.parent.GetComponent<Renderer>().material = greenMaterial;
    }
}
