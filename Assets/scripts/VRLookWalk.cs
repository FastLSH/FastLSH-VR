using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRLookWalk : MonoBehaviour {

	public Transform vrCamera;
	 

	public float speed = 0.5f;

	public bool moveForward;
	public GameObject flySpeed;
	private CharacterController cc;


	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		int speedLevel = 2;
		for (int i = 1; i < (flySpeed.transform.childCount-2); i++) {
			if (flySpeed.transform.GetChild (i).gameObject.GetComponent<Toggle> ().isOn){
				speedLevel = i;
				break;
			}
		}

		if (speedLevel == 1)
			speed = 0.005f;
		else if (speedLevel == 2)
			speed = 0.02f;
		else if (speedLevel == 3)
			speed = 0.5f;


		if(Input.GetButtonDown("Fire1")){
			moveForward = true;
		} 

		if (Input.GetButtonUp ("Fire1")) {
			moveForward = false;
		}



		if (moveForward) {
			Vector3 forward = vrCamera.TransformDirection (Vector3.forward);
			Vector3 move;	
			move.x = (float)((double)forward.x * (double)speed);
			move.y = (float)((double)forward.y * (double)speed);
			move.z = (float)((double)forward.z * (double)speed);
			//cc.Move (forward * speed);
			cc.Move (move);
		}

	}
}
