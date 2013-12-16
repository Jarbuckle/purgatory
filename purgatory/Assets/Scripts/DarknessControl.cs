using UnityEngine;
using System.Collections;

public class DarknessControl : MonoBehaviour {

	public GameObject trapGroup;
	private TrapGroup traps;

	void Awake () {
		traps = trapGroup.GetComponent<TrapGroup>();
	}

	void Start() {
		StartCoroutine(SpikeTimer());
	}

	IEnumerator SpikeTimer() {
		while (true) {
			traps.ToggleTraps();
			yield return new WaitForSeconds(2f);
		}
		yield return null;
	}
}
