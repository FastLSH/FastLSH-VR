using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showStatus : MonoBehaviour {


	public GameObject dataCanvas;
	private Text textField;


	// Use this for initialization
	void Start () {
		textField = dataCanvas.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void ShowStatus(){
		Transform  trans= this.gameObject.transform;
		textField.text = this.gameObject.name+"\n"+"x: "+(trans.position.x-100).ToString("0.00")+" \ny: "
			+(trans.position.y-100).ToString("0.00") + " \nz: "+ (trans.position.z-100).ToString("0.00");
	}
}
