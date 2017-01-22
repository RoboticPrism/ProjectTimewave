using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextObject : MonoBehaviour {

    public int fontSize = 20;
    private Text text;
    public GameObject parent;
    public Vector3 offset;
    public int lifetimeSeconds = 5;
    public enum typeSpeed { INSTANT, QUICK, SLOW }

	// Use this for initialization
	void Start () {
        text = this.GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (parent != null)
        {
            this.GetComponent<RectTransform>().position = parent.transform.position + offset;
        }   
	}

    // Types out the text at the speed specified
    public void CreateText(GameObject parent, Vector3 offest, string newText, typeSpeed textSpeed, int fontSize)
    {
        this.parent = parent;
        text = this.GetComponentInChildren<Text>();
        text.fontSize = fontSize;
        if (textSpeed == typeSpeed.INSTANT)
        {
            text.text = newText;
        }
    }

    public void DeleteText()
    {
        Destroy(this.gameObject);
    }
}
