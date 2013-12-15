using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {
	private PlayerState player;
	// Use this for initialization

	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerState>();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name=="Player") {
			if (player.hasKey == true) {
				player.hasKey = false;
				StartCoroutine("LoadLevel");
			}
		}
	}

	IEnumerator LoadLevel() {
		//yield return new WaitForSeconds(2);
		yield return player.DisablePlayer(2.0f);
		Application.LoadLevel("level2");
		yield return null;
	}
}
