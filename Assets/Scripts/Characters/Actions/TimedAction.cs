using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedAction : MonoBehaviour {

    public Character character;
    public BaseAction action;
    public int activateOn;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public TimedAction SetUp(Character character, BaseAction action, int activateOn)
    {
        this.character = character;
        this.transform.SetParent(character.transform);
        this.action = action;
        this.activateOn = activateOn;
        return this;
    }

    public void DoTimedAction(int current_time)
    {
        if (current_time == activateOn || activateOn == -1)
        {
            action.DoAction();
        }
    }

    public void StopTimedAction()
    {
        action.StopAction();
        Destroy(this);
    }
}
