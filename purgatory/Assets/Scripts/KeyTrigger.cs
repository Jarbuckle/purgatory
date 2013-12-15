using UnityEngine;
using System.Collections;

public class KeyTrigger : MonoBehaviour {
	private Inventory inventory;
	// Use this for initialization
	void Start () {
		inventory = GameObject.Find("Player").GetComponent<Inventory>();
		inventory.setKey(false);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name=="Player") {
			inventory.setKey(true);
			Destroy(gameObject);
		}
	}
}
