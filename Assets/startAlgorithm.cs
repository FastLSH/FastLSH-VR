using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class startAlgorithm : MonoBehaviour {


	public GameObject cylinderPrefab;
	public GameObject ball;
	public GameObject dataPoints;

	public GameObject dataPointsDup;
	bool startMove = false;
	bool finish = false;
	int finishCount;
	List<Vector3> targetList;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		if (startMove) {
			for(int i=0;i<dataPointsDup.transform.childCount;i++){
				Transform ob = dataPointsDup.transform.GetChild (i);
				if (ob.position == targetList [i])
					continue;
				ob.position = Vector3.MoveTowards(ob.position,targetList[i],0.01f);
				if (ob.position == targetList [i])
					finishCount++;
			}

		}


		
	}


	public void startDemo(){
		Random r = new Random();
		for (int i = 0; i < 100; i++) {
			Vector3 cVector = new Vector3 (r.Next (0, 50) * 1000.0f, r.Next (0, 50) * 1000.0f, r.Next (0, 50) * 1000.0f);
			GameObject cylinder = CreateCylinderBetweenPoints (Vector3.zero, cVector, 0.2f);
			movePoints (cVector);
			startMove = true;
			finishCount = 0;
			while (finishCount<dataPoints.transform.childCount) {
			}
			Destroy (cylinder);
		}
	}


	public GameObject CreateCylinderBetweenPoints(Vector3 start, Vector3 end, float width)
	{
		var offset = end - start;
		var scale = new Vector3(width, offset.magnitude / 2.0f, width);
		var position = start + (offset / 2.0f);

		var cylinder = Instantiate(cylinderPrefab, position, Quaternion.identity);
		Debug.Log ("DRAWED");
		cylinder.transform.up = offset;

		cylinder.transform.localScale = scale;

		return cylinder;
	}


	public void movePoints(Vector3 line){
		
		for(int i=dataPointsDup.transform.childCount-1;i>=0;i--){
			Destroy (dataPointsDup.transform.GetChild(i).gameObject);
		}

		Debug.Log ("start move");
		targetList = new List<Vector3> (dataPoints.transform.childCount);

		Debug.Log (dataPoints.transform.childCount);
		for(int i=0;i<dataPoints.transform.childCount;i++){

			Transform ob = dataPoints.transform.GetChild (i);

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
