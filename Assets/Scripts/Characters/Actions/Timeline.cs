using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timeline : MonoBehaviour {

    private List<TimedAction> timedActions;
    private List<BaseAction> timedActions2;

    private void Awake()
    {
        timedActions = new List<TimedAction>();
        timedActions2 = new List<BaseAction>();

        foreach (TimedAction action in this.GetComponentsInChildren<TimedAction>())
        {
            action.action = action.GetComponentInChildren<BaseAction>();
            timedActions.Add(action);
        }

        foreach (BaseAction action in this.GetComponentsInChildren<BaseAction>())
        {
            timedActions2.Add(action);
        }
    }

    // Use this for initialization
    void Start () {
        
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetUpTimeline(Character character)
    {
        foreach (BaseAction action in timedActions2)
        {
            action.SetCharacter(character);
        }
    }

    public void DeleteTimeline()
    {
        foreach (TimedAction action in timedActions)
        {
            action.StopTimedAction();
        }
        foreach (BaseAction action in timedActions2)
        {
            action.StopAction();
        }
        Destroy(this);
    }

    public void DoTimedActions(int current_seconds)
    {
        foreach (BaseAction action in timedActions2)
        {
            if (action.ActivateOn == current_seconds || action.ActivateOn == -1)
            {
                action.DoAction();
            }
        }
    }
}
