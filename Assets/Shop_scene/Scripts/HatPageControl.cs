using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HatPageControl : MonoBehaviour
{

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

    public int currentpage;
    public int hatpage;
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

        yesBuyButton.onClick.AddListener(BuyGreyHatTrue);
        noBuyButton.onClick.AddListener(BuyGreyHatFalse);

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

        //Makes the buttons disappear
        GreyHat.enabled = false;
        GreyHat.GetComponent<Image>().enabled = false;

        OrangeHat.enabled = false;
        OrangeHat.GetComponent<Image>().enabled = false;

        RedHat.enabled = false;
        RedHat.GetComponent<Image>().enabled = false;

        GreenHat.enabled = false;
        GreenHat.GetComponent<Image>().enabled = false;

        WhiteHat.enabled = false;
        WhiteHat.GetComponent<Image>().enabled = false;

        ownsGreyHatBool = GameObject.Find("BobButton").GetComponent<BobPageControl>().ownsGreyHat;
        ownsOrangeHatBool = GameObject.Find("BobButton").GetComponent<BobPageControl>().ownsOrangeHat;
        ownsRedHatBool = GameObject.Find("BobButton").GetComponent<BobPageControl>().ownsRedHat;
        ownsGreenHatBool = GameObject.Find("BobButton").GetComponent<BobPageControl>().ownsGreenHat;
        ownsWhiteHatBool = GameObject.Find("BobButton").GetComponent<BobPageControl>().ownsWhiteHat;
    }

    // Update is called once per frame
    void Update()
    {
        dustAmount = GameObject.Find("ShopBook").GetComponent<DustController>().DustAmount;
        hatpage = GameObject.Find("BookButton").GetComponent<BookButtonControl>().hatpage - 1;
        currentpage = GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage;

        //checks if the current page is equal to hat page and if so then the hats are shown
        if (hatpage == currentpage)
        {
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
        }
        else
        {
            GreyHat.enabled = false;
            GreyHat.GetComponent<Image>().enabled = false;

            OrangeHat.enabled = false;
            OrangeHat.GetComponent<Image>().enabled = false;

            RedHat.enabled = false;
            RedHat.GetComponent<Image>().enabled = false;

            GreenHat.enabled = false;
            GreenHat.GetComponent<Image>().enabled = false;

            WhiteHat.enabled = false;
            WhiteHat.GetComponent<Image>().enabled = false;
        }

        if (ownsGreyHatBool == true)
        {
            ownsGreyHat.enabled = true;
        }
        else if (ownsGreyHatBool == false)
        {
            ownsGreyHat.enabled = false;
        }
    }

    void BuyGreyHat()
    {
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

    void BuyOrangeHat()
    {
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

    void BuyRedHat()
    {
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

    void BuyGreenHat()
    {
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

    void BuyWhiteHat()
    {
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

    void BuyGreyHatTrue()
    {
        buyGreyHat = true;
        //Checks if you want to buy the item
        if (buyGreyHat == true)
        {
            ConfirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;

            Debug.Log("You have bought an item");
            GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(hatprice / 2);
            GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();

            if (dustAmount < 1)
            {
                dustAmount = 0;
                GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
            }

        }
        else if (buyGreyHat == false)
        {
            Debug.Log("Your purchase failed");
            BuyGreyHatFalse();
        }
    }

    //makes buying grey hat false if you don't want to buy that hat
    void BuyGreyHatFalse()
    {
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

    void BuyOrangeHatTrue()
    {
        buyOrangeHat = true;
        //Checks if you want to buy the item
        if (buyOrangeHat == true)
        {
            BuyOrangeHatFalse();
            ConfirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;

            Debug.Log("You have bought an item");
            GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(hatprice / 2);
            GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();

            if (dustAmount < 1)
            {
                dustAmount = 0;
                GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
            }
        }
        else if (buyOrangeHat == false)
        {
            Debug.Log("Your purchase failed");
            BuyOrangeHatFalse();
        }
    }

    void BuyOrangeHatFalse()
    {
        buyOrangeHat = false;
        ConfirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;
    }

    void BuyRedHatTrue()
    {
        buyRedHat = true;
        //Checks if you want to buy the item
        if (buyRedHat == true)
        {
            BuyRedHatFalse();
            ConfirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;

            Debug.Log("You have bought an item");
            GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(hatprice / 2);
            GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();

            if (dustAmount < 1)
            {
                dustAmount = 0;
                GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
            }
        }
        else if (buyRedHat == false)
        {
            Debug.Log("Your purchase failed");
            BuyRedHatFalse();
        }
    }

    void BuyRedHatFalse()
    {
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

    void BuyGreenHatTrue()
    {
        buyGreenHat = true;
        //Checks if you want to buy the item
        if (buyGreenHat == true)
        {
            BuyGreenHatFalse();
            ConfirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;

            Debug.Log("You have bought an item");
            GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(hatprice / 2);
            GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();

            if (dustAmount < 1)
            {
                dustAmount = 0;
                GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
            }
        }
        else if (buyGreenHat == false)
        {
            Debug.Log("Your purchase failed");
            BuyGreenHatFalse();
        }
    }

    void BuyGreenHatFalse()
    {
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

    void BuyWhiteHatTrue()
    {
        buyWhiteHat = true;
        //Checks if you want to buy the item
        if (buyWhiteHat == true)
        {
            ConfirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            background.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;

            Debug.Log("You have bought an item");
            GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(hatprice / 2);
            GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();

            if (dustAmount < 1)
            {
                dustAmount = 0;
                GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
            }
        }
        else if (buyWhiteHat == false)
        {
            BuyWhiteHatFalse();
            Debug.Log("Your purchase failed");
        }
    }

    void BuyWhiteHatFalse()
    {
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
}




