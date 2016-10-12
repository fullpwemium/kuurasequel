using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LastPageControl : MonoBehaviour
{ 

    public Button LastPage;
   public int currentpage;
    public int lastpage = 10;
    GameObject book;
	// Use this for initialization
	void Start ()
    {
        LastPage.onClick.AddListener(Lastpage);
        book = GameObject.Find("ShopBook");
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Makes it so that the values of current page can't go to bad amounts
        if (currentpage < 0)
            currentpage = 0;
        else if (currentpage > lastpage)
            currentpage = lastpage;

        if (currentpage == 0 || book.GetComponent<Image>().enabled == false)
        {
            GetComponent<Image>().enabled = false;
        }
        else if (currentpage > 0 && book.GetComponent<Image>().enabled == true)
        {
            GetComponent<Image>().enabled = true;
        }
	}
    void Lastpage()
    {
        //changes the page
        currentpage--;
        Debug.Log("Previous page");
    }
}
