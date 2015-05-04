using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	const string IS_WALKING = "isWalking";

	Rigidbody2D rbody;
	Animator anim;

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float input_x = Input.GetAxisRaw("Horizontal");
		float input_y = Input.GetAxisRaw("Vertical");
		Vector2 movement_vector = new Vector2(input_x, input_y);

		if (movement_vector != Vector2.zero) {
			anim.SetBool (IS_WALKING, true);
			anim.SetFloat("input_x", input_x);
			anim.SetFloat("input_y", input_y);
		} else {
			anim.SetBool(IS_WALKING, false);
		}

		rbody.MovePosition(rbody.position + movement_vector.normalized * Time.deltaTime);

	}
}
