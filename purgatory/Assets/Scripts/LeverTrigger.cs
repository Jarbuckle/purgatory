using UnityEngine;
using System.Collections;

public class LeverTrigger : MonoBehaviour {
	private enum LeverState {OFF, ON};
	private LeverState leverState;
	private bool closeEnoughToLever;
	private string leverValue;

	private bool leverPulled;

	// Update is called once per frame
	void Update () {
		if (leverState == null) {
			leverState = LeverState.OFF;
		}

		if (closeEnoughToLever) {
			if (Input.GetKeyDown(KeyCode.Space)) {
				if (leverState != null) {
					switch (leverState) {
						case LeverState.OFF:
							leverState = LeverState.ON;
							leverValue = "OFF";
							break;
						case LeverState.ON:
							leverState = LeverState.OFF;
							leverValue = "ON";
							break;
						default:
							Debug.Log("Noooooo");
							break;
					}
				} else {
					Debug.Log("leverPulled = " + leverPulled);
					if (!leverPulled) {
						leverPulled = true;
					} else {
						leverPulled = false;
					}
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

	public bool isLeverOn() {
		return this.leverState == LeverState.ON;
	}

	public bool isLeverPulled() {
		return this.leverPulled == true;
	}
}
