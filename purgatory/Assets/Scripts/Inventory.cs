using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {
	private bool key;
	// Use this for initialization

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public bool getKey() {
		return key;
	}

	public void setKey(bool key) {
		this.key = key;
	}
}
