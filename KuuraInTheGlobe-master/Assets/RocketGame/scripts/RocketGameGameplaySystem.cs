using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

// RocketGameGameplaySystem, a script that handles the general behavior of the game
// by spawning player, obstacles and background items, as well as activating the game
// over and pause screens if necessary.

public class RocketGameGameplaySystem : MonoBehaviour {

	// Public prefabs
	public GameObject playerPrefab;
	public GameObject PauseScreen;
	public GameObject PauseButton;
	public GameObject catCollectedMarker;
	public GameObject levelIndicator;
	public List<GameObject> spawnableObjects;
	public List<GameObject> backgroundObjects;
	public GameObject catObject;
	public List<TextAsset> levels;
	public GameObject systemPrefab;

	// Is the game paused?
	public bool paused = false;


	Transform fuelMeter;
	Transform damagedFuelMeter;
	Transform altitudeMeter;

	Text altitudeMeterText;
	Transform speedoMeter;
	SpriteRenderer fullAltitudeMeter;

	Transform MainCanvas;

	// Timer for spawning obstacles
	float timer;
	float backgroundObjectTimer = 0f;

	//Spawnable and spawned objects list
	List<int> spawnProbabilities;
	List<ObjectScript> spawnedObjects;
	List<ObjectScript> spawnedBackgroundObjects;


	// Player game object we instantiate at startup
	RocketPlayerScript player;

	// Is player playing the game?
	bool playing = false;
	RocketGameCountdown countdown;
	//Is the game over?
	bool isGameOver;

	float damagedFuelDecrement = 2f;

	// Level data
	RocketGameLevelData level;
	int currentLevel = 1;

	//System object
	RocketGameSystem system;

	// Game Over
	RocketGameGameOverScript GO;

	// Fuel related variables
	int guaranteedFuelDrop = 0;
	float fuelWarnTimer = 0f; // Timer that handles the red flashing of the fuel bar when it gets too low
	SpriteRenderer fuelMeterFG; 

	// Pausing variables for the pause screen implementation
	bool canPause = false;

	// Background object's renderer
	Image bg;
	Transform bgCanvas;

	//Foreground object's renderer
	Transform UICanvas;

	// Use this for initialization
	void Start () {

		// Fetch system object
		if (!GameObject.Find ("rocketGameSystem")) {
			system = GameObject.Instantiate (systemPrefab).GetComponent<RocketGameSystem> ();
			system.init ();
		} else {
			system = GameObject.Find ("rocketGameSystem").GetComponent<RocketGameSystem> ();
		}

		GO = GetComponent<RocketGameGameOverScript> ();
		countdown = GetComponent<RocketGameCountdown> ();

		// Get starting level
		currentLevel = system.getStartingLevel ();

		// Get HUD objects
		fuelMeter = GameObject.Find ("UICanvas/fuelMeter/currentFuel").GetComponent<Transform> ();
		damagedFuelMeter = GameObject.Find ("UICanvas/fuelMeter/damagedFuel").GetComponent<Transform> ();
		altitudeMeter = GameObject.Find ("UICanvas/altitudeMeter/currentAltitude").GetComponent<Transform> ();
		altitudeMeterText = GameObject.Find ("UICanvas/altitudeMeter/textObjects/text/altitude").GetComponent<Text> ();
		speedoMeter = GameObject.Find ("UICanvas/altitudeMeter/textObjects/arrow").GetComponent<Transform> ();
		fuelMeterFG = GameObject.Find ("UICanvas/fuelMeter/fg_graphic").GetComponent<SpriteRenderer> ();

		fullAltitudeMeter = GameObject.Find ("UICanvas/altitudeMeter/fullAltitude").GetComponent<SpriteRenderer> ();

		bg = GameObject.Find ("BG_Canvas/BG").GetComponent<Image> ();

		unpause ();

		if (system.isEndless ()) {
			enableEndlessMode ();
		}

		//Init spawnable list
		spawnedObjects = new List<ObjectScript> ();
		spawnedBackgroundObjects = new List<ObjectScript> ();

		UICanvas = GameObject.Find ("UICanvas").GetComponent<Transform> ();
		MainCanvas = GameObject.Find ("MainCanvas").GetComponent<Transform> ();
		bgCanvas = GameObject.Find ("BG_Canvas").GetComponent<Transform> ();

		// START THE GAME
		gameStart ();

	}

	void pauseGame() {
		if (canPause && !paused) {
			MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuEffect, 1);
			paused = !paused; //flip the boolean
			player.pause (paused);
			Destroy (GameObject.Find ("UICanvas/fuelMeter/rg_pause(Clone)"));
			GameObject obj = Instantiate (PauseScreen);
			obj.transform.SetParent (GameObject.Find("GameOverCanvas").GetComponent<Transform>(), false);
		}

		// Release the button so it does not appear "held"
		EventSystem.current.SetSelectedGameObject (null);
	}

	public void unpause() {
		EventSystem.current.SetSelectedGameObject (null);
		Transform pauseButCanvas = GameObject.Find ("UICanvas/fuelMeter").GetComponent<Transform> ();
		GameObject obj = Instantiate (PauseButton);
		obj.GetComponent<Button> ().onClick.AddListener ( delegate { this.pauseGame(); } );
		obj.transform.SetParent ( pauseButCanvas, false );
		if (player != null) {
			player.pause (false);
		}
		paused = false;
	}

	// float to int, or more accurately take a decimal percentage and turn it into integer percentage
	// a helper function for using populateSpawnList(), which is used during loadLevel()
	int fti ( float fl ) {
		return (int)Mathf.Floor (fl * 100);
	}

	// Function to add a given object N amount of times to the spawnProbabilities list.
	// This gives things a pseudo-percentage based method to see what object to spawn,
	// as we randomize between [0,spawnProbablities.Count], and pick the object that
	// index refers to. There is no hard limit on the size of the list, and it's not
	// all that necessary.
	void populateSpawnList ( int amount, int objIndex ) {
		if (amount == 0) {
			return;
		}
		for (int i = 0; i < amount; i++) {
			spawnProbabilities.Add (objIndex);
		}
	}

	void loadLevel (int levelToBeLoaded) {

		// If we're starting from a level that is not [1] or we're not playing endless mode,
		// get the target altitude from previous level, which will work as the current level's
		// starting altitude.
		float start = 0f;
		if (levelToBeLoaded > 1 && levelToBeLoaded < 11) {
			RocketGameLevelData plevel = JsonUtility.FromJson<RocketGameLevelData> (levels [levelToBeLoaded - 2].text);
			start = plevel.targetAltitude;
		}

		// Load level's json data
		level = JsonUtility.FromJson<RocketGameLevelData> (levels [levelToBeLoaded - 1].text);
		level.startAltitude = start;

		// Set spawn rate
		timer = 2.35f;

		// Little pseudo percentage based way to set what objects are spawned and how often
		spawnProbabilities = new List<int> ();
		populateSpawnList (fti (level.spawnFuel), 0);
		populateSpawnList (fti (level.spawnBadCloud), 1);
		populateSpawnList (fti (level.spawnSnow), 2);
		populateSpawnList (fti (level.spawnLava), 3);
		populateSpawnList (fti (level.spawnPoison), 4);
		populateSpawnList (fti (level.spawnVenom), 5);
		populateSpawnList (fti (level.spawnEvil), 6);


		// Update player's altitude
		player.initAltitude (start);

		// Update the altitude counter
		updateAltitude (start, 0f);

	}

	public int getCurrentLevel () {
		return currentLevel;
	}

	void gotoNextLevel () {
		MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.keyCollected, 1);
		if (!system.isCatCollected (currentLevel)) {
			spawnCat (currentLevel);
		}

		if (currentLevel <= 10) {
			currentLevel += 1;
		}

		GameObject obj = Instantiate (levelIndicator);
		obj.transform.SetParent (UICanvas, false);

		system.clearLevel (currentLevel);
		if (currentLevel < 11) {
			loadLevel (currentLevel);
		} else {
			Debug.Log ("You are winrar");
		}
	}

	public int getStartingLevel () {
		return system.getStartingLevel ();
	}

	public void markCatCollected ( ObjectScript cat ) {
		Transform t = Instantiate (catCollectedMarker).GetComponent<Transform>();
		t.SetParent (UICanvas, false);
		t.localPosition = new Vector3 (cat.transform.localPosition.x + 5f, -22.0f , cat.transform.localPosition.z);
		system.collectCat ( cat.getCatLevel() );
	}

	void enableEndlessMode() {
		Destroy (GameObject.Find ("UICanvas/altitudeMeter/fullAltitude"));
		Destroy (GameObject.Find ("UICanvas/altitudeMeter/currentAltitude"));
		Destroy (GameObject.Find ("UICanvas/altitudeMeter/fg_Graphic"));
		Destroy (GameObject.Find ("UICanvas/altitudeMeter/bg_Graphic"));
		GameObject.Find ("UICanvas/altitudeMeter/textObjects").transform.localPosition = new Vector3 (-0.6f, 0f, 0f);

	}

	public void gameStart() {
		MusicPlayer.PlayMusic (MusicTrack.WinterForestMarathon);
		destroyObjects ();
		player = Instantiate (playerPrefab, new Vector3 (0, -340, 0), Quaternion.identity).GetComponent<RocketPlayerScript> ();
		player.transform.SetParent (MainCanvas, false);
		player.togglePlayable ();
		isGameOver = false;
		playing = false;
		loadLevel (system.getStartingLevel());
		randomizeBackgroundObjects ();
		countdown.init();
		guaranteedFuelDrop = 0;
		updateFuel (1f);
	}

	public void gameOver( float result ) {
		isGameOver = true;

		bool newEndlessHighScore = false;
		if (system.isEndless()) {
			if (result > system.getHighscore()) {
				system.setHighscore (result);
				newEndlessHighScore = true;
			}
		}

		GO.init ( result, newEndlessHighScore );
	}

	public void retry ( ) {
		// Restart the level from last checkpoint
		gameStart ();
		if (getStartingAltitude () != 0f) {
			currentAltitudeValue = -1f;
		} else {
			currentAltitudeValue = 0f;
		}
		updateAltitudeText ( getStartingAltitude() );


	}

	public void gotoLevelSelect () {
		SceneManager.LoadScene ("_rocketGameLevelSelect", LoadSceneMode.Single);
	}

	public void exit () {
		system.exit ();
	}

	// Update is called once per frame
	void Update () {

		if (paused) {
			return;
		}

		if (!playing) {
			updateAltitude (level.startAltitude, 0f);
			//updateBackgroundColor (0f);
			playing = countdown.checkIfFinished ();
		} else {
			if (!isGameOver) {
				canPause = true;
				player.updatePlayer ();
				checkSpawn ();
				updateSpawnedObjects ();
			} else {
				canPause = false;
			}
		}
	}

	void checkSpawn() {

		timer -= Time.fixedDeltaTime;

		if (timer <= 0) {

			int objID = Random.Range (0, spawnProbabilities.Count-1);
			objID = spawnProbabilities [objID];

			if(objID != 1) {// fuel
				if (guaranteedFuelDrop >= level.spawnFuelEvery) {
					spawnObject (0);	
					guaranteedFuelDrop = 0;
				} else {
					guaranteedFuelDrop++;
				}
			} 

			spawnObject (objID);
		}

		// Check random bg object spawn
		backgroundObjectTimer -= Time.fixedDeltaTime;
		if (backgroundObjectTimer  <= 0f) {
			backgroundObjectTimer =  Random.Range (level.bgSpawnMin, level.bgSpawnMax);
			spawnBackgroundObject (500f);
		}
	}

	int RandomSign()  {
		return Random.value < .5 ? 1 : -1;
	}

	float lastSpawnPosition = -1000f;
	float lastFuelSpawnPosition = -1000f;
	void spawnObject(int objID ) {
		float spawnPosition = Random.Range (-240f, 240f);

		// Try to relocate a spawned fuel cloud so that it hopefully doesn't overlap with
		// an obstacle. However, no rechecks are made if an obstacle spawns on top of a fuel
		// AFTER the fuel has been spawned.
		if (lastSpawnPosition != -1000f) {
			if (objID == 1) {
				if (spawnPosition > lastSpawnPosition - 50f &&
				    spawnPosition < lastSpawnPosition + 50f) {
					spawnPosition = spawnPosition - Random.Range (100f, 300f);
					if (spawnPosition < -240f) {
						spawnPosition = 240f - (Mathf.Abs (spawnPosition) - 240f);
					}
				}
				lastFuelSpawnPosition = spawnPosition;
			}
		}

		// Modify object spawn location so that it ideally wouldn't spawn on top of a 
		// fuel collectable if it spawns after one.
		if (lastFuelSpawnPosition != -1000f) {
			if (objID != 1) {
				if (spawnPosition > lastFuelSpawnPosition  - 50f &&
					spawnPosition < lastFuelSpawnPosition  + 50f) {
					spawnPosition = spawnPosition - Random.Range (100f, 300f);
					if (spawnPosition < -240f) {
						spawnPosition = 240f - (Mathf.Abs (spawnPosition) - 240f);
					}
					lastFuelSpawnPosition = -1000f; //Allow next obstacle to spawn in the fuel's last position
				}
			}
		}

		lastSpawnPosition = spawnPosition;

		ObjectScript obj = Instantiate (
			spawnableObjects [objID],
			new Vector3 (spawnPosition, 500, Random.Range(33, 99)),
			Quaternion.identity
		).GetComponent<ObjectScript> ();
		spawnedObjects.Add (obj);
		obj.gameObject.transform.SetParent (MainCanvas, false);
		timer = Random.Range (level.spawnMin, level.spawnMax);

		// Randomize object's size
		float randSize = Random.Range (obj.gameObject.transform.localScale.x * 0.8f, obj.gameObject.transform.localScale.x * 1.2f);
		obj.gameObject.transform.localScale = new Vector3 (randSize * RandomSign(), randSize, 1f); 
	}

	void randomizeBackgroundObjects() {
		for (int i = -280; i < 400; i += 10) {
			// Magic schmagick numbers
			if (Random.Range (0, 1001) >= 900) {
				spawnBackgroundObject ((float)i);
			}
		}
	}

	void spawnBackgroundObject (float yPos) {
		int objID = Random.Range (level.bgObjectMin, level.bgObjectMax + 1);
		ObjectScript obj = Instantiate (
			backgroundObjects [objID],
			new Vector3 (Random.Range (-300f, 300f), yPos, Random.Range(33,99)),
			Quaternion.identity
		).GetComponent<ObjectScript> ();
		spawnedBackgroundObjects.Add (obj);
		obj.gameObject.transform.SetParent (bgCanvas, false);

		// Randomize background object's size
		float randSize = Random.Range (obj.gameObject.transform.localScale.x, obj.gameObject.transform.localScale.x * 2.4f);
		obj.gameObject.transform.localScale = new Vector3 (randSize * RandomSign(), randSize, 1f); 
	}

	void spawnCat ( int level ) {
		ObjectScript cat = Instantiate (
			                   catObject,
			                   new Vector3 (Random.Range (-240f, 240f), 500, 20),
			                   Quaternion.identity
		                   ).GetComponent<ObjectScript> ();
		spawnedObjects.Add (cat);
		cat.gameObject.transform.SetParent (MainCanvas, false);

		cat.markCat (level);
	}

	void updateSpawnedObjects() {
		// Game items
		for (int i = spawnedObjects.Count -1; i >= 0; i--) {
			spawnedObjects[i].move ();
			if (spawnedObjects[i].setToDestroy) {
				Destroy (spawnedObjects [i].gameObject);
				spawnedObjects.RemoveAt (i);
			}
		}
		// BG objs
		for (int i = spawnedBackgroundObjects.Count - 1; i >= 0; i--) {
			spawnedBackgroundObjects[i].move ();
			if (spawnedBackgroundObjects[i].setToDestroy) {
				Destroy (spawnedBackgroundObjects [i].gameObject);
				spawnedBackgroundObjects.RemoveAt (i);
			}
		}
	}

	void destroyObjects () {
		while (spawnedObjects.Count > 0) {
			Destroy (spawnedObjects [0].gameObject);
			spawnedObjects.RemoveAt (0);
		}

		while (spawnedBackgroundObjects.Count > 0) {
			Destroy (spawnedBackgroundObjects [0].gameObject);
			spawnedBackgroundObjects.RemoveAt (0);
		}
	}

	public void removeSpawnedObject (int ID) {
		Destroy (spawnedObjects [ID - 1].gameObject);
		spawnedObjects.RemoveAt(ID-1);
	}

	public float getStartingAltitude() {
		return level.startAltitude;
	}
		
	public void updateAltitude ( float current, float speed ) {

		if (current >= level.targetAltitude && currentLevel <= 10) {
			fullAltitudeMeter.color = new Color (1, 1, 1, 1);
			gotoNextLevel ();
			return;
		}

		if (currentLevel <= 10) {
			Color col = fullAltitudeMeter.color;
			if (col.a > 0f) {
				fullAltitudeMeter.color = new Color (1, 1, 1, col.a - Time.fixedDeltaTime);
			}
		}

		if (!system.isEndless()) {
			float scl = (current - level.startAltitude) / (level.targetAltitude - level.startAltitude);
			altitudeMeter.localScale = new Vector3 (1, Mathf.Clamp (scl, 0, 1), 1);
			updateBackgroundColor (scl);
		}
		updateAltitudeText (current);
		updateSpeedoMeter (speed);
	}

	float currentAltitudeValue = -1f;
	float altText_spd = 11.125f;
	void updateAltitudeText ( float current ) {
		if (!playing) {
			if (currentAltitudeValue != current) {
				altText_spd += current / 60;
				Vector2 v = Vector2.MoveTowards (new Vector2 (currentAltitudeValue, 0), new Vector2 (current, 0), altText_spd);
				altitudeMeterText.text = Mathf.Floor (Mathf.Floor (v.x)) + "m";
				if (v.x == current) {
					altText_spd = 0f;
					currentAltitudeValue = current;
				}
			} else {
				altitudeMeterText.text = Mathf.Floor (current) + "m";
				if (currentAltitudeValue != 0f) {
					if (altText_spd < Mathf.PI) {
						altText_spd += Time.fixedDeltaTime * 10;
						altitudeMeterText.transform.localPosition = new Vector3 (-6.27f, 2.25f + Mathf.Sin (altText_spd) / 18f, 1.8f);
					} else {
						altitudeMeterText.transform.localPosition = new Vector3 (-6.27f, 2.25f, 1.8f);
					}
				}
			}
		} else {
			altitudeMeterText.text = Mathf.Floor (current) + "m";
		}
	}

	const float H_Const = 255f / 359f;
	const float S_Const = 119f / 255f;
	const float V_Const = 174f / 255f;
	void updateBackgroundColor ( float levelProgress ) {
		levelProgress = ((float)currentLevel / 10f) -0.1f + (levelProgress/100f); //levelProgress;

		// Apparently RGBToHSV uses pass-by-reference to get around multiple return values
		// and/or not having to make a HSV construct or class. Sneaky sneak, Unity team.
		float aH, aS, aV;
		Color col = bg.color;
		Color.RGBToHSV (col, out aH, out aS, out aV);

		Vector2 v = new Vector2 ( aS, aV );
		Vector2 t = new Vector2 ( S_Const * levelProgress, 1f - V_Const * levelProgress);
		// x == S => S_Const * levelProgress;
		// y == V => 1f - V_Const * levelProgress;

		// Seek darker skies over time
		v = Vector2.MoveTowards (v, t, Time.fixedDeltaTime);

		Color finalCol = Color.HSVToRGB (H_Const, v.x, v.y );;
		bg.color = finalCol;

		for ( int i = spawnedBackgroundObjects.Count -1; i >= 0; i--) {
			if (spawnedBackgroundObjects [i].gameObject.tag != "star") {
				SpriteRenderer r = spawnedBackgroundObjects [i].transform.FindChild ("graphic").GetComponent<SpriteRenderer> ();
				r.color = finalCol;
			}
		}
	}

	float speedoMeterBouncer;
	float speedoMeterVariance;
	void updateSpeedoMeter ( float speed ) {
		speed = speed / 0.125f;
		if (Mathf.Floor (speed) == 1) {
			speedoMeterBouncer += 0.075f;
			speedoMeter.eulerAngles = new Vector3 ( 0, 0, speed * 90 - Mathf.Sin(speedoMeterBouncer)*2  );
		} else {
			speedoMeterBouncer = 0f;
			speedoMeter.eulerAngles = new Vector3 ( 0, 0, speed * 90  );
		}
	}

	public void updateFuel ( float current ) {

		if (current < 0.11f) {
			fuelWarning ();
		} else {
			fuelMeterFG.color = new Color (1.0f, 1.0f, 1.0f, 1f);
			fuelWarnTimer = 0f;
		}

		fuelMeter.localScale = new Vector3 (1, current, 1);

		if (damagedFuelMeter.localScale.y > 0f) {
			if (damagedFuelDecrement < 0f) {
				float cur = damagedFuelMeter.localScale.y - (damagedFuelMeter.localScale.y - current) /4;

				if (cur < current + 0.005f) {
					cur = 0f;
				}

				damagedFuelMeter.localScale = new Vector3 ( 0.98f, cur, 1);
			} else {
				damagedFuelDecrement -= 0.05f;
			}
		}
	}

	void fuelWarning () {
		fuelWarnTimer += 0.2f;
		float blink = (Mathf.Sin ((fuelWarnTimer) * Mathf.PI / 2) + 1) / 4;
		fuelMeterFG.color = new Color (1.0f, 0.5f+blink, 0.5f+blink, 1f);
	}

	public void setDamagedFuelPosition ( float current ) {
		damagedFuelMeter.localScale = new Vector3 (0.98f, current, 1);
		damagedFuelDecrement = 2f;
	}

}