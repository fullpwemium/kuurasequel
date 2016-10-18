using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NotEnoughDust : MonoBehaviour {
    public Image Background;
    public Text notEnoughDustText;
    public Button OkButton;
    public Button BuyMacigDustButton;
    public Button BuyMagicDustTextButton;
    public Text BuyMagicDustText;
    
	// Use this for initialization
	void Start ()
    {
        Background.enabled = false;
        OkButton.onClick.AddListener(RemoveBackGround);
        BuyMacigDustButton.onClick.AddListener(BuyMagicDust);
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Background.enabled == true)
        {
            notEnoughDustText.enabled = true;
            OkButton.enabled = true;
            BuyMacigDustButton.enabled = true;
            BuyMagicDustText.enabled = true;
            BuyMagicDustTextButton.enabled = true;
            BuyMacigDustButton.GetComponent<Image>().enabled = true;
            OkButton.GetComponent<Image>().enabled = true;
        }
        else
        {
            notEnoughDustText.enabled = false;
            OkButton.enabled = false;
            BuyMacigDustButton.enabled = false;
            BuyMagicDustText.enabled = false;
            BuyMagicDustTextButton.enabled = false;
            BuyMacigDustButton.GetComponent<Image>().enabled = false;
            OkButton.GetComponent<Image>().enabled = false;
        }
	}

    void RemoveBackGround()
    {
        Background.enabled = false;
    }

    void BuyMagicDust()
    {
        Background.enabled = false;
        GameObject.Find("BookButton").GetComponent<BookButtonControl>().DustPage();
    }
}
