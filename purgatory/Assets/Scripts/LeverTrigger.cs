using UnityEngine;
using System.Collections;

public class LeverTrigger : MonoBehaviour {
	private bool closeEnoughToLever;
	private string leverValue;

	private bool leverPulled;

	void Start() {
		leverPulled = false;
	}

	// Update is called once per frame
	void Update () {
		if (closeEnoughToLever) {
			if (Input.GetKeyDown(KeyCode.Space)) {
				if (leverPulled) {
					leverPulled = false;
				} else {
					leverPulled = true;
				}
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

	public bool getCloseEnoughToLever() {
		return this.closeEnoughToLever;
	}

	void OnGUI () {
		if (getCloseEnoughToLever()) {
			GUI.Label (new Rect (Screen.width/2,Screen.height/2,100,50), "Press Space Bar to interact with lever");
		}
	}

	public bool isLeverPulled() {
		return this.leverPulled == true;
	}
}
