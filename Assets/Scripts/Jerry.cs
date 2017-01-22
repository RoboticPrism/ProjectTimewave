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

    private List<Collider2D> triggers;

    // Use this for initialization
    void Start () {
        movementScript = GetComponent<Movement>();
        triggers = new List<Collider2D>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Restart") > 0)
        {
            Application.LoadLevel(0);
        }
        if (Input.GetAxis("Interact") > 0)
        {
            doInterraction();
        }

    }

    private void doInterraction()
    {
        List<Collider2D> objectsToRemove = new List<Collider2D>();
        foreach (Collider2D trigger in triggers)
        {
            if (trigger.gameObject.GetComponent<RoadRubbish>())
            {
                //triggers.Remove(trigger);
                if (currentCoroutine == null)
                {
                    currentCoroutine = WriteText(new Vector3(0, 1, 0), "This looks like it could easily make a car spin out. Lets get rid of this...", TextObject.typeSpeed.INSTANT, 20, 5);
                    StartCoroutine(currentCoroutine);
                    trigger.gameObject.GetComponent<RoadRubbish>().Interact(null);
                    objectsToRemove.Add(trigger);
                }
            }
            else if (trigger.gameObject.GetComponent<ManholeCover>())
            {
                if (currentCoroutine == null)
                {
                    currentCoroutine = WriteText(new Vector3(0, 1, 0), "This open manhole looks really dangerous, lets cover this up...", TextObject.typeSpeed.INSTANT, 20, 5);
                    StartCoroutine(currentCoroutine);
                    trigger.gameObject.GetComponent<ManholeCover>().Interact(null);
                }
            }
            else if (trigger.gameObject.GetComponent<InteractibleObject>() != null)
            {
                if (currentCoroutine == null)
                {
                    trigger.gameObject.GetComponent<InteractibleObject>().Interact(this);
                }
            }
        }
        foreach(Collider2D removal in objectsToRemove)
        {
            triggers.Remove(removal);
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D coll)
    {
        triggers.Add(coll);
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

    public virtual void OnTriggerExit2D(Collider2D coll)
    {
        triggers.Remove(coll);
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
        StartCoroutine(resetWorld());
    }

    public IEnumerator resetWorld()
    {
        yield return new WaitForSeconds(3);
        Application.LoadLevel(3);
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
