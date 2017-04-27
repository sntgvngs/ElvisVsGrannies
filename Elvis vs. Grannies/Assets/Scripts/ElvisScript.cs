using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ElvisScript : MonoBehaviour {
    Animator anim;
    NavMeshAgent agent;

    public GameObject target;
    private bool isPaused;
    private Vector3 pausedDest;

    private Transform targetTransform;
    Vector3 lastPos;
    float dist;
    float threshold = 0.001f;
	// Use this for initialization
	void Start () {
        targetTransform = target.GetComponent<Transform>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        lastPos = transform.position;
        anim.SetBool("isMoving", false);
        isPaused = false;
        Pause();
	}
	
	// Update is called once per frame
	void Update () {
        if (!isPaused)
        {
            agent.SetDestination(targetTransform.position);
            dist = Vector3.Distance(transform.position, lastPos);
            if (dist > threshold)
                anim.SetBool("isMoving", true);
            else
                anim.SetBool("isMoving", false);
            lastPos = transform.position;
        }
	}

    public void Pause()
    {
        if(!isPaused)
        {
            pausedDest = agent.destination;
            agent.SetDestination(transform.position);
            anim.enabled = false;
        } else
        {
            agent.SetDestination(pausedDest);
            anim.enabled = true;
        }
        isPaused = !isPaused;
    }

}
