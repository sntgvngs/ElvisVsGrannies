using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ElvisScript : MonoBehaviour {
    Animator anim;
    NavMeshAgent agent;
    public GameObject target;
    private Transform targetTransform;
    private Transform myTransform;
    Vector3 lastPos;
    float dist;
    float threshold = 0.001f;
	// Use this for initialization
	void Start () {
        targetTransform = target.GetComponent<Transform>();
        myTransform = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        lastPos = myTransform.position;
        anim.SetBool("isMoving", false);
	}
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(targetTransform.position);
        dist = Vector3.Distance(myTransform.position, lastPos);
        if (dist > threshold)
            anim.SetBool("isMoving", true);
        else
            anim.SetBool("isMoving", false);
        lastPos = myTransform.position;
	}
}
