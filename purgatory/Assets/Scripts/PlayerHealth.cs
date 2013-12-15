using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	private enum HealthState {ALIVE, DEAD};
	private HealthState healthState;
	
	// Use this for initialization
	void Start () {
		healthState = HealthState.ALIVE;
	}

	public bool IsAlive() {
		return this.healthState == HealthState.ALIVE;
	}

	public HealthState getHealthState() {
		return this.healthState;
	}

	public void setHealthState(HealthState healthState) {
		this.healthState = healthState;
	}
}
