using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BatScript : MonoBehaviour
{
    [SerializeField] Transform target;

    


    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Peter").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;


    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Peter")
        {
            transform.position = new Vector2(33.2f, 85.8f);
        }

    }

        // Update is called once per frame
        void Update()
    {
            agent.SetDestination(target.position);
        if (GetComponent<PeterScript>().reset == true)
        {
            transform.position = new Vector2(33.2f, 85.8f);
        }
        
        




    }
   
}
