using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private Animator anim;
	private Rigidbody2D rg2d;
	public float moveSpeed = 10;
    public float maxSpeed = 100;
    public int direction = 0;

	void Start() {
		anim = GetComponent<Animator> ();
		rg2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate() {
        float horizontal = SetMaxMin(rg2d.velocity.x/2 + Input.GetAxis("Horizontal") * moveSpeed, maxSpeed);
        float vertical = SetMaxMin(rg2d.velocity.y/2 + Input.GetAxis("Vertical") * moveSpeed, maxSpeed);
        Vector2 velocity = new Vector2(horizontal, vertical);
        rg2d.velocity = velocity;
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        if (angle < 0)
        {
            angle = 360 + angle;
        }
        float speed = velocity.sqrMagnitude;
        if (speed > 0)
        {
            // Forward
            if (angle >= 215f && angle <= 325f)
            {
                direction = 0;
            }
            // Left
            else if (angle > 135f && angle < 215f)
            {
                direction = 1;
            }
            // Down
            else if (angle >= 45f && angle <= 135f)
            {
                direction = 2;
            }
            // Right
            else if (angle < 45f || angle > 325f)
            {
                direction = 3;
            }
        }
        anim.SetFloat("Speed", velocity.magnitude);
        anim.SetInteger("Direction", direction);

    }

    float SetMaxMin(float original, float max)
    {
        if (original > max)
        {
            return original = max;
        } else if (original < -max)
        {
            return original = -max;
        }
        else
        {
            return original;
        }
    }
}