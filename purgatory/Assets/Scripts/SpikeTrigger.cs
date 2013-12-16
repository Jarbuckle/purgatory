using UnityEngine;
using System.Collections;

public class SpikeTrigger : MonoBehaviour {

	public int state = 3;
	public float delay = .5f;
	private PlayerState playerHealth;

	private Transform spikes;

	// Use this for initialization
	void Awake () {
		state = 3;
		playerHealth = GameObject.Find("Player").GetComponent<PlayerState>();
		//spikes = GameObject.Find
	}

	void OnTriggerStay(Collider other) {
		if (state == 3 && other.name == "Player") 
			if (playerHealth.alive == true)
				StartCoroutine(playerHealth.KillPlayer());
	}
	
	public IEnumerator RaiseSpikes(float delay) {
		if (delay != 0) {
			state = 2; //Animate spike position, sound effect w/ pitch randomness
			yield return new WaitForSeconds(delay);
		}
		state = 3; //Animate spike position, sound effect w/ pitch randomness
		yield return null;
	}

	public void LowerSpikes() {
		state = 1; //Animate spike position, sound effect w/ pitch randomness
	}

	public void ToggleState() {
		if (state == 1)
			StartCoroutine(RaiseSpikes(delay));
		else
			LowerSpikes();
	}

	public void ToggleStateInstant() {
		if (state == 1)
			StartCoroutine(RaiseSpikes(0));
		else
			LowerSpikes();

	}

	IEnumerator LerpSpikes() {
		while (true) {
			yield return null;
		}
		yield return null;
	}
}
