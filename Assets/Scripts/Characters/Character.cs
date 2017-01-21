using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    public float moveSpeed = .01f;
    private bool alive = true;
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

    }
}
