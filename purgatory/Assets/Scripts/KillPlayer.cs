using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {
	private GameObject spawn;
	private GameObject player;
	private PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
		spawn = GameObject.Find("Spawn");
		playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
		if (playerHealth.IsAlive()) {
			Debug.Log("Player is alive");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Player") {
			playerHealth.setAlive(false);

			if (!playerHealth.IsAlive()) {
				Debug.Log("Player killed");
				other.gameObject.transform.position = spawn.transform.position;
			}
		}
	}
}
