﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DustController : MonoBehaviour {
    public int DustAmount;

    // Use this for initialization
    void Start ()
    {
        //DustAmount = GlobalManager.MagicDust;
        //DustAmount = GlobalGameManager.MagicDust;
        DustAmount = PlayerPrefs.GetInt("Magic Dust ");
        if (GameObject.FindGameObjectWithTag("DustAmount"))
            GameObject.FindGameObjectWithTag("DustAmount").GetComponent<Text>().text = DustAmount.ToString();
    }   

    void Update()
    {
        if (DustAmount < 1)
            DustAmount = 0;
    }

    //adds dust
    public void GetDust(int value)
    {
        DustAmount += value;
        //GlobalManager.MagicDust = DustAmount;
        GlobalGameManager.MagicDust = DustAmount;
        PlayerPrefs.SetInt("Magic Dust ", DustAmount);
        Debug.Log(value + " dust has been added");
    }

    //Loses dust
    public void LoseDust(int value)
    {
        DustAmount -= value;
        //GlobalManager.MagicDust = DustAmount;     
        //PlayerPrefs.SetInt("Magic Dust ", DustAmount);
        Debug.Log(value + " dust has been lost");
        Debug.Log("Dust remain = " + DustAmount);
        GlobalGameManager.MagicDust = DustAmount;
        PlayerPrefs.SetInt("Magic Dust ", DustAmount);
    }

    //updates the amount of dust text
    public void UpdateDust()
    {
        //DustAmount = GlobalManager.MagicDust;
        //DustAmount = GlobalGameManager.MagicDust;
        DustAmount = PlayerPrefs.GetInt("Magic Dust ");
        GameObject.FindGameObjectWithTag("DustAmount").GetComponent<Text>().text = DustAmount.ToString();
        PlayerPrefs.SetInt("Magic Dust ", DustAmount);
    }
}
