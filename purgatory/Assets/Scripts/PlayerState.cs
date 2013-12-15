using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {
	public bool alive = true;
	private MovePlayer playerMovement;
	public bool hasKey = false;
		
	void Awake() {
		playerMovement = GetComponent<MovePlayer>();
	}

	public IEnumerator KillPlayer() {
		alive = false;
		renderer.enabled = false; //Fade effect
		yield return StartCoroutine(DisablePlayer(2.0f));
		Respawn();
		renderer.enabled = true;
		yield return new WaitForSeconds(.05f);
		alive = true;
		yield return null;
	}

	public IEnumerator DisablePlayer(float duration) {
		playerMovement.enabled = false;
		yield return new WaitForSeconds(duration);
		playerMovement.enabled = true;
		yield return null;
	}

	public void TeleportPlayer(Transform target) {
		transform.position = target.position;
	}

	void Respawn() {
		Transform spawn = GameObject.FindGameObjectWithTag("Respawn").transform;
		TeleportPlayer(spawn);
	}

	public void CollectKey() {
		hasKey = true;
	}
}
