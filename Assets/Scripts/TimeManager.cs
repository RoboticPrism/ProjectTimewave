using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    //public delegate void TimeReceiver(float timeReceived);

    private float startTime;
    private int tickrate = 1;
    private List<TimeReceiver> timeReceivers;

    private static TimeManager instance;

    private bool success;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Attempting to create more than one TimeManager!!!");
        }
        if (timeReceivers == null) timeReceivers = new List<TimeReceiver>();
    }

    public static TimeManager getInstance()
    {
        return instance;
    }

    // Use this for initialization
    void Start () {
        success = false;
        startTime = Time.time;
        InvokeRepeating("BroadcastCurrentTime", 0.0f, 1.0f);
    }
	
	// Update is called once per frame
	void Update () {

	}

    void BroadcastCurrentTime()
    {
        float currentTime = GetCurrentTime();
        //BroadcastMessage("ReceiveCurrentTime", currentTime);
        foreach (TimeReceiver receiver in timeReceivers)
        {
            receiver.receiveTime(currentTime);
        }
        if ((int)currentTime == 95)
        {
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
        this.timeReceivers.Add(receiver);
    }

    public void removeTimeReceiver(TimeReceiver receiver)
    {
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

    public void setSuccess(bool success)
    {
        this.success = success;
    }

}
