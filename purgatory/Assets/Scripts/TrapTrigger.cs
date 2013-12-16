using UnityEngine;
using System.Collections;

public class TrapTrigger : MonoBehaviour {

	public GameObject trapGroup;
	private TrapGroup t;
	private DarknessControl d;

	void Awake() {
		t = trapGroup.GetComponent<TrapGroup>();
	}

	void OnTriggerEnter(Collider other) {
		if (other.name=="Player") {
			if (t != null)
				t.ToggleTraps();
			else
				trapGroup.SetActive(true);
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
