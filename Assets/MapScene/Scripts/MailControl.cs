using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MailControl : MonoBehaviour {

    public Button mailBox;
    public Button mailBoxExit;
    public Image mailBoxExitImage;
    public Image mailBoxBackground;

    public Button letter1Button;
    public Image letter1ButtonImage;
    public Button exitLetter1;
    public Image exitLetter1Image;
    public Image letter1;
    public Text letter1Text;

    // Use this for initialization
    void Start ()
    {
        mailBox.onClick.AddListener(OpenMailBox);
        mailBoxExit.onClick.AddListener(CloseMailBox);
        
        
        letter1Button.onClick.AddListener(ReadLetter1);
        exitLetter1.onClick.AddListener(ExitLetter1);

        mailBoxExitImage.enabled = false;
        mailBoxExit.enabled = false;
        mailBoxBackground.enabled = false;

        exitLetter1.enabled = false;
        exitLetter1Image.enabled = false;

        letter1.enabled = false;
        letter1Text.enabled = false;
        letter1Button.enabled = false;
        letter1ButtonImage.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void CloseMailBox()
    {
        mailBoxExitImage.enabled = false;
        mailBoxExit.enabled = false;
        mailBoxBackground.enabled = false;
        letter1Button.enabled = false;
        letter1ButtonImage.enabled = false;
    }

    void OpenMailBox()
    {
        mailBoxExitImage.enabled = true;
        mailBoxExit.enabled = true;
        letter1Button.enabled = true;
        letter1ButtonImage.enabled = true;
        mailBoxBackground.enabled = true;
    }

    void ReadLetter1()
    {
        letter1.enabled = true;
        letter1Text.enabled = true;
        exitLetter1.enabled = true;
        exitLetter1Image.enabled = true;
    }

    void ExitLetter1()
    { 

        exitLetter1.enabled = false;
        exitLetter1Image.enabled = false;
        letter1.enabled = false;
        letter1Text.enabled = false;
        letter1Button.enabled = false;
        letter1ButtonImage.enabled = false;   
    }
}
