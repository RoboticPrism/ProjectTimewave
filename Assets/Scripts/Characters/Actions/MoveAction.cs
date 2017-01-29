using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveAction : BaseAction {

    public Vector3 targetLocation;
    private float moveSpeedPerSecond;
    private bool moving;
    private float distance;

	// Use this for initialization
	void Start () {
        moving = false;
	}
	
	// Update is called once per frame
	void Update () {
        moveTowardsTarget();		
	}

    public override void DoAction()
    {
        this.moveSpeedPerSecond = Character.moveSpeed;
        this.moving = true;
        distance = Vector3.Distance(Character.transform.position, targetLocation);
    }

    public override void StopAction()
    {
        moving = false;
        Destroy(this.gameObject);
    }

    public void moveTowardsTarget()
    {
        if(moving)
        {
            float moveDistance = Time.deltaTime * moveSpeedPerSecond;
            Character.transform.position = Vector3.MoveTowards(Character.transform.position, targetLocation, moveDistance);
            if (Character.transform.position.Equals(targetLocation))
            {
                moving = false;
            }
        }
    }
}
