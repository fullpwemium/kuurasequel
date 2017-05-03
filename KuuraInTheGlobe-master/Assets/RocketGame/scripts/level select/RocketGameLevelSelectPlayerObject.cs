using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketGameLevelSelectPlayerObject : MonoBehaviour {

	float timer;
	Transform spriteTransform;

	public float playerFlyingPosition = -50f;

	// Use this for initialization
	void Start () {
		timer = 0f;
		spriteTransform = this.transform.FindChild ("playerGraphic");
	}

	float buildingSpeed = 4f;
	// Update is called once per frame
	void FixedUpdate () {

		float recoverySpeed = 0f;
		if (playerFlyingPosition < 0f) {
			if (transform.localPosition.y < playerFlyingPosition) {
				recoverySpeed = (Mathf.Abs (transform.localPosition.y)) / 10;
			}
		} else {
			buildingSpeed += 1 + buildingSpeed / 10;
			recoverySpeed = buildingSpeed;
		}

		this.transform.localPosition = new Vector3 (
			this.transform.localPosition.x,
			Mathf.Clamp ( this.transform.localPosition.y + recoverySpeed, -600f, playerFlyingPosition),
			this.transform.localPosition.z
		);

		sineWaveGraphic ();	
	}

	void sineWaveGraphic () {
		timer += 0.125f;
		spriteTransform.localPosition = new Vector3 (0, Mathf.Sin (timer)/8, 0);
		spriteTransform.eulerAngles = new Vector3 (0, 0, (Mathf.Sin (timer+(Mathf.PI/2))-0.5f) * 2);
	}
}
