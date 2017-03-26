using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RocketPlayerScript : MonoBehaviour {

	// Player's graphic 
	Transform spriteTransform;
	SpriteRenderer spriteRenderer;

	RocketGameGameplaySystem game;
	ParticleSystem emitter;

	// Touch position
	bool touching;
	Vector2 lastMousePosition;

	// Invulnerability timer for player object
	float invulTimer;
	float damagedTimer; // variable for shaking player after taking a hit
	bool  damaged;

	bool falling;
	public float fallSpeed = 10.25f;
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
	float playerFlyingPosition = -110.0f;
	float playerDeathBarrier = -560f;

	bool playable = false;
	float timer = 0f;
	float blinkingTimer = 0;

	bool initialized = false;
	// Use this for initialization
	void Start () {

		// Get child graphic object; we'll be doing some transform changes onto it
		spriteTransform = this.transform.FindChild ("playerGraphic");
		spriteRenderer = this.transform.FindChild ("playerGraphic").GetComponent<SpriteRenderer> ();

		emitter = this.transform.FindChild ("emitter").GetComponent<ParticleSystem> ();

		damaged = false;
		currentFallSpeed = .0f;

		game = GameObject.Find ("gameplaySystem").GetComponent<RocketGameGameplaySystem> ();

		fuel = 1.0f;;
		altitude = game.getStartingAltitude ();

		initialized = true;
	}
	
	// Called by RocketGameGameplaySystem.cs once every frame
	public void updatePlayer () {
		if (!initialized) { return; }
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

	public void pause(bool toggle) {
		if (toggle) {
			emitter.Pause ();
		} else {
			emitter.Play ();
		}
	}

	float applyMovement () {

		if (falling || damaged ) {
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
			deltaX = -(lastMousePosition.x - currentMousePosition.x);

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
		if (!falling && !damaged) {
			if (transform.localPosition.y < playerFlyingPosition) {
				recoverySpeed = (Mathf.Abs (transform.localPosition.y)) / 60;
			}
		}

		this.transform.localPosition = new Vector3 (
			Mathf.Clamp ( this.transform.localPosition.x + deltaX, -290f, 305f),
			Mathf.Clamp ( this.transform.localPosition.y - currentFallSpeed + recoverySpeed, playerDeathBarrier -2f, playerFlyingPosition),
			this.transform.position.z
		);

		if (this.transform.localPosition.y < playerDeathBarrier ) {
			//that's death
			game.gameOver( altitude );
			Destroy (gameObject);;
		}

		return deltaX;
	}

	void applyRotation ( float change ) {

		if (Mathf.Abs (change) > 0f) {
			// Replace current rotation if necessary
			change = Mathf.Clamp ((change/80) * -75, -42, 45);
			if (Mathf.Abs (change) > Mathf.Abs (spriteTransform.rotation.z)) {
				spriteTransform.eulerAngles = new Vector3 (
					0,
					0,
					change
				);
			}
			return;
		} else {
			// Seek upright position over time
			//  Mathf.Sin (timer+(Mathf.PI/2)) * 2)
			if (Mathf.Abs (spriteTransform.rotation.z) > .0f) {
				float rot = spriteTransform.rotation.z;
				rot = spriteTransform.rotation.z + spriteTransform.rotation.z / (-spriteTransform.rotation.z) * 0.1f;
				rot = rot / 1000;
				spriteTransform.eulerAngles = new Vector3 (0, 0, spriteTransform.rotation.z + rot);
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

		game.updateFuel (fuel);

		if (fuel <= .0f) {
			if (!falling) {
				falling = true;
				emitter.Stop ();
				//emitter.Play ();
			}
		} else {
			if (falling) {
				falling = false;
				emitter.Play ();
				//emitter.Stop ();
			}
		}
	}

	public void initAltitude(float alt) {
		altitude = alt;
	}

	float accel = 0f;
	void updateAltitude () {

		//float accel = 0f;
		if (!damaged) {
			if (!falling) {
				accel += speedAcceleration / 2;
			} else {
				if (accel > 0) {
					accel = 0f;
				}
				accel += -speedAcceleration / 4;
			}
		} else {
			if (accel > 0) {
				accel = 0f;
			}
			accel += -speedAcceleration / 5;
		}

		if (!falling) {
			sineWaveGraphic (); // do this before doing the invul check so that player shakes real good
		}

		speed += accel;
		speed = Mathf.Clamp (speed, 0, speedMax);

		altitude += speed;
		game.updateAltitude ( altitude, speed );
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
		game.setDamagedFuelPosition (fuel);
	}

	void collectFuel ( float refillMultiplier ) {
		fuelAddition = 0.075f * refillMultiplier; //magic number, don't tell anyone :)
	}

	void collectCat ( ObjectScript cat ) {
		game.markCatCollected ( cat );
	}

	void OnTriggerEnter2D ( Collider2D col ) {

		ObjectScript obj = col.gameObject.GetComponent<ObjectScript> ();

		switch (col.gameObject.tag) 
		{
		case "cloud": 
			registerHit(1);
			break;
		case "fuel":
			collectFuel (0.65f);
			obj.collect ();
			break;
		case "Cat":
			collectCat ( obj  );
			obj.collect ( );
			break;
		default:
			Debug.Log ("Unknown object type collided!");
			obj.kill ();
			break;
		}

	}
}
