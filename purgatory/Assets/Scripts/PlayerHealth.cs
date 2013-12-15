using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	private bool alive;
	// Use this for initialization
	void Start () {
		setAlive(true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool IsAlive() {
		return this.alive == true;
	}

	public bool getAlive() {
		return this.alive;
	}

	public void setAlive(bool alive) {
		this.alive = alive;
	}
}
