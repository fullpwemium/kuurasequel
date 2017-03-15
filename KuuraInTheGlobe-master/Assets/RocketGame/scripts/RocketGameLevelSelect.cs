using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RocketGameLevelSelect : MonoBehaviour {

	public GameObject systemPrefab;
	RocketGameSystem system;
	Transform levelSelectText;
	RocketGameLevelSelectPlayerObject player;

	float timer;
	float startTimer = 1f;
	bool clicked = false;
	bool countdown = false;

	// Use this for initialization
	void Start () {
		timer = 0f;
		// Fetch system object
		if (!GameObject.Find ("rocketGameSystem")) {
			system = GameObject.Instantiate (systemPrefab).GetComponent<RocketGameSystem> ();
			system.init ();
		} else {
			system = GameObject.Find ("rocketGameSystem").GetComponent<RocketGameSystem> ();
		}

		player = GameObject.Find ("MainCanvas/playerObject_levelSelect").GetComponent<RocketGameLevelSelectPlayerObject> ();

		levelSelectText = GameObject.Find ("MainCanvas/level_select_text").transform;
			
		setButtonEventListeners ();
	}

	void setButtonEventListeners() {

		// Add event listeners to buttons
		for (int i = 1; i < 11; i++) {
			addDelegateOrRemove (i); // Must escape for loop scope, otherwise every button will act like it's the 10th level button!
									 // This is because variables are passed by value by default in C#, and not by reference.
		}

		// Endless mode button
		GameObject.Find("MainCanvas/endless").GetComponent<Button>().onClick.AddListener ( delegate { this.endlessMode(); } );

		// Exit button
		GameObject.Find("MainCanvas/exit").GetComponent<Button>().onClick.AddListener ( delegate { this.exitMinigame(); } );
	}

	void addDelegateOrRemove ( int i ) {
		if (system.getClearedLevels() > i-1) {
			GameObject.Find ("MainCanvas/level"+(i)).GetComponent<Button> ().onClick.AddListener (delegate {
				this.levelButtonClicked (i);
			});
			if (!system.isCatCollected(i)) {
				Destroy (GameObject.Find ("MainCanvas/level" + (i) + "/cat_l" + (i)));
			}
		} else {
			Destroy (GameObject.Find ("MainCanvas/level" +(i)));
		}
	}

	void Update () {
		timer += 0.075f;
		levelSelectText.eulerAngles = new Vector3 (0, 0, Mathf.Sin (timer)*4);

		if (!clicked) { return; }
		if (!countdown) {
			if (player.transform.localPosition.y > 400f) {
				countdown = true;
			}
		} else {
			startTimer -= Time.fixedDeltaTime;
			if (startTimer < 0f) {
				SceneManager.LoadScene ("_rocketGame-Gameplay", LoadSceneMode.Single);
			}
		}
	}

	void levelButtonClicked ( int level ) {
		if (clicked) {
			return;
		}
		system.setEndless (false);
		system.setStartingLevel (level);
		//SceneManager.LoadScene ("_rocketGame-Gameplay", LoadSceneMode.Single);
		player.playerFlyingPosition = 5000f;
		clicked = true;
	}

	void endlessMode() {
		system.setEndless (true);
		system.setStartingLevel (11);
		player.playerFlyingPosition = 5000f;
		clicked = true;
	}

	void exitMinigame ( ) {
		system.exit ();
		SceneManager.LoadScene ("Map2", LoadSceneMode.Single);;
	}

}
