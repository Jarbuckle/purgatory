using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private Transform player;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		offset = this.transform.position - player.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(player.position.x, 0, player.position.z) + offset;
	}
}
