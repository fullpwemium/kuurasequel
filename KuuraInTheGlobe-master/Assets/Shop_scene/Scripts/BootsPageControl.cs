using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BootsPageControl : MonoBehaviour {

    int greyBootsCounter, orangeBootsCounter, redBootsCounter, greenBootsCounter, whiteBootsCounter, blueBootsCounter;
    int greyBootsBought, orangeBootsBought, redBootsBought, greenBootsBought, whiteBootsBought, blueBootsBought;

    public Button GreyBoots, OrangeBoots, RedBoots, GreenBoots, WhiteBoots, BlueBoots;

    public Button BootsControlButton;

    public Button yesBuyButton, noBuyButton;
    public Text confirmText;
    public Text yesText, noText;
    public Button buyConfirmButton;
    public Image buyConfirm;
    public Image background;
    //public AudioClip yes;
    //public AudioClip no;
    //AudioSource audio;

    public Image ownsGreyBoots, ownsOrangeBoots, ownsRedBoots, ownsGreenBoots, ownsWhiteBoots, ownsBlueBoots;
    public GameObject GreyBootsPrice, OrangeBootsPrice, RedBootsPrice, GreenBootsPrice, WhiteBootsPrice, BlueBootsPrice;

    public bool ownsGreyBootsBool, ownsOrangeBootsBool, ownsRedBootsBool, ownsGreenBootsBool, ownsWhiteBootsBool, ownsBlueBootsBool;
    public bool buyGreyBoots, buyOrangeBoots, buyRedBoots, buyGreenBoots, buyWhiteBoots, buyBlueBoots;
    public int dustAmount;

    int greyBootsPrice;
    int whiteBootsPrice;
    int orangeBootsPrice;
    int redBootsPrice;
    int greenBootsPrice;
    int blueBootsPrice;

    void Awake()
    {
        //setting boots prices
        greyBootsPrice = 300;
        whiteBootsPrice = 300;
        orangeBootsPrice = 500;
        redBootsPrice = 500;
        greenBootsPrice = 800;
        blueBootsPrice = 800;
    }

    // Use this for initialization
    void Start ()
    {
        //Making boots buyable
        GreyBoots.onClick.AddListener(BuyGreyBoots);
        OrangeBoots.onClick.AddListener(BuyOrangeBoots);
        RedBoots.onClick.AddListener(BuyRedBoots);
        GreenBoots.onClick.AddListener(BuyGreenBoots);
        WhiteBoots.onClick.AddListener(BuyWhiteBoots);
        BlueBoots.onClick.AddListener(BuyBlueBoots);

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

        BootsControlButton.enabled = false;
        BootsControlButton.GetComponent<Image>().enabled = false;

        GreyBoots.enabled = true;
        GreyBoots.GetComponent<Image>().enabled = true;

        OrangeBoots.enabled = true;
        OrangeBoots.GetComponent<Image>().enabled = true;

        RedBoots.enabled = true;
        RedBoots.GetComponent<Image>().enabled = true;

        GreenBoots.enabled = true;
        GreenBoots.GetComponent<Image>().enabled = true;

        WhiteBoots.enabled = true;
        WhiteBoots.GetComponent<Image>().enabled = true;

        BlueBoots.enabled = true;
        BlueBoots.GetComponent<Image>().enabled = true;

        buyGreyBoots = false;
        buyOrangeBoots = false;
        buyRedBoots = false;
        buyGreenBoots = false;
        buyWhiteBoots = false;
        buyBlueBoots = false;

        ownsGreyBootsBool = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyBootsOwned;
        ownsOrangeBootsBool = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeBootsOwned;
        ownsRedBootsBool = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedBootsOwned;
        ownsGreenBootsBool = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenBootsOwned;
        ownsWhiteBootsBool = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteBootsOwned;
        ownsBlueBootsBool = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().BlueBootsOwned;

        //Gets the value of the boots bought from the hard drive
        greyBootsBought = PlayerPrefs.GetInt("greyBootsOwned");
        orangeBootsBought = PlayerPrefs.GetInt("orangeBootsOwned");
        redBootsBought = PlayerPrefs.GetInt("redBootsOwned");
        greenBootsBought = PlayerPrefs.GetInt("greenBootsOwned");
        whiteBootsBought = PlayerPrefs.GetInt("whiteBootsOwned");
        blueBootsBought = PlayerPrefs.GetInt("blueBootsOwned");

        //gets audiosource for yes and no buttons
        //audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        dustAmount = GameObject.Find("ShopBook").GetComponent<DustController>().DustAmount;

        //cheks if you own the grey boots
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyBootsOwned == true || greyBootsBought == 1)
        {
            //disables the buttons and the price of the boots
            ownsGreyBoots.enabled = true;
            GreyBoots.enabled = false;
            GreyBootsPrice.SetActive(false);
        }
        else if (ownsGreyBootsBool == false || greyBootsBought == 0)
        {
            //activates the button and the price of the boots
            ownsGreyBoots.enabled = false;
            GreyBoots.enabled = true;
            GreyBootsPrice.SetActive(true);
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyBootsOwned = false;
        }

        //cheks if you own the orange boots
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeBootsOwned == true || orangeBootsBought == 1)
        {
            //disables the buttons and the price of the boots
            ownsOrangeBoots.enabled = true;
            OrangeBoots.enabled = false;
            OrangeBootsPrice.SetActive(false);
        }
        else if (ownsOrangeBootsBool == false || orangeBootsBought == 0)
        {
            //activates the button and the price of the boots
            ownsOrangeBoots.enabled = false;
            OrangeBoots.enabled = true;
            OrangeBootsPrice.SetActive(true);
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeBootsOwned = false;
        }

        //cheks if you own the red boots
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedBootsOwned == true || redBootsBought == 1)
        {
            //disables the buttons and the price of the boots
            ownsRedBoots.enabled = true;
            RedBoots.enabled = false;
            RedBootsPrice.SetActive(false);
        }
        else if (ownsRedBootsBool == false || redBootsBought == 0)
        {
            //activates the button and the price of the boots
            ownsRedBoots.enabled = false;
            RedBoots.enabled = true;
            RedBootsPrice.SetActive(true);
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedBootsOwned = false;
        }

        //cheks if you own the green boots
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenBootsOwned == true || greenBootsBought == 1)
        {
            //disables the buttons and the price of the boots
            ownsGreenBoots.enabled = true;
            GreenBoots.enabled = false;
            GreenBootsPrice.SetActive(false);
        }
        else if (ownsGreenBootsBool == false || greenBootsBought == 0)
        {
            //activates the button and the price of the boots
            ownsGreenBoots.enabled = false;
            GreenBoots.enabled = true;
            GreenBootsPrice.SetActive(true);
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenBootsOwned = false;
        }

        //cheks if you own the white boots
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteBootsOwned == true || whiteBootsBought == 1)
        {
            //disables the buttons and the price of the boots
            ownsWhiteBoots.enabled = true;
            WhiteBoots.enabled = false;
            WhiteBootsPrice.SetActive(false);
        }
        else if (ownsWhiteBootsBool == false || whiteBootsBought == 0)
        {
            //activates the button and the price of the boots
            ownsWhiteBoots.enabled = false;
            WhiteBoots.enabled = true;
            WhiteBootsPrice.SetActive(true);
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteBootsOwned = false;
        }

        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().BlueBootsOwned == true || blueBootsBought == 1)
        {
            //disables the buttons and the price of the boots
            ownsBlueBoots.enabled = true;
            BlueBoots.enabled = false;
            BlueBootsPrice.SetActive(false);
        }
        else if (ownsBlueBootsBool == false || blueBootsBought == 0)
        {
            //activates the button and the price of the boots
            ownsBlueBoots.enabled = false;
            BlueBoots.enabled = true;
            BlueBootsPrice.SetActive(true);
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().BlueBootsOwned = false;
        }
    }
    //--------------------------------------------------------------------------------------------------------------------------

    void BuyGreyBoots()
    {
        //Removes the listeners that aren't needed
        yesBuyButton.onClick.RemoveAllListeners();
        noBuyButton.onClick.RemoveAllListeners();

        //adding the right listeners for yes and no buttons
        yesBuyButton.onClick.AddListener(BuyGreyBootsTrue);
        noBuyButton.onClick.AddListener(BuyGreyBootsFalse);

        //disables the confirmation text from buying boots
        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        //Checks how much dust the player has and then if it has enough dust, the item will become buyable
        if (dustAmount >= greyBootsPrice)
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
        else if (dustAmount < greyBootsPrice)
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
        Debug.Log("GreyBoots");
    }
    //--------------------------------------------------------------------------------------------------------------------------

    void BuyOrangeBoots()
    {
        //Removes the listeners that aren't needed
        yesBuyButton.onClick.RemoveAllListeners();
        noBuyButton.onClick.RemoveAllListeners();

        //adding the right listeners for yes and no buttons
        yesBuyButton.onClick.AddListener(BuyOrangeBootsTrue);
        noBuyButton.onClick.AddListener(BuyOrangeBootsFalse);

        //disables the confirmation text from buying boots
        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        //Checks how much dust the player has and then if it has enough dust, the item will become buyable
        if (dustAmount >= orangeBootsPrice)
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
        else if (dustAmount < orangeBootsPrice)
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
        Debug.Log("OrangeBoots");
    }

    //--------------------------------------------------------------------------------------------------------------------------

    void BuyRedBoots()
    {
        //Removes the listeners that aren't needed
        yesBuyButton.onClick.RemoveAllListeners();
        noBuyButton.onClick.RemoveAllListeners();

        //adding the right listeners for yes and no buttons
        yesBuyButton.onClick.AddListener(BuyRedBootsTrue);
        noBuyButton.onClick.AddListener(BuyRedBootsFalse);

        //disables the confirmation text from buying boots
        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        //Checks how much dust the player has and then if it has enough dust, the item will become buyable
        if (dustAmount >= redBootsPrice)
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
        else if (dustAmount < redBootsPrice)
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
        Debug.Log("RedBoots");
    }
    //--------------------------------------------------------------------------------------------------------------------------

    void BuyGreenBoots()
    {
        //Removes the listeners that aren't needed
        yesBuyButton.onClick.RemoveAllListeners();
        noBuyButton.onClick.RemoveAllListeners();

        //adding the right listeners for yes and no buttons
        yesBuyButton.onClick.AddListener(BuyGreenBootsTrue);
        noBuyButton.onClick.AddListener(BuyGreenBootsFalse);

        //disables the confirmation text from buying boots
        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        //Checks how much dust the player has and then if it has enough dust, the item will become buyable
        if (dustAmount >= greenBootsPrice)
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
        else if (dustAmount < greenBootsPrice)
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
        Debug.Log("GreenBoots");
    }
    //--------------------------------------------------------------------------------------------------------------------------

    void BuyWhiteBoots()
    {
        //Removes the listeners that aren't needed
        yesBuyButton.onClick.RemoveAllListeners();
        noBuyButton.onClick.RemoveAllListeners();

        //adding the right listeners for yes and no buttons
        yesBuyButton.onClick.AddListener(BuyWhiteBootsTrue);
        noBuyButton.onClick.AddListener(BuyWhiteBootsFalse);

        //disables the confirmation text from buying boots
        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        //Checks how much dust the player has and then if it has enough dust, the item will become buyable
        if (dustAmount >= whiteBootsPrice)
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
        else if (dustAmount < whiteBootsPrice)
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
        Debug.Log("WhiteBoots");
    }
    //--------------------------------------------------------------------------------------------------------------------------

    void BuyBlueBoots()
    {
        //Removes the listeners that aren't needed
        yesBuyButton.onClick.RemoveAllListeners();
        noBuyButton.onClick.RemoveAllListeners();

        //adding the right listeners for yes and no buttons
        yesBuyButton.onClick.AddListener(BuyBlueBootsTrue);
        noBuyButton.onClick.AddListener(BuyBlueBootsFalse);

        //disables the confirmation text from buying boots
        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        //Checks how much dust the player has and then if it has enough dust, the item will become buyable
        if (dustAmount >= blueBootsPrice)
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
        else if (dustAmount < blueBootsPrice)
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
        Debug.Log("BlueBoots");
    }
    //--------------------------------------------------------------------------------------------------------------------------

    void BuyGreyBootsTrue()
    {
        Debug.Log("BuyGreyBootsTrue");
        GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().ShopSaveGreyBootsOwned(true);

        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyBootsOwned == true && greyBootsCounter == 0)
        {
            //audio.PlayOneShot(yes);

            greyBootsCounter++;

            confirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;

            GreyBoots.enabled = false;
            Debug.Log("You have bought Greyboots");
            GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(greyBootsPrice);

            GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();

            if (dustAmount < 1)
            {
                dustAmount = 0;
                GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
            }
        }
    }

    void BuyGreyBootsFalse()
    {
        //audio.PlayOneShot(no);

        Debug.Log("BuyGreyBootsFalse");
        ownsGreyBootsBool = false;
        buyGreyBoots = false;

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

    void BuyOrangeBootsTrue()
    {
        //audio.PlayOneShot(yes);

        Debug.Log("BuyOrangeBootsTrue");
        GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().ShopSaveOrangeBootsOwned(true);

        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeBootsOwned == true && orangeBootsCounter == 0)
        {
            orangeBootsCounter++;

            confirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;

            OrangeBoots.enabled = false;
            Debug.Log("You have bought Orangeboots");
            GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(orangeBootsPrice);

            GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();

            if (dustAmount < 1)
            {
                dustAmount = 0;
                GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
            }
        }
    }

    void BuyOrangeBootsFalse()
    {
        //audio.PlayOneShot(no);

        Debug.Log("BuyOrangeBootsFalse");
        ownsOrangeBootsBool = false;
        buyOrangeBoots = false;

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

    void BuyRedBootsTrue()
    {
        //audio.PlayOneShot(yes);

        Debug.Log("BuyRedBootsTrue");
        GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().ShopSaveRedBootsOwned(true);

        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedBootsOwned == true && redBootsCounter == 0)
        {
            redBootsCounter++;

            confirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;

            RedBoots.enabled = false;
            Debug.Log("You have bought Redboots");
            GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(redBootsPrice);

            GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();

            if (dustAmount < 1)
            {
                dustAmount = 0;
                GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
            }
        }
    }

    void BuyRedBootsFalse()
    {
        //audio.PlayOneShot(no);

        Debug.Log("BuyRedBootsFalse");
        ownsRedBootsBool = false;
        buyRedBoots = false;

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

    void BuyGreenBootsTrue()
    {
        //audio.PlayOneShot(yes);

        Debug.Log("BuyGreenBootsTrue");
        GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().ShopSaveGreenBootsOwned(true);

        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenBootsOwned == true && greenBootsCounter == 0)
        {
            greenBootsCounter++;

            confirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;

            GreenBoots.enabled = false;
            Debug.Log("You have bought Greenboots");
            GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(greenBootsPrice);

            GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();

            if (dustAmount < 1)
            {
                dustAmount = 0;
                GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
            }
        }
    }

    void BuyGreenBootsFalse()
    {
        //audio.PlayOneShot(no);

        Debug.Log("BuyGreenBootsFalse");
        ownsGreenBootsBool = false;
        buyGreenBoots = false;

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

    void BuyWhiteBootsTrue()
    {
        //audio.PlayOneShot(yes);

        Debug.Log("BuyWhiteBootsTrue");
        GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().ShopSaveWhiteBootsOwned(true);

        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteBootsOwned == true && whiteBootsCounter == 0)
        {
            whiteBootsCounter++;

            confirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;

            WhiteBoots.enabled = false;
            Debug.Log("You have bought Whiteboots");
            GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(whiteBootsPrice);

            GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();

            if (dustAmount < 1)
            {
                dustAmount = 0;
                GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
            }
        }
    }

    void BuyWhiteBootsFalse()
    {
        //audio.PlayOneShot(no);

        Debug.Log("BuyWhiteBootsFalse");
        ownsWhiteBootsBool = false;
        buyWhiteBoots = false;

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

    void BuyBlueBootsTrue()
    {
        //audio.PlayOneShot(yes);

        Debug.Log("BuyBlueBootsTrue");
        GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().ShopSaveBlueBootsOwned(true);

        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().BlueBootsOwned == true && blueBootsCounter == 0)
        {
            blueBootsCounter++;

            confirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;

            BlueBoots.enabled = false;
            Debug.Log("You have bought Blueboots");
            GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(blueBootsPrice);

            GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();

            if (dustAmount < 1)
            {
                dustAmount = 0;
                GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
            }
        }
    }

    void BuyBlueBootsFalse()
    {
        //audio.PlayOneShot(no);

        Debug.Log("BuyBlueBootsFalse");
        ownsBlueBootsBool = false;
        buyBlueBoots = false;

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

}
