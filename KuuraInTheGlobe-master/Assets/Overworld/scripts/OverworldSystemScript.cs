using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldSystemScript : MonoBehaviour {

	Vector3 bobPosition;
	string bobNode;

	// Use this for initialization
	void Start () {
		gameObject.name = "OverworldGameSystem";
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void init() {
		bobPosition = GameObject.Find ("Canvas/Foreground/Tiles/RocketGame").GetComponent<Transform> ().position;
		bobNode = "Canvas/Foreground/Tiles/RocketGame";
	}

	public Vector3 getBobStartingPosition() {
		return bobPosition;
	}

	public void setBobStartingPosition(Vector3 vec) {
		bobPosition = vec; 
	}

	public void setBobNodeName ( string nodeName ) {
		bobNode = nodeName;
	}

	public string getBobNodeName () {
		return bobNode;
	}
}
