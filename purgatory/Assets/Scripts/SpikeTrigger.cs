using UnityEngine;
using System.Collections;

public class SpikeTrigger : MonoBehaviour {
	private enum HealthState {ALIVE, DEAD};
	private GameObject spawn;
	private GameObject player;
	private PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
		spawn = GameObject.Find("Spawn");
		playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.name == "Player") {
			playerHealth.setHealthState(HealthState.DEAD);
			player = other.gameObject;
			if (!playerHealth.IsAlive()) {
				StartCoroutine("Safe");
			}
		}
	}
	
	IEnumerator Safe() {
		yield return new WaitForSeconds(2);
		//player.transform.position = spawn.transform.position;
	}
}
