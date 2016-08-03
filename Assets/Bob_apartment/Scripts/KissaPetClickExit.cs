using UnityEngine;
using System.Collections;

public class KissaPetClickExit : MonoBehaviour {
	public GameObject pet2;
	public GameObject pet1;
	public GameObject säde;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseExit() {
		pet1.SetActive (true);
		pet2.SetActive (false);
		säde.SetActive (false);
	}

}
