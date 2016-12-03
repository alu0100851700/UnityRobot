using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class DHManager : MonoBehaviour {

	public InputField 	numbersOfWorlds;
	int nWorlds_;
	public float x;

	// Use this for initialization
	void Start () {
		//PlayerPrefs.DeleteAll ();
	}
	
	// Update is called once per frame
	void Update () {
		nWorlds_ = int.Parse (numbersOfWorlds.text);
	}

	public void changeScene (string scene) {
		PlayerPrefs.SetInt ("nWorlds", nWorlds_);
		Application.LoadLevel (scene);
	}

	void OnGUI() {
		GUI.Label 		(new Rect (50, 150, 50, 20), "d");
		GUI.Label 		(new Rect (50, 175, 50, 20), "th");
		GUI.Label 		(new Rect (50, 200, 50, 20), "a");
		GUI.Label 		(new Rect (50, 225, 50, 20), "al");



		for (int i = 0; i < nWorlds_; i++) {
			string d = GUI.TextField (new Rect (100 + i * 50, 150, 50, 20), PlayerPrefs.GetString("world" + i.ToString() + "d"));
			if (Regex.Match (d, "^[-+]?[0-9]*\\.?[0-9]*([+]v?)?$").Success)
				PlayerPrefs.SetString ("world" + i.ToString () + "d", d);
			
			string th = GUI.TextField (new Rect (100 + i * 50, 175, 50, 20), PlayerPrefs.GetString("world" + i.ToString() + "th"));
			if (Regex.Match (th, "^[-+]?[0-9]*\\.?[0-9]*([+]v?)?$").Success)
				PlayerPrefs.SetString ("world" + i.ToString() + "th" , th);

			string a = GUI.TextField (new Rect (100 + i * 50, 200, 50, 20), PlayerPrefs.GetString("world" + i.ToString() + "a"));
			if (Regex.Match (a, "^[-+]?[0-9]*\\.?[0-9]*([+]v?)?$").Success)
				PlayerPrefs.SetString ("world" + i.ToString() + "a" , a);

			string al = GUI.TextField (new Rect (100 + i * 50, 225, 50, 20), PlayerPrefs.GetString ("world" + i.ToString () + "al"));
			if (Regex.Match (al,"^[-+]?[0-9]*\\.?[0-9]*([+]v?)?$").Success)
				PlayerPrefs.SetString ("world" + i.ToString() + "al" ,al);

		}
	}


}
