using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawLine : MonoBehaviour {


	public GameObject cylinderPrefab;


	// Use this for initialization
	void Start () {
//		Debug.Log ("START");
//		CreateCylinderBetweenPoints(Vector3.zero, new Vector3(1000f, 1000f, 1000f), 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void CreateCylinderBetweenPoints(Vector3 start, Vector3 end, float width)
	{
		var offset = end - start;
		var scale = new Vector3(width, offset.magnitude / 2.0f, width);
		var position = start + (offset / 2.0f);

		var cylinder = Instantiate(cylinderPrefab, position, Quaternion.identity);
		cylinder.transform.up = offset;

		cylinder.transform.localScale = scale;
	}


}
