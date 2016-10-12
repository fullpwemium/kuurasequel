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

    void Awake()
    {
        //Makes the text of the button to be nothing
        GetComponentInChildren<Text>().text = "";
    }

	// Use this for initialization
	void Start ()
    {
        shopbook = GameObject.Find("ShopBook");
        shopbook.GetComponent<Image>().enabled = false;
        currentSprite = GetComponent<Image>().sprite;
        BookButton.onClick.AddListener(OpenBook);
    }
	
	// Update is called once per frame
	void Update ()
    {
               
	}
    void OpenBook()
    {
        currentSprite = GetComponent<Image>().sprite;
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage = 0;
        
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
}
