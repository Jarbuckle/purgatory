using UnityEngine;
using System.Collections;

public class TrapTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name=="Player") {
			Debug.Log("Entered trigger");
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.name=="Player") {
			Debug.Log("Exited trigger");
		}
	}

	void OnTriggerStay(Collider other) {
		//Debug.Log("In trigger");
	}
}
