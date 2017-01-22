using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : BaseAction {

    public Vector3 targetLocation;
    public float moveSpeed;
    private IEnumerator coroutine;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public MoveAction SetUp(Character character, Vector3 targetLocation, float moveSpeed)
    {
        this.character = character;
        this.targetLocation = targetLocation;
        this.moveSpeed = moveSpeed;
        return this;
    }

    public override void DoAction()
    {
        this.moveSpeed = character.moveSpeed;
        coroutine = MoveToLocationEnum(character.gameObject, targetLocation);
        StartCoroutine(coroutine);
    }

    public override void StopAction()
    {
        if (coroutine != null) {
            StopCoroutine(coroutine);
        }
        Destroy(this.gameObject);
    }

    protected IEnumerator MoveToLocationEnum(GameObject character, Vector3 targetLocation)
    {
        while (Vector3.Distance(character.transform.position, targetLocation) > 0.01f)
        {
            character.transform.position = Vector3.MoveTowards(character.transform.position, targetLocation, moveSpeed);
            yield return null;
        }
        character.transform.position = targetLocation;
        yield return null;
    }
}
