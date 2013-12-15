using UnityEngine;
using System.Collections;

public class SpikeTrigger : MonoBehaviour {
	private GameObject spawn;
	private GameObject player;
	private LeverTrigger leverTrigger;
	private bool isSafe;
	private PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
		spawn = GameObject.Find("Spawn");
		playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
		leverTrigger = GameObject.Find("Lever").GetComponent<LeverTrigger>();
		isSafe = true;
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.name == "Player") {
			player = other.gameObject;
			if (leverTrigger.isLeverPulled()) {
				StartCoroutine(Safe(player));
			}
		}
	}

	void OnTriggerExit() {
		print ("isSafe is safe");
		isSafe = true;
	}
	
	IEnumerator Safe(GameObject player) {
		isSafe = true;
		yield return new WaitForSeconds(2);
		yield return new WaitForSeconds(2);
		yield return new WaitForSeconds(2);
		yield return new WaitForSeconds(2);
		if (!isSafe) {
			Debug.Log("DEAD!");
		}
	}
}
