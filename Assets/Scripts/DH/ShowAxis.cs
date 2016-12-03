using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowAxis : MonoBehaviour {
	/*
	public 	GameObject	Axis;
			GameObject 	X ,Y, Z;

	float  	FirstXRotation = 0.0f, 
			FirstYRotation = 0.0f, 
			FirstZRotation = 0.0f;

	// Use this for initialization
	void Start () {
		

		X = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
		X.transform.name = "X";
		Y = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
		Y.transform.name = "Y";
		Z = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
		Z.transform.name = "Z";



		X.transform.localScale = new Vector3 (0.05f, 1f, 0.05f);
		Y.transform.localScale = new Vector3 (0.05f, 1f, 0.05f);
		Z.transform.localScale = new Vector3 (0.05f, 1f, 0.05f);

		X.transform.Rotate (new Vector3(0.0f,0.0f,90));
		Y.transform.Rotate (new Vector3(0.0f,0.0f,0.0f));
		Z.transform.Rotate (new Vector3(-90.0f,0.0f,0.0f));

		X.transform.position += new Vector3 (1.0f, 0f, 0.0f);
		Y.transform.position += new Vector3 (0.0f, 1f, 0.0f);
		Z.transform.position += new Vector3 (0.0f, 0.0f, 1f);

		Renderer rendX = X.transform.GetComponent<Renderer> ();
		rendX.material.shader = Shader.Find ("Specular");
		rendX.material.SetColor ("_Color", Color.red);

		Renderer rendY = Y.transform.GetComponent<Renderer> ();
		rendY.material.shader = Shader.Find ("Specular");
		rendY.material.SetColor ("_Color", Color.green);

		Renderer rendZ = Z.transform.GetComponent<Renderer> ();
		rendZ.material.shader = Shader.Find ("Specular");
		rendZ.material.SetColor ("_Color", Color.blue);

		X.transform.parent = Axis.transform;
		Y.transform.parent = Axis.transform;
		Z.transform.parent = Axis.transform;
		X.transform.localPosition += Axis.transform.localPosition;
		Y.transform.localPosition += Axis.transform.localPosition;
		Z.transform.localPosition += Axis.transform.localPosition;

		rotateX ();
	}
	
	// Update is called once per frame
	void Update () {
		PlayerPrefs.SetFloat ("FirstXRotation", FirstXRotation);
		PlayerPrefs.SetFloat ("FirstYRotation", FirstYRotation);
		PlayerPrefs.SetFloat ("FirstZRotation", FirstZRotation);
	}

	public void rotateX () {
		Axis.transform.Rotate ( -Vector3.right * 90);
		FirstXRotation = -90.0f;
	}

	public void rotateY () {
		Axis.transform.Rotate (-Vector3.up * 90);
		FirstYRotation -= 90.0f;
	}

	public void rotateZ () {
		Axis.transform.Rotate (-Vector3.forward * 90);
		FirstZRotation -= 90.0f;
	}

*/

}
