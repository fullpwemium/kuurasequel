using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RocketGameLevelSelect : MonoBehaviour {

	public GameObject systemPrefab;
	RocketGameSystem system;
	Transform levelSelectText;

	float timer;

	// Use this for initialization
	void Start () {
		timer = 0f;
		// Fetch system object
		if (!GameObject.Find ("rocketGameSystem")) {
			system = GameObject.Instantiate (systemPrefab).GetComponent<RocketGameSystem> ();
		} else {
			system = GameObject.Find ("rocketGameSystem").GetComponent<RocketGameSystem> ();
		}

		levelSelectText = GameObject.Find ("MainCanvas/level_select_text").transform;
			
		setButtonEventListeners ();
	}

	void setButtonEventListeners() {
		// First level button is always visible by default!
		GameObject.Find("MainCanvas/level1").GetComponent<Button>().onClick.AddListener ( delegate { this.levelButtonClicked (1); } );

		for (int i = 2; i < 11; i++) {
			addDelegateOrRemove (i); // Must escape for loop scope, otherwise every button will act like it's the 10th level button
		}
		// Exit button
		GameObject.Find("MainCanvas/exit").GetComponent<Button>().onClick.AddListener ( delegate { this.exitMinigame(); } );
	}

	void addDelegateOrRemove ( int i ) {
		if (system.getClearedLevels() > i-1) {
			GameObject.Find ("MainCanvas/level"+(i)).GetComponent<Button> ().onClick.AddListener (delegate {
				this.levelButtonClicked (i);
			});
		} else {
			Destroy (GameObject.Find ("MainCanvas/level" +(i)));
		}
	}

	void Update () {
		timer += 0.075f;
		levelSelectText.eulerAngles = new Vector3 (0, 0, Mathf.Sin (timer)*4);
	}

	void levelButtonClicked ( int level ) {
		Debug.Log (level);
		system.setStartingLevel (level);
		SceneManager.LoadScene ("_rocketGame-Gameplay", LoadSceneMode.Single);
	}

	void exitMinigame ( ) {
		system.exit ();
		SceneManager.LoadScene ("Map2", LoadSceneMode.Single);;
	}

}
