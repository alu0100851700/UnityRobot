using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LengthSceneManager : MonoBehaviour {
	
	public InputField 	numbersOfLinks;
	public GUIStyle 	myStyle;

	int nLinks_;
	// Use this for initialization
	void Start () {
		numbersOfLinks.text = PlayerPrefs.GetInt ("nLinks").ToString();
	}

	void Update () {
		nLinks_ = int.Parse (numbersOfLinks.text);
		PlayerPrefs.SetInt ("nLinks", nLinks_);
	}

	public void changeScene (string scene) {
		Application.LoadLevel (scene);
	}

	void OnGUI(){
		
		for (int i = 0; i < nLinks_; i++) {
			GUI.Label 		(new Rect (450, 80 + i * 30, 50, 20), "Link " + i.ToString());

			//*********************** LENGTH OF LINKS **************************************
			string lengthT = PlayerPrefs.GetInt ("link" + i.ToString () + "length", 0).ToString();
			
			PlayerPrefs.SetInt ("link" + i.ToString() + "length" ,
				int.Parse (GUI.TextField 	(new Rect (500, 80 + i * 30, 30, 20), lengthT, 20)));

		}
	}




}
