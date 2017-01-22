using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClockAnimator : MonoBehaviour {

    private const float
       hoursToDegrees = 360f / 12f,
       minutesToDegrees = 360f / 60f,
       secondsToDegrees = 360f / 60f;

    public Transform seconds;

     void Update()
    {
        DateTime time = DateTime.Now;
        seconds.localRotation = Quaternion.Euler(0f, 0f, time.Second * -secondsToDegrees);
    }
}
