using UnityEngine;
using System.Collections;

public class StayintheLight : MonoBehaviour { 

	public string textToShow = "";

	private PlayerState player;
	private GameGUI gui;
	//private DarknessControl controlScript;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerState>();
		gui = GameObject.Find("GuiControl").GetComponent<GameGUI>();
		//controlScript = GameObject.Find("DarknessControl").GetComponent<DarknessControl>();
	}

	void OnTriggerEnter(Collider c) {
		if (c.name == "Player") {
			gui.ShowTextBox(textToShow);
		}
	}
	
	void OnTriggerExit(Collider c) {
		if (c.name == "Player") {
			player.isNotSafe();
			gui.HideTextBox();
		}
	}

	void OnTriggerStay(Collider c) {
		if (c.name == "Player") {
			player.isSafe();
		}
	}
}
