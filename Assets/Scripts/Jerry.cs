using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jerry : MonoBehaviour {

    public bool alive = true;
    Movement movementScript;
    Animator anim;

	// Use this for initialization
	void Start () {
        movementScript = GetComponent<Movement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<KillerCarCharacter>())
        {
            Kill();
            Debug.Log("jerry died");
        }

    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (Input.GetAxis("Interact") > 0)
        {
            if (coll.gameObject.GetComponent<RoadRubbish>())
            {
                Debug.Log("boop");
                coll.gameObject.GetComponent<RoadRubbish>().Interact();
            }
        }
    }

    void Kill()
    {
        movementScript.Kill();
    }
}
