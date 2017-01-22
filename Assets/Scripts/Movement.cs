using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private Animator anim;
	private Rigidbody2D rg2d;
	private float moveHorizontal;
	private float moveVertical;

	void Start() {
		anim = GetComponent<Animator> ();
		rg2d = GetComponent<Rigidbody2D> ();
		moveHorizontal = 0.0f;
		moveVertical = 0.0f;
	}

	void FixedUpdate() {
		moveHorizontal = Input.GetAxis("Horizontal");
		moveVertical = Input.GetAxis("Vertical");
		print (moveHorizontal);
		print (moveVertical);
		Vector2 speed = new Vector2 (moveHorizontal, moveVertical);
		rg2d.AddForce(speed);
		anim.SetFloat("Speed", speed.magnitude);
		if (Input.GetKey("up")) {
			anim.SetInteger("Direction", 0);
		}
		else if (Input.GetKey("left")) {
			anim.SetInteger("Direction", 1);
		}
		else if (Input.GetKey ("down")) {
			anim.SetInteger("Direction", 2);
		}
		else if (Input.GetKey ("right")) {
			anim.SetInteger("Direction", 3);
		}
	}
}