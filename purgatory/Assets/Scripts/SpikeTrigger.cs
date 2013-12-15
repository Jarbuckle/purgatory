using UnityEngine;
using System.Collections;

public class SpikeTrigger : MonoBehaviour {
	private GameObject spawn;
	private GameObject player;
	private LeverTrigger leverTrigger;

	private PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
		spawn = GameObject.Find("Spawn");
		playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
		leverTrigger = GameObject.Find("Lever").GetComponent<LeverTrigger>();
	}

	void OnTriggerStay(Collider other) {

		if (other.gameObject.name == "Player") {
			if (leverTrigger.isLeverPulled()) {
				StartCoroutine("Safe");
			} else {
				Debug.Log("Not pulled");
			}
		}
	}
	
	IEnumerator Safe() {
		yield return new WaitForSeconds(2);
		Debug.Log("On");
		yield return new WaitForSeconds(2);
		Debug.Log("Off");
	}
}
