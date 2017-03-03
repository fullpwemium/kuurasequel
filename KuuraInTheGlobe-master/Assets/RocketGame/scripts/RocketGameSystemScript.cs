using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RocketGameSystemScript : MonoBehaviour {

	public GameObject playerPrefab;
	public Button retryButton;
	public GameObject gameOverScreen;


	Transform fuelMeter;
	Transform damagedFuelMeter;
	Transform altitudeMeter;

	Transform MainCanvas;

	Text altitudeMeterText;
	Text speedoMeterText;


	// Timer for spawning obstacles
	float timer;

	//Spawnable and spawned objects list
	List<int> spawnProbabilities;
	List<ObjectScript> spawnedObjects;
	public List<GameObject> spawnableObjects;

	// Player game object we instantiate at startup
	RocketPlayerScript player;

	// Is player playing the game?
	bool playing;

	float damagedFuelDecrement = 2f;

	//Is the game over?
	bool isGameOver;

	// Level data
	RocketGameLevelScript level;
	public List<TextAsset> levels;
	RocketGameLevelSelect levelSelectObject;
	int currentLevel = 1;

	// Use this for initialization
	void Start () {

		// Get starting level
		levelSelectObject = GameObject.Find ("levelSelectSystem").GetComponent<RocketGameLevelSelect> ();
		currentLevel = levelSelectObject.getSelectedLevel ();

		// Get HUD objects
		fuelMeter = GameObject.Find ("fuelMeter/currentFuel").GetComponent<Transform> ();
		damagedFuelMeter = GameObject.Find ("fuelMeter/damagedFuel").GetComponent<Transform> ();
		altitudeMeter = GameObject.Find ("altitudeMeter/currentAltitude").GetComponent<Transform> ();
		altitudeMeterText = GameObject.Find ("altitudeMeter/altitudeCanvas/altitudeText").GetComponent<Text> ();
		speedoMeterText = GameObject.Find ("altitudeMeter/altitudeCanvas/speedText").GetComponent<Text> ();

		MainCanvas = GameObject.Find ("MainCanvas").GetComponent<Transform> ();

		//Init spawnable list
		spawnedObjects = new List<ObjectScript> ();

		// START
		gameStart ();

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
			RocketGameLevelScript plevel = JsonUtility.FromJson<RocketGameLevelScript> (levels [levelToBeLoaded - 2].text);
			start = plevel.targetAltitude;
		}

		// Load level's json data
		level = JsonUtility.FromJson<RocketGameLevelScript> (levels [levelToBeLoaded - 1].text);
		level.startAltitude = start;

		// Set spawn rate
		timer  = Random.Range (level.spawnMin, level.spawnMax);

		// Little hack-ish way to set what objects are spawned and how often
		spawnProbabilities = new List<int> ();
		populateSpawnList (fti (level.spawnBadCloud), 0);
		populateSpawnList (fti (level.spawnFuel), 1);
	}

	void gotoNextLevel () {
		if (currentLevel <= 10) {
			currentLevel += 1;
		}
		levelSelectObject.clearLevel (currentLevel);
		if (currentLevel < 11) {
			loadLevel (currentLevel);
		} else {
			Debug.Log ("You are winrar");
		}
	}

	void gameStart() {
		destroyObjects ();
		player = Instantiate (playerPrefab, new Vector3 (0, -6, 0), Quaternion.identity).GetComponent<RocketPlayerScript> ();
		player.togglePlayable ();
		isGameOver = false;
		loadLevel (currentLevel);
		Debug.Log ("Letse goo");
	}

	public void gameOver() {
		Debug.Log ("You is death");
		isGameOver = true;
		List<Button> butList = new List<Button> ();


		Instantiate (gameOverScreen);
		Button rButton = (Button)Instantiate (retryButton);
		rButton.transform.SetParent (MainCanvas, false);
		butList.Add (rButton);



		Button lButton = (Button)Instantiate (retryButton, MainCanvas.transform);
		lButton.transform.SetParent (MainCanvas, false);
		butList.Add (lButton);

		// Create retry button through a delegate function
		rButton.onClick.AddListener ( delegate { this.retryButtonClicked (butList); } );
		// Same for level select
		lButton.onClick.AddListener ( delegate { this.levelSelectButtonClicked (butList); } );
	}

	public void retryButtonClicked (List<Button> list ) {
		// Remove retry button and game over screen
		foreach (Button but in list) {
			Destroy (but.gameObject);
		}

		Destroy (GameObject.Find (gameOverScreen.name + "(Clone)"));

		// Restart the level from last checkpoint
		gameStart ();
	}

	public void levelSelectButtonClicked (List<Button> list ) {
		int c =  levelSelectObject.getClearedLevels();
		Destroy (GameObject.Find ("levelSelectSystem"));
		SceneManager.LoadScene ("_rocketGameLevelSelect", LoadSceneMode.Single);
		levelSelectObject = GameObject.Find ("levelSelectSystem").GetComponent<RocketGameLevelSelect> ();
		levelSelectObject.clearLevel (c);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isGameOver) {
			player.updatePlayer ();
			checkSpawn ();
			updateSpawnedObjects ();
		}
	}
		
	void checkSpawn() {

		timer -= Time.fixedDeltaTime;

		if (timer <= 0) {

			int objID = Random.Range (0, spawnProbabilities.Count-1);
			objID = spawnProbabilities [objID];

			ObjectScript obj = Instantiate (
				                   spawnableObjects [objID],
				                   new Vector3 (Random.Range (-7.5f, 7.5f), 7, 30),
				                   Quaternion.identity
			                   ).GetComponent<ObjectScript> ();
			spawnedObjects.Add (obj);
			timer = Random.Range (level.spawnMin, level.spawnMax);
		}
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
		speedoMeterText.text = Mathf.Clamp ( speed, 0, 10 ) + "m/s";
	}

	public void updateFuel ( float current ) {
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

	public void setDamagedFuelPosition ( float current ) {
		damagedFuelMeter.localScale = new Vector3 (0.98f, current, 1);
		damagedFuelDecrement = 2f;
	}
}
