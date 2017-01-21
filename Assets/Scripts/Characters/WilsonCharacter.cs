using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WilsonCharacter : Character {

    
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void DoActions(int current_seconds)
    {
        if (current_seconds == 2)
        {
            MoveToLocation(new Vector3(2, 0, 0));
        }
    }
    

}
