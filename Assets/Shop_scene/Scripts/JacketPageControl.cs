using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JacketPageControl : MonoBehaviour {

    int greyJacketCounter, orangeJacketCounter, redJacketCounter, greenJacketCounter, whiteJacketCounter;
    int greyJacketBought, orangeJacketBought, redJacketBought, greenJacketBought, whiteJacketBought;

    public Button GreyJacket, OrangeJacket, RedJacket, GreenJacket, WhiteJacket;
    public Button JacketControlButton;
    public Button yesBuyButton, noBuyButton;
    public Text confirmText;
    public Text yesText, noText;
    public Button buyConfirmButton;
    public Image buyConfirm;
    public Image background;

    public Image ownsGreyJacket, ownsOrangeJacket, ownsRedJacket, ownsGreenJacket, ownsWhiteJacket;
    public GameObject GreyJacketPrice, OrangeJacketPrice, RedJacketPrice, GreenJacketPrice, WhiteJacketPrice;

    public bool ownsGreyJacketBool, ownsOrangeJacketBool, ownsRedJacketBool, ownsGreenJacketBool, ownsWhiteJacketBool;
    public bool buyGreyJacket, buyOrangeJacket, buyRedJacket, buyGreenJacket, buyWhiteJacket;
    public int dustAmount;

    int jacketPrice;

    void Awake()
    {
        //setting the jacket price
        jacketPrice = 800;
    }

    void Start()
    {
        //Making jackets buyable
        GreyJacket.onClick.AddListener(BuyGreyJacket);
        OrangeJacket.onClick.AddListener(BuyOrangeJacket);
        RedJacket.onClick.AddListener(BuyRedJacket);
        GreenJacket.onClick.AddListener(BuyGreenJacket);
        WhiteJacket.onClick.AddListener(BuyWhiteJacket);

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


        buyGreyJacket = false;
        buyOrangeJacket = false;
        buyRedJacket = false;
        buyGreenJacket = false;
        buyWhiteJacket = false;

        ownsGreyJacketBool = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyJacketOwned;

        greyJacketBought = PlayerPrefs.GetInt("greyJacketOwned");
    }

    void Update()
    {
        dustAmount = GameObject.Find("ShopBook").GetComponent<DustController>().DustAmount;

        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyJacketOwned == true || greyJacketBought == 1)
        {
            GreyJacket.enabled = false;
            GreyJacketPrice.SetActive(false);

            ownsGreyJacket.enabled = true;
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyJacketOwned = true;
        }
        else if (ownsGreyJacketBool == false || greyJacketBought != 1)
        {
            GreyJacket.enabled = true;
            GreyJacketPrice.SetActive(true);

            ownsGreyJacket.enabled = false;
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyJacketOwned = false;
        }

        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeJacketOwned == true || orangeJacketBought == 1)
        {
            OrangeJacket.enabled = false;
            OrangeJacketPrice.SetActive(false);

            ownsGreyJacket.enabled = true;
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeJacketOwned = true;
        }
        else if (ownsOrangeJacketBool == false || orangeJacketBought != 1)
        {
            OrangeJacket.enabled = true;
            OrangeJacketPrice.SetActive(true);

            ownsGreyJacket.enabled = false;
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeJacketOwned = false;
        }

        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedJacketOwned == true || redJacketBought == 1)
        {
            RedJacket.enabled = false;
            RedJacketPrice.SetActive(false);

            ownsRedJacket.enabled = true;
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedJacketOwned = true;
        }
        else if (ownsRedJacketBool == false || redJacketBought != 1)
        {
            RedJacket.enabled = true;
            RedJacketPrice.SetActive(true);

            ownsRedJacket.enabled = false;
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedJacketOwned = false;
        }

        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenJacketOwned == true || greenJacketBought == 1)
        {
            GreenJacket.enabled = false;
            GreenJacketPrice.SetActive(false);

            ownsGreenJacket.enabled = true;
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenJacketOwned = true;
        }
        else if (ownsGreenJacketBool == false || greenJacketBought != 1)
        {
            GreenJacket.enabled = true;
            GreenJacketPrice.SetActive(true);

            ownsGreenJacket.enabled = false;
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenJacketOwned = false;
        }

        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteJacketOwned == true || whiteJacketBought == 1)
        {
            WhiteJacket.enabled = false;
            WhiteJacketPrice.SetActive(false);

            ownsWhiteJacket.enabled = true;
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteJacketOwned = true;
        }
        else if (ownsWhiteJacketBool == false || whiteJacketBought != 1)
        {
            WhiteJacket.enabled = true;
            WhiteJacketPrice.SetActive(true);

            ownsWhiteJacket.enabled = false;
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteJacketOwned = false;
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
        if (dustAmount >= jacketPrice)
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
        //tells to you if you dont have enough dust
        else if (dustAmount < jacketPrice)
        {
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
        Debug.Log("OrangeJacket");
    }
//--------------------------------------------------------------------------------------------------------------------------

    void BuyRedJacket()
    {
        Debug.Log("RedJacket");
    }
//--------------------------------------------------------------------------------------------------------------------------

    void BuyGreenJacket()
    {
        Debug.Log("GreenJacket");
    }
 //--------------------------------------------------------------------------------------------------------------------------

    void BuyWhiteJacket()
    {
        Debug.Log("WhiteJacket");
    }
//--------------------------------------------------------------------------------------------------------------------------

    void BuyGreyJacketTrue()
    {

    }

    void BuyGreyJacketFalse()
    {

    }
//--------------------------------------------------------------------------------------------------------------------------

    void BuyOrangeJacketTrue()
    {

    }

    void BuyOrangeJacketFalse()
    {

    }
//--------------------------------------------------------------------------------------------------------------------------

    void BuyRedJacketTrue()
    {

    }

    void BuyRedJacketFalse()
    {

    }
//--------------------------------------------------------------------------------------------------------------------------

    void BuyGreenJacketTrue()
    {

    }

    void BuyGreenJacketFalse()
    {

    }
//--------------------------------------------------------------------------------------------------------------------------

    void BuyWhiteJacketTrue()
    {

    }

    void BuyWhiteJacketFalse()
    {

    }
//--------------------------------------------------------------------------------------------------------------------------
}

