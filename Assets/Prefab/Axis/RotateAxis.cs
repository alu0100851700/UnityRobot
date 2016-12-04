using UnityEngine;
using System.Collections;

public class RotateAxis : MonoBehaviour {

	float XRotation = 0f;
	float ZRotation = 0f;

	void Start() {
		XRotation = PlayerPrefs.GetFloat ("XRotation");
		ZRotation = PlayerPrefs.GetFloat ("ZRotation");
		if 		(this.name == "X") 	this.transform.parent.Rotate (XRotation, 0f, 0f);
		else if (this.name == "Z") 	this.transform.parent.Rotate (0f, 0f, ZRotation);
	}

	void OnMouseUp() {
		
		Debug.Log ("X Pushed");
		if (this.name == "X") {
			this.transform.parent.Rotate (-90f, 0f, 0f);
			XRotation = -90.0f;
			PlayerPrefs.SetFloat ("XRotation", XRotation);
		} else if (this.name == "Z") {
			this.transform.parent.Rotate (0f, 0f, -90f);
			ZRotation = -90.0f;
			PlayerPrefs.SetFloat ("ZRotation", ZRotation);
		}
	}
}
