using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketGamePauseScreenScript : MonoBehaviour {

	RocketGameGameplaySystem game;
	Transform t;


	float timer = 0f;

	// Use this for initialization
	void Start () {
		timer = 0f;
		game = GameObject.Find ("gameplaySystem").GetComponent<RocketGameGameplaySystem> ();
		transform.FindChild ("play").gameObject.GetComponent<Button> ().onClick.AddListener ( delegate {this.unpause();});
		transform.FindChild ("levelselect").gameObject.GetComponent<Button> ().onClick.AddListener ( delegate {this.gotoLevelSelect();});
		t = transform.FindChild ("text").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer +=  0.075f;
		t.eulerAngles = new Vector3 (
			0,
			0,
			Mathf.Sin (timer) * 4
		);

	}

	void unpause() {
		game.unpause ();
		Destroy (gameObject);
	}

	void gotoLevelSelect() {
		game.gotoLevelSelect ();
	}
}
