using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketGameSystemScript : MonoBehaviour {

	public GameObject playerPrefab;
	public Button retryButton;

	Transform fuelMeter;
	Transform damagedFuelMeter;
	Transform altitudeMeter;

	Transform MainCanvas;

	Text altitudeMeterText;
	Text speedoMeterText;


	// Timer for spawning obstacles
	float timer;

	//Spawnable and spawned objects list
	List<ObjectScript> spawnedObjects;
	public List<GameObject> spawnableObjects;

	// Player game object we instantiate at startup
	RocketPlayerScript player;

	// Is player playing the game?
	bool playing;

	//Current level
	float target = 100f;
	float damagedFuelDecrement = 2f;

	//Is the game over?
	bool isGameOver;

	// Use this for initialization
	void Start () {
		//...
		timer = Random.Range (2.0f, 5.0f);

		fuelMeter = GameObject.Find ("fuelMeter/currentFuel").GetComponent<Transform> ();
		damagedFuelMeter = GameObject.Find ("fuelMeter/damagedFuel").GetComponent<Transform> ();
		altitudeMeter = GameObject.Find ("altitudeMeter/currentAltitude").GetComponent<Transform> ();
		altitudeMeterText = GameObject.Find ("altitudeMeter/altitudeCanvas/altitudeText").GetComponent<Text> ();
		speedoMeterText = GameObject.Find ("altitudeMeter/altitudeCanvas/speedText").GetComponent<Text> ();

		MainCanvas = GameObject.Find ("MainCanvas").GetComponent<Transform> ();
		spawnedObjects = new List<ObjectScript> ();

		//Debug.Log ("Screen size: " + Screen.width + ":" + Screen.height);
		gameStart ();
	}

	void gameStart() {
		player = Instantiate (playerPrefab, new Vector3 (0, -6, 0), Quaternion.identity).GetComponent<RocketPlayerScript> ();
		player.togglePlayable ();
		isGameOver = false;
		Debug.Log ("Letse goo");
	}

	public void gameOver() {
		Debug.Log ("You is death");
		Button newButton = (Button)Instantiate (retryButton);
		newButton.transform.SetParent (MainCanvas, false);
		isGameOver = true;

		// Create retry button through a delegate function
		newButton.onClick.AddListener ( delegate { this.retryButtonClicked (newButton); } );
	}

	public void retryButtonClicked (Button but ) {
		// Remove retry button
		Destroy (but.gameObject);
		// Restart
		gameStart ();
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

			ObjectScript obj = Instantiate (
				                   spawnableObjects [Random.Range (0, spawnableObjects.Count)],
				                   new Vector3 (Random.Range (-7.5f, 7.5f), 7, 30),
				                   Quaternion.identity
			                   ).GetComponent<ObjectScript> ();
			spawnedObjects.Add (obj);
			obj.setSystem (this, spawnedObjects.Count);
			timer = Random.Range (2.0f, 5.0f);
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

	public void removeSpawnedObject (int ID) {
		Destroy (spawnedObjects [ID - 1].gameObject);
		spawnedObjects.RemoveAt(ID-1);
	}

	public float getStartingAltitude() {
		return .0f;
	}

	public float getTargetAltitude() {
		return target;
	}

	public void updateAltitude ( float current, float speed ) {
		altitudeMeter.localScale = new Vector3 (1, Mathf.Clamp (current / target, 0, 1), 1);
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
