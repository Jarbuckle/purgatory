using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public AudioClip clip1;
	public AudioClip clip2;

	private Transform player;
	private Vector3 offset;

	private AudioSource a;

	// Use this for initialization
	void Start () {
		a = GetComponent<AudioSource>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		offset = this.transform.position - player.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(player.position.x, 0, player.position.z) + offset;
	}

	public IEnumerator PlayTrack1() {
		yield return StartCoroutine(FadeTrack(false));
		a.Stop ();
		a.clip = clip1;
		a.Play ();
		yield return StartCoroutine(FadeTrack(true));

	}

	public IEnumerator PlayTrack2() {
		yield return StartCoroutine(FadeTrack(false));
		a.Stop();
		a.clip = clip2;
		a.Play();
		yield return StartCoroutine(FadeTrack(true));
		
	}

	IEnumerator FadeTrack(bool fadeTo) {
		while (true) {
			a.volume = fadeTo ? a.volume + Time.deltaTime / 2 : a.volume - Time.deltaTime / 2;
			if (a.volume <= 0 || a.volume >= 1) {
				break;
			}
			yield return null;
		}
		yield return null;
	}
}
