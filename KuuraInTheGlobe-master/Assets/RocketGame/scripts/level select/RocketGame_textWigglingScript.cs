using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketGame_textWigglingScript : MonoBehaviour {

	float timer = 0f;
	public float force = 2;
	public float speed = 0.075f;

	void Start () {
		timer = Random.Range (0f, Mathf.PI);
	}
	
	// Update is called once per frame
	void Update () {
		timer += speed;
		transform.eulerAngles = new Vector3 (0, 0, Mathf.Cos (timer+(Mathf.PI/2)) * force);
	}
}
