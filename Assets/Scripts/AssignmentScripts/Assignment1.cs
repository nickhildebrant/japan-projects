using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment1 : MonoBehaviour
{
    int step = 0;
    const int NUM_BALLS = 10;
    GameObject[] balls;

    public Transform prefab;
    public int spawnTimer = 90;

    // Start is called before the first frame update
    void Start()
    {
        GenerateBalls();
    }

    // Update is called once per frame
    void Update()
    {
        step++;

        // Every 3 seconds spawn in a new set of balls
        if(step % spawnTimer == 0) { GenerateBalls(); }

        // When the Space key is pressed all balls are destroyed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            balls = GameObject.FindGameObjectsWithTag("Ball");
            foreach(var ball in balls) { GameObject.Destroy(ball.gameObject); }
        }
    }

    /// <summary>
    /// Generates the balls of the program. Amount is determined by provided number
    /// </summary>
    private void GenerateBalls()
    {
        for (int i = 0; i < NUM_BALLS; i++)
        {
            var ball = Instantiate(prefab, new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f)), Quaternion.identity);
            ball.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-15f, 15f), 0, Random.Range(-15f, 15f)));
        }
    }
}
