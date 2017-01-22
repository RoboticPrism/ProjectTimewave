using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jerry : MonoBehaviour {

    public TextObject textObjectPrefab;
    public TextObject textObject;
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
            StartCoroutine(WriteText(new Vector3(0, 1, 0), "AGHHHH", TextObject.typeSpeed.INSTANT, 40, 5));
        }
        if (coll.gameObject.GetComponent<Manhole>())
        {
            Kill();
            Destroy(this.GetComponent<SpriteRenderer>());
            StartCoroutine(WriteText(new Vector3(0, 1, 0), "AAAAAaaaaaa....\n!SPLOOOSH!", TextObject.typeSpeed.INSTANT, 20, 5));
        }

    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (Input.GetAxis("Interact") > 0)
        {
            if (coll.gameObject.GetComponent<RoadRubbish>())
            {
                StartCoroutine(WriteText(new Vector3(0, 1, 0), "This looks like it could easily make a car spin out. Lets get rid of this...", TextObject.typeSpeed.INSTANT, 20, 5));
                coll.gameObject.GetComponent<RoadRubbish>().Interact();
            }
            if (coll.gameObject.GetComponent<ManholeCover>())
            {
                StartCoroutine(WriteText(new Vector3(0, 1, 0), "This open manhole looks really dangerous, lets cover this up...", TextObject.typeSpeed.INSTANT, 20, 5));
                coll.gameObject.GetComponent<ManholeCover>().Interact();
            }
            
        }
    }

    IEnumerator WriteText(Vector3 offset, string text, TextObject.typeSpeed textSpeed, int textSize, int lifetime)
    {
        if (textObject != null)
        {
            Destroy(textObject.gameObject);
        }
        textObject = Instantiate(textObjectPrefab);
        textObject.transform.SetParent((FindObjectOfType(typeof(TextManager)) as TextManager).gameObject.transform);
        textObject.CreateText(this.gameObject, offset, text, textSpeed, textSize);
        yield return new WaitForSeconds(lifetime);
        textObject.DeleteText();
    }

    void Kill()
    {
        movementScript.Kill();
    }
}
