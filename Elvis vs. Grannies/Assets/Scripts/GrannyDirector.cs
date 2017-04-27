using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GrannyDirector : MonoBehaviour {
    public GameObject grannyObject;
    public Camcorder mainCam;

    private bool isPaused;
    private float pauseTime;

    private ArrayList grannies;
    private bool started;
    private float nextGran;

	// Use this for initialization
	void Start () {
        grannies = new ArrayList();
        started = false;
        pauseTime = 3;
        isPaused = true;
        GrannyScript.elvis = GameObject.Find("Big_Vegas");
        GrannyScript.elvisT = GrannyScript.elvis.transform;
	}
	
	// Update is called once per frame
	void Update () {
        if(!isPaused)
        {
            if (Time.time >= nextGran)
            {
                started = true;
                nextGran = Time.time + 7;
                grannies.Add(Instantiate(grannyObject, RandomPoint(), Quaternion.identity, transform));
            }
            for (int i = grannies.Count - 1; i >= 0; i--)
            {
                if ((grannies[i] as GameObject).transform.position.y < -10)
                {
                    Destroy(grannies[i] as GameObject);
                    grannies.RemoveAt(i);
                }
            }
            if (grannies.Count < 1 && started)
                mainCam.Win();
        }		
    }

    Vector3 RandomPoint()
    {
        for ( int i = 0; i < 30; i++)
        {
            Vector3 point = Random.insideUnitSphere * 20;
            point = point - Vector3.up * point.y;
            NavMeshHit hit;
            if(NavMesh.SamplePosition(point, out hit, 1.0f, NavMesh.AllAreas))
            {
                return hit.position;
            }
        }
        return Vector3.zero;
    }

    public void Pause()
    {
        isPaused = !isPaused;
        if (isPaused)
            pauseTime = nextGran - Time.time;
        else
            nextGran = Time.time + pauseTime;
        foreach(GameObject granny in grannies)
        {
            granny.GetComponent<GrannyScript>().Pause();
        }
    }
}
