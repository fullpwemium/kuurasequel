using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketGameSystem : MonoBehaviour {

	int clearedLevels = 10;
	int startingLevel = 1;
	bool[] cats = new bool[10];
	bool initialized = false;
	bool endless = false;
	float highscore = 0;

	public void init () {
		if (initialized) {
			return;
		}
		for (int i = 0; i < cats.Length; i++) {
			cats [i] = false;
		}

		initialized = true;
	}

	public bool isCatCollected ( int level) {
		return cats[level-1];
	}

	public void collectCat ( int level ) {
		Debug.Log ("Cat was collected from level [" + level + "]");
		cats [level - 1] = true;
	}

	public float getHighscore () {
		return highscore;
	}

	public void setHighscore ( float f ) {
		highscore = Mathf.Clamp ( Mathf.Floor (f), 0f, 99999f);
	}

	// Use this for initialization
	void Start () {
		gameObject.name = "rocketGameSystem";
		DontDestroyOnLoad (gameObject);
	}

	public void setStartingLevel ( int l ) {
		startingLevel = l;
	}

	public void setEndless(bool b) {
		endless = b;
	}

	public bool isEndless() {
		return endless;
	}

	public int getStartingLevel () {
		return startingLevel;
	}

	public void clearLevel ( int cleared ) {
		if (clearedLevels < cleared) {
			clearedLevels = cleared;
		}

		setStartingLevel (cleared);
	}

	public int getClearedLevels ( ) {
		return clearedLevels;
	}

	public void exit () {
		// ...
		Destroy(gameObject);
	}
}
