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
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Player") {
			playerHealth.setAlive(false);
			player = other.gameObject;
			if (!playerHealth.IsAlive()) {
				Debug.Log("Starting coroutine");
				StartCoroutine("Fade");
				Debug.Log("2 seconds later");
			}
		}
	}

	IEnumerator Fade() {
		//player.transform.position = spawn.transform.position;
		yield return new WaitForSeconds(10);
	}
}
