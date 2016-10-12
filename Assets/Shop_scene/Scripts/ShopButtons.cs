using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopButtons : MonoBehaviour {

    //Setting buttons
    public Button BobButton;
    public Button CartButton;
    public Button BookButton;
    public Button BackButton;
    public Button MenuButton;
    public int sceneToLoad;
    int lastpage;
    int currentpage;
    int bobspage;
    int cartpage;
    int menupage;
    public GameObject Bobbutton;
    public GameObject shopbook;
    public GameObject Cartbutton;
    public GameObject Menubutton;
    // Use this for initialization
    void Start()
    {
        if (shopbook.GetComponent<Image>().enabled == false)
        {
            Bobbutton.GetComponent<Image>().enabled = false;
            Cartbutton.GetComponent<Image>().enabled = false;
            MenuButton.GetComponent<Image>().enabled = false;
        }
        else if (shopbook.GetComponent<Image>().enabled == true)
        {
            Bobbutton.GetComponent<Image>().enabled = true;
            Cartbutton.GetComponent<Image>().enabled = true;
            MenuButton.GetComponent<Image>().enabled = true;
        }
        menupage = 0;
        cartpage = 9;
        bobspage = 10;
        //Programming buttons to call specific methods
        BackButton.onClick.AddListener(() => LoadScene(sceneToLoad));
        CartButton.onClick.AddListener(CartPage);
        BobButton.onClick.AddListener(Bobpage);
        MenuButton.onClick.AddListener(Menupage);
    }

    void Update()
    {
        if (shopbook.GetComponent<Image>().enabled == false)
        {
            Bobbutton.GetComponent<Image>().enabled = false;
            Cartbutton.GetComponent<Image>().enabled = false;
            MenuButton.GetComponent<Image>().enabled = false;
        }
        else if(shopbook.GetComponent<Image>().enabled == true)
        {
            Bobbutton.GetComponent<Image>().enabled = true;
            Cartbutton.GetComponent<Image>().enabled = true;
            MenuButton.GetComponent<Image>().enabled = true;
        }
        currentpage = GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage;
        lastpage = GameObject.Find("BookLastPage").GetComponent<LastPageControl>().lastpage;
    }

    public void LoadScene(int scene)
    {
        //BackButton loads the worldmap
        SceneManager.LoadScene("Map2");
    }

    void CartPage()
    {
        //CartButton opens the cartpage
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage = cartpage;
        Debug.Log("CartPage");
    }
    void Bobpage()
    {
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage = bobspage;
        Debug.Log("Bob page");
    }
    void Menupage()
    {
        GameObject.Find("BookLastPage").GetComponent<LastPageControl>().currentpage = menupage;
        Debug.Log("Menu page");
    }
}
