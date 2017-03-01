using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RocketPlayerScript : MonoBehaviour {

	// Player's graphic 
	Transform spriteTransform;

	RocketGameSystemScript system;

	// Touch position
	bool touching;
	Vector2 lastMousePosition;

	// Null vector for utility when calculating horizontal movement delta
	Vector3 nullVector;

	// Invulnerability timer for player object
	float invulTimer;
	float damagedTimer; // variable for shaking player after taking a hit
	bool  damaged;

	bool falling;
	public float fallSpeed = .00125f;
	float currentFallSpeed;

	// fuel and fuel consumption
	float fuel;
	float fuelConsumption = 0.00125f;
	float fuelPenalty = .0f;
	float fuelAddition = .0f;

	// Current flying position
	float altitude = 0.0f;

	// Flying speed
	float speed = 0.0f;
	float speedAcceleration = 0.001f;
	float speedMax = 0.125f;

	// Positional variables for handling Bob's position on screen and when to trigger game over
	float playerFlyingPosition = -2.0f;
	float playerDeathBarrier = -10f;

	bool playable = false;
	float timer = 0;

	// Use this for initialization
	void Start () {

		// Get child graphic object; we'll be doing some transform changes onto it
		spriteTransform = this.transform.FindChild ("playerGraphic");

		nullVector = Camera.main.ScreenToWorldPoint (new Vector3 (0, 0, 0));

		damaged = false;
		currentFallSpeed = .0f;

		system = GameObject.Find ("system").GetComponent<RocketGameSystemScript> ();

		//transform.position = new Vector3 (0, playerFlyingPosition, 0);
		playerFlyingPosition = -2.0f;

		fuel = 1.0f;;
		altitude = system.getStartingAltitude ();

	}
	
	// Called by RocketGameSystemScript.cs once every frame
	public void updatePlayer () {
		if (playable) {
			float difference = applyMovement ();
			applyRotation (difference);
			checkFuel ();
			updateAltitude ();
			checkInvul ();
		}
	}

	public void togglePlayable () {
		playable = !playable;
	}
		

	float applyMovement () {

		if (falling) {
			currentFallSpeed += fallSpeed * 0.25f;
		} else {
			if (currentFallSpeed > 0) {
				currentFallSpeed = currentFallSpeed / 10;
				if (currentFallSpeed < 0.0125) {
					currentFallSpeed = 0;
				}
			}
		}

		if (Input.GetMouseButtonDown (1)) {
			collectFuel ();
		}

		float deltaX = .0f;
		if (Input.GetMouseButton (0) && touching) {

			// There probably is an easier way to find the mouse delta, but I don't know
			float currentMousePosition = Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition - lastMousePosition).x;
			deltaX = currentMousePosition - nullVector.x;

			lastMousePosition = (Vector2)Input.mousePosition;
		} else {
			if (Input.GetMouseButtonDown (0)) {
				touching = true;
				lastMousePosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			} else {
				touching = false;
			}
		}

		float recoverySpeed = 0f;
		if (!falling) {
			if (transform.position.y < playerFlyingPosition) {
				recoverySpeed = (Mathf.Abs (transform.position.y)) / 30;
			}
		}

		this.transform.position = new Vector3 (
			Mathf.Clamp ( this.transform.position.x + deltaX, nullVector.x, -nullVector.x),
			Mathf.Clamp ( this.transform.position.y - currentFallSpeed + recoverySpeed, playerDeathBarrier -2f, playerFlyingPosition),
			this.transform.position.z
		);

		if (this.transform.position.y < playerDeathBarrier ) {
			//that's death
			system.gameOver();
			Destroy (gameObject);
		}

		return deltaX;
	}

	void applyRotation ( float change ) {

		if (Mathf.Abs (change) > .0f) {
			// Replace current rotation if necessary
			change = Mathf.Clamp (change * -75, -42, 42);
			if (Mathf.Abs (change) > Mathf.Abs (spriteTransform.rotation.z)) {
				spriteTransform.rotation = Quaternion.Euler (
					spriteTransform.rotation.x,
					spriteTransform.rotation.y,
					change
				);
			}
			return;
		} else {
			// Seek upright position over time
			if (Mathf.Abs (spriteTransform.rotation.z) > .0f) {
				float rot = spriteTransform.rotation.z;
				rot = spriteTransform.rotation.z + spriteTransform.rotation.z / (-spriteTransform.rotation.z) * 0.1f;
				rot = rot / 1000;
				spriteTransform.rotation = Quaternion.Euler (0, 0, spriteTransform.rotation.z + rot);
			}
		}
		                 
	}

	void sineWaveGraphic () {
		timer += 0.125f;
		spriteTransform.localPosition = new Vector3 (0, Mathf.Sin (timer)/8, 0);
	}

	void collectFuel () {
		fuelAddition = 0.075f; //magic number, don't tell anyone :)
	}

	void checkFuel () {
		if (fuelAddition > 0.001f) {
			fuel += fuelAddition;
			fuelAddition = fuelAddition / 1.25f;
		} else {
			fuel -= fuelConsumption;
		}
		fuel -= fuelPenalty;
		fuelPenalty = fuelPenalty / 2;
		fuel = Mathf.Clamp( fuel, 0f, 1f );

		system.updateFuel (fuel);

		if (fuel <= .0f) {
			falling = true;
		} else {
			falling = false;
		}
	}

	void updateAltitude () {

		float accel = 0f;
		if (!damaged) {
			if (!falling) {
				accel = speedAcceleration;
			} else {
				accel = -speedAcceleration;
			}
		} else {
			accel = -speedAcceleration * 2;
		}

		if (!falling) {
			sineWaveGraphic (); // do this before doing the invul check so that player shakes real good
		}


		speed = Mathf.Clamp (speed + accel, 0, speedMax);

		altitude += speed;
		system.updateAltitude ( altitude, speed );
	}

	void checkInvul() {
		if (invulTimer > .0f) {
			invulTimer -= Time.deltaTime;
		};
			
		if (damaged) {
			if (damagedTimer > .0f) {
				damagedTimer -= Time.deltaTime;
				spriteTransform.localPosition = new Vector3 (
					Random.Range (-0.125f, 0.125f) * (damagedTimer / 0.25f),
					spriteTransform.localPosition.y + Random.Range (-0.125f, 0.125f) * (damagedTimer / 0.25f),
					0
				);
			} else {
				spriteTransform.localPosition = new Vector3 (0, spriteTransform.localPosition.y, 0);
				damaged = false;
			}
		}
	}

	void registerHit ( ) {
		if (invulTimer > .0f) {
			return;
		}

		fuelPenalty = 0.025f;
		invulTimer = 2f;
		damagedTimer = 0.4f;
		damaged = true;
		system.setDamagedFuelPosition (fuel);
	}

	void OnTriggerEnter2D ( Collider2D col ) {
		
		switch (col.gameObject.tag) 
		{
		case "cloud": 
			registerHit();
			break;
		case "fuel":
			collectFuel ();
			col.gameObject.GetComponent<ObjectScript> ().collect ();
			//col.gameObject.GetComponent<fuelObject>().collect();
			break;
		default:
			Debug.Log ("Unknown object type collided!");
			break;
		}

	}
}
