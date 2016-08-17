using UnityEngine;
using System.Collections;

public class KissaPetClick : MonoBehaviour {

	public GameObject pet2;
	public GameObject pet1;
	public GameObject säde;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseOver() {
		pet1.SetActive (false);
		pet2.SetActive (true);
		säde.SetActive (true);

	}

}
