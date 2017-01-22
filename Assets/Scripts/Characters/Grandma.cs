using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grandma : Character {

	private bool triggered = false;

	void Start() {
		base.Start();
	}

	IEnumerator OnTriggerEnter2D(Collider2D other) {
		if (!this.triggered) {
			this.triggered = true;
			int textSize = 20;
			string text1 = "Why don't you ever call anymore???";
			string text2 = "Come on, I don't bite. ";
			string text3 = "You little young whipper snappers";
			string text4 = "get to go out and have fun";
			string text5 = "but I'm too old for that shit.";
			string text6 = "If I went out and had any fun";
			string text7 = "I would just fall apart...";
			string text8 = "I'm so lonely here.";
			string text9 = "I'll just spend my days";
			string text10 = "aimlessly wondering around";
			string text11 = " until I drop dead.";
			string text12 = "I can't wait.";
			Instantiate (textActionPrefab).SetUp (this, new Vector3 (1, 1, 0), text1, TextObject.typeSpeed.SLOW, textSize, 4).DoAction ();
			yield return new WaitForSeconds (4);
			Instantiate (textActionPrefab).SetUp (this, new Vector3 (1, 1, 0), text2, TextObject.typeSpeed.SLOW, textSize, 4).DoAction ();
			yield return new WaitForSeconds (4);
			Instantiate (textActionPrefab).SetUp (this, new Vector3 (1, 1, 0), text3, TextObject.typeSpeed.SLOW, textSize, 4).DoAction ();
			yield return new WaitForSeconds (4);
			Instantiate (textActionPrefab).SetUp (this, new Vector3 (1, 1, 0), text4, TextObject.typeSpeed.SLOW, textSize, 4).DoAction ();
			yield return new WaitForSeconds (4);
			Instantiate (textActionPrefab).SetUp (this, new Vector3 (1, 1, 0), text5, TextObject.typeSpeed.SLOW, textSize, 4).DoAction ();
			yield return new WaitForSeconds (4);
			Instantiate (textActionPrefab).SetUp (this, new Vector3 (1, 1, 0), text6, TextObject.typeSpeed.SLOW, textSize, 4).DoAction ();
			yield return new WaitForSeconds (4);
			Instantiate (textActionPrefab).SetUp (this, new Vector3 (1, 1, 0), text7, TextObject.typeSpeed.SLOW, textSize, 4).DoAction ();
			yield return new WaitForSeconds (4);
			Instantiate (textActionPrefab).SetUp (this, new Vector3 (1, 1, 0), text8, TextObject.typeSpeed.SLOW, textSize, 4).DoAction ();
			yield return new WaitForSeconds (4);
			Instantiate (textActionPrefab).SetUp (this, new Vector3 (1, 1, 0), text9, TextObject.typeSpeed.SLOW, textSize, 4).DoAction ();
			yield return new WaitForSeconds (4);
			Instantiate (textActionPrefab).SetUp (this, new Vector3 (1, 1, 0), text10, TextObject.typeSpeed.SLOW, textSize, 4).DoAction ();
			yield return new WaitForSeconds (4);
			Instantiate (textActionPrefab).SetUp (this, new Vector3 (1, 1, 0), text11, TextObject.typeSpeed.SLOW, textSize, 4).DoAction ();
			yield return new WaitForSeconds (4);
			Instantiate (textActionPrefab).SetUp (this, new Vector3 (1, 1, 0), text12, TextObject.typeSpeed.SLOW, textSize, 4).DoAction ();
			yield return new WaitForSeconds (4);
			this.triggered = false;
		}
	}
}
	