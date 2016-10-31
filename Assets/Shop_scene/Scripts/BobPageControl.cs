using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BobPageControl : MonoBehaviour {

    public bool ownsGreyHat;
    public bool ownsOrangeHat;
    public bool ownsRedHat;
    public bool ownsGreenHat;
    public bool ownsWhiteHat;

    public Image greyHat;
    public Image orangeHat;
    public Image redHat;
    public Image greenHat;
    public Image whiteHat;

    int greyHatBought;
    int orangeHatBought;
    int redHatBought;
    int greenHatBought;
    int whiteHatBought;

    void Awake()
    {
        greyHat.enabled = false;
        orangeHat.enabled = false;
        redHat.enabled = false;
        greenHat.enabled = false;
        whiteHat.enabled = false;

        //Checks the values of GlobalGameManager script GreyHatOwned, OrangeHatOwned, RedHatOwned, GreenHatOwned, WhiteHatOwned and saves them to these booleans
        ownsGreyHat = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyHatOwned;
        ownsOrangeHat = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeHatOwned;
        ownsRedHat = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedHatOwned;
        ownsGreenHat = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenHatOwned;
        ownsWhiteHat = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteHatOwned;
    }
	// Use this for initialization
	void Start ()
    {
        //Gets the value of the hat bought from the hard drive
        greyHatBought = PlayerPrefs.GetInt("greyHatOwned");
        orangeHatBought = PlayerPrefs.GetInt("orangeHatOwned");
        redHatBought = PlayerPrefs.GetInt("redHatOwned");
        greenHatBought = PlayerPrefs.GetInt("greenHatOwned");
        whiteHatBought = PlayerPrefs.GetInt("whiteHatOwned");
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Checks the values of GlobalGameManager script GreyHatOwned, OrangeHatOwned, RedHatOwned, GreenHatOwned, WhiteHatOwned and saves them to these booleans
        ownsGreyHat = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyHatOwned;
        ownsOrangeHat = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeHatOwned;
        ownsRedHat = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedHatOwned;
        ownsGreenHat = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenHatOwned;
        ownsWhiteHat = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteHatOwned;


        //Checks if the Grey hat is owned
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyHatOwned == true || greyHatBought == 1)
        {
            greyHat.enabled = true;
        }
        else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyHatOwned == false || greyHatBought == 0)
        {
            greyHat.enabled = false;
        }

        //Checks if the Orange hat is owned
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeHatOwned == true || orangeHatBought == 1)
        {
            orangeHat.enabled = true;
        }
        else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeHatOwned == false || orangeHatBought == 0)
        {
            orangeHat.enabled = false;
        }

        //Checks if the Red hat is owned
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedHatOwned == true || redHatBought == 1)
        {
            redHat.enabled = true;
        }
        else if(GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedHatOwned == false || redHatBought == 0)
        {
            redHat.enabled = false;
        }

        //Checks if the Green hat is owned
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenHatOwned == true || greenHatBought == 1)
        {
            greenHat.enabled = true;
        }
        else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenHatOwned == false || greenHatBought == 0)
        {
            greenHat.enabled = false;
        }

         //Checks if the White hat is owned
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteHatOwned == true || whiteHatBought == 1)
        {
            whiteHat.enabled = true;
        }
        else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteHatOwned == false || whiteHatBought == 0)
        {
            whiteHat.enabled = false;
        }
    }
}
