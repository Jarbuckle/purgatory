using UnityEngine;
using System.Collections;

public class DisplayText : MonoBehaviour {
	private LeverTrigger leverTrigger;

	// Use this for initialization
	void Awake () {
		leverTrigger = GameObject.Find("Player").GetComponent<LeverTrigger>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void showText() {
		GUI.Label (new Rect (Screen.width/2,Screen.height/2,100,50), "This is the text string for a Label Control");
		leverTrigger = GameObject.Find("Player").GetComponent<LeverTrigger>();
		if (leverTrigger == null) {
			leverTrigger = GameObject.Find("Player").GetComponent<LeverTrigger>();
		}
	}

	void OnGUI () {
		showText();
	}
}
