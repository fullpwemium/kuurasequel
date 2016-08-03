using UnityEngine;
using System.Collections;

public class watchAds : MonoBehaviour {

    public GameObject kissa1;
    public GameObject kissakasa1;
    public GameObject BlackScreen;
    public GameObject buttonYes;
    public GameObject buttonNo;
    public GameObject text;
    public GameObject BackButton;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        BlackScreen.SetActive(true);
        buttonYes.SetActive(true);
        buttonNo.SetActive(true);
        text.SetActive(true);

    }

    public void ButtonNoClick()
    {
        BlackScreen.SetActive(false);
        buttonYes.SetActive(false);
        buttonNo.SetActive(false);
        text.SetActive(false);
        BackButton.SetActive(true);
    }

    public void ButtonYesClick()
    {
        //Tähän extra dustin saaminen
        BackButton.SetActive(true);
        BlackScreen.SetActive(false);
        buttonYes.SetActive(false);
        buttonNo.SetActive(false);
        text.SetActive(false);
    }
}
