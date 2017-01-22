using Assets.Scripts.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadRubbish : MonoBehaviour, InteractibleObject
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Interact(Actor actor)
    {
        Destroy(this.gameObject);
    }
}
