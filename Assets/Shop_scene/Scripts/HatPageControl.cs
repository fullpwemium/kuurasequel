using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HatPageControl : MonoBehaviour
{
    int greyHatCounter, orangeHatCounter, redHatCounter, greenHatCounter, whiteHatCounter;
    int greyHatBought;
    int orangeHatBought;
    int redHatBought;
    int greenHatBought;
    int whiteHatBought;

    public Button GreyHat;
    public Button OrangeHat;
    public Button RedHat;
    public Button GreenHat;
    public Button WhiteHat;

    public Button HatControlButton;
    public Button yesBuyButton;
    public Button noBuyButton;
    public Text ConfirmText;
    public Text yesText;
    public Text noText;
    public Button buyconfirmbutton;
    public Image buyconfirm;
    public Image background;

    public Image ownsGreyHat;
    public Image ownsOrangeHat;
    public Image ownsRedHat;
    public Image ownsGreenHat;
    public Image ownsWhiteHat;

    public GameObject GreyHatPrice;
    public GameObject OrangeHatPrice;
    public GameObject RedHatPrice;
    public GameObject GreenHatPrice;
    public GameObject WhiteHatPrice;

    public bool ownsGreyHatBool;
    public bool ownsOrangeHatBool;
    public bool ownsRedHatBool;
    public bool ownsGreenHatBool;
    public bool ownsWhiteHatBool;

    public bool buyGreyHat;
    public bool buyOrangeHat;
    public bool buyRedHat;
    public bool buyGreenHat;
    public bool buyWhiteHat;

    int hatprice;
    public int dustAmount;

    // Use this for initialization
    void Awake()
    {
        //Setting the hat price
        hatprice = 500;
    }

    void Start()
    {
        //Making hats buyable
        GreyHat.onClick.AddListener(BuyGreyHat);
        OrangeHat.onClick.AddListener(BuyOrangeHat);
        RedHat.onClick.AddListener(BuyRedHat);
        GreenHat.onClick.AddListener(BuyGreenHat);
        WhiteHat.onClick.AddListener(BuyWhiteHat);

        //Makes the confirmation text for the buttons to be false
        ConfirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;
        buyconfirmbutton.enabled = false;
        buyconfirm.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        buyGreyHat = false;
        buyOrangeHat = false;
        buyRedHat = false;
        buyGreenHat = false;
        buyWhiteHat = false;

        HatControlButton.enabled = false;
        HatControlButton.GetComponent<Image>().enabled = false;

        //Makes the buttons appear
        GreyHat.enabled = true;
        GreyHat.GetComponent<Image>().enabled = true;

        OrangeHat.enabled = true;
        OrangeHat.GetComponent<Image>().enabled = true;

        RedHat.enabled = true;
        RedHat.GetComponent<Image>().enabled = true;

        GreenHat.enabled = true;
        GreenHat.GetComponent<Image>().enabled = true;

        WhiteHat.enabled = true;
        WhiteHat.GetComponent<Image>().enabled = true;

        ownsGreyHat.enabled = false;
        ownsOrangeHat.enabled = false;
        ownsRedHat.enabled = false;
        ownsGreenHat.enabled = false;
        ownsWhiteHat.enabled = false;

        ownsGreyHatBool = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyHatOwned;
        ownsOrangeHatBool = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeHatOwned;
        ownsRedHatBool = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedHatOwned;
        ownsGreenHatBool = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenHatOwned;
        ownsWhiteHatBool = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteHatOwned;

        //Gets the value of the hat bought from the hard drive
        greyHatBought = PlayerPrefs.GetInt("greyHatOwned");
        orangeHatBought = PlayerPrefs.GetInt("orangeHatOwned");
        redHatBought = PlayerPrefs.GetInt("redHatOwned");
        greenHatBought = PlayerPrefs.GetInt("greenHatOwned");
        whiteHatBought = PlayerPrefs.GetInt("whiteHatOwned");
    }
//--------------------------------------------------------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        dustAmount = GameObject.Find("ShopBook").GetComponent<DustController>().DustAmount;
        //--------------------------------------------------------------------------------------------------------------------------
               
        //checks if you own the grey hat and then you cannot buy it anymore
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyHatOwned == true || greyHatBought == 1 )
        {
            ownsGreyHat.enabled = true;
            GreyHat.enabled = false;
            GreyHatPrice.SetActive(false);           
        }
        else if (ownsGreyHatBool == false || greyHatBought == 0)
        {
            ownsGreyHat.enabled = false;
            GreyHat.enabled = true;
            GreyHatPrice.SetActive(true);
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyHatOwned = false;
        }

        //checks if you own the orange hat and then you cannot buy it anymore
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeHatOwned == true || orangeHatBought == 1)
        {
            ownsOrangeHat.enabled = true;
            OrangeHat.enabled = false;
            OrangeHatPrice.SetActive(false);
            GameObject.Find("BobButton").GetComponent<BobPageControl>().ownsOrangeHat = true;
        }
        else if (ownsOrangeHatBool==false || orangeHatBought == 0)
        {
            ownsOrangeHat.enabled = false;
            OrangeHat.enabled = true;
            OrangeHatPrice.SetActive(true);
            GameObject.Find("BobButton").GetComponent<BobPageControl>().ownsOrangeHat = false;
        }

        //checks if you own the red hat and then you cannot buy it anymore
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedHatOwned == true || redHatBought == 1)
        {
            ownsRedHat.enabled = true;
            RedHat.enabled = false;
            RedHatPrice.SetActive(false);
            GameObject.Find("BobButton").GetComponent<BobPageControl>().ownsRedHat = true;
        }
        else if (ownsRedHatBool==false || redHatBought == 0)
        {
            ownsRedHat.enabled = false;
            RedHat.enabled = true;
            RedHatPrice.SetActive(true);
            GameObject.Find("BobButton").GetComponent<BobPageControl>().ownsRedHat = false;
        }

        //checks if you own the green hat and then you cannot buy it anymore
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenHatOwned == true || greenHatBought == 1)
        {
            ownsGreenHat.enabled = true;
            GreenHat.enabled = false;
            GreenHatPrice.SetActive(false);
            GameObject.Find("BobButton").GetComponent<BobPageControl>().ownsGreenHat = true;
        }
        else if(ownsGreenHatBool==false || greenHatBought == 0)
        {
            ownsGreenHat.enabled = false;
            GreenHat.enabled = true;
            GreenHatPrice.SetActive(true);
            GameObject.Find("BobButton").GetComponent<BobPageControl>().ownsGreenHat = false;
        }

        //checks if you own the white hat and then you cannot buy it anymore
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteHatOwned == true || whiteHatBought == 1)
        {
            ownsWhiteHat.enabled = true;
            WhiteHat.enabled = false;
            WhiteHatPrice.SetActive(false);
            GameObject.Find("BobButton").GetComponent<BobPageControl>().ownsWhiteHat = true;
        }
        else if(ownsWhiteHatBool==false || whiteHatBought == 0)
        {
            ownsWhiteHat.enabled = false;
            WhiteHat.enabled = true;
            WhiteHatPrice.SetActive(true);
            GameObject.Find("BobButton").GetComponent<BobPageControl>().ownsWhiteHat = false;
        }
        //--------------------------------------------------------------------------------------------------------------------------
    }

//--------------------------------------------------------------------------------------------------------------------------
    void BuyGreyHat()
    {
        //Removes the listeners that aren't needed
        yesBuyButton.onClick.RemoveAllListeners();
        noBuyButton.onClick.RemoveAllListeners();

        //Adds listeners so that you can buy the right hat
        yesBuyButton.onClick.AddListener(BuyGreyHatTrue);
        noBuyButton.onClick.AddListener(BuyGreyHatFalse);      

        //disables the confirmation text from buying hats
        ConfirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        //Checks how much dust the player has and then if it has enough dust, the item will become buyable
        if (dustAmount >= hatprice)
        {
            ConfirmText.enabled = true;
            yesText.enabled = true;
            noText.enabled = true;

            yesBuyButton.enabled = true;
            yesBuyButton.GetComponent<Image>().enabled = true;

            background.GetComponent<Image>().enabled = true;

            noBuyButton.enabled = true;
            noBuyButton.GetComponent<Image>().enabled = true;
        }
        //tells to you if you dont have enough dust
        else if (dustAmount < hatprice)
        {
            Debug.Log("You don't have enough magic dust");
            GameObject.Find("NotEnoughDust").GetComponent<NotEnoughDust>().Background.enabled = true;
            ConfirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;
        }
    }
 //--------------------------------------------------------------------------------------------------------------------------

    void BuyOrangeHat()
    {
        //Removes the listeners that aren't needed
        yesBuyButton.onClick.RemoveAllListeners();
        noBuyButton.onClick.RemoveAllListeners();

        //Adds listeners so that you can buy the right hat
        yesBuyButton.onClick.AddListener(BuyOrangeHatTrue);
        noBuyButton.onClick.AddListener(BuyOrangeHatFalse);

        //disables the confirmation text from buying hats
        ConfirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        //Checks how much dust the player has and then if it has enough dust, the item will become buyable
        if (dustAmount >= hatprice)
        {
            ConfirmText.enabled = true;
            yesText.enabled = true;
            noText.enabled = true;

            yesBuyButton.enabled = true;
            yesBuyButton.GetComponent<Image>().enabled = true;

            background.GetComponent<Image>().enabled = true;

            noBuyButton.enabled = true;
            noBuyButton.GetComponent<Image>().enabled = true;
        }
        else if (dustAmount < hatprice)
        {
            Debug.Log("You don't have enough magic dust");
            GameObject.Find("NotEnoughDust").GetComponent<NotEnoughDust>().Background.enabled = true;
            ConfirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;
        }
    }
//--------------------------------------------------------------------------------------------------------------------------

    void BuyRedHat()
    {
        //Removes the listeners that aren't needed
        yesBuyButton.onClick.RemoveAllListeners();
        noBuyButton.onClick.RemoveAllListeners();

        //Adds listeners so that you can buy the right hat
        yesBuyButton.onClick.AddListener(BuyRedHatTrue);
        noBuyButton.onClick.AddListener(BuyRedHatFalse);

        //disables the confirmation text from buying hats
        ConfirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        //Checks how much dust the player has and then if it has enough dust, the item will become buyable
        if (dustAmount >= hatprice)
        {
            ConfirmText.enabled = true;
            yesText.enabled = true;
            noText.enabled = true;

            yesBuyButton.enabled = true;
            yesBuyButton.GetComponent<Image>().enabled = true;

            background.GetComponent<Image>().enabled = true;

            noBuyButton.enabled = true;
            noBuyButton.GetComponent<Image>().enabled = true;
        }
        else if (dustAmount < hatprice)
        {
            Debug.Log("You don't have enough magic dust");
            GameObject.Find("NotEnoughDust").GetComponent<NotEnoughDust>().Background.enabled = true;
            ConfirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;
        }
    }
//--------------------------------------------------------------------------------------------------------------------------

    void BuyGreenHat()
    {
        //Removes the listeners that aren't needed
        yesBuyButton.onClick.RemoveAllListeners();
        noBuyButton.onClick.RemoveAllListeners();

        //Adds listeners so that you can buy the right hat
        yesBuyButton.onClick.AddListener(BuyGreenHatTrue);
        noBuyButton.onClick.AddListener(BuyGreenHatFalse);

        //disables the confirmation text from buying hats
        ConfirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        //Checks how much dust the player has and then if it has enough dust, the item will become buyable
        if (dustAmount >= hatprice)
        {
            ConfirmText.enabled = true;
            yesText.enabled = true;
            noText.enabled = true;

            yesBuyButton.enabled = true;
            yesBuyButton.GetComponent<Image>().enabled = true;

            background.GetComponent<Image>().enabled = true;

            noBuyButton.enabled = true;
            noBuyButton.GetComponent<Image>().enabled = true;
        }
        else if (dustAmount < hatprice)
        {
            Debug.Log("You don't have enough magic dust");
            GameObject.Find("NotEnoughDust").GetComponent<NotEnoughDust>().Background.enabled = true;
            ConfirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;
        }
    }
//--------------------------------------------------------------------------------------------------------------------------

    void BuyWhiteHat()
    {
        //Removes the listeners that aren't needed
        yesBuyButton.onClick.RemoveAllListeners();
        noBuyButton.onClick.RemoveAllListeners();

        //Adds listeners so that you can buy the right hat
        yesBuyButton.onClick.AddListener(BuyWhiteHatTrue);
        noBuyButton.onClick.AddListener(BuyWhiteHatFalse);

        //disables the confirmation text from buying hats
        ConfirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        //Checks how much dust the player has and then if it has enough dust, the item will become buyable
        if (dustAmount >= hatprice)
        {
            ConfirmText.enabled = true;
            yesText.enabled = true;
            noText.enabled = true;

            yesBuyButton.enabled = true;
            yesBuyButton.GetComponent<Image>().enabled = true;

            background.GetComponent<Image>().enabled = true;

            noBuyButton.enabled = true;
            noBuyButton.GetComponent<Image>().enabled = true;
        }
        else if (dustAmount < hatprice)
        {
            Debug.Log("You don't have enough magic dust");
            GameObject.Find("NotEnoughDust").GetComponent<NotEnoughDust>().Background.enabled = true;
            ConfirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;
        }
    }
 //--------------------------------------------------------------------------------------------------------------------------

    void BuyGreyHatTrue()
    {
        //Makes grey hat owned in the GlobalGameManager script true
      GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().ShopSaveGreyHatOwned(true);
        //Checks if you want to buy the item
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyHatOwned == true && greyHatCounter == 0)
        {
            greyHatCounter++;

            ConfirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;
            GreyHat.enabled = false;

            Debug.Log("You have bought a grey hat");
            GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(hatprice);
            GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();

            if (dustAmount < 1)
            {
                dustAmount = 0;
                GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
            }
        }
    }

    //makes buying grey hat false if you don't want to buy that hat
    void BuyGreyHatFalse()
    {
        Debug.Log("Your grey hat purchase failed");
        ownsGreyHatBool = false;
        buyGreyHat = false;
        ConfirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;
    }
//--------------------------------------------------------------------------------------------------------------------------

    void BuyOrangeHatTrue()
    {
        //Makes orange hat owned in the GlobalGameManager script true
        GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().ShopSaveOrangeHatOwned(true);

        //Checks if you want to buy the item
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeHatOwned == true && orangeHatCounter == 0)
        {
            orangeHatCounter++;

            ConfirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            OrangeHat.enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;

            Debug.Log("You have bought an orange hat");
            GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(hatprice);
            GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();

            if (dustAmount < 1)
            {
                dustAmount = 0;
                GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
            }
        }
    }

    void BuyOrangeHatFalse()
    {
        Debug.Log("Your orange hat purchase has failed");
        ownsOrangeHatBool = false;
        ConfirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;
    }
//--------------------------------------------------------------------------------------------------------------------------

    void BuyRedHatTrue()
    {
        //Makes red hat owned in the GlobalGameManager script true
        GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().ShopSaveRedHatOwned(true);
        //Checks if you want to buy the item
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedHatOwned == true && redHatCounter == 0)
        {
            redHatCounter++;

            ConfirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            RedHat.enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;

            Debug.Log("You have bought a red hat");
            GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(hatprice);
            GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();

            if (dustAmount < 1)
            {
                dustAmount = 0;
                GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
            }
        }
    }

    void BuyRedHatFalse()
    {
        Debug.Log("Your red hat purchase failed");
        buyRedHat = false;
        ConfirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;
    }
//--------------------------------------------------------------------------------------------------------------------------

    void BuyGreenHatTrue()
    {
        //Makes green hat owned in the GlobalGameManager script true
        GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().ShopSaveGreenHatOwned(true);
        //Checks if you want to buy the item
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenHatOwned == true && greenHatCounter == 0)
        {
            greenHatCounter++;

            ConfirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            GreenHat.enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;

            Debug.Log("You have bought a green hat");
            GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(hatprice);
            GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();

            if (dustAmount < 1)
            {
                dustAmount = 0;
                GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
            }
        }
    }

    void BuyGreenHatFalse()
    {
        Debug.Log("Your green hat purchase has failed");
        buyGreenHat = false;
        ConfirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;
    }
//--------------------------------------------------------------------------------------------------------------------------

    void BuyWhiteHatTrue()
    {
        //Makes white hat owned in the GlobalGameManager script true
        GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().ShopSaveWhiteHatOwned(true);
        //Checks if you want to buy the item
        if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteHatOwned == true && whiteHatCounter == 0)
        {
            whiteHatCounter++;

            ConfirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            WhiteHat.enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;

            Debug.Log("You have bought a white hat");
            GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(hatprice);
            GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();

            if (dustAmount < 1)
            {
                dustAmount = 0;
                GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
            }
        }
    }

    void BuyWhiteHatFalse()
    {
        Debug.Log("Your white hat purchase has failed");
        buyWhiteHat = false;
        ConfirmText.enabled = false;
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




