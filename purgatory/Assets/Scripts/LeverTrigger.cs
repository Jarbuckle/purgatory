using UnityEngine;
using System.Collections;

public class LeverTrigger : MonoBehaviour {
	private bool closeEnoughToLever;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (closeEnoughToLever) {

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
