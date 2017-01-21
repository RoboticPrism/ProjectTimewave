using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    private float startTime;
    private int tickrate = 1;
	// Use this for initialization
	void Start () {
        startTime = Time.time;
        InvokeRepeating("BroadcastCurrentTime", 0.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {

	}

    void BroadcastCurrentTime()
    {
        BroadcastMessage("ReceiveCurrentTime", GetCurrentTime());
    }

    public float GetStartTime()
    {
        return startTime;
    }

    public float GetCurrentTime()
    {
        return (Time.time - startTime)/tickrate;
    }

    public void RestartTime()
    {
        startTime = Time.time;
    }

}
