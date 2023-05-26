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

        if(frustrationTimer >= 120 && !isleaving)
        {
            foundSeat = true;
            finalDestination = GameObject.FindGameObjectsWithTag("Finish")[Random.Range(0, GameObject.FindGameObjectsWithTag("Finish").Length)];
            agent.isStopped = false;
            agent.destination = finalDestination.transform.position;
            GetComponentInChildren<Renderer>().material = angryColor;

            isleaving = true;
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
            isleaving = true;
        }

        if (finalDestination && Vector3.Distance(finalDestination.transform.position, transform.position) <= (agent.radius * 3)) GoingHome();
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
            if (GetComponentInChildren<Renderer>().material == happyColor)
            {
                int i = PlayerPrefs.GetInt("SatisfiedCustomers");
                PlayerPrefs.SetInt("SatisfiedCustomers", ++i);

                int j = PlayerPrefs.GetInt("TotalHappyTime");
                PlayerPrefs.SetInt("TotalHappyTime", j + (int)frustrationTimer);

                int min = PlayerPrefs.GetInt("MinHappyTime");
                if (min > (int)frustrationTimer) PlayerPrefs.SetInt("MinHappyTime", (int)frustrationTimer);

                int max = PlayerPrefs.GetInt("MaxHappyTime");
                if (max < (int)frustrationTimer) PlayerPrefs.SetInt("MaxHappyTime", (int)frustrationTimer);
            }
            else
            {
                int i = PlayerPrefs.GetInt("AngryCustomers");
                PlayerPrefs.SetInt("AngryCustomers", ++i);

                int j = PlayerPrefs.GetInt("TotalAngryTime");
                PlayerPrefs.SetInt("TotalAngryTime", j + (int)frustrationTimer);

                int min = PlayerPrefs.GetInt("MinAngryTime");
                if (min > (int)frustrationTimer) PlayerPrefs.SetInt("MinAngryTime", (int)frustrationTimer);

                int max = PlayerPrefs.GetInt("MaxAngryTime");
                if (max < (int)frustrationTimer) PlayerPrefs.SetInt("MaxAngryTime", (int)frustrationTimer);
            }

            GameObject.Destroy(gameObject);

            return true;
        }

        return false;
    }
}
