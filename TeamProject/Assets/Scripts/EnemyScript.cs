using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{

    Rigidbody rb;
    public GameObject Peter;
    public GameObject[] waypoints;
    public GameObject[] enemy;
    public GameObject[] scatterWP;
    int current = 0;
    float WPradius = 1;
    public float patrolSpeed;
    public float aggroRange;


    private Vector2 initialPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        GameObject Peter = GameObject.FindGameObjectWithTag("Peter");
        initialPosition = transform.position; 
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
    }

    
    void Update()
    {
        if (Peter.GetComponent<PeterScript>().poweredUp == true)
        {
            if (Vector2.Distance(scatterWP[current].transform.position, transform.position) < WPradius)
            {
                current = Random.Range(0, scatterWP.Length);
                if (current >= scatterWP.Length)
                {
                    current = 0;
                }

            }
            GetComponent<NavMeshAgent>().destination = scatterWP[current].transform.position;
            Debug.Log("RUN!");
        }
        if (Peter.GetComponent<PeterScript>().poweredUp == false)
        {
            if (Vector2.Distance(waypoints[current].transform.position, transform.position) < WPradius)
            {
                current = Random.Range(0, waypoints.Length);
                if (current >= waypoints.Length)
                {
                    current = 0;
                }
            }
            GetComponent<NavMeshAgent>().destination = waypoints[current].transform.position;

            if ((Vector2.Distance(transform.position, Peter.transform.position) < aggroRange))
            {
                GetComponent<NavMeshAgent>().destination = Peter.transform.position;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Peter") && Peter.GetComponent<PeterScript>().poweredUp == false)
        {
            enemy[0].transform.position = initialPosition;
            enemy[1].transform.position = initialPosition;
            enemy[2].transform.position = initialPosition;
            enemy[3].transform.position = initialPosition;
        }
        if (other.gameObject.CompareTag("Peter") && Peter.GetComponent<PeterScript>().poweredUp == true)
        {
            gameObject.transform.position = initialPosition;
        }
    }

}
