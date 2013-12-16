using UnityEngine;
using System.Collections;

public class TrapGroup : MonoBehaviour {

	private SpikeTrigger[] traps;

	void Awake() {
		traps = GetComponentsInChildren<SpikeTrigger>();
	}

	public void ToggleTraps() {
		foreach (SpikeTrigger trap in traps) {
			trap.ToggleState();
		}
	}

	public void ToggleTrapsInstant() {
		foreach (SpikeTrigger trap in traps) {
			trap.ToggleStateInstant();
		}
	}

	public void ResetTraps() {
		print ("Reset");
		foreach (SpikeTrigger trap in traps) {
			trap.RaiseSpikes(0);
		}
	}
}
