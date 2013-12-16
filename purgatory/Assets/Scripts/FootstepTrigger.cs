using UnityEngine;
using System.Collections;

public class FootstepTrigger : MonoBehaviour {

	AudioSource a;

	void Awake() {
		a = GetComponent<AudioSource>();
	}

	public void FootstepAudio() {
		a.Play();
	}
}
