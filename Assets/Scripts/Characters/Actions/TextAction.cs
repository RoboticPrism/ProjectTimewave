using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAction : BaseAction {

    public TextObject textObjectPrefab;
    public TextObject textObject;

    public Vector3 offest;
    public string text;
    public TextObject.typeSpeed textSpeed;
    public int textSize;
    public int lifetime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public TextAction SetUp(Character character, Vector3 offest, string text, TextObject.typeSpeed textSpeed, int textSize, int lifetime)
    {
        this.character = character;
        this.offest = offest;
        this.text = text;
        this.textSpeed = textSpeed;
        this.textSize = textSize;
        this.lifetime = lifetime;
        return this;
    }

    public override void DoAction()
    {
        StartCoroutine(WriteText(character, offest, text, textSpeed, textSize, lifetime));
    }

    public override void StopAction()
    {
        Destroy(this.gameObject);
    }

    IEnumerator WriteText(Character character, Vector3 offset, string text, TextObject.typeSpeed textSpeed, int textSize, int lifetime)
    {
        textObject = Instantiate(textObjectPrefab);
        textObject.transform.SetParent((FindObjectOfType(typeof(TextManager)) as TextManager).gameObject.transform);
        textObject.CreateText(character.gameObject, offset, text, textSpeed, textSize);
        yield return new WaitForSeconds(lifetime);
        textObject.DeleteText();
    }
}
