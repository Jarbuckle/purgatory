using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {
	public bool alive = true;
	private MovePlayer playerMovement;
	public bool hasKey = false;

	public bool playerIsSafe = true;

	public float lightStartSize = 25f;
	public float lightMinSize = 5f;
	public float lightFadeDuration = 300f;
	private float lightRemaining;
	public float lightDangerThreshold = 30f;
	private bool isInDanger = false;
	private Light spotlight;

	private GameGUI gui;
		
	void Awake() {
		playerMovement = GetComponent<MovePlayer>();
		gui = GameObject.Find ("GuiControl").GetComponent<GameGUI>();
		gui.ShowLevelTitle("Guiding Lights");
		StartCoroutine(DisablePlayer(2));
		StartCoroutine(InDarkness());
	}

	public IEnumerator KillPlayer() {
		StartCoroutine(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().PlayTrack1());
		alive = false;
		//renderer.enabled = false; //Fade effect
		yield return StartCoroutine(DisablePlayer(2.0f));
		Respawn();
		//renderer.enabled = true;
		//yield return new WaitForSeconds(.05f);
		//alive = true;
		//yield return null;
	}

	public IEnumerator DisablePlayer(float duration) {
		playerMovement.enabled = false;
		yield return new WaitForSeconds(duration);
		playerMovement.enabled = true;
		gui.HideLevelTitle();
		yield return null;
	}

	public void TeleportPlayer(Transform target) {
		transform.position = target.position;
	}
	
	public void isSafe() {
		playerIsSafe = true;
	}

	public void isNotSafe() {
		playerIsSafe = false;
	}

	void Respawn() {
		Transform spawn = GameObject.FindGameObjectWithTag("Respawn").transform; 
		TeleportPlayer(spawn);
		playerIsSafe = true;
		
		Application.LoadLevel(0);
	}

	public void CollectKey() {
		hasKey = true;
	}

	IEnumerator InDarkness() {
		lightRemaining = lightFadeDuration;
		spotlight = GetComponentInChildren<Light>();
		spotlight.spotAngle = lightStartSize + lightMinSize;
		isInDanger = false;
		spotlight.color = new Color(1f,1f,1f);
		GetComponentInChildren<SpriteRenderer>().color = new Color(1f,1f,1f);

		float belowThreshold = 0;

		while (true) {
			if (!playerIsSafe) {
				lightRemaining -= Time.deltaTime;
				spotlight.spotAngle = lightMinSize + lightStartSize * lightRemaining/lightFadeDuration;

				if (lightRemaining <= lightDangerThreshold) {
					belowThreshold = lightRemaining / lightDangerThreshold;
					spotlight.color = new Color(1f,belowThreshold,belowThreshold);
					GetComponentInChildren<SpriteRenderer>().color = new Color(1f,belowThreshold,belowThreshold);

					if (isInDanger == false) {
						isInDanger = true;
						StartCoroutine(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().PlayTrack2());//Fade audio to different music
					}
				}

				if (lightRemaining <= 0) {
					break;
				}
			}
			yield return null;
		}
		//Fade audio to different music
		yield return StartCoroutine(KillPlayer());
	}
}
