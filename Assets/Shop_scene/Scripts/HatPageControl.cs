using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HatPageControl : MonoBehaviour {

    public Button BlackHat;
    public Button WhiteHat;
    public Button GreenHat;
    public Button RedHat;
    public Button OrangeHat;
    public Button HatControlButton;
    public Button yesBuyButton;
    public Button noBuyButton;
    public Text ConfirmText;
    public Text yesText;
    public Text noText;

    public Image background;
    public bool buy;
    int currentpage;
    int hatpage;
    int hatprice;
    public int dustAmount;
    // Use this for initialization
    void Start()
    {
        ConfirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        background.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        buy = false;
        hatprice = 500;
        HatControlButton.enabled = false;
        HatControlButton.GetComponent<Image>().enabled = false;
        BlackHat.onClick.AddListener(BuyHat);
        WhiteHat.onClick.AddListener(BuyHat);
        GreenHat.onClick.AddListener(BuyHat);
        RedHat.onClick.AddListener(BuyHat);
        OrangeHat.onClick.AddListener(BuyHat);
        yesBuyButton.onClick.AddListener(BuyTrue);
        noBuyButton.onClick.AddListener(BuyFalse);
    }
	// Update is called once per frame
	void Update ()
    {
        dustAmount = GameObject.Find("ShopBook").GetComponent<DustController>().DustAmount;
        hatpage = GameObject.Find("BookButton").GetComponent<BookButtonControl>().hatpage-1;
        currentpage = GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage;
        if (hatpage == currentpage)
        {
            BlackHat.enabled = true;
            BlackHat.GetComponent<Image>().enabled = true;

            WhiteHat.enabled = true;
            WhiteHat.GetComponent<Image>().enabled = true;

            GreenHat.enabled = true;
            GreenHat.GetComponent<Image>().enabled = true;

            RedHat.enabled = true;
            RedHat.GetComponent<Image>().enabled = true;

            OrangeHat.enabled = true;
            OrangeHat.GetComponent<Image>().enabled = true;
        }
        else
        {
            BlackHat.enabled = false;
            BlackHat.GetComponent<Image>().enabled = false;

            WhiteHat.enabled = false;
            WhiteHat.GetComponent<Image>().enabled = false;

            GreenHat.enabled = false;
            GreenHat.GetComponent<Image>().enabled = false;

            RedHat.enabled = false;
            RedHat.GetComponent<Image>().enabled = false;

            OrangeHat.enabled = false;
            OrangeHat.GetComponent<Image>().enabled = false;
        }
	}
    void BuyHat()
    {
        if (dustAmount >= hatprice)
        {

            ConfirmText.enabled = true;
            yesText.enabled = true;
            noText.enabled = true;

            yesBuyButton.enabled = true;
            yesBuyButton.GetComponent<Image>().enabled = true;

            background.GetComponent<Image>().enabled = true;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = true;

            if (buy == true)
            {
                GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(hatprice);
                GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
            }
        }
        else if (dustAmount < hatprice)
        {
            Debug.Log("You don't have enough magic dust");
            GameObject.Find("NotEnoughDust").GetComponent<NotEnoughDust>().Background.enabled = true;
        }
    }
    void BuyTrue()
    {
        buy = true;
    }
    void BuyFalse()
    {
        buy = false;
    }
}
