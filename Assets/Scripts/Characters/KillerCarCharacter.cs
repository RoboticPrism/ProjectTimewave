using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerCarCharacter : Character {

	// Use this for initialization
	void Start () {
        base.Start();
        timeline.SetUpTimeline(this);
    }
	
}
