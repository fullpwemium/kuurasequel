using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DustController : MonoBehaviour {
    public int DustAmount;
    // Use this for initialization
    void Start ()
    {
        //Updates amount of dust
        DustAmount = GlobalManager.MagicDust;
        if(GameObject.FindGameObjectWithTag("DustAmount"))
        GameObject.FindGameObjectWithTag("DustAmount").GetComponent<Text>().text = DustAmount.ToString();
    }

    //adds dust
    public void GetDust(int value)
    {
        DustAmount += value;
        GlobalManager.MagicDust = DustAmount;
        Debug.Log(value + " dust has been added");
    }

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
