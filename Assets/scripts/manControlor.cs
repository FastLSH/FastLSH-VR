﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class manControlor : MonoBehaviour {

//	private CardboardHead head;
	public Transform vrCamera;

	// Use this for initialization
	void Start () {

	//	GvrC
	}
	
	// Update is called once per frame
	void Update () {

		float y = vrCamera.eulerAngles.y;
//		GV

		float oriX = transform.eulerAngles.x;
		float oriY = transform.eulerAngles.z;

		transform.eulerAngles = new Vector3 (oriX, y, oriY);
	
		Vector3 pos = vrCamera.position;
		pos [1] = pos [1] - 1;

		transform.position = pos;


		
	}
}
