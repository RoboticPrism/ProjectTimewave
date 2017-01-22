using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject followObject;
    public Vector3 offset;
    public Vector2 minBounds;
    public Vector2 maxBounds;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 newLocation = followObject.transform.position + offset;
        this.transform.position = new Vector3(newLocation.x, newLocation.y, this.transform.position.z);
	}


}
