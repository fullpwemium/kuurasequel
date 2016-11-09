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
    public Button limitedTimeButton;
    public Button limitedTextButton;

    public int hatpage;
    public int catItemsPage;
    public int powerUpsPage;
    public int jacketpage;
    public int dustpage;
    public int bootspage;
    public int leftpage;
    public int rightpage;
    public int glasspage;
    public int limitedpage;

    public Text hatpagetext;
    public Text catitemstext;
    public Text powerupstext;
    public Text jackettext;
    public Text dusttext;
    public Text bootstext;
    public Text glasstext;
    public Text limitedText;

    private AudioSource[] audioSources;
    private AudioSource bookCloseSound;
    private AudioSource bookOpenSound;
    private AudioSource cancelSound;
    private AudioSource okSound;
    private AudioSource pageTurnSound;

    void Awake()
    {
        //Makes the text of the button to be nothing
        hatpage = 2;
        jacketpage = 4;
        bootspage = 6;
        glasspage = 8;
        catItemsPage = 10;
        powerUpsPage = 12;
        limitedpage = 14;
        dustpage = 16;

        audioSources = GetComponents<AudioSource>();
        bookCloseSound = audioSources[0];
        bookOpenSound = audioSources[1];
        cancelSound = audioSources[2];
        okSound = audioSources[3];
        pageTurnSound = audioSources[4];

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

        limitedTimeButton.onClick.AddListener(LimitedTimePage);
        limitedTextButton.onClick.AddListener(LimitedTimePage);
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

            limitedTimeButton.GetComponent<Image>().enabled = true;
            limitedTextButton.GetComponent<Image>().enabled = true;
            limitedText.GetComponent<Text>().enabled = true;
            limitedTimeButton.enabled = true;
            limitedTextButton.enabled = true;
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

            limitedTimeButton.GetComponent<Image>().enabled = false;
            limitedTextButton.GetComponent<Image>().enabled = false;
            limitedText.GetComponent<Text>().enabled = false;
            limitedTimeButton.enabled = false;
            limitedTextButton.enabled = false;
        }
      
        GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
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
            Debug.Log("Book is opened now");
            shopbook.GetComponent<Image>().enabled = true;
            shopbook.GetComponent<Image>().sprite = openbook;

            bookCloseSound.Play();
        }
        else if (currentSprite != bookopen)
        {
            //checks if the currentsprite of the button isn't equal to bookopen, 
            //and if this is true then it swaps the picture to be an open book
            GetComponent<Image>().sprite = bookopen;
            Debug.Log("Book is closed now");
            shopbook.GetComponent<Image>().enabled = false;

            bookOpenSound.Play();
        }
    }

    void Hatpage()
    {
        //Changes the page
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().leftcounter = hatpage;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().rightcounter = hatpage + 1;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage = hatpage / 2;
        pageTurnSound.Play();
    }
    void CatItemsPage()
    {
        //Changes the page
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().leftcounter = catItemsPage;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().rightcounter = catItemsPage + 1;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage = catItemsPage / 2;
        pageTurnSound.Play();
    }
    void PowerUpsPage()
    {
        //Changes the page
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().leftcounter = powerUpsPage;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().rightcounter = powerUpsPage + 1;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage = powerUpsPage / 2;
        pageTurnSound.Play();
    }
    void JacketPage()
    {
        //Changes the page
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().leftcounter = jacketpage;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().rightcounter = jacketpage + 1;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage = jacketpage / 2;
        pageTurnSound.Play();
    }
   public void DustPage()
    {
        //Changes the page
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().leftcounter = dustpage;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().rightcounter = dustpage + 1;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage = dustpage / 2;
        pageTurnSound.Play();
    }
    void BootsPage()
    {
        //Changes the page
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().leftcounter = bootspage;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().rightcounter = bootspage + 1;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage = bootspage / 2;
        pageTurnSound.Play();
    }
    void GlassesPage()
    {
        //Changes the page
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().leftcounter = glasspage;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().rightcounter = glasspage + 1;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage = glasspage / 2;
        pageTurnSound.Play();
    }

    void LimitedTimePage()
    {
        //Changes the page
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().leftcounter = limitedpage;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().rightcounter = limitedpage + 1;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage = limitedpage / 2;
        pageTurnSound.Play();
    }
}
