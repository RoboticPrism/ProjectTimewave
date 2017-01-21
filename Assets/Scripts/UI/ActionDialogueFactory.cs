using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionDialogueFactory : MonoBehaviour {

    //set outside this class
    private static GameObject actionDialogueUIPrefab;
    private static Canvas uiCanvas;

    //set inside this class
    private static GameObject actionDialogueUI = null;
    private static List<GameObject> buttons;


    //methods
    public static void setActionDialoguePrefab(GameObject prefab)
    {
        actionDialogueUIPrefab = prefab;
    }
    public static void setUICanvas(Canvas canvas)
    {
        uiCanvas = canvas;
    }

    private static float xAnchor = 0.5f;
    private static float yAnchor = 1.0f;

    /*
     * The createActionDialogue function will create and action dialogue with buttons. These buttons will be cleaned up with the ActionDialogue goes away.
    */
    public static GameObject createActionDialogue(string text, List<GameObject> buttons)
    {
        if(actionDialogueUIPrefab == null)
        {
            Debug.Log("Prefab must be set on ActionDialogueFactory before and action dialogue can be created!!!");
            return null;
        }
        if (uiCanvas == null)
        {
            Debug.Log("UI Canvas must be set on ActionDialogueFactory before and action dialogue can be created!!!");
            return null;
        }
        if (actionDialogueUI != null)
        {
            Debug.Log("Attempt to create an action dialogue when one is already being displayed. Ignoring second request!");
        }
        else
        {
            actionDialogueUI = (GameObject)Instantiate(actionDialogueUIPrefab);
            actionDialogueUI.transform.SetParent(uiCanvas.transform);
            actionDialogueUI.transform.GetComponent<RectTransform>().anchorMin = new Vector2(xAnchor, yAnchor);
            actionDialogueUI.transform.GetComponent<RectTransform>().anchorMax = new Vector2(xAnchor, yAnchor);
            actionDialogueUI.transform.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1.0f);
            actionDialogueUI.transform.GetComponent<RectTransform>().anchoredPosition = (Vector3)new Vector2(0, -120.0f);
            actionDialogueUI.transform.GetChild(0).transform.GetComponent<Text>().text = text;
            addButtonsToDialogue(buttons);
        }
        return actionDialogueUI;
    }

    public static void destroyActionDialogue()
    {
        Debug.Log("Destroying current action dialogue.");
        if (buttons != null)
        {
            foreach (GameObject button in buttons)
            {
                ButtonFactory.destroyButton(button);
            }
            buttons = null;
        }
        Destroy(actionDialogueUI);
        actionDialogueUI = null;
    }

    private static void addButtonsToDialogue(List<GameObject> buttons)
    {
        if (buttons == null) return;
        foreach(GameObject button in buttons)
        {
            button.transform.SetParent(actionDialogueUI.transform);
        }
        ActionDialogueFactory.buttons = buttons;
    }
}
