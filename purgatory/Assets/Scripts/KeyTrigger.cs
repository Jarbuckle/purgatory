using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(AudioSource))]
public class KeyTrigger : MonoBehaviour {
	private PlayerState player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerState>();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name=="Player") {
			player.CollectKey();
			Destroy(gameObject);
		}
	}
}
