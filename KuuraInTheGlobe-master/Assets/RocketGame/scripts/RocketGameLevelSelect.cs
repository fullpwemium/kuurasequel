using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RocketGameLevelSelect : MonoBehaviour {

	public Scene gameplayScene;

	int selectedLevel;
	int clearedLevels = 1;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		selectedLevel = 1;

		setButtonEventListeners ();
	}

	void setButtonEventListeners() {
		GameObject.Find("ButtonCanvas/level1/Button").GetComponent<Button>().onClick.AddListener ( delegate { this.levelButtonClicked (1); } );
		GameObject.Find("ButtonCanvas/level2/Button").GetComponent<Button>().onClick.AddListener ( delegate { this.levelButtonClicked (2); } );
		GameObject.Find("ButtonCanvas/exitButton/Button").GetComponent<Button>().onClick.AddListener ( delegate { this.exitMinigame(); } );
	}

	void levelButtonClicked ( int level ) {
		selectedLevel = level;
		SceneManager.LoadScene ("_rocketGame-GameplayLoop", LoadSceneMode.Single);
	}

	void exitMinigame ( ) {
		SceneManager.LoadScene ("Map2", LoadSceneMode.Single);
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		// ...
	}

	public int getSelectedLevel () {
		return selectedLevel;
	}

	public void clearLevel ( int cleared ) {
		Debug.Log ("Perkele!");
		if (clearedLevels < cleared) {
			clearedLevels = cleared;
		}
	}

	public int getClearedLevels ( ) {
		return clearedLevels;
	}

	public void returnToLevelSelect() { 
		//Debug.Log ("moi");
		//setButtonEventListeners ();
	}

}
