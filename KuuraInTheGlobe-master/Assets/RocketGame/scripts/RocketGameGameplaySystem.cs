using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class RocketGameGameplaySystem : MonoBehaviour {

	public GameObject playerPrefab;
	public GameObject PauseScreen;
	public GameObject PauseButton;

	Transform fuelMeter;
	Transform damagedFuelMeter;
	Transform altitudeMeter;

	Text altitudeMeterText;
	Transform speedoMeter;

	Transform MainCanvas;


	// Timer for spawning obstacles
	float timer;

	//Spawnable and spawned objects list
	List<int> spawnProbabilities;
	List<ObjectScript> spawnedObjects;
	public List<GameObject> spawnableObjects;
	public GameObject catObject;

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
	public List<TextAsset> levels;
	int currentLevel = 1;

	//System object
	public GameObject systemPrefab;
	RocketGameSystem system;

	// Game Over
	RocketGameGameOverScript GO;

	int guaranteedFuelDrop = 0;
	float fuelWarnTimer = 0f;
	SpriteRenderer fuelMeterFG;

	bool canPause = false;
	public bool paused = false;

	// Use this for initialization
	void Start () {

		// Fetch system object
		if (!GameObject.Find ("rocketGameSystem")) {
			system = GameObject.Instantiate (systemPrefab).GetComponent<RocketGameSystem> ();
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

		unpause ();

		//Init spawnable list
		spawnedObjects = new List<ObjectScript> ();

		MainCanvas = GameObject.Find ("MainCanvas").GetComponent<Transform> ();
		// START
		gameStart ();

	}

	void pauseGame() {
		if (canPause && !paused) {
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

	//float to int, or more accurately take a decimal percentage and turn it into integer percentage
	int fti ( float fl ) {
		return (int)Mathf.Floor (fl * 100);
	}

	void populateSpawnList ( int amount, int objIndex ) {
		if (amount == 0) {
			return;
		}
		for (int i = 0; i < amount; i++) {
			spawnProbabilities.Add (objIndex);
		}
	}

	void loadLevel (int levelToBeLoaded) {

		float start = 0f;
		if (levelToBeLoaded > 1) {
			RocketGameLevelData plevel = JsonUtility.FromJson<RocketGameLevelData> (levels [levelToBeLoaded - 2].text);
			start = plevel.targetAltitude;
		}

		// Load level's json data
		level = JsonUtility.FromJson<RocketGameLevelData> (levels [levelToBeLoaded - 1].text);
		level.startAltitude = start;

		// Set spawn rate
		timer = 2.35f;

		// Little hack-ish way to set what objects are spawned and how often
		spawnProbabilities = new List<int> ();
		populateSpawnList (fti (level.spawnBadCloud), 0);
		populateSpawnList (fti (level.spawnFuel), 1);

		player.initAltitude (start);
		updateAltitude (start, 0f);

	}

	void gotoNextLevel () {
		if (currentLevel <= 10) {
			currentLevel += 1;
		}
		//system.clearLevel (currentLevel);
		if (currentLevel < 11) {
			loadLevel (currentLevel);
		} else {
			Debug.Log ("You are winrar");
		}
		spawnCat ();
	}

	public int getStartingLevel () {
		return system.getStartingLevel ();
	}

	public void markClearedLevel () {
		system.clearLevel (currentLevel);
		Debug.Log ("Marked check point: " + currentLevel);
	}

	public void gameStart() {
		destroyObjects ();
		player = Instantiate (playerPrefab, new Vector3 (0, -340, 0), Quaternion.identity).GetComponent<RocketPlayerScript> ();
		player.transform.SetParent (MainCanvas, false);
		player.togglePlayable ();
		isGameOver = false;
		playing = false;
		loadLevel (system.getStartingLevel());
		countdown.init();
		guaranteedFuelDrop = 0;
		updateFuel (1f);
	}

	public void gameOver() {
		isGameOver = true;
		GO.init ();
	}

	public void retry ( ) {
		// Restart the level from last checkpoint
		gameStart ();
	}

	public void gotoLevelSelect () {
		SceneManager.LoadScene ("_rocketGameLevelSelect", LoadSceneMode.Single);
	}

	public void exit () {
		system.exit ();
		SceneManager.LoadScene ("Map2", LoadSceneMode.Single);;
	}

	// Update is called once per frame
	void Update () {

		if (paused) {
			return;
		}

		if (!playing) {
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
				if (guaranteedFuelDrop >= 3) {
					spawnObject (1);	
					guaranteedFuelDrop = 0;
				} else {
					guaranteedFuelDrop++;
				}
			} 

			spawnObject (objID);
		}
	}

	void spawnObject(int objID ) {
		ObjectScript obj = Instantiate (
			spawnableObjects [objID],
			new Vector3 (Random.Range (-240f, 240f), 500, 30),
			Quaternion.identity
		).GetComponent<ObjectScript> ();
		spawnedObjects.Add (obj);
		obj.gameObject.transform.SetParent (MainCanvas, false);
		timer = Random.Range (level.spawnMin, level.spawnMax);
	}

	void spawnCat () {
		ObjectScript cat = Instantiate (
			                   catObject,
			                   new Vector3 (Random.Range (-240f, 240f), 500, 30),
			                   Quaternion.identity
		                   ).GetComponent<ObjectScript> ();
		spawnedObjects.Add (cat);
		cat.gameObject.transform.SetParent (MainCanvas, false);
	}

	void updateSpawnedObjects() {
		for (int i = spawnedObjects.Count -1; i >= 0; i--) {
			spawnedObjects[i].move ();
			if (spawnedObjects[i].setToDestroy) {
				Destroy (spawnedObjects [i].gameObject);
				spawnedObjects.RemoveAt (i);
			}
		}
	}

	void destroyObjects () {
		while (spawnedObjects.Count > 0) {
			Destroy (spawnedObjects [0].gameObject);
			spawnedObjects.RemoveAt (0);
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
		if (current >= level.targetAltitude) {
			//Debug.Log (current + " : " + level.targetAltitude);
			gotoNextLevel ();
			Debug.Log (level.startAltitude);
			return;
		}
		float scl = (current-level.startAltitude) / (level.targetAltitude-level.startAltitude);

		altitudeMeter.localScale = new Vector3 (1, Mathf.Clamp (scl, 0, 1), 1);
		altitudeMeterText.text = Mathf.Floor (current) + "m";
		speedoMeter.eulerAngles = new Vector3 ( 0, 0, speed/0.125f * 90 );
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