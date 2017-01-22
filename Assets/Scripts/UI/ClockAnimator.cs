using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Scripts;

public class ClockAnimator : MonoBehaviour, TimeReceiver
{

    private const float
       hoursToDegrees = 360f / 12f,
       minutesToDegrees = 360f / 60f,
       secondsToDegrees = 360f / 60f;

    public Transform seconds;
    public GameObject timeManagerGO;

    private void Start()
    {
        TimeManager manager = timeManagerGO.GetComponent<TimeManager>();
        manager.addTimeReceiver(this);
    }

    void Update()
    {
    }

    void TimeReceiver.receiveTime(float timeReceived)
    {
        //Debug.Log("Received Time " + timeReceived);
        float degrees = (timeReceived / -95.0f) * 360.0f + 90;
        seconds.localRotation = Quaternion.Euler(0f, 0f, degrees);
    }
}
