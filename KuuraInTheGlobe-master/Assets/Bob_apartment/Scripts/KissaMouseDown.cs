using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KissaMouseDown : MonoBehaviour {
	
	public GameObject kissekuva;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		kissekuva.SetActive (true);
	}
}
