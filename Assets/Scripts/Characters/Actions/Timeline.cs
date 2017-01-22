using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timeline : MonoBehaviour {

    public List<TimedAction> timedActions;

	// Use this for initialization
	void Start () {
        timedActions = new List<TimedAction>();
        foreach (TimedAction action in this.GetComponentsInChildren<TimedAction>())
        {
            action.action = action.GetComponentInChildren<BaseAction>();
            timedActions.Add(action);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetUpTimeline(Character character)
    {
        foreach (TimedAction action in timedActions)
        {
            action.character = character;
            action.action.character = character;
        }
    }

    public List<TimedAction> GetTimeline()
    {
        return timedActions;
    }

    public void DeleteTimeline()
    {
        foreach (TimedAction action in timedActions)
        {
            action.StopTimedAction();
        }
        Destroy(this);
    }
}
