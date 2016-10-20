using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DustController : MonoBehaviour {
    public int DustAmount;
    public GameObject WantToBuy;
    public GameObject NotEnoughDust;
    public GameObject WhiteBackground;
    public GameObject BuyConfirm;

    // Use this for initialization
    void Start ()
    {
        //Updates amount of dust
        DustAmount = GlobalManager.MagicDust;
        if(GameObject.FindGameObjectWithTag("DustAmount"))
        GameObject.FindGameObjectWithTag("DustAmount").GetComponent<Text>().text = DustAmount.ToString();

        //Checks if you have enough dust and if you want to buy the item
        NotEnoughDust.SetActive(false);
        WhiteBackground.SetActive(false);
        WantToBuy.SetActive(false);
        BuyConfirm.SetActive(false);
    }

    void Update()
    {
        if (DustAmount < 1)
            DustAmount = 0;
        UpdateDust();
    }

    //adds dust
    public void GetDust(int value)
    {
        DustAmount += value;
        GlobalManager.MagicDust = DustAmount;
        Debug.Log(value + " dust has been added");
    }

    //Loses dust
    public void LoseDust(int value)
    {
        DustAmount -= value;
        GlobalManager.MagicDust = DustAmount;
        Debug.Log(value + " dust has been lost");
    }

    //updates the amount of dust text
    public void UpdateDust()
    {
        DustAmount = GlobalManager.MagicDust;
        GameObject.FindGameObjectWithTag("DustAmount").GetComponent<Text>().text = DustAmount.ToString();
    }
}
