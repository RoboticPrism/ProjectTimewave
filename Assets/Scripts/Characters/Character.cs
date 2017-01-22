using Assets.Scripts;
using Assets.Scripts.Characters;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, TimeReceiver, Actor {
    public TimedAction timedActionPrefab;
    public MoveAction moveActionPrefab;
    public TextAction textActionPrefab;

    public float moveSpeed = .01f;
    protected bool alive = true;
    protected GameObject textManager;
    public Timeline timeline;
    public List<BaseAction> currentActions = new List<BaseAction>();

    protected List<Collider2D> triggers;

	// Use this for initialization
	protected virtual void Start () {
        textManager = (FindObjectOfType(typeof(TextManager)) as TextManager).gameObject;
		timeline.SetUpTimeline(this);
        TimeManager.getInstance().addTimeReceiver(this);
        triggers = new List<Collider2D>();
    }
	
	// Update is called once per frame
	void Update () {

	}

    public virtual void OnTriggerEnter2D(Collider2D coll)
    {
        triggers.Add(coll);
    }

    public virtual void OnTriggerExit2D(Collider2D coll)
    {
        triggers.Remove(coll);
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

    public void receiveTime(float timeReceived)
    {
        if (alive)
        {
            DoActions((int)timeReceived);
        }
    }

    public void doInteraction()
    {
        foreach (Collider2D trigger in triggers)
        {
            InteractibleObject interactable = trigger.gameObject.GetComponent<InteractibleObject>();
            if (interactable != null)
            {
                interactable.Interact(this);
            }
        }
            
    }
}

