using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketGameSystem : MonoBehaviour {

	int clearedLevels = 1;
	int startingLevel = 1;

	// Use this for initialization
	void Start () {
		gameObject.name = "rocketGameSystem";
		DontDestroyOnLoad (gameObject);
	}

	public void setStartingLevel ( int l ) {
		startingLevel = l;
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
