using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    //public delegate void TimeReceiver(float timeReceived);

    private float startTime;
    private int tickrate = 1;
    private List<TimeReceiver> timeReceivers;

    // Use this for initialization
    void Start () {
        startTime = Time.time;
        InvokeRepeating("BroadcastCurrentTime", 0.0f, 1.0f);
        if (timeReceivers == null) timeReceivers = new List<TimeReceiver>();
    }
	
	// Update is called once per frame
	void Update () {

	}

    void BroadcastCurrentTime()
    {
        float currentTime = GetCurrentTime();
        BroadcastMessage("ReceiveCurrentTime", currentTime);
        foreach (TimeReceiver receiver in timeReceivers)
        {
            receiver.receiveTime(currentTime);
        }
        if ((int)currentTime == 95)
        {
            bool success = false;
            if (success)
            {
                Application.LoadLevel(2);
            }
            else
            {
                Application.LoadLevel(0);
            }
        }
    }

    public void addTimeReceiver(TimeReceiver receiver)
    {
        if (timeReceivers == null) timeReceivers = new List<TimeReceiver>();
        this.timeReceivers.Add(receiver);
    }

    public void removeTimeReceiver(TimeReceiver receiver)
    {
        if (timeReceivers == null) timeReceivers = new List<TimeReceiver>();
        this.timeReceivers.Remove(receiver);
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
