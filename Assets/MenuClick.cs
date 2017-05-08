using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Linq;
using UnityEngine.UI;
using Random = System.Random;

public class MenuClick : MonoBehaviour {

	public GameObject ball;
	public GameObject dataPoints;

	public GameObject dataPointsDup;
	public GameObject dataSelected;
	public GameObject dimInfo;


	bool startMove = false;
	List<Vector3> targetList;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (startMove) {
			for(int i=0;i<dataPointsDup.transform.childCount;i++){

				Transform ob = dataPoints.transform.GetChild (i);

				ob.position = Vector3.MoveTowards(ob.position,targetList[i],0.01f);
			}
		
		}

		
	}

	public void drawPoints(){

		for(int i=dataPoints.transform.childCount-1;i>=0;i--){
			Destroy (dataPoints.transform.GetChild(i).gameObject);
		}


		int dataType = 1;
	
		for (int i = 1; i < dataSelected.transform.childCount; i++) {
			if (dataSelected.transform.GetChild (i).gameObject.GetComponent<Toggle> ().isOn){
				dataType = i;
				break;
			}
		}
		Debug.Log (dataType);


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
		List<int> dimList = new List<int>();



		var data = System.IO.File.ReadAllLines("./Assets/vis_data/Iris.csv").Select(x => x.Split(',')).ToArray();
		if(dataType==1)
			 data = System.IO.File.ReadAllLines("./Assets/vis_data/Iris.csv").Select(x => x.Split(',')).ToArray();
		else if (dataType==2)
			 data = System.IO.File.ReadAllLines("./Assets/vis_data/glass.csv").Select(x => x.Split(',')).ToArray();
		else if(dataType==3)
			 data = System.IO.File.ReadAllLines("./Assets/vis_data/author.csv").Select(x => x.Split(',')).ToArray();
	
		int dimNumber = data[0].GetLength (0);

		Random r = new Random();

		while(dimList.Count<3){
			int rInt = r.Next(3, dimNumber);
			if (!dimList.Contains (rInt))
				dimList.Add (rInt);
		}


		dimInfo.transform.Find ("D1").Find ("Text").GetComponent<Text> ().text = data[0][dimList[0]];
		dimInfo.transform.Find ("D2").Find ("Text").GetComponent<Text> ().text = data[0][dimList[1]];
		dimInfo.transform.Find ("D3").Find ("Text").GetComponent<Text> ().text = data[0][dimList[2]];

		Debug.Log ("read");
		for (int i = 1; i < data.GetLength(0); i++) {
			GameObject ob = Instantiate (ball, new Vector3 (float.Parse(data[i][dimList[0]])+100, float.Parse(data[i][dimList[1]])+100, float.Parse(data[i][dimList[2]])+100), Quaternion.identity, dataPoints.transform) as GameObject;
			ob.name = data [i] [0] + "-" + data[i][1];


			if (!classList.Contains(data[i][1])){
				classList.Add(data[i][1]);
			}


			ob.GetComponent<Renderer> ().material.color = colorList[classList.IndexOf(data[i][1])];
		}
		Debug.Log ("draw");

		movePoints ();
			
	}

	public void movePoints(){

		for(int i=dataPointsDup.transform.childCount-1;i>=0;i--){
			Destroy (dataPointsDup.transform.GetChild(i).gameObject);
		}

		Debug.Log ("start move");
		targetList = new List<Vector3> (dataPoints.transform.childCount);

		Debug.Log (dataPoints.transform.childCount);
		for(int i=0;i<dataPoints.transform.childCount;i++){

			Transform ob = dataPoints.transform.GetChild (i);
			Vector3 line = new Vector3 (1000f, 1000f, 1000f);

			//Vector3 target = Vector3.Scale(ob.position,line).magnitude/(line.magnitude) * (line.normalized);
//			Vector3 target = Vector3.Scale (ob.position, line.normalized).magnitude * line.normalized;
			Vector3 target  = Vector3.Dot (ob.position, line.normalized) * line.normalized;
			Debug.Log (target);
			targetList.Add(target);
			startMove = true;

			GameObject obj = Instantiate (ob.gameObject,dataPointsDup.transform) as GameObject;
			Color c = obj.GetComponent<Renderer> ().material.color;
			c.a = 0.2f;
			obj.GetComponent<Renderer> ().material.color= c;
//			ob.position = Vector3.MoveTowards(ob.position,target,1f);
		}

	}


}
