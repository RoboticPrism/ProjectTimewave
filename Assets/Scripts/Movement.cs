using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float speed;
	public float maxVelocity;

	private Rigidbody2D rb2d;
	private SpriteRenderer sp;
	private Sprite up_idle;
	private Sprite up_movement;
	private Sprite down_idle;
	private Sprite down_movement;
	private Sprite left_idle;
	private Sprite left_movement;
	private Sprite right_idle;
	private Sprite right_movement;

	void Start() {
		rb2d = GetComponent<Rigidbody2D> ();
		sp = gameObject.GetComponent<SpriteRenderer> ();
		up_idle = Resources.Load<Sprite> ("Sprites/jerry_back_idle");
		up_movement = Resources.Load<Sprite> ("Sprites/jerry_back_walk");
		down_idle = Resources.Load<Sprite> ("Sprites/jerry_front_idle");
		down_movement = Resources.Load<Sprite> ("Sprites/jerry_front_walk");
		left_idle = Resources.Load<Sprite> ("Sprites/jerry_left_idle");
		left_movement = Resources.Load<Sprite> ("Sprites/jerry_left_walk");
		right_idle = Resources.Load<Sprite> ("Sprites/jerry_right_idle");
		right_movement = Resources.Load<Sprite> ("Sprites/jerry_right_walk");

		// Set default direction
		sp.sprite = up_idle;
	}

	void FixedUpdate() {
		float moveHorizontal;
		float moveVertical;
		string direction;
		string motion;

		moveHorizontal = Input.GetAxis("Horizontal");
		moveVertical = Input.GetAxis("Vertical");
		print ("Velocity: " + rb2d.velocity.ToString());
		if (rb2d.velocity.sqrMagnitude <= maxVelocity) {
			rb2d.AddForce (new Vector2 (moveHorizontal, moveVertical) * speed);
		}

		/*if (Input.GetKeyDown ("up")) {
			sp.sprite = up_idle;
		}*/
		if (Input.GetKey ("up")) {
			direction = "up";
		}
		/*if (Input.GetKeyUp ("up")) {
			sp.sprite = up_idle;
		}
		if (Input.GetKeyDown ("down")) {
			sp.sprite = down_idle;
		}*/
		else if (Input.GetKey ("down")) {
			direction = "down";
		}
		/*if (Input.GetKeyUp ("down")) {
			sp.sprite = down_idle;
		}
		if (Input.GetKeyDown ("left")) {
			sp.sprite = left_idle;
		}*/
		else if (Input.GetKey ("left")) {
			direction = "left";
		}
		/*if (Input.GetKeyUp ("left")) {
			sp.sprite = left_idle;
		}
		if (Input.GetKeyDown ("right")) {
			sp.sprite = right_idle;
		}*/
		else if (Input.GetKey ("right")) {
			direction = "right";
		}
		/*if (Input.GetKeyUp ("right")) {
			sp.sprite = right_idle;
		}*/
		if (rb2d.velocity.magnitude > 0.2) {
			motion = "walk";
		} else {
			motion = "idle";
		}

		sp.sprite = "jerry_" + direction + "_" + motion;
	}
}