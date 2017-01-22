using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadRubbish : InteractibleObject {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Interact()
    {
        Destroy(this.gameObject);
    }
}
