using Assets.Scripts.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Jerry : MonoBehaviour, BagelReceiver {

    public TextObject textObjectPrefab;
    public TextObject textObject;
    public bool alive = true;
    Movement movementScript;
    Animator anim;
    IEnumerator currentCoroutine;

	// Use this for initialization
	void Start () {
        movementScript = GetComponent<Movement>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Restart") > 0)
        {
            Application.LoadLevel(2);
        }
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
                if (currentCoroutine == null)
                {
                    currentCoroutine = WriteText(new Vector3(0, 1, 0), "This looks like it could easily make a car spin out. Lets get rid of this...", TextObject.typeSpeed.INSTANT, 20, 5);
                    StartCoroutine(currentCoroutine);
                    coll.gameObject.GetComponent<RoadRubbish>().Interact(null);
                }
            } else if (coll.gameObject.GetComponent<ManholeCover>())
            {
                if (currentCoroutine == null)
                {
                    currentCoroutine = WriteText(new Vector3(0, 1, 0), "This open manhole looks really dangerous, lets cover this up...", TextObject.typeSpeed.INSTANT, 20, 5);
                    StartCoroutine(currentCoroutine);
                    coll.gameObject.GetComponent<ManholeCover>().Interact(null);
                }
            } else if (coll.gameObject.GetComponent<InteractibleObject>() != null)
            {
                if (currentCoroutine == null)
                {
                    coll.gameObject.GetComponent<InteractibleObject>().Interact(this);
                }
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
        currentCoroutine = null;
    }

    void Kill()
    {
        movementScript.Kill();
    }

    public void receiveBagel(bool bagelReceived)
    {
        if (bagelReceived)
        {
            currentCoroutine = WriteText(new Vector3(0, 1, 0), "Bagels are delicious! I'll take one!", TextObject.typeSpeed.INSTANT, 20, 5);
        } else
        {
            currentCoroutine = WriteText(new Vector3(0, 1, 0), "Aw... Looks like they are out of bagels", TextObject.typeSpeed.INSTANT, 20, 5);
        }
        StartCoroutine(currentCoroutine);
    }
}
