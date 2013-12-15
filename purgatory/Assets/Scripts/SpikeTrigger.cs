using UnityEngine;
using System.Collections;

public class SpikeTrigger : MonoBehaviour {

	private LeverTrigger leverTrigger;
	private bool isSafe;
	private PlayerState playerHealth;

	// Use this for initialization
	void Start () {
		playerHealth = GameObject.Find("Player").GetComponent<PlayerState>();
		leverTrigger = GameObject.Find("Lever").GetComponent<LeverTrigger>();
		isSafe = true;
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.name == "Player") {
/*			player = other.gameObject;
			if (leverTrigger.isLeverPulled()) {
				isSafe = false;
				StartCoroutine(Safe(player));
			}*/
			if (playerHealth.alive == true)
				StartCoroutine(playerHealth.KillPlayer());
		}
	}

	void OnTriggerExit() {
		print ("isSafe is safe");
		isSafe = true;
	}
	
	IEnumerator Safe(GameObject player) {
		yield return new WaitForSeconds(2);
		// Popping up
		yield return new WaitForSeconds(2);
		// Popped up
		yield return new WaitForSeconds(2);

		if (!isSafe) {
			Debug.Log("DEAD!");
		}
	}
}
