using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RocketPlayerScript : MonoBehaviour {

	// Player's graphic 
	Transform spriteTransform;
	SpriteRenderer spriteRenderer;

	RocketGameSystemScript system;
	ParticleSystem emitter;

	// Touch position
	bool touching;
	Vector2 lastMousePosition;

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
	float blinkingTimer = 0;

	// Use this for initialization
	void Start () {

		// Get child graphic object; we'll be doing some transform changes onto it
		spriteTransform = this.transform.FindChild ("playerGraphic");
		spriteRenderer = this.transform.FindChild ("playerGraphic").GetComponent<SpriteRenderer> ();

		emitter = this.transform.FindChild ("emitter").GetComponent<ParticleSystem> ();

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
			collectFuel (1f);
		}
			

		float deltaX = .0f;
		if (Input.GetMouseButton (0) && touching) {

			Vector2 currentMousePosition = Input.mousePosition;
			float xMovement = lastMousePosition.x - currentMousePosition.x;

			Vector3 objScrPoint = Camera.main.WorldToScreenPoint (transform.position);
			objScrPoint.x += xMovement;

			objScrPoint = Camera.main.ScreenToWorldPoint (objScrPoint);
			deltaX = transform.position.x - objScrPoint.x;


			lastMousePosition = (Vector2) Input.mousePosition;
		} else {
			if (Input.GetMouseButtonDown (0)) {
				touching = true;
				lastMousePosition = (Vector2) Input.mousePosition;
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
			Mathf.Clamp ( this.transform.position.x + deltaX, -6f, 6f),
			Mathf.Clamp ( this.transform.position.y - currentFallSpeed + recoverySpeed, playerDeathBarrier -2f, playerFlyingPosition),
			this.transform.position.z
		);

		if (this.transform.position.y < playerDeathBarrier ) {
			//that's death
			system.gameOver();
			Destroy (gameObject);;
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
			if (!falling) {
				falling = true;
				emitter.Play ();
			}
		} else {
			if (falling) {
				falling = false;
				emitter.Stop ();
			}
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
			blinkingTimer += 0.125f;
			float blink = (Mathf.Sin ((2 * blinkingTimer + 3) * Mathf.PI / 2) + 1) / 4;
			spriteRenderer.color = new Color (1.0f, 0.5f+blink, 0.5f+blink, 1f);
			invulTimer -= Time.deltaTime;
			if (invulTimer <= .0f) {
				spriteRenderer.color = new Color (1.0f, 1.0f, 1.0f, 1f);
			}
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

	void registerHit ( int penaltyLevel ) {
		if (invulTimer > .0f) {
			return;
		}
		blinkingTimer = 0f;
		fuelPenalty = 0.025f * penaltyLevel;
		invulTimer = 1.5f;
		damagedTimer = 0.4f;
		damaged = true;
		system.setDamagedFuelPosition (fuel);
	}

	void collectFuel ( float refillMultiplier ) {
		fuelAddition = 0.075f * refillMultiplier; //magic number, don't tell anyone :)
	}

	void OnTriggerEnter2D ( Collider2D col ) {
		
		switch (col.gameObject.tag) 
		{
		case "cloud": 
			registerHit(1);
			break;
		case "fuel":
			collectFuel (0.5f);
			col.gameObject.GetComponent<ObjectScript> ().collect ();
			//col.gameObject.GetComponent<fuelObject>().collect();
			break;
		default:
			Debug.Log ("Unknown object type collided!");
			col.gameObject.GetComponent<ObjectScript> ().kill ();
			break;
		}

	}
}
