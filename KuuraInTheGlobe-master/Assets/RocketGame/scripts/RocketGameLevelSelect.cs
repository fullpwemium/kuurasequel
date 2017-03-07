using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RocketGameLevelSelect : MonoBehaviour {

	public GameObject systemPrefab;
	RocketGameSystem system;

	// Use this for initialization
	void Start () {
		// Fetch system object
		if (!GameObject.Find ("rocketGameSystem")) {
			system = GameObject.Instantiate (systemPrefab).GetComponent<RocketGameSystem> ();
		} else {
			system = GameObject.Find ("rocketGameSystem").GetComponent<RocketGameSystem> ();
		}
			
		setButtonEventListeners ();
	}

	void setButtonEventListeners() {
		GameObject.Find("ButtonCanvas/level1").GetComponent<Button>().onClick.AddListener ( delegate { this.levelButtonClicked (1); } );
		GameObject.Find("ButtonCanvas/level2").GetComponent<Button>().onClick.AddListener ( delegate { this.levelButtonClicked (2); } );
		GameObject.Find("ButtonCanvas/level3").GetComponent<Button>().onClick.AddListener ( delegate { this.levelButtonClicked (3); } );
		GameObject.Find("ButtonCanvas/level4").GetComponent<Button>().onClick.AddListener ( delegate { this.levelButtonClicked (4); } );
		GameObject.Find("ButtonCanvas/level5").GetComponent<Button>().onClick.AddListener ( delegate { this.levelButtonClicked (5); } );
		GameObject.Find("ButtonCanvas/level6").GetComponent<Button>().onClick.AddListener ( delegate { this.levelButtonClicked (6); } );
		GameObject.Find("ButtonCanvas/level7").GetComponent<Button>().onClick.AddListener ( delegate { this.levelButtonClicked (7); } );
		GameObject.Find("ButtonCanvas/level8").GetComponent<Button>().onClick.AddListener ( delegate { this.levelButtonClicked (8); } );
		GameObject.Find("ButtonCanvas/level9").GetComponent<Button>().onClick.AddListener ( delegate { this.levelButtonClicked (9); } );
		GameObject.Find("ButtonCanvas/level10").GetComponent<Button>().onClick.AddListener ( delegate { this.levelButtonClicked (10); } );
		GameObject.Find("ButtonCanvas/exit").GetComponent<Button>().onClick.AddListener ( delegate { this.exitMinigame(); } );
	}

	void levelButtonClicked ( int level ) {
		system.setStartingLevel (level);
		SceneManager.LoadScene ("_rocketGame-Gameplay", LoadSceneMode.Single);
	}

	void exitMinigame ( ) {
		system.exit ();
		SceneManager.LoadScene ("Map2", LoadSceneMode.Single);;
	}

}
