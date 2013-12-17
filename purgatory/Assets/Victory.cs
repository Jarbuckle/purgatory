using UnityEngine;
using System.Collections;

public class Victory : MonoBehaviour {
	
	
	private PlayerState player;
	private GameGUI gui;

	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerState>();
		gui = GameObject.Find("GuiControl").GetComponent<GameGUI>();
	}
	
	void OnTriggerEnter(Collider c) {
		if (c.name == "Player") {
			gui.ShowLevelTitle("Well Done");
			StartCoroutine(LiftPlayer ());
		}
	}

	IEnumerator LiftPlayer() {
		SpriteRenderer sprite = player.GetComponentInChildren<SpriteRenderer>();
		Transform t = player.transform;
		Vector3 v = t.position;
		Vector3 d = new Vector3(v.x,200f,v.z);
		Light l = player.GetComponentInChildren<Light>();
		StartCoroutine(player.DisablePlayer(5f));
		StartCoroutine(ResetTimer());
		while (true) {
			t.position = Vector3.Lerp (v,d,Time.deltaTime / 3);
			sprite.color = Vector4.Lerp (Color.white,Color.black,Time.deltaTime/ 3);
			l.spotAngle = Mathf.Lerp(10f,100f,Time.deltaTime / 3);
			yield return null;
		}

	}

	IEnumerator ResetTimer() {
		yield return new WaitForSeconds(5f);
		player.KillPlayer();
	}
}
