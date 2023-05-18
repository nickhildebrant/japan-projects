using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDay1b : MonoBehaviour
{
    public Transform prefab;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            Transform temp = Instantiate(prefab, new Vector3(i * 10, 0, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
