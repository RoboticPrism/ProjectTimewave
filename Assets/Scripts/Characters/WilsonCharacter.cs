using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WilsonCharacter : Character {

	// Use this for initialization
	void Start () {
        actions.Add(new MoveToLocation(new Vector3(2, 0, 0), 2));
        actions.Add(new MoveToLocation(new Vector3(0, 0, 0), 3));
        actions.Add(new MoveToLocation(new Vector3(0, 2, 0), 5));
    }
}
