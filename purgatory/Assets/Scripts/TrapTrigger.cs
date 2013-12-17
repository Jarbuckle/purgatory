using UnityEngine;
using System.Collections;

public class TrapTrigger : MonoBehaviour {

	public GameObject trapGroup;
	private TrapGroup t;
	private DarknessControl d;
	private AudioSource a;

	void Awake() {
		t = trapGroup.GetComponent<TrapGroup>();
		a = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider other) {
		if (other.name=="Player") {
			if (t != null)
				t.ToggleTraps();
			else
				trapGroup.SetActive(true);
			a.Play();
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
