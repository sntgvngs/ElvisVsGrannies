using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrannyScript : MonoBehaviour {
    Animator anim;

    private bool isPaused;

    public static GameObject elvis;
    public static Transform elvisT;
    public static Vector3 midpoint;
    public Camcorder mainCam;

    private Vector3 momentum;
    private Rigidbody rig;

    static float wStalk = 1;
    static float wMomentum = 15;

    private float stalkDistance = 5;
    Vector3 lastPos;
    Quaternion lastRot;

    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
        anim.SetBool("isRunning", false);
        anim.SetBool("isFalling", false);
        lastPos = transform.position;
        lastRot = transform.rotation;
    }
    void Update()
    {
        if(isPaused)
        {
            transform.position = lastPos;
            transform.rotation = lastRot;
        } else
        {
            if ((transform.position - lastPos).y < -0.01)
            {
                anim.SetBool("isFalling", true);
            }
            else
            {
                if (Vector3.Distance(transform.position, elvisT.position) <= stalkDistance)
                {
                    if (Vector3.Distance(transform.position, elvisT.position) <= 1)
                        GameObject.Find("Main Camera").GetComponent<Camcorder>().Lose();
                    anim.SetBool("isRunning", true);
                    momentum = wStalk * (elvisT.position - transform.position).normalized + wMomentum * momentum;
                    momentum = momentum.normalized * 4f;
                    rig.MovePosition(transform.position + momentum * Time.deltaTime);
                    rig.MoveRotation(Quaternion.LookRotation(momentum));
                }
                else
                {
                    momentum = Vector3.zero;
                    anim.SetBool("isRunning", false);
                }
                lastPos = transform.position;
                lastRot = transform.rotation;
            }
        }
        
    }

    public void Pause()
    {
        if (!isPaused)
        {
            anim.enabled = false;
        }
        else
        {
            anim.enabled = true;
        }
        isPaused = !isPaused;
    }
}
