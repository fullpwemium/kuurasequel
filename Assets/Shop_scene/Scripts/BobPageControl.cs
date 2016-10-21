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
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyHatOwned == true)
        {
            greyHat.enabled = true;           
        }

        //Checks if the Orange hat is owned
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeHatOwned == true)
        {
            orangeHat.enabled = true;
        }

        //Checks if the Red hat is owned
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedHatOwned == true)
        {
            redHat.enabled = true;
        }

        //Checks if the Green hat is owned
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenHatOwned == true)
        {
            greenHat.enabled = true;
        }

        //Checks if the White hat is owned
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteHatOwned == true)
        {
            whiteHat.enabled = true;
        }
	}
}
