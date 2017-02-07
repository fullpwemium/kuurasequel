using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CatPageControl : MonoBehaviour {

    int foodPrice;
    int ballofyarnPrice;

    public int dustAmount;

    public Button Food, Ball;

    public Button CatControlButton, yesBuyButton, noBuyButton, buyConfirmButton;
    public Text confirmText, yesText, noText;
    public Image buyConfirmImage, backgroundImage;
    //public AudioClip yes;
    //public AudioClip no;
    //AudioSource audio;

    void Awake()
    {
        //Setting the food and ballofyarn prices
        foodPrice = 500;
        ballofyarnPrice = 750;
    }
	// Use this for initialization
	void Start ()
    {
        Food.onClick.AddListener(BuyFood);
        Ball.onClick.AddListener(BuyBall);

        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;
        buyConfirmButton.enabled = false;
        buyConfirmImage.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        backgroundImage.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
       
    }

    void BuyFood()
    {
        dustAmount = GameObject.Find("ShopBook").GetComponent<DustController>().DustAmount;
        yesBuyButton.onClick.RemoveAllListeners();
        noBuyButton.onClick.RemoveAllListeners();

        yesBuyButton.onClick.AddListener(BuyFoodTrue);
        noBuyButton.onClick.AddListener(BuyFoodFalse);

        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        backgroundImage.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        Debug.Log("BuyFood");

        if (dustAmount >= foodPrice)
        {
            confirmText.enabled = true;
            yesText.enabled = true;
            noText.enabled = true;

            yesBuyButton.enabled = true;
            yesBuyButton.GetComponent<Image>().enabled = true;

            backgroundImage.GetComponent<Image>().enabled = true;

            noBuyButton.enabled = true;
            noBuyButton.GetComponent<Image>().enabled = true;
        }
        else if (dustAmount < foodPrice)
        {
            GameObject.Find("NotEnoughDust").GetComponent<NotEnoughDust>().Background.enabled = true;
            confirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;
            //buyConfirmButton.enabled = false;
            //buyConfirmImage.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            backgroundImage.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;
            Debug.Log("You don't have enough magic dust");
        }
    }

    void BuyBall()
    {
        dustAmount = GameObject.Find("ShopBook").GetComponent<DustController>().DustAmount;
        yesBuyButton.onClick.RemoveAllListeners();
        noBuyButton.onClick.RemoveAllListeners();

        yesBuyButton.onClick.AddListener(BuyBallTrue);
        noBuyButton.onClick.AddListener(BuyBallFalse);

        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        backgroundImage.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        Debug.Log("BuyBall");

        if (dustAmount >= ballofyarnPrice)
        {
            confirmText.enabled = true;
            yesText.enabled = true;
            noText.enabled = true;

            yesBuyButton.enabled = true;
            yesBuyButton.GetComponent<Image>().enabled = true;

            backgroundImage.GetComponent<Image>().enabled = true;

            noBuyButton.enabled = true;
            noBuyButton.GetComponent<Image>().enabled = true;


        }

        else if (dustAmount < ballofyarnPrice)
        {
            GameObject.Find("NotEnoughDust").GetComponent<NotEnoughDust>().Background.enabled = true;
            confirmText.enabled = false;
            yesText.enabled = false;
            noText.enabled = false;

            yesBuyButton.enabled = false;
            yesBuyButton.GetComponent<Image>().enabled = false;

            backgroundImage.GetComponent<Image>().enabled = false;

            noBuyButton.enabled = false;
            noBuyButton.GetComponent<Image>().enabled = false;

            Debug.Log("You don't have enough magic dust");
        }
    }

    void BuyFoodTrue()
    {
        //audio.PlayOneShot(yes);

        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        backgroundImage.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        Debug.Log("You have bought 5 cans of cat food");
        GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(foodPrice);
        GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
        GameObject.Find("DummyPlayer").GetComponent<ItemControl>().AddFood(5);
        dustAmount = dustAmount - foodPrice;

        if (dustAmount < 1)
        {
            dustAmount = 0;
            GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
        }
    }

    void BuyFoodFalse()
    {
        //audio.PlayOneShot(no);

        Debug.Log("You didn't buy food");
        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        backgroundImage.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;
    }

    void BuyBallTrue()
    {
        //audio.PlayOneShot(yes);

        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        backgroundImage.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;

        Debug.Log("You have bought 5 ballsOfYarn");
        GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(ballofyarnPrice);
        GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
        GameObject.Find("DummyPlayer").GetComponent<ItemControl>().AddBall(5);
        dustAmount = dustAmount - ballofyarnPrice;

        if (dustAmount < 1)
        {
            dustAmount = 0;
            GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
        }
    }

    void BuyBallFalse()
    {
        //audio.PlayOneShot(no);

        Debug.Log("You didn't buy ball");
        confirmText.enabled = false;
        yesText.enabled = false;
        noText.enabled = false;

        yesBuyButton.enabled = false;
        yesBuyButton.GetComponent<Image>().enabled = false;

        backgroundImage.GetComponent<Image>().enabled = false;

        noBuyButton.enabled = false;
        noBuyButton.GetComponent<Image>().enabled = false;
    }
}
