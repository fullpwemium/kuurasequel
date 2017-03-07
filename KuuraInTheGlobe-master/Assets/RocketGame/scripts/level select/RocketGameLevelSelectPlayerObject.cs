using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketGameLevelSelectPlayerObject : MonoBehaviour {

	float timer;
	Transform spriteTransform;

	float playerFlyingPosition = -224.5f;

	// Use this for initialization
	void Start () {
		timer = 0f;
		spriteTransform = this.transform.FindChild ("playerGraphic");
	}
	
	// Update is called once per frame
	void Update () {

		float recoverySpeed = 0f;
		if (transform.localPosition.y < playerFlyingPosition) {
			recoverySpeed = (Mathf.Abs (transform.localPosition.y)) / 900;
		}

		this.transform.localPosition = new Vector3 (
			this.transform.localPosition.x,
			Mathf.Clamp ( this.transform.localPosition.y + recoverySpeed, -240f, playerFlyingPosition),
			this.transform.localPosition.z
		);

		sineWaveGraphic ();	
	}

	void sineWaveGraphic () {
		timer += 0.125f;
		spriteTransform.localPosition = new Vector3 (0, Mathf.Sin (timer)/8, 0);
	}
}
