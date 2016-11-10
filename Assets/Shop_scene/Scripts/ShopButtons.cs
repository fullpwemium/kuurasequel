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
    int blueHatBought;

    int greyJacketBought;
    int orangeJacketBought;
    int redJacketBought;
    int greenJacketBought;
    int whiteJacketBought;
    int blueJacketBought;

    int greyBootsBought;
    int orangeBootsBought;
    int redBootsBought;
    int greenBootsBought;
    int whiteBootsBought;
    int blueBootsBought;

    int greyGlassesBought;
    int orangeGlassesBought;
    int redGlassesBought;
    int greenGlassesBought;
    int whiteGlassesBought;
    int blueGlassesBought;

    public int sceneToLoad;

    public int lastpage;

    public int currentpage;
    public int bobspage;
    public int menupage;
    public int hatpage;
    public int jacketpage;
    public int bootspage;
    public int glassespage;
    public int catpage;

    public GameObject Bobbutton;
    public GameObject shopbook;
    public GameObject Menubutton;
    public GameObject NotEnoughDust, WantToBuy, BuyConfirm, WhiteBackground;

    public Button GreyHat, OrangeHat, RedHat, GreenHat, WhiteHat, BlueHat;
    public Image GreyHatImage, OrangeHatImage, RedHatImage, GreenHatImage, WhiteHatImage, BlueHatImage;
    public Image GreyHatOwned, OrangeHatOwned, RedHatOwned, GreenHatOwned, WhiteHatOwned, BlueHatOwned;
    public Image GreyHatSlot, OrangeHatSlot, RedHatSlot, GreenHatSlot, WhiteHatSlot, BlueHatSlot;
    public Image GreyHatPriceImage, OrangeHatPriceImage, RedHatPriceImage, GreenHatPriceImage, WhiteHatPriceImage, BlueHatPriceImage;
    public Text GreyHatPriceText, OrangeHatPriceText, RedHatPriceText, GreenHatPriceText, WhiteHatPriceText, BlueHatPriceText;

    public Button GreyJacket, OrangeJacket, RedJacket, GreenJacket, WhiteJacket, BlueJacket;
    public Image GreyJacketSlot, OrangeJacketSlot, RedJacketSlot, GreenJacketSlot, WhiteJacketSlot, BlueJacketSlot;
    public Image GreyJacketImage, OrangeJacketImage, RedJacketImage, GreenJacketImage, WhiteJacketImage, BlueJacketImage;
    public Image GreyJacketOwned, OrangeJacketOwned, RedJacketOwned, GreenJacketOwned, WhiteJacketOwned, BlueJacketOwned;
    public Image GreyJacketPriceImage, OrangeJacketPriceImage, RedJacketPriceImage, GreenJacketPriceImage, WhiteJacketPriceImage, BlueJacketPriceImage;
    public Text GreyJacketPriceText, OrangeJacketPriceText, RedJacketPriceText, GreenJacketPriceText, WhiteJacketPriceText, BlueJacketPriceText;

    public Button GreyBoots, OrangeBoots, RedBoots, GreenBoots, WhiteBoots, BlueBoots;
    public Image GreyBootsSlot, OrangeBootsSlot, RedBootsSlot, GreenBootsSlot, WhiteBootsSlot, BlueBootsSlot;
    public Image GreyBootsImage, OrangeBootsImage, RedBootsImage, GreenBootsImage, WhiteBootsImage, BlueBootsImage;
    public Image GreyBootsOwned, OrangeBootsOwned, RedBootsOwned, GreenBootsOwned, WhiteBootsOwned, BlueBootsOwned;
    public Image GreyBootsPriceImage, OrangeBootsPriceImage, RedBootsPriceImage, GreenBootsPriceImage, WhiteBootsPriceImage, BlueBootsPriceImage;
    public Text GreyBootsPriceText, OrangeBootsPriceText, RedBootsPriceText, GreenBootsPriceText, WhiteBootsPriceText, BlueBootsPriceText;

    public Button GreyGlasses, OrangeGlasses, RedGlasses, GreenGlasses, WhiteGlasses, BlueGlasses;
    public Image GreyGlassesImage, OrangeGlassesImage, RedGlassesImage, GreenGlassesImage, WhiteGlassesImage, BlueGlassesImage;
    public Image GreyGlassesSlot, OrangeGlassesSlot, RedGlassesSlot, GreenGlassesSlot, WhiteGlassesSlot, BlueGlassesSlot;
    public Image GreyGlassesOwned, OrangeGlassesOwned, RedGlassesOwned, GreenGlassesOwned, WhiteGlassesOwned, BlueGlassesOwned;
    public Image GreyGlassesPriceImage, OrangeGlassesPriceImage, RedGlassesPriceImage, GreenGlassesPriceImage, WhiteGlassesPriceImage, BlueGlassesPriceImage;
    public Text GreyGlassesPriceText, OrangeGlassesPriceText, RedGlassesPriceText, GreenGlassesPriceText, WhiteGlassesPriceText, blueGlassesPriceText;
    
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
        bobspage = 9;

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
        blueHatBought = PlayerPrefs.GetInt("blueHatOwned");

        //Gets the value of the jacket bought from the hard drive
        greyJacketBought = PlayerPrefs.GetInt("greyJacketOwned");
        orangeJacketBought = PlayerPrefs.GetInt("orangeJacketOwned");
        redJacketBought = PlayerPrefs.GetInt("redJacketOwned");
        greenJacketBought = PlayerPrefs.GetInt("greenJacketOwned");
        whiteJacketBought = PlayerPrefs.GetInt("whiteJacketOwned");
        blueJacketBought = PlayerPrefs.GetInt("blueJacketOwned");

        //Gets the value of the boots bought from the hard drive
        greyBootsBought = PlayerPrefs.GetInt("greyBootsOwned");
        orangeBootsBought = PlayerPrefs.GetInt("orangeBootsOwned");
        redBootsBought = PlayerPrefs.GetInt("redBootsOwned");
        greenBootsBought = PlayerPrefs.GetInt("greenBootsOwned");
        whiteBootsBought = PlayerPrefs.GetInt("whiteBootsOwned");
        blueBootsBought = PlayerPrefs.GetInt("blueBootsOwned");

        //Gets the value of the glasses bought from the hard drive
        greyGlassesBought = PlayerPrefs.GetInt("greyGlassesOwned");
        orangeGlassesBought = PlayerPrefs.GetInt("orangeGlassesOwned");
        redGlassesBought = PlayerPrefs.GetInt("redGlassesOwned");
        greenGlassesBought = PlayerPrefs.GetInt("greenGlassesOwned");
        whiteGlassesBought = PlayerPrefs.GetInt("whiteGlassesOwned");
        blueGlassesBought = PlayerPrefs.GetInt("blueGlassesOwned");
    }

    void Update()
    {          
        hatpage = GameObject.Find("BookButton").GetComponent<BookButtonControl>().hatpage - 1;
        glassespage = GameObject.Find("BookButton").GetComponent<BookButtonControl>().glasspage - 2;
        jacketpage = GameObject.Find("BookButton").GetComponent<BookButtonControl>().jacketpage - 3;
        bootspage = GameObject.Find("BookButton").GetComponent<BookButtonControl>().bootspage - 4;
        catpage = GameObject.Find("BookButton").GetComponent<BookButtonControl>().catItemsPage - 5;

        //Making if it's possible to buy items true
        if (currentpage == hatpage || currentpage == jacketpage || currentpage == bootspage || currentpage == glassespage || currentpage == catpage)
        {
            //Making if it's possible to buy items true
            NotEnoughDust.SetActive(true);
            WhiteBackground.SetActive(true);
            WantToBuy.SetActive(true);
            BuyConfirm.SetActive(true);
        }
        else if (currentpage != hatpage || currentpage != jacketpage || currentpage != catpage || currentpage != bootspage || currentpage != glassespage)
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
            BlueHatImage.enabled = true;

            GreyHatPriceImage.enabled = true;
            OrangeHatPriceImage.enabled = true;
            RedHatPriceImage.enabled = true;
            GreenHatPriceImage.enabled = true;
            WhiteHatPriceImage.enabled = true;
            BlueHatPriceImage.enabled = true;

            GreyHatPriceText.enabled = true;
            OrangeHatPriceText.enabled = true;
            RedHatPriceText.enabled = true;
            GreenHatPriceText.enabled = true;
            WhiteHatPriceText.enabled = true;
            BlueHatPriceText.enabled = true;
        }
        else if (currentpage != hatpage)
        {
            //Making everything in HatButtonController Gameobject false if you aren't on the hat page
            GreyHat.enabled = false;
            OrangeHat.enabled = false;
            RedHat.enabled = false;
            GreenHat.enabled = false;
            WhiteHat.enabled = false;
            BlueHat.enabled = false;

            GreyHatImage.enabled = false;
            OrangeHatImage.enabled = false;
            RedHatImage.enabled = false;
            GreenHatImage.enabled = false;
            WhiteHatImage.enabled = false;
            BlueHatImage.enabled = false;

            GreyHatOwned.enabled = false;
            OrangeHatOwned.enabled = false;
            RedHatOwned.enabled = false;
            GreenHatOwned.enabled = false;
            WhiteHatOwned.enabled = false;
            BlueHatOwned.enabled = false;

            GreyHatPriceImage.enabled = false;
            OrangeHatPriceImage.enabled = false;
            RedHatPriceImage.enabled = false;
            GreenHatPriceImage.enabled = false;
            WhiteHatPriceImage.enabled = false;
            BlueHatPriceImage.enabled = false;

            GreyHatPriceText.enabled = false;
            OrangeHatPriceText.enabled = false;
            RedHatPriceText.enabled = false;
            GreenHatPriceText.enabled = false;
            WhiteHatPriceText.enabled = false;
            BlueHatPriceText.enabled = false;
        }
        //---------------------------------------------------------------------------------------------------------------------------------------

        if (currentpage == glassespage)
        {
            //Making everything in glassespagecontrol true if you are on it's page
            GreyGlassesImage.enabled = true;
            OrangeGlassesImage.enabled = true;
            RedGlassesImage.enabled = true;
            GreenGlassesImage.enabled = true;
            WhiteGlassesImage.enabled = true;
            BlueGlassesImage.enabled = true;

            //changes the positions of the glasses on the glassespage 
            GreyGlassesImage.transform.position = new Vector2(-90f, 325f);
            OrangeGlassesImage.transform.position = new Vector2(-80f, 240f);
            RedGlassesImage.transform.position = new Vector2(-75f, 145f);
            GreenGlassesImage.transform.position = new Vector2(-65f, 35f);
            WhiteGlassesImage.transform.position = new Vector2(410f, 365f);
            BlueGlassesImage.transform.position = new Vector2(420f, 280f);

            GreyGlassesPriceImage.enabled = true;
            OrangeGlassesPriceImage.enabled = true;
            RedGlassesPriceImage.enabled = true;
            GreenGlassesPriceImage.enabled = true;
            WhiteGlassesPriceImage.enabled = true;
            BlueGlassesPriceImage.enabled = true;

            GreyGlassesPriceText.enabled = true;
            OrangeGlassesPriceText.enabled = true;
            RedGlassesPriceText.enabled = true;
            GreenGlassesPriceText.enabled = true;
            WhiteGlassesPriceText.enabled = true;
            blueGlassesPriceText.enabled = true;
        }
        else if (currentpage != glassespage)
        {
            //Making everything false if you aren't on the glasses page
            GreyGlasses.enabled = false;
            OrangeGlasses.enabled = false;
            RedGlasses.enabled = false;
            GreenGlasses.enabled = false;
            WhiteGlasses.enabled = false;
            BlueGlasses.enabled = false;

            GreyGlassesImage.enabled = false;
            OrangeGlassesImage.enabled = false;
            RedGlassesImage.enabled = false;
            GreenGlassesImage.enabled = false;
            WhiteGlassesImage.enabled = false;
            BlueGlassesImage.enabled = false;

            GreyGlassesOwned.enabled = false;
            OrangeGlassesOwned.enabled = false;
            RedGlassesOwned.enabled = false;
            GreenGlassesOwned.enabled = false;
            WhiteGlassesOwned.enabled = false;
            BlueGlassesOwned.enabled = false;

            GreyGlassesPriceImage.enabled = false;
            OrangeGlassesPriceImage.enabled = false;
            RedGlassesPriceImage.enabled = false;
            GreenGlassesPriceImage.enabled = false;
            WhiteGlassesPriceImage.enabled = false;
            BlueGlassesPriceImage.enabled = false;

            GreyGlassesPriceText.enabled = false;
            OrangeGlassesPriceText.enabled = false;
            RedGlassesPriceText.enabled = false;
            GreenGlassesPriceText.enabled = false;
            WhiteGlassesPriceText.enabled = false;
            blueGlassesPriceText.enabled = false;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------

        if (currentpage == jacketpage)
        {
            //Making everything in jacketpage control true if you are on it's page
            GreyJacketImage.enabled = true;
            OrangeJacketImage.enabled = true;
            RedJacketImage.enabled = true;
            GreenJacketImage.enabled = true;
            WhiteJacketImage.enabled = true;
            BlueJacketImage.enabled = true;

            //changes the positions of the jackets on the jacketpage 
            GreyJacketImage.transform.position = new Vector2(-90f, 325f);
            OrangeJacketImage.transform.position = new Vector2(-80f, 240f);
            RedJacketImage.transform.position = new Vector2(-75f, 145f);
            GreenJacketImage.transform.position = new Vector2(-65f, 35f);
            WhiteJacketImage.transform.position = new Vector2(400f, 365f);
            BlueJacketImage.transform.position = new Vector2(400f, 265f);

            GreyJacketPriceImage.enabled = true;
            OrangeJacketPriceImage.enabled = true;
            RedJacketPriceImage.enabled = true;
            GreenJacketPriceImage.enabled = true;
            WhiteJacketPriceImage.enabled = true;
            BlueJacketPriceImage.enabled = true;

            GreyJacketPriceText.enabled = true;
            OrangeJacketPriceText.enabled = true;
            RedJacketPriceText.enabled = true;
            GreenJacketPriceText.enabled = true;
            WhiteJacketPriceText.enabled = true;
            BlueJacketPriceText.enabled = true;

        }
        else if (currentpage != jacketpage)
        {
            //Making everything false if you aren't on the jacket page
            GreyJacket.enabled = false;
            OrangeJacket.enabled = false;
            RedJacket.enabled = false;
            GreenJacket.enabled = false;
            WhiteJacket.enabled = false;
            BlueJacket.enabled = false;

            GreyJacketImage.enabled = false;
            OrangeJacketImage.enabled = false;
            RedJacketImage.enabled = false;
            GreenJacketImage.enabled = false;
            WhiteJacketImage.enabled = false;
            BlueJacketImage.enabled = false;

            GreyJacketOwned.enabled = false;
            OrangeJacketOwned.enabled = false;
            RedJacketOwned.enabled = false;
            GreenJacketOwned.enabled = false;
            WhiteJacketOwned.enabled = false;
            BlueJacketOwned.enabled = false;

            GreyJacketPriceImage.enabled = false;
            OrangeJacketPriceImage.enabled = false;
            RedJacketPriceImage.enabled = false;
            GreenJacketPriceImage.enabled = false;
            WhiteJacketPriceImage.enabled = false;
            BlueJacketPriceImage.enabled = false;

            GreyJacketPriceText.enabled = false;
            OrangeJacketPriceText.enabled = false;
            RedJacketPriceText.enabled = false;
            GreenJacketPriceText.enabled = false;
            WhiteJacketPriceText.enabled = false;
            BlueJacketPriceText.enabled = false;
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
            BlueBootsImage.enabled = true;

            //changes the positions of the boots on the bootspage 
            GreyBootsImage.transform.position = new Vector2(-90f, 325f);
            OrangeBootsImage.transform.position = new Vector2(-80f, 240f);
            RedBootsImage.transform.position = new Vector2(-75f, 145f);
            GreenBootsImage.transform.position = new Vector2(-65f, 35f);
            WhiteBootsImage.transform.position = new Vector2(400f, 365f);
            BlueBootsImage.transform.position = new Vector2(420f, 265f);

            GreyBootsPriceImage.enabled = true;
            OrangeBootsPriceImage.enabled = true;
            RedBootsPriceImage.enabled = true;
            GreenBootsPriceImage.enabled = true;
            WhiteBootsPriceImage.enabled = true;
            BlueBootsPriceImage.enabled = true;

            GreyBootsPriceText.enabled = true;
            OrangeBootsPriceText.enabled = true;
            RedBootsPriceText.enabled = true;
            GreenBootsPriceText.enabled = true;
            WhiteBootsPriceText.enabled = true;
            BlueBootsPriceText.enabled = true;
        }
        else if (currentpage != bootspage)
        {
            //Making everything false if you aren't on the boots page
            GreyBoots.enabled = false;
            OrangeBoots.enabled = false;
            RedBoots.enabled = false;
            GreenBoots.enabled = false;
            WhiteBoots.enabled = false;
            BlueBoots.enabled = false;

            GreyBootsImage.enabled = false;
            OrangeBootsImage.enabled = false;
            RedBootsImage.enabled = false;
            GreenBootsImage.enabled = false;
            WhiteBootsImage.enabled = false;
            BlueBootsImage.enabled = false;

            GreyBootsOwned.enabled = false;
            OrangeBootsOwned.enabled = false;
            RedBootsOwned.enabled = false;
            GreenBootsOwned.enabled = false;
            WhiteBootsOwned.enabled = false;
            BlueBootsOwned.enabled = false;

            GreyBootsPriceImage.enabled = false;
            OrangeBootsPriceImage.enabled = false;
            RedBootsPriceImage.enabled = false;
            GreenBootsPriceImage.enabled = false;
            WhiteBootsPriceImage.enabled = false;
            BlueBootsPriceImage.enabled = false;

            GreyBootsPriceText.enabled = false;
            OrangeBootsPriceText.enabled = false;
            RedBootsPriceText.enabled = false;
            GreenBootsPriceText.enabled = false;
            WhiteBootsPriceText.enabled = false;
            BlueBootsPriceText.enabled = false;
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
                GreyHatSlot.enabled = false;
            }

            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyHatOwned == false || greyHatBought == 0)
            {
                //Doesn't show the image of grey hat on bobspage if you haven't bought it
                GreyHatImage.enabled = false;
                GreyHatSlot.enabled = true;
            }

            if(GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeHatOwned == true || orangeHatBought == 1)
            {
                //Shows the image of orange hat on bobspage if you have bought it
                OrangeHatImage.enabled = true;
                OrangeHatSlot.enabled = false;
            }

            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeHatOwned == false || orangeHatBought == 0)
            {
                //Doesn't show the image of orange hat on bobspage if you haven't bought it
                OrangeHatImage.enabled = false;
                OrangeHatSlot.enabled = true;
            }

            if(GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedHatOwned == true || redHatBought == 1)
            {
                //Shows the image of red hat on bobspage if you have bought it
                RedHatImage.enabled = true;
                RedHatSlot.enabled = false;
            }

            else if(GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedHatOwned == false || redHatBought == 0)
            {
                //Doesn't show the image of red hat on bobspage if you haven't bought it
                RedHatImage.enabled = false;
                RedHatSlot.enabled = true;
            }

            if(GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenHatOwned == true || greenHatBought == 1)
            {
                //Shows the image of green hat on bobspage if you have bought itä
                GreenHatImage.enabled = true;
                GreenHatSlot.enabled = false;
            }

            else if(GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenHatOwned == false || greenHatBought == 0)
            {
                //Doesn't show the image of green hat on bobspage if you haven't bought it
                GreenHatImage.enabled = false;
                GreenHatSlot.enabled = true;
            }

            if(GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteHatOwned == true || whiteHatBought == 1)
            {
                //Shows the image of white hat on bobspage if you have bought it
                WhiteHatImage.enabled = true;
                WhiteHatSlot.enabled = false;
            }

            else if(GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteHatOwned == false || whiteHatBought == 0)
            {
                //Doesn't show the image of white hat on bobspage if you haven't bought it
                WhiteHatImage.enabled = false;
                WhiteHatSlot.enabled = true;
            }

            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().BlueHatOwned == true || blueHatBought == 1)
            {
                //Shows the image of blue hat on bobspage if you have bought it
                BlueHatImage.enabled = true;
                BlueHatSlot.enabled = false;
            }

            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().BlueHatOwned == false || blueHatBought == 0)
            {
                //Doesn't show the image of blue hat on bobspage if you haven't bought it
                BlueHatImage.enabled = false;
                BlueHatSlot.enabled = true;
            }
        }
        else if (currentpage != bobspage)
        {
            GreyHatSlot.enabled = false;
            OrangeHatSlot.enabled = false;
            RedHatSlot.enabled = false;
            GreenHatSlot.enabled = false;
            WhiteHatSlot.enabled = false;
            BlueHatSlot.enabled = false;
        }
//-----------------------------------------------------------------------------------------------------------------------------------------

        //Checking if the player owns the glasses and then shows them on bobspage in the correct position
        if (currentpage == bobspage)
        {
            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyGlassesOwned == true || greyGlassesBought == 1)
            {
                //Shows the image of grey glasses on bobspage if you have bought it
                GreyGlassesImage.enabled = true;
                GreyGlassesSlot.enabled = false;

                //changes the positions of the grey glasses on bobspage
                GreyGlassesImage.transform.position = new Vector2(20f, 340f);
            }
            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyGlassesOwned == false || greyGlassesBought == 0)
            {
                //Doesn't show the image of grey glasses on bobspage if you haven't bought it
                GreyGlassesImage.enabled = false;
                GreyGlassesSlot.enabled = true;
            }

            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeGlassesOwned == true || orangeGlassesBought == 1)
            {
                //Shows the image of orange glasses on bobspage if you have bought it
                OrangeGlassesImage.enabled = true;
                OrangeGlassesSlot.enabled = false;

                //changes the positions of the orange glasses on bobspage
                OrangeGlassesImage.transform.position = new Vector2(20f, 245f);
            }
            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeGlassesOwned == false || orangeGlassesBought == 0)
            {
                //Doesn't show the image of orange glasses on bobspage if you haven't bought it
                OrangeGlassesImage.enabled = false;
                OrangeGlassesSlot.enabled = true;
            }

            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedGlassesOwned == true || redGlassesBought == 1)
            {
                //Shows the image of red glasses on bobspage if you have bought it
                RedGlassesImage.enabled = true;
                RedGlassesSlot.enabled = false;

                //changes the positions of the red glasses on bobspage
                RedGlassesImage.transform.position = new Vector2(20f, 150f);
            }
            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedGlassesOwned == false || redGlassesBought == 0)
            {
                //Doesn't show the image of red glasses on bobspage if you haven't bought it
                RedGlassesImage.enabled = false;
                RedGlassesSlot.enabled = true;
            }

            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenGlassesOwned == true || greenGlassesBought == 1)
            {
                //Shows the image of green glasses on bobspage if you have bought it
                GreenGlassesImage.enabled = true;
                GreenGlassesSlot.enabled = false;

                //changes the positions of the green glasses on bobspage
                GreenGlassesImage.transform.position = new Vector2(20f, 50f);
            }
            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenGlassesOwned == false || greenGlassesBought == 0)
            {
                //Doesn't show the image of green glasses on bobspage if you haven't bought it
                GreenGlassesImage.enabled = false;
                GreenGlassesSlot.enabled = true;
            }

            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteGlassesOwned == true || whiteGlassesBought == 1)
            {
                //Shows the image of white glasses on bobspage if you have bought it
                WhiteGlassesImage.enabled = true;
                WhiteGlassesSlot.enabled = false;

                //changes the positions of the white glasses on bobspage
                WhiteGlassesImage.transform.position = new Vector2(490f, 390f);
            }
            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteGlassesOwned == false || whiteGlassesBought == 0)
            {
                //Doesn't show the image of white glasses on bobspage if you haven't bought it
                WhiteGlassesImage.enabled = false;
                WhiteGlassesSlot.enabled = true;
            }

            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().BlueGlassesOwned == true || blueGlassesBought == 1)
            {
                //Shows the image of blue glasses on bobspage if you have bought it
                BlueGlassesImage.enabled = true;
                BlueGlassesSlot.enabled = false;

                //changes the positions of the blue glasses on bobspage
                BlueGlassesImage.transform.position = new Vector2(500f, 275f);
            }
            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteGlassesOwned == false || whiteGlassesBought == 0)
            {
                //Doesn't show the image of blue glasses on bobspage if you haven't bought it
                BlueGlassesImage.enabled = false;
                BlueGlassesSlot.enabled = true;
            }
        }
        else if (currentpage!=bobspage)
        {
            GreyGlassesSlot.enabled = false;
            OrangeGlassesSlot.enabled = false;
            RedGlassesSlot.enabled = false;
            GreenGlassesSlot.enabled = false;
            WhiteGlassesSlot.enabled = false;
            BlueGlassesSlot.enabled = false;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------
        if (currentpage == bobspage)
        {
            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyJacketOwned == true || greyJacketBought == 1)
            {
                //Shows the image of grey jacket on bobspage if you have bought it
                GreyJacketImage.enabled = true;
                GreyJacketSlot.enabled = false;

                //changes the positions of the grey jacket on bobspage
                GreyJacketImage.transform.position = new Vector2(110f, 340f);
            }

            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyJacketOwned == false || greyJacketBought == 0)
            {
                //Doesn't show the image of grey jacket on bobspage if you haven't bought it
                GreyJacketImage.enabled = false;
                GreyJacketSlot.enabled = true;
            }

            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeJacketOwned == true || orangeJacketBought == 1)
            {
                //Shows the image of orange jacket on bobspage if you have bought it
                OrangeJacketImage.enabled = true;
                OrangeJacketSlot.enabled = false;

                //changes the positions of the orange jacket on bobspage
                OrangeJacketImage.transform.position = new Vector2(110f, 245f);
            }

            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeJacketOwned == false || orangeJacketBought == 0)
            {
                //Doesn't show the image of orange jacket on bobspage if you haven't bought it
                OrangeJacketImage.enabled = false;
                OrangeJacketSlot.enabled = true;
            }

            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedJacketOwned == true || redJacketBought == 1)
            {
                //Shows the image of red jacket on bobspage if you have bought it
                RedJacketImage.enabled = true;
                RedJacketSlot.enabled = false;

                //changes the positions of the red jacket on bobspage
                RedJacketImage.transform.position = new Vector2(110f, 150f);
            }

            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedJacketOwned == false || redJacketBought == 0)
            {
                //Doesn't show the image of red jacket on bobspage if you haven't bought it
                RedJacketImage.enabled = false;
                RedJacketSlot.enabled = true;
            }

            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenJacketOwned == true || greenJacketBought == 1)
            {
                //Shows the image of green jacket on bobspage if you have bought itä
                GreenJacketImage.enabled = true;
                GreenJacketSlot.enabled = false;
                
                //changes the positions of the green jacket on bobspage
                GreenJacketImage.transform.position = new Vector2(110f, 50f);
            }

            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenJacketOwned == false || greenJacketBought == 0)
            {
                //Doesn't show the image of green jacket on bobspage if you haven't bought it
                GreenJacketImage.enabled = false;
                GreenJacketSlot.enabled = true;
            }

            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteJacketOwned == true || whiteJacketBought == 1)
            {
                //Shows the image of white jacket on bobspage if you have bought it
                WhiteJacketImage.enabled = true;
                WhiteJacketSlot.enabled = false;

                //changes the positions of the white jacket on bobspage
                WhiteJacketImage.transform.position = new Vector2(575f, 375f);
            }

            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteJacketOwned == false || whiteJacketBought == 0)
            {
                //Doesn't show the image of white jacket on bobspage if you haven't bought it
                WhiteJacketImage.enabled = false;
                WhiteJacketSlot.enabled = true;
            }

            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().BlueJacketOwned == true || blueJacketBought == 1)
            {
                //Shows the image of blue jacket on bobspage if you have bought it
                BlueJacketImage.enabled = true;
                BlueJacketSlot.enabled = false;

                //changes the positions of the blue jacket on bobspage
                BlueJacketImage.transform.position = new Vector2(590f, 275f);
            }

            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().BlueJacketOwned == false || blueJacketBought == 0)
            {
                //Doesn't show the image of blue jacket on bobspage if you haven't bought it
                BlueJacketImage.enabled = false;
                BlueJacketSlot.enabled = true;
            }
        }
        else if (currentpage!=bobspage)
        {
            GreyJacketSlot.enabled = false;
            OrangeJacketSlot.enabled = false;
            RedJacketSlot.enabled = false;
            GreenJacketSlot.enabled = false;
            WhiteJacketSlot.enabled = false;
            BlueJacketSlot.enabled = false;
        }
        //---------------------------------------------------------------------------------------------------------------------------------------


        //Checking if the player owns the boots and then shows them on bobspage in the correct position
        if (currentpage == bobspage)
        {
            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyBootsOwned == true || greyBootsBought == 1)
            {
                //Shows the image of grey boots on bobspage if you have bought it
                GreyBootsImage.enabled = true;
                GreyBootsSlot.enabled = false;

                //changes the positions of the grey boots on bobspage
                GreyBootsImage.transform.position = new Vector2(200f, 350f);
            }
            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreyBootsOwned == false || greyBootsBought == 0)
            {
                //Doesn't show the image of grey boots on bobspage if you haven't bought it
                GreyBootsImage.enabled = false;
                GreyBootsSlot.enabled = true;
            }

            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeBootsOwned == true || orangeBootsBought == 1)
            {
                //Shows the image of orange boots on bobspage if you have bought it
                OrangeBootsImage.enabled = true;
                OrangeBootsSlot.enabled = false;

                //changes the positions of the orange boots on bobspage
                OrangeBootsImage.transform.position = new Vector2(200f, 250f);
            }
            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().OrangeBootsOwned == false || orangeBootsBought == 0)
            {
                //Doesn't show the image of orange boots on bobspage if you haven't bought it
                OrangeBootsImage.enabled = false;
                OrangeBootsSlot.enabled = true;
            }

            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedBootsOwned == true || redBootsBought == 1)
            {
                //Shows the image of red boots on bobspage if you have bought it
                RedBootsImage.enabled = true;
                RedBootsSlot.enabled = false;

                //changes the positions of the red boots on bobspage
                RedBootsImage.transform.position = new Vector2(200f, 150f);
            }
            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().RedBootsOwned == false || redBootsBought == 0)
            {
                //Doesn't show the image of red Boots on bobspage if you haven't bought it
                RedBootsImage.enabled = false;
                RedBootsSlot.enabled = true;
            }

            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenBootsOwned == true || greenBootsBought == 1)
            {
                //Shows the image of green boots on bobspage if you have bought it
                GreenBootsImage.enabled = true;
                GreenBootsSlot.enabled = false;

                //changes the positions of the green boots on bobspage
                GreenBootsImage.transform.position = new Vector2(200f, 50f);
            }
            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().GreenBootsOwned == false || greenBootsBought == 0)
            {
                //Doesn't show the image of green Boots on bobspage if you haven't bought it
                GreenBootsImage.enabled = false;
                GreenBootsSlot.enabled = true;
            }

            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteBootsOwned == true || whiteBootsBought == 1)
            {
                //Shows the image of white boots on bobspage if you have bought it
                WhiteBootsImage.enabled = true;
                WhiteBootsSlot.enabled = false;

                //changes the positions of the white boots on bobspage
                WhiteBootsImage.transform.position = new Vector2(660f, 375f);
            }
            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().WhiteBootsOwned == false || whiteBootsBought == 0)
            {
                //Doesn't show the image of white boots on bobspage if you haven't bought it
                WhiteBootsImage.enabled = false;
                WhiteBootsSlot.enabled = true;
            }

            if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().BlueBootsOwned == true || blueBootsBought == 1)
            {
                //Shows the image of blue boots on bobspage if you have bought it
                BlueBootsImage.enabled = true;
                BlueBootsSlot.enabled = false;

                //changes the positions of the blue boots on bobspage
                BlueBootsImage.transform.position = new Vector2(670f, 275f);
            }
            else if (GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().BlueBootsOwned == false || blueBootsBought == 0)
            {
                //Doesn't show the image of white boots on bobspage if you haven't bought it
                BlueBootsImage.enabled = false;
                BlueBootsSlot.enabled = true;
            }
        }
        else if (currentpage != bobspage)
        {
            GreyBootsSlot.enabled = false;
            RedBootsSlot.enabled = false;
            OrangeBootsSlot.enabled = false;
            GreenBootsSlot.enabled = false;
            WhiteBootsSlot.enabled = false;
            BlueBootsSlot.enabled = false;
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
