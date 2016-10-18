using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LastPageControl : MonoBehaviour
{ 

    public Button LastPage;
    public int currentpage;
    public int lastpage;
    public Text leftpagecounter;
   public int leftcounter;
   public int rightcounter = 1;
    public Text rightpagecounter;
    GameObject book;
    int leftpagemax;
    int rightpagemax;
    // Use this for initialization
    void Awake()
    {
        lastpage = 12;
        leftpagemax = lastpage * 2;
        rightpagemax = lastpage * 2 + 1;
    }

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

        //sets the left counter to be the maximum left page if it goes over the last page
        if (leftpagemax <= leftcounter)
        {
            leftcounter = leftpagemax;
        }

        //sets the right counter to be the maximum right page if it goes over the last page
        if (rightpagemax <= rightcounter)
        {
            rightcounter = rightpagemax;
        }

        //makes sure that the right counter can't go to negative numbers
        if (rightcounter < 2)
        {
            rightcounter = 1;
        }

        // makes sure that the left counter can't go to negative numbers
        if (leftcounter < 1)
        {
            leftcounter = 0;
        }

        //Checks if the book is visible and if it isn't it makes the page numbers disappear
        if (book.GetComponent<Image>().enabled == false)
        {
            leftpagecounter.enabled = false;
            rightpagecounter.enabled = false;
        } //Checks if the book is visible and if it is it makes the page numbers appear
        else if (book.GetComponent<Image>().enabled == true)
        {
            leftpagecounter.enabled = true;
            rightpagecounter.enabled = true;
        }

        //Checks if the left counter is equal to 0, and if it is it makes it disappear
        if (leftcounter == 0)
            leftpagecounter.enabled = false;

        leftpagecounter.text = leftcounter.ToString();
        rightpagecounter.text = rightcounter.ToString();
	}
    void Lastpage()
    {
        //changes the page
        currentpage--;
        Leftpagedown(2);
        Rightpagedown(2);
        Debug.Log("Previous page");
    }

    public void Leftpageup(int pagenumber)
    {
        leftcounter += pagenumber;
    }

    public void Rightpageup(int pagenumber)
    {
        rightcounter += pagenumber;
    }

    public void Leftpagedown(int pagenumber)
    {
        leftcounter -= pagenumber;
    }

    public void Rightpagedown(int pagenumber)
    {
        rightcounter -= pagenumber;
    }
}
