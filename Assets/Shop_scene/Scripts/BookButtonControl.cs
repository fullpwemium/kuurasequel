using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BookButtonControl : MonoBehaviour {

    public Sprite bookopen;
    public Sprite bookclosed;
    Sprite currentSprite;
    GameObject shopbook;
    public Sprite openbook;
    public Button BookButton;
    public Button hatpageButton;
    public Button hatpagetextButton;
    public Button catItemsPageButton;
    public Button catItemsTextButton;
    public Button powerUpsPageButton;
    public Button powerUpsTextButton;
    public Button jacketPageButton;
    public Button jacketTextButton;
    public Button dustPageButton;
    public Button dustTextButton;
    public Button bootsPageButton;
    public Button bootsTextButton;
    public Button glassesPageButton;
    public Button glassesTextButton;
    int hatpage;
    int catItemsPage;
    int powerUpsPage;
    int jacketpage;
    int dustpage;
    int bootspage;
    int leftpage;
    int rightpage;
    int glasspage;
    public Text hatpagetext;
    public Text catitemstext;
    public Text powerupstext;
    public Text jackettext;
    public Text dusttext;
    public Text bootstext;
    public Text glasstext;
    

    void Awake()
    {

        //Makes the text of the button to be nothing
        GetComponentInChildren<Text>().text = "";
        hatpage = 2;
        jacketpage = 4;
        bootspage = 6;
        glasspage = 8;
        catItemsPage = 10;
        powerUpsPage = 12;
        dustpage = 16;
    }

    // Use this for initialization
    void Start()
    {
        shopbook = GameObject.Find("ShopBook");
        shopbook.GetComponent<Image>().enabled = false;
        currentSprite = GetComponent<Image>().sprite;
        BookButton.onClick.AddListener(OpenBook);

        hatpageButton.onClick.AddListener(Hatpage);
        hatpagetextButton.onClick.AddListener(Hatpage);

        catItemsPageButton.onClick.AddListener(CatItemsPage);
        catItemsTextButton.onClick.AddListener(CatItemsPage);

        powerUpsPageButton.onClick.AddListener(PowerUpsPage);
        powerUpsTextButton.onClick.AddListener(PowerUpsPage);

        jacketPageButton.onClick.AddListener(JacketPage);
        jacketTextButton.onClick.AddListener(JacketPage);

        dustPageButton.onClick.AddListener(DustPage);
        dustTextButton.onClick.AddListener(DustPage);


        bootsPageButton.onClick.AddListener(BootsPage);
        bootsTextButton.onClick.AddListener(BootsPage);

       glassesPageButton.onClick.AddListener(GlassesPage);
        glassesTextButton.onClick.AddListener(GlassesPage);
    }

    // Update is called once per frame
    void Update()
    {
        leftpage = GameObject.Find("BookLastPage").GetComponent<LastPageControl>().leftcounter;
        rightpage = GameObject.Find("BookLastPage").GetComponent<LastPageControl>().rightcounter;

        //Makes the buttons appear if the book is open and you are on the menu page
        if (leftpage == 0 && rightpage == 1 && shopbook.GetComponent<Image>().enabled == true)
        {
            hatpageButton.GetComponent<Image>().enabled = true;
            hatpagetextButton.GetComponent<Image>().enabled = true;
            hatpagetext.GetComponent<Text>().enabled = true;
            hatpageButton.enabled = true;
            hatpagetextButton.enabled = true;

            catItemsPageButton.GetComponent<Image>().enabled = true;
            catItemsTextButton.GetComponent<Image>().enabled = true;
            catitemstext.GetComponent<Text>().enabled = true;
            catItemsPageButton.enabled = true;
            catItemsTextButton.enabled = true;

            powerUpsPageButton.GetComponent<Image>().enabled = true;
            powerUpsTextButton.GetComponent<Image>().enabled = true;
            powerupstext.GetComponent<Text>().enabled = true;
            powerUpsPageButton.enabled = true;
            powerUpsTextButton.enabled = true;

            jacketPageButton.GetComponent<Image>().enabled = true;
            jacketTextButton.GetComponent<Image>().enabled = true;
            jackettext.GetComponent<Text>().enabled = true;
            jacketPageButton.enabled = true;
            jacketTextButton.enabled = true;

            dustPageButton.GetComponent<Image>().enabled = true;
            dustTextButton.GetComponent<Image>().enabled = true;
            dusttext.GetComponent<Text>().enabled = true;
            dustPageButton.enabled = true;
            dustTextButton.enabled = true;

            bootsPageButton.GetComponent<Image>().enabled = true;
            bootsTextButton.GetComponent<Image>().enabled = true;
            bootstext.GetComponent<Text>().enabled = true;
            bootsPageButton.enabled = true;
            bootsTextButton.enabled = true;

            glassesPageButton.GetComponent<Image>().enabled = true;
            glassesTextButton.GetComponent<Image>().enabled = true;
            glasstext.GetComponent<Text>().enabled = true;
            glassesPageButton.enabled = true;
            glassesTextButton.enabled = true;
        }
        else
        {
            //Makes the buttons disappear if the book isn't open or if you aren't on the menu page
            hatpageButton.GetComponent<Image>().enabled = false;
            hatpagetextButton.GetComponent<Image>().enabled = false;
            hatpagetext.GetComponent<Text>().enabled = false;
            hatpageButton.enabled = false;
            hatpagetextButton.enabled = false;

            catItemsPageButton.GetComponent<Image>().enabled = false;
            catItemsTextButton.GetComponent<Image>().enabled = false;
            catitemstext.GetComponent<Text>().enabled = false;
            catItemsPageButton.enabled = false;
            catItemsTextButton.enabled = false;

            powerUpsPageButton.GetComponent<Image>().enabled = false;
            powerUpsTextButton.GetComponent<Image>().enabled = false;
            powerupstext.GetComponent<Text>().enabled = false;
            powerUpsPageButton.enabled = false;
            powerUpsTextButton.enabled = false;

            jacketPageButton.GetComponent<Image>().enabled = false;
            jacketTextButton.GetComponent<Image>().enabled = false;
            jackettext.GetComponent<Text>().enabled = false;
            jacketPageButton.enabled = false;
            jacketTextButton.enabled = false;

            dustPageButton.GetComponent<Image>().enabled = false;
            dustTextButton.GetComponent<Image>().enabled = false;
            dusttext.GetComponent<Text>().enabled = false;
            dustPageButton.enabled = false;
            dustTextButton.enabled = false;

            bootsPageButton.GetComponent<Image>().enabled = false;
            bootsTextButton.GetComponent<Image>().enabled = false;
            bootstext.GetComponent<Text>().enabled = false;
            bootsPageButton.enabled = false;
            bootsTextButton.enabled = false;

            glassesPageButton.GetComponent<Image>().enabled = false;
            glassesTextButton.GetComponent<Image>().enabled = false;
            glasstext.GetComponent<Text>().enabled = false;
            glassesPageButton.enabled = false;
            glassesTextButton.enabled = false;
        }

    }
    void OpenBook()
    {
        currentSprite = GetComponent<Image>().sprite;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage = 0;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().rightcounter = 1;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().leftcounter = 0;
        //enables the image of shopbook and changes the image of the button to be a picture of a book closed
        if (currentSprite == bookopen)
        {
            GetComponent<Image>().sprite = bookclosed;
            Debug.Log("Book is closed now");
            shopbook.GetComponent<Image>().enabled = true;
            shopbook.GetComponent<Image>().sprite = openbook;
        }
        else if (currentSprite != bookopen)
        {
            //checks if the currentsprite of the button isn't equal to bookopen, 
            //and if this is true then it swaps the picture to be an open book
            GetComponent<Image>().sprite = bookopen;
            Debug.Log("Book is opened now");
            shopbook.GetComponent<Image>().enabled = false;
        }
    }

    void Hatpage()
    {
        //Changes the page
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().leftcounter = hatpage;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().rightcounter = hatpage + 1;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage = hatpage / 2;
    }
    void CatItemsPage()
    {
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().leftcounter = catItemsPage;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().rightcounter = catItemsPage + 1;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage = catItemsPage / 2;
    }
    void PowerUpsPage()
    {
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().leftcounter = powerUpsPage;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().rightcounter = powerUpsPage + 1;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage = powerUpsPage / 2;
    }
    void JacketPage()
    {
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().leftcounter = jacketpage;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().rightcounter = jacketpage + 1;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage = jacketpage / 2;
    }
    void DustPage()
    {
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().leftcounter = dustpage;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().rightcounter = dustpage + 1;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage = dustpage / 2;
    }
    void BootsPage()
    {
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().leftcounter = bootspage;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().rightcounter = bootspage + 1;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage = bootspage / 2;
    }
    void GlassesPage()
    {
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().leftcounter = glasspage;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().rightcounter = glasspage + 1;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage = glasspage / 2;
    }
}
