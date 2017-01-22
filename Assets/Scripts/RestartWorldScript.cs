using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartWorldScript : MonoBehaviour {

    public MovieTexture movie;

	// Use this for initialization
	void Start () {
        Debug.Log("start movie");
        movie = ((MovieTexture)GetComponent<Renderer>().material.mainTexture);
        movie.Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (!movie.isPlaying || Input.GetAxis("Interact") > 0)
        {
            Debug.Log("movie end");
            Application.LoadLevel(0);
        }
    }
}
