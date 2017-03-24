using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour {

	public float speed = 0.025f; 
	public bool setToDestroy = false;
	int isCat = -1;
	float timer;

	bool pulsate = false;
	Transform gfx;
	float sizeX;
	float sizeY;

	void Start () {
		speed = Random.Range (speed * 0.825f, speed * 1.175f);
		timer = 0f;
		if (gameObject.GetComponent<BoxCollider2D> ()) {
			gfx = transform;//.FindChild ("graphic").GetComponent<Transform> ();
			sizeX = gfx.localScale.x;
			sizeY = gfx.localScale.y;
			pulsate = true;
		}
	}

	public bool checkIfCat () {
		return isCat == -1;
	}

	public int getCatLevel () {
		return isCat;
	}

	public void markCat( int level ) {
		isCat = level;
	}

	public void move() {
		transform.localPosition = new Vector3 (
			transform.localPosition.x,
			transform.localPosition.y - speed,
			transform.localPosition.z
		);

		if (transform.position.y < -10) {
			setToDestroy = true;
		}

		if (pulsate && isCat==-1) {
			timer += 0.075f;
			gfx.localScale = new Vector3 (sizeX - Mathf.Sin (timer)*2, sizeY - Mathf.Cos (timer+Mathf.PI/2), 1);
		}

	}

	public void collect () {
		//Debug.Log ("This object was collected by player: " + gameObject);
		setToDestroy = true;
	}

	//A little gruesome name, I must admit
	public void kill () {
		//Debug.Log ("Kill was had: " + gameObject);
		setToDestroy = true;
	}
}
