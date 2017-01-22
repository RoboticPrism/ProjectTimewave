using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    public TimedAction timedActionPrefab;
    public MoveAction moveActionPrefab;
    public TextAction textActionPrefab;

    public float moveSpeed = .01f;
    protected bool alive = true;
    protected GameObject textManager;
    public Timeline timeline;
    public List<BaseAction> currentActions = new List<BaseAction>();

    public bool doInteraction { get; set; }

	// Use this for initialization
	protected virtual void Start () {
        textManager = (FindObjectOfType(typeof(TextManager)) as TextManager).gameObject;
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
    public void DoActions(int current_seconds)
    {
        foreach (TimedAction action in timeline.GetTimeline())
        {
            action.DoTimedAction(current_seconds);
        }
    }

    // Cancels all actions that are currently running
    public void StopAllActions()
    {
        timeline.DeleteTimeline();
    }

    // Delete the user's future actions and add new ones
    public void ChangeFuture(Timeline newTimeline)
    {
        Debug.Log("changing future");
        timeline.DeleteTimeline();
        timeline = newTimeline;
        timeline.SetUpTimeline(this);
    }

    // Kill the character and end their future events
    public void Kill(BaseAction deathAction)
    {
        Debug.Log("DEAD");
        alive = false;
        StopAllActions();
        currentActions = new List<BaseAction>();
        deathAction.DoAction();
    }
}

