using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float speed;
	public float maxVelocity;

	private Rigidbody2D rb2d;
	private SpriteRenderer sp;
	private Sprite up;
	private Sprite down;
	private Sprite left;
	private Sprite right;

	void Start() {
		rb2d = GetComponent<Rigidbody2D> ();
		sp = gameObject.GetComponent<SpriteRenderer> ();
		up = Resources.Load<Sprite> ("Sprites/jerry_back_idle");
		down = Resources.Load<Sprite> ("Sprites/jerry_front_idle");
		left = Resources.Load<Sprite> ("Sprites/jerry_left_idle");
		right = Resources.Load<Sprite> ("Sprites/jerry_right_idle");

		// Set default direction
		sp.sprite = up;
	}

	void FixedUpdate() {
		float moveHorizontal;
		float moveVertical;

		moveHorizontal = Input.GetAxis("Horizontal");
		moveVertical = Input.GetAxis("Vertical");
		print ("Velocity: " + rb2d.velocity.ToString());
		if (rb2d.velocity.sqrMagnitude <= maxVelocity) {
			rb2d.AddForce (new Vector2 (moveHorizontal, moveVertical) * speed);
		}
		if (Input.GetKeyDown ("up")) {
			sp.sprite = up;
		}
		if (Input.GetKeyDown ("down")) {
			sp.sprite = down;
		}
		if (Input.GetKeyDown ("left")) {
			sp.sprite = left;
		}
		if (Input.GetKeyDown ("right")) {
			sp.sprite = right;
		}
		/*if (Input.GetKeyUp ("up")) {
			print ("Up Key Released");
			rb2d.AddForce (new Vector2(1.0f, rb2d.velocity.x));
		}*/
		/*if (Input.GetKeyUp ("down")) {
			print ("Down Key Released");
			rb2d.AddForce(
		}*/
	}
}