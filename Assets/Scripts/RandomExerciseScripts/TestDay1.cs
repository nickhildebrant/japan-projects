using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDay1 : MonoBehaviour
{
    public float myDegree = 30f;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, myDegree * Time.deltaTime, 0);
        transform.Translate(2 * Time.deltaTime, 0, 0);
    }
}
