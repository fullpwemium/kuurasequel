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
    public int sceneToLoad; 
    

    // Use this for initialization
    void Start()
    {
        //Programming buttons to call specific methods
        BackButton.onClick.AddListener(() => LoadScene(sceneToLoad));
        BookButton.onClick.AddListener(OpenBook);
        CartButton.onClick.AddListener(CartPage);
    }

    public void LoadScene(int scene)
    {
        //BackButton loads the worldmap
        SceneManager.LoadScene("Map2");
    }

    void OpenBook()
    {
        //BookButton opens the catalog
        Debug.Log("Open book");
    }

    void CartPage()
    {
        //CartButton opens the cartpage
        Debug.Log("CartPage");
    }
}
