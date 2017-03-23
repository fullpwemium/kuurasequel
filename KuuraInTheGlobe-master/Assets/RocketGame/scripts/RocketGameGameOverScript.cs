using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketGameGameOverScript : MonoBehaviour {

	RocketGameGameplaySystem game;
	public Button retryButton;
	public Button levelSelectButton;
	public Button exitButton;

	public GameObject gameOverText;
	GameObject gameOverTextObj;
	public GameObject gameOverScreen;
	GameObject gameOverScreenObj;

	public GameObject highScore;
	GameObject highScoreObj;

	float hsPosition;

	// retry button
	Transform rbTransform;
	float rbPosition;

	// level select button
	Transform lbTransform;
	float lbPosition;

	// exit button
	Transform ebTransform;
	float ebPosition;

	Transform UICanvas;
	float fade;
	Vector3 ogPosition;

	bool activated = false;
	bool buttonsSpawned = false;
	bool finished = false;
	bool waitForButtons = false;

	// timer
	float timer = 0f;

	// Use this for initialization
	void Start () {

		game = gameObject.GetComponent<RocketGameGameplaySystem> ();
		UICanvas = GameObject.Find ("GameOverCanvas").GetComponent<Transform> ();
	}

	void Update () {
		timer += 0.075f;

		if (gameOverTextObj != null) {
			gameOverTextObj.transform.eulerAngles = new Vector3 (
				0,
				0,
				Mathf.Sin (timer) * 4
			);
		}

		if (waitForButtons) {
			if (timer < 4f) {
				return;
			} else {
				spawnButtons ();
				waitForButtons = false;
				timer = 0f;
			}
		}

		if (finished) {
			return;
		}
		if (!buttonsSpawned) {
			if (!activated) {
				return;
			}

			fade -= 0.0125f;

			if (fade <= .0f) {
				fade = 0f;
				activated = false;
			}

			SpriteRenderer r = gameOverScreenObj.GetComponent<SpriteRenderer> ();
			Transform t = gameOverScreenObj.GetComponent<Transform> ();

			r.color = new Color (1f, 1f, 1f, 1f - fade);
			t.position = new Vector3 (ogPosition.x, ogPosition.y + fade * 20, ogPosition.z);

			if (!activated) {
				waitForButtons = true;
				fade = 400f;
				timer = 0f;
				//fade = 400f;
			}
		} else {
			fade = fade / 1.5f;

			Color col = gameOverScreenObj.GetComponent<SpriteRenderer>().color;
			float val = Mathf.Clamp (col.r - 0.075f, 0.5f, 1.0f);
			gameOverScreenObj.GetComponent<SpriteRenderer>().color = new Color ( val, val,	val, 1f);
 
			rbTransform.localPosition = new Vector3 (rbPosition + fade, rbTransform.localPosition.y, rbTransform.localPosition.z);
			lbTransform.localPosition = new Vector3 (lbPosition + fade, lbTransform.localPosition.y, lbTransform.localPosition.z);
			ebTransform.localPosition = new Vector3 (ebPosition - fade, ebTransform.localPosition.y, ebTransform.localPosition.z);
			highScoreObj.transform.localPosition = new Vector3 (hsPosition - fade, highScoreObj.transform.localPosition.y, highScoreObj.transform.localPosition.z);

			gameOverTextObj.transform.localPosition = new Vector3 (
				rbPosition + fade - 15f,
				gameOverTextObj.transform.localPosition.y,
				gameOverTextObj.transform.localPosition.z
			);

			if (fade < 0.2f) {
				rbTransform.localPosition = new Vector3 (rbPosition, rbTransform.localPosition.y, rbTransform.localPosition.z);
				lbTransform.localPosition = new Vector3 (lbPosition, lbTransform.localPosition.y, lbTransform.localPosition.z);
				ebTransform.localPosition = new Vector3 (ebPosition, ebTransform.localPosition.y, ebTransform.localPosition.z);

				gameOverTextObj.transform.localPosition = new Vector3 ( 
					rbPosition - 15f,
					gameOverTextObj.transform.localPosition.y,
					gameOverTextObj.transform.localPosition.z
				);

				finished = true;
			}
		}
	}

	float scoreResult = 0f;
	bool highscoreAchieved = false;
	public void init (float result, bool isHighscore ) {

		gameOverScreenObj = Instantiate (gameOverScreen);
		gameOverScreenObj.transform.SetParent (UICanvas, false);
		gameOverScreenObj.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0f);
		//gameOverScreenImg = gameOverScreenObj.transform.FindChild ("img").GetComponent<Image> ();

		scoreResult = result;
		highscoreAchieved = isHighscore;


		ogPosition = gameOverScreenObj.transform.position;
		activated = true;
		fade = 1f;
		buttonsSpawned = false;
		finished = false;
		timer = 0f;

	}

	void spawnButtons () {

		gameOverTextObj = Instantiate (gameOverText);
		gameOverTextObj.transform.SetParent (UICanvas, false);

		List<Button> butList = new List<Button> ();

		Button rButton = (Button)Instantiate (retryButton);
		rButton.transform.SetParent (UICanvas, false);
		rbTransform = rButton.transform;
		rbPosition = 230f;
		butList.Add (rButton);

		Button lButton = (Button)Instantiate (levelSelectButton);
		lButton.transform.SetParent (UICanvas, false);
		lbTransform = lButton.transform;
		lbPosition = 230f;
		butList.Add (lButton);

		Button eButton = (Button)Instantiate (exitButton);
		eButton.transform.SetParent (UICanvas, false);
		ebTransform = eButton.transform;
		ebPosition = -335f;
		butList.Add (eButton);

		highScoreObj = Instantiate (highScore);
		highScoreObj.transform.SetParent (UICanvas, false);
		hsPosition = -120f;

		if (!highscoreAchieved) {
			Destroy(highScoreObj.transform.FindChild ("text/highscoreAcquired").GetComponent<Text> ());
		}

		highScoreObj.transform.FindChild ("text/highscore").GetComponent<Text> ().text = Mathf.Floor (scoreResult) + "m";

		// Create retry button through a delegate function
		rButton.onClick.AddListener ( delegate { this.retryButtonClicked (butList); } );
		// Same for level select
		lButton.onClick.AddListener ( delegate { this.levelSelectButtonClicked (); } );
		// Same for exit button
		eButton.onClick.AddListener ( delegate { this.exit (); } );
		buttonsSpawned = true;
	}

	public void retryButtonClicked (List<Button> list ) {
		// Remove retry button and game over screen
		foreach (Button but in list) {
			Destroy (but.gameObject);
		}

		Destroy (gameOverTextObj);
		Destroy (gameOverScreenObj);

		// Restart the level from last checkpoint
		game.retry ();
	}

	public void levelSelectButtonClicked ( ) {
		game.gotoLevelSelect ();
	}

	public void exit () {
		game.exit ();
	}
}
