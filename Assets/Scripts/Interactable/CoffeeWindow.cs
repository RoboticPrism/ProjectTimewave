using Assets.Scripts.Characters;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeWindow : MonoBehaviour, InteractibleObject
{
    public int RemainingBagels;

    public void Interact(Actor actor)
    {
        if (actor is BagelReceiver)
        {
            BagelReceiver receiver = (BagelReceiver)actor;
            if(RemainingBagels > 0)
            {
                RemainingBagels--;
                receiver.receiveBagel(true);
            }
            else {
                receiver.receiveBagel(false);
            }
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
