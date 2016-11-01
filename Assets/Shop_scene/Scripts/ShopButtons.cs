using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopButtons : MonoBehaviour {

    //Setting buttons
    public Button BobButton;
    public Button BookButton;
    public Button BackButton;
    public Button MenuButton;

    int greyHatBought;
    int orangeHatBought;
    int redHatBought;
    int greenHatBought;
    int whiteHatBought;

    public int sceneToLoad;

    int lastpage;

    public int currentpage;
    public int bobspage;
    public int menupage;
    public int hatpage;
    public int jacketpage;

    public GameObject Bobbutton;
    public GameObject shopbook;
    public GameObject Menubutton;
    public GameObject NotEnoughDust, WantToBuy, BuyConfirm, WhiteBackground;

    public Button GreyHat, OrangeHat, RedHat, GreenHat, WhiteHat;
    public Image GreyHatImage, OrangeHatImage, RedHatImage, GreenHatImage, WhiteHatImage;
    public Image GreyHatOwned, OrangeHatOwned, RedHatOwned, GreenHatOwned, WhiteHatOwned;
    public Image GreyHatPriceImage, OrangeHatPriceImage, RedHatPriceImage, GreenHatPriceImage, WhiteHatPriceImage;
    public Text GreyHatPriceText, OrangeHatPriceText, RedHatPriceText, GreenHatPriceText, WhiteHatPriceText;

    // Use this for initialization
    void Start()
    {
        if (shopbook.GetComponent<Image>().enabled == false)
        {
            Bobbutton.GetComponent<Image>().enabled = false;
            MenuButton.GetComponent<Image>().enabled = false;
        }
        else if (shopbook.GetComponent<Image>().enabled == true)
        {
            Bobbutton.GetComponent<Image>().enabled = true;
            MenuButton.GetComponent<Image>().enabled = true;
        }
        menupage = 0;
        bobspage = 11;

        //Programming buttons to call specific methods
        BackButton.onClick.AddListener(() => LoadScene(sceneToLoad));
        BobButton.onClick.AddListener(Bobpage);
        MenuButton.onClick.AddListener(Menupage);

        //Gets the value of the hat bought from the hard drive
        greyHatBought = PlayerPrefs.GetInt("greyHatOwned");
        orangeHatBought = PlayerPrefs.GetInt("orangeHatOwned");
        redHatBought = PlayerPrefs.GetInt("redHatOwned");
        greenHatBought = PlayerPrefs.GetInt("greenHatOwned");
        whiteHatBought = PlayerPrefs.GetInt("whiteHatOwned");
    }

    void Update()
    {
        jacketpage=GameObject.Find("BookButton").GetComponent<BookButtonControl>().jacketpage-1;
        hatpage = GameObject.Find("BookButton").GetComponent<BookButtonControl>().hatpage - 1;

        //---------------------------------------------------------------------------------------------------------------------------------------
        //Compares the current page to hat page
        if (currentpage == hatpage)
        {
            //Making everything in HatButtonController Gameobject true if you are on the hat page
            GreyHatImage.enabled = true;
            OrangeHatImage.enabled = true;
            RedHatImage.enabled = true;
            GreenHatImage.enabled = true;
            WhiteHatImage.enabled = true;

            GreyHatPriceImage.enabled = true;
            OrangeHatPriceImage.enabled = true;
            RedHatPriceImage.enabled = true;
            GreenHatPriceImage.enabled = true;
            WhiteHatPriceImage.enabled = true;

            GreyHatPriceText.enabled = true;
            OrangeHatPriceText.enabled = true;
            RedHatPriceText.enabled = true;
            GreenHatPriceText.enabled = true;
            WhiteHatPriceText.enabled = true;

            //Making if it's possible to buy a hat true
            NotEnoughDust.SetActive(true);
            WhiteBackground.SetActive(true);
            WantToBuy.SetActive(true);
            BuyConfirm.SetActive(true);
        }
        else if (currentpage != hatpage)
        {
            //Making everything in HatButtonController Gameobject false if you aren't on the hat page
            GreyHat.enabled = false;
            OrangeHat.enabled = false;
            RedHat.enabled = false;
            GreenHat.enabled = false;
            WhiteHat.enabled = false;

            GreyHatImage.enabled = false;
            OrangeHatImage.enabled = false;
            RedHatImage.enabled = false;
            GreenHatImage.enabled = false;
            WhiteHatImage.enabled = false;

            GreyHatOwned.enabled = false;
            OrangeHatOwned.enabled = false;
            RedHatOwned.enabled = false;
            GreenHatOwned.enabled = false;
            WhiteHatOwned.enabled = false;

            GreyHatPriceImage.enabled = false;
            OrangeHatPriceImage.enabled = false;
            RedHatPriceImage.enabled = false;
            GreenHatPriceImage.enabled = false;
            WhiteHatPriceImage.enabled = false;

            GreyHatPriceText.enabled = false;
            OrangeHatPriceText.enabled = false;
            RedHatPriceText.enabled = false;
            GreenHatPriceText.enabled = false;
            WhiteHatPriceText.enabled = false;

            //Making if it's possible to buy a hat false
            NotEnoughDust.SetActive(false);
            WhiteBackground.SetActive(false);
            WantToBuy.SetActive(false);
            BuyConfirm.SetActive(false);
        }
        //---------------------------------------------------------------------------------------------------------------------------------------

        //Checks if current page is bobs page
       if (currentpage == bobspage)
        {
            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyHatOwned == true || greyHatBought == 1)
            {
                //Shows the image of grey hat on bobspage if you have bought it
                GreyHatImage.enabled = true;
            }

            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyHatOwned == false || greyHatBought == 0)
            {
                //Doesn't show the image of grey hat on bobspage if you haven't bought it
                GreyHatImage.enabled = false;
            }

            if(GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeHatOwned == true || orangeHatBought == 1)
            {
                //Shows the image of orange hat on bobspage if you have bought it
                OrangeHatImage.enabled = true;
            }

            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeHatOwned == false || orangeHatBought == 0)
            {
                //Doesn't show the image of orange hat on bobspage if you haven't bought it
                OrangeHatImage.enabled = false;
            }

            if(GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedHatOwned == true || redHatBought == 1)
            {
                //Shows the image of red hat on bobspage if you have bought it
                RedHatImage.enabled = true;
            }

            else if(GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedHatOwned == false || redHatBought == 0)
            {
                //Doesn't show the image of red hat on bobspage if you haven't bought it
                RedHatImage.enabled = false;
            }

            if(GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenHatOwned == true || greenHatBought == 1)
            {
                //Shows the image of green hat on bobspage if you have bought itä
                GreenHatImage.enabled = true;
            }

            else if(GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenHatOwned == false || greenHatBought == 0)
            {
                //Doesn't show the image of green hat on bobspage if you haven't bought it
                GreenHatImage.enabled = false;
            }

            if(GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteHatOwned == true || whiteHatBought == 1)
            {
                //Shows the image of white hat on bobspage if you have bought it
                WhiteHatImage.enabled = true;
            }

            else if(GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteHatOwned == false || whiteHatBought == 0)
            {
                //Doesn't show the image of white hat on bobspage if you haven't bought it
                WhiteHatImage.enabled = false;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------

        if (shopbook.GetComponent<Image>().enabled == false)
        {
            Bobbutton.GetComponent<Image>().enabled = false;
            MenuButton.GetComponent<Image>().enabled = false;
        }
        else if(shopbook.GetComponent<Image>().enabled == true)
        {
            Bobbutton.GetComponent<Image>().enabled = true;
            MenuButton.GetComponent<Image>().enabled = true;
        }
        //---------------------------------------------------------------------------------------------------------------------------------------

        currentpage = GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage;
        lastpage = GameObject.Find("BookLastPage").GetComponent<LastPageControl>().lastpage;
    }

    public void LoadScene(int scene)
    {
        //BackButton loads the worldmap
        SceneManager.LoadScene("MapScene/Map2");
    }

    void Bobpage()
    {
        //BobButton opens the inventory
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage = bobspage;
        Debug.Log("Bob page");
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().leftcounter = bobspage*2;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().rightcounter = bobspage*2+1;
    }
    void Menupage()
    {
        //Opens the menu page, you will also start on this page
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage = menupage;
        Debug.Log("Menu page");
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().leftcounter = menupage;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().rightcounter = menupage + 1;
    }
}
