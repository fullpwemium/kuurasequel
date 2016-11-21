using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MailControl : MonoBehaviour {

    public Button mailBox;
    public Button exitLetter;
    public Image exitLetterImage;
    public Image letter1;
    public Text letter1Text;

    // Use this for initialization
    void Start ()
    {
        mailBox.onClick.AddListener(ReadLetter1);
        exitLetter.onClick.AddListener(ExitLetter);

        exitLetter.enabled = false;
        exitLetterImage.enabled = false;
        letter1.enabled = false;
        letter1Text.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void ReadLetter1()
    {
        letter1.enabled = true;
        letter1Text.enabled = true;
        exitLetter.enabled = true;
        exitLetterImage.enabled = true;
    }

    void ExitLetter()
    { 

        exitLetter.enabled = false;
        exitLetterImage.enabled = false;
        letter1.enabled = false;
        letter1Text.enabled = false;
        
    }
}
