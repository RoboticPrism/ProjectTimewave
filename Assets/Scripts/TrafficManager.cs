using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrafficManager : MonoBehaviour, TimeReceiver {

    public GameObject GenericCarPrefab;
    public GameObject GenericTruckPrefab;
    public List<float> lanes;
    public List<float> directions;
    public List<Vector2> pauseTimes;

    public int percentChanceOfCarSpawnPerSecond;

    private int pauseIndexes;
    private int limit = 100;
    private int carCount = 0;
    private int lastLane = -1;

    // Use this for initialization
    void Start()
    {
        TimeManager.getInstance().addTimeReceiver(this);
        pauseIndexes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool isPaused(float timeReceived)
    {
        if (pauseTimes != null && pauseTimes.Count > 0 && pauseIndexes < pauseTimes.Count)
        {
            if (timeReceived > pauseTimes[pauseIndexes].x)
            {
                if (timeReceived < pauseTimes[pauseIndexes].y)
                {
                    return true;
                }
                else
                {
                    pauseIndexes++;
                    return isPaused(timeReceived);
                }
            }
        }
        return false;
    }

    public void receiveTime(float timeReceived)
    {
        if (carCount >= limit) return;
        if (isPaused(timeReceived))
        {
            return;
        }
        if (UnityEngine.Random.Range(0, 100) > percentChanceOfCarSpawnPerSecond) return;
        int lane = UnityEngine.Random.Range(0, lanes.Count);
        if (lastLane == lane) lane = (lane + 1) % lanes.Count;
        bool truck = UnityEngine.Random.Range(0, 2) == 1;
        GameObject car = (GameObject)Instantiate(truck ? GenericTruckPrefab : GenericCarPrefab, new Vector2(1.735f + 27.695f * directions[lane]*-1f, lanes[lane]), Quaternion.identity);
        TimedAction timedAction = car.transform.GetComponentInChildren<TimedAction>();
        timedAction.activateOn = (int)timeReceived + 1;
        MoveAction moveAction = car.transform.GetComponentInChildren<MoveAction>();
        moveAction.targetLocation = new Vector2(50f * directions[lane], lanes[lane]);
        if (directions[lane] < 0)
        {
            car.transform.GetComponent<SpriteRenderer>().flipX = !car.transform.GetComponent<SpriteRenderer>().flipX;
            if (!truck)
            {
                car.transform.GetChild(0).transform.GetComponent<SpriteRenderer>().flipX = !car.transform.GetChild(0).transform.GetComponent<SpriteRenderer>().flipX;
                car.transform.GetChild(0).transform.position = new Vector2(-1 + car.transform.position.x, car.transform.position.y);
            }
        }
        carCount++;
    }
}
