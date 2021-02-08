using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class RockScript : MonoBehaviour
{
    [SerializeField] Transform target;

    [SerializeField] Transform runpoint;
    public static int level;
    Animator animator;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 1"))
        {
            level = 1;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 2"))
        {
            level = 2;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Menu"))
        {
            level = 0;
        }
        target = GameObject.FindGameObjectWithTag("Peter").transform;
        runpoint = GameObject.FindGameObjectWithTag("Runpoint").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        animator = GetComponent<Animator>();

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Peter" && target.GetComponent<PeterScript>().poweredUp == false)
        {
            target.GetComponent<PeterScript>().reset = true;
        }
        if (collision.collider.tag == "Peter" && target.GetComponent<PeterScript>().poweredUp == true)
        {
            target.GetComponent<PeterScript>().reset = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (level == 1)
        {
            if (target.GetComponent<PeterScript>().reset == true)
            {
                transform.position = new Vector2(33f, 86.9f);
                agent.SetDestination(target.position);
                animator.SetInteger("State", 0);
            }
            if (target.GetComponent<PeterScript>().poweredUp == false)
            {
                agent.SetDestination(target.position);
                animator.SetInteger("State", 0);
            }

            if (target.GetComponent<PeterScript>().poweredUp == true)
            {
                animator.SetInteger("State", 1);
            }
        }
        if (level == 2)
        {
            if (target.GetComponent<PeterScript>().reset == true)
            {
                transform.position = new Vector2(321.4f, 86.2f);
                agent.SetDestination(target.position);
                animator.SetInteger("State", 0);
            }
            if (target.GetComponent<PeterScript>().poweredUp == false)
            {
                agent.SetDestination(target.position);
                animator.SetInteger("State", 0);
            }

            if (target.GetComponent<PeterScript>().poweredUp == true)
            {
                animator.SetInteger("State", 1);
            }
        }





    }

}
