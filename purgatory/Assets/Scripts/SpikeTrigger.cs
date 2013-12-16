﻿using UnityEngine;
using System.Collections;

public class SpikeTrigger : MonoBehaviour {

	public int state = 1;
	private PlayerState playerHealth;
	private GameObject spikes;

	private Transform spikes;

	// Use this for initialization
	void Start () {
		playerHealth = GameObject.Find("Player").GetComponent<PlayerState>();
<<<<<<< HEAD
		//spikes = GameObject.Find
=======
		spikes = GameObject.Find("Spikes");
	}

	void Update() {
		StartCoroutine(RaiseSpikes(1.0F));
		StartCoroutine(LowerSpikes(1.0F));
>>>>>>> 12f685b7bd8e0a5aeeb97c3280e8cb449f8f4b4d
	}

	void OnTriggerStay(Collider other) {
		state = 3;
		print (state ==3 && other.gameObject.name == "Player");
		if (state == 3 && other.gameObject.name == "Player") 
			if (playerHealth.alive == true)
				StartCoroutine(playerHealth.KillPlayer());
	}
	
	public IEnumerator RaiseSpikes(float delay) {
		state = 2; //Animate spike position
		spikes.audio.Play();
		yield return new WaitForSeconds (spikes.audio.clip.length);

		//yield return new WaitForSeconds(delay);
		state = 3; //Animate spike position

		//yield return null;
	}

	public IEnumerator LowerSpikes(float delay) {
		state = 1; //Animate spike position
		spikes.audio.Play();
		yield return new WaitForSeconds (spikes.audio.clip.length);
		//yield return new WaitForSeconds(delay);
	}

	IEnumerator LerpSpikes() {
		while (true) {
			yield return null;
		}
		yield return null;
	}
}
