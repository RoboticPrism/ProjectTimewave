using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFactory : MonoBehaviour {

    private static GameObject buttonUIPrefab;

    public delegate void ButtonPress();

    public static void setButtonUIPrefab(GameObject prefab)
    {
        buttonUIPrefab = prefab;
    }

    private static float xAnchor = 0.5f;
    private static float yAnchor = 1.0f;

    public static GameObject createButton(string text, ButtonPress buttonPress)
    {
        GameObject button = null;
        if (buttonUIPrefab == null)
        {
            Debug.Log("Prefab must be set on ActionDialogueFactory before and action dialogue can be created!!!");
            return button;
        }
        else
        {
            button = (GameObject) Instantiate(buttonUIPrefab);
            button.transform.GetChild(0).transform.GetComponent<Text>().text = text;
            button.GetComponent<Button>().onClick.AddListener(() => buttonPress());
        }
        return button;
    }

    public static void destroyButton(GameObject button)
    {
        Debug.Log("Destroying " + button.transform.GetChild(0).transform.GetComponent<Text>().text + "  button.");
        Destroy(button);
    }
}
