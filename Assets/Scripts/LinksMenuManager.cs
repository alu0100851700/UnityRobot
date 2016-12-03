using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LinksMenuManager : MonoBehaviour {

	public Text numberLinksText;

	// Use this for initialization
	void Start () {
		string text = "Number of links: ";
		text += PlayerPrefs.GetInt ("nLinks").ToString ();
		numberLinksText.text = text;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
