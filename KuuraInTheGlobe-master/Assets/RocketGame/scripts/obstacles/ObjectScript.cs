using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour {

	public float speed = 0.025f;

	int ID;
	RocketGameSystemScript system;
	public bool setToDestroy = false;

	// Use this for initialization
	void Start () {
		// ...
	}

	public void setSystem ( RocketGameSystemScript sys, int sysID ) {
		system = sys;
		ID = sysID;
	}

	public void move() {
		transform.position = new Vector3 (
			transform.position.x,
			transform.position.y - speed,
			transform.position.z
		);

		if (transform.position.y < -10) {
			setToDestroy = true;
			//system.removeSpawnedObject (ID);
			//Destroy (gameObject);
		}
	}

	public void collect () {
		Debug.Log ("This object was collected by player: " + gameObject);
		//Destroy (gameObject);
		setToDestroy = true;
		//system.removeSpawnedObject (ID);
	}
}
