using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camcorder : MonoBehaviour {
    public Transform elvis;
    private Vector3 offset;

	void Start () {
        offset = new Vector3(0, 8, 9);
    }
	

	void Update () {
        transform.position = elvis.position + offset;
    }
}
