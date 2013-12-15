using UnityEngine;
using System.Collections;

public class DisplayText : MonoBehaviour {
	private LeverTrigger leverTrigger;

	// Use this for initialization
	void Awake () {
		leverTrigger = GameObject.Find("Player").GetComponent<LeverTrigger>();
		print("awake() leverTrigger is " + leverTrigger);
	}
	
	// Update is called once per frame
	void Update () {
		//leverTrigger = GameObject.Find("Player").GetComponent<LeverTrigger>();
		//print("update() leverTrigger is " + leverTrigger);
	}

	public void showText() {
		GUI.Label (new Rect (Screen.width/2,Screen.height/2,100,50), "This is the text string for a Label Control");
		leverTrigger = GameObject.Find("Player").GetComponent<LeverTrigger>();
		if (leverTrigger == null) {
			leverTrigger = GameObject.Find("Player").GetComponent<LeverTrigger>();
		}

		if (leverTrigger != null && leverTrigger.getCloseEnoughToLever()) {

		}
	}

	void OnGUI () {
		showText();
	}
}
