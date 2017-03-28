using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// RocketGameSystem, the main component that holds all the relevant data in the Rocket Game
// in regards to cleared levels, collected cats and others.

public class RocketGameSystem : MonoBehaviour {

	// How many levels has the player cleared?
	int clearedLevels = 10;

	// Chosen level or the point at which player starts from after picking "retry" on game over screen
	int startingLevel = 1;

	// List of the cats that have been collected; true if yes, false if not
	bool[] cats = new bool[10];

	// Has this script's init() function been called?
	bool initialized = false;

	// Is the player playing endless mode or not?
	bool endless = false;

	// Highscore, ie. the highest altitude player has reached
	// This is updated only in the endless mode
	float highscore = 0;

	// Function to initialize the game system state; mostly relevant
	// for checking what cats have been acquired and what haven't
	public void init () {
		if (initialized) {
			return;
		}
		for (int i = 0; i < cats.Length; i++) {
			cats [i] = false;
		}

		initialized = true;
	}

	// Return if cat is collected for a given level
	// Parameter should vary between [0,9] inclusively
	public bool isCatCollected ( int level) {
		return cats[level-1];
	}

	// Mark cat as collected for the given level
	// Parameter should vary between [0,9] inclusively
	public void collectCat ( int level ) {
		Debug.Log ("Cat was collected from level [" + level + "]");
		cats [level - 1] = true;
	}

	// Returns the highest altitude player has achieved
	public float getHighscore () {
		return highscore;
	}

	// Update highscore
	public void setHighscore ( float f ) {
		highscore = Mathf.Clamp ( Mathf.Floor (f), 0f, 99999f);
	}

	// Initialization for when the object is created
	void Start () {
		gameObject.name = "rocketGameSystem";
		DontDestroyOnLoad (gameObject);
	}

	// Set the endless mode to true or false; see RocketGame/scripts/level_select/RocketGameLevelSelect.cs for more details
	public void setEndless(bool b) {
		endless = b;
	}

	// Is gameplay currently in endless mode?
	public bool isEndless() {
		return endless;
	}

	// Set the starting level from which player starts from; level is passed either as a 
	// selection from level select or upon clearing a stage in regular gameplay
	// Special note: endless mode is level 11 (parameter is 10)
	public void setStartingLevel ( int l ) {
		startingLevel = l;
	}

	// Get the level player chose or last checkpoint before game over
	public int getStartingLevel () {
		return startingLevel;
	}

	// Mark a level as cleared by incrementing the value
	public void clearLevel ( int cleared ) {
		// If cleared level is higher than previous maximum, update the value
		if (clearedLevels < cleared) {
			clearedLevels = cleared;
		}

		// Set checkpoint if player dies during non-endless mode gameplay
		setStartingLevel (cleared);
	}

	// Return what levels have been cleared
	public int getClearedLevels ( ) {
		return clearedLevels;
	}

	// Function to call when player wants to exit the minigame
	public void exit () {
		// Saving cleared levels, collected cats, and other details would go here
		MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuCancel, 1);
		Destroy(gameObject);
		SceneManager.LoadScene ("Overworld", LoadSceneMode.Single);
	}
}
