using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WilfredIcon : MonoBehaviour {

    public GameObject WilfredIconImage;
    public GameObject DeadWilfredIconImage;
    public GameObject DeathXIconImage;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void killWilfredIcon()
    {
        //gameOverText.SetActive(true);
        WilfredIconImage.SetActive(false);
        DeadWilfredIconImage.SetActive(true);
        DeathXIconImage.SetActive(true);
    }
}
