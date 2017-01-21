using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public float moveSpeed = .01f;
    private bool alive = true;
    public List<Action> actions = new List<Action>();

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // Listens for updates from the time controller
    public void ReceiveCurrentTime(int current_seconds)
    {
        if (alive)
        {
            DoActions(current_seconds);
        }
    }

    // Searchs player actions and runs actions if its time
    public virtual void DoActions(int current_seconds)
    {
        foreach (Action action in actions)
        {
            action.DoAction(this, current_seconds);
        }
    }

    // Moves the character to the given location
    public void MoveToLocation(Vector3 targetLocation)
    {
        StartCoroutine(MoveToLocationEnum(this.gameObject, targetLocation));
    }

    protected IEnumerator MoveToLocationEnum(GameObject character, Vector3 targetLocation)
    {
        while (Vector3.Distance(this.transform.position, targetLocation) > 0.01f)
        {
            character.transform.position = Vector3.MoveTowards(character.transform.position, targetLocation, moveSpeed);
            yield return null;
        }
        this.transform.position = targetLocation;
        yield return null;
    }

    // Makes the character say something
    public void WriteText(string characterText)
    {
        //TODO
    }

    // Kill the character and end their future events
    public void Kill()
    {
        alive = false;
        actions = new List<Action>(); // Delete the list, dead people can't do stuff
    }
}

// Base class for actions
public abstract class Action
{
    public abstract void DoAction(Character character, int current_time);
} 

// Move to location action
public class MoveToLocation : Action
{
    public Vector3 targetLocation;
    public int activateOn;

    public MoveToLocation(Vector3 targetLocation, int activateOn)
    {
        this.targetLocation = targetLocation;
        this.activateOn = activateOn;
    }

    public override void DoAction(Character character, int current_time)
    {
        if (current_time == activateOn)
        {
            character.MoveToLocation(targetLocation);
        }
    }
}

// Write text action
public class WriteText : Action
{
    public string characterText;
    public int activateOn;

    public WriteText(string characterText, int activateOn)
    {
        this.characterText = characterText;
        this.activateOn = activateOn;
    }

    public override void DoAction(Character character, int current_time)
    {
        if (current_time == activateOn) { 
            character.WriteText(characterText);
        }
    }
}

