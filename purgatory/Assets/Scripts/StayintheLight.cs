using UnityEngine;
using System.Collections;

public class StayintheLight : MonoBehaviour {

	//private PlayerState player;
	private DarknessControl controlScript;

	// Use this for initialization
	void Awake () {
		//player = GameObject.FindGameObjectWithTag("Player").
		controlScript = GameObject.Find("DarknessControl").GetComponent<DarknessControl>();
	}

	void OnTriggerStay() {
		controlScript.PlayerIsSafe();
	}
}
