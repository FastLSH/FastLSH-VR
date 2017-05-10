using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasControlSide : MonoBehaviour {

	public Transform vrCamera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = vrCamera.position;
		pos [0] = pos [0] - 1.8f;
		pos [1] = pos [1] - 1;
		pos [2] = pos [2] ; 

		transform.position = pos;
	}
}
