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
    private bool playSound;

	// Use this for initialization
	void Start ()
    {
        playSound = true;
        Background.enabled = false;
        OkButton.onClick.AddListener(RemoveBackGround);
        BuyMacigDustButton.onClick.AddListener(BuyMagicDust);
        BuyMagicDustTextButton.onClick.AddListener(BuyMagicDust);
	}
	
	// Update is called once per frame
	void Update ()
    {
        //If the background of not enough dust is true then all of the buy more dust elements are shown
        if (Background.enabled == true)
        {        
            PlaySoundEffect();
            notEnoughDustText.enabled = true;
            OkButton.enabled = true;
            BuyMacigDustButton.enabled = true;
            BuyMagicDustText.enabled = true;
            BuyMagicDustTextButton.enabled = true;
            BuyMacigDustButton.GetComponent<Image>().enabled = true;
            OkButton.GetComponent<Image>().enabled = true;
        }
        else  //If the background of not enough dust isn't true then all of the buy more dust elements aren't shown
        {
            playSound = true;
            notEnoughDustText.enabled = false;
            OkButton.enabled = false;
            BuyMacigDustButton.enabled = false;
            BuyMagicDustText.enabled = false;
            BuyMagicDustTextButton.enabled = false;
            BuyMacigDustButton.GetComponent<Image>().enabled = false;
            OkButton.GetComponent<Image>().enabled = false;
        }
	}

    //Removes the background of buying magic dust
    void RemoveBackGround()
    {
        Background.enabled = false;
    }

    //Throws the player to the dust page;
    void BuyMagicDust()
    {
        RemoveBackGround();
        GameObject.Find("BookButton").GetComponent<BookButtonControl>().DustPage();
    }

    private void PlaySoundEffect() {

        if (playSound) {
            MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.bubbleBurst1, 1);
            playSound = false;
        }
                
    }
        

    

}
