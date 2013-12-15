using UnityEngine;
using System.Collections;

public class LeverTrigger : MonoBehaviour {
	private enum LeverState {OFF, ON};
	private LeverState leverState;
	private bool closeEnoughToLever;

	// Use this for initialization
	void Start () {
		leverState = LeverState.OFF;
	}
	
	// Update is called once per frame
	void Update () {
		if (closeEnoughToLever) {
			if (Input.GetKeyDown("space")) {
				switch (leverState) {
					case LeverState.OFF:
						leverState = LeverState.ON;
						break;
					case LeverState.ON:
						leverState = LeverState.OFF;
						break;
				}
				print (leverState);
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
}
