using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {

	public const int LINEAL  = 0;
	public const int ANGULAR = 1;

	int nLinks_;
	int[] linksData_;
	int[,] jointsData_;
	// Use this for initialization

	GameObject[] links_;
	GameObject[] joints_;

	void Start () {
		
		InicializateRobotValues ();
		MakeRobot ();
		SetInitialValues ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CCD (int x, int y){


	}

		

	void SetInitialValues () {
		for (int i = 0; i < nLinks_; i++) {

			/********************* ALGULAR JOINT ****************************/
			if (jointsData_ [i, 2] == 1) 
				MoveAngularJoint (i, jointsData_[i,4]);

			/********************* LINEAL JOINT ****************************/
			else if (jointsData_ [i, 2] == 0) {
				// EN CONSTRUCCÏON

			}
				
		}
	}

	void InverseKinematics (int x, int y) {

	}

	float GetAngularJoint(int jointNumber){
		float angle = 0.0f;
		if (jointsData_ [jointNumber, 2] == 1) {

			/**** X AXIS ***/
			if (jointsData_ [jointNumber, 3] == 0)
				angle = joints_ [jointNumber].transform.localRotation.x;

			/**** Y AXIS ***/
			else if (jointsData_ [jointNumber, 3] == 1)
				angle = joints_ [jointNumber].transform.localRotation.y;

			/**** Z AXIS ***/
			else if (jointsData_ [jointNumber, 3] == 2)
				angle = joints_ [jointNumber].transform.localRotation.z;
		}

		return angle;
	}


	void MoveAngularJoint(int jointNumber, int value){
		if (jointsData_ [jointNumber, 2] == 1) {

			/**** X AXIS ***/
			if (jointsData_ [jointNumber, 3] == 0)
				joints_[jointNumber].transform.localRotation = Quaternion.Euler( value, 0, 0);

			/**** Y AXIS ***/
			else if (jointsData_ [jointNumber, 3] == 1)
				joints_[jointNumber].transform.localRotation = Quaternion.Euler( 0, value, 0);

			/**** Z AXIS ***/
			else if (jointsData_ [jointNumber, 3] == 2)
				joints_[jointNumber].transform.localRotation = Quaternion.Euler( 0, 0, value);
		}
	}

	void InicializateRobotValues () {
		nLinks_ = PlayerPrefs.GetInt ("nLinks");

		/***************************** LINKS & JOINTS MATRIX *************************************/
		linksData_  = new int[nLinks_];
		jointsData_ = new int[nLinks_, 5];

		for (int i = 0; i < nLinks_; i++) {
			linksData_[i] = PlayerPrefs.GetInt ("link" + i.ToString () + "length");

			jointsData_[i,0] = PlayerPrefs.GetInt ("joint" + i.ToString () + "min");
			jointsData_[i,1] = PlayerPrefs.GetInt ("joint" + i.ToString () + "max");
			jointsData_[i,2] = PlayerPrefs.GetInt ("joint" + i.ToString () + "angular");
			jointsData_[i,3] = PlayerPrefs.GetInt ("joint" + i.ToString () + "axis");
			jointsData_[i,4] = PlayerPrefs.GetInt ("joint" + i.ToString () + "init");
		}
	}

	void MakeRobot () {
		/*************************** MAKE ROBOT JERARCHY ***************************************/
		links_  = new GameObject[nLinks_];
		joints_ = new GameObject[nLinks_];

		links_  = new GameObject[nLinks_];
		joints_ = new GameObject[nLinks_];

		for (int i = 0; i < nLinks_; i++) {
			joints_[i] = new GameObject();
			joints_ [i].name = "Joint" + i;


			GameObject articulation = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
			articulation.name  = "Art"  + i;
			articulation.transform.localScale = new Vector3 (1, 0.5f, 1);
			articulation.transform.parent = joints_ [i].transform;
			if (jointsData_ [i, 3] == 0)
				articulation.transform.localRotation = Quaternion.Euler( 0, 0, 90);

			else if (jointsData_ [i, 3] == 2)
				articulation.transform.localRotation = Quaternion.Euler( 90, 0, 0);


			links_ [i] = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
			links_ [i].name  = "Link"  + i;
			links_ [i].transform.localScale = new Vector3 (0.5f, linksData_ [i], 0.5f);
			links_ [i].transform.parent = joints_ [i].transform;
			links_ [i].transform.localPosition = new Vector3 (0, linksData_ [i], 0);




			if (i > 0) {
				joints_ [i].transform.parent = joints_ [i - 1].transform;
				joints_ [i].transform.localPosition = new Vector3 (0, linksData_[i-1]*2 ,0);
			}
		}

	}


}
