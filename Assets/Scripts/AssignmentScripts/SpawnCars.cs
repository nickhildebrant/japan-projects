using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    private float timer = 0.5f;

    public Transform destination;
    public GameObject carPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 5.0f)
        {
            timer = 0.0f;
            GameObject newCar = GameObject.Instantiate(carPrefab, transform.position, Quaternion.identity);
            newCar.GetComponent<CarAI>().destination = destination;
        }
    }
}