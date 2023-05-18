using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach to Prefab Street Node. Handles the street stops
/// </summary>
public class StreetNode : MonoBehaviour
{
    public Transform[] nextNodes;
    public Vector3[] directions;

    // Start is called before the first frame update
    void Start()
    {
        if (nextNodes.Length == 0) return;

        directions = new Vector3[nextNodes.Length];
        for(int i = 0; i < nextNodes.Length; i++)
        {
            directions[i] = Vector3.Normalize(nextNodes[i].position - transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
