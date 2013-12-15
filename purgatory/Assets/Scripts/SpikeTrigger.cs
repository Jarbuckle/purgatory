using UnityEngine;
using System.Collections;

public class SpikeTrigger : MonoBehaviour {

	public int state = 1;
	private PlayerState playerHealth;

	// Use this for initialization
	void Start () {
		playerHealth = GameObject.Find("Player").GetComponent<PlayerState>();
	}

	void OnTriggerStay(Collider other) {
		if (state == 3 && other.gameObject.name == "Player") 
			if (playerHealth.alive == true)
				StartCoroutine(playerHealth.KillPlayer());
	}
	
	public IEnumerator RaiseSpikes(float delay) {
		state = 2; //Animate spike position
		yield return new WaitForSeconds(delay);
		state = 3; //Animate spike position
		yield return null;
	}

	public void LowerSpikes() {
		state = 1; //Animate spike position
	}
}
