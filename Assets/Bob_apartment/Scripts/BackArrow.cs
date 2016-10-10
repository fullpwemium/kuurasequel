using UnityEngine;
using System.Collections;

public class BackArrow : MonoBehaviour {

    ItemControl ic1;
	public GameObject pet;
	public GameObject pet2;
	public GameObject kissekuva;
	public GameObject kissa1;
	public GameObject kissakasa1;
	public GameObject backarrow;
	public GameObject feidi;
    public GameObject dusti;
    public GameObject exitButton;
    public GameObject happiness;

    int foodamount = ItemControl.amountofFood;
    // Use this for initialization
    void Start ()
    {
       
    }
	
	// Update is called once per frame
	void Update ()
    {

	}
	void OnMouseDown()
    {
        GameObject.FindWithTag("Food");  
		kissekuva.SetActive (false);
		kissa1.SetActive (true);
		kissakasa1.SetActive (true);
		backarrow.SetActive (false);
		feidi.SetActive (false);
		pet.SetActive (false);
		pet2.SetActive (false);
        dusti.SetActive(false);
        exitButton.SetActive(true);
        if (foodamount > 0)
        {
            GameObject.FindWithTag("Food").SetActive(false);
        }
        else
        {
            Debug.Log("You are out of food");
        }
        happiness.SetActive(true);
    }
}
