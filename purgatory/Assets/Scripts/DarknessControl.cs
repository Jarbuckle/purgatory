using UnityEngine;
using System.Collections;

public class DarknessControl : MonoBehaviour {

	public float darknessThreshold = 5f;
	private PlayerState player;
	private bool playerissafe = true;

	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerState>();
	}

	void Start() {
		//StartCoroutine(CheckDarkness());
	}

	public void PlayerIsSafe() {
		playerissafe = true;
	}

	IEnumerator CheckDarkness () {
		float countdown = darknessThreshold;
		float lastTime = Time.time;
		while (true) {
			if (playerissafe == false) {
				countdown -= Time.time - lastTime; //Also increase volume, show things in the darkness
			}
			else {
				countdown = darknessThreshold; //Fade out track, hide things in the darkness
			}

			if (countdown <= 0) {
				break;
			}

			playerissafe = false;
			lastTime = Time.time;
			yield return new WaitForSeconds(.2f);
		}
		yield return StartCoroutine(player.KillPlayer());
		StartCoroutine(CheckDarkness());
	}
}
