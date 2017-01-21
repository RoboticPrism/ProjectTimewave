using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private GameObject actionDialogue;
    public GameObject actionDialoguePrefab;
    public GameObject buttonPrefab;
    public Canvas uiCanvas;

	// Use this for initialization
	void Start () {
        ActionDialogueFactory.setActionDialoguePrefab(actionDialoguePrefab);
        ActionDialogueFactory.setUICanvas(uiCanvas);
        ButtonFactory.setButtonUIPrefab(buttonPrefab);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (actionDialogue == null)
            {
                actionDialogue = ActionDialogueFactory.createActionDialogue("This is a test action dialogue!\n\nHow cool!", null);
            } else
            {
                ActionDialogueFactory.destroyActionDialogue();
                actionDialogue = null;
            }
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            if (actionDialogue == null)
            {
                actionDialogue = ActionDialogueFactory.createActionDialogue("T\nH\nI\nS\n\nI\nS\n\nD\nI\nF\nF\nE\nR\nN\nT\n!", null);
            }
            else
            {
                ActionDialogueFactory.destroyActionDialogue();
                actionDialogue = null;
            }
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            List<GameObject> buttons = new List<GameObject>();
            buttons.Add(ButtonFactory.createButton("Test 1", test1));
            buttons.Add(ButtonFactory.createButton("This is a longer Test 2", test2));
            if (actionDialogue == null)
            {
                actionDialogue = ActionDialogueFactory.createActionDialogue("Here are all the buttons!\n\nPick One!", buttons);
            }
            else
            {
                ActionDialogueFactory.destroyActionDialogue();
                actionDialogue = null;
            }
        }
    }

    private void test1()
    {
        Debug.Log("Test 1 button pressed!");
        ActionDialogueFactory.destroyActionDialogue();
    }

    private void test2()
    {
        Debug.Log("Test 2 button pressed!");
        ActionDialogueFactory.destroyActionDialogue();
    }
}
