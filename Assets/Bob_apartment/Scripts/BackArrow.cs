using UnityEngine;
using System.Collections;

public class BackArrow : MonoBehaviour {

	public GameObject pet;
	public GameObject pet2;
	public GameObject kissekuva;
	public GameObject kissa1;
	public GameObject kissakasa1;
	public GameObject backarrow;
	public GameObject feidi;
    public GameObject dusti;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnMouseDown() {
		kissekuva.SetActive (false);
		kissa1.SetActive (true);
		kissakasa1.SetActive (true);
		backarrow.SetActive (false);
		feidi.SetActive (false);
		pet.SetActive (false);
		pet2.SetActive (false);
        dusti.SetActive(false);
    }
}
