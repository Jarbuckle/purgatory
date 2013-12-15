using UnityEngine;
using System.Collections;

public class KeyTrigger : MonoBehaviour {
	private Inventory inventory;
	// Use this for initialization
	void Start () {
	 	//Inventory inventory1 = (Inventory)gameObject.GetComponent<Inventory>();

		//inventory1.setKey(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name=="Player") {
			//inventory.setKey(true);
			Destroy(gameObject);
		}
	}
}
