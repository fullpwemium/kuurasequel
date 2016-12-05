using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

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
        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuOk, 1);
        BlackScreen.SetActive(true);
        buttonYes.SetActive(true);
        buttonNo.SetActive(true);
        text.SetActive(true);

    }

    public void ButtonNoClick()
    {
        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuCancel, 1);
        BlackScreen.SetActive(false);
        buttonYes.SetActive(false);
        buttonNo.SetActive(false);
        text.SetActive(false);
        BackButton.SetActive(true);
		SceneManager.LoadScene ("ARCat"); 
    }

    public void ButtonYesClick()
    {
        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuOk, 1);
        //Dust reward for watching ads
        if (NotWatchedToday()) {
            PlayerPrefs.SetInt("Magic Dust ", PlayerPrefs.GetInt("Magic Dust ") + 100);
        }
        BackButton.SetActive(true);
        BlackScreen.SetActive(false);
        buttonYes.SetActive(false);
        buttonNo.SetActive(false);
        text.SetActive(false);
		SceneManager.LoadScene ("ARCat"); 
    }

    private bool NotWatchedToday()
    {
        return true;
    }
}
