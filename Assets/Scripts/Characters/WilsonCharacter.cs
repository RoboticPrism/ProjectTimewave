﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WilsonCharacter : Character {

    Animator anim;
    Rigidbody2D rgbd;
    int direction = 0;
    Vector3 lastLocation;

	// Use this for initialization
	void Start () {
        base.Start();
        timeline.SetUpTimeline(this);
        anim = GetComponent<Animator>();
        rgbd = GetComponent<Rigidbody2D>();
        lastLocation = this.transform.position;
    }

    void FixedUpdate()
    {
        Vector2 velocity = this.transform.position - lastLocation;
        float speed = velocity.sqrMagnitude;
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        if (speed > 0)
        {
            if (angle >= 215f && angle <= 325f)
            {
                direction = 0;
            }
            else if (angle > 135f && angle < 215f)
            {
                direction = 1;
            }
            else if (angle >= 45f && angle <= 135f)
            {
                direction = 2;
            }
            else if (angle < 45f || angle > 325f)
            {
                direction = 3;
            }
        }
        Debug.Log(speed);
        anim.SetFloat("Speed", speed);
        anim.SetInteger("Direction", direction);
        lastLocation = this.transform.position;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<KillerCarCharacter>())
        {
            Kill(Instantiate(textActionPrefab).SetUp(this, new Vector3(0, 1, 0), "BLRGRGgggg....", TextObject.typeSpeed.INSTANT, 40, 3));
        }
    }
}
