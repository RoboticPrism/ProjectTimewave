using Assets.Scripts.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManholeCover : MonoBehaviour, InteractibleObject
{

    IEnumerator moveIntoPlace;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Interact(Actor actor)
    {
        if (moveIntoPlace == null)
        {
            moveIntoPlace = MoveIntoPlace();
            StartCoroutine(moveIntoPlace);
        }
    }

    IEnumerator MoveIntoPlace()
    {
        Manhole manhole = FindObjectOfType(typeof(Manhole)) as Manhole;
        while (Vector3.Distance(manhole.gameObject.transform.position, this.transform.position) > 0.1f)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, manhole.transform.position, 0.01f);
            yield return null;
        }
        this.transform.position = manhole.transform.position;
        Destroy(manhole);
    }
}
