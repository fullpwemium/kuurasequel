using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GlassesPageControl : MonoBehaviour {

    int greyGlassesCounter, orangeGlassesCounter, redGlassesCounter, greenGlassesCounter, whiteGlassesCounter;
    int greyGlassesBought, orangeGlassesBought, redGlassesBought, greenGlassesBought, whiteGlassesBought;

    public Button GreyGlasses, OrangeGlasses, RedGlasses, GreenGlasses, WhiteGlasses;

    public Button GlassesControlButton;

    public Image ownsGreyGlasses, ownsOrangeGlasses, ownsRedGlasses, ownsGreenGlasses, ownsWhiteGlasses;
    public GameObject GreyGlassesPrice, OrangeGlassesPrice, RedGlassesPrice, GreenGlassesPrice, WhiteGlassesPrice;

    public bool ownsGreyGlassesBool, ownsOrangeGlassesBool, ownsRedGlassesBool, ownsGreenGlassesBool, ownsWhiteGlassesBool;
    public bool buyGreyGlasses, buyOrangeGlasses, buyRedGlasses, buyGreenGlasses, buyWhiteGlasses;

    public Button yesBuyButton, noBuyButton;
    public Text confirmText;
    public Text yesText, noText;
    public Button buyConfirmButton;
    public Image buyConfirm;
    public Image background;

    public int dustAmount;

    int glassesPrice;

    void Awake()
    {
        //Setting the glasses price
        glassesPrice = 300;
    }

    // Use this for initialization
    void Start ()
    {
        GreyGlasses.onClick.AddListener(BuyGreyGlasses);
        OrangeGlasses.onClick.AddListener(BuyOrangeGlasses);
        RedGlasses.onClick.AddListener(BuyRedGlasses);
        GreenGlasses.onClick.AddListener(BuyGreenGlasses);
        WhiteGlasses.onClick.AddListener(BuyWhiteGlasses);

        //Makes the confirmation text for the buttons to be false
        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;
        buyConfirmButton.enabled = false;
        buyConfirm.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        GlassesControlButton.enabled = false;
        GlassesControlButton.GetComponent<Image>().enabled = false;

        GreyGlasses.enabled = true;
        GreyGlasses.GetComponent<Image>().enabled = true;

        OrangeGlasses.enabled = true;
        OrangeGlasses.GetComponent<Image>().enabled = true;

        RedGlasses.enabled = true;
        RedGlasses.GetComponent<Image>().enabled = true;

        GreenGlasses.enabled = true;
        GreenGlasses.GetComponent<Image>().enabled = true;

        WhiteGlasses.enabled = true;
        WhiteGlasses.GetComponent<Image>().enabled = true;

        buyGreyGlasses = false;
        buyOrangeGlasses = false;
        buyRedGlasses = false;
        buyGreenGlasses = false;
        buyWhiteGlasses = false;

        ownsGreyGlassesBool = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyGlassesOwned;
        ownsOrangeGlassesBool = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeGlassesOwned;
        ownsRedGlassesBool = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedGlassesOwned;
        ownsGreenGlassesBool = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenGlassesOwned;
        ownsWhiteGlassesBool = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteGlassesOwned;

        greyGlassesBought = PlayerPrefs.GetInt("greyGlassesOwned");
        orangeGlassesBought = PlayerPrefs.GetInt("orangeGlassesOwned");
        redGlassesBought = PlayerPrefs.GetInt("redGlassesOwned");
        greenGlassesBought = PlayerPrefs.GetInt("greenGlassesOwned");
        whiteGlassesBought = PlayerPrefs.GetInt("whiteGlassesOwned");
    }
	
	// Update is called once per frame
	void Update ()
    {
        dustAmount = GameObject.Find("ShopBook").GetComponent<DustController>().DustAmount;

        //Checks if you own grey glasses
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyGlassesOwned == true || greyGlassesBought == 1)
        {
            //disables the button and the price of grey glasses
            ownsGreyGlasses.enabled = true;
            GreyGlasses.enabled = false;
            GreyGlassesPrice.SetActive(false);
        }
        else if (ownsGreyGlassesBool == false || greyGlassesBought == 0)
        {
            //activates the button and the price of the glasses
            ownsGreyGlasses.enabled = false;
            GreyGlasses.enabled = true;
            GreyGlassesPrice.SetActive(true);
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyGlassesOwned = false;
        }

        //Checks if you own orange glasses
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeGlassesOwned == true || orangeGlassesBought == 1)
        {
            //disables the button and the price of orange glasses
            ownsOrangeGlasses.enabled = true;
            OrangeGlasses.enabled = false;
            OrangeGlassesPrice.SetActive(false);
        }
        else if (ownsOrangeGlassesBool == false || orangeGlassesBought == 0)
        {
            //activates the button and the price of orange glasses
            ownsOrangeGlasses.enabled = false;
            OrangeGlasses.enabled = true;
            OrangeGlassesPrice.SetActive(true);
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeGlassesOwned = false;
        }

        //Checks if you own red glasses
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedGlassesOwned == true || redGlassesBought == 1)
        {
            //disables the button and the price of red glasses
            ownsRedGlasses.enabled = true;
            RedGlasses.enabled = false;
            RedGlassesPrice.SetActive(false);
        }
        else if (ownsRedGlassesBool == false || redGlassesBought == 0)
        {
            //activates the button and the price of red glasses
            ownsRedGlasses.enabled = false;
            RedGlasses.enabled = true;
            RedGlassesPrice.SetActive(true);
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedGlassesOwned = false;
        }

        //Checks if you own green glasses
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenGlassesOwned == true || greenGlassesBought == 1)
        {
            //disables the button and the price of green glasses
            ownsGreenGlasses.enabled = true;
            GreenGlasses.enabled = false;
            GreenGlassesPrice.SetActive(false);
        }
        else if (ownsGreenGlassesBool == false || greenGlassesBought == 0)
        {
            //activates the button and the price of the green glasses
            ownsGreenGlasses.enabled = false;
            GreenGlasses.enabled = true;
            GreenGlassesPrice.SetActive(true);
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenGlassesOwned = false;
        }

        //Checks if you own white glasses
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteGlassesOwned == true || whiteGlassesBought == 1)
        {
            //disables the button and the price of white glasses
            ownsWhiteGlasses.enabled = true;
            WhiteGlasses.enabled = false;
            WhiteGlassesPrice.SetActive(false);
        }
        else if (ownsWhiteGlassesBool == false || whiteGlassesBought == 0)
        {
            //activates the button and the price of white glasses
            ownsWhiteGlasses.enabled = false;
            WhiteGlasses.enabled = true;
            WhiteGlassesPrice.SetActive(true);
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteGlassesOwned = false;
        }

    }
    //--------------------------------------------------------------------------------------------------------------------------

    void BuyGreyGlasses()
    {
        //Removes the listeners that aren't needed
        yesBuyButton.onClick.RemoveAllListeners();
        noBuyButton.onClick.RemoveAllListeners();

        //Adding the correct listeners for the yes and no buttons
        yesBuyButton.onClick.AddListener(BuyGreyGlassesTrue);
        noBuyButton.onClick.AddListener(BuyGreyGlassesFalse);

        //disables the confirmation text from buying glasses
        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        //Checks how much dust the player has and then if it has enough dust, the item will become buyable
        if (dustAmount >= glassesPrice)
        {
            confirmText.enabled = true;
            yesText.enabled = true;
            noText.enabled = true;

            yesBuyButton.enabled = true;
            yesBuyButton.GetComponent<Image>().enabled = true;

            background.GetComponent<Image>().enabled = true;

            noBuyButton.enabled = true;
            noBuyButton.GetComponent<Image>().enabled = true;
        }
        else if (dustAmount < glassesPrice)
        {
            //tells to you if you dont have enough dust
            Debug.Log("You don't have enough magic dust");

            GameObject.Find("NotEnoughDust").GetComponent<NotEnoughDust>().Background.enabled = true;

            confirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;
        }
        Debug.Log("BuyGreyGlasses");
    }
    //--------------------------------------------------------------------------------------------------------------------------

    void BuyOrangeGlasses()
    {
        //Removes the listeners that aren't needed
        yesBuyButton.onClick.RemoveAllListeners();
        noBuyButton.onClick.RemoveAllListeners();

        //Adding the correct listeners for the yes and no buttons
        yesBuyButton.onClick.AddListener(BuyOrangeGlassesTrue);
        noBuyButton.onClick.AddListener(BuyOrangeGlassesFalse);

        //disables the confirmation text from buying glasses
        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        //Checks how much dust the player has and then if it has enough dust, the item will become buyable
        if (dustAmount >= glassesPrice)
        {
            confirmText.enabled = true;
            yesText.enabled = true;
            noText.enabled = true;

            yesBuyButton.enabled = true;
            yesBuyButton.GetComponent<Image>().enabled = true;

            background.GetComponent<Image>().enabled = true;

            noBuyButton.enabled = true;
            noBuyButton.GetComponent<Image>().enabled = true;
        }
        else if (dustAmount < glassesPrice)
        {
            //tells to you if you dont have enough dust
            Debug.Log("You don't have enough magic dust");

            GameObject.Find("NotEnoughDust").GetComponent<NotEnoughDust>().Background.enabled = true;

            confirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;
        }
        Debug.Log("BuyOrangeGlasses");
    }
    //--------------------------------------------------------------------------------------------------------------------------

    void BuyRedGlasses()
    {
        //Removes the listeners that aren't needed
        yesBuyButton.onClick.RemoveAllListeners();
        noBuyButton.onClick.RemoveAllListeners();

        //Adding the correct listeners for the yes and no buttons
        yesBuyButton.onClick.AddListener(BuyRedGlassesTrue);
        noBuyButton.onClick.AddListener(BuyRedGlassesFalse);

        //disables the confirmation text from buying glasses
        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        //Checks how much dust the player has and then if it has enough dust, the item will become buyable
        if (dustAmount >= glassesPrice)
        {
            confirmText.enabled = true;
            yesText.enabled = true;
            noText.enabled = true;

            yesBuyButton.enabled = true;
            yesBuyButton.GetComponent<Image>().enabled = true;

            background.GetComponent<Image>().enabled = true;

            noBuyButton.enabled = true;
            noBuyButton.GetComponent<Image>().enabled = true;
        }
        else if (dustAmount < glassesPrice)
        {
            //tells to you if you dont have enough dust
            Debug.Log("You don't have enough magic dust");

            GameObject.Find("NotEnoughDust").GetComponent<NotEnoughDust>().Background.enabled = true;

            confirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;
        }
        Debug.Log("BuyRedGlasses");
    }
    //--------------------------------------------------------------------------------------------------------------------------

    void BuyGreenGlasses()
    {
        //Removes the listeners that aren't needed
        yesBuyButton.onClick.RemoveAllListeners();
        noBuyButton.onClick.RemoveAllListeners();

        //Adding the correct listeners for the yes and no buttons
        yesBuyButton.onClick.AddListener(BuyGreenGlassesTrue);
        noBuyButton.onClick.AddListener(BuyGreenGlassesFalse);

        //disables the confirmation text from buying glasses
        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        //Checks how much dust the player has and then if it has enough dust, the item will become buyable
        if (dustAmount >= glassesPrice)
        {
            confirmText.enabled = true;
            yesText.enabled = true;
            noText.enabled = true;

            yesBuyButton.enabled = true;
            yesBuyButton.GetComponent<Image>().enabled = true;

            background.GetComponent<Image>().enabled = true;

            noBuyButton.enabled = true;
            noBuyButton.GetComponent<Image>().enabled = true;
        }
        else if (dustAmount < glassesPrice)
        {
            //tells to you if you dont have enough dust
            Debug.Log("You don't have enough magic dust");

            GameObject.Find("NotEnoughDust").GetComponent<NotEnoughDust>().Background.enabled = true;

            confirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;
        }
        Debug.Log("BuyGreenGlasses");
    }
    //--------------------------------------------------------------------------------------------------------------------------

    void BuyWhiteGlasses()
    {
        //Removes the listeners that aren't needed
        yesBuyButton.onClick.RemoveAllListeners();
        noBuyButton.onClick.RemoveAllListeners();

        //Adding the correct listeners for the yes and no buttons
        yesBuyButton.onClick.AddListener(BuyWhiteGlassesTrue);
        noBuyButton.onClick.AddListener(BuyWhiteGlassesFalse);

        //disables the confirmation text from buying glasses
        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        //Checks how much dust the player has and then if it has enough dust, the item will become buyable
        if (dustAmount >= glassesPrice)
        {
            confirmText.enabled = true;
            yesText.enabled = true;
            noText.enabled = true;

            yesBuyButton.enabled = true;
            yesBuyButton.GetComponent<Image>().enabled = true;

            background.GetComponent<Image>().enabled = true;

            noBuyButton.enabled = true;
            noBuyButton.GetComponent<Image>().enabled = true;
        }
        else if (dustAmount < glassesPrice)
        {
            //tells to you if you dont have enough dust
            Debug.Log("You don't have enough magic dust");

            GameObject.Find("NotEnoughDust").GetComponent<NotEnoughDust>().Background.enabled = true;

            confirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;
        }
        Debug.Log("BuyWhiteGlasses");
    }
    //--------------------------------------------------------------------------------------------------------------------------

    void BuyGreyGlassesTrue()
    {
        Debug.Log("BuyGreyGlassesTrue");
        GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().ShopSaveGreyGlassesOwned(true);

        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyGlassesOwned == true && greyGlassesCounter == 0)
        {
            greyGlassesCounter++;

            confirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;

            GreyGlasses.enabled = false;
            Debug.Log("You have bought grey glasses");

            GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(glassesPrice);

            GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();

            if (dustAmount < 1)
            {
                dustAmount = 0;
                GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
            }
        }
    }

    void BuyGreyGlassesFalse()
    {
        Debug.Log("BuyGreyGlassesFalse");
        ownsGreyGlassesBool = false;
        buyGreyGlasses = false;

        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;
    }
    //--------------------------------------------------------------------------------------------------------------------------

    void BuyOrangeGlassesTrue()
    {
        Debug.Log("BuyOrangeGlassesTrue");
        GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().ShopSaveOrangeGlassesOwned(true);

        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeGlassesOwned == true && orangeGlassesCounter == 0)
        {
            orangeGlassesCounter++;

            confirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;

            OrangeGlasses.enabled = false;
            Debug.Log("You have bought orange glasses");
            GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(glassesPrice);

            GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();

            if (dustAmount < 1)
            {
                dustAmount = 0;
                GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
            }
        }
    }

    void BuyOrangeGlassesFalse()
    {
        Debug.Log("BuyOrangeGlassesFalse");
        ownsOrangeGlassesBool = false;
        buyGreyGlasses = false;

        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;
    }
    //--------------------------------------------------------------------------------------------------------------------------

    void BuyRedGlassesTrue()
    {
        Debug.Log("BuyRedGlassesTrue");
        GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().ShopSaveRedGlassesOwned(true);

        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedGlassesOwned == true && redGlassesCounter == 0)
        {
            redGlassesCounter++;

            confirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;

            RedGlasses.enabled = false;
            Debug.Log("You have bought red glasses");
            GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(glassesPrice);

            GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();

            if (dustAmount < 1)
            {
                dustAmount = 0;
                GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
            }
        }
    }

    void BuyRedGlassesFalse()
    {
        Debug.Log("BuyRedGlassesFalse");
        ownsRedGlassesBool = false;
        buyRedGlasses = false;

        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;
    }
    //--------------------------------------------------------------------------------------------------------------------------

    void BuyGreenGlassesTrue()
    {
        Debug.Log("BuyGreenGlassesTrue");
        GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().ShopSaveGreenGlassesOwned(true);

        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenGlassesOwned == true && greenGlassesCounter == 0)
        {
            greenGlassesCounter++;

            confirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;

            GreenGlasses.enabled = false;
            Debug.Log("You have bought green glasses");

            GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(glassesPrice);

            GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();

            if (dustAmount < 1)
            {
                dustAmount = 0;
                GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
            }
        }
    }

    void BuyGreenGlassesFalse()
    {
        Debug.Log("BuyGreenGlassesFalse");
        ownsGreenGlassesBool = false;
        buyGreenGlasses = false;

        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;
    }
    //--------------------------------------------------------------------------------------------------------------------------

    void BuyWhiteGlassesTrue()
    {
        Debug.Log("BuyWhiteGlassesTrue");
        GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().ShopSaveWhiteGlassesOwned(true);

        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteGlassesOwned == true && whiteGlassesCounter == 0)
        {
            whiteGlassesCounter++;

            confirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;

            WhiteGlasses.enabled = false;
            Debug.Log("You have bought white glasses");
            GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(glassesPrice);

            if (dustAmount < 1)
            {
                dustAmount = 0;
                GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
            }
        }
    }

    void BuyWhiteGlassesFalse()
    {
        Debug.Log("BuyWhiteGlassesFalse");
        ownsWhiteGlassesBool = false;
        buyWhiteGlasses = false;

        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;
    }
}
