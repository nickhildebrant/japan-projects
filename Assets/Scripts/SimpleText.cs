using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

/// <summary>
/// Attach this script to the TextMeshPro UI Object;
/// </summary>
public class SimpleText : MonoBehaviour
{
    TextMeshProUGUI message;

    // Start is called before the first frame update
    void Start()
    {
        message = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        message.text = Time.time.ToString("0.00");
    }
}
