using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach to the main camera
/// </summary>
public class ExerciseShooting : MonoBehaviour
{
    public Transform prefabBullet;
    public float shootForce = 1000f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Transform temp = Instantiate(prefabBullet, new Vector3(0, 2, 0), Quaternion.identity);
            temp.GetComponent<Rigidbody>().AddForce(shootForce * transform.forward);
        }
    }
}
