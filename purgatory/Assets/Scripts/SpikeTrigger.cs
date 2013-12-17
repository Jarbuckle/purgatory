using UnityEngine;
using System.Collections;

public class SpikeTrigger : MonoBehaviour {
	
	public int state = 3;
	public float delay = 1f;
	private PlayerState playerHealth;
	private Transform spikes;
	private AudioSource a;
	
	// Use this for initialization
	void Awake () {
		state = 3;
		playerHealth = GameObject.Find("Player").GetComponent<PlayerState>();
		spikes = transform.Find("spiketrap_spikes");
		a = GetComponent<AudioSource>();
	}
	
	void OnTriggerStay(Collider other) {
		if (state == 3 && other.name == "Player") 
			if (playerHealth.alive == true)
				StartCoroutine(playerHealth.KillPlayer());
	}
	
	public IEnumerator RaiseSpikes(float delay) {
		a.pitch = Random.Range(.8f,1.2f);
		a.PlayScheduled(Random.Range(.3f,.6f));
		if (delay != 0) {
			state = 2; 
			MoveSpikes();//Animate spike position, sound effect w/ pitch randomness
			yield return new WaitForSeconds(delay);
		}
		state = 3; //Animate spike position, sound effect w/ pitch randomness
		MoveSpikes();
		yield return null;
	}
	
	public void LowerSpikes() {
		state = 1; //Animate spike position, sound effect w/ pitch randomness
		MoveSpikes();
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
	
	void MoveSpikes() {
		Vector3 pos = spikes.position;
		switch (state) {
		case 1:
			spikes.position = new Vector3(pos.x, -1, pos.z);
			break;
		case 2:
			spikes.position = new Vector3(pos.x, -.5f, pos.z);
			break;
		case 3:
			spikes.position = new Vector3(pos.x, 0, pos.z);
			break;
			
		}
	}
}
