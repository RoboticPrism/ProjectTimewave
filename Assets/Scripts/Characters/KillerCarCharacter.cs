using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerCarCharacter : Character {

    public Timeline crashTimeline;

	// Use this for initialization
	void Start () {
        base.Start();
        timeline.SetUpTimeline(this);
    }

    public override void OnTriggerEnter2D(Collider2D coll)
    {
        base.OnTriggerEnter2D(coll);
        RoadRubbish interact = coll.gameObject.GetComponent<RoadRubbish>();
        this.triggers.Remove(coll);
        if (interact != null)
        {
            Debug.Log("Collision!");
            ChangeFuture(crashTimeline);
        }
    }
	
}
