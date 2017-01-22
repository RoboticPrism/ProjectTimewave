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

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<RoadRubbish>())
        {
            Debug.Log("Collision!");
            ChangeFuture(crashTimeline);
        }
    }
	
}
