using UnityEngine;
using System.Collections;

public class TrapTrigger : MonoBehaviour {

	public GameObject trapGroup;
	private TrapGroup t;

	void Awake() {
		t = trapGroup.GetComponent<TrapGroup>();
	}

	void OnTriggerEnter(Collider other) {
		if (other.name=="Player") {
			t.ToggleTraps();
			Debug.Log("Entered trigger");
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.name=="Player") {
			//Debug.Log("Exited trigger");
		}
	}

	void OnTriggerStay(Collider other) {
		//Debug.Log("In trigger");
	}
}
