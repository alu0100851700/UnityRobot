using UnityEngine;
using System.Collections;

public class JointsSceneManager : MonoBehaviour {


	int nLinks_;
	string[] selStrings = new string[] {"X", "Y", "Z"};

	// Use this for initialization
	void Start () {
		nLinks_ = PlayerPrefs.GetInt ("nLinks");
	}

	void Update () {
		

	}

	public void changeScene (string scene) {
		Application.LoadLevel (scene);
	}

	void OnGUI(){
		//******************* HEADLINES *******************
		GUI.Label 		(new Rect (100, 60, 50, 20), "MIN");
		GUI.Label 		(new Rect (150, 60, 50, 20), "MAX");
		GUI.Label 		(new Rect (200, 60, 80, 20), "ANGULAR");
		GUI.Label 		(new Rect (360, 60, 150, 20), "INITIAL VALUE");

		for (int i = 0; i < nLinks_; i++) {
			//*********************** LIMITS OF JOINT **************************************
			GUI.Label 		(new Rect (50, 100 + i * 30, 50, 20), "Joint " + i.ToString());
			//***** MIN LIMIT *****
			string minT = PlayerPrefs.GetInt ("joint" + i.ToString () + "min", 0).ToString();
			PlayerPrefs.SetInt ("joint" + i.ToString() + "min" ,
				int.Parse (GUI.TextField 	(new Rect (100, 100 + i * 30, 45, 20), minT, 20)));

			//***** MAX LIMIT *****
			string maxT = PlayerPrefs.GetInt ("joint" + i.ToString () + "max", 0).ToString();
			PlayerPrefs.SetInt ("joint" + i.ToString() + "max" ,
				int.Parse (GUI.TextField 	(new Rect (150, 100 + i * 30, 45, 20), maxT, 20)));

			//*********************** TYPE OF JOINT **************************************
			bool angularB = PlayerPrefs.GetInt ( "joint" + i.ToString() + "angular", 1) == 0? false : true;

			PlayerPrefs.SetInt ( "joint" + i.ToString() + "angular" , 
				GUI.Toggle (new Rect (220, 100 + i * 30, 20, 20), angularB , "") ? 1 : 0);

			//*********************** AXIS MOVEMENT **************************************
			if (PlayerPrefs.GetInt ("joint" + i.ToString () + "angular", 1) == 1) {		//ARTICULACION ANGULAR
				int selGridInt = PlayerPrefs.GetInt ( "joint" + i.ToString() + "axis", 1);
				PlayerPrefs.SetInt ( "joint" + i.ToString() + "axis" ,
					GUI.SelectionGrid(new Rect(250, 100 + i * 30, 100, 20), selGridInt, selStrings, 3));
			}

			//*********************** INIT VALUE **************************************
			int initValue = PlayerPrefs.GetInt ( "joint" + i.ToString() + "init", 1);

			PlayerPrefs.SetInt ("joint" + i.ToString() + "init" ,
				int.Parse (GUI.TextField 	(new Rect (390, 100 + i * 30, 30, 20), initValue.ToString(), 20)));
		}
	}



}
