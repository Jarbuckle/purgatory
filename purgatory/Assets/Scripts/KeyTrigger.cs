using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(AudioSource))]
public class KeyTrigger : MonoBehaviour {
	private Inventory inventory;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		inventory = player.GetComponent<Inventory>();
		inventory.setKey(false);

	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.name=="Player") {
			inventory.setKey(true);
			player.audio.Play();
			Destroy(gameObject);
		}
	}
}
