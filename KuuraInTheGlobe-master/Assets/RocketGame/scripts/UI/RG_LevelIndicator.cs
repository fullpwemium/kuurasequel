using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RG_LevelIndicator : MonoBehaviour {

	float speed = 0f;
	public float initialSpeed = 5f;
	public float deaccel = 0.5f;

	int level_num = 0;

	float timer = 0f;
	SpriteRenderer r_text;
	SpriteRenderer r_num2;
	SpriteRenderer r_num1;

	public List<Sprite> numbers;

	void Start () {
		speed = initialSpeed;
		r_text = transform.FindChild("LevelIndicator/level_text").GetComponent<SpriteRenderer> ();
		r_num2 = transform.FindChild("LevelIndicator/level_number_2").GetComponent<SpriteRenderer> ();
		r_num1 = transform.FindChild("LevelIndicator/level_number_1").GetComponent<SpriteRenderer> ();

		int l = GameObject.Find ("gameplaySystem").GetComponent<RocketGameGameplaySystem> ().getCurrentLevel ();
		setLevel (l);
	}

	void setLevel ( int level ) {
		if (level < 0) {
			level = level * -1;
		}
		if (level > 11) {
			level = 11;
		}
		level_num = level;

		// Set the first digit
		if (level == 10) {
			r_num1.sprite = numbers [1];
		} else {
			if (level < 10) {
				r_num1.sprite = numbers [level];
			} else {
				r_num1.sprite = numbers [10];
				r_num1.transform.localScale = new Vector3 (25, 25, 1);
			}
		}

		// Set the second digit if necessary
		if (level_num < 10) {
			r_num2.color = new Color (1, 1, 1, 0);
		} else {
			if (level_num == 10) {
				r_num2.sprite = numbers [0];
			} else {
				r_num2.color = new Color (1, 1, 1, 0);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (speed < initialSpeed * -1) {
			timer += Time.fixedDeltaTime;
			r_text.color = new Color (1, 1, 1, 4 - timer);
			if (level_num == 10) {
				r_num2.color = new Color (1, 1, 1, 4 - timer);
			}
			r_num1.color = new Color (1, 1, 1, 4 - timer);
			if ((4 - timer) < 0) {
				Destroy (gameObject);
			}
			return;
		}

		float y = transform.localPosition.y + speed;
		transform.localPosition = new Vector3 (transform.localPosition.x, y, transform.localPosition.z);

		speed -= deaccel;
	}
}
