using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JacketPageControl : MonoBehaviour {

    int greyJacketCounter, orangeJacketCounter, redJacketCounter, greenJacketCounter, whiteJacketCounter, blueJacketCounter;
    int greyJacketBought, orangeJacketBought, redJacketBought, greenJacketBought, whiteJacketBought, blueJacketBought;

    public Button GreyJacket, OrangeJacket, RedJacket, GreenJacket, WhiteJacket, BlueJacket;
    public Button JacketControlButton;
    public Button yesBuyButton, noBuyButton;
    public Text confirmText;
    public Text yesText, noText;
    public Button buyConfirmButton;
    public Image buyConfirm;
    public Image background;
    public AudioClip yes;
    public AudioClip no;
    AudioSource audio;

    public Image ownsGreyJacket, ownsOrangeJacket, ownsRedJacket, ownsGreenJacket, ownsWhiteJacket, ownsBlueJacket;
    public GameObject GreyJacketPrice, OrangeJacketPrice, RedJacketPrice, GreenJacketPrice, WhiteJacketPrice, BlueJacketPrice;

    public bool ownsGreyJacketBool, ownsOrangeJacketBool, ownsRedJacketBool, ownsGreenJacketBool, ownsWhiteJacketBool, ownsBlueJacketBool;
    public bool buyGreyJacket, buyOrangeJacket, buyRedJacket, buyGreenJacket, buyWhiteJacket, buyBlueJacket;
    public int dustAmount;

    int greyJacketPrice;
    int whiteJacketPrice;
    int orangeJacketPrice;
    int redJacketPrice;
    int greenJacketPrice;
    int blueJacketPrice;

    void Awake()
    {
        //setting the jacket prices
        greyJacketPrice = 800;
        whiteJacketPrice = 800;
        orangeJacketPrice = 900;
        redJacketPrice = 900;
        greenJacketPrice = 1100;
        blueJacketPrice = 1100;
    }

    void Start()
    {
        //Making jackets buyable
        GreyJacket.onClick.AddListener(BuyGreyJacket);
        OrangeJacket.onClick.AddListener(BuyOrangeJacket);
        RedJacket.onClick.AddListener(BuyRedJacket);
        GreenJacket.onClick.AddListener(BuyGreenJacket);
        WhiteJacket.onClick.AddListener(BuyWhiteJacket);
        BlueJacket.onClick.AddListener(BuyBlueJacket);

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

        JacketControlButton.enabled = false;
        JacketControlButton.GetComponent<Image>().enabled = false;

        GreyJacket.enabled = true;
        GreyJacket.GetComponent<Image>().enabled = true;

        OrangeJacket.enabled = true;
        OrangeJacket.GetComponent<Image>().enabled = true;

        RedJacket.enabled = true;
        RedJacket.GetComponent<Image>().enabled = true;

        GreenJacket.enabled = true;
        GreenJacket.GetComponent<Image>().enabled = true;

        WhiteJacket.enabled = true;
        WhiteJacket.GetComponent<Image>().enabled = true;

        BlueJacket.enabled = true;
        BlueJacket.GetComponent<Image>().enabled = true;


        buyGreyJacket = false;
        buyOrangeJacket = false;
        buyRedJacket = false;
        buyGreenJacket = false;
        buyWhiteJacket = false;
        buyBlueJacket = false;

        ownsGreyJacketBool = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyJacketOwned;
        ownsOrangeJacketBool = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeJacketOwned;
        ownsRedJacketBool = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedJacketOwned;
        ownsGreenJacketBool = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenJacketOwned;
        ownsWhiteJacketBool = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteJacketOwned;
        ownsBlueJacketBool = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteJacketOwned;

        //Gets the value of the jacket bought from the hard drive
        greyJacketBought = PlayerPrefs.GetInt("greyJacketOwned");
        orangeJacketBought = PlayerPrefs.GetInt("orangeJacketOwned");
        redJacketBought = PlayerPrefs.GetInt("redJacketOwned");
        greenJacketBought = PlayerPrefs.GetInt("greenJacketOwned");
        whiteJacketBought = PlayerPrefs.GetInt("whiteJacketOwned");
        blueJacketBought = PlayerPrefs.GetInt("blueJacketOwned");
    }

    void Update()
    {
        dustAmount = GameObject.Find("ShopBook").GetComponent<DustController>().DustAmount;

        //cheks if you own the grey jacket
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyJacketOwned == true || greyJacketBought == 1)
        {
            //disables the buttons and the price of the jacket
            ownsGreyJacket.enabled = true;
            GreyJacket.enabled = false;
            GreyJacketPrice.SetActive(false);
        }
        else if (ownsGreyJacketBool == false || greyJacketBought == 0)
        {
            //activates the button and the price of the jacket
            ownsGreyJacket.enabled = false;
            GreyJacket.enabled = true;
            GreyJacketPrice.SetActive(true);            
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyJacketOwned = false;
        }

        //cheks if you own the orange jacket
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeJacketOwned == true || orangeJacketBought == 1)
        {
            //disables the buttons and the price of the jacket
            OrangeJacket.enabled = false;
            OrangeJacketPrice.SetActive(false);

            ownsOrangeJacket.enabled = true;
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeJacketOwned = true;
        }
        else if (ownsOrangeJacketBool == false || orangeJacketBought == 0)
        {
            //activates the button and the price of the jacket
            OrangeJacket.enabled = true;
            OrangeJacketPrice.SetActive(true);

            ownsOrangeJacket.enabled = false;
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeJacketOwned = false;
        }

        //cheks if you own the red jacket
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedJacketOwned == true || redJacketBought == 1)
        {
            //disables the buttons and the price of the jacket
            RedJacket.enabled = false;
            RedJacketPrice.SetActive(false);

            ownsRedJacket.enabled = true;
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedJacketOwned = true;
        }
        else if (ownsRedJacketBool == false || redJacketBought == 0)
        {
            //activates the button and the price of the jacket
            RedJacket.enabled = true;
            RedJacketPrice.SetActive(true);

            ownsRedJacket.enabled = false;
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedJacketOwned = false;
        }

        //cheks if you own the green jacket
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenJacketOwned == true || greenJacketBought == 1)
        {
            //disables the buttons and the price of the jacket
            GreenJacket.enabled = false;
            GreenJacketPrice.SetActive(false);

            ownsGreenJacket.enabled = true;
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenJacketOwned = true;
        }
        else if (ownsGreenJacketBool == false || greenJacketBought == 0)
        {
            //activates the button and the price of the jacket
            GreenJacket.enabled = true;
            GreenJacketPrice.SetActive(true);

            ownsGreenJacket.enabled = false;
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenJacketOwned = false;
        }

        //cheks if you own the white jacket
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteJacketOwned == true || whiteJacketBought == 1)
        {
            //disables the buttons and the price of the jacket
            WhiteJacket.enabled = false;
            WhiteJacketPrice.SetActive(false);

            ownsWhiteJacket.enabled = true;
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteJacketOwned = true;
        }
        else if (ownsWhiteJacketBool == false || whiteJacketBought == 0)
        {
            //activates the button and the price of the jacket
            WhiteJacket.enabled = true;
            WhiteJacketPrice.SetActive(true);

            ownsWhiteJacket.enabled = false;
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteJacketOwned = false;
        }

        //cheks if you own the blue jacket
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().BlueJacketOwned == true || blueJacketBought == 1)
        {
            //disables the buttons and the price of the jacket
            BlueJacket.enabled = false;
            BlueJacketPrice.SetActive(false);

            ownsBlueJacket.enabled = true;
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().BlueJacketOwned = true;
        }
        else if (ownsBlueJacketBool == false || blueJacketBought == 0)
        {
            //activates the button and the price of the jacket
            BlueJacket.enabled = true;
            BlueJacketPrice.SetActive(true);

            ownsBlueJacket.enabled = false;
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().BlueJacketOwned = false;
        }
    }
//--------------------------------------------------------------------------------------------------------------------------

    void BuyGreyJacket()
    {
        //Removes the listeners that aren't needed
        yesBuyButton.onClick.RemoveAllListeners();
        noBuyButton.onClick.RemoveAllListeners();

        //adding the right listeners for yes and no buttons
        yesBuyButton.onClick.AddListener(BuyGreyJacketTrue);
        noBuyButton.onClick.AddListener(BuyGreyJacketFalse);

        //disables the confirmation text from buying jackets
        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        //Checks how much dust the player has and then if it has enough dust, the item will become buyable
        if (dustAmount >= greyJacketPrice)
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
        else if (dustAmount < greyJacketPrice)
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
        Debug.Log("GreyJacket");
    }
//--------------------------------------------------------------------------------------------------------------------------

    void BuyOrangeJacket()
    {
        //Removes the listeners that aren't needed
        yesBuyButton.onClick.RemoveAllListeners();
        noBuyButton.onClick.RemoveAllListeners();

        //adding the right listeners for yes and no buttons
        yesBuyButton.onClick.AddListener(BuyOrangeJacketTrue);
        noBuyButton.onClick.AddListener(BuyOrangeJacketFalse);

        //disables the confirmation text from buying jackets
        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        //Checks how much dust the player has and then if it has enough dust, the item will become buyable
        if (dustAmount >= orangeJacketPrice)
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
        else if (dustAmount < orangeJacketPrice)
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
        Debug.Log("OrangeJacket");
    }
//--------------------------------------------------------------------------------------------------------------------------

    void BuyRedJacket()
    {
        //Removes the listeners that aren't needed
        yesBuyButton.onClick.RemoveAllListeners();
        noBuyButton.onClick.RemoveAllListeners();

        //adding the right listeners for yes and no buttons
        yesBuyButton.onClick.AddListener(BuyRedJacketTrue);
        noBuyButton.onClick.AddListener(BuyRedJacketFalse);

        //disables the confirmation text from buying jackets
        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        //Checks how much dust the player has and then if it has enough dust, the item will become buyable
        if (dustAmount >= redJacketPrice)
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
        else if (dustAmount < redJacketPrice)
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
        Debug.Log("RedJacket");
    }
//--------------------------------------------------------------------------------------------------------------------------

    void BuyGreenJacket()
    {
        //Removes the listeners that aren't needed
        yesBuyButton.onClick.RemoveAllListeners();
        noBuyButton.onClick.RemoveAllListeners();

        //adding the right listeners for yes and no buttons
        yesBuyButton.onClick.AddListener(BuyGreenJacketTrue);
        noBuyButton.onClick.AddListener(BuyGreenJacketFalse);

        //disables the confirmation text from buying jackets
        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        //Checks how much dust the player has and then if it has enough dust, the item will become buyable
        if (dustAmount >= greenJacketPrice)
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
        else if (dustAmount < greenJacketPrice)
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
        Debug.Log("GreenJacket");
    }
 //--------------------------------------------------------------------------------------------------------------------------

    void BuyWhiteJacket()
    {
        //Removes the listeners that aren't needed
        yesBuyButton.onClick.RemoveAllListeners();
        noBuyButton.onClick.RemoveAllListeners();

        //adding the right listeners for yes and no buttons
        yesBuyButton.onClick.AddListener(BuyWhiteJacketTrue);
        noBuyButton.onClick.AddListener(BuyWhiteJacketFalse);

        //disables the confirmation text from buying jackets
        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        //Checks how much dust the player has and then if it has enough dust, the item will become buyable
        if (dustAmount >= whiteJacketPrice)
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
        else if (dustAmount < whiteJacketPrice)
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
        Debug.Log("WhiteJacket");
    }
    //--------------------------------------------------------------------------------------------------------------------------

    void BuyBlueJacket()
    {
        //Removes the listeners that aren't needed
        yesBuyButton.onClick.RemoveAllListeners();
        noBuyButton.onClick.RemoveAllListeners();

        //adding the right listeners for yes and no buttons
        yesBuyButton.onClick.AddListener(BuyBlueJacketTrue);
        noBuyButton.onClick.AddListener(BuyBlueJacketFalse);

        //disables the confirmation text from buying jackets
        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        //Checks how much dust the player has and then if it has enough dust, the item will become buyable
        if (dustAmount >= blueJacketPrice)
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
        else if (dustAmount < blueJacketPrice)
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
        Debug.Log("BlueJacket");
    }
    //--------------------------------------------------------------------------------------------------------------------------

    void BuyGreyJacketTrue()
    {
        audio.PlayOneShot(yes);

        Debug.Log("BuyGreyJacketTrue");
        GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().ShopSaveGreyJacketOwned(true);

        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyJacketOwned == true && greyJacketCounter == 0)
        {
            greyJacketCounter++;

            confirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;

            GreyJacket.enabled = false;
            Debug.Log("You have bought a Greyjacket");
            GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(greyJacketPrice);

            GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();

            if (dustAmount < 1)
            {
                dustAmount = 0;
                GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
            }
        }
    }

    void BuyGreyJacketFalse()
    {
        audio.PlayOneShot(no);

        Debug.Log("BuyGreyJacketFalse");
        ownsGreyJacketBool = false;
        buyGreyJacket = false;

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

    void BuyOrangeJacketTrue()
    {
        audio.PlayOneShot(yes);

        Debug.Log("BuyOrangeJacketTrue");
        GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().ShopSaveOrangeJacketOwned(true);

        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeJacketOwned == true && orangeJacketCounter == 0)
        {
            orangeJacketCounter++;

            confirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;

            OrangeJacket.enabled = false;
            Debug.Log("You have bought a Orangejacket");
            GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(orangeJacketPrice);

            GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();

            if (dustAmount < 1)
            {
                dustAmount = 0;
                GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
            }
        }
    }

    void BuyOrangeJacketFalse()
    {
        audio.PlayOneShot(no);

        Debug.Log("BuyOrangeJacketFalse");
        ownsOrangeJacketBool = false;
        buyOrangeJacket = false;

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

    void BuyRedJacketTrue()
    {
        audio.PlayOneShot(yes);

        Debug.Log("BuyRedJacketTrue");
        GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().ShopSaveRedJacketOwned(true);

        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedJacketOwned == true && redJacketCounter == 0)
        {
            redJacketCounter++;

            confirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;

            RedJacket.enabled = false;
            Debug.Log("You have bought a Redjacket");
            GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(redJacketPrice);

            GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();

            if (dustAmount < 1)
            {
                dustAmount = 0;
                GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
            }
        }
    }

    void BuyRedJacketFalse()
    {
        audio.PlayOneShot(no);

        Debug.Log("BuyRedJacketFalse");
        ownsRedJacketBool = false;
        buyRedJacket = false;

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

    void BuyGreenJacketTrue()
    {
        audio.PlayOneShot(yes);

        Debug.Log("BuyGreenJacketTrue");
        GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().ShopSaveGreenJacketOwned(true);

        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenJacketOwned == true && greenJacketCounter == 0)
        {
            greenJacketCounter++;

            confirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;

            GreenJacket.enabled = false;
            Debug.Log("You have bought a Greenjacket");
            GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(greenJacketPrice);

            GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();

            if (dustAmount < 1)
            {
                dustAmount = 0;
                GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
            }
        }
    }

    void BuyGreenJacketFalse()
    {
        audio.PlayOneShot(no);

        Debug.Log("BuyGreenJacketFalse");
        ownsGreenJacketBool = false;
        buyGreenJacket = false;

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

    void BuyWhiteJacketTrue()
    {
        audio.PlayOneShot(yes);

        Debug.Log("BuyWhiteJacketTrue");
        GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().ShopSaveWhiteJacketOwned(true);

        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteJacketOwned == true && whiteJacketCounter == 0)
        {
            whiteJacketCounter++;

            confirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;

            WhiteJacket.enabled = false;
            Debug.Log("You have bought a Whitejacket");
            GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(whiteJacketPrice);

            GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();

            if (dustAmount < 1)
            {
                dustAmount = 0;
                GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
            }
        }
    }

    void BuyWhiteJacketFalse()
    {
        audio.PlayOneShot(no);

        Debug.Log("BuyWhiteJacketFalse");
        ownsWhiteJacketBool = false;
        buyWhiteJacket = false;

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

    void BuyBlueJacketTrue()
    {
        audio.PlayOneShot(yes);

        Debug.Log("BuyBlueJacketTrue");
        GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().ShopSaveBlueJacketOwned(true);

        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().BlueJacketOwned == true && blueJacketCounter == 0)
        {
            blueJacketCounter++;

            confirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;

            BlueJacket.enabled = false;
            Debug.Log("You have bought a bluejacket");
            GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(blueJacketPrice);

            GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();

            if (dustAmount < 1)
            {
                dustAmount = 0;
                GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
            }
        }
    }

    void BuyBlueJacketFalse()
    {
        audio.PlayOneShot(no);

        Debug.Log("BuyBlueJacketFalse");
        ownsBlueJacketBool = false;
        buyBlueJacket = false;

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

