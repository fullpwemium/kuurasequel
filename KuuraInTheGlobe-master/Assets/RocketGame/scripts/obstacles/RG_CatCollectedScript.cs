using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RG_CatCollectedScript : MonoBehaviour {

	float speed = 0f;
	public float initialSpeed = 5f;
	public float deaccel = 0.5f;

	float timer = 0f;
	SpriteRenderer r;

	void Start () {
		speed = initialSpeed;
		r = gameObject.GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (speed < initialSpeed * -1) {
			timer += Time.fixedDeltaTime;
			r.color = new Color (1, 1, 1, 1 - timer);
			if ((1 - timer) < 0) {
				Destroy (gameObject);
			}
			return;
		}

		float y = transform.localPosition.y + speed;
		transform.localPosition = new Vector3 (transform.localPosition.x, y, transform.localPosition.z);

		speed -= deaccel;
	}
}
