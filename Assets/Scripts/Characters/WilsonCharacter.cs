using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WilsonCharacter : Character {

	// Use this for initialization
	void Start () {
        base.Start();
        timeline.SetUpTimeline(this);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<KillerCarCharacter>())
        {
            Kill(Instantiate(textActionPrefab).SetUp(this, new Vector3(0, 1, 0), "BLRGRGgggg....", TextObject.typeSpeed.INSTANT, 40, 3));
        }
    }
}
