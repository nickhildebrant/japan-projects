using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class FindASeat : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject dayNightManager;

    public bool foundSeat = false;

    public float walkingSpeed = 5.0f;
    public int partySize = 1;

    private float timer = 0.0f;

    [SerializeField]
    private GameObject finalDestination;

    public GameObject timerText;

    public GameObject[] friends;

    public Material angryColor, happyColor;
    public float frustrationTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        dayNightManager = GameObject.Find("Directional Light");

        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        frustrationTimer += Time.deltaTime;

        if(frustrationTimer >= 120)
        {
            agent.destination = finalDestination.transform.position;
            GetComponentInChildren<Renderer>().material = angryColor;
        }

        if(foundSeat)
        {
            timer += Time.deltaTime;
            timerText.GetComponent<Text>().text = timer.ToString("0");
        }

        if(timer >= 30.0f)
        {
            agent.destination = finalDestination.transform.position;
            timer = 0;
            timerText.GetComponent<Text>().text = "";
        }

        if (finalDestination && Vector3.Distance(finalDestination.transform.position, transform.position) <= (agent.radius * 3) && foundSeat)
        {
            GameObject.Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Seat")
        {
            int numOfExits = GameObject.FindGameObjectsWithTag("Finish").Length;
            finalDestination = GameObject.FindGameObjectsWithTag("Finish")[Random.Range(0, numOfExits)];

            foundSeat = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Seat")
        {
            GetComponentInChildren<Renderer>().material = happyColor;
            timerText.GetComponent<Text>().enabled = false;
        }

        if(other.tag == "Entrance" && agent.isStopped)
        {
            agent.isStopped = false;
        }
    }

    public void ShowTimer()
    {
        timerText.GetComponent<Text>().enabled = true;
        timerText.GetComponent<Text>().text = timer.ToString("0");
    }    
}
