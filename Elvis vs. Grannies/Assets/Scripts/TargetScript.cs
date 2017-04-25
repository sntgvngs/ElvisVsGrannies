using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {
    public GameObject elvis;
    public GameObject target;
    private float d;
    // Use this for initialization
    void Start () {
        d = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Fire2")) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                transform.position = new Vector3(hit.point.x, 0, hit.point.z);
            }
            target.SetActive(true);
        } else
        {
            if (Vector3.Distance(transform.position, elvis.transform.position) < d)
            {
                target.SetActive(false);
            }
        }
	}
}
