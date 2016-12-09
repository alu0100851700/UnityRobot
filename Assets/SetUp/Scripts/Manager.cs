using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;


public class Manager : MonoBehaviour {

	//************ UI ******************//
	public Text 		Tittle;

	public InputField	d;
	public InputField	th;
	public InputField	a;
	public InputField	al;

	public Dropdown		fatherWorld;
	public Dropdown 	variableSelector;

	//********** Prefabs **************//
	public GameObject 	baseAxis;
	public GameObject	WorldPreferences;


	int nWorlds = 0;
	int actualWorld = 0;

	// Use this for initialization
	void Start () {
		nWorlds = PlayerPrefs.GetInt ("nWorlds");
		Tittle.text = "Base World";
		fatherWorld.options.Add (new Dropdown.OptionData (0.ToString ()));
		baseAxis.SetActive( true );
		WorldPreferences.SetActive( false );

		for(int i = 0; i <nWorlds; i++)
			fatherWorld.options.Add (new Dropdown.OptionData (i.ToString ()));
	}
	// Update is called once per frame
	void Update () {
		
	}

	public void changeScene (string scene) {
		saveConfig ();
		Application.LoadLevel (scene);
	}

	public void UpdateUI(bool next){
		Debug.Log ("UpdateUI");
		if (actualWorld != 0) {
			if ( d.text != "" || th.text != "" || a.text != "" || al.text != "")
				if (!saveConfig ()) {
					Debug.Log ("Cannot Change World");
					return;
			}
		}

		bool newWorld = false;

		if (next) {//NEXT
			actualWorld++;
			if (newWorld = nWorlds < actualWorld) addWorld ();
		}
		else //if (!next && actualWorld > 0)
				actualWorld--;
		
		if (actualWorld == 0) 
			loadBase ();
		else if (actualWorld > 0 && !newWorld) 
			loadConfig ();
	}

	void loadBase() {
		WorldPreferences.SetActive( false );
		baseAxis.SetActive( true );
		Tittle.text = "Base World";
	}

	void addWorld() {
		Tittle.text = "World "  + actualWorld.ToString ();
		WorldPreferences.SetActive( true );
		baseAxis.SetActive( false );

		nWorlds++;
		fatherWorld.options.Add (new Dropdown.OptionData (nWorlds.ToString ()));
		d.text = "";
		th.text = "";
		a.text = "";
		al.text = "";

		fatherWorld.value = actualWorld - 1;
		variableSelector.value = 0;
	}

	void loadConfig() {
		Tittle.text = "World "  + actualWorld.ToString ();
		WorldPreferences.SetActive( true );
		baseAxis.SetActive( false );

		d.text = PlayerPrefs.GetString ("world" + actualWorld.ToString () + "d");
		th.text = PlayerPrefs.GetString ("world" + actualWorld.ToString () + "th");
		a.text = PlayerPrefs.GetString ("world" + actualWorld.ToString () + "a");
		al.text = PlayerPrefs.GetString ("world" + actualWorld.ToString () + "al");
		fatherWorld.value = PlayerPrefs.GetInt ("father" + actualWorld.ToString ());
		variableSelector.value = PlayerPrefs.GetInt ("variable" + actualWorld.ToString ());
	}

	bool saveConfig() {
			
		if (Regex.Match (d.text, "^[-+]?[0-9]+$").Success && Regex.Match (th.text, "^[-+]?[0-9]+$").Success &&
		    Regex.Match (a.text, "^[-+]?[0-9]+$").Success && Regex.Match (al.text, "^[-+]?[0-9]+$").Success) {
			PlayerPrefs.SetInt ("nWorlds", nWorlds);
			PlayerPrefs.SetString ("world" + actualWorld.ToString () + "d", d.text);
			PlayerPrefs.SetString ("world" + actualWorld.ToString () + "th", th.text);
			PlayerPrefs.SetString ("world" + actualWorld.ToString () + "a", a.text);
			PlayerPrefs.SetString ("world" + actualWorld.ToString () + "al", al.text);

			PlayerPrefs.SetInt ("father" + actualWorld.ToString (), fatherWorld.value);
			PlayerPrefs.SetInt ("variable" + actualWorld.ToString (), variableSelector.value);
			return true;

		} else {
			//nWorlds--;
			return false;
		}

	}

	public void reset (){
		PlayerPrefs.DeleteAll();
		Application.LoadLevel (Application.loadedLevel);
	}



}
