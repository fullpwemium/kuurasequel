using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NextPageControl : MonoBehaviour {
    public Button NextPage;
    public GameObject Shopbook;
    int lastpage;
    int currentpage;
	// Use this for initialization
	void Start ()
    {
        NextPage.onClick.AddListener(Nextpage);
    }
	
	// Update is called once per frame
	void Update ()
    {
        currentpage = GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage;
        lastpage = GameObject.Find("BookLastPage").GetComponent<LastPageControl>().lastpage;

        //Checks if the shopbook is visible and if it is then it checks if lastpage is smaller than current page and then if both of those
        //are true it makes the image of next page arrow appear
        if (Shopbook.GetComponent<Image>().enabled == true)
        {
            if (lastpage > currentpage)
            {
                GetComponent<Image>().enabled = true;
            }
            else //Makes the next page arrow disappear if you are on the last page     
            {
                GetComponent<Image>().enabled = false;
            }
        }
        else if (Shopbook.GetComponent<Image>().enabled == true)
        {
            if (lastpage <= currentpage)
            {
                GetComponent<Image>().enabled = false;
            }
        }
        else if (Shopbook.GetComponent<Image>().enabled == false)
        {
            GetComponent<Image>().enabled = false;
        }
    }
    void Nextpage()
    {
        //changes the page
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage++;
        Debug.Log("Next page");
    }
}
