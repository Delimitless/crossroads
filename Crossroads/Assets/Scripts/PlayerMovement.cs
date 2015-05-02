using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	const string IS_WALKING = "isWalking";

	Rigidbody2D rbody;
	Animator anim;

	private bool isColliding = false;

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector2 v_movement = new Vector2(
									Input.GetAxisRaw("Horizontal"), 
									Input.GetAxisRaw("Vertical"));

		if (v_movement != Vector2.zero) {
			anim.SetBool (IS_WALKING, true);
			anim.SetFloat("input_x", v_movement.x);
			anim.SetFloat("input_y", v_movement.y);
		} else {
			anim.SetBool(IS_WALKING, false);
		}

		rbody.MovePosition(rbody.position + v_movement * Time.deltaTime);

	}
}
