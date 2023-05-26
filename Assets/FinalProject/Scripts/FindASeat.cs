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

    private bool isleaving = false;
    private bool isHappy = false;

    private GameObject EatingSlider;

    private GameObject Storage;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = false;

        dayNightManager = GameObject.Find("Directional Light");

        timerText.GetComponent<Text>().enabled = false;

        EatingSlider = GameObject.Find("Eating Slider");

        Storage = GameObject.FindGameObjectWithTag("Storage");
    }

    // Update is called once per frame
    void Update()
    {
        frustrationTimer += Time.deltaTime;

        if(frustrationTimer >= 120 && !isleaving)
        {
            foundSeat = true;
            finalDestination = GameObject.FindGameObjectsWithTag("Finish")[Random.Range(0, GameObject.FindGameObjectsWithTag("Finish").Length)];
            agent.isStopped = false;
            agent.destination = finalDestination.transform.position;
            GetComponentInChildren<Renderer>().material = angryColor;

            isleaving = true;
            isHappy = false;
        }

        if(timerText.GetComponent<Text>().enabled)
        {
            timer += Time.deltaTime;
            timerText.GetComponent<Text>().text = timer.ToString("0");
        }

        if(timer >= EatingSlider.GetComponent<UnityEngine.UI.Slider>().value)
        {
            agent.destination = finalDestination.transform.position;
            timer = 0;
            timerText.GetComponent<Text>().text = "";
            isleaving = true;
            isHappy = true;
        }

        if (finalDestination && Vector3.Distance(finalDestination.transform.position, transform.position) <= (agent.radius * 5)) GoingHome();
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

        if (other.tag == "Entrance" && agent.isStopped)
        {
            agent.isStopped = false;
        }
    }

    public void ShowTimer()
    {
        timerText.GetComponent<Text>().enabled = true;
        timerText.GetComponent<Text>().text = timer.ToString("0");
    }
    
    public bool GoingHome()
    {
        if(foundSeat || GetComponentInChildren<Renderer>().material == angryColor)
        {
            if (isHappy) Storage.GetComponent<StorageScript>().UpdateHappy((int)frustrationTimer);
            else Storage.GetComponent<StorageScript>().UpdateAngry((int)frustrationTimer);

            GameObject.Destroy(gameObject);

            return true;
        }

        return false;
    }
}
