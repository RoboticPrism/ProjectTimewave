using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WilsonCharacter : Character {

	// Use this for initialization
	void Start () {
        List<Action> beginning_timeline = new List<Action>(); 
        beginning_timeline.Add(new MoveToLocation(new Vector3(4, 0, 0), 3));
        beginning_timeline.Add(new MoveToLocation(new Vector3(0, 0, 0), 6));
        beginning_timeline.Add(new MoveToLocation(new Vector3(0, 4, 0), 9));
        ChangeFuture(beginning_timeline);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<KillerCarCharacter>())
        {
            Kill();
        }
    }
}
