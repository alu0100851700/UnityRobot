using UnityEngine;
using System.Collections;

public class RobotBase : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.FindChild ("baseAxis/joint1") != null)
			transform.FindChild ("visibleObject").localPosition = new Vector3(0, -0.23f, 0);
		else
			transform.FindChild ("visibleObject").localPosition = new Vector3(0, -0.105f, 0);
	}
}
