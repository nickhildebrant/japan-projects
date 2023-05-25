using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public GameObject canvas;

    public Vector3 offset;

    Transform mainCamera;
    Transform unit;
    Transform WorldSpaceCanvas;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.transform;
        unit = transform.parent;
        WorldSpaceCanvas = canvas.transform;

        transform.SetParent(WorldSpaceCanvas);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - mainCamera.position);
        transform.position = unit.position + offset;
    }
}