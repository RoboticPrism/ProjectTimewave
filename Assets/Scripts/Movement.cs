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
		down_movement = Resources.Load<Sprite> ("Sprites/jerry_font_walk");
		left_idle = Resources.Load<Sprite> ("Sprites/jerry_left_idle");
		left_movement = Resources.Load<Sprite> ("Sprites/jerry_left_movement");
		right_idle = Resources.Load<Sprite> ("Sprites/jerry_right_idle");
		right_movement = Resources.Load<Sprite> ("Sprites/jerry_right_movement");

		// Set default direction
		sp.sprite = up_idle;
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
		if (Input.GetKey ("up")) {
			sp.sprite = up_movement;
		}
		if (Input.GetKey ("down")) {
			sp.sprite = down_movement;
		}
		if (Input.GetKey ("left")) {
			sp.sprite = left_movement;
		}
		if (Input.GetKey ("right")) {
			sp.sprite = right_movement;
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