using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour {

	public float speed = 0.025f; 
	public bool setToDestroy = false;

	void Start () {
		// ...
	}

	public void move() {
		transform.position = new Vector3 (
			transform.position.x,
			transform.position.y - speed,
			transform.position.z
		);

		if (transform.position.y < -10) {
			setToDestroy = true;
		}
	}

	public void collect () {
		Debug.Log ("This object was collected by player: " + gameObject);
		setToDestroy = true;
	}

	//A little gruesome name, I must admit
	public void kill () {
		Debug.Log ("Kill was had: " + gameObject);
		setToDestroy = true;
	}
}
