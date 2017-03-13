using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketGameCountdown : MonoBehaviour {

	Transform MainCanvas;

	RocketGameGameplaySystem game;
	public GameObject gfxObject;
	SpriteRenderer gfx;
	Transform gfxT;

	float endTime;
	int currentCount;
	bool started;
	bool playing;

	float rotationSpeedDec = 0.0125f;
	float rotationSpeedMax = 1f;
	float rotationSpeed;
	float rotationDir = 1f;

	float scaleSpeedDec = 0.25f;
	float scaleSpeedMax = 5.5f;
	float scaleSpeed;

	float scrollSpeed;
	float scrollSpeedStart = -0.15f;
	float scrollSpeedAcc = 0.0025f;

	public Sprite[] frames;
	int frameIndex = 0;

	// Use this for initialization
	void Start () {
		//...
		MainCanvas = GameObject.Find ("MainCanvas").GetComponent<Transform> ();
	}

	void Update ()  {

		if (game.paused) {
			return;
		}

		if (!playing) {
			return;
		}

		if (scaleSpeed > -0.25f) {
			Vector3 scl = gfxT.transform.localScale; 
			scl.x -= scaleSpeed;
			scl.y -= scaleSpeed;
			scaleSpeed -= scaleSpeedDec;
			gfxT.transform.localScale = scl;
		}
		Vector3 rot = gfxT.transform.eulerAngles;
		rotationSpeed -= rotationSpeedDec;
		rot.z += rotationSpeed * rotationDir;
		gfxT.transform.eulerAngles = rot;

		if (!started) {
			scrollSpeed += scrollSpeedAcc;
			if (scrollSpeed > .0f) {
				Vector3 pos = gfxT.transform.position;
				pos.y -= scrollSpeed;
				gfxT.transform.position = pos;
				if (pos.y < -8f) {
					Destroy (gfx.gameObject);
					playing = false;
				}
			}
			return;
		}

		float left = endTime - Time.time;

		if (Mathf.Floor (left) < currentCount) {
			
			frameIndex++;
			currentCount--;
			gfx.sprite = frames [frameIndex];
			gfxT.transform.localScale = new Vector3 (140, 140, 1);
			rotationSpeed = rotationSpeedMax;
			rotationDir = rotationDir * -1;
			scaleSpeed = scaleSpeedMax;
			gfxT.transform.eulerAngles = new Vector3 (0, 0, 34 * rotationDir *-1 );
		}

		if (left < 0) {
			started = false;
		}

	}
	
	public void init () {
		frameIndex = 0;
		game = gameObject.GetComponent<RocketGameGameplaySystem> (); 
		int l = game.getStartingLevel ();
		if (l == 1) {
			// if first level needs some special stuff before count down, put it here
		}
		endTime = Time.time + 3f;
		started = true;
		currentCount = 2;

		gfx = GameObject.Instantiate (gfxObject).GetComponent<SpriteRenderer> ();
		gfxT = gfx.gameObject.transform;
		gfx.transform.SetParent (MainCanvas, false);
		gfxT.transform.localScale = new Vector3 (140, 140, 1);
		gfxT.transform.eulerAngles = new Vector3 (0, 0, 34 * rotationDir *-1 );

		rotationSpeed = rotationSpeedMax;
		scrollSpeed = scrollSpeedStart;
		scaleSpeed = scaleSpeedMax;

		playing = true;
	}



	public bool checkIfFinished () {
		return !started;
	}
}
