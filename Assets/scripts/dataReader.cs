using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using System.Linq;
using UnityEngine;


public class dataReader : MonoBehaviour {

	public GameObject ball;
	public GameObject cube;
	public GameObject capsule;
	public GameObject dataPoints;

	// Use this for initialization
	void Start () {
		List<Color> colorList = new List<Color> () {

			Color.red,
			Color.green,
			Color.yellow,
			Color.magenta,
			new Color(255F, 0F, 255F),    
			new Color(0F, 255F, 255F),    
			new Color(255F, 255F, 0F),
			new Color(128F, 0F, 128F),    
			new Color(128F, 0F, 0F)
		};
			

		List<string> classList = new List<string> ();

		Debug.Log ("It is working");

		var data = System.IO.File.ReadAllLines(Application.dataPath + "/Resources/vis_data/Iris_normalized.csv").Select(x => x.Split(',')).ToArray();
		//var data = System.IO.File.ReadAllLines("./Assets/vis_data/Iris.csv").Select(x => x.Split(',')).ToArray();


		for (int i = 1; i < data.GetLength(0); i++) {
//			Debug.Log (data[i][3]);
			GameObject ob = Instantiate (ball, new Vector3 (float.Parse(data[i][2])+100, float.Parse(data[i][3])+100, float.Parse(data[i][4])+100), Quaternion.identity, dataPoints.transform) as GameObject;
			ob.name = data [i] [0] + "-" + data[i][1];

			if (!classList.Contains(data[i][1])){
				classList.Add(data[i][1]);
			}


			ob.GetComponent<Renderer> ().material.color = colorList[classList.IndexOf(data[i][1])];
		}
	

//		Physics.gravity = new Vector3(0,0,0);	
//		float scale = 60;
//		int number = 2000;
//		Random rnd = new Random ();
//		for (int i = 0; i < number; i++) {
//			Instantiate (ball, new Vector3 ((float)(103 + rnd.NextDouble()*scale), (float)(103 + rnd.NextDouble()*scale), (float)(103 + rnd.NextDouble()*scale)), Quaternion.identity);
//			Instantiate(cube, new Vector3 ((float)(60 + rnd.NextDouble()*scale), (float)(60 + rnd.NextDouble()*scale), (float)(97 + rnd.NextDouble()*scale)), Quaternion.identity);
//			Instantiate(capsule, new Vector3 ((float)(93 + rnd.NextDouble()*scale), (float)(70 + rnd.NextDouble()*scale), (float)(70 + rnd.NextDouble()*scale)), Quaternion.identity);
//		}


		//	Instantiate (ball, transform.position, transform.rotation);


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
