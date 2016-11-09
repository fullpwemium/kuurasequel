using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackToApartmentArrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		Debug.Log("Back arrow clicked");
		SceneManager.LoadScene("Bob_apartment");
	}
}
