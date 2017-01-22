using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jerry : MonoBehaviour {

    public TextAction textActionPrefab;
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
        }
        if (coll.gameObject.GetComponent<Manhole>())
        {
            Kill();
            Destroy(this.GetComponent<SpriteRenderer>());
        }

    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (Input.GetAxis("Interact") > 0)
        {
            if (coll.gameObject.GetComponent<RoadRubbish>())
            {
                coll.gameObject.GetComponent<RoadRubbish>().Interact();
            }
            if (coll.gameObject.GetComponent<ManholeCover>())
            {
                coll.gameObject.GetComponent<ManholeCover>().Interact();
            }
            
        }
    }

    void Kill()
    {
        movementScript.Kill();
    }
}
