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

    int greyJacketBought;
    int orangeJacketBought;
    int redJacketBought;
    int greenJacketBought;
    int whiteJacketBought;

    int greyBootsBought;
    int orangeBootsBought;
    int redBootsBought;
    int greenBootsBought;
    int whiteBootsBought;

    public int sceneToLoad;

    int lastpage;

    public int currentpage;
    public int bobspage;
    public int menupage;
    public int hatpage;
    public int jacketpage;
    public int bootspage;
    public int catpage;

    public GameObject Bobbutton;
    public GameObject shopbook;
    public GameObject Menubutton;
    public GameObject NotEnoughDust, WantToBuy, BuyConfirm, WhiteBackground;

    public Button GreyHat, OrangeHat, RedHat, GreenHat, WhiteHat;
    public Image GreyHatImage, OrangeHatImage, RedHatImage, GreenHatImage, WhiteHatImage;
    public Image GreyHatOwned, OrangeHatOwned, RedHatOwned, GreenHatOwned, WhiteHatOwned;
    public Image GreyHatPriceImage, OrangeHatPriceImage, RedHatPriceImage, GreenHatPriceImage, WhiteHatPriceImage;
    public Text GreyHatPriceText, OrangeHatPriceText, RedHatPriceText, GreenHatPriceText, WhiteHatPriceText;

    public Button GreyJacket, OrangeJacket, RedJacket, GreenJacket, WhiteJacket;
    public Image GreyJacketImage, OrangeJacketImage, RedJacketImage, GreenJacketImage, WhiteJacketImage;
    public Image GreyJacketOwned, OrangeJacketOwned, RedJacketOwned, GreenJacketOwned, WhiteJacketOwned;
    public Image GreyJacketPriceImage, OrangeJacketPriceImage, RedJacketPriceImage, GreenJacketPriceImage, WhiteJacketPriceImage;
    public Text GreyJacketPriceText, OrangeJacketPriceText, RedJacketPriceText, GreenJacketPriceText, WhiteJacketPriceText;

    public Button GreyBoots, OrangeBoots, RedBoots, GreenBoots, WhiteBoots;
    public Image GreyBootsImage, OrangeBootsImage, RedBootsImage, GreenBootsImage, WhiteBootsImage;
    public Image GreyBootsOwned, OrangeBootsOwned, RedBootsOwned, GreenBootsOwned, WhiteBootsOwned;
    public Image GreyBootsPriceImage, OrangeBootsPriceImage, RedBootsPriceImage, GreenBootsPriceImage, WhiteBootsPriceImage;
    public Text GreyBootsPriceText, OrangeBootsPriceText, RedBootsPriceText, GreenBootsPriceText, WhiteBootsPriceText;

    public Button CatFood, BallOYarn;
    public Image CatFoodImage, BallOYarnImage;
    public Image CatFoodPriceImage, BallOYarnPriceImage;
    public Text CatFoodAmountText, BallOYarnAmountText, CatFoodPriceText, BallOYarnPriceText;


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

        //Gets the value of the jacket bought from the hard drive
        greyJacketBought = PlayerPrefs.GetInt("greyJacketOwned");
        orangeJacketBought = PlayerPrefs.GetInt("orangeJacketOwned");
        redJacketBought = PlayerPrefs.GetInt("redJacketOwned");
        greenJacketBought = PlayerPrefs.GetInt("greenJacketOwned");
        whiteJacketBought = PlayerPrefs.GetInt("whiteJacketOwned");

        //Gets the value of the boots bought from the hard drive
        greyBootsBought = PlayerPrefs.GetInt("greyBootsOwned");
        orangeBootsBought = PlayerPrefs.GetInt("orangeBootsOwned");
        redBootsBought = PlayerPrefs.GetInt("redBootsOwned");
        greenBootsBought = PlayerPrefs.GetInt("greenBootsOwned");
        whiteBootsBought = PlayerPrefs.GetInt("whiteBootsOwned");
    }

    void Update()
    {
        bootspage = GameObject.Find("BookButton").GetComponent<BookButtonControl>().bootspage - 3;
        jacketpage = GameObject.Find("BookButton").GetComponent<BookButtonControl>().jacketpage - 2;
        hatpage = GameObject.Find("BookButton").GetComponent<BookButtonControl>().hatpage - 1;
        catpage = GameObject.Find("BookButton").GetComponent<BookButtonControl>().catItemsPage - 5;

            //Making if it's possible to buy items true
        if (currentpage == hatpage || currentpage == jacketpage || currentpage == bootspage || currentpage == catpage)
        {
            //Making if it's possible to buy items true
            NotEnoughDust.SetActive(true);
            WhiteBackground.SetActive(true);
            WantToBuy.SetActive(true);
            BuyConfirm.SetActive(true);
        }
        else if (currentpage != hatpage || currentpage != jacketpage || currentpage != catpage || currentpage != bootspage)
        {
        //Making if it's possible to buy items false
            NotEnoughDust.SetActive(false);
            WhiteBackground.SetActive(false);
            WantToBuy.SetActive(false);
            BuyConfirm.SetActive(false);
        }

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

        }
        //---------------------------------------------------------------------------------------------------------------------------------------

        if (currentpage == jacketpage)
        {
            //Making everything in jacketpage control true if you are on it's page
            GreyJacketImage.enabled = true;
            OrangeJacketImage.enabled = true;
            RedJacketImage.enabled = true;
            GreenJacketImage.enabled = true;
            WhiteJacketImage.enabled = true;

            //changes the positions of the jackets on the jacketpage 
            GreyJacketImage.transform.position = new Vector2(-90f, 325f);
            OrangeJacketImage.transform.position = new Vector2(-80f, 240f);
            RedJacketImage.transform.position = new Vector2(-75f, 145f);
            GreenJacketImage.transform.position = new Vector2(-65f, 35f);
            WhiteJacketImage.transform.position = new Vector2(400f, 365f);


            GreyJacketPriceImage.enabled = true;
            OrangeJacketPriceImage.enabled = true;
            RedJacketPriceImage.enabled = true;
            GreenJacketPriceImage.enabled = true;
            WhiteJacketPriceImage.enabled = true;

            GreyJacketPriceText.enabled = true;
            OrangeJacketPriceText.enabled = true;
            RedJacketPriceText.enabled = true;
            GreenJacketPriceText.enabled = true;
            WhiteJacketPriceText.enabled = true;

        }
        else if (currentpage != jacketpage)
        {
            //Making everything false if you aren't on the jacket page
            GreyJacket.enabled = false;
            OrangeJacket.enabled = false;
            RedJacket.enabled = false;
            GreenJacket.enabled = false;
            WhiteJacket.enabled = false;

            GreyJacketImage.enabled = false;
            OrangeJacketImage.enabled = false;
            RedJacketImage.enabled = false;
            GreenJacketImage.enabled = false;
            WhiteJacketImage.enabled = false;

            GreyJacketOwned.enabled = false;
            OrangeJacketOwned.enabled = false;
            RedJacketOwned.enabled = false;
            GreenJacketOwned.enabled = false;
            WhiteJacketOwned.enabled = false;

            GreyJacketPriceImage.enabled = false;
            OrangeJacketPriceImage.enabled = false;
            RedJacketPriceImage.enabled = false;
            GreenJacketPriceImage.enabled = false;
            WhiteJacketPriceImage.enabled = false;

            GreyJacketPriceText.enabled = false;
            OrangeJacketPriceText.enabled = false;
            RedJacketPriceText.enabled = false;
            GreenJacketPriceText.enabled = false;
            WhiteJacketPriceText.enabled = false;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------

        if (currentpage == bootspage)
        {
            //Making everything in bootspagecontrol true if you are on it's page
            GreyBootsImage.enabled = true;
            OrangeBootsImage.enabled = true;
            RedBootsImage.enabled = true;
            GreenBootsImage.enabled = true;
            WhiteBootsImage.enabled = true;

            //changes the positions of the boots on the bootspage 
            GreyBootsImage.transform.position = new Vector2(-90f, 325f);
            OrangeBootsImage.transform.position = new Vector2(-80f, 240f);
            RedBootsImage.transform.position = new Vector2(-75f, 145f);
            GreenBootsImage.transform.position = new Vector2(-65f, 35f);
            WhiteBootsImage.transform.position = new Vector2(400f, 365f);


            GreyBootsPriceImage.enabled = true;
            OrangeBootsPriceImage.enabled = true;
            RedBootsPriceImage.enabled = true;
            GreenBootsPriceImage.enabled = true;
            WhiteBootsPriceImage.enabled = true;

            GreyBootsPriceText.enabled = true;
            OrangeBootsPriceText.enabled = true;
            RedBootsPriceText.enabled = true;
            GreenBootsPriceText.enabled = true;
            WhiteBootsPriceText.enabled = true;

        }
        else if (currentpage != bootspage)
        {
            //Making everything false if you aren't on the boots page
            GreyBoots.enabled = false;
            OrangeBoots.enabled = false;
            RedBoots.enabled = false;
            GreenBoots.enabled = false;
            WhiteBoots.enabled = false;

            GreyBootsImage.enabled = false;
            OrangeBootsImage.enabled = false;
            RedBootsImage.enabled = false;
            GreenBootsImage.enabled = false;
            WhiteBootsImage.enabled = false;

            GreyBootsOwned.enabled = false;
            OrangeBootsOwned.enabled = false;
            RedBootsOwned.enabled = false;
            GreenBootsOwned.enabled = false;
            WhiteBootsOwned.enabled = false;

            GreyBootsPriceImage.enabled = false;
            OrangeBootsPriceImage.enabled = false;
            RedBootsPriceImage.enabled = false;
            GreenBootsPriceImage.enabled = false;
            WhiteBootsPriceImage.enabled = false;

            GreyBootsPriceText.enabled = false;
            OrangeBootsPriceText.enabled = false;
            RedBootsPriceText.enabled = false;
            GreenBootsPriceText.enabled = false;
            WhiteBootsPriceText.enabled = false;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------

        if (currentpage == catpage)
        {
            //Making everything in catpagecontrol true if you are on cat page
            CatFood.enabled = true;
            BallOYarn.enabled = true;

            CatFoodImage.enabled = true;
            BallOYarnImage.enabled = true;

            CatFoodPriceImage.enabled = true;
            BallOYarnPriceImage.enabled = true;

            CatFoodPriceText.enabled = true;
            BallOYarnPriceText.enabled = true;

            CatFoodAmountText.enabled = true;
            BallOYarnAmountText.enabled = true;
        }
        else if (currentpage != catpage)
        {
            //Making everything in catpagecontrol false if you aren't on cat page
            CatFood.enabled = false;
            BallOYarn.enabled = false;

            CatFoodImage.enabled = false;
            BallOYarnImage.enabled = false;

            CatFoodPriceImage.enabled = false;
            BallOYarnPriceImage.enabled = false;

            CatFoodPriceText.enabled = false;
            BallOYarnPriceText.enabled = false;

            CatFoodAmountText.enabled = false;
            BallOYarnAmountText.enabled = false;

        }
//------------------------------------------------------------------------------------------------------------------------------------

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
        if (currentpage == bobspage)
        {
            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyJacketOwned == true || greyJacketBought == 1)
            {
                //Shows the image of grey jacket on bobspage if you have bought it
                GreyJacketImage.enabled = true;

                //changes the positions of the grey jacket on bobspage
                GreyJacketImage.transform.position = new Vector2(10f, 330f);
            }

            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyJacketOwned == false || greyJacketBought == 0)
            {
                //Doesn't show the image of grey jacket on bobspage if you haven't bought it
                GreyJacketImage.enabled = false;
            }

            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeJacketOwned == true || orangeJacketBought == 1)
            {
                //Shows the image of orange jacket on bobspage if you have bought it
                OrangeJacketImage.enabled = true;

                //changes the positions of the orange jacket on bobspage
                OrangeJacketImage.transform.position = new Vector2(10f, 245f);
            }

            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeJacketOwned == false || orangeJacketBought == 0)
            {
                //Doesn't show the image of orange jacket on bobspage if you haven't bought it
                OrangeJacketImage.enabled = false;
            }

            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedJacketOwned == true || redJacketBought == 1)
            {
                //Shows the image of red jacket on bobspage if you have bought it
                RedJacketImage.enabled = true;

                //changes the positions of the red jacket on bobspage
                RedJacketImage.transform.position = new Vector2(10f, 150f);
            }

            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedJacketOwned == false || redJacketBought == 0)
            {
                //Doesn't show the image of red jacket on bobspage if you haven't bought it
                RedJacketImage.enabled = false;
            }

            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenJacketOwned == true || greenJacketBought == 1)
            {
                //Shows the image of green jacket on bobspage if you have bought itä
                GreenJacketImage.enabled = true;
                
                //changes the positions of the green jacket on bobspage
                GreenJacketImage.transform.position = new Vector2(10f, 50f);
            }

            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenJacketOwned == false || greenJacketBought == 0)
            {
                //Doesn't show the image of green jacket on bobspage if you haven't bought it
                GreenJacketImage.enabled = false;
            }

            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteJacketOwned == true || whiteJacketBought == 1)
            {
                //Shows the image of white jacket on bobspage if you have bought it
                WhiteJacketImage.enabled = true;

                //changes the positions of the white jacket on bobspage
                WhiteJacketImage.transform.position = new Vector2(490f, 375f);
            }

            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteJacketOwned == false || whiteJacketBought == 0)
            {
                //Doesn't show the image of white jacket on bobspage if you haven't bought it
                WhiteJacketImage.enabled = false;
            }
        }

        //Checking if the player owns the boots and then shows them on bobspage in the correct position
        if (currentpage == bobspage)
        {
            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyBootsOwned == true || greyBootsBought == 1)
            {
                //Shows the image of grey boots on bobspage if you have bought it
                GreyBootsImage.enabled = true;

                //changes the positions of the grey boots on bobspage
                GreyBootsImage.transform.position = new Vector2(100f, 340f);
            }
            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyBootsOwned == false || greyBootsBought == 0)
            {
                //Doesn't show the image of grey boots on bobspage if you haven't bought it
                GreyBootsImage.enabled = false;
            }

            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeBootsOwned == true || orangeBootsBought == 1)
            {
                //Shows the image of orange boots on bobspage if you have bought it
                OrangeBootsImage.enabled = true;

                //changes the positions of the orange boots on bobspage
                OrangeBootsImage.transform.position = new Vector2(100f, 245f);
            }
            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeBootsOwned == false || orangeBootsBought == 0)
            {
                //Doesn't show the image of orange boots on bobspage if you haven't bought it
                OrangeBootsImage.enabled = false;
            }

            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedBootsOwned == true || redBootsBought == 1)
            {
                //Shows the image of red boots on bobspage if you have bought it
                RedBootsImage.enabled = true;

                //changes the positions of the red boots on bobspage
                RedBootsImage.transform.position = new Vector2(100f, 150f);
            }
            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedBootsOwned == false || redBootsBought == 0)
            {
                //Doesn't show the image of red Boots on bobspage if you haven't bought it
                RedBootsImage.enabled = false;
            }

            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenBootsOwned == true || greenBootsBought == 1)
            {
                //Shows the image of green boots on bobspage if you have bought it
                GreenBootsImage.enabled = true;

                //changes the positions of the green boots on bobspage
                GreenBootsImage.transform.position = new Vector2(100f, 50f);
            }
            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenBootsOwned == false || greenBootsBought == 0)
            {
                //Doesn't show the image of green Boots on bobspage if you haven't bought it
                GreenBootsImage.enabled = false;
            }

            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteBootsOwned == true || whiteBootsBought == 1)
            {
                //Shows the image of white boots on bobspage if you have bought it
                WhiteBootsImage.enabled = true;

                //changes the positions of the white boots on bobspage
                WhiteBootsImage.transform.position = new Vector2(575f, 375f);
            }
            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteBootsOwned == false || whiteBootsBought == 0)
            {
                //Doesn't show the image of white boots on bobspage if you haven't bought it
                WhiteBootsImage.enabled = false;
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
