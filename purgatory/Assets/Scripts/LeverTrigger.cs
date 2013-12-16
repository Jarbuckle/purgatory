using UnityEngine;
using System.Collections;

public class LeverTrigger : MonoBehaviour {
	private bool closeEnoughToLever = false;
	private string leverValue;

	public bool leverState = false;

	public GameObject listener;

	void Awake() {
	}

	void OnTriggerStay () {
		if (closeEnoughToLever) {
			if (Input.GetKeyDown(KeyCode.Space)) {
				leverState = !leverState;
			} 
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name=="Player") {
			closeEnoughToLever = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.name=="Player") {
			closeEnoughToLever = false;
		}
	}

	void OnGUI () {
		if (closeEnoughToLever) {
			GUI.Label (new Rect (Screen.width/2,Screen.height/2,100,50), "Press Space Bar to interact with lever");
		}
	}

}
