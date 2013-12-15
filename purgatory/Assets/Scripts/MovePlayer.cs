using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;
	private Animator anim;
	

	// Use this for initialization
	void Awake () {
		controller =  GetComponent<CharacterController>();
		anim = GetComponent<Animator>();
		DontDestroyOnLoad(this.gameObject);
	}

	
	// Update is called once per frame
	void Update () {
		float xdelta = Input.GetAxis("Horizontal");
		float ydelta = Input.GetAxis("Vertical");

		if (!Mathf.Approximately(xdelta,0) || !Mathf.Approximately(ydelta,0)) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;


			if (moveDirection.x > 0)
				transform.localScale = new Vector3(1,1,1);
			if (moveDirection.x < 0)
				transform.localScale = new Vector3(-1,1,1);
		}
		else
			moveDirection = Vector3.zero;

		if (moveDirection.magnitude >= .1) 
			anim.SetBool("PlayerWalking",true);
		else 
			anim.SetBool("PlayerWalking",false);

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);	
	}
}
