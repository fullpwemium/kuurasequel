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

    public Button letter4Button;
    public Image letter4ButtonImage;
    public Button exitLetter4;
    public Image exitLetter4Image;
    public Image letter4;
    public Text letter4Text;
    public int letter4Counter;

    public Button letter5Button;
    public Image letter5ButtonImage;
    public Button exitLetter5;
    public Image exitLetter5Image;
    public Image letter5;
    public Text letter5Text;
    public int letter5Counter;

    public Button letter6Button;
    public Image letter6ButtonImage;
    public Button exitLetter6;
    public Image exitLetter6Image;
    public Image letter6;
    public Text letter6Text;
    public int letter6Counter;

    int greyHatBought;
    int orangeHatBought;
    int redHatBought;
    int greenHatBought;
    int whiteHatBought;
    int blueHatBought;

    int greyJacketBought;
    int orangeJacketBought;
    int redJacketBought;
    int greenJacketBought;
    int whiteJacketBought;
    int blueJacketBought;

    int greyBootsBought;
    int orangeBootsBought;
    int redBootsBought;
    int greenBootsBought;
    int whiteBootsBought;
    int blueBootsBought;

    int greyGlassesBought;
    int orangeGlassesBought;
    int redGlassesBought;
    int greenGlassesBought;
    int whiteGlassesBought;
    int blueGlassesBought;



    // Use this for initialization
    void Start ()
    {
        //Gets value of the counter from the hard drive
        letter1Counter = PlayerPrefs.GetInt("LetterOneCounter");
        letter2Counter = PlayerPrefs.GetInt("LetterTwoCounter");
        letter3Counter = PlayerPrefs.GetInt("LetterThreeCounter");
        letter4Counter = PlayerPrefs.GetInt("LetterFourCounter");
        letter5Counter = PlayerPrefs.GetInt("LetterFiveCounter");
        letter6Counter = PlayerPrefs.GetInt("LetterSixCounter");

        mailBox.onClick.AddListener(OpenMailBox);
        mailBoxExit.onClick.AddListener(CloseMailBox);
        
        letter1Button.onClick.AddListener(ReadLetter1);
        exitLetter1.onClick.AddListener(ExitLetter1);

        letter2Button.onClick.AddListener(ReadLetter2);
        exitLetter2.onClick.AddListener(ExitLetter2);

        letter3Button.onClick.AddListener(ReadLetter3);
        exitLetter3.onClick.AddListener(ExitLetter3);

        letter4Button.onClick.AddListener(ReadLetter4);
        exitLetter4.onClick.AddListener(ExitLetter4);

        letter5Button.onClick.AddListener(ReadLetter5);
        exitLetter5.onClick.AddListener(ExitLetter5);

        letter6Button.onClick.AddListener(ReadLetter6);
        exitLetter6.onClick.AddListener(ExitLetter6);

        //Disables everything at start
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

        exitLetter4.enabled = false;
        exitLetter4Image.enabled = false;
        letter4.enabled = false;
        letter4Text.enabled = false;
        letter4Button.enabled = false;
        letter4ButtonImage.enabled = false;

        exitLetter5.enabled = false;
        exitLetter5Image.enabled = false;
        letter5.enabled = false;
        letter5Text.enabled = false;
        letter5Button.enabled = false;
        letter5ButtonImage.enabled = false;

        exitLetter6.enabled = false;
        exitLetter6Image.enabled = false;
        letter6.enabled = false;
        letter6Text.enabled = false;
        letter6Button.enabled = false;
        letter6ButtonImage.enabled = false;


    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    void CloseMailBox()
    {
       //closes the mailbox
        mailBoxExitImage.enabled = false;
        mailBoxExit.enabled = false;
        mailBoxBackground.enabled = false;

        letter1Button.enabled = false;
        letter1ButtonImage.enabled = false;

        letter2Button.enabled = false;
        letter2ButtonImage.enabled = false;

        letter3Button.enabled = false;
        letter3ButtonImage.enabled = false;

        letter4Button.enabled = false;
        letter4ButtonImage.enabled = false;

        letter5Button.enabled = false;
        letter5ButtonImage.enabled = false;

        letter6Button.enabled = false;
        letter6ButtonImage.enabled = false;
    }

    void OpenMailBox()
    {

        //Opens the mailbox

        //Gets the value of the hat bought from the hard drive
        greyHatBought = PlayerPrefs.GetInt("greyHatOwned");
        orangeHatBought = PlayerPrefs.GetInt("orangeHatOwned");
        redHatBought = PlayerPrefs.GetInt("redHatOwned");
        greenHatBought = PlayerPrefs.GetInt("greenHatOwned");
        whiteHatBought = PlayerPrefs.GetInt("whiteHatOwned");
        blueHatBought = PlayerPrefs.GetInt("blueHatOwned");

        //Gets the value of the jacket bought from the hard drive
        greyJacketBought = PlayerPrefs.GetInt("greyJacketOwned");
        orangeJacketBought = PlayerPrefs.GetInt("orangeJacketOwned");
        redJacketBought = PlayerPrefs.GetInt("redJacketOwned");
        greenJacketBought = PlayerPrefs.GetInt("greenJacketOwned");
        whiteJacketBought = PlayerPrefs.GetInt("whiteJacketOwned");
        blueJacketBought = PlayerPrefs.GetInt("blueJacketOwned");

        //Gets the value of the boots bought from the hard drive
        greyBootsBought = PlayerPrefs.GetInt("greyBootsOwned");
        orangeBootsBought = PlayerPrefs.GetInt("orangeBootsOwned");
        redBootsBought = PlayerPrefs.GetInt("redBootsOwned");
        greenBootsBought = PlayerPrefs.GetInt("greenBootsOwned");
        whiteBootsBought = PlayerPrefs.GetInt("whiteBootsOwned");
        blueBootsBought = PlayerPrefs.GetInt("blueBootsOwned");

        //Gets the value of the glasses bought from the hard drive
        greyGlassesBought = PlayerPrefs.GetInt("greyGlassesOwned");
        orangeGlassesBought = PlayerPrefs.GetInt("orangeGlassesOwned");
        redGlassesBought = PlayerPrefs.GetInt("redGlassesOwned");
        greenGlassesBought = PlayerPrefs.GetInt("greenGlassesOwned");
        whiteGlassesBought = PlayerPrefs.GetInt("whiteGlassesOwned");
        blueGlassesBought = PlayerPrefs.GetInt("blueGlassesOwned");

        letter1Counter = PlayerPrefs.GetInt("LetterOneCounter");
        letter2Counter = PlayerPrefs.GetInt("LetterTwoCounter");
        letter3Counter = PlayerPrefs.GetInt("LetterThreeCounter");
        letter4Counter = PlayerPrefs.GetInt("LetterFourCounter");
        letter5Counter = PlayerPrefs.GetInt("LetterFiveCounter");
        letter6Counter = PlayerPrefs.GetInt("LetterSixCounter");

        mailBoxExitImage.enabled = true;
        mailBoxExit.enabled = true;
        mailBoxBackground.enabled = true;

        //checks if you have bought all grey items
        if(greyBootsBought == 1 && 
            greyGlassesBought == 1 &&
            greyJacketBought == 1 && 
            greyHatBought == 1 && 
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

        //checks if you have bought all white items
        if (whiteBootsBought == 1 &&
            whiteGlassesBought == 1 && 
            whiteJacketBought == 1 && 
            whiteHatBought == 1 && 
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

        //checks if you have bought all red items
        if (redBootsBought==1 &&
           redGlassesBought==1 &&
           redJacketBought==1 &&
           redHatBought==1 && 
           letter3Counter == 0)
        {
            letter3Button.enabled = true;
            letter3ButtonImage.enabled = true;
        }
        else if(letter3Counter != 0)
        {
            letter3Button.enabled = false;
            letter3ButtonImage.enabled = false;
        }

        //checks if you have bought all orange items
        if (orangeBootsBought == 1 &&
            orangeGlassesBought == 1 &&
            orangeJacketBought == 1 &&
            orangeHatBought == 1 &&
            letter4Counter == 0)
        {
            letter4Button.enabled = true;
            letter4ButtonImage.enabled = true;
        }
        else if (letter4Counter != 0)
        {
            letter4Button.enabled = false;
            letter4ButtonImage.enabled = false;
        }

        //checks if you have bought all green items
        if (greenBootsBought == 1 &&
            greenGlassesBought == 1 &&
            greenJacketBought == 1 &&
            greenHatBought == 1 &&
            letter5Counter == 0)
        {
            letter5Button.enabled = true;
            letter5ButtonImage.enabled = true;
        }
        else if (letter5Counter != 0)
        {
            letter5Button.enabled = false;
            letter5ButtonImage.enabled = false;
        }

        //checks if you have bought all blue items
        if (blueBootsBought == 1 &&
            blueGlassesBought == 1 &&
            blueJacketBought == 1 &&
            blueHatBought == 1 &&
            letter6Counter == 0)
        {
            letter6Button.enabled = true;
            letter6ButtonImage.enabled = true;
        }
        else if (letter6Counter != 0)
        {
            letter6Button.enabled = false;
            letter6ButtonImage.enabled = false;
        }
    }

    //Opens letter1
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

    //closes letter1
    void ExitLetter1()
    { 

        exitLetter1.enabled = false;
        exitLetter1Image.enabled = false;
        letter1.enabled = false;
        letter1Text.enabled = false;
        letter1Button.enabled = false;
        letter1ButtonImage.enabled = false;   

        if(letter1Counter == 0)
        {
            letter1Button.enabled = true;
            letter1ButtonImage.enabled = true;
        }
        else if (letter1Counter !=0)
        {
            letter1Button.enabled = false;
            letter1ButtonImage.enabled = false;
        }
    }

    //Opens letter2
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

    //Closes letter2
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

    //Opens letter3
    void ReadLetter3()
    {
        letter3.enabled = true;
        letter3Text.enabled = true;
        exitLetter3.enabled = true;
        exitLetter3Image.enabled = true;
        letter3Counter++;
        PlayerPrefs.SetInt("LetterThreeCounter", letter3Counter);

        letter3Button.enabled = false;
        letter3ButtonImage.enabled = false;
    }

    //Closes letter3
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
            letter3Button.enabled = true;
            letter3ButtonImage.enabled = true;
        }
        else if (letter3Counter != 0)
        {
            letter3Button.enabled = false;
            letter3ButtonImage.enabled = false;
        }
    }

    //Opens letter4
    void ReadLetter4()
    {
        letter4.enabled = true;
        letter4Text.enabled = true;
        exitLetter4.enabled = true;
        exitLetter4Image.enabled = true;
        letter4Counter++;
        PlayerPrefs.SetInt("LetterFourCounter", letter4Counter);

        letter4Button.enabled = false;
        letter4ButtonImage.enabled = false;
    }

    //Closes letter4
    void ExitLetter4()
    {
        exitLetter4.enabled = false;
        exitLetter4Image.enabled = false;
        letter4.enabled = false;
        letter4Text.enabled = false;
        letter4Button.enabled = false;
        letter4ButtonImage.enabled = false;

        if (letter4Counter == 0)
        {
            letter4Button.enabled = true;
            letter4ButtonImage.enabled = true;
        }
        else if (letter4Counter != 0)
        {
            letter4Button.enabled = false;
            letter4ButtonImage.enabled = false;
        }
    }
    
    //Opens letter5
    void ReadLetter5()
    {
        letter5.enabled = true;
        letter5Text.enabled = true;
        exitLetter5.enabled = true;
        exitLetter5Image.enabled = true;
        letter5Counter++;
        PlayerPrefs.SetInt("LetterFiveCounter", letter5Counter);

        letter5Button.enabled = false;
        letter5ButtonImage.enabled = false;
    }

    //Closes letter5
    void ExitLetter5()
    {
        exitLetter5.enabled = false;
        exitLetter5Image.enabled = false;
        letter5.enabled = false;
        letter5Text.enabled = false;
        letter5Button.enabled = false;
        letter5ButtonImage.enabled = false;

        if (letter5Counter == 0)
        {
            letter5Button.enabled = true;
            letter5ButtonImage.enabled = true;
        }
        else if (letter5Counter != 0)
        {
            letter5Button.enabled = false;
            letter5ButtonImage.enabled = false;
        }
    }

    //Opens letter6
    void ReadLetter6()
    {
        letter6.enabled = true;
        letter6Text.enabled = true;
        exitLetter6.enabled = true;
        exitLetter6Image.enabled = true;
        letter6Counter++;
        PlayerPrefs.SetInt("LetterSixCounter", letter6Counter);

        letter6Button.enabled = false;
        letter6ButtonImage.enabled = false;
        
    }

    //Closes letter6
    void ExitLetter6()
    {
        exitLetter6.enabled = false;
        exitLetter6Image.enabled = false;
        letter6.enabled = false;
        letter6Text.enabled = false;
        letter6Button.enabled = false;
        letter6ButtonImage.enabled = false;

        if (letter6Counter == 0)
        {
            letter6Button.enabled = true;
            letter6ButtonImage.enabled = true;
        }
        else if (letter6Counter != 0)
        {
            letter6Button.enabled = false;
            letter6ButtonImage.enabled = false;
        }
    }
}
