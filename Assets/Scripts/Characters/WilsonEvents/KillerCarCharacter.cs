using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerCarCharacter : Character {

	// Use this for initialization
	void Start () {
        List<Action> beginning_timeline = new List<Action>();
        beginning_timeline.Add(new MoveToLocation(new Vector3(0, 4, 0), 7));
        ChangeFuture(beginning_timeline);
    }
	
}
