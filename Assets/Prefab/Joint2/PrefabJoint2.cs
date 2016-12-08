using UnityEngine;
using System.Collections;


public class PrefabJoint2 : MonoBehaviour {
	//****** CONSTATS *******
	const bool X =  true;
	const bool Z =  false;

	bool rotationSign;
	bool rotationAxis;
	public float a;
	Transform vChildren;

	// Use this for initialization
	void Start () {
		rotationAxis = Z;
		rotationSign = true;
	}

	// Update is called once per frame
	void Update () {
		//SET TEXT ANGLE
		//GetComponent<TextMesh>().text = "  " + this.transform.localEulerAngles.x.ToString ("F2") + "º";
		rotateChildrens (a);

	}

	public bool rotateChildrens(float angle){
		foreach (Transform children in transform) {
			if (children.name.Contains ("Joint")) {
				children.RotateAround (
					transform.position,
					rotationAxis == Z ? transform.forward :  transform.right,
					rotationSign? -angle : angle);
			}
		}

		return true;
	}

	public void rotateOverZ(bool sign){
		rotationAxis = Z;
		rotationSign = sign;
		if(sign == true)
			transform.FindChild ("visibleObject").localRotation = Quaternion.Euler (0,0,0);
		else
			transform.FindChild ("visibleObject").localRotation = Quaternion.Euler (0,-180,0);
	}

	public void rotateOverX(bool sign){
		rotationAxis = X;
		rotationSign = sign;
		if(sign == true)
			transform.FindChild ("visibleObject").localRotation = Quaternion.Euler (0,90,0);
		else
			transform.FindChild ("visibleObject").localRotation = Quaternion.Euler (0,-90,0);
	}

	public void linkSize(float size){
		transform.FindChild ("visibleObject/Link").localScale = new Vector3 (1, size, 1);
	}

}
