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
    int hatpage;
    int leftpage;
    int rightpage;
    public Text hatpagetext;
   
    void Awake()
    {
       
        //Makes the text of the button to be nothing
        GetComponentInChildren<Text>().text = "";
        hatpage = 4;
    }

	// Use this for initialization
	void Start ()
    {
        shopbook = GameObject.Find("ShopBook");
        shopbook.GetComponent<Image>().enabled = false;
        currentSprite = GetComponent<Image>().sprite;
        BookButton.onClick.AddListener(OpenBook);
        hatpageButton.onClick.AddListener(Hatpage);
        hatpagetextButton.onClick.AddListener(Hatpage);
       
    }
	
	// Update is called once per frame
	void Update ()
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
        }
        else
        {
            //Makes the buttons disappear if the book isn't open or if you aren't on the menu page
            hatpageButton.GetComponent<Image>().enabled = false;
            hatpagetextButton.GetComponent<Image>().enabled = false;
            hatpagetext.GetComponent<Text>().enabled = false;
            hatpageButton.enabled = false;
            hatpagetextButton.enabled = false;
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
}
