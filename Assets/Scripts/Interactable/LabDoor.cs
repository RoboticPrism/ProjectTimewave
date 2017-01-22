using Assets.Scripts.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabDoor : MonoBehaviour, InteractibleObject {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private int access = 0;
    public void Interact(Actor actor)
    {
        Debug.Log("Interaction with lab door! " + access++);
        if (actor is LabWorker)
        {
            Debug.Log("Interaction with lab door from a worked!");
            LabWorker worker = (LabWorker)actor;
            worker.enterLab();
        }
    }
}
