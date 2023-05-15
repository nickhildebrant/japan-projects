using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach to the main camera
/// </summary>
public class SimpleShoot : MonoBehaviour
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
        if(Input.GetButtonDown("Jump"))
        {
            Transform temp = Instantiate(prefabBullet, transform.position, Quaternion.identity);
            temp.GetComponent<Rigidbody>().AddForce(shootForce * transform.forward);
        }
    }
}
