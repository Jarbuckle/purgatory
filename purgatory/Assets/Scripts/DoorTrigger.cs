using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {
	private Inventory inventory;
	// Use this for initialization
	void Start () {
		inventory = GameObject.Find("Player").GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name=="Player") {
			if (inventory.getKey()) {
				inventory.setKey(false);
				StartCoroutine("LoadLevel");
			}
		}
	}

	IEnumerator LoadLevel() {
		yield return new WaitForSeconds(2);
		Application.LoadLevel("level2");
	}
}
