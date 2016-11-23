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
    public int letter1Counter;

    public Button letter2Button;
    public Image letter2ButtonImage;
    public Button exitLetter2;
    public Image exitLetter2Image;
    public Image letter2;
    public Text letter2Text;
    public int letter2Counter;

    public Button letter3Button;
    public Image letter3ButtonImage;
    public Button exitLetter3;
    public Image exitLetter3Image;
    public Image letter3;
    public Text letter3Text;
    public int letter3Counter;

    public bool greyHatOwned, greyGlassesOwned, greyJacketOwned, greyBootsOwned;
    public bool whiteHatOwned, whiteGlassesOwned, whiteJacketOwned, whiteBootsOwned;
    public bool redHatOwned, redGlassesOwned, redJacketOwned, redBootsOwned;

    // Use this for initialization
    void Start ()
    {
        letter1Counter = PlayerPrefs.GetInt("LetterOneCounter");
        letter2Counter = PlayerPrefs.GetInt("LetterTwoCounter");
        letter3Counter = PlayerPrefs.GetInt("LetterTreeCounter");

        mailBox.onClick.AddListener(OpenMailBox);
        mailBoxExit.onClick.AddListener(CloseMailBox);
        
        letter1Button.onClick.AddListener(ReadLetter1);
        exitLetter1.onClick.AddListener(ExitLetter1);

        letter2Button.onClick.AddListener(ReadLetter2);
        exitLetter2.onClick.AddListener(ExitLetter2);

        letter3Button.onClick.AddListener(ReadLetter3);
        exitLetter3.onClick.AddListener(ExitLetter3);

        mailBoxExitImage.enabled = false;
        mailBoxExit.enabled = false;
        mailBoxBackground.enabled = false;

        exitLetter1.enabled = false;
        exitLetter1Image.enabled = false;
        letter1.enabled = false;
        letter1Text.enabled = false;
        letter1Button.enabled = false;
        letter1ButtonImage.enabled = false;

        exitLetter2.enabled = false;
        exitLetter2Image.enabled = false;
        letter2.enabled = false;
        letter2Text.enabled = false;
        letter2Button.enabled = false;
        letter2ButtonImage.enabled = false;

        exitLetter3.enabled = false;
        exitLetter3Image.enabled = false;
        letter3.enabled = false;
        letter3Text.enabled = false;
        letter3Button.enabled = false;
        letter3ButtonImage.enabled = false;

	
	}
	
	// Update is called once per frame
	void Update ()
    {
      
    }

    void CloseMailBox()
    {
        greyHatOwned = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyHatOwned;
        greyGlassesOwned = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyGlassesOwned;
        greyJacketOwned = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyJacketOwned;
        greyBootsOwned = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyBootsOwned;

        whiteHatOwned = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteHatOwned;
        whiteGlassesOwned = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteGlassesOwned;
        whiteJacketOwned = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteJacketOwned;
        whiteBootsOwned = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteBootsOwned;
        
        redHatOwned = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedHatOwned;
        redGlassesOwned = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedGlassesOwned;
        redJacketOwned = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedJacketOwned;
        redBootsOwned = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedBootsOwned;


        mailBoxExitImage.enabled = false;
        mailBoxExit.enabled = false;
        mailBoxBackground.enabled = false;

        letter1Button.enabled = false;
        letter1ButtonImage.enabled = false;

        letter2Button.enabled = false;
        letter2ButtonImage.enabled = false;

        letter3Button.enabled = false;
        letter3ButtonImage.enabled = false;
    }

    void OpenMailBox()
    {
        greyHatOwned = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyHatOwned;
        greyGlassesOwned = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyGlassesOwned;
        greyJacketOwned = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyJacketOwned;
        greyBootsOwned = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyBootsOwned;

        whiteHatOwned = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteHatOwned;
        whiteGlassesOwned = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteGlassesOwned;
        whiteJacketOwned = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteJacketOwned;
        whiteBootsOwned = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteBootsOwned;

        redHatOwned = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedHatOwned;
        redGlassesOwned = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedGlassesOwned;
        redJacketOwned = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedJacketOwned;
        redBootsOwned = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedBootsOwned;

        letter1Counter = PlayerPrefs.GetInt("LetterOneCounter");
        letter2Counter = PlayerPrefs.GetInt("LetterTwoCounter");
        letter3Counter = PlayerPrefs.GetInt("LetterTreeCounter");

        mailBoxExitImage.enabled = true;
        mailBoxExit.enabled = true;
        mailBoxBackground.enabled = true;

        if(greyBootsOwned==true && 
            greyGlassesOwned==true &&
            greyJacketOwned==true && 
            greyHatOwned==true && 
            letter1Counter == 0)
        {
            letter1Button.enabled = true;
            letter1ButtonImage.enabled = true;
        }
        else if (letter1Counter != 0)
        {
            letter1Button.enabled = false;
            letter1ButtonImage.enabled = false;
        }

        if (whiteBootsOwned == true &&
            whiteGlassesOwned == true && 
            whiteJacketOwned == true && 
            whiteHatOwned == true && 
            letter2Counter ==0)
        {
            letter2Button.enabled = true;
            letter2ButtonImage.enabled = true;         
        }
        else if (letter2Counter !=0)
        {
            letter2Button.enabled = false;
            letter2ButtonImage.enabled = false;
        }

        if(redBootsOwned==true &&
           redGlassesOwned==true &&
           redJacketOwned==true &&
           redHatOwned==true)
        {
            letter3Button.enabled = true;
            letter3ButtonImage.enabled = true;
        }
        else if(letter3Counter != 0)
        {
            letter3Button.enabled = false;
            letter3ButtonImage.enabled = false;
        }
    }

    void ReadLetter1()
    {
        letter1.enabled = true;
        letter1Text.enabled = true;
        exitLetter1.enabled = true;
        exitLetter1Image.enabled = true;
        letter1Counter++;
        PlayerPrefs.SetInt("LetterOneCounter", letter1Counter);

        letter1Button.enabled = false;
        letter1ButtonImage.enabled = false;
    }

    void ExitLetter1()
    { 

        exitLetter1.enabled = false;
        exitLetter1Image.enabled = false;
        letter1.enabled = false;
        letter1Text.enabled = false;
        letter1Button.enabled = false;
        letter1ButtonImage.enabled = false;   

        if(letter2Counter==0)
        {
            letter2Button.enabled = true;
            letter2ButtonImage.enabled = true;
        }
        else if (letter2Counter !=0)
        {
            letter2Button.enabled = false;
            letter2ButtonImage.enabled = false;
        }
    }

    void ReadLetter2()
    {
        letter2.enabled = true;
        letter2Text.enabled = true;
        exitLetter2.enabled = true;
        exitLetter2Image.enabled = true;
        letter2Counter++;
        PlayerPrefs.SetInt("LetterTwoCounter", letter2Counter);

        letter2Button.enabled = false;
        letter2ButtonImage.enabled = false;
    }

    void ExitLetter2()
    {
        exitLetter2.enabled = false;
        exitLetter2Image.enabled = false;
        letter2.enabled = false;
        letter2Text.enabled = false;
        letter2Button.enabled = false;
        letter2ButtonImage.enabled = false;

        if(letter2Counter == 0)
        {
            letter2Button.enabled = true;
            letter2ButtonImage.enabled = true;
        }
        else if(letter2Counter != 0)
        {
            letter2Button.enabled = false;
            letter2ButtonImage.enabled = false;
        }
    }

    void ReadLetter3()
    {
        letter3.enabled = true;
        letter3Text.enabled = true;
        exitLetter3.enabled = true;
        exitLetter3Image.enabled = true;
        letter3Counter++;
        PlayerPrefs.SetInt("LetterTreeCounter", letter3Counter);

        letter3Button.enabled = false;
        letter3ButtonImage.enabled = false;
    }

    void ExitLetter3()
    {
        exitLetter3.enabled = false;
        exitLetter3Image.enabled = false;
        letter3.enabled = false;
        letter3Text.enabled = false;
        letter3Button.enabled = false;
        letter3ButtonImage.enabled = false;

        if (letter3Counter == 0)
        {
            letter1Button.enabled = true;
            letter1ButtonImage.enabled = true;
        }
        else if (letter3Counter != 0)
        {
            letter3Button.enabled = false;
            letter3ButtonImage.enabled = false;
        }
    }
}
