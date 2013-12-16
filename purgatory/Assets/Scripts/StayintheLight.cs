using UnityEngine;
using System.Collections;

public class StayintheLight : MonoBehaviour { 

	private PlayerState player;
	//private DarknessControl controlScript;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerState>();
		//controlScript = GameObject.Find("DarknessControl").GetComponent<DarknessControl>();
	}

	void OnTriggerExit(Collider c) {
		if (c.name == "Player") {
			player.isNotSafe();
		}
	}

	void OnTriggerStay(Collider c) {
		if (c.name == "Player") {
			player.isSafe();
		}
	}
}
