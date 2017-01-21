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

    public void SetUp(GameObject parent, Vector3 offset, int fontSize)
    {
        this.parent = parent;
        this.offset = offset;
        this.fontSize = fontSize;
    }

    // Types out the text at the speed specified
    public void WriteText(string newText, typeSpeed textSpeed, int secondsUntilDelete)
    {
        text = this.GetComponentInChildren<Text>();
        if (textSpeed == typeSpeed.INSTANT)
        {
            text.text = newText;
        }
        StartCoroutine(WaitToDeleteEnum(secondsUntilDelete));
    }

    protected IEnumerator WaitToDeleteEnum(int secondsUntilDelete)
    {
        while (true)
        {
            yield return new WaitForSeconds(secondsUntilDelete);
            Debug.Log("delete text");
            Destroy(this.gameObject);
        }
    }
}
