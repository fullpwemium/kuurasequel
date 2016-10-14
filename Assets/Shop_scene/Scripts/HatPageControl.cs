using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HatPageControl : MonoBehaviour {

    public Button BlackHat;
    public Button WhiteHat;
    public Button GreenHat;
    public Button RedHat;
    public Button OrangeHat;
    public Button HatControlButton;

    int currentpage;
    int hatpage;
    int hatprice;
    public int dustAmount;
    // Use this for initialization
    void Start()
    {
        hatprice = 500;
        HatControlButton.enabled = false;
        HatControlButton.GetComponent<Image>().enabled = false;
        BlackHat.onClick.AddListener(BuyHat);
        WhiteHat.onClick.AddListener(BuyHat);
        GreenHat.onClick.AddListener(BuyHat);
        RedHat.onClick.AddListener(BuyHat);
        OrangeHat.onClick.AddListener(BuyHat);
    }
	// Update is called once per frame
	void Update ()
    {
        dustAmount = GameObject.Find("ShopBook").GetComponent<DustController>().DustAmount;
        hatpage = GameObject.Find("BookButton").GetComponent<BookButtonControl>().hatpage-1;
        currentpage = GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage;
        if (hatpage == currentpage)
        {
            BlackHat.enabled = true;
            BlackHat.GetComponent<Image>().enabled = true;

            WhiteHat.enabled = true;
            WhiteHat.GetComponent<Image>().enabled = true;

            GreenHat.enabled = true;
            GreenHat.GetComponent<Image>().enabled = true;

            RedHat.enabled = true;
            RedHat.GetComponent<Image>().enabled = true;

            OrangeHat.enabled = true;
            OrangeHat.GetComponent<Image>().enabled = true;
        }
        else
        {
            BlackHat.enabled = false;
            BlackHat.GetComponent<Image>().enabled = false;

            WhiteHat.enabled = false;
            WhiteHat.GetComponent<Image>().enabled = false;

            GreenHat.enabled = false;
            GreenHat.GetComponent<Image>().enabled = false;

            RedHat.enabled = false;
            RedHat.GetComponent<Image>().enabled = false;

            OrangeHat.enabled = false;
            OrangeHat.GetComponent<Image>().enabled = false;
        }
	}
    void BuyHat()
    {
        GameObject.Find("ShopBook").GetComponent<DustController>().LoseDust(hatprice);
        GameObject.Find("ShopBook").GetComponent<DustController>().UpdateDust();
    }
}
